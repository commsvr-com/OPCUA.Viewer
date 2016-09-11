//<summary>
//  Title   : Node value editor
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

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// A dialog used to edit a NodeId.
    /// </summary>
    public partial class NodeIdValueEditDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeIdValueEditDlg"/> class.
        /// </summary>
        public NodeIdValueEditDlg()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public NodeId ShowDialog(Session session, NodeId value)
        {
            if (session == null) throw new ArgumentNullException("session");

            ValueCTRL.Browser    = new Browser(session);
            ValueCTRL.RootId     = Objects.RootFolder;
            ValueCTRL.Identifier = value;

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return ValueCTRL.Identifier;
        }

        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public ExpandedNodeId ShowDialog(Session session, ExpandedNodeId value)
        {
            if (session == null) throw new ArgumentNullException("session");

            ValueCTRL.Browser    = new Browser(session);
            ValueCTRL.RootId     = Objects.RootFolder;
            ValueCTRL.Identifier = ExpandedNodeId.ToNodeId(value, session.NamespaceUris);

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return ValueCTRL.Identifier;
        }
        #endregion
    }
}
