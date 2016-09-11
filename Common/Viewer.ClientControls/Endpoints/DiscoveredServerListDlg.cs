//<summary>
//  Title   : Discovered server list
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
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Opc.Ua;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// Allows the user to browse a list of servers.
    /// </summary>
    public partial class DiscoveredServerListDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes the dialog.
        /// </summary>
        public DiscoveredServerListDlg()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Private Fields
        private string m_hostname;
        private ApplicationDescription m_server;
        private ApplicationConfiguration m_configuration;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public ApplicationDescription ShowDialog(string hostname, ApplicationConfiguration configuration)
        {
            m_configuration = configuration;

            if (String.IsNullOrEmpty(hostname))
            {
                hostname = System.Net.Dns.GetHostName();
            }

            m_hostname = hostname;
            List<string> hostnames = new List<string>();

            HostNameCTRL.Initialize(hostname, hostnames);
            ServersCTRL.Initialize(hostname, configuration);

            OkBTN.Enabled = false;

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }
  
            return m_server;
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

        private void HostNameCTRL_HostSelected(object sender, SelectHostCtrlEventArgs e)
        {
            try
            {
                if (m_hostname != e.Hostname)
                {
                    m_hostname = e.Hostname;
                    ServersCTRL.Initialize(m_hostname, m_configuration);
                    m_server = null;
                    OkBTN.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void HostNameCTRL_HostConnected(object sender, SelectHostCtrlEventArgs e)
        {
            try
            {
                m_hostname = e.Hostname;
                ServersCTRL.Initialize(m_hostname, m_configuration);
                m_server = null;
                OkBTN.Enabled = false;
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
                m_server = null;

                foreach (ApplicationDescription server in e.Items)
                {
                    m_server = server;
                    break;
                }

                OkBTN.Enabled = m_server != null;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ServersCTRL_ItemsPicked(object sender, ListItemActionEventArgs e)
        {
            try
            {
                m_server = null;

                foreach (ApplicationDescription server in e.Items)
                {
                    m_server = server;
                    break;
                }

                if (m_server != null)
                {
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
