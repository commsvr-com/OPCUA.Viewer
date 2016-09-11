//<summary>
//  Title   : Performanse result list
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

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class PerformanceResultsListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        public PerformanceResultsListCtrl()
        {
            InitializeComponent();                       
			SetColumns(m_ColumnNames);
        }

        #region Private Fields
        /// <summary>
		/// The columns to display in the control.
		/// </summary>
		private readonly object[][] m_ColumnNames = new object[][]
		{
			new object[] { "Server", HorizontalAlignment.Left, null }, 
			new object[] { "1",      HorizontalAlignment.Left, "-1" }, 
			new object[] { "10",     HorizontalAlignment.Left, "-1" }, 
			new object[] { "50",     HorizontalAlignment.Left, "-1" }, 
			new object[] { "100",    HorizontalAlignment.Left, "-1" }, 
			new object[] { "250",    HorizontalAlignment.Left, "-1" },
			new object[] { "500",    HorizontalAlignment.Left, "-1" }, 
			new object[] { "1000",   HorizontalAlignment.Left, "-1" }, 
			//new object[] { "2500",   HorizontalAlignment.Left, "-1" },
			//new object[] { "5000",   HorizontalAlignment.Left, "-1" }, 
		};
		#endregion

        #region Public Interface
        /// <summary>
        /// Adds a result to the control.
        /// </summary>
        public void Add(PerformanceTestResult result)
        {
            if (result == null) throw new ArgumentNullException("result");

            AddItem(result);
            AdjustColumns();
        }

        /// <summary>
        /// Clears all results in the control.
        /// </summary>
        public void Clear()
        {
            ItemsLV.Items.Clear();
            AdjustColumns();
        }

        /// <summary>
        /// Returns all results in the control.
        /// </summary>
        public PerformanceTestResult[] GetResults()
        {
            return (PerformanceTestResult[])GetItems(typeof(PerformanceTestResult));
        }
		#endregion
                
        #region Overridden Methods
        /// <see cref="BaseListCtrl.PickItems" />
        protected override void PickItems()
        {
            base.PickItems();
        }

        /// <see cref="BaseListCtrl.EnableMenuItems" />
		protected override void EnableMenuItems(ListViewItem clickedItem)
		{
            DeleteMI.Enabled   = ItemsLV.SelectedItems.Count > 0;
            ClearAllMI.Enabled = ItemsLV.Items.Count > 0;
		}
        
        /// <see cref="BaseListCtrl.UpdateItem" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
			PerformanceTestResult result = item as PerformanceTestResult;

			if (result == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}
                       
            listItem.SubItems[0].Text = String.Format("{0}", result.Endpoint);
            listItem.SubItems[1].Text = String.Format("{0:0.##}", result.Results[1]);
            listItem.SubItems[2].Text = String.Format("{0:0.##}", result.Results[10]);
            listItem.SubItems[3].Text = String.Format("{0:0.##}", result.Results[50]);
            listItem.SubItems[4].Text = String.Format("{0:0.##}", result.Results[100]);
            listItem.SubItems[5].Text = String.Format("{0:0.##}", result.Results[250]);
            listItem.SubItems[6].Text = String.Format("{0:0.##}", result.Results[500]);
            //listItem.SubItems[7].Text = String.Format("{0:0.##}", result.Results[1000]);
            //listItem.SubItems[7].Text = String.Format("{0:0.##}", result.Results[2500]);
            //listItem.SubItems[8].Text = String.Format("{0:0.##}", result.Results[5000]);
            
			listItem.Tag = item;
            listItem.ImageKey = "DataType";
        }
        #endregion

        private void DeleteMI_Click(object sender, EventArgs e)
        {
            try
            {
                List<ListViewItem> itemsToDelete = new List<ListViewItem>();

                foreach (ListViewItem item in ItemsLV.SelectedItems)
                {
                    itemsToDelete.Add(item);
                }

                foreach (ListViewItem item in itemsToDelete)
                {
                    item.Remove();
                }

                AdjustColumns();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ClearAllMI_Click(object sender, EventArgs e)
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
    }
}
