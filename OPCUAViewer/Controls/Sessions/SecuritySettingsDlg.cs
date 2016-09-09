//<summary>
//  Title   : Security settings
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

namespace CAS.OPC.UA.Viewer.Controls
{
    /// <summary>
    /// Prompts the user to create a new secure channel.
    /// </summary>
    public partial class SecuritySettingsDlg : Form
    {
        public SecuritySettingsDlg()
        {
            InitializeComponent();

            foreach (MessageSecurityMode value in Enum.GetValues(typeof(MessageSecurityMode)))
            {
                SecurityModeCB.Items.Add(value);
            }

            foreach (string value in SecurityPolicies.GetDisplayNames())
            {
                SecurityPolicyUriCB.Items.Add(value);
            }
        }

        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public bool ShowDialog(ref MessageSecurityMode securityMode, ref string securityPolicyUri, ref bool useNativeStack)
        {
            // set security mode.
            SecurityModeCB.SelectedItem = securityMode;
            
            // set security policy uri
            SecurityPolicyUriCB.SelectedIndex = -1;

            // set native stack flag.
            UseNativeStackCK.Checked = useNativeStack;

            if (!String.IsNullOrEmpty(securityPolicyUri))
            {
                SecurityPolicyUriCB.SelectedItem = SecurityPolicies.GetDisplayName(securityPolicyUri);
            }

            // show dialog.
            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }
                
            securityMode      = (MessageSecurityMode)SecurityModeCB.SelectedItem;
            securityPolicyUri = SecurityPolicies.GetUri((string)SecurityPolicyUriCB.SelectedItem);
            useNativeStack    = UseNativeStackCK.Checked;
                       
            return true;
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // close the dialog.
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
