//<summary>
//  Title   : Read value list
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
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class ReadValueListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        public ReadValueListCtrl()
        {
            InitializeComponent();                        
			SetColumns(m_ColumnNames);
        }

        #region Private Fields
        private Session m_session;

        /// <summary>
		/// The columns to display in the control.
		/// </summary>
		private readonly object[][] m_ColumnNames = new object[][]
		{
			new object[] { "Name",        HorizontalAlignment.Left, null },  
			new object[] { "NodeId",      HorizontalAlignment.Left, null }, 
			new object[] { "Attribute",   HorizontalAlignment.Left, "Value" }, 
			new object[] { "IndexRange",  HorizontalAlignment.Left, "" }, 
			new object[] { "Encoding",    HorizontalAlignment.Left, "" }
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
        /// Sets the nodes in the control.
        /// </summary>
        public void Initialize(Session session, ReadValueIdCollection valueIds)
        {
            if (session == null)  throw new ArgumentNullException("session");
            
            Clear();
            
            m_session = session;

            foreach (ReadValueId valueId in valueIds)
            {
                AddItem(valueId);
            }

            AdjustColumns();
        }

        /// <summary>
        /// Adds a value to the control.
        /// </summary>
        public void AddValueId(ReferenceDescription reference)
        {
            Node node = m_session.NodeCache.Find(reference.NodeId) as Node;

            if (node == null)
            {
                return;
            }

            ReadValueId valueId = new ReadValueId();

            valueId.NodeId       = node.NodeId;
            valueId.AttributeId  = Attributes.Value;
            valueId.IndexRange   = null;
            valueId.DataEncoding = null;

            // read the display name for non-variables.
            if ((node.NodeClass & (NodeClass.Variable | NodeClass.VariableType)) == 0)
            {
                valueId.AttributeId  = Attributes.DisplayName;
            }

            AddItem(valueId);
            AdjustColumns();
        }

        /// <summary>
        /// Returns the items in the control.
        /// </summary>
        public ReadValueIdCollection GetValueIds()
        {
            ReadValueIdCollection valueIds = new ReadValueIdCollection();

            foreach (ListViewItem item in ItemsLV.Items)
            {
                ReadValueId valueId = item.Tag as ReadValueId;

                if (valueId != null)
                {
                    valueIds.Add(valueId);
                }
            }

            return valueIds;
        }
		#endregion
                
        #region Overridden Methods
        /// <see cref="BaseListCtrl.PickItems" />
        protected override void PickItems()
        {
            base.PickItems();
            EditMI_Click(this, null);
        }

        /// <see cref="BaseListCtrl.EnableMenuItems" />
		protected override void EnableMenuItems(ListViewItem clickedItem)
		{
            NewMI.Enabled          = true;
            EditMI.Enabled         = ItemsLV.SelectedItems.Count == 1;
            DeleteMI.Enabled       = ItemsLV.SelectedItems.Count > 0;
            SetAttributeMI.Enabled = ItemsLV.SelectedItems.Count > 0;
            SetEncodingMI.Enabled  = ItemsLV.SelectedItems.Count == 1;
		}
        
        /// <see cref="BaseListCtrl.UpdateItem" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
			ReadValueId valueId = item as ReadValueId;

			if (valueId == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}

            INode node = m_session.NodeCache.Find(valueId.NodeId);

            if (node != null)
            {
                listItem.SubItems[0].Text = String.Format("{0}", node);
            }
            else
            {
                listItem.SubItems[0].Text = String.Format("{0}", valueId.NodeId);
            }
            
            listItem.SubItems[1].Text = String.Format("{0}", valueId.NodeId);
            listItem.SubItems[2].Text = String.Format("{0}", Attributes.GetBrowseName(valueId.AttributeId));
            listItem.SubItems[3].Text = String.Format("{0}", valueId.IndexRange);
            listItem.SubItems[4].Text = String.Format("{0}", valueId.DataEncoding);

			listItem.Tag = item;
            listItem.ImageKey = "Method";
        }

        /// <summary>
        /// Handles a drop event.
        /// </summary>
        protected override void ItemsLV_DragDrop(object sender, DragEventArgs e)
        {            
            try
            {
                ReferenceDescription reference = e.Data.GetData(typeof(ReferenceDescription)) as ReferenceDescription;

                if (reference == null)
                {
                    return;
                }
                    
                AddValueId(reference);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
        
        #region Event Handlers
        private void NewMI_Click(object sender, EventArgs e)
        {
            try
            {
                ReadValueId valueId = new ReadValueId();

                if (new ReadValueEditDlg().ShowDialog(m_session, valueId))
                {
                    AddItem(valueId);
                }

                AdjustColumns();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void EditMI_Click(object sender, EventArgs e)
        {
            try
            {
                ReadValueId valueId = SelectedTag as ReadValueId;

                if (valueId == null)
                {
                    return;
                }

                if (new ReadValueEditDlg().ShowDialog(m_session, valueId))
                {
                    UpdateItem(ItemsLV.SelectedItems[0], valueId);
                }
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
                DeleteSelection();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
