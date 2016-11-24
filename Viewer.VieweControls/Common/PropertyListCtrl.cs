//<summary>
//  Title   : Property list
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
    public partial class PropertyListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        public PropertyListCtrl()
        {
            InitializeComponent();                        
			SetColumns(m_ColumnNames);
        }

        #region Private Fields
        private Session m_session;
        private bool m_showValues;

        /// <summary>
		/// The columns to display in the control.
		/// </summary>
		private readonly object[][] m_ColumnNames = new object[][]
		{
			new object[] { "Property",    HorizontalAlignment.Left, null },  
			new object[] { "Value",       HorizontalAlignment.Left, ""   }, 
			new object[] { "DataType",    HorizontalAlignment.Left, null },
			new object[] { "Description", HorizontalAlignment.Left, null } 
		};
		#endregion

        #region Public Interface
        /// <summary>
        /// Whether the values should be displayed.
        /// </summary>
        public bool ShowValues
        {
            get { return m_showValues;  }
            set { m_showValues = value; }
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
        public void Update(Session session, ReferenceDescription reference)
        {
            if (session == null) throw new ArgumentNullException("session");
            
            Clear();

            if (reference == null)
            {
                return;                
            }
            
            m_session = session;

            AddProperties(reference.NodeId);

            AdjustColumns();
        }
		#endregion
        
        #region NodeField Class
        /// <summary>
        /// A field associated with a node.
        /// </summary>
        private class PropertyItem
        {            
            public ReferenceDescription Reference;
            public VariableNode         Property;
        }
		#endregion

        #region Private Methods
        /// <summary>
        /// Adds the properties to the control.
        /// </summary>
        private void AddProperties(ExpandedNodeId nodeId)
        {
            // get node.
            Node node = m_session.NodeCache.Find(nodeId) as Node;

            if (node == null)
            {
                return;
            }

            // get properties from supertype.
            ExpandedNodeId supertypeId = node.GetSuperType(m_session.TypeTree);

            if (supertypeId != null)
            {
                AddProperties(supertypeId);
            }

            // build list of properties to read.
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

            Browser browser = new Browser(m_session);
            
            browser.BrowseDirection   = BrowseDirection.Forward;
            browser.ReferenceTypeId   = ReferenceTypeIds.HasProperty;
            browser.IncludeSubtypes   = true;
            browser.NodeClassMask     = (int)NodeClass.Variable;
            browser.ContinueUntilDone = true;

            ReferenceDescriptionCollection references = browser.Browse(node.NodeId);

            // add propertoes to view.
            foreach (ReferenceDescription reference in references)
            {
                PropertyItem field = new PropertyItem();

                field.Reference = reference;
                field.Property  = m_session.NodeCache.Find(reference.NodeId) as VariableNode;

                AddItem(field, "Property", -1);
            }
        }
		#endregion
        
        #region Overridden Methods
        /// <see cref="BaseListCtrl.GetDataToDrag" />
        protected override object GetDataToDrag()
        {
            ReferenceDescriptionCollection references = new ReferenceDescriptionCollection();

            foreach (ListViewItem listItem in ItemsLV.SelectedItems)
            {
                PropertyItem property = listItem.Tag as PropertyItem;

                if (property != null)
                {
                    references.Add(property.Reference);
                }
            }

            return references;
        }

        /// <see cref="BaseListCtrl.EnableMenuItems" />
		protected override void EnableMenuItems(ListViewItem clickedItem)
		{                        
            PropertyItem[] items = GetSelectedItems(typeof(PropertyItem)) as PropertyItem[];

            if (items != null && items.Length > 0)
            {
                SelectMI.Enabled = true;
            }
		}
        
        /// <see cref="BaseListCtrl.UpdateItem" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
			PropertyItem property = item as PropertyItem;

			if (property == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}

            listItem.SubItems[0].Text = String.Format("{0}", property.Reference);
            listItem.SubItems[1].Text = "";

            if (m_showValues)
            {
                object value = property.Property.Value;
                Array array = value as Array;

                if (array == null)
                {
                    listItem.SubItems[1].Text = String.Format("{0}", value);
                }
                else
                {
                    listItem.SubItems[1].Text = String.Format("{0}[{1}]", value.GetType().GetElementType().Name, array.Length);
                }
            }

            INode node = m_session.NodeCache.Find(property.Property.DataType);

            if (node != null)
            {
                listItem.SubItems[2].Text = String.Format("{0}", node);
            }
            else
            {
                listItem.SubItems[2].Text = String.Format("{0}", property.Property.DataType);
            }

            if (property.Property.ValueRank >= 0)
            {
                listItem.SubItems[2].Text += "[]";
            }
                
            listItem.SubItems[3].Text = String.Format("{0}", property.Property.Description);

			listItem.Tag = item;
        }
        #endregion

        private void SelectMI_Click(object sender, EventArgs e)
        {
            try
            {
                PickItems();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
