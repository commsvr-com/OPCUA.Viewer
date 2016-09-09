//<summary>
//  Title   : Write dialog
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
    public partial class WriteDlg : Form
    {
        #region Constructors
        public WriteDlg()
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
        public void Show(Session session, WriteValueCollection values)
        {
            if (session == null) throw new ArgumentNullException("session");
            
            m_session = session;

            BrowseCTRL.SetView(m_session, BrowseViewType.Objects, null);
            WriteValuesCTRL.Initialize(session, values);

            MoveBTN_Click(BackBTN, null);

            Show();
            BringToFront();
        }

        /// <summary>
        /// Writes the valus to the server.
        /// </summary>
        private void Write()
        {
            WriteValueCollection nodesToWrite = WriteValuesCTRL.GetValues();

            if (nodesToWrite == null || nodesToWrite.Count == 0)
            {
                return;
            }

            StatusCodeCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;
            
            ResponseHeader responseHeader = m_session.Write(
                null,
                nodesToWrite,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToWrite);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToWrite);  
     
            WriteResultsCTRL.ShowValue(results, true);
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
                        WriteValuesCTRL.AddValue(reference);
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
                    Write();

                    WriteValuesCTRL.Parent  = SplitterPN.Panel1;

                    BackBTN.Visible         = true;
                    NextBTN.Visible         = false;
                    WriteBTN.Visible         = true;
                    WriteValuesCTRL.Visible  = true;
                    WriteResultsCTRL.Visible = true;
                    BrowseCTRL.Visible      = false;
                }

                else if (sender == BackBTN)
                {
                    WriteValuesCTRL.Parent  = SplitterPN.Panel2;

                    BackBTN.Visible          = false;
                    NextBTN.Visible          = true;
                    WriteBTN.Visible          = false;
                    WriteResultsCTRL.Visible  = false;
                    BrowseCTRL.Visible       = true;
                    WriteValuesCTRL.Visible   = true;
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void WriteMI_Click(object sender, EventArgs e)
        {
            try
            {
                Write();
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
