//<summary>
//  Title   : Clipboard hacks
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
using System.Threading;
using System.Windows.Forms;
using Opc.Ua;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// This class is used to work around a bug in the MS VPC implementation. 
    /// </summary>    
    /// <remarks>
    /// Clipborad operations will fail if this class is not used on VPCs with the 
    /// virtual machine additions installed.
    /// </remarks>
    public static class ClipboardHack
    {
        #region Public Methods
        /// <summary>
        /// Retrieves the data from the clipboard.
        /// </summary>
        public static object GetData(string format)
        {
            lock (m_lock)
            {
                m_format = format;
                m_data = null;
                m_error = null;

                Thread thread = new Thread(new ThreadStart(GetClipboardPrivate));
                thread.IsBackground = true;
                
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();

                if (m_error != null)
                {
                    throw new ServiceResultException(m_error, StatusCodes.BadUnexpectedError);
                }

                return m_data;
            }
        }
        
        /// <summary>
        /// Saves the data in the clipboard.
        /// </summary>
        public static void SetData(string format, object data)
        {
            lock (m_lock)
            {
                m_format = format;
                m_data = data;
                m_error = null;

                Thread thread = new Thread(new ThreadStart(SetClipboardPrivate));
                thread.IsBackground = true;
                
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();

                if (m_error != null)
                {
                    throw new ServiceResultException(m_error, StatusCodes.BadUnexpectedError);
                }
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the data in the clipboard if it is the correct format.
        /// </summary>
        private static void GetClipboardPrivate()
        {
            try
            {
                m_error = null;

                if (String.IsNullOrEmpty(m_format) || !Clipboard.ContainsData(m_format))
                { 
                    m_data = null;
                    return;
                }
                
                m_data = Clipboard.GetData(m_format);
            }
            catch (Exception e)
            {
                m_error = e;
            }
        }
        
        /// <summary>
        /// Saves the data in the clipboard if it is the correct format.
        /// </summary>
        private static void SetClipboardPrivate()
        {
            try
            {
                m_error = null;

                if (String.IsNullOrEmpty(m_format) || m_data == null)
                { 
                    return;
                }

                Clipboard.SetData(m_format, m_data);
            }
            catch (Exception e)
            {
                m_error = e;
            }
        }
        #endregion

        #region Private Fields
        private static object m_lock = new object();
        private static string m_format = null;
        private static object m_data = null;
        private static Exception m_error = null;
        #endregion
    }
}
