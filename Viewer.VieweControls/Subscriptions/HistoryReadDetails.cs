//<summary>
//  Title   : History read details
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
using System.Collections.Generic;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Client
{
    public partial class HistoryReadDetails : UserControl
    {
        public HistoryReadDetails()
        {
            InitializeComponent();
            
            QueryTypeCB.Items.Clear();
            QueryTypeCB.Items.Add("Read Raw or Modified");
        }

        private Session m_session;
        private ReadRawModifiedDetails m_details;
        
        #region Private Methods
        /// <summary>
        /// Initializes the control
        /// </summary>
        /// <param name="session"></param>
        /// <param name="details"></param>
        /// <param name="nodes"></param>
        public void Initialize(
            Session session,
            ReadRawModifiedDetails details,
            IList<ILocalNode> nodes)
        {
            m_session = session;
            m_details = details;

            StartTimeCTRL.Value = ToControlDateTime(details.StartTime);
            StartTimeSpecifiedCHK.Checked = details.StartTime != DateTime.MinValue;
            EndTimeCTRL.Value = ToControlDateTime(details.EndTime);
            EndTimeSpecifiedCHK.Checked = details.EndTime != DateTime.MinValue;
            MaxValuesCTRL.Value = details.NumValuesPerNode;
            IncludeBoundsCHK.Checked = details.ReturnBounds;
            IsModifiedCHK.Checked = details.IsReadModified;
        }
        #endregion
        
        #region Private Methods
        private DateTime ToControlDateTime(DateTime value)
        {
            if (value < new DateTime(1900,1,1))
            {
                return new DateTime(1900,1,1);
            }

            if (value > new DateTime(2100,1,1))
            {
                return new DateTime(2100,1,1);
            }

            return value;
        }

        private DateTime FromControlDateTime(DateTime value)
        {
            if (value <= new DateTime(1900,1,1))
            {
                return DateTime.MinValue;
            }

            if (value >= new DateTime(2100,1,1))
            {
                return DateTime.MaxValue;
            }

            return value;
        }
        #endregion
    }
}
