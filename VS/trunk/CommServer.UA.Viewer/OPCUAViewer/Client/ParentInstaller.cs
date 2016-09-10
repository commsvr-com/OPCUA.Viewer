//<summary>
//  Title   : Installer for the main assembly. Should be included as a link to the assembly.
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    MPostol: 06-03-2007: created
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using CAS.Lib.CodeProtect.EnvironmentAccess;
using System.Reflection;

namespace CAS.Lib.CodeProtect
{
  /// <summary>
  /// Provides the foundation for custom installations.
  /// </summary>
  [RunInstaller( true )]
  public partial class ParentInstaller: Installer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ParentInstaller"/> class.
    /// </summary>
    public ParentInstaller()
    {
      this.Installers.Add( new CAS.Lib.CodeProtect.LibInstaller() );
#if DEBUG
      Directory.SetCurrentDirectory( Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ) );
      if ( System.Windows.Forms.MessageBox.Show
        (
        "To debug attach to the process. Cancel to abort installation",
        "Main form installer", System.Windows.Forms.MessageBoxButtons.OKCancel
        ) != System.Windows.Forms.DialogResult.OK
        )
        throw new InstallException( "Installation aborted by used" );
#endif
    }
  }
}