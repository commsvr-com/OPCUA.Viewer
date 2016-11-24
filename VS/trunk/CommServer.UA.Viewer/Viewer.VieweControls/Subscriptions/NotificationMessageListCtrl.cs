//<summary>
//  Title   : Notificatin message list
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
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class NotificationMessageListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public NotificationMessageListCtrl()
        {
            MaxMessageCount = 100;

            InitializeComponent();                        
			SetColumns(m_ColumnNames);

            ItemsLV.Sorting = SortOrder.Descending;
            m_SessionNotification = new NotificationEventHandler(Session_Notification);
        }
		#endregion

        #region Private Fields
        private Session m_session;
        private Subscription m_subscription;
        private NotificationEventHandler m_SessionNotification;
        private int m_maxMessageCount;
        
        /// <summary>
		/// The columns to display in the control.
		/// </summary>
		private readonly object[][] m_ColumnNames = new object[][]
		{
			new object[] { "Subscription",  HorizontalAlignment.Left,   null   },
			new object[] { "Message ID",    HorizontalAlignment.Center, null   },
			new object[] { "Publish Time",  HorizontalAlignment.Center, null   },
			new object[] { "Notifications", HorizontalAlignment.Center, null   },
			new object[] { "Data Changes",  HorizontalAlignment.Center, null   },
			new object[] { "EventTypes",    HorizontalAlignment.Center, null   }
		};
		#endregion

        #region Public Interface
        /// <summary>
        /// The maximum number of messages displayed in the control.
        /// </summary>
        public int MaxMessageCount
        {
            get { return m_maxMessageCount;  }
            set { m_maxMessageCount = value; }
        }

        /// <summary>
        /// Clears the contents of the control,
        /// </summary>
        public void Clear()
        {
            ItemsLV.Items.Clear();
            AdjustColumns();
        }

        /// <summary>
        /// Initializes the control with the session/subscription indicated.
        /// </summary>
        public void Initialize(Session session, Subscription subscription)
        {
            // do nothing if nothing has changed.
            if (Object.ReferenceEquals(session, m_session) && Object.ReferenceEquals(subscription, m_subscription))
            {
                return;
            }

            // subscription to event notifications.
            if (!Object.ReferenceEquals(session, m_session))
            {
                if (m_session != null)
                {
                    m_session.Notification -= m_SessionNotification;
                }

                if (session != null)
                {
                    session.Notification += m_SessionNotification;
                }
            }

            Clear();

            m_session = session;
            m_subscription = subscription;

            // nothing to do if no session provided.
            if (m_session == null)
            {
                return;
            }                     
                        
            List<ItemData> tags = new List<ItemData>();

            // display only items for current subscription.
            if (subscription != null)
            {
                foreach (NotificationMessage item in subscription.Notifications)
                {
                    tags.Insert(0, new ItemData(subscription, item));
                }
            }

            // display all notifications for all subscriptions.
            else
            {
                foreach (Subscription item1 in m_session.Subscriptions)
                {
                    foreach (NotificationMessage item2 in item1.Notifications)
                    {
                        tags.Insert(0, new ItemData(item1, item2));
                    }
                }
            }
            
            // update control.
            Update(tags);
        }
        #endregion
        
        #region ItemData Class
        /// <summary>
        /// Stores the data associated with a list view item.
        /// </summary>
        private class ItemData
        {
            public Subscription        Subscription;
            public NotificationMessage NotificationMessage;

            public ItemData(
                Subscription        subscription,
                NotificationMessage notificationMessage)
            {
                Subscription        = subscription;
                NotificationMessage = notificationMessage;
            }
        }
        #endregion

        #region Overridden Methods
        /// <see cref="BaseListCtrl.EnableMenuItems" />
		protected override void EnableMenuItems(ListViewItem clickedItem)
		{
            if (m_session != null)
            {
                ClearMI.Enabled     = true;
                RepublishMI.Enabled = m_subscription != null;

                if (clickedItem != null)
                {
                    ItemData itemData = clickedItem.Tag as ItemData;

                    if (itemData != null)
                    {
                        DeleteMI.Enabled = true;
                    }
                }
            }
		}

        /// <see cref="BaseListCtrl.UpdateItem" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
            ItemData itemData = item as ItemData;

			if (itemData == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}

			listItem.SubItems[0].Text  = String.Format("{0}", itemData.Subscription.DisplayName);
			listItem.SubItems[1].Text  = String.Format("{0}", itemData.NotificationMessage.SequenceNumber);
			listItem.SubItems[2].Text  = String.Format("{0:HH:mm:ss.fff}", itemData.NotificationMessage.PublishTime.ToLocalTime());
			
            int events = 0;
            int datachanges = 0;
            int notifications = 0;

            foreach (ExtensionObject notification in itemData.NotificationMessage.NotificationData)
            {
                notifications++;

                if (ExtensionObject.IsNull(notification))
                {
                    continue;
                }

                DataChangeNotification datachangeNotification = notification.Body as DataChangeNotification;

                if (datachangeNotification != null)
                {
                    datachanges += datachangeNotification.MonitoredItems.Count;
                }

                EventNotificationList EventNotification = notification.Body as EventNotificationList;

                if (EventNotification != null)
                {
                    events += EventNotification.Events.Count;
                }
            }

            listItem.SubItems[3].Text  = String.Format("{0}", notifications);
            listItem.SubItems[4].Text  = String.Format("{0}", datachanges);
            listItem.SubItems[5].Text  = String.Format("{0}", events);

			listItem.Tag = item;
        }
		#endregion

        private void Update(List<ItemData> tags)
        {
            if (tags.Count > MaxMessageCount)
            {
                tags.RemoveRange(MaxMessageCount, tags.Count-MaxMessageCount);
            }
                            
            BeginUpdate();
            
            foreach (ItemData tag in tags)
            {
                AddItem(tag);
            }

            EndUpdate();
        }

        private void Session_Notification(Session sender, NotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(m_SessionNotification, sender, e);
                return;
            }
            else if (!IsHandleCreated)
            {
                return;
            }
            
            try
            {
                if (m_subscription != null)
                {
                    if (!Object.ReferenceEquals(m_subscription, e.Subscription))
                    {
                        return;
                    }
                }

                // get the current control contents.
                List<ItemData> tags = new List<ItemData>();

                foreach (ListViewItem item in ItemsLV.Items)
                {
                    ItemData tag = item.Tag as ItemData;

                    if (tag != null)
                    {
                        tags.Add(tag);
                    }
                }

                tags.Insert(0, new ItemData(e.Subscription, e.NotificationMessage));

                // update control.
                Update(tags);
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
                for (int ii = 0; ii < ItemsLV.SelectedItems.Count;)
                {
                    ItemsLV.SelectedItems[ii].Remove();
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ClearMI_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void RepublishMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_subscription == null)
                {
                    return;
                }

                NotificationMessage message = new RepublishNotificationMessageDlg().ShowDialog(m_subscription);

                if (message != null)
                {
                    ListViewItem listItem = AddItem(new ItemData(m_subscription, message));
                    listItem.ForeColor = Color.Red;
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
