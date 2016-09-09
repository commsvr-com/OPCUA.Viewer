//<summary>
//  Title   : Background task
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

using System.Windows.Forms;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class BackgroundTaskDlg : Form
    {
        public BackgroundTaskDlg()
        {
            InitializeComponent();

            OkBTN.Enabled = false;
        }

        public int Progress
        {
            get { return ProgressCTRL.Value;  }
            
            set 
            { 
                ProgressCTRL.Value = value;

                if (value == ProgressCTRL.Maximum)
                {
                    OkBTN.Enabled = true;
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
