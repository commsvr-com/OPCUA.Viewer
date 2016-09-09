//<summary>
//  Title   : main Program of OPC.UA.Viewer
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate:$
//  $Rev:$
//  $LastChangedBy:$
//  $URL:$
//  $Id:$
//
//  Copyright (C)2010, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Windows.Forms;
using CAS.OPC.UA.Viewer.Properties;
using Opc.Ua;
using Opc.Ua.Configuration;

namespace CAS.OPC.UA.Viewer.Client
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault( false );

      ApplicationInstance application = new ApplicationInstance();
      application.ApplicationName = "OPC UA Viewer";
      application.ApplicationType = ApplicationType.ClientAndServer;
      application.ConfigSectionName = "OPC UA Viewer";
      try
      {
        string m_cmmdLine = Environment.CommandLine;
        if ( m_cmmdLine.ToLower().Contains( "installic" ) )
          CAS.Lib.CodeProtect.LibInstaller.InstalLicense( true );
      }
      catch ( Exception ex )
      {
        MessageBox.Show(
          string.Format( Resources.MainProgram_LicenseInstalation_Failure, ex.Message ),
          Resources.MainProgram_LicenseInstalation_Failure_Caption,
          MessageBoxButtons.OK, MessageBoxIcon.Error );
      }
      try
      {
        // process and command line arguments.
        if ( application.ProcessCommandLine( true ) )
        {
          return;
        }

        // load the application configuration.
        application.LoadApplicationConfiguration( false );

        // check the application certificate.
        application.CheckApplicationInstanceCertificate( false, 0 );

        // start the server.
        //application.Start(new SampleServer());

        // run the application interactively.
        Application.Run( new OpcUaClientForm( application, null, application.ApplicationConfiguration ) );
      }
      catch ( Exception e )
      {
        ExceptionDlg.Show( application.ApplicationName, e );
        return;
      }
    }
  }
}
