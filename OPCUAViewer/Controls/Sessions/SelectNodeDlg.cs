//<summary>
//  Title   : Select node dialog
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
    public partial class SelectNodeDlg : Form
    {
        #region Constructors
        public SelectNodeDlg()
        {
            InitializeComponent();

            foreach (IdType idType in Enum.GetValues(typeof(IdType)))
            {
                IdentifierTypeCB.Items.Add(idType);
            }

            foreach (NodeClass nodeClass in Enum.GetValues(typeof(NodeClass)))
            {
                NodeClassCB.Items.Add(nodeClass);
            }
        }
        #endregion

        #region Private Fields
        private ReferenceDescription m_reference;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public ReferenceDescription ShowDialog(Browser browser, NodeId rootId)
        {
            if (browser == null) throw new ArgumentNullException("browser");

            BrowseCTRL.SetRoot(browser, rootId);

            NamespaceUriCB.Items.Clear();
            NamespaceUriCB.Items.AddRange(browser.Session.NamespaceUris.ToArray());
            
            OkBTN.Enabled = false;

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }
            
            return m_reference;
        }
        #endregion

        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void NamespaceUriCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_reference = null;
            OkBTN.Enabled = false;
        }

        private void NamespaceUriCB_TextChanged(object sender, EventArgs e)
        {
            m_reference = null;
            OkBTN.Enabled = false;
        }

        private void NodeIdentifierTB_TextChanged(object sender, EventArgs e)
        {
            m_reference = null;
            OkBTN.Enabled = false;
        }

        private void IdentifierTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_reference = null;
            OkBTN.Enabled = false;
        }

        private void BrowseCTRL_NodeSelected(object sender, TreeNodeActionEventArgs e)
        {
            try
            {
                // disable ok button if selection is not valid.
                OkBTN.Enabled = false;

                ReferenceDescription reference = e.Node as ReferenceDescription;
                
                if (reference == null)
                {
                    return;
                }

                if (NodeId.IsNull(reference.NodeId))
                {
                    return;
                }

                // set the display name.
                DisplayNameTB.Text       = reference.ToString();
                NodeClassCB.SelectedItem = (NodeClass)reference.NodeClass;
                
                // set identifier type.
                IdentifierTypeCB.SelectedItem = reference.NodeId.IdType;

                // set namespace uri.
                if (!String.IsNullOrEmpty(reference.NodeId.NamespaceUri))
                {
                    NamespaceUriCB.SelectedIndex = -1;
                    NamespaceUriCB.Text = reference.NodeId.NamespaceUri;
                }
                else
                {
                    if (reference.NodeId.NamespaceIndex < NamespaceUriCB.Items.Count)
                    {
                        NamespaceUriCB.SelectedIndex = (int)reference.NodeId.NamespaceIndex;
                    }
                    else
                    {
                        NamespaceUriCB.SelectedIndex = -1;
                        NamespaceUriCB.Text = null;
                    }
                }
                
                // set identifier.
                switch (reference.NodeId.IdType)
                {
                    case IdType.Opaque:
                    {
                        NodeIdentifierTB.Text = Convert.ToBase64String((byte[])reference.NodeId.Identifier);
                        break;
                    }

                    default:
                    {
                        NodeIdentifierTB.Text = Utils.Format("{0}", reference.NodeId.Identifier);
                        break;
                    }
                }

                // selection valid - enable ok.
                OkBTN.Enabled = true;
                m_reference = reference;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
