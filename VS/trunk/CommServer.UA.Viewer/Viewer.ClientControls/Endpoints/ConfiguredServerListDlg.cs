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
using System.Windows.Forms;
using Opc.Ua;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// Allows the user to browse a list of servers.
    /// </summary>
    public partial class ConfiguredServerListDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes the dialog.
        /// </summary>
        public ConfiguredServerListDlg()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Private Fields
        private ConfiguredEndpoint m_endpoint;
        private ApplicationConfiguration m_configuration;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public ConfiguredEndpoint ShowDialog(ApplicationConfiguration configuration, bool createNew)
        {
            m_configuration = configuration;
            m_endpoint = null;

            // create a default collection if none provided.
            if (createNew)
            {
                ApplicationDescription server = new DiscoveredServerListDlg().ShowDialog(null, m_configuration);

                if (server != null)
                {
                    return new ConfiguredEndpoint(server, EndpointConfiguration.Create(configuration));
                }

                return null;
            }
            
            ServersCTRL.Initialize(null, configuration);
            
            OkBTN.Enabled = false;

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }
  
            return m_endpoint;
        }
        #endregion
        
        #region Event Handlers
        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ServersCTRL_ItemsSelected(object sender, ListItemActionEventArgs e)
        {
            try
            {
                m_endpoint = null;

                foreach (ConfiguredEndpoint server in e.Items)
                {
                    m_endpoint = server;
                    break;
                }

                OkBTN.Enabled = m_endpoint != null;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
