//<summary>
//  Title   : Configured server list
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
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Opc.Ua;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// A list of servers.
    /// </summary>
    public partial class ConfiguredServerListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        #region Constructors
        /// <summary>
        /// Initalize the control.
        /// </summary>
        public ConfiguredServerListCtrl()
        {
            InitializeComponent();
            SetColumns(m_ColumnNames);
        }
        #endregion
        
        #region Private Fields
        // The columns to display in the control.		
		private readonly object[][] m_ColumnNames = new object[][]
		{ 
			new object[] { "Name",          HorizontalAlignment.Left, null },  
			new object[] { "Host",          HorizontalAlignment.Left, null },
			new object[] { "Protocol",      HorizontalAlignment.Left, null },
			new object[] { "Security Mode", HorizontalAlignment.Left, null },
			new object[] { "User Token",    HorizontalAlignment.Left, null }
		};
        
        private ApplicationConfiguration m_configuration;
        private ConfiguredEndpointCollection m_endpoints;
        #endregion

        #region Public Interface
        /// <summary>
        /// Displays a list of servers in the control.
        /// </summary>
        public void Initialize(ConfiguredEndpointCollection endpoints, ApplicationConfiguration configuration)
        {
            Interlocked.Exchange(ref m_configuration, configuration);

            ItemsLV.Items.Clear();

            m_endpoints = endpoints;

            if (endpoints != null)
            {
                foreach (ConfiguredEndpoint endpoint in endpoints.Endpoints)
                {
                    AddItem(endpoint);
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
                DeleteMI.Enabled = true;
            }
        }

        /// <summary>
        /// Updates an item in the control.
        /// </summary>
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
            ConfiguredEndpoint endpoint = listItem.Tag as ConfiguredEndpoint;

            if (endpoint == null)
            {
                base.UpdateItem(listItem, endpoint);
                return;
            }

            string hostname = "<Unknown>";
            string protocol = "<Unknown>";

            Uri uri = endpoint.EndpointUrl;
            
            if (uri != null)
            {
                hostname = uri.DnsSafeHost; 
                protocol = uri.Scheme;
            }

			listItem.SubItems[0].Text = String.Format("{0}", endpoint.Description.Server.ApplicationName);
			listItem.SubItems[1].Text = String.Format("{0}", hostname);
			listItem.SubItems[2].Text = String.Format("{0}", protocol); 

			listItem.SubItems[3].Text = String.Format(
                "{0}/{1}", 
                SecurityPolicies.GetDisplayName(endpoint.Description.SecurityPolicyUri),
                endpoint.Description.SecurityMode);
            
			listItem.SubItems[4].Text = "<Unknown>";

            UserTokenPolicy policy = endpoint.SelectedUserTokenPolicy;

            if (policy != null)
            {
                StringBuilder buffer = new StringBuilder();

                buffer.Append(policy.TokenType);

                if (endpoint.UserIdentity != null)
                {
                    buffer.Append("/");
                    buffer.Append(endpoint.UserIdentity);
                }

			    listItem.SubItems[4].Text = buffer.ToString();
            }

            listItem.ImageKey = GuiUtils.Icons.Process;
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

                ConfiguredEndpoint endpoint = new ConfiguredServerDlg().ShowDialog(server, m_configuration);

                if (endpoint == null)
                {
                    return;
                }

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

                endpoint = new ConfiguredServerDlg().ShowDialog(endpoint, m_configuration);

                if (endpoint == null)
                {
                    return;
                }
                
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
