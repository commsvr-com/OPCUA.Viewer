//<summary>
//  Title   : Endpoint view
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
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Opc.Ua;

namespace CAS.OPC.UA.Viewer.Controls
{
    /// <summary>
    /// Prompts the user to create a new secure channel.
    /// </summary>
    public partial class EndpointViewDlg : Form
    {
        public EndpointViewDlg()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public bool ShowDialog(EndpointDescription endpoint)
        {
            if (endpoint == null) throw new ArgumentNullException("endpoint");
        
            EndpointTB.Text   = endpoint.EndpointUrl;
            ServerNameTB.Text = endpoint.Server.ApplicationName.Text;
            ServerUriTB.Text  = endpoint.Server.ApplicationUri;

            try
            {
                X509Certificate2 certificate = CertificateFactory.Create(endpoint.ServerCertificate, true);
                ServerCertificateTB.Text = String.Format("{0}", certificate.Subject);
            }
            catch
            {
                ServerCertificateTB.Text = "<bad certificate>";
            }
                
           
            SecurityModeTB.Text      = String.Format("{0}", endpoint.SecurityMode);;
            SecurityPolicyUriTB.Text = String.Format("{0}", endpoint.SecurityPolicyUri);
            
            UserIdentityTypeTB.Text = "";

            foreach (UserTokenPolicy policy in endpoint.UserIdentityTokens)
            {
                UserIdentityTypeTB.Text += String.Format("{0} ", policy.TokenType);
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }
                       
            return true;
        }
    }
}
