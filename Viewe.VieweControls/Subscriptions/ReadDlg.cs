//<summary>
//  Title   : Read dialog
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
    public partial class ReadDlg : Form
    {
        #region Constructors
        public ReadDlg()
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
        public void Show(Session session, ReadValueIdCollection valueIds)
        {
            if (session == null) throw new ArgumentNullException("session");
            
            m_session = session;

            BrowseCTRL.SetView(m_session, BrowseViewType.Objects, null);
            ReadValuesCTRL.Initialize(session, valueIds);

            MoveBTN_Click(BackBTN, null);

            Show();
            BringToFront();
        }

        private void Read()
        {
            ReadValueIdCollection nodesToRead = ReadValuesCTRL.GetValueIds();

            if (nodesToRead == null || nodesToRead.Count == 0)
            {
                return;
            }

            DataValueCollection values = null;
            DiagnosticInfoCollection diagnosticInfos = null;
            
            ResponseHeader responseHeader = m_session.Read(
                null,
                0,
                TimestampsToReturn.Both,
                nodesToRead,
                out values,
                out diagnosticInfos);

            ClientBase.ValidateResponse(values, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);  
     
            ReadResultsCTRL.ShowValue(values, true);
        }
        #endregion
        
        #region Event Handlers
        private void BrowseCTRL_ItemsSelected(object sender, NodesSelectedEventArgs e)
        {
            try
            {
                foreach (ReferenceDescription reference in e.References)
                {
                    if (reference.ReferenceTypeId == ReferenceTypeIds.HasProperty || reference.IsForward)
                    {
                        ReadValuesCTRL.AddValueId(reference);
                    }
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void MoveBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == NextBTN)
                {
                    Read();

                    ReadValuesCTRL.Parent  = SplitterPN.Panel1;

                    BackBTN.Visible         = true;
                    NextBTN.Visible         = false;
                    ReadBTN.Visible         = true;
                    ReadValuesCTRL.Visible  = true;
                    ReadResultsCTRL.Visible = true;
                    BrowseCTRL.Visible      = false;
                }

                else if (sender == BackBTN)
                {
                    ReadValuesCTRL.Parent  = SplitterPN.Panel2;

                    BackBTN.Visible          = false;
                    NextBTN.Visible          = true;
                    ReadBTN.Visible          = false;
                    ReadResultsCTRL.Visible  = false;
                    BrowseCTRL.Visible       = true;
                    ReadValuesCTRL.Visible   = true;
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ReadMI_Click(object sender, EventArgs e)
        {
            try
            {
                Read();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
