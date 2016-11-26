//_______________________________________________________________
//  Title   : AssemblyTraceEvent
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________



using System;
using System.Diagnostics;
using System.Reflection;

namespace CAS.OPCViewer
{
  /// <summary>
  /// Singleton implementation of the <see cref="TraceSource"/>.
  /// </summary>
  public static class AssemblyTraceEvent
  {
    private static Lazy<TraceSource> m_TraceEventInternal = new Lazy<TraceSource>(() => new TraceSource(Assembly.GetCallingAssembly().GetName().Name) );
    /// <summary>
    /// Gets the tracer.
    /// </summary>
    /// <value>The tracer.</value>
    public static TraceSource Tracer
    {
      get
      {
        return m_TraceEventInternal.Value;
      }
    }
  }
}
