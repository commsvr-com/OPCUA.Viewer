//<summary>
//  Title   : Complex value edit
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
using System.Reflection;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// A dialog to edit a complex value.
    /// </summary>
    public partial class ComplexValueEditDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexValueEditDlg"/> class.
        /// </summary>
        public ComplexValueEditDlg()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Private Fields
        private object m_value;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public object ShowDialog(object value)
        {
            return ShowDialog(value, null);
        }

        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public object ShowDialog(object value, MonitoredItem monitoredItem)
        {
            m_value = Utils.Clone(value);

            ValueCTRL.MonitoredItem = monitoredItem;
            ValueCTRL.ShowValue(m_value);

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return m_value;
        }
        #endregion
        
        #region Event Handlers
        private void OkBTN_Click(object sender, EventArgs e)
        {        
            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
