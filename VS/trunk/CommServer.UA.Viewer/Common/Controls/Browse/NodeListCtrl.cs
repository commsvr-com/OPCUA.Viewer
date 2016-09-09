//<summary>
//  Title   : Node list
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
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// Displays a list of nodes.
    /// </summary>
    public partial class NodeListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeListCtrl"/> class.
        /// </summary>
        public NodeListCtrl()
        {
            InitializeComponent();
			SetColumns(m_ColumnNames);
        }

        #region Private Fields
        private Session m_session;
        private BrowseListCtrl m_referencesCTRL;
        private AttributeListCtrl m_attributesCTRL;
       
		// The columns to display in the control.		
		private readonly object[][] m_ColumnNames = new object[][]
		{
			new object[] { "Name",  HorizontalAlignment.Left, null },  
			new object[] { "ID",    HorizontalAlignment.Left,   null }
		};
		#endregion

        /// <summary>
        /// The control that displays the non-hierarchial references for the selected node.
        /// </summary>
        public BrowseListCtrl ReferencesCTRL
        {
            get { return m_referencesCTRL;  }
            set { m_referencesCTRL = value; }
        }

        /// <summary>
        /// The control that displays the attributes/properties for the selected node.
        /// </summary>
        public AttributeListCtrl AttributesCTRL
        {
            get { return m_attributesCTRL;  }
            set { m_attributesCTRL = value; }
        }
            
        /// <summary>
        /// Initializes the control with a set of items.
        /// </summary>
        public void Initialize(Session session, IList<NodeId> nodeIds)
        {
            ItemsLV.Items.Clear();
            m_session = session;

            if (m_session == null || nodeIds == null || nodeIds.Count == 0)
            {
                AdjustColumns();
                return;
            }

            for (int ii = 0; ii < nodeIds.Count; ii++)
            {
                ILocalNode node = m_session.NodeCache.Find(nodeIds[ii]) as ILocalNode;

                if (node == null)
                {
                    continue;
                }

                AddItem(node);
            }

            AdjustColumns();
        }
        
        /// <summary>
        /// Adds a node to the control.
        /// </summary>
        public void Add(NodeId nodeId)
        {
            ILocalNode node = m_session.NodeCache.Find(nodeId) as ILocalNode;

            if (node != null)
            {
                AddItem(node);
                AdjustColumns();
            }
        }

        /// <summary>
        /// Returns the list of nodes in the control.
        /// </summary>
        public IList<ILocalNode> GetNodeList()
        {
            List<ILocalNode> items = new List<ILocalNode>(ItemsLV.Items.Count);
            
            for (int ii  = 0; ii < ItemsLV.Items.Count; ii++)
            {
                items.Add(ItemsLV.Items[ii].Tag as ILocalNode);
            }

            return items;
        }

        #region Overridden Methods
        /// <see cref="BaseListCtrl.SelectItems" />
        protected override void SelectItems()
        {
            base.SelectItems();

            ILocalNode node = GetSelectedTag(0) as ILocalNode;

            if (node == null)
            {
                return;
            }

            // update attributes control.
            if (AttributesCTRL != null)
            {
                AttributesCTRL.Initialize(m_session, node.NodeId);
            }

            // update references control.
            if (ReferencesCTRL != null)
            {
                ReferencesCTRL.Initialize(m_session, node.NodeId);
            }
        }

        /// <see cref="CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl.EnableMenuItems" />
		protected override void EnableMenuItems(ListViewItem clickedItem)
		{
            DeleteMI.Enabled = ItemsLV.SelectedItems.Count > 0;
		}

        /// <see cref="CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl.UpdateItem(ListViewItem,object)" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
            ILocalNode node = item as ILocalNode;

			if (node == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}

			listItem.SubItems[0].Text = Utils.Format("{0}", node.DisplayName);
			listItem.SubItems[1].Text = Utils.Format("{0}", node.NodeId);
            
            listItem.ImageKey = GuiUtils.GetTargetIcon(m_session, node.NodeClass, node.TypeDefinitionId);
			listItem.Tag = item;
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

                ILocalNode node = m_session.NodeCache.Find(reference.NodeId) as ILocalNode;

                if (node == null)
                {
                    return;
                }

                AddItem(node);

                AdjustColumns();                    
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion

        private void DeleteMI_Click(object sender, EventArgs e)
        {
            try
            {
                List<ListViewItem> items = new List<ListViewItem>(ItemsLV.SelectedItems.Count);
                
                for (int ii  = 0; ii < ItemsLV.SelectedItems.Count; ii++)
                {
                    items.Add(ItemsLV.SelectedItems[ii]);
                }

                for (int ii  = 0; ii < items.Count; ii++)
                {
                    items[ii].Remove();
                }

                AdjustColumns();
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
