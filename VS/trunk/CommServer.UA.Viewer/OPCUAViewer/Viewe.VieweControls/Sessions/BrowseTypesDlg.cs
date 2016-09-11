//<summary>
//  Title   : Browse types dialog
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
using CAS.OPC.UA.Viewer.Client;
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class BrowseTypesDlg : Form
    {
        #region Constructors
        public BrowseTypesDlg()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Fields
        private Session m_session;
        private ILocalNode m_selectedType;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public void Show(
            Session session,
            NodeId  typeId)
        {
            if (session == null) throw new ArgumentNullException("session");

            m_session = session;                    
            
            TypeNavigatorCTRL.Initialize(m_session, typeId);
            TypeHierarchyCTRL.Initialize(m_session, typeId);

            Show();
            BringToFront();
        }
        #endregion
        
        #region Private Methods
        #endregion
        
        #region Event Handler
        private void TypeNavigatorCTRL_TypeSelected(object sender, TypeNavigatorEventArgs e)
        {
            try
            {
                m_selectedType = e.Node;

                if (m_selectedType != null)
                {
                    TypeHierarchyCTRL.Initialize(m_session, m_selectedType.NodeId);
                }
                else
                {
                    TypeHierarchyCTRL.Initialize(m_session, null);
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
