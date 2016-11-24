//<summary>
//  Title   : Data value list
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
using System.Windows.Forms;
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class DataValueListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        #region Constructors
        public DataValueListCtrl()
        {
            InitializeComponent();                        
			SetColumns(m_ColumnNames);
        }
        #endregion

        #region Private Fields
        private Session m_session;
        private DataListCtrl m_DataListCtrl;

        /// <summary>
		/// The columns to display in the control.
		/// </summary>
		private readonly object[][] m_ColumnNames = new object[][]
		{
			new object[] { "Node",        HorizontalAlignment.Left, null     },  
			new object[] { "Attribute",   HorizontalAlignment.Left, "Value", }, 
			new object[] { "Value",       HorizontalAlignment.Left, "", 200  }, 
			new object[] { "Status",      HorizontalAlignment.Left, ""       }, 
			new object[] { "Source Time", HorizontalAlignment.Left, ""       },
			new object[] { "Server Time", HorizontalAlignment.Left, ""       },
		};
		#endregion

        #region Public Interface
        /// <summary>
        /// The control used to display the details of a value.
        /// </summary>
        public DataListCtrl DataListCtrl
        {
            get { return m_DataListCtrl;  }
            set { m_DataListCtrl = value; } 
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
        /// Sets the nodes in the control.
        /// </summary>
        public void Initialize(
            Session               session,
            ReadValueIdCollection valueIds, 
            DataValueCollection   values, 
            List<ServiceResult>   results)
        {
            if (session == null) throw new ArgumentNullException("session");
            
            Clear();
                        
            m_session  = session;

            if (valueIds != null)
            {
                for (int ii = 0; ii < valueIds.Count; ii++)
                {
                    ValueItem item = new ValueItem();

                    item.Node        = m_session.NodeCache.Find(valueIds[ii].NodeId) as Node;
                    item.AttributeId = valueIds[ii].AttributeId;

                    if (values != null && ii < values.Count)
                    {
                        item.Value = values[ii];
                    }

                    if (results != null && ii < results.Count)
                    {
                        item.Result = results[ii];
                    }

                    AddItem(item, "DataType", -1);
                }
            }

            AdjustColumns();
        }

        /// <summary>
        /// Sets the nodes in the control.
        /// </summary>
        public void Initialize(
            Session               session,
            WriteValueCollection  values,
            List<ServiceResult>   results)
        {
            if (session == null) throw new ArgumentNullException("session");
            
            Clear();
                        
            m_session = session;
            
            if (values != null)
            {
                for (int ii = 0; ii < values.Count; ii++)
                {
                    ValueItem item = new ValueItem();

                    item.Node        = m_session.NodeCache.Find(values[ii].NodeId) as Node;
                    item.AttributeId = values[ii].AttributeId;
                    item.Value       = values[ii].Value;

                    if (results != null && ii < results.Count)
                    {
                        item.Result = results[ii];
                    }

                    AddItem(item, "DataType", -1);
                }
            }

            AdjustColumns();
        }
		#endregion
        
        #region NodeField Class
        /// <summary>
        /// A field associated with a node.
        /// </summary>
        private class ValueItem
        {            
            public Node Node;
            public uint AttributeId;
            public DataValue Value;
            public ServiceResult Result;
        }
		#endregion

        #region Private Methods
		#endregion
        
        #region Overridden Methods
        /// <see cref="BaseListCtrl.UpdateItem" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
			ValueItem dataValue = item as ValueItem;

			if (dataValue == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}

            listItem.SubItems[0].Text = String.Format("{0}", dataValue.Node);
            listItem.SubItems[1].Text = Attributes.GetBrowseName(dataValue.AttributeId);
            listItem.SubItems[2].Text = "";
            listItem.SubItems[3].Text = "";
            listItem.SubItems[4].Text = "";
            listItem.SubItems[5].Text = "";

            if (dataValue.Value != null)
            {
                listItem.SubItems[2].Text = String.Format("{0}", dataValue.Value.WrappedValue);

                if (dataValue.Value.SourceTimestamp != DateTime.MinValue)
                {
                    listItem.SubItems[4].Text = String.Format("{0:HH:mm:ss.fff}", dataValue.Value.SourceTimestamp.ToLocalTime());
                }

                if (dataValue.Value.ServerTimestamp != DateTime.MinValue)
                {
                    listItem.SubItems[5].Text = String.Format("{0:HH:mm:ss.fff}", dataValue.Value.ServerTimestamp.ToLocalTime());
                }
            }

            if (dataValue.Result != null)
            {
                listItem.SubItems[3].Text =String.Format("{0}", dataValue.Result);
            }

			listItem.Tag = item;
        }
        
        /// <see cref="BaseListCtrl.SelectItems" />
        protected override void SelectItems()
        {
            base.SelectItems();

            if (m_DataListCtrl != null)
            {
                ValueItem[] values = GetSelectedItems(typeof(ValueItem)) as ValueItem[];

                if (values != null && values.Length > 0)
                {
                    m_DataListCtrl.ShowValue(values[0].Value);
                }
                else
                {
                    m_DataListCtrl.ShowValue(null);
                }
            }
        }
        #endregion
    }
}
