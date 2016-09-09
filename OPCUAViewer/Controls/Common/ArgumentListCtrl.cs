//<summary>
//  Title   : Argument list
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
    public partial class ArgumentListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        public ArgumentListCtrl()
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
			new object[] { "DataType",    HorizontalAlignment.Left, null }, 
			new object[] { "Value",       HorizontalAlignment.Left, null }, 
			new object[] { "Description", HorizontalAlignment.Left, null }, 
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
        public bool Update(Session session, NodeId methodId, bool inputArgs)
        {
            if (session == null)  throw new ArgumentNullException("session");
            if (methodId == null) throw new ArgumentNullException("methodId");
            
            Clear();
            
            m_session = session;

            // find the method.
            MethodNode method = session.NodeCache.Find(methodId) as MethodNode;

            if (method == null)
            {
                return false;
            }

            // select the property to find.
            QualifiedName browseName = null;
                    
            if (inputArgs)
            {
                browseName = Opc.Ua.BrowseNames.InputArguments;
            }
            else
            {
                browseName = Opc.Ua.BrowseNames.OutputArguments;
            }

            // fetch the argument list.
            VariableNode argumentsNode = session.NodeCache.Find(methodId, ReferenceTypeIds.HasProperty, false, true, browseName) as VariableNode;

            if (argumentsNode == null)
            {
                return false;
            }

            // read the value from the server.
            DataValue value = m_session.ReadValue(argumentsNode.NodeId);

            ExtensionObject[] argumentsList = value.Value as ExtensionObject[];

            if (argumentsList != null)
            {
                for (int ii = 0; ii < argumentsList.Length; ii++)
                {
                    AddItem(argumentsList[ii].Body as Argument);
                }
            }

            AdjustColumns();

            return ItemsLV.Items.Count > 0;
        }        

        /// <summary>
        /// Returns the argument values
        /// </summary>
        public VariantCollection GetValues()
        {
            VariantCollection values = new VariantCollection();

            foreach (ListViewItem item in ItemsLV.Items)
            {
                Argument argument = item.Tag as Argument;

                if (argument != null)
                {
                    values.Add(new Variant(argument.Value));
                }
            }

            return values;
        }

        /// <summary>
        /// Updates the argument values.
        /// </summary>
        public void SetValues(VariantCollection values)
        {
            int ii = 0;

            foreach (ListViewItem item in ItemsLV.Items)
            {
                Argument argument = item.Tag as Argument;

                if (argument != null)
                {
                    argument.Value = values[ii++].Value;
                    UpdateItem(item, argument);
                }
            }

            AdjustColumns();
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
            EditMI.Enabled       = ItemsLV.SelectedItems.Count == 1;
            ClearValueMI.Enabled = EditMI.Enabled;
		}
        
        /// <see cref="BaseListCtrl.UpdateItem" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
			Argument argument = item as Argument;

			if (argument == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}

			listItem.SubItems[0].Text = String.Format("{0}", argument.Name);

            INode datatype = m_session.NodeCache.Find(argument.DataType);

            if (datatype != null)
            {
                listItem.SubItems[1].Text = String.Format("{0}", datatype);
            }
            else
            {
                listItem.SubItems[1].Text = String.Format("{0}", argument.DataType);
            }

            if (argument.ValueRank >= ValueRanks.OneOrMoreDimensions)
            {
                listItem.SubItems[1].Text += "[]";
            }

            if (argument.Value == null)
            {
                argument.Value = TypeInfo.GetDefaultValue(argument.DataType, argument.ValueRank, m_session.TypeTree);

                if (argument.Value == null)
                {
                    Type type = m_session.MessageContext.Factory.GetSystemType(argument.DataType);

                    if (type != null)
                    {
                        if (argument.ValueRank == ValueRanks.Scalar)
                        {
                            argument.Value = new ExtensionObject(Activator.CreateInstance(type));
                        }
                        else
                        {
                            argument.Value = new ExtensionObject[0];
                        }
                    }
                }
            }

			listItem.SubItems[2].Text = String.Format("{0}", argument.Value);
			listItem.SubItems[3].Text = String.Format("{0}", argument.Description.Text);

			listItem.Tag = item;
        }
        #endregion

        private void EditMI_Click(object sender, EventArgs e)
        {
            try
            {
                Argument[] arguments = GetSelectedItems(typeof(Argument)) as Argument[];

                if (arguments == null || arguments.Length != 1)
                {
                    return;
                }

                object value = GuiUtils2.EditValue(m_session, arguments[0].Value, arguments[0].DataType, arguments[0].ValueRank);

                if (value != null)
                {
                    arguments[0].Value = value;
                }

                UpdateItem(ItemsLV.SelectedItems[0], arguments[0]);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ClearValueMI_Click(object sender, EventArgs e)
        {
            try
            {
                Argument[] arguments = GetSelectedItems(typeof(Argument)) as Argument[];

                if (arguments == null || arguments.Length != 1)
                {
                    return;
                }

                arguments[0].Value = null;

                UpdateItem(ItemsLV.SelectedItems[0], arguments[0]);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
