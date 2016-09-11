//<summary>
//  Title   : PseudoComServer list
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
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Configuration;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// Displays a list of COM servers registered for use with the UA COM proxy.
    /// </summary>
    public partial class PseudoComServerListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        #region Constructors
        /// <summary>
        /// Initalize the control.
        /// </summary>
        public PseudoComServerListCtrl()
        {
            InitializeComponent();
            SetColumns(m_ColumnNames);
        }
        #endregion
        
        #region Private Fields
        // The columns to display in the control.		
		private readonly object[][] m_ColumnNames = new object[][]
		{ 
			new object[] { "ProgID",        HorizontalAlignment.Left, null },  
			new object[] { "Specification", HorizontalAlignment.Center, null },
			new object[] { "Server",        HorizontalAlignment.Left, null },
			new object[] { "Protocol",      HorizontalAlignment.Left, null },
			new object[] { "Host",          HorizontalAlignment.Left, null },
			new object[] { "Security",      HorizontalAlignment.Left, null }
		};
        
        private ApplicationConfiguration m_configuration;
        #endregion

        #region Public Interface
        /// <summary>
        /// Displays a list of servers in the control.
        /// </summary>
        public void Initialize(ApplicationConfiguration configuration)
        {
            Interlocked.Exchange(ref m_configuration, configuration);

            ItemsLV.Items.Clear();

            foreach (ConfiguredEndpoint server in PseudoComServer.Enumerate())
            {
                if (server.ComIdentity != null)
                {
                    AddItem(server);
                }
            }

            AdjustColumns();
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Enables context menu items.
        /// </summary>
        protected override void EnableMenuItems(ListViewItem clickedItem)
        {
            base.EnableMenuItems(clickedItem);

            NewMI.Enabled = true;   
            
            if (clickedItem != null)
            {
                ConfiguredEndpoint endpoint = clickedItem.Tag as ConfiguredEndpoint;

                if (endpoint == null)
                {
                    return;
                }

                ConfigureMI.Enabled = true;
                ConfigureEndpointMI.Enabled = true;
                DeleteMI.Enabled = true;
            }
        }

        /// <summary>
        /// Updates an item in the control.
        /// </summary>
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
            ConfiguredEndpoint server = listItem.Tag as ConfiguredEndpoint;

            if (server == null)
            {
                base.UpdateItem(listItem, server);
                return;
            }

			listItem.SubItems[0].Text = String.Format("{0}", server.ComIdentity.ProgId);
			listItem.SubItems[1].Text = String.Format("{0}", server.ComIdentity.Specification); 
			listItem.SubItems[2].Text = String.Format("{0}", server.Description.Server.ApplicationName); 

            Uri url = server.EndpointUrl;

            if (url != null)
            {
			    listItem.SubItems[3].Text = String.Format("{0}", url.Scheme); 
			    listItem.SubItems[4].Text = String.Format("{0}", url.DnsSafeHost); 
            }
            else
            {
			    listItem.SubItems[3].Text = String.Format("{0}", ""); 
			    listItem.SubItems[4].Text = String.Format("{0}", ""); 
            }

			listItem.SubItems[5].Text = String.Format(
                "{0}/{1}", 
                SecurityPolicies.GetDisplayName(server.Description.SecurityPolicyUri),
                server.Description.SecurityMode);

            listItem.ImageKey = GuiUtils.Icons.Service;
        }
        #endregion
        
        #region Event Handlers
        private void NewMI_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationDescription server = new DiscoveredServerListDlg().ShowDialog(null, m_configuration);

                if (server == null)
                {
                    return;
                }

                ConfiguredEndpoint endpoint = new ConfiguredEndpoint(server, null);

                endpoint.ComIdentity = new EndpointComIdentity();
                endpoint.ComIdentity.Specification = ComSpecification.DA;

                endpoint = new ConfiguredServerDlg().ShowDialog(endpoint, m_configuration);

                if (endpoint == null)
                {
                    return;
                }
                
                EndpointComIdentity comIdentity = new PseudoComServerDlg().ShowDialog(endpoint);

                if (comIdentity == null)
                {
                    return;
                }

                endpoint.ComIdentity = comIdentity;
                PseudoComServer.Save(endpoint);

                AddItem(endpoint);
                AdjustColumns();
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ConfigureMI_Click(object sender, EventArgs e)
        {
            try
            {
                ConfiguredEndpoint endpoint = SelectedTag as ConfiguredEndpoint;
                
                if (endpoint == null)
                {
                    return;
                }

                EndpointComIdentity comIdentity = new PseudoComServerDlg().ShowDialog(endpoint);

                if (comIdentity == null)
                {
                    return;
                }
                
                endpoint.ComIdentity = comIdentity;
                PseudoComServer.Save(endpoint);
                
                UpdateItem(ItemsLV.SelectedItems[0], endpoint);
                AdjustColumns();
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        
        private void ConfigureEndpointMI_Click(object sender, EventArgs e)
        {
            try
            {
                ConfiguredEndpoint endpoint = SelectedTag as ConfiguredEndpoint;
                
                if (endpoint == null)
                {
                    return;
                }

                endpoint = new ConfiguredServerDlg().ShowDialog(endpoint, m_configuration);

                if (endpoint == null)
                {
                    return;
                }
                
                PseudoComServer.Save(endpoint);
                UpdateItem(ItemsLV.SelectedItems[0], endpoint);
                AdjustColumns();
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void DeleteMI_Click(object sender, EventArgs e)
        {
            try
            {
                ConfiguredEndpoint endpoint = SelectedTag as ConfiguredEndpoint;
                
                if (endpoint == null)
                {
                    return;
                }

                PseudoComServer.Delete(endpoint.ComIdentity.Clsid);

                ItemsLV.SelectedItems[0].Remove();
                AdjustColumns();
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
