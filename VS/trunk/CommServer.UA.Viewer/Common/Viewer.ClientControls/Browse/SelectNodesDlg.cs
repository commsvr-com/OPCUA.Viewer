//<summary>
//  Title   : Select nodes dialog
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
    /// A dialog used to selected one or more nodes.
    /// </summary>
    public partial class SelectNodesDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectNodesDlg"/> class.
        /// </summary>
        public SelectNodesDlg()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Fields
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public IList<ILocalNode> ShowDialog(Session session, NodeId rootId, IList<NodeId> nodeIds)
        {
            BrowseCTRL.Initialize(session, rootId, null, null, BrowseDirection.Forward);
            ReferencesCTRL.Initialize(session, rootId);
            AttributesCTRL.Initialize(session, rootId);
            NodesCTRL.Initialize(session, nodeIds);

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return NodesCTRL.GetNodeList();
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

        private void BrowseCTRL_NodesSelected(object sender, BrowseTreeCtrl.NodesSelectedEventArgs e)
        {
            try
            {
                foreach (ReferenceDescription reference in e.Nodes)
                {
                    if (!reference.NodeId.IsAbsolute)
                    {
                        NodesCTRL.Add((NodeId)reference.NodeId);
                    }
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }

        }
    }
}
