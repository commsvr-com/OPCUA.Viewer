//<summary>
//  Title   : Host list
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Configuration;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// A list of hosts.
    /// </summary>
    public partial class HostListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        #region Constructors
        /// <summary>
        /// Initalize the control.
        /// </summary>
        public HostListCtrl()
        {
            InitializeComponent();
            SetColumns(m_ColumnNames);            
            m_enumerator = new HostEnumerator();
            m_enumerator.HostsDiscovered += new EventHandler<HostEnumeratorEventArgs>(HostEnumerator_HostsDiscovered);
        }
        #endregion
        
        #region Private Fields
        // The columns to display in the control.		
		private readonly object[][] m_ColumnNames = new object[][]
		{ 
			new object[] { "Name",        HorizontalAlignment.Left, null },  
			new object[] { "Addresses",   HorizontalAlignment.Left, null }
		};
        
        private HostEnumerator m_enumerator;
        private bool m_waitingForHosts;
        #endregion

        #region Public Interface
        /// <summary>
        /// Displays a list of servers in the control.
        /// </summary>
        public void Initialize(string domain)
        {
            ItemsLV.Items.Clear();

            this.Instructions = Utils.Format("Discovering hosts on domain '{0}'.", domain);
            AdjustColumns();

            m_waitingForHosts = true;
            m_enumerator.Start(domain);
        }
        #endregion
        
        #region Private Methods
        /// <summary>
        /// Finds the addresses for the specified host.
        /// </summary>
        private void OnFetchAddresses(object state)
        {
            ListViewItem listItem = state as ListViewItem;

            if (listItem == null)
            {
                return;
            }

            string hostname = listItem.Tag as string;

            if (hostname == null)
            {
                return;
            }

            try
            {
                IPAddress[] addresses = Dns.GetHostAddresses(hostname);

                StringBuilder buffer = new StringBuilder();

                for (int ii = 0; ii < addresses.Length; ii++)
                {
                    if (buffer.Length > 0)
                    {
                        buffer.Append(", ");
                    }

                    buffer.AppendFormat("{0}", addresses[ii]);
                }

                ThreadPool.QueueUserWorkItem(new WaitCallback(OnUpdateAddress), new object[] { listItem, buffer.ToString() });
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Could not get ip addresses for host: {0}", hostname);                
                ThreadPool.QueueUserWorkItem(new WaitCallback(OnUpdateAddress), new object[] { listItem, e.Message });
            }
        }

        /// <summary>
        /// Updates the addresses for a host.
        /// </summary>
        private void OnUpdateAddress(object state)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new WaitCallback(OnUpdateAddress), state);
                return;
            }
            
            ListViewItem listItem = ((object[])state)[0] as ListViewItem;

            if (listItem == null)
            {
                return;
            }

            string addresses = ((object[])state)[1] as string;

            if (addresses == null)
            {
                return;
            }

			listItem.SubItems[1].Text = addresses;

            AdjustColumns();
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Updates an item in the control.
        /// </summary>
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
            string hostname = listItem.Tag as string;

            if (hostname == null)
            {
                base.UpdateItem(listItem, hostname);
                return;
            }

			listItem.SubItems[0].Text = String.Format("{0}", hostname);
			listItem.SubItems[1].Text = "<Unknown>";

            listItem.ImageKey = GuiUtils.Icons.Computer;

            ThreadPool.QueueUserWorkItem(new WaitCallback(OnFetchAddresses), listItem);
        }
        #endregion
        
        #region Event Handlers
        private void HostEnumerator_HostsDiscovered(object sender, HostEnumeratorEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<HostEnumeratorEventArgs>(HostEnumerator_HostsDiscovered), sender, e);
                return;
            }

            // check if this is the first callback.
            if (m_waitingForHosts)
            {
                ItemsLV.Items.Clear();
                m_waitingForHosts = false;
            }

            // populate list with hostnames.
            if (e != null && e.Hostnames != null)
            {
                foreach (string hostname in e.Hostnames)
                {
                    AddItem(hostname);
                }
            }
                
            AdjustColumns();
        }
        #endregion
    }
}
