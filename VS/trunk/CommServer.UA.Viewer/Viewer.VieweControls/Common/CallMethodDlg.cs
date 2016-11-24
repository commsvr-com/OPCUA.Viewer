//<summary>
//  Title   : Call method
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
    public partial class CallMethodDlg : Form
    {
        #region Constructors
        public CallMethodDlg()
        {
            InitializeComponent();
            m_SessionClosing = new EventHandler(Session_Closing);
        }
        #endregion

        #region Private Fields
        private Session m_session;
        private EventHandler m_SessionClosing;
        private NodeId m_objectId;
        private NodeId m_methodId;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public void Show(Session session, NodeId objectId, NodeId methodId)
        {
            if (session == null)  throw new ArgumentNullException("session");
            if (methodId == null) throw new ArgumentNullException("methodId");
            
            if (m_session != null)
            {
                m_session.SessionClosing -= m_SessionClosing;
            }

            m_session = session;
            m_session.SessionClosing += m_SessionClosing;
        
            m_objectId = objectId;            
            m_methodId = methodId;

            InputArgumentsCTRL.Update(session, methodId, true);     
            OutputArgumentsCTRL.Update(session, methodId, false);
            
            Node target = session.NodeCache.Find(objectId) as Node;
            Node method = session.NodeCache.Find(methodId) as Node;

            if (target != null && method != null)
            {
                Text = String.Format("Call {0}.{1}", target, method);
            }

            Show();
            BringToFront();
        }
        #endregion
                
        private void Session_Closing(object sender, EventArgs e)
        {
            if (Object.ReferenceEquals(sender, m_session))
            {
                m_session.SessionClosing -= m_SessionClosing;
                m_session = null;
                Close();
            }
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                VariantCollection inputArguments = InputArgumentsCTRL.GetValues();
                                
                CallMethodRequest request = new CallMethodRequest();

                request.ObjectId       = m_objectId;
                request.MethodId       = m_methodId;
                request.InputArguments = inputArguments;

                CallMethodRequestCollection requests = new CallMethodRequestCollection();
                requests.Add(request);

                CallMethodResultCollection results;
                DiagnosticInfoCollection diagnosticInfos;

                ResponseHeader responseHeader = m_session.Call(
                    null,
                    requests,
                    out results,
                    out diagnosticInfos);

                if (StatusCode.IsBad(results[0].StatusCode))
                {
                    throw new ServiceResultException(new ServiceResult(results[0].StatusCode, 0, diagnosticInfos, responseHeader.StringTable));
                }

                OutputArgumentsCTRL.SetValues(results[0].OutputArguments);

                if (results[0].OutputArguments.Count == 0)
                {
                    MessageBox.Show(this, "Method executed successfully.");
                }
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
                if (Modal)
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    Close();
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
