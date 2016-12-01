//_______________________________________________________________
//  Title   : ApplicationSettings
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate:  $
//  $Rev: $
//  $LastChangedBy: $
//  $URL: $
//  $Id:  $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.Lib.CodeProtect;
using System.IO;

namespace CAS.CommServer.UA.Viewer.UserInterface
{
  /// <summary>
  /// Class ApplicationSettings.
  /// </summary>
  public static class ApplicationSettings
  {
    /// <summary>
    /// Gets the log file folder path.
    /// </summary>
    /// <value>The log file folder path.</value>
    public static string LogFileFolderPath
    { get
      {
        return Path.Combine(InstallContextNames.ApplicationDataPath, Properties.Settings.Default.RelativeLogFilePath);
      }
    }
  }
}
