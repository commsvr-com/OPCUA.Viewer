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
using System.Reflection;
using System.Windows.Forms;
using Opc.Ua.Configuration;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// Allows the user to browse a list of servers.
    /// </summary>
    public partial class HostListDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes the dialog.
        /// </summary>
        public HostListDlg()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Private Fields
        private string m_domain;
        private string m_hostname;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public string ShowDialog(string domain)
        {
            if (String.IsNullOrEmpty(domain))
            {
                domain = ConfigUtils.GetComputerWorkgroupOrDomain();
            }

            m_domain = domain;

            DomainNameCTRL.Initialize(m_domain, null);
            HostsCTRL.Initialize(m_domain);
            OkBTN.Enabled = false;

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }
  
            return m_hostname;
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

        private void DomainNameCTRL_HostSelected(object sender, SelectHostCtrlEventArgs e)
        {
            try
            {
                if (m_domain != e.Hostname)
                {
                    m_domain = e.Hostname;
                    HostsCTRL.Initialize(m_domain);
                    m_hostname = null;
                    OkBTN.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void DomainNameCTRL_HostConnected(object sender, SelectHostCtrlEventArgs e)
        {
            try
            {
                m_domain = e.Hostname;
                HostsCTRL.Initialize(m_domain);
                m_hostname = null;
                OkBTN.Enabled = false;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void HostsCTRL_ItemsSelected(object sender, ListItemActionEventArgs e)
        {
            try
            {
                m_hostname = null;

                foreach (string hostname in e.Items)
                {
                    m_hostname = hostname;
                    break;
                }

                OkBTN.Enabled = !String.IsNullOrEmpty(m_hostname);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void HostsCTRL_ItemsPicked(object sender, ListItemActionEventArgs e)
        {
            try
            {
                m_hostname = null;

                foreach (string hostname in e.Items)
                {
                    m_hostname = hostname;
                    break;
                }

                if (!String.IsNullOrEmpty(m_hostname))
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
