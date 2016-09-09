//<summary>
//  Title   : Session tree
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
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class SessionTreeCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseTreeCtrl
    {
        #region Contructors
        public SessionTreeCtrl()
        {
            InitializeComponent();

            m_eventRegistrations = new Dictionary<object,TreeNode>();
            m_endpointUrls = new StringCollection();
            m_dialogs = new Dictionary<Subscription,SubscriptionDlg>();

            m_SessionSubscriptionsChanged = new EventHandler(Session_SubscriptionsChanged);
            m_SubscriptionStateChanged = new SubscriptionStateChangedEventHandler(Subscription_StateChanged);
        }
        #endregion

        #region Private Fields
        private BrowseTreeCtrl m_AddressSpaceCtrl;
        private NotificationMessageListCtrl m_NotificationMessagesCtrl;
        private ToolStripStatusLabel m_ServerStatusCtrl;
        private EventHandler m_SessionSubscriptionsChanged;
        private SubscriptionStateChangedEventHandler m_SubscriptionStateChanged;
        private Dictionary<object,TreeNode> m_eventRegistrations;
        private StringCollection m_endpointUrls;
        private Dictionary<Subscription,SubscriptionDlg> m_dialogs;
        private ApplicationConfiguration m_configuration;
        private ServiceMessageContext m_messageContext;
        private ConfiguredEndpoint m_endpoint;
        private string m_filePath;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// The configuration to use when creating sessions.
        /// </summary>
        public ApplicationConfiguration Configuration
        {
            get { return m_configuration;  }
            set { m_configuration = value; }
        }

        /// <summary>
        /// The message context to use with the sessions.
        /// </summary>
        public ServiceMessageContext MessageContext
        {
            get { return m_messageContext;  }
            set { m_messageContext = value; }
        }

        /// <summary>
        /// Closes all open sessions within the control.
        /// </summary>
        public void Close()
        {
            // close all active sessions.
            foreach (TreeNode root in NodesTV.Nodes)
            {
                Session session  = root.Tag as Session;

                if (session != null)
                {
                    session.Close();
                }
            }

            Clear();
        }

        /// <summary>
        /// Clears the contents of the control,
        /// </summary>
        public void Clear()
        {
            // close all active sessions.
            foreach (TreeNode root in NodesTV.Nodes)
            {
                Session session  = root.Tag as Session;

                if (session != null)
                {
                    session.Close();
                }
            }
            
            Clear(NodesTV.Nodes);
        }
        
        /// <summary>
        /// The control used to display the address space for a session.
        /// </summary>
        public BrowseTreeCtrl AddressSpaceCtrl
        {
            get { return m_AddressSpaceCtrl;  }
            set { m_AddressSpaceCtrl = value; }
        }

        /// <summary>
        /// The control used to display the notification messages returned for a session..
        /// </summary>
        public NotificationMessageListCtrl NotificationMessagesCtrl
        {
            get { return m_NotificationMessagesCtrl;  }
            set { m_NotificationMessagesCtrl = value; }
        }

        /// <summary>
        /// The control use to display the selected server's status.
        /// </summary>
        public ToolStripStatusLabel ServerStatusCtrl
        {
            get { return m_ServerStatusCtrl;  }
            set { m_ServerStatusCtrl = value; }
        }

        /// <summary>
        /// Creates a session with the endpoint.
        /// </summary>
        public Session Connect(ConfiguredEndpoint endpoint)
        {
            if (endpoint == null) throw new ArgumentNullException("endpoint");

            // check if the endpoint needs to be updated.
            if (endpoint.UpdateBeforeConnect)
            {
                endpoint = new ConfiguredServerDlg().ShowDialog(endpoint, m_configuration);

                if (endpoint == null)
                {
                    return null;
                }
            }

            m_endpoint = endpoint;

            // copy the message context.
            m_messageContext = m_configuration.CreateMessageContext();

            // create the channel.
            ITransportChannel channel = SessionChannel.Create(
                m_configuration,
                endpoint.Description,
                endpoint.Configuration,
                m_configuration.SecurityConfiguration.ApplicationCertificate.Find(true),
                m_messageContext);

            // create the session.
            return Connect(endpoint, channel);
        }

        /// <summary>
        /// Opens a new session.
        /// </summary>
        public Session Connect(ConfiguredEndpoint endpoint, ITransportChannel channel)
        {
            if (channel == null) throw new ArgumentNullException("channel");

            try
            {
                // create the session.
                Session session = new Session(channel, m_configuration, endpoint, null);
                session.ReturnDiagnostics = DiagnosticsMasks.All;

                if (!new SessionOpenDlg().ShowDialog(session))
                {
                    return null;
                }
                
                // session now owns the channel.
                channel = null;

                // delete the existing session.
                Close();

                // add session to tree.
                AddNode(session);

                // return the new session.
                return session;
            }
            finally
            {
                // ensure the channel is closed on error.
                if (channel != null)
                {
                    channel.Close();
                }
            }
        }
                
        /// <summary>
        /// Deletes a session.
        /// </summary>
        public void Delete(Session session)
        {
            if (session == null) throw new ArgumentNullException("session");

            TreeNode node = FindNode(NodesTV.Nodes, session);

            if (node != null)
            {
                Clear(node.Nodes);
                node.Remove();
            }
            
            // close any dialogs.
            foreach (SubscriptionDlg dialog in new List<SubscriptionDlg>(m_dialogs.Values))
            {
                dialog.Close();
            }

            session.Close();
            NodesTV.SelectedNode = null;
            SelectNode();
        }
        
        /// <summary>
        /// Deletes a subscription.
        /// </summary>
        public void Delete(Subscription subscription)
        {
            if (subscription == null) throw new ArgumentNullException("subscription");

            TreeNode node = FindNode(NodesTV.Nodes, subscription);

            if (node != null)
            {
                Clear(node.Nodes);
                node.Remove();
            }
            
            // close any dialog.
            SubscriptionDlg dialog = null;

            if (m_dialogs.TryGetValue(subscription, out dialog))
            {
                dialog.Close();
            }

            Session session = subscription.Session;
            session.RemoveSubscription(subscription);
            NodesTV.SelectedNode = FindNode(NodesTV.Nodes, session);
        }
        
        /// <summary>
        /// Deletes a monitored item.
        /// </summary>
        public void Delete(MonitoredItem monitoredItem)
        {
            if (monitoredItem == null) throw new ArgumentNullException("monitoredItem");

            TreeNode node = FindNode(NodesTV.Nodes, monitoredItem);

            if (node != null)
            {
                Clear(node.Nodes);
                node.Remove();
            }

            Subscription subscription = monitoredItem.Subscription;
            subscription.RemoveItem(monitoredItem);
            subscription.ApplyChanges();;
            NodesTV.SelectedNode = FindNode(NodesTV.Nodes, subscription);
        }

        /// <summary>
        /// Creates a new subscription.
        /// </summary>
        public Subscription CreateSubscription(Session session)
        {                                        
            // create form.
            SubscriptionDlg dialog = new SubscriptionDlg();
            dialog.FormClosing += new FormClosingEventHandler(Subscription_FormClosing);
            
            // create subscription.
            Subscription subscription = dialog.New(session);

            if (subscription != null)
            {
                m_dialogs.Add(subscription, dialog);
                return subscription;
            }

            return null;
        }
        #endregion
        
        #region Overridden Members
        /// <see cref="BaseTreeCtrl.EnableMenuItems" />
        protected override void EnableMenuItems(TreeNode clickedNode)
        {
            NewSessionMI.Enabled = true;
            NewWindowMI.Visible = this.FindForm() is ClientForm;
            NewWindowMI.Enabled = true;

            Session session = clickedNode.Tag as Session;

            if (session != null)
            {
                SessionSaveMI.Enabled          = true;
                SessionLoadMI.Enabled          = true;
                DeleteMI.Enabled               = true;
                ReadMI.Enabled                 = true;
                WriteMI.Enabled                = true;
                BrowseMI.Enabled               = session.Connected;
                BrowseAllMI.Enabled            = BrowseMI.Enabled;
                BrowseObjectsMI.Enabled        = BrowseMI.Enabled;
                BrowseObjectTypesMI.Enabled    = BrowseMI.Enabled;
                BrowseEventTypesMI.Enabled     = BrowseMI.Enabled;
                BrowseServerViewsMI.Enabled    = BrowseMI.Enabled;
                BrowseVariableTypesMI.Enabled  = BrowseMI.Enabled;
                BrowseDataTypesMI.Enabled      = BrowseMI.Enabled;
                BrowseReferenceTypesMI.Enabled = BrowseMI.Enabled;
                SubscriptionMI.Enabled         = session.Connected;
                SubscriptionCreateMI.Enabled   = SubscriptionMI.Enabled;
            }

            Subscription subscription = clickedNode.Tag as Subscription;

            if (subscription != null)
            {
                DeleteMI.Enabled                        = true;
                ReadMI.Enabled                          = true;
                WriteMI.Enabled                         = true;
                SubscriptionMI.Enabled                  = subscription.Session.Connected;
                SubscriptionMonitorMI.Enabled           = SubscriptionMI.Enabled;
                SubscriptionEnabledPublishingMI.Enabled = SubscriptionMI.Enabled; 
                SubscriptionEnabledPublishingMI.Checked = subscription.CurrentPublishingEnabled;
            }

            MonitoredItem monitoredItem = clickedNode.Tag as MonitoredItem;

            if (monitoredItem != null)
            {
                DeleteMI.Enabled = true;
                ReadMI.Enabled   = true;
                WriteMI.Enabled  = true;
            }
        }

        /// <summary>
        /// Finds the first tag in the tree above the node that matches the type argument.
        /// </summary>
        private T Get<T>(TreeNode node)
        {
            if (node == null)
            {
                return default(T);
            }

            if (node.Tag is T)
            {
                return (T)node.Tag ;
            }

            return Get<T>(node.Parent);
        }

        /// <see cref="BaseTreeCtrl.SelectNode" />
        protected override void SelectNode()
        {
            base.SelectNode();

            TreeNode selectedNode = NodesTV.SelectedNode;
            
            Session session = Get<Session>(selectedNode);
            Subscription subscription = Get<Subscription>(selectedNode); 
                        
            // update address space control.
            if (m_AddressSpaceCtrl != null)
            {
                m_AddressSpaceCtrl.SetView(session, BrowseViewType.Objects, null);
            }

            // update notification messages control.
            if (m_NotificationMessagesCtrl != null)
            {
                m_NotificationMessagesCtrl.Initialize(session, subscription);
            }
        }
        #endregion

        /// <summary>
        /// Recursively clears a subtree.
        /// </summary>
        private void Clear(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (m_eventRegistrations.Remove(node.Tag))
                {
                    if (node.Tag is Session)
                    {
                        ((Session)node.Tag).SubscriptionsChanged -= m_SessionSubscriptionsChanged;
                    }

                    else if (node.Tag is Subscription)
                    {
                        ((Subscription)node.Tag).StateChanged -= m_SubscriptionStateChanged;
                    }                   
                }

                Clear(node.Nodes);
            }

            nodes.Clear();
        }

        #region Private Members
        /// <summary>
        /// Called when the set of items for a subscription changes.
        /// </summary>
        private void Subscription_StateChanged(object sender, EventArgs e)
        {
            TreeNode node = FindNode(NodesTV.Nodes, sender);

            if (node == null)
            {
                return;
            }
            
            UpdateNode(node, sender as Subscription);
        }

        /// <summary>
        /// Called when the set of subscriptions for a session changes.
        /// </summary>
        private void Session_SubscriptionsChanged(object sender, EventArgs e)
        {
            TreeNode node = FindNode(NodesTV.Nodes, sender);

            if (node == null)
            {
                return;
            }
            
            UpdateNode(node, sender as Session);
            node.EnsureVisible();
            node.Expand();
        }

        /// <summary>
        /// Recursively finds the node with the specified tag.
        /// </summary>
        private TreeNode FindNode(TreeNodeCollection collection, object tag)
        {
            foreach (TreeNode node in collection)
            {
                if (Object.ReferenceEquals(node.Tag, tag))
                {
                    return node;
                }

                TreeNode child = FindNode(node.Nodes, tag);

                if (child != null)
                {
                    return child;
                }
            }

            return null;
        }

        /// <summary>
        /// Recursively finds the node with the specified tag and returns the immediate child with the specified child tag.
        /// </summary>
        private TreeNode FindChild(TreeNodeCollection collection, object tag, object childTag)
        {
            TreeNode parent = FindNode(collection, tag);

            if (parent == null)
            {
                return null;
            }

            foreach (TreeNode child in parent.Nodes)
            {
                if (Object.ReferenceEquals(child.Tag, childTag))
                {
                    return child;
                }
            }

            return null;
        }

        /// <summary>
        /// Adds a session to the tree.
        /// </summary>
        private void AddNode(Session session)
        {
            if (session == null) throw new ArgumentNullException("session");

            TreeNode node = AddNode(null, session, session.SessionName, "Server");
            UpdateNode(node, session);
            
            if (!m_eventRegistrations.ContainsKey(session))
            {
                session.SubscriptionsChanged += m_SessionSubscriptionsChanged;
                m_eventRegistrations.Add(session, node);
            }
            
            NodesTV.SelectedNode = node;
        }

        /// <summary>
        /// Updates a session node in the tree.
        /// </summary>
        private void UpdateNode(TreeNode parent, Session session)
        {
            UpdateNode(parent, session, session.SessionName, (session.Connected)?"Server":"ServerStopped");
            Clear(parent.Nodes);

            if (Object.ReferenceEquals(parent.Tag, session))
            {
                foreach (Subscription subscription in session.Subscriptions)
                {
                    AddNode(parent, subscription);
                }
            }
        }

        /// <summary>
        /// Adds a subscription to the tree.
        /// </summary>
        private void AddNode(TreeNode parent, Subscription subscription)
        {
            TreeNode node = AddNode(parent, subscription, subscription.DisplayName, "Object");
            UpdateNode(node, subscription);

            if (!m_eventRegistrations.ContainsKey(subscription))
            {
                subscription.StateChanged += m_SubscriptionStateChanged;
                m_eventRegistrations.Add(subscription, node);
            }
        }
        
        /// <summary>
        /// Updates a subscription node in the tree.
        /// </summary>
        private void UpdateNode(TreeNode parent, Subscription subscription)
        {
            Clear(parent.Nodes);            
            parent.Text = subscription.DisplayName;

            foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
            {                
                AddNode(parent, monitoredItem, monitoredItem.DisplayName, "Property");
            }
        }
        #endregion       

        private void BrowseAllMI_Click(object sender, EventArgs e)
        {     
            try
            {
                TreeNode selectedNode = NodesTV.SelectedNode;

                // change nothing if nothing selected.
                if (selectedNode == null)
                {
                    return;
                }
                
                // get selected session.
                Session session = selectedNode.Tag as Session; 

                if (session != null)
                {
                    new AddressSpaceDlg().Show(session, BrowseViewType.All, null);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BrowseObjectsMI_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = NodesTV.SelectedNode;

                // change nothing if nothing selected.
                if (selectedNode == null)
                {
                    return;
                }
                
                // get selected session.
                Session session = selectedNode.Tag as Session; 

                if (session != null)
                {
                    new AddressSpaceDlg().Show(session, BrowseViewType.Objects, null);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BrowseObjectTypesMI_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = NodesTV.SelectedNode;

                // change nothing if nothing selected.
                if (selectedNode == null)
                {
                    return;
                }
                
                // get selected session.
                Session session = selectedNode.Tag as Session; 

                if (session != null)
                {
                    new BrowseTypesDlg().Show(session, ObjectTypeIds.BaseObjectType);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BrowseVariableTypesMI_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = NodesTV.SelectedNode;

                // change nothing if nothing selected.
                if (selectedNode == null)
                {
                    return;
                }
                
                // get selected session.
                Session session = selectedNode.Tag as Session; 

                if (session != null)
                {
                    new BrowseTypesDlg().Show(session, VariableTypeIds.BaseDataVariableType);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BrowseDataTypesMI_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = NodesTV.SelectedNode;

                // change nothing if nothing selected.
                if (selectedNode == null)
                {
                    return;
                }
                
                // get selected session.
                Session session = selectedNode.Tag as Session; 

                if (session != null)
                {
                    new AddressSpaceDlg().Show(session, BrowseViewType.DataTypes, null);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BrowseReferenceTypesMI_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = NodesTV.SelectedNode;

                // change nothing if nothing selected.
                if (selectedNode == null)
                {
                    return;
                }
                
                // get selected session.
                Session session = selectedNode.Tag as Session; 

                if (session != null)
                {
                    new AddressSpaceDlg().Show(session, BrowseViewType.ReferenceTypes, null);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BrowseEventTypesMI_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = NodesTV.SelectedNode;

                // change nothing if nothing selected.
                if (selectedNode == null)
                {
                    return;
                }
                
                // get selected session.
                Session session = selectedNode.Tag as Session; 

                if (session != null)
                {
                    new BrowseTypesDlg().Show(session, ObjectTypeIds.BaseEventType);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BrowseServerViewsMI_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = NodesTV.SelectedNode;

                // change nothing if nothing selected.
                if (selectedNode == null)
                {
                    return;
                }
                
                // get selected session.
                Session session = selectedNode.Tag as Session; 

                if (session != null)
                {
                    BrowseServerViewsMI.DropDown.Items.Clear();

                    Browser browser = new Browser(session);

                    browser.BrowseDirection   = BrowseDirection.Forward;
                    browser.IncludeSubtypes   = true;
                    browser.ReferenceTypeId   = null;
                    browser.NodeClassMask     = (int)NodeClass.View;
                    browser.ContinueUntilDone = true;

                    ReferenceDescriptionCollection references = browser.Browse(Objects.ViewsFolder);

                    foreach (ReferenceDescription reference in references)
                    {
                        ToolStripItem item = BrowseServerViewsMI.DropDown.Items.Add(reference.ToString());
                        item.Click += new EventHandler(BrowseServerViewsMI_Click);
                        item.Tag = reference;
                    }
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        void BrowseServerViewsMI_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = NodesTV.SelectedNode;

                // change nothing if nothing selected.
                if (selectedNode == null)
                {
                    return;
                }
                
                // get selected session.
                Session session = selectedNode.Tag as Session; 

                if (session != null)
                {
                    ToolStripMenuItem menuitem = sender as ToolStripMenuItem;

                    if (menuitem != null)
                    {
                        ReferenceDescription reference = menuitem.Tag as ReferenceDescription;
                        
                        new AddressSpaceDlg().Show(
                            session, 
                            BrowseViewType.ServerDefinedView, 
                            (NodeId)reference.NodeId);
                    }
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void SubscriptionCreateMI_Click(object sender, EventArgs e)
        {
            try
            {
                // get current selection.
                TreeNode selectedNode = NodesTV.SelectedNode;

                if (selectedNode == null)
                {
                    return;
                }

                // get selected session.
                Session session = selectedNode.Tag as Session;

                if (session == null)
                {
                    return;
                }

                // create the subscription.
                CreateSubscription(session);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        void Subscription_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (KeyValuePair<Subscription,SubscriptionDlg> current in m_dialogs)
            {
                if (current.Value == sender)
                {
                    m_dialogs.Remove(current.Key);
                    return;
                }
            }
        }

        internal void NewSessionMI_Click(object sender, EventArgs e)
        {
          if ( m_endpoint == null )
            return;
            try
            {
                Connect(m_endpoint);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        internal void DeleteMI_Click(object sender, EventArgs e)
        {            
            try
            {
                // get current selection.
                TreeNode selectedNode = NodesTV.SelectedNode;

                if (selectedNode == null)
                {
                    return;
                }

                // delete session.
                Session session = selectedNode.Tag as Session;

                if (session != null)
                {
                    Delete(session);
                }

                // delete subscription
                Subscription subscription = selectedNode.Tag as Subscription;

                if (subscription != null)
                {
                    Delete(subscription);
                }

                // delete monitored item
                MonitoredItem monitoredItem = selectedNode.Tag as MonitoredItem;

                if (monitoredItem != null)
                {
                    Delete(monitoredItem);
                }                
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        internal void ReadMI_Click(object sender, EventArgs e)
        {
            try
            {
                // get the current session.
                Session session = Get<Session>(NodesTV.SelectedNode);

                if (session == null || !session.Connected)
                {
                    return;
                }

                // build list of nodes to read.
                ReadValueIdCollection valueIds = new ReadValueIdCollection();

                MonitoredItem monitoredItem = Get<MonitoredItem>(NodesTV.SelectedNode);

                if (monitoredItem != null)
                {
                    ReadValueId valueId = new ReadValueId();

                    valueId.NodeId       = monitoredItem.ResolvedNodeId;
                    valueId.AttributeId  = monitoredItem.AttributeId;
                    valueId.IndexRange   = monitoredItem.IndexRange;
                    valueId.DataEncoding = monitoredItem.Encoding;

                    valueIds.Add(valueId);
                }
                else
                {
                    Subscription subscription = Get<Subscription>(NodesTV.SelectedNode);

                    if (subscription != null)
                    {
                        foreach (MonitoredItem item in subscription.MonitoredItems)
                        {
                            ReadValueId valueId = new ReadValueId();

                            valueId.NodeId       = item.ResolvedNodeId;
                            valueId.AttributeId  = item.AttributeId;
                            valueId.IndexRange   = item.IndexRange;
                            valueId.DataEncoding = item.Encoding;

                            valueIds.Add(valueId);
                        }
                    }
                }

                // show form.
                new ReadDlg().Show(session, valueIds);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        internal void WriteMI_Click(object sender, EventArgs e)
        {
            try
            {
                // get the current session.
                Session session = Get<Session>(NodesTV.SelectedNode);

                if (session == null || !session.Connected)
                {
                    return;
                }

                // build list of nodes to read.
                WriteValueCollection values = new WriteValueCollection();

                MonitoredItem monitoredItem = Get<MonitoredItem>(NodesTV.SelectedNode);

                if (monitoredItem != null)
                {
                    WriteValue value = new WriteValue();

                    value.NodeId      = monitoredItem.ResolvedNodeId;
                    value.AttributeId = monitoredItem.AttributeId; 
                    value.IndexRange  = monitoredItem.IndexRange;

                    MonitoredItemNotification datachange = monitoredItem.LastValue as MonitoredItemNotification;

                    if (datachange != null)
                    {
                        value.Value = (DataValue)Utils.Clone(datachange.Value);
                    }

                    values.Add(value);
                }
                else
                {
                    Subscription subscription = Get<Subscription>(NodesTV.SelectedNode);

                    if (subscription != null)
                    {
                        foreach (MonitoredItem item in subscription.MonitoredItems)
                        {
                            WriteValue value = new WriteValue();

                            value.NodeId      = item.ResolvedNodeId;
                            value.AttributeId = item.AttributeId;     
                            value.IndexRange  = item.IndexRange;                      

                            MonitoredItemNotification datachange = item.LastValue as MonitoredItemNotification;

                            if (datachange != null)
                            {
                                value.Value = (DataValue)Utils.Clone(datachange.Value);
                            }

                            values.Add(value);
                        }
                    }
                }

                // show form.
                new WriteDlg().Show(session, values);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void SubscriptionEnabledPublishingMI_Click(object sender, EventArgs e)
        {
            try
            {
                // get current selection.
                TreeNode selectedNode = NodesTV.SelectedNode;

                if (selectedNode == null)
                {
                    return;
                }

                // delete session.
                Subscription subscription = selectedNode.Tag as Subscription;

                if (subscription != null)
                {
                    subscription.SetPublishingMode(SubscriptionEnabledPublishingMI.Checked);
                }   
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void SubscriptionMonitorMI_Click(object sender, EventArgs e)
        {            
            try
            {
                // get selected session.
                Subscription subscription = SelectedTag as Subscription;

                if (subscription == null)
                {
                    return;
                }
                                        
                // show form
                SubscriptionDlg dialog = null;

                if (!m_dialogs.TryGetValue(subscription, out dialog))
                {
                    dialog = new SubscriptionDlg();
                    dialog.FormClosing += new FormClosingEventHandler(Subscription_FormClosing);
                    m_dialogs.Add(subscription, dialog);
                }
                
                dialog.Show(subscription);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        internal void SessionSaveMI_Click(object sender, EventArgs e)
        {
			try
			{
                // get selected session.
                Session session = SelectedTag as Session;

                if (session == null)
                {
                    return;
                }

                // create a default file.
                if (String.IsNullOrEmpty(m_filePath))
                {
                    FileInfo defaultInfo = new FileInfo(Application.ExecutablePath);

                    m_filePath = defaultInfo.DirectoryName;
                    m_filePath += "\\";
                    m_filePath += session.SessionName;                    
                    m_filePath += ".uases";
                }
                 
                // prompt user to select file.
                FileInfo fileInfo = new FileInfo(m_filePath);

				SaveFileDialog dialog = new SaveFileDialog();

				dialog.CheckFileExists  = false;
				dialog.CheckPathExists  = true;
        dialog.DefaultExt = ".uases";
        dialog.Filter = "Result Files (*.uases)|*.uases|All Files (*.*)|*.*";
				dialog.ValidateNames    = true;
				dialog.Title            = "Save Subscriptions";
				dialog.FileName         = m_filePath;
                dialog.InitialDirectory = fileInfo.DirectoryName;
                dialog.RestoreDirectory = true;

				if (dialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}

                // save file.
                session.Save(dialog.FileName);

                // remember file path.
                m_filePath = dialog.FileName;
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        internal void SessionLoadMI_Click(object sender, EventArgs e)
        {               
			try
			{
                // get selected session.
                Session session = SelectedTag as Session;

                if (session == null)
                {
                    return;
                }

                // create a default file.
                if (String.IsNullOrEmpty(m_filePath))
                {
                    FileInfo defaultInfo = new FileInfo(Application.ExecutablePath);

                    m_filePath = defaultInfo.DirectoryName;
                    m_filePath += "\\";
                    m_filePath += session.SessionName;
                    m_filePath += ".uases";
                }
                
                FileInfo fileInfo = new FileInfo(m_filePath);
                
				OpenFileDialog dialog = new OpenFileDialog();

				dialog.CheckFileExists  = true;
				dialog.CheckPathExists  = true;
        dialog.DefaultExt = ".uases";
        dialog.Filter = "Result Files (*.uases)|*.uases|All Files (*.*)|*.*";
				dialog.Multiselect      = false;
				dialog.ValidateNames    = true;
				dialog.Title            = "Load Subscriptions";
				dialog.FileName         = m_filePath;
                dialog.InitialDirectory = fileInfo.DirectoryName;
                dialog.RestoreDirectory = true;

				if (dialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
                
                // remember file path.
                m_filePath = dialog.FileName;

                // load file.
                IEnumerable<Subscription> subscriptions = session.Load(dialog.FileName);
                
                // create the subscriptions automatically if the session is connected.
                if (session.Connected)
                {
                    foreach (Subscription subscription in subscriptions)
                    {
                        subscription.Create();
                    }
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
                ClientForm form = this.FindForm() as ClientForm;

                if (form != null)
                {
                    form.OpenForm();
                }
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
