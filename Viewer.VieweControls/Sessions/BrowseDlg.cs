//<summary>
//  Title   : Browse dialog
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
    public partial class BrowseDlg : Form
    {
        #region Constructors
        public BrowseDlg()
        {
            InitializeComponent();
            m_SessionClosing = new EventHandler(Session_Closing);
        }
        #endregion
        
        #region Private Fields
        private Session m_session;
        private EventHandler m_SessionClosing;
        #endregion

        #region Public Interface
        /// <summary>
        /// Displays the address space with the specified view
        /// </summary>
        public void Show(Session session, NodeId startId)
        {   
            if (session == null) throw new ArgumentNullException("session");
            
            if (m_session != null)
            {
                m_session.SessionClosing -= m_SessionClosing;
            }

            m_session = session;            
            m_session.SessionClosing += m_SessionClosing;
            
            Browser browser  = new Browser(session);

            browser.BrowseDirection = BrowseDirection.Both;
            browser.ContinueUntilDone = true;
            browser.ReferenceTypeId = ReferenceTypeIds.References;

            BrowseCTRL.Initialize(browser, startId);
            
            UpdateNavigationBar();

            Show();
            BringToFront();
        }
        #endregion

        /// <summary>
        /// Updates the navigation bar with the current positions in the browse control.
        /// </summary>
        private void UpdateNavigationBar()
        {
            int index = 0;

            foreach (NodeId nodeId in BrowseCTRL.Positions)
            {
                Node node = m_session.NodeCache.Find(nodeId) as Node;

                string displayText = m_session.NodeCache.GetDisplayText(node);

                if (index < NodeCTRL.Items.Count)
                {
                    if (displayText != NodeCTRL.Items[index] as string)
                    {
                        NodeCTRL.Items[index] = displayText;
                    }
                }
                else
                {
                    NodeCTRL.Items.Add(displayText);
                }

                index++;
            }        
         
            while (index < NodeCTRL.Items.Count)
            {
                NodeCTRL.Items.RemoveAt(NodeCTRL.Items.Count-1);
            }
                                
            NodeCTRL.SelectedIndex = BrowseCTRL.Position;
        }
        
        private void Session_Closing(object sender, EventArgs e)
        {
            if (Object.ReferenceEquals(sender, m_session))
            {
                m_session.SessionClosing -= m_SessionClosing;
                m_session = null;
                Close();
            }
        }

        private void AddressSpaceDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_session != null)
            {
                m_session.SessionClosing -= m_SessionClosing;
                m_session = null;
            }
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            try
            {   
                BrowseCTRL.Back();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ForwardBTN_Click(object sender, EventArgs e)
        {
            try
            {   
                BrowseCTRL.Forward();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void NodeCTRL_SelectedIndexChanged(object sender, EventArgs e)
        {            
            try
            {   
                BrowseCTRL.SetPosition(NodeCTRL.SelectedIndex);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BrowseCTRL_PositionChanged(object sender, EventArgs e)
        { 
            try
            {
                if (BrowseCTRL.Position < NodeCTRL.Items.Count)
                {
                    NodeCTRL.SelectedIndex = BrowseCTRL.Position;
                }
                else
                {
                    NodeCTRL.SelectedIndex = -1;
                }                   
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BrowseCTRL_PositionAdded(object sender, EventArgs e)
        {
            try
            {
                UpdateNavigationBar();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
