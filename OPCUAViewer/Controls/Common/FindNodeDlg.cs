//<summary>
//  Title   : Find node dialog
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
    public partial class FindNodeDlg : Form
    {
        public FindNodeDlg()
        {
            InitializeComponent();
        }

        private Session m_session;

        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public NodeIdCollection ShowDialog(Session session, NodeId startNodeId)
        {
            m_session = session;

            StartNode.Text    = String.Format("{0}", startNodeId);
            RelativePath.Text = null;

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return null;
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {                
                BrowsePathCollection browsePaths = new BrowsePathCollection();
                
                BrowsePath browsePath = new BrowsePath();

                browsePath.StartingNode = NodeId.Parse(StartNode.Text);
                browsePath.RelativePath = Opc.Ua.RelativePath.Parse(RelativePath.Text, m_session.TypeTree);
                
                browsePaths.Add(browsePath);

                BrowsePathResultCollection results = null;
                DiagnosticInfoCollection diagnosticInfos = null;

                m_session.TranslateBrowsePathsToNodeIds(
                    null,
                    browsePaths,
                    out results,
                    out diagnosticInfos);

                if (results != null && results.Count == 1)
                {
                    // NodesCTRL.SetNodeList(results[0].MatchingNodeIds);
                }    
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
