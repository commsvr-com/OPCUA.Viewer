//<summary>
//  Title   : Set monitoring mode
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
    public partial class SetMonitoringModeDlg : Form
    {
        public SetMonitoringModeDlg()
        {
            InitializeComponent();

            foreach (MonitoringMode value in Enum.GetValues(typeof(MonitoringMode)))
            {
                MonitoringModeCB.Items.Add(value);
            }
        }

        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public bool ShowDialog(ref MonitoringMode monitoringMode)
        {
            MonitoringModeCB.SelectedItem = monitoringMode;

            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            monitoringMode = (MonitoringMode)MonitoringModeCB.SelectedItem;

            return true;
        }
    }
}
