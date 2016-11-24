//<summary>
//  Title   : Read value
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
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class ReadValueEditDlg : Form
    {
        public ReadValueEditDlg()
        {
            InitializeComponent();
            AttributeIdCB.Items.AddRange(Attributes.GetBrowseNames());
        }

        /// <summary>
        /// Prompts the user to specify the browse options.
        /// </summary>
        public bool ShowDialog(Session session, ReadValueId valueId)
        {
            if (session == null) throw new ArgumentNullException("session");
            if (valueId == null) throw new ArgumentNullException("valueId");

            NodeIdCTRL.Browser = new Browser(session);

            INode node = session.NodeCache.Find(valueId.NodeId);

            if (node != null)
            {
                DisplayNameTB.Text = node.ToString();
            }

            NodeIdCTRL.Identifier      = valueId.NodeId;
            AttributeIdCB.SelectedItem = Attributes.GetBrowseName(valueId.AttributeId);
            IndexRangeTB.Text          = valueId.IndexRange;
            EncodingCB.Text            = (valueId.DataEncoding != null)?valueId.DataEncoding.Name:null;
         
            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            valueId.NodeId      = NodeIdCTRL.Identifier;
            valueId.AttributeId = Attributes.GetIdentifier((string)AttributeIdCB.SelectedItem);
            valueId.IndexRange  = IndexRangeTB.Text;            
         
            if (String.IsNullOrEmpty(EncodingCB.Text))
            {
                valueId.DataEncoding = new QualifiedName(EncodingCB.Text);
            }

            return true;
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {              
            try
            {
                NodeId nodeId = NodeIdCTRL.Identifier;
            }
            catch (Exception)
            {
				MessageBox.Show("Please enter a valid node id.", this.Text);
            }
                        
            try
            {
                if (!String.IsNullOrEmpty(IndexRangeTB.Text))
                {
                    NumericRange indexRange = NumericRange.Parse(IndexRangeTB.Text);
                }
            }
            catch (Exception)
            {
				MessageBox.Show("Please enter a valid index range.", this.Text);
            }

            DialogResult = DialogResult.OK;
        }

        private void NodeIdCTRL_IdentifierChanged(object sender, EventArgs e)
        {
            if (NodeIdCTRL.Reference != null)
            {
                DisplayNameTB.Text = NodeIdCTRL.Reference.ToString();

                if (AttributeIdCB.SelectedItem == null)
                {
                    AttributeIdCB.SelectedItem = Attributes.GetBrowseName(Attributes.Value);
                }
            }
        }
    }
}
