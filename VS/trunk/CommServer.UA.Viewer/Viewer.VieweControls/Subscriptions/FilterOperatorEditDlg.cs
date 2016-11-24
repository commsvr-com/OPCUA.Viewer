//<summary>
//  Title   : Filter opernad editor
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
using Opc.Ua;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class FilterOperatorEditDlg : Form
    {
        #region Constructors
        public FilterOperatorEditDlg()
        {
            InitializeComponent();

            OperatorCB.Items.Clear();

            foreach (FilterOperator op in Enum.GetValues(typeof(FilterOperator)))
            {
                OperatorCB.Items.Add(op);
            }
        }
        #endregion
                
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public bool ShowDialog(ref FilterOperator value)
        {
            OperatorCB.SelectedItem = value;

            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            
            value = (FilterOperator)OperatorCB.SelectedItem;
            
            return true;
        }
        #endregion
    }
}
