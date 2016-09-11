//<summary>
//  Title   : Republish notification message
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
    public partial class RepublishNotificationMessageDlg : Form
    {
        #region Constructors
        public RepublishNotificationMessageDlg()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Private Fields
        private Subscription m_subscription;
        private NotificationMessage m_message;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public NotificationMessage ShowDialog(Subscription subscription)
        {
            if (subscription == null) throw new ArgumentNullException("subscription");

            m_subscription = subscription;

            SequenceNumberNC.Value = 0;

            foreach (uint sequenceNumber in m_subscription.AvailableSequenceNumbers)
            {
                if (SequenceNumberNC.Value < (decimal)sequenceNumber)
                {
                    SequenceNumberNC.Value = sequenceNumber;
                }
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return m_message;
        }
        #endregion

        #region Event Handlers
        private void OkBTN_Click(object sender, EventArgs e)
        {        
            try
            {
                m_message = m_subscription.Republish((uint)SequenceNumberNC.Value);
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
