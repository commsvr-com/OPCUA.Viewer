//<summary>
//  Title   : Node attributes
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
    public partial class NodeAttributesDlg : Form
    {
        #region Constructors
        public NodeAttributesDlg()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Fields
        private Session m_session;
        private ExpandedNodeId m_nodeId;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public void ShowDialog(Session session, ExpandedNodeId nodeId)
        {
            if (session == null)   throw new ArgumentNullException("session");
            if (nodeId == null) throw new ArgumentNullException("nodeId");
            
            m_session = session;
            m_nodeId  = nodeId;

            AttributesCTRL.Initialize(session, nodeId);

            if (ShowDialog() != DialogResult.OK)
            {
                return;
            }
        }
        #endregion

        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                AttributesCTRL.Initialize(m_session, m_nodeId);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
