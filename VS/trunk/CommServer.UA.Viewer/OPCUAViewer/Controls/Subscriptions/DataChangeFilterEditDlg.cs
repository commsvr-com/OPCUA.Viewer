//<summary>
//  Title   : Data change filter
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
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class DataChangeFilterEditDlg : Form
    {
        public DataChangeFilterEditDlg()
        {
            InitializeComponent();
            
            Array values = Enum.GetValues(typeof(DataChangeTrigger));

            foreach (object value in values)
            {
                TriggerCB.Items.Add(value);
            }
                        
            values = Enum.GetValues(typeof(DeadbandType));

            foreach (object value in values)
            {
                DeadbandTypeCB.Items.Add(value);
            }
        }

        /// <summary>
        /// Prompts the user to specify the browse options.
        /// </summary>
        public bool ShowDialog(Session session, MonitoredItem monitoredItem)
        {
            if (monitoredItem == null) throw new ArgumentNullException("monitoredItem");

            DataChangeFilter filter = monitoredItem.Filter as DataChangeFilter;

            if (filter == null)
            {
                filter = new DataChangeFilter();

                filter.Trigger       = DataChangeTrigger.StatusValue;
                filter.DeadbandValue = 0;
                filter.DeadbandType  = (uint)(int)DeadbandType.None;
            }

            TriggerCB.SelectedItem      = filter.Trigger;
            DeadbandTypeCB.SelectedItem = (DeadbandType)(int)filter.DeadbandType;
            DeadbandNC.Value            = (decimal)filter.DeadbandValue;
            
            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            filter.Trigger       = (DataChangeTrigger)TriggerCB.SelectedItem;
            filter.DeadbandType  = Convert.ToUInt32(DeadbandTypeCB.SelectedItem);
            filter.DeadbandValue = (double)DeadbandNC.Value;

            monitoredItem.Filter = filter;

            return true;
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {              
            DialogResult = DialogResult.OK;
        }

        private void DeadbandTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeadbandType deadbandType = (DeadbandType)DeadbandTypeCB.SelectedItem;

            DeadbandNC.Enabled = deadbandType != DeadbandType.None;

            if (deadbandType == DeadbandType.Percent)
            {
                DeadbandNC.Minimum = 0;
                DeadbandNC.Maximum = 100;
            }
            else
            {
                DeadbandNC.Minimum = Decimal.MinValue;
                DeadbandNC.Maximum = Decimal.MaxValue;
            }
        }
    }
}
