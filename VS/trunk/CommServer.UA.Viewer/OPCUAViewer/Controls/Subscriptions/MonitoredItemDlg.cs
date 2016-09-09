//<summary>
//  Title   : Monitored item dialog
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
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class MonitoredItemDlg : Form
    {
        #region Constructors
        public MonitoredItemDlg()
        {
            InitializeComponent();

            m_SubscriptionStateChanged = new SubscriptionStateChangedEventHandler(Subscription_StateChanged);
            m_MonitoredItemNotification = new MonitoredItemNotificationEventHandler(MonitoredItem_Notification);
            m_PublishStatusChanged = new EventHandler(Subscription_PublishStatusChanged);
        }
        #endregion

        #region Private Fields
        private Subscription m_subscription;
        private MonitoredItem m_monitoredItem;
        private SubscriptionStateChangedEventHandler m_SubscriptionStateChanged;
        private MonitoredItemNotificationEventHandler m_MonitoredItemNotification;
        private EventHandler m_PublishStatusChanged;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public void Show(MonitoredItem monitoredItem)
        {
            if (monitoredItem == null) throw new ArgumentNullException("monitoredItem");
            
            Show();
            BringToFront();

            // remove previous subscription.
            if (m_monitoredItem != null)
            {
                monitoredItem.Subscription.StateChanged -= m_SubscriptionStateChanged;
                monitoredItem.Subscription.PublishStatusChanged -= m_PublishStatusChanged;
                monitoredItem.Notification -= m_MonitoredItemNotification;
            }
            
            // start receiving notifications from the new subscription.
            m_monitoredItem = monitoredItem;
            m_subscription  = null;
  
            if (m_monitoredItem != null)
            {
                m_subscription = monitoredItem.Subscription;
                m_monitoredItem.Subscription.StateChanged += m_SubscriptionStateChanged;
                m_monitoredItem.Subscription.PublishStatusChanged += m_PublishStatusChanged;
                m_monitoredItem.Notification += m_MonitoredItemNotification;
            }

            WindowMI_Click(WindowStatusMI, null);
            WindowMI_Click(WindowLatestValueMI, null);

            MonitoredItemsCTRL.Initialize(m_monitoredItem);
            EventsCTRL.Initialize(m_subscription, m_monitoredItem);
            DataChangesCTRL.Initialize(m_subscription, m_monitoredItem);
            LatestValueCTRL.ShowValue(m_monitoredItem, false);
        }
        #endregion
        
        #region Private Methods
        /// <summary>
        /// Updates the controls displaying the status of the subscription.
        /// </summary>
        private void UpdateStatus()
        {
            NotificationMessage lastMessage = null;

            if (m_monitoredItem != null)
            {
                lastMessage = m_monitoredItem.LastMessage;
            }

            MonitoringModeTB.Text = String.Empty;
            MonitoringModeTB.ForeColor = Color.Empty;
            MonitoringModeTB.Font = new Font(MonitoringModeTB.Font, FontStyle.Regular);

            if (m_monitoredItem != null)
            {
                MonitoringModeTB.Text = String.Format("{0}", m_monitoredItem.Status.MonitoringMode);
            }

            if (m_subscription != null && m_subscription.PublishingStopped)
            {
                MonitoringModeTB.Text = String.Format("BadNoCommunication");
                MonitoringModeTB.ForeColor = Color.Red;
                MonitoringModeTB.Font = new Font(MonitoringModeTB.Font, FontStyle.Bold);
            }
            
            LastUpdateTimeTB.Text = String.Empty;
            LastMessageIdTB.Text  = String.Empty;

            if (lastMessage != null)
            {
                LastUpdateTimeTB.Text = String.Format("{0:HH:mm:ss}", lastMessage.PublishTime.ToLocalTime());
                LastMessageIdTB.Text  = String.Format("{0}", lastMessage.SequenceNumber);
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Processes a Publish repsonse from the server.
        /// </summary>
        void MonitoredItem_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(m_MonitoredItemNotification, monitoredItem, e);
                return;
            }
            else if (!IsHandleCreated)
            {
                return;
            }

            try
            {
                // ignore notifications for other monitored items.
                if (!Object.ReferenceEquals(m_monitoredItem, monitoredItem))
                {
                    return;
                }
                                
                // notify controls of the change.
                EventsCTRL.NotificationReceived(e);
                DataChangesCTRL.NotificationReceived(e);
                LatestValueCTRL.ShowValue(monitoredItem, true);
           
                // update item status.
                UpdateStatus();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Handles a change to the state of the subscription.
        /// </summary>
        void Subscription_StateChanged(Subscription subscription, SubscriptionStateChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(m_SubscriptionStateChanged, subscription, e);
                return;
            }
            else if (!IsHandleCreated)
            {
                return;
            }

            try
            {
                // ignore notifications for other subscriptions.
                if (m_monitoredItem == null || !Object.ReferenceEquals(m_monitoredItem.Subscription, subscription))
                {
                    return;
                }

                // notify controls of the change.
                EventsCTRL.SubscriptionChanged(e);
                DataChangesCTRL.SubscriptionChanged(e);
                MonitoredItemsCTRL.SubscriptionChanged(e);

                // update subscription status.
                UpdateStatus();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Handles a change to the publish status for the subscription.
        /// </summary>
        void Subscription_PublishStatusChanged(object subscription, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(m_PublishStatusChanged, subscription, e);
                return;
            }
            else if (!IsHandleCreated)
            {
                return;
            }

            try
            {
                // ignore notifications for other subscriptions.
                if (!Object.ReferenceEquals(m_subscription,  subscription))
                {
                    return;
                }

                // update item status.
                UpdateStatus();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void WindowMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == WindowStatusMI)
                {
                    WindowStatusMI.Checked      = !WindowStatusMI.Checked;
                    WindowLatestValueMI.Checked = false;
                    MonitoredItemsCTRL.Visible  = true; 
                    SplitterPN.Panel1Collapsed  = !WindowStatusMI.Checked;
                }

                else if (sender == WindowHistoryMI)
                {
                    WindowHistoryMI.Checked        = true;
                    WindowLatestValueMI.Checked    = false;
                    MonitoredItemsCTRL.Visible     = true;
                    EventsCTRL.Visible             = m_monitoredItem.NodeClass != NodeClass.Variable;
                    DataChangesCTRL.Visible        = !EventsCTRL.Visible;
                    LatestValueCTRL.Visible        = false;

                    Text = String.Format("{0} - {1} - {2}", m_subscription.DisplayName, m_monitoredItem.DisplayName, "Recent Values");
                }
                
                else if (sender == WindowLatestValueMI)
                {
                    WindowHistoryMI.Checked        = false;
                    WindowLatestValueMI.Checked    = true;
                    MonitoredItemsCTRL.Visible     = true;
                    EventsCTRL.Visible             = false;
                    DataChangesCTRL.Visible        = false; 
                    LatestValueCTRL.Visible        = true;

                    Text = String.Format("{0} - {1} - {2}", m_subscription.DisplayName, m_monitoredItem.DisplayName, "Latest Value");
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void MonitoringModeMI_Click(object sender, EventArgs e)
        {
            try
            {
                MonitoringMode monitoringMode = m_monitoredItem.MonitoringMode;

                if (sender == MonitoringModeReportingMI)
                {
                    monitoringMode = MonitoringMode.Reporting;
                }
                
                else if (sender == MonitoringModeSamplingMI)
                {
                    monitoringMode = MonitoringMode.Sampling;
                }

                else if (sender == MonitoringModeDisabledMI)
                {
                    monitoringMode = MonitoringMode.Disabled;
                }
                
                m_monitoredItem.Subscription.SetMonitoringMode(monitoringMode, new MonitoredItem[] { m_monitoredItem });
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void MonitoringModeMI_DropDownOpening(object sender, EventArgs e)
        {            
            try
            {
                MonitoringModeReportingMI.Checked = false;
                MonitoringModeSamplingMI.Checked  = false;
                MonitoringModeDisabledMI.Checked  = false;

                switch (m_monitoredItem.MonitoringMode)
                {
                    case MonitoringMode.Reporting: { MonitoringModeReportingMI.Checked = true; break; }
                    case MonitoringMode.Sampling:  { MonitoringModeSamplingMI.Checked  = true; break; }
                    case MonitoringMode.Disabled:  { MonitoringModeDisabledMI.Checked  = true; break; }
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
