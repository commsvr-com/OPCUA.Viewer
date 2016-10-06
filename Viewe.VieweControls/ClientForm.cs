//<summary>
//  Title   : Client form
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
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CAS.Lib.ControlLibrary;
using CAS.OPC.UA.Viewer.Client.Controls;
using CAS.OPC.UA.Viewer.Sample.Properties;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System.Diagnostics;
using CAS.Lib.CodeProtect.Controls;
using System.Resources;
using System.IO;
using CAS.Lib.CodeProtect;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class ClientForm : Form
    {
        #region Private Fields
        private Session m_session;
        private ApplicationInstance m_application;
        private Opc.Ua.Server.StandardServer m_server;
        private ConfiguredEndpointCollection m_endpoints;
        private ApplicationConfiguration m_configuration;
        private ServiceMessageContext m_context;
        private ClientForm m_masterForm;
        private List<ClientForm> m_forms;
        private BaseTreeCtrl m_btcSession;
        private BaseTreeCtrl m_btcBrowse;
        #endregion
        
        public ClientForm()
        {
            InitializeComponent();
        }

        public ClientForm(
            ServiceMessageContext context,
            ApplicationInstance application, 
            ClientForm masterForm, 
            ApplicationConfiguration configuration)
        {
            InitializeComponent();
            if (maintenanceControlComponent.Warning != null)
              Utils.Trace( "The following warning(s) appeared during loading the license: " + maintenanceControlComponent.Warning );        
            m_masterForm = masterForm;
            m_context = context;
            m_application = application;
            m_server = application.Server as Opc.Ua.Server.StandardServer;

            if (m_masterForm == null)
            {
                m_forms = new List<ClientForm>();
            }

            SessionsCTRL.Configuration  = m_configuration = configuration;
            SessionsCTRL.MessageContext = context;

            m_btcBrowse = (BaseTreeCtrl)BrowseCTRL;
            m_btcSession = (BaseTreeCtrl)SessionsCTRL;
            m_btcSession.NodesTV.MouseDown += new MouseEventHandler( NodesTVInSession_MouseDown );
            m_btcBrowse.NodesTV.MouseDown += new MouseEventHandler( NodesTVInBrowse_MouseDown );

          // get list of cached endpoints.
            m_endpoints = m_configuration.LoadCachedEndpoints(true);
            m_endpoints.DiscoveryUrls = configuration.ClientConfiguration.WellKnownDiscoveryUrls;
            EndpointSelectorCTRL.Initialize(m_endpoints, m_configuration);

            // initialize control state.
            Disconnect();
        }

        void NodesTVInSession_MouseDown( object sender, MouseEventArgs e )
        {
          m_btcSession.NodesTV_MouseDown( sender, e );
          TreeNode selectedNode = null;
          if ( sender is TreeView )
            selectedNode = ( (TreeView)sender ).SelectedNode;
          if ( selectedNode != null )
          {
            Session session = selectedNode.Tag as Session;
            MonitoredItem monitoredItem = selectedNode.Tag as MonitoredItem;
            Subscription subscription = selectedNode.Tag as Subscription;
            if ( session != null )
            {
              //Session controls on the toolbar should be enabled
              toolStripMainNewSessionButton.Enabled = true;
              toolStripMainDeleteSessionButton.Enabled = true;
              toolStripMainLoadSubscriptionButton.Enabled = true;
              toolStripMainSaveSubscriptionButton.Enabled = true;
              //Browse controls on the toolbar should be disabled
              toolStripMainBrowseASButton.Enabled = false;
              toolStripMainReadValueButton.Enabled = false;
              toolStripMainWriteValueButton.Enabled = false;
              //Session controls should be enabled
              SessionsCTRL.NewSessionMI.Enabled = true;
              SessionsCTRL.DeleteMI.Enabled = true;
              SessionsCTRL.SessionSaveMI.Enabled = true;
              SessionsCTRL.SessionLoadMI.Enabled = true;
              SessionsCTRL.BrowseMI.Enabled = true;
              SessionsCTRL.BrowseAllMI.Enabled = true;
              SessionsCTRL.BrowseObjectsMI.Enabled = true;
              SessionsCTRL.BrowseServerViewsMI.Enabled = true;
              SessionsCTRL.BrowseObjectTypesMI.Enabled = true;
              SessionsCTRL.BrowseVariableTypesMI.Enabled = true;
              SessionsCTRL.BrowseDataTypesMI.Enabled = true;
              SessionsCTRL.BrowseReferenceTypesMI.Enabled = true;
              SessionsCTRL.BrowseEventTypesMI.Enabled = true;
              SessionsCTRL.SubscriptionMI.Enabled = true;
              SessionsCTRL.SubscriptionCreateMI.Enabled = true;
              SessionsCTRL.SubscriptionMonitorMI.Enabled = true;
              SessionsCTRL.SubscriptionEnabledPublishingMI.Enabled = true;
              SessionsCTRL.ReadMI.Enabled = true;
              SessionsCTRL.WriteMI.Enabled = true;
              //Browse controls should be disabled
              BrowseCTRL.BrowseOptionsMI.Enabled = false;
              BrowseCTRL.ShowReferencesMI.Enabled = false;
              BrowseCTRL.BrowseMI.Enabled = false;
              BrowseCTRL.ViewAttributesMI.Enabled = false;
              BrowseCTRL.ReadMI.Enabled = false;
              BrowseCTRL.HistoryReadMI.Enabled = false;
              BrowseCTRL.WriteMI.Enabled = false;
              BrowseCTRL.HistoryUpdateMI.Enabled = false;
              BrowseCTRL.EncodingsMI.Enabled = false;
              BrowseCTRL.SubscribeMI.Enabled = false;
              BrowseCTRL.SubscribeNewMI.Enabled = false;
              BrowseCTRL.CallMI.Enabled = false;
              BrowseCTRL.SelectMI.Enabled = false;
              BrowseCTRL.SelectItemMI.Enabled = false;
              BrowseCTRL.SelectChildrenMI.Enabled = false;
            }
            else if( subscription != null || monitoredItem != null)
            {
              toolStripMainNewSessionButton.Enabled = true;
              toolStripMainDeleteSessionButton.Enabled = true;
              toolStripMainLoadSubscriptionButton.Enabled = false;
              toolStripMainSaveSubscriptionButton.Enabled = false;
              toolStripMainBrowseASButton.Enabled = false;
            }
          }
          else
            DisableAllButtons();
        }
       
        void NodesTVInBrowse_MouseDown( object sender, MouseEventArgs e )
        {
          m_btcBrowse.NodesTV_MouseDown( sender, e );
          TreeNode selectedNode = null;
          if ( sender is TreeView )
            selectedNode = ( (TreeView)sender ).SelectedNode;
          if ( selectedNode != null )
          {
              //Session controls on the toolbar should be disabled
              toolStripMainNewSessionButton.Enabled = false;
              toolStripMainDeleteSessionButton.Enabled = false;
              toolStripMainLoadSubscriptionButton.Enabled = false;
              toolStripMainSaveSubscriptionButton.Enabled = false;
              //Browse controls on the toolbar should be enabled
              toolStripMainBrowseASButton.Enabled = true;
              toolStripMainReadValueButton.Enabled = true;
              toolStripMainWriteValueButton.Enabled = true;
              //Session controls should be disabled
              SessionsCTRL.NewSessionMI.Enabled = false;
              SessionsCTRL.DeleteMI.Enabled = false;
              SessionsCTRL.SessionSaveMI.Enabled = false;
              SessionsCTRL.SessionLoadMI.Enabled = false;
              SessionsCTRL.BrowseMI.Enabled = false;
              SessionsCTRL.BrowseAllMI.Enabled = false;
              SessionsCTRL.BrowseObjectsMI.Enabled = false;
              SessionsCTRL.BrowseServerViewsMI.Enabled = false;
              SessionsCTRL.BrowseObjectTypesMI.Enabled = false;
              SessionsCTRL.BrowseVariableTypesMI.Enabled = false;
              SessionsCTRL.BrowseDataTypesMI.Enabled = false;
              SessionsCTRL.BrowseReferenceTypesMI.Enabled = false;
              SessionsCTRL.BrowseEventTypesMI.Enabled = false;
              SessionsCTRL.SubscriptionMI.Enabled = false;
              SessionsCTRL.SubscriptionCreateMI.Enabled = false;
              SessionsCTRL.SubscriptionMonitorMI.Enabled = false;
              SessionsCTRL.SubscriptionEnabledPublishingMI.Enabled = false;
              SessionsCTRL.ReadMI.Enabled = false;
              SessionsCTRL.WriteMI.Enabled = false;
              //Browse controls should be enabled
              BrowseCTRL.BrowseOptionsMI.Enabled = true;
              BrowseCTRL.ShowReferencesMI.Enabled = true;
              BrowseCTRL.BrowseMI.Enabled = true;
              BrowseCTRL.ViewAttributesMI.Enabled = true;
              BrowseCTRL.ReadMI.Enabled = true;
              BrowseCTRL.HistoryReadMI.Enabled = true;
              BrowseCTRL.WriteMI.Enabled = true;
              BrowseCTRL.HistoryUpdateMI.Enabled = false; //TODO It used to be true in SDK 1.318
              BrowseCTRL.EncodingsMI.Enabled = true;
              BrowseCTRL.SubscribeMI.Enabled = true;
              BrowseCTRL.SubscribeNewMI.Enabled = true;
              BrowseCTRL.CallMI.Enabled = true;
              BrowseCTRL.SelectMI.Enabled = true;
              BrowseCTRL.SelectItemMI.Enabled = true;
              BrowseCTRL.SelectChildrenMI.Enabled = true;
          }
          else
            DisableAllButtons();
        }
        
        /// <summary>
        /// Disables all buttons.
        /// </summary>
        private void DisableAllButtons()
        {
          toolStripMainNewSessionButton.Enabled = false;
          toolStripMainDeleteSessionButton.Enabled = false;
          toolStripMainLoadSubscriptionButton.Enabled = false;
          toolStripMainSaveSubscriptionButton.Enabled = false;
          toolStripMainBrowseASButton.Enabled = false;
          toolStripMainReadValueButton.Enabled = false;
          toolStripMainWriteValueButton.Enabled = false;
          SessionsCTRL.NewSessionMI.Enabled = false;
          SessionsCTRL.DeleteMI.Enabled = false;
          SessionsCTRL.SessionSaveMI.Enabled = false;
          SessionsCTRL.SessionLoadMI.Enabled = false;
          SessionsCTRL.BrowseMI.Enabled = false;
          SessionsCTRL.BrowseAllMI.Enabled = false;
          SessionsCTRL.BrowseObjectsMI.Enabled = false;
          SessionsCTRL.BrowseServerViewsMI.Enabled = false;
          SessionsCTRL.BrowseObjectTypesMI.Enabled = false;
          SessionsCTRL.BrowseVariableTypesMI.Enabled = false;
          SessionsCTRL.BrowseDataTypesMI.Enabled = false;
          SessionsCTRL.BrowseReferenceTypesMI.Enabled = false;
          SessionsCTRL.BrowseEventTypesMI.Enabled = false;
          SessionsCTRL.SubscriptionMI.Enabled = false;
          SessionsCTRL.SubscriptionCreateMI.Enabled = false;
          SessionsCTRL.SubscriptionMonitorMI.Enabled = false;
          SessionsCTRL.SubscriptionEnabledPublishingMI.Enabled = false;
          SessionsCTRL.ReadMI.Enabled = false;
          SessionsCTRL.WriteMI.Enabled = false;
          BrowseCTRL.BrowseOptionsMI.Enabled = false;
          BrowseCTRL.ShowReferencesMI.Enabled = false;
          BrowseCTRL.BrowseMI.Enabled = false;
          BrowseCTRL.ViewAttributesMI.Enabled = false;
          BrowseCTRL.ReadMI.Enabled = false;
          BrowseCTRL.HistoryReadMI.Enabled = false;
          BrowseCTRL.WriteMI.Enabled = false;
          BrowseCTRL.HistoryUpdateMI.Enabled = false;
          BrowseCTRL.EncodingsMI.Enabled = false;
          BrowseCTRL.SubscribeMI.Enabled = false;
          BrowseCTRL.SubscribeNewMI.Enabled = false;
          BrowseCTRL.CallMI.Enabled = false;
          BrowseCTRL.SelectMI.Enabled = false;
          BrowseCTRL.SelectItemMI.Enabled = false;
          BrowseCTRL.SelectChildrenMI.Enabled = false;
          return;
        }
        
        /// <summary>
        /// Opens a new form.
        /// </summary>
        public void OpenForm()
        {
            if (m_masterForm == null)
            {
                ClientForm form = new ClientForm(m_context, m_application, this, m_configuration);
                m_forms.Add(form);
                form.FormClosing += new FormClosingEventHandler(Window_FormClosing);
                form.Show();
            }
            else
            {
                m_masterForm.OpenForm();
            }
        }

        /// <summary>
        /// Handles a close event fo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int ii = 0; ii < m_forms.Count; ii++)
            {
                if (Object.ReferenceEquals(m_forms[ii], sender))
                {
                    m_forms.RemoveAt(ii);
                    break;
                }
            }
        }

        /// <summary>
        /// Disconnect from the server if ths form is closing.
        /// </summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (m_masterForm == null && m_forms.Count > 0)
            {
                if (MessageBox.Show("Close all sessions?", "Close Window", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }

                List<ClientForm> forms = new List<ClientForm>(m_forms);

                foreach (ClientForm form in forms)
                {
                    form.Close();
                }
            }

            Disconnect();
        }
        
        /// <summary>
        /// Disconnects from a server.
        /// </summary>
        public void Disconnect()
        {
            if (m_session != null)
            {
                m_session.Close();
                m_session = null;
            }

            ServerUrlLB.Text = "";
        }

        /// <summary>
        /// Provides a user defined method.
        /// </summary>
        protected virtual void DoTest(Session session)
        {
            MessageBox.Show("A handy place to put test code.");
        }
        
        void EndpointSelectorCTRL_ConnectEndpoint(object sender, ConnectEndpointEventArgs e)
        {
            try
            {
                Connect(e.Endpoint);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
                e.UpdateControl = false;
            }
        }

        private void EndpointSelectorCTRL_OnChange(object sender, EventArgs e)
        {
            try
            {
                m_endpoints.Save();
            }
            catch (Exception)
            {
				// GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Connects to a server.
        /// </summary>
        public void Connect(ConfiguredEndpoint endpoint)
        {
            if (endpoint == null)
            {
                return;
            }

            Session session = SessionsCTRL.Connect(endpoint); 

            if (session != null)
            {
                m_session = session;
                m_session.KeepAlive += new KeepAliveEventHandler(StandardClient_KeepAlive);
                BrowseCTRL.SetView(m_session, BrowseViewType.Objects, null);
                StandardClient_KeepAlive(m_session, null);
            }
        }

        /// <summary>
        /// Updates the status control when a keep alive event occurs.
        /// </summary>
        void StandardClient_KeepAlive(Session sender, KeepAliveEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new KeepAliveEventHandler(StandardClient_KeepAlive), sender, e);
                return;
            }
            else if (!IsHandleCreated)
            {
                return;
            }

            if (sender != null && sender.Endpoint != null)
            {
                ServerUrlLB.Text = Utils.Format(
                    "{0} ({1}) {2}", 
                    sender.Endpoint.EndpointUrl, 
                    sender.Endpoint.SecurityMode, 
                    (sender.EndpointConfiguration.UseBinaryEncoding)?"UABinary":"XML");
            }
            else
            {
                ServerUrlLB.Text = "None";
            }

            if (e != null && m_session != null)
            {            
                if (ServiceResult.IsGood(e.Status))
                {
                    ServerStatusLB.Text = Utils.Format(
                        "Server Status: {0} {1:yyyy-MM-dd HH:mm:ss} {2}/{3}", 
                        e.CurrentState, 
                        e.CurrentTime.ToLocalTime(), 
                        m_session.OutstandingRequestCount, 
                        m_session.DefunctRequestCount);
                    
                    ServerStatusLB.ForeColor = Color.Empty;
                    ServerStatusLB.Font = new Font(ServerStatusLB.Font, FontStyle.Regular);
                }
                else
                {
                    ServerStatusLB.Text = String.Format(
                        "{0} {1}/{2}", e.Status,
                        m_session.OutstandingRequestCount, 
                        m_session.DefunctRequestCount);

                    ServerStatusLB.ForeColor = Color.Red;
                    ServerStatusLB.Font = new Font(ServerStatusLB.Font, FontStyle.Bold);
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {            
            try
            {
                SessionsCTRL.Close();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        private void opcUaEbookToolStripMenuItem_Click( object sender, EventArgs e )
        {
          System.Diagnostics.Process.Start( Resources.OpcUaEbook ); 
        }
        private void FileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PerformanceTestMI_Click(object sender, EventArgs e)
        {  
            try
            {
                new PerformanceTestDlg().ShowDialog(
                    m_configuration,
                    m_endpoints,
                    m_configuration.SecurityConfiguration.ApplicationCertificate.Find(true));
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void DiscoverServersMI_Click(object sender, EventArgs e)
        {
            try
            {
                ConfiguredEndpoint endpoint = new ConfiguredServerListDlg().ShowDialog(m_configuration, true);
                
                if (endpoint != null)
                {
                    this.EndpointSelectorCTRL.SelectedEndpoint = endpoint;
                    return;
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void NewWindowMI_Click(object sender, EventArgs e)
        {
            try
            {
                this.OpenForm();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void Discovery_RegisterMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_server != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(OnRegister, null);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void OnRegister(object sender)
        {
            try
            {
                Opc.Ua.Server.StandardServer server = m_server;

                if (server != null)
                {
                    server.RegisterWithDiscoveryServer();
                }
            }
            catch (Exception exception)
            {
				Utils.Trace(exception, "Could not register with the LDS");
            }
        }

        private void Task_TestMI_Click(object sender, EventArgs e)
        {
            try
            {
                DoTest(m_session);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void rSSFeedToolStripMenuItem_Click( object sender, EventArgs e )
        {
          System.Diagnostics.Process.Start( Resources.RSS );
        }

        private void supportToolStripMenuItem_Click( object sender, EventArgs e )
        {
          string MessageToBeShown = Resources.Support_MessageToBeShown;
          string MessageCaption = Resources.Support_MessageCaption;
          string emailAddress = Resources.Support_emailAddress;
          string messageSubject = Resources.Support_messageSubject;
          string MessageBody = Resources.Support_MessageBody;
          MessageBoxSentEmail.ShowMessageAndOpenEmailClient( MessageToBeShown, MessageCaption, DialogResult.OK, MessageBoxButtons.OKCancel, emailAddress, messageSubject, MessageBody );
        }

        private void homeToolStripMenuItem_Click( object sender, EventArgs e )
        {
          System.Diagnostics.Process.Start( Resources.Home );
        }

        private void aboutToolStripMenuItem_Click( object sender, EventArgs e )
        {
          using ( AboutForm dial = new AboutForm ( CAS.OPC.UA.Viewer.Sample.Properties.Resources.Przegl_48, "Freeware", Assembly.GetEntryAssembly() ) )
          {
            dial.ShowDialog();
          }
        }

        private void toolStripMainOpcUaEbookButton_Click( object sender, EventArgs e )
        {
          System.Diagnostics.Process.Start( Resources.OpcUaEbook );
        }

        private void toolStripMainSupportButton_Click( object sender, EventArgs e )
        {
          string MessageToBeShown = Resources.Support_MessageToBeShown;
          string MessageCaption = Resources.Support_MessageCaption;
          string emailAddress = Resources.Support_emailAddress;
          string messageSubject = Resources.Support_messageSubject;
          string MessageBody = Resources.Support_MessageBody;
          MessageBoxSentEmail.ShowMessageAndOpenEmailClient( MessageToBeShown, MessageCaption, DialogResult.OK, MessageBoxButtons.OKCancel, emailAddress, messageSubject, MessageBody );
        }

        private void toolStripMainNewSessionButton_Click( object sender, EventArgs e )
        {
          BrowseCTRL.SessionTreeCtrl.NewSessionMI_Click( sender, e ); 
        }

        private void toolStripMainDeleteSessionButton_Click( object sender, EventArgs e )
        {
          BrowseCTRL.SessionTreeCtrl.DeleteMI_Click( sender, e );
        }

        private void toolStripMainLoadSubscriptionButton_Click( object sender, EventArgs e )
        {
          BrowseCTRL.SessionTreeCtrl.SessionLoadMI_Click( sender, e );
        }

        private void toolStripMainSaveSubscriptionButton_Click( object sender, EventArgs e )
        {
          BrowseCTRL.SessionTreeCtrl.SessionSaveMI_Click( sender, e );
        }

        private void toolStripMainBrowseASButton_Click( object sender, EventArgs e )
        {
          BrowseCTRL.BrowseMI_Click( sender, e );
        }

        private void toolStripMainReadValueButton_Click( object sender, EventArgs e )
        {
          BrowseCTRL.ReadMI_Click( sender, e );
        }

        private void toolStripMainWriteValueButton_Click( object sender, EventArgs e )
        {
          BrowseCTRL.WriteMI_Click( sender, e );
        }

        void tabControl_Selected( object sender, System.Windows.Forms.TabControlEventArgs e )
        {
          DisableAllButtons();
        }

        private void licenseInformationToolStripMenuItem_Click( object sender, EventArgs e )
        {
          using ( LicenseForm dial = new LicenseForm( CAS.OPC.UA.Viewer.Sample.Properties.Resources.Przegl_48, "Freeware", Assembly.GetEntryAssembly() ) )
          {
            Licences cLicDial = new Licences();
            dial.SetAdditionalControl = cLicDial;
            dial.LicenceRequestMessageProvider = new LicenseForm.LicenceRequestMessageProviderDelegate( delegate()
            {
              return cLicDial.GetLicenseMessageRequest();
            } );
            dial.ShowDialog();
          }
        }

        private void openLogsContainingFolderToolStripMenuItem_Click( object sender, EventArgs e )
        {
          FileInfo fi = new FileInfo( InstallContextNames.ApplicationDataPath );
          string path = Path.Combine( fi.Directory.Parent.FullName, "Logs");
          try
          {
            using ( Process process = Process.Start( @path ) ) { }
          }
          catch ( Win32Exception _Win32Exception)
          {
            MessageBox.Show( 
              $"An error {_Win32Exception} during opening a log folder occurred; no Log folder exists under this link: { path } You can create this folder yourself.", 
              "No Log folder !", 
              MessageBoxButtons.OK, 
              MessageBoxIcon.Error );
            return;
          }
          catch ( Exception exception)
          {
            MessageBox.Show( $"An error {exception} during opening a log folder occurred and the log folder cannot be open", "Problem with log folder !", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return;
          }
        }

        private void unlockSoftwareToolStripMenuItem_Click( object sender, EventArgs e )
        {
          using ( UlockKeyDialog dialog = new UlockKeyDialog() )
          {
            dialog.ShowDialog();
          }
        }

        private ResourceManager Getter()
        {
          return Resources.ResourceManager;
        }

    }
}
