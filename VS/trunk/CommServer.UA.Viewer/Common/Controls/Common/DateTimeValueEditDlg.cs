//<summary>
//  Title   : DateTime editor
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
using System.Windows.Forms;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// A dialog to edit a date/time value
    /// </summary>
    public partial class DateTimeValueEditDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeValueEditDlg"/> class.
        /// </summary>
        public DateTimeValueEditDlg()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public bool ShowDialog(ref DateTime value)
        {
            if (value < ValueCTRL.MinDate)
            {
                ValueCTRL.Value = ValueCTRL.MinDate;
            }
            else if (value > ValueCTRL.MaxDate)
            {
                ValueCTRL.Value = ValueCTRL.MaxDate;
            }
            else
            {
                ValueCTRL.Value = value;
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            
            value = ValueCTRL.Value;

            if (value == ValueCTRL.MinDate)
            {
                value = DateTime.MinValue;
            }

            if (value == ValueCTRL.MaxDate)
            {
                value = DateTime.MaxValue;
            }

            return true;
        }
        #endregion
    }
}
