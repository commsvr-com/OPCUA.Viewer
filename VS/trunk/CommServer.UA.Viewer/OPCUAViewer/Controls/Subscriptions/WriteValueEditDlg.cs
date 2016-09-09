//<summary>
//  Title   : Write value editor
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
    public partial class WriteValueEditDlg : Form
    {
        public WriteValueEditDlg()
        {
            InitializeComponent();

            AttributeIdCB.Items.AddRange(Attributes.GetBrowseNames());
        }

        /// <summary>
        /// Prompts the user to specify the browse options.
        /// </summary>
        public bool ShowDialog(Session session, WriteValue value)
        {
            if (session == null) throw new ArgumentNullException("session");
            if (value == null)   throw new ArgumentNullException("value");

            
            NodeIdCTRL.Browser = new Browser(session);

            INode node = session.NodeCache.Find(value.NodeId);

            if (node != null)
            {
                DisplayNameTB.Text = node.ToString();
            }

            NodeIdCTRL.Identifier      = value.NodeId;
            AttributeIdCB.SelectedItem = Attributes.GetBrowseName(value.AttributeId);
            IndexRangeTB.Text          = value.IndexRange;
         
            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            value.NodeId      = NodeIdCTRL.Identifier;
            value.AttributeId = Attributes.GetIdentifier((string)AttributeIdCB.SelectedItem);
            value.IndexRange  = IndexRangeTB.Text;            
         
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
