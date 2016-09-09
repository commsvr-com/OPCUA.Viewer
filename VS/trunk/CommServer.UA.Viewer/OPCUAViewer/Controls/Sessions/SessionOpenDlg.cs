//<summary>
//  Title   : Session open dialog
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
using System.Threading;
using System.Windows.Forms;
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class SessionOpenDlg : Form
    {
        #region Constructors
        public SessionOpenDlg()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Fields
        private Session m_session;
        private const string m_BrowseCertificates = "<Browse...>";
        private static long m_Counter = 0;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public bool ShowDialog(Session session)
        {
            if (session == null) throw new ArgumentNullException("session");

            m_session = session;
            
            UserIdentityTypeCB.Items.Clear();

            foreach (UserTokenPolicy policy in session.Endpoint.UserIdentityTokens)
            {
                UserIdentityTypeCB.Items.Add(policy.TokenType);
            }

            if (UserIdentityTypeCB.Items.Count == 0)
            {
                UserIdentityTypeCB.Items.Add(UserTokenType.UserName);
            }

            UserIdentityTypeCB.SelectedIndex = 0;

            SessionNameTB.Text = session.SessionName;

            if (String.IsNullOrEmpty(SessionNameTB.Text))
            {
                SessionNameTB.Text = Utils.Format("MySession {0}", Utils.IncrementIdentifier(ref m_Counter));
            }
            
            if (session.Identity != null)
            {
                UserIdentityTypeCB.SelectedItem = session.Identity.TokenType;
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            
            return true;
        }
        #endregion

        private void UserIdentityTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {            
            try
            {
                UserTokenType tokenType = (UserTokenType)UserIdentityTypeCB.SelectedItem;

                UserNameCB.Items.Clear();
                
                UserNameCB.Enabled = true;
                PasswordTB.Enabled = true;

                // allow use to browse certificate stores.
                if (tokenType == UserTokenType.Certificate)
                {
                    UserNameCB.Items.Add(m_BrowseCertificates);
                    UserNameCB.SelectedIndex = 0;
                }

                // populate list.
                foreach (IUserIdentity identity in m_session.IdentityHistory)
                {
                    if (identity.TokenType == tokenType)
                    {
                        UserNameCB.Items.Add(identity.DisplayName);
                    }
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // construct the user identity.
                IUserIdentity identity = null;

                if ((UserTokenType)UserIdentityTypeCB.SelectedItem == UserTokenType.UserName)
                {
                    string username = (string)UserNameCB.SelectedItem;

                    if (String.IsNullOrEmpty(username))
                    {
                        username = UserNameCB.Text;
                    }
                    
                    if (!String.IsNullOrEmpty(username) || !String.IsNullOrEmpty(PasswordTB.Text))
                    {
                        identity = new UserIdentity(username, PasswordTB.Text);
                    }
                }

                Cursor = Cursors.WaitCursor;

                ThreadPool.QueueUserWorkItem(Open, new object[] { m_session, SessionNameTB.Text, identity });
                
                CancelBTN.Enabled = false;
                OkBTN.Enabled = false;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }        

        /// <summary>
        /// Reports the results of the open session operation.
        /// </summary>
        private void OpenComplete(object e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new WaitCallback(OpenComplete), e);
                return;
            }

            if (IsDisposed)
            {
                return;
            }

            try
            {
                Cursor = Cursors.Default;

                if (e != null)
                {
                    GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), (Exception)e);
                }

                DialogResult = DialogResult.OK;
            }
            finally
            {
                CancelBTN.Enabled = true;
                OkBTN.Enabled = true;
            }
        }

        /// <summary>
        /// Asynchronously open the session.
        /// </summary>
        private void Open(object state)
        {
            try
            {
                Session session = ((object[])state)[0] as Session;
                string sessionName = ((object[])state)[1] as string;
                IUserIdentity identity = ((object[])state)[2] as IUserIdentity;

                // open the session.
                session.Open(sessionName, identity);

                OpenComplete(null);
            }
            catch (Exception exception)
            {
                OpenComplete(exception);
            }
        }
    }
}
