//<summary>
//  Title   : ClientForm
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
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Configuration;
using System.Runtime.InteropServices;
using System.ComponentModel;
using CAS.Lib.CodeProtect;

namespace CAS.OPC.UA.Viewer.Client
{
  [LicenseProvider( typeof( CodeProtectLP ) )]
  [GuidAttribute( "38b20165-1ee4-47e8-8a70-6929e900795f" )]
    public partial class OpcUaClientForm : CAS.OPC.UA.Viewer.Controls.ClientForm
    {
        public OpcUaClientForm()
        {
            InitializeComponent();
        }

        public OpcUaClientForm(
            ApplicationInstance application, 
            CAS.OPC.UA.Viewer.Controls.ClientForm masterForm, 
            ApplicationConfiguration configuration)
        :
            base(configuration.CreateMessageContext(), application, masterForm, configuration)
        {
            InitializeComponent();
            
            base.BrowseCTRL.MethodCalled += new CAS.OPC.UA.Viewer.Controls.MethodCalledEventHandler(BrowseCTRL_MethodCalled);
            configuration.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
        }

        void CertificateValidator_CertificateValidation(CertificateValidator validator, CertificateValidationEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CertificateValidationEventHandler(CertificateValidator_CertificateValidation), validator, e);
                return;
            }

            try
            {
                GuiUtils.HandleCertificateValidationError(this, validator, e);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        void BrowseCTRL_MethodCalled(object sender, CAS.OPC.UA.Viewer.Controls.MethodCalledEventArgs e)
        {            
            try
            {
                // TBD
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
