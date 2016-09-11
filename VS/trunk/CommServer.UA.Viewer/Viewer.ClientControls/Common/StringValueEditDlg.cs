//<summary>
//  Title   : String value editor
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
    /// A dialog to edit a string value.
    /// </summary>
    public partial class StringValueEditDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="StringValueEditDlg"/> class.
        /// </summary>
        public StringValueEditDlg()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public string ShowDialog(string value)
        {
            ValueTB.Text = value;

            if (value != null)
            {
                int length = value.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).Length;

                if (length > 20)
                {
                    length = 20;
                }

                this.Height += (length-1)*16;
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return ValueTB.Text;
        }
        #endregion
    }
}
