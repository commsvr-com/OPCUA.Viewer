//<summary>
//  Title   : Filter operand list
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
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class FilterOperandListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        public FilterOperandListCtrl()
        {
            InitializeComponent();                        
			SetColumns(m_ColumnNames);
        }

        #region Private Fields
        private Session m_session;
        private IList<ContentFilterElement> m_elements;
        private int m_index;

        /// <summary>
		/// The columns to display in the control.
		/// </summary>
		private readonly object[][] m_ColumnNames = new object[][]
		{
			new object[] { "Index",   HorizontalAlignment.Left, null },
			new object[] { "Operand", HorizontalAlignment.Left, null },
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
        public void Initialize(Session session, IList<ContentFilterElement> elements, int index)
        {
            if (session == null) throw new ArgumentNullException("session");
            
            Clear();
            
            m_session  = session;
            m_elements = elements;
            m_index    = index;

            if (elements == null || index < 0 || index >= elements.Count)
            {
                return;                
            }

            foreach (FilterOperand operand in elements[index].GetOperands())
            {
                AddItem(operand);
            }

            AdjustColumns();
        }

        /// <summary>
        /// Returns the list of operands in the control.
        /// </summary>
        public List<FilterOperand> GetOperands()
        {
            List<FilterOperand> operands = new List<FilterOperand>();
                    
            for (int ii = 0; ii < ItemsLV.Items.Count; ii++)
            {
                FilterOperand operand = ItemsLV.Items[ii].Tag as FilterOperand;

                if (operand != null)
                {
                    operands.Add(operand);
                }
            }

            return operands;
        }
        #endregion

        #region Overridden Methods
        /// <see cref="BaseListCtrl.EnableMenuItems" />
		protected override void EnableMenuItems(ListViewItem clickedItem)
		{
            NewMI.Enabled    = true;
            EditMI.Enabled   = ItemsLV.SelectedItems.Count == 1;
            DeleteMI.Enabled = ItemsLV.SelectedItems.Count > 0;
		}
        
        /// <see cref="BaseListCtrl.UpdateItem" />
        protected override void UpdateItem(ListViewItem listItem, object item, int index)
        {
			FilterOperand operand = item as FilterOperand;

			if (operand == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}
                      
            listItem.SubItems[0].Text = String.Format("[{0}]", index);
            listItem.SubItems[1].Text = operand.ToString(m_session.NodeCache);
                        
            listItem.Tag = operand;
        }
        #endregion
               
        #region Event Handlers
        private void NewMI_Click(object sender, EventArgs e)
        {
            try
            {
                FilterOperand operand = new FilterOperandEditDlg().ShowDialog(m_session, m_elements, m_index, null);

                if (operand == null)
                {
                    return;
                }              

                // insert after the current selection.
                int index = ItemsLV.SelectedIndices.Count;

                if (ItemsLV.SelectedIndices.Count > 0)
                {
                    index = ItemsLV.SelectedIndices[0]+1;
                }

                AddItem(operand, "SimpleItem", index);

                // must update index for all items.
                for (int ii = 0; ii < ItemsLV.Items.Count; ii++)
                {
                    UpdateItem(ItemsLV.Items[ii], ItemsLV.Items[ii].Tag, ii);
                }
                
                AdjustColumns();

                m_elements[m_index].FilterOperands.Clear();
                m_elements[m_index].SetOperands(GetOperands());
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
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
