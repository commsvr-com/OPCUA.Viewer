//<summary>
//  Title   : Numeric value editor
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

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// A dialog to edit a numeric value.
    /// </summary>
    public partial class NumericValueEditDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericValueEditDlg"/> class.
        /// </summary>
        public NumericValueEditDlg()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public object ShowDialog(object value, Type type)
        {
            if (type == null && value != null)
            {
                type = value.GetType();
            }

            if (type == typeof(Variant))
            {
                type = typeof(double);
            }

            SetLimits(type);

            ValueCTRL.Value = Convert.ToDecimal(value);

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return Convert.ChangeType(ValueCTRL.Value, type);
        }
        #endregion
        
        #region Private Methods
        /// <summary>
        /// Sets the limits according to the data type.
        /// </summary>
        private void SetLimits(Type type)
        {
            if (type == typeof(sbyte))
            {
                ValueCTRL.Minimum = SByte.MinValue;
                ValueCTRL.Maximum = SByte.MaxValue;
                ValueCTRL.DecimalPlaces = 0;
            }

            if (type == typeof(byte))
            {
                ValueCTRL.Minimum = Byte.MinValue;
                ValueCTRL.Maximum = Byte.MaxValue;
                ValueCTRL.DecimalPlaces = 0;
            }

            if (type == typeof(short))
            {
                ValueCTRL.Minimum = Int16.MinValue;
                ValueCTRL.Maximum = Int16.MaxValue;
                ValueCTRL.DecimalPlaces = 0;
            }

            if (type == typeof(ushort))
            {
                ValueCTRL.Minimum = UInt16.MinValue;
                ValueCTRL.Maximum = UInt16.MaxValue;
                ValueCTRL.DecimalPlaces = 0;
            }

            if (type == typeof(int))
            {
                ValueCTRL.Minimum = Int32.MinValue;
                ValueCTRL.Maximum = Int32.MaxValue;
                ValueCTRL.DecimalPlaces = 0;
            }

            if (type == typeof(uint))
            {
                ValueCTRL.Minimum = UInt32.MinValue;
                ValueCTRL.Maximum = UInt32.MaxValue;
                ValueCTRL.DecimalPlaces = 0;
            }

            if (type == typeof(long))
            {
                ValueCTRL.Minimum = Int64.MinValue;
                ValueCTRL.Maximum = Int64.MaxValue;
                ValueCTRL.DecimalPlaces = 0;
            }

            if (type == typeof(ulong))
            {
                ValueCTRL.Minimum = UInt64.MinValue;
                ValueCTRL.Maximum = UInt64.MaxValue;
                ValueCTRL.DecimalPlaces = 0;
            }

            if (type == typeof(float))
            {
                ValueCTRL.Minimum = Decimal.MinValue;
                ValueCTRL.Maximum = Decimal.MaxValue;
                ValueCTRL.DecimalPlaces = 6;
            }

            if (type == typeof(double))
            {
                ValueCTRL.Minimum = Decimal.MinValue;
                ValueCTRL.Maximum = Decimal.MaxValue;
                ValueCTRL.DecimalPlaces = 15;
            }
        }
        #endregion
    }
}
