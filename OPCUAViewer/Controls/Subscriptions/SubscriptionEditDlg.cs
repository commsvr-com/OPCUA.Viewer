//<summary>
//  Title   : Subscription editor
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
using System.Windows.Forms;

using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class SubscriptionEditDlg : Form
    {
        public SubscriptionEditDlg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Prompts the user to specify the browse options.
        /// </summary>
        public bool ShowDialog(Subscription subscription)
        {
            if (subscription == null) throw new ArgumentNullException("subscription");

            DisplayNameTB.Text          = subscription.DisplayName;
            PublishingIntervalNC.Value  = (decimal)subscription.PublishingInterval;
            KeepAliveCountNC.Value      = subscription.KeepAliveCount;
            LifetimeCountCTRL.Value     = subscription.LifetimeCount;
            MaxNotificationsCTRL.Value  = subscription.MaxNotificationsPerPublish;
            PriorityNC.Value            = subscription.Priority;
            PublishingEnabledCK.Checked = subscription.PublishingEnabled;
            
            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            subscription.DisplayName                = DisplayNameTB.Text;
            subscription.PublishingInterval         = (int)PublishingIntervalNC.Value;
            subscription.KeepAliveCount             = (uint)KeepAliveCountNC.Value;
            subscription.LifetimeCount              = (uint)LifetimeCountCTRL.Value;
            subscription.MaxNotificationsPerPublish = (uint)MaxNotificationsCTRL.Value;
            subscription.Priority                   = (byte)PriorityNC.Value;
            subscription.PublishingEnabled          = PublishingEnabledCK.Checked;
            
            return true;
        }
    }
}
