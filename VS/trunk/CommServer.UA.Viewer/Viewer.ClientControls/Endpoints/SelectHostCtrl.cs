//<summary>
//  Title   : Select host
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
using Opc.Ua.Configuration;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// Displays a drop down list of hosts.
    /// </summary>
    public partial class SelectHostCtrl : UserControl
    {
        #region Constructors
        /// <summary>
        /// Initializes the control.
        /// </summary>
        public SelectHostCtrl()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Fields
        private int m_selectedIndex;
        private bool m_selectDomains;
        private event EventHandler<SelectHostCtrlEventArgs> m_HostSelected;
        private event EventHandler<SelectHostCtrlEventArgs> m_HostConnected;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Whether the control is used to select domains instead of hosts.
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool SelectDomains
        {
            get { return m_selectDomains;  }
            set { m_selectDomains = value; }
        }

        /// <summary>
        /// The text displayed on the connect button.
        /// </summary>
        [System.ComponentModel.DefaultValue("Connect")]
        public string CommandText
        {
            get { return ConnectBTN.Text;  }
            set { ConnectBTN.Text = value; }
        }

        /// <summary>
        /// Displays a set of hostnames in the control.
        /// </summary>
        public void Initialize(string defaultHost, IList<string> hostnames)
        {
            HostsCB.Items.Clear();
            
            // add option to browse for hosts.
            HostsCB.Items.Add("<Browse...>");

            // add any existing hosts.
            if (hostnames != null)
            {
                foreach (string hostname in hostnames)
                {
                    HostsCB.Items.Add(hostname);
                }
            }
            
            // set a suitable default hostname.
            if (String.IsNullOrEmpty(defaultHost))
            {
                if (!m_selectDomains)
                {
                    defaultHost = System.Net.Dns.GetHostName();
                }
                else
                {
                    defaultHost = ConfigUtils.GetComputerWorkgroupOrDomain();
                }
        
                if (hostnames != null && hostnames.Count > 0)
                {
                    defaultHost = hostnames[0];
                }
            }

            // set the current selection.
            m_selectedIndex = HostsCB.FindString(defaultHost);

            if (m_selectedIndex == -1)
            {
                m_selectedIndex = HostsCB.Items.Add(defaultHost);
            }

            HostsCB.SelectedIndex = m_selectedIndex;
        }

        /// <summary>
        /// Raised when a host is selected in the control.
        /// </summary>
        public event EventHandler<SelectHostCtrlEventArgs> HostSelected
        {
            add { m_HostSelected += value; }
            remove { m_HostSelected -= value; }
        }

        /// <summary>
        /// Raised when the connect button is clicked.
        /// </summary>
        public event EventHandler<SelectHostCtrlEventArgs> HostConnected
        {
            add { m_HostConnected += value; }
            remove { m_HostConnected -= value; }
        }
        #endregion
        
        #region Event Handlers
        private void HostsCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {   
                if (HostsCB.SelectedIndex != 0)
                {
                    if (m_HostSelected != null)
                    {
                        m_HostSelected(this, new SelectHostCtrlEventArgs((string)HostsCB.SelectedItem));
                    }

                    m_selectedIndex = HostsCB.SelectedIndex;
                    return;
                }

                if (!m_selectDomains)
                {
                    // prompt user to select a host.
                    string hostname = new HostListDlg().ShowDialog(null);

                    if (hostname == null)
                    {
                        HostsCB.SelectedIndex = m_selectedIndex;
                        return;
                    }
                    
                    // set the current selection.
                    m_selectedIndex = HostsCB.FindString(hostname);

                    if (m_selectedIndex == -1)
                    {
                        m_selectedIndex = HostsCB.Items.Add(hostname);
                    }
                }
                
                HostsCB.SelectedIndex = m_selectedIndex;
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ConnectBTN_Click(object sender, EventArgs e)
        {
            try
            {   int index = HostsCB.SelectedIndex;

                if (index == 0)
                {
                    return;
                }

                if (m_HostConnected != null)
                {
                    if (index == -1)
                    {
                        if (!String.IsNullOrEmpty(HostsCB.Text))
                        {
                            m_HostConnected(this, new SelectHostCtrlEventArgs(HostsCB.Text));
                        }
                        
                        // add host to list.
                        m_selectedIndex = HostsCB.FindString(HostsCB.Text);

                        if (m_selectedIndex == -1)
                        {
                            m_selectedIndex = HostsCB.Items.Add(HostsCB.Text);
                        }

                        return;
                    }
                
                    m_HostConnected(this, new SelectHostCtrlEventArgs((string)HostsCB.SelectedItem));
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }

    #region SelectHostCtrlEventArgs Class
    /// <summary>
    /// The event arguments passed when the SelectHostCtrlEventArgs raises events.
    /// </summary>
    public class SelectHostCtrlEventArgs : EventArgs
    {
        /// <summary>
        /// Initilizes the object with the current hostname.
        /// </summary>
        public SelectHostCtrlEventArgs(string hostname)
        {
            m_hostname = hostname;
        }

        /// <summary>
        /// The current hostname.
        /// </summary>
        public string Hostname
        {
            get { return m_hostname; }
        }

        private string m_hostname;
    }
    #endregion
}
