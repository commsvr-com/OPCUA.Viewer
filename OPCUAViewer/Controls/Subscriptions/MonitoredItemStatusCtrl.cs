//<summary>
//  Title   : Monitored item status
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
using System.Windows.Forms;
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class MonitoredItemStatusCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public MonitoredItemStatusCtrl()
        {
            InitializeComponent();
            SetColumns(m_ColumnNames);
        }
		#endregion

        #region Private Fields
        private Subscription m_subscription;
        private MonitoredItem m_monitoredItem;
        
        /// <summary>
		/// The columns to display in the control.
		/// </summary>
		private readonly object[][] m_ColumnNames = new object[][]
		{
			new object[] { "ID",             HorizontalAlignment.Center, null       },
			new object[] { "Name",           HorizontalAlignment.Left,   null       },
			new object[] { "Class",          HorizontalAlignment.Left,   "Variable" },
			new object[] { "Sampling Rate",  HorizontalAlignment.Center, null       }, 
			new object[] { "Queue Size",     HorizontalAlignment.Center, "0"        }, 
			new object[] { "Value",          HorizontalAlignment.Left,   "",        200 }, 
			new object[] { "Status",         HorizontalAlignment.Left,   "",        }, 
			new object[] { "Timestamp",      HorizontalAlignment.Center, ""         },
		};
		#endregion

        #region Public Interface
        /// <summary>
        /// Clears the contents of the control,
        /// </summary>
        public void Clear()
        {
            ItemsLV.Items.Clear();
            AdjustColumns();
        }

        /// <summary>
        /// Displays the items for the specified subscription in the control.
        /// </summary>
        public void Initialize(MonitoredItem monitoredItem)
        {
            // do nothing if same subscription provided.
            if (Object.ReferenceEquals(m_monitoredItem, monitoredItem))
            {
                return;
            }

            m_monitoredItem = monitoredItem;
            m_subscription  = null;

            Clear();
            
            if (m_monitoredItem != null)
            {
                m_subscription  = monitoredItem.Subscription;
                UpdateItems();
            }
        }

        /// <summary>
        /// Displays the items for the specified subscription in the control.
        /// </summary>
        public void Initialize(Subscription subscription)
        {
            // do nothing if same subscription provided.
            if (Object.ReferenceEquals(m_subscription, subscription))
            {
                return;
            }

            m_monitoredItem = null;
            m_subscription  = subscription;

            Clear();
            
            if (m_subscription != null)
            {
                UpdateItems();
            }
        }
        
        /// <summary>
        /// Called when the subscription changes.
        /// </summary>
        public void SubscriptionChanged(SubscriptionStateChangedEventArgs e)
        {
            UpdateItems();
        }

        /// <summary>
        /// Refreshes the state of all items displayed in the control.
        /// </summary>
        public void UpdateItems()
        {
            if (m_subscription != null)
            {
                BeginUpdate();

                foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                {
                    if (m_monitoredItem == null || monitoredItem.ClientHandle == m_monitoredItem.ClientHandle)
                    {
                        AddItem(monitoredItem);
                    }
                }

                EndUpdate();

                AdjustColumns();
            }
        }
        
        /// <summary>
        /// Apply any changes to the set of items.
        /// </summary>
        public void ApplyChanges()
        {
            if (m_subscription != null)
            {
                m_subscription.ApplyChanges();

                foreach (ListViewItem listItem in ItemsLV.Items)
                {
                    UpdateItem(listItem, listItem.Tag);
                }

                AdjustColumns();
            }
        }
        #endregion
        
        #region Overridden Methods
        /// <see cref="BaseListCtrl.EnableMenuItems" />
		protected override void EnableMenuItems(ListViewItem clickedItem)
		{
            // no menu defined at this time.
		}
        
        /// <see cref="BaseListCtrl.UpdateItem" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
			MonitoredItem monitoredItem = item as MonitoredItem;

			if (monitoredItem == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}

		    listItem.SubItems[0].Text = String.Format("{0}", monitoredItem.Status.Id);
		    listItem.SubItems[1].Text = String.Format("{0}", monitoredItem.DisplayName);
		    listItem.SubItems[2].Text = String.Format("{0}", monitoredItem.NodeClass);
            listItem.SubItems[3].Text = String.Format("{0}", monitoredItem.Status.SamplingInterval);
		    listItem.SubItems[4].Text = String.Format("{0}", monitoredItem.Status.QueueSize);
            listItem.SubItems[5].Text = String.Empty;
            listItem.SubItems[6].Text = String.Format("{0}", monitoredItem.Status.Error);
            listItem.SubItems[7].Text = String.Empty;

            IEncodeable value = monitoredItem.LastValue;

            if (value != null)
            {
                MonitoredItemNotification datachange = value as MonitoredItemNotification;

                if (datachange != null)
                {
                    listItem.SubItems[5].Text = String.Format("{0}", datachange.Value);

                    if (datachange.Value.SourceTimestamp != DateTime.MinValue)
                    {
                        listItem.SubItems[7].Text = String.Format("{0:HH:mm:ss.fff}", datachange.Value.SourceTimestamp.ToLocalTime());
                    }
                }

                EventFieldList eventFields = value as EventFieldList;

                if (eventFields != null)
                {
                    listItem.SubItems[5].Text = String.Format("{0}", monitoredItem.GetEventType(eventFields));
                    listItem.SubItems[7].Text = String.Format("{0:HH:mm:ss.fff}", monitoredItem.GetEventTime(eventFields).ToLocalTime());                
                }
            }
 
			listItem.Tag = item;
        }
		#endregion
    }
}
