//<summary>
//  Title   : Select node
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
    public partial class SelectNodesDlg : Form
    {
        #region Constructors
        public SelectNodesDlg()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Fields
        private Session m_session;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public NodeIdCollection ShowDialog(
            Session          session, 
            BrowseViewType   browseView, 
            NodeIdCollection nodesIds,
            NodeClass        nodeClassMask)
        {
            if (session == null) throw new ArgumentNullException("session");

            m_session = session;

            BrowseCTRL.SetView(session, browseView, null);
            NodeListCTRL.Initialize(session, nodesIds, nodeClassMask);
            
            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }
                        
            return NodeListCTRL.GetNodeIds();
        }
        #endregion
        
        #region Private Methods
        #endregion
        
        #region Event Handler
        private void BrowseCTRL_NodesSelected(object sender, NodesSelectedEventArgs e)
        {
            try
            {
                foreach (ReferenceDescription reference in e.References)
                {
                    NodeListCTRL.AddNodeId(reference);
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
