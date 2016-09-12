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

using CAS.Lib.CodeProtect;
using CAS.OPC.UA.Viewer.Client.Controls;
using CAS.OPC.UA.Viewer.Controls;
using Opc.Ua;
using Opc.Ua.Configuration;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CAS.CommServer.UA.Viewer.UserInterface
{
  [LicenseProvider(typeof(CodeProtectLP))]
  [Guid("38b20165-1ee4-47e8-8a70-6929e900795f")]
  public partial class OpcUaClientForm : ClientForm
  {
    public OpcUaClientForm()
    {
      InitializeComponent();
    }
    public OpcUaClientForm(ApplicationInstance application, ClientForm masterForm, ApplicationConfiguration configuration) : base(configuration.CreateMessageContext(), application, masterForm, configuration)
    {
      InitializeComponent();
      base.BrowseCTRL.MethodCalled += new MethodCalledEventHandler(BrowseCTRL_MethodCalled);
      configuration.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
    }
    private void CertificateValidator_CertificateValidation(CertificateValidator validator, CertificateValidationEventArgs e)
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
    private void BrowseCTRL_MethodCalled(object sender, MethodCalledEventArgs e)
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
