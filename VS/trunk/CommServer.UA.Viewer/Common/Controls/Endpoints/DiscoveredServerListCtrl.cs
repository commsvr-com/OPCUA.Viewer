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
using System.Threading;
using System.Windows.Forms;
using Opc.Ua;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// Displays a list of servers.
    /// </summary>
    public partial class DiscoveredServerListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        #region Constructors
        /// <summary>
        /// Initalize the control.
        /// </summary>
        public DiscoveredServerListCtrl()
        {
            InitializeComponent();
            SetColumns(m_ColumnNames);
            ItemsLV.Sorting = SortOrder.Descending;
            ItemsLV.MultiSelect = false;
        }
        #endregion
        
        #region Private Fields
        // The columns to display in the control.		
		private readonly object[][] m_ColumnNames = new object[][]
		{ 
			new object[] { "Name", HorizontalAlignment.Left, null },  
			new object[] { "Type", HorizontalAlignment.Left, null },
			new object[] { "Host", HorizontalAlignment.Left, null },
			new object[] { "URI",  HorizontalAlignment.Left, null }
		};
        
        private ApplicationConfiguration m_configuration;
        private int m_discoveryTimeout;
        private int m_discoverCount;
        private string m_discoveryUrl;
        #endregion

        #region Public Interface
        /// <summary>
        /// The timeout in milliseconds to use when discovering servers.
        /// </summary>
        [System.ComponentModel.DefaultValue(5000)]
        public int DiscoveryTimeout
        {
            get { return m_discoveryTimeout; }
            set { m_discoveryTimeout = value; }
        }

        /// <summary>
        /// Gets or sets the discovery URL used to find the servers displayed in the control.
        /// </summary>
        /// <value>The discovery URL.</value>
        public string DiscoveryUrl
        {
            get { return m_discoveryUrl; }
            set { m_discoveryUrl = value; }
        }

        /// <summary>
        /// Displays a list of servers in the control.
        /// </summary>
        public void Initialize(ConfiguredEndpointCollection endpoints, ApplicationConfiguration configuration)
        {
            Interlocked.Exchange(ref m_configuration, configuration);

            ItemsLV.Items.Clear();

            foreach (ApplicationDescription server in endpoints.GetServers())
            {
                AddItem(server);
            }

            AdjustColumns();
        }

        /// <summary>
        /// Displays a list of servers in the control.
        /// </summary>
        public void Initialize(string hostname, ApplicationConfiguration configuration)
        {
            Interlocked.Exchange(ref m_configuration, configuration);

            ItemsLV.Items.Clear();

            if (String.IsNullOrEmpty(hostname))
            {
                hostname = System.Net.Dns.GetHostName();
            }
            
            this.Instructions = Utils.Format("Discovering servers on host '{0}'.", hostname);
            AdjustColumns();

            // get a list of well known discovery urls to use.
            StringCollection discoveryUrls = null;

            if (configuration != null && configuration.ClientConfiguration != null)
            {
                discoveryUrls = configuration.ClientConfiguration.WellKnownDiscoveryUrls;
            }

            if (discoveryUrls == null || discoveryUrls.Count == 0)
            {
                discoveryUrls = new StringCollection(Utils.DiscoveryUrls);
            }
            
            // update the urls with the hostname.
            StringCollection urlsToUse = new StringCollection();

            foreach (string discoveryUrl in discoveryUrls)
            {
                urlsToUse.Add(Utils.Format(discoveryUrl, hostname));
            }

            Interlocked.Increment(ref m_discoverCount);
            ThreadPool.QueueUserWorkItem(new WaitCallback(OnDiscoverServers), urlsToUse);
        }

        /// <summary>
        /// Updates the list of servers displayed in the control.
        /// </summary>
        private void OnUpdateServers(object state)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new WaitCallback(OnUpdateServers), state);
                return;
            }
            
            ItemsLV.Items.Clear();

            ApplicationDescriptionCollection servers = state as ApplicationDescriptionCollection;

            if (servers != null)
            {
                foreach (ApplicationDescription server in servers)
                {
                    if (server.ApplicationType == ApplicationType.DiscoveryServer)
                    {
                        continue;
                    }

                    AddItem(server);
                }
            }

            if (ItemsLV.Items.Count == 0)
            {
                this.Instructions = Utils.Format("No servers to display.");
            }

            AdjustColumns();
        }

        /// <summary>
        /// Attempts fetch the list of servers from the discovery server.
        /// </summary>
        private void OnDiscoverServers(object state)
        {
            try
            {
                int discoverCount = m_discoverCount;

                // do nothing if a valid list is not provided.
                IList<string> discoveryUrls = state as IList<string>;

                if (discoveryUrls == null)
                {
                    return;
                }

                // process each url.
                foreach (string discoveryUrl in discoveryUrls)
                {
                    Uri url = Utils.ParseUri(discoveryUrl);

                    if (url != null)
                    {
                        if (DiscoverServers(url))
                        {
                            return;
                        }

                        // check if another discover operation has started.
                        if (discoverCount != m_discoverCount)
                        {
                            return;
                        }
                    }
                }

                // display empty list.
                OnUpdateServers(null);
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error discovering servers.");
            }
        }

        /// <summary>
        /// Fetches the servers from the discovery server.
        /// </summary>
        private bool DiscoverServers(Uri discoveryUrl)
        {
            // use a short timeout.
            EndpointConfiguration configuration = EndpointConfiguration.Create(m_configuration);
            configuration.OperationTimeout = m_discoveryTimeout;

            DiscoveryClient client = null;

            try
            {
                client = DiscoveryClient.Create(
                    discoveryUrl,
                    BindingFactory.Create(m_configuration, m_configuration.CreateMessageContext()),
                    EndpointConfiguration.Create(m_configuration));

                ApplicationDescriptionCollection servers = client.FindServers(null);
                m_discoveryUrl = discoveryUrl.ToString();
                OnUpdateServers(servers);
                return true;
            }
            catch (Exception e)
            {
                Utils.Trace("DISCOVERY ERROR - Could not fetch servers from url: {0}. Error=({2}){1}", discoveryUrl, e.Message, e.GetType());
                return false;
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Updates an item in the control.
        /// </summary>
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
            ApplicationDescription server = listItem.Tag as ApplicationDescription;

            if (server == null)
            {
                base.UpdateItem(listItem, server);
                return;
            }

            string hostname = "";

            // extract host from application uri.
            Uri uri = Utils.ParseUri(server.ApplicationUri);
            
            if (uri != null)
            {
                hostname = uri.DnsSafeHost; 
            }

            // get the host name from the discovery urls.
            if (String.IsNullOrEmpty(hostname))
            {
                foreach (string discoveryUrl in server.DiscoveryUrls)
                {
                    Uri url = Utils.ParseUri(discoveryUrl);

                    if (url != null)
                    {
                        hostname = url.DnsSafeHost;
                        break;
                    }
                }
            }

			listItem.SubItems[0].Text = String.Format("{0}", server.ApplicationName);
			listItem.SubItems[1].Text = String.Format("{0}", server.ApplicationType);
			listItem.SubItems[2].Text = String.Format("{0}", hostname);
			listItem.SubItems[3].Text = String.Format("{0}", server.ApplicationUri); 

            listItem.ImageKey = GuiUtils.Icons.Service;
        }
        #endregion
    }
}
