//<summary>
//  Title   : Filter operand editor
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
using System.Text;
using System.Windows.Forms;
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class FilterOperandEditDlg : Form
    {
        #region Constructors
        public FilterOperandEditDlg()
        {
            InitializeComponent();

            OperandTypeCB.Items.Clear();
            OperandTypeCB.Items.Add(typeof(LiteralOperand).Name);
            OperandTypeCB.Items.Add(typeof(AttributeOperand).Name);
            OperandTypeCB.Items.Add(typeof(ElementOperand).Name);

            foreach (BuiltInType datatype in Enum.GetValues(typeof(BuiltInType)))
            {
                DataTypeCB.Items.Add(datatype);
            }

            AttributeIdCB.Items.AddRange(Attributes.GetBrowseNames());
        }
        #endregion

        #region Private Fields
        private Session m_session;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public FilterOperand ShowDialog(
            Session                     session, 
            IList<ContentFilterElement> elements, 
            int                         index, 
            FilterOperand               operand)
        {
            if (session == null)  throw new ArgumentNullException("session");
            if (elements == null) throw new ArgumentNullException("elements");

            m_session = session;
            
            TypeDefinitionIdCTRL.Browser = new Browser(session);
            TypeDefinitionIdCTRL.RootId  = ObjectTypes.BaseEventType;

            OperandTypeCB.SelectedItem = typeof(LiteralOperand).Name;

            if (operand != null)
            {
                OperandTypeCB.SelectedItem = operand.GetType().Name;
            }
            
            ElementsCB.Items.Clear();

            for (int ii = index+1; ii < elements.Count; ii++)
            {
                ElementsCB.Items.Add(elements[ii].ToString(m_session.NodeCache));
            }
                        
            ElementOperand elementOperand = operand as ElementOperand;

            if (elementOperand != null)
            {
                ElementsCB.SelectedIndex = (int)elementOperand.Index - index -1;
            }
            
            AttributeOperand attributeOperand = operand as AttributeOperand;

            if (attributeOperand != null)
            {
                TypeDefinitionIdCTRL.Identifier = attributeOperand.NodeId;
                BrowsePathTB.Text               = attributeOperand.BrowsePath.Format(session.NodeCache.TypeTree);
                AttributeIdCB.SelectedItem      = Attributes.GetBrowseName(attributeOperand.AttributeId);
                IndexRangeTB.Text               = attributeOperand.IndexRange;
                AliasTB.Text                    = attributeOperand.Alias;
            }
            
            LiteralOperand literalOperand = operand as LiteralOperand;

            if (literalOperand != null)
            {
                NodeId datatypeId = TypeInfo.GetDataTypeId(literalOperand.Value.Value);
                DataTypeCB.SelectedItem = TypeInfo.GetBuiltInType(datatypeId);

                StringBuilder buffer = new StringBuilder();

                Array array = literalOperand.Value.Value as Array;

                if (array != null)
                {
                    for (int ii = 0; ii < array.Length; ii++)
                    {
                        if (ii > 0)
                        {
                            buffer.Append("\r\n");
                        }

                        buffer.AppendFormat("{0}", new Variant(array.GetValue(ii)));
                    }
                }
                else
                {
                    buffer.AppendFormat("{0}", literalOperand.Value);
                }

                ValueTB.Text = buffer.ToString();
            }
                        
            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return operand;
        }
        #endregion
        
        #region Event Handlers
        private void OperandTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch ((string)OperandTypeCB.SelectedItem)
                {
                    case "LiteralOperand":
                    {
                        LiteralPN.Visible   = true;
                        AttributePN.Visible = false;
                        ElementPN.Visible   = false;
                        break;
                    }

                    case "AttributeOperand":
                    {
                        LiteralPN.Visible   = false;
                        AttributePN.Visible = true;
                        ElementPN.Visible   = false;
                        break;
                    }

                    case "ElementOperand":
                    {
                        LiteralPN.Visible   = false;
                        AttributePN.Visible = false;
                        ElementPN.Visible   = true;
                        break;
                    }
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
