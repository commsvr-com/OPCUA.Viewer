//<summary>
//  Title   : Monitored item editor
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
    public partial class MonitoredItemEditDlg : Form
    {
        public MonitoredItemEditDlg()
        {
            InitializeComponent();

            AttributeIdCB.Items.AddRange(Attributes.GetBrowseNames());
            
            foreach (MonitoringMode value in Enum.GetValues(typeof(MonitoringMode)))
            {
                MonitoringModeCB.Items.Add(value);
            }

            foreach (NodeClass value in Enum.GetValues(typeof(NodeClass)))
            {
                NodeClassCB.Items.Add(value);
            }
        }

        private Session m_session;

        /// <summary>
        /// Prompts the user to specify the browse options.
        /// </summary>
        public bool ShowDialog(Session session, MonitoredItem monitoredItem)
        {
            if (monitoredItem == null) throw new ArgumentNullException("monitoredItem");

            m_session = session;

            NodeIdCTRL.Browser = new Browser(session);

            DisplayNameTB.Text                  = monitoredItem.DisplayName;
            NodeIdCTRL.Identifier               = monitoredItem.StartNodeId;
            RelativePathTB.Text                 = monitoredItem.RelativePath;
            NodeClassCB.SelectedItem            = monitoredItem.NodeClass;
            AttributeIdCB.SelectedItem          = Attributes.GetBrowseName(monitoredItem.AttributeId);
            IndexRangeTB.Text                   = monitoredItem.IndexRange;
            EncodingCB.Text                     = (monitoredItem.Encoding != null)?monitoredItem.Encoding.Name:null;
            MonitoringModeCB.SelectedItem       = monitoredItem.MonitoringMode;
            SamplingIntervalNC.Value            = 1000;
            SamplingIntervalSpecifiedCK.Checked = false;
            QueueSizeNC.Value                   = 1;
            QueueSizeSpecifiedCK.Checked        = false;
            DisableOldestCK.Checked             = monitoredItem.DiscardOldest;

            if (monitoredItem.SamplingInterval >= 0)
            {
                SamplingIntervalNC.Value = monitoredItem.SamplingInterval;
                SamplingIntervalSpecifiedCK.Checked = true;
            }
            
            if (monitoredItem.QueueSize > 0 && monitoredItem.QueueSize != Int32.MaxValue)
            {
                QueueSizeNC.Value = monitoredItem.QueueSize;
                QueueSizeSpecifiedCK.Checked = true;
            }
            
            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            monitoredItem.DisplayName      = DisplayNameTB.Text;
            monitoredItem.NodeClass        = (NodeClass)NodeClassCB.SelectedItem;
            monitoredItem.StartNodeId      = NodeIdCTRL.Identifier;
            monitoredItem.RelativePath     = RelativePathTB.Text;
            monitoredItem.AttributeId      = Attributes.GetIdentifier((string)AttributeIdCB.SelectedItem);
            monitoredItem.IndexRange       = IndexRangeTB.Text;            
            monitoredItem.MonitoringMode   = (MonitoringMode)MonitoringModeCB.SelectedItem;
            monitoredItem.SamplingInterval = (int)SamplingIntervalNC.Value;
            monitoredItem.QueueSize        = (uint)QueueSizeNC.Value;
            monitoredItem.DiscardOldest    = DisableOldestCK.Checked;

            if (!SamplingIntervalSpecifiedCK.Checked)
            {
                monitoredItem.SamplingInterval = -1;
            }
            
            if (!QueueSizeSpecifiedCK.Checked)
            {
                monitoredItem.QueueSize = 0;
            }

            if (String.IsNullOrEmpty(EncodingCB.Text))
            {
                monitoredItem.Encoding = new QualifiedName(EncodingCB.Text);
            }

            return true;
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {              
            try
            {
                NodeId nodeId = NodeIdCTRL.Identifier;
            }
            catch (Exception)
            {
				MessageBox.Show("Please enter a valid node id.", this.Text);
            }
            
            try
            {
                if (!String.IsNullOrEmpty(RelativePathTB.Text))
                {
                    RelativePath relativePath = RelativePath.Parse(RelativePathTB.Text, m_session.TypeTree);
                }
            }
            catch (Exception)
            {
				MessageBox.Show("Please enter a valid relative path.", this.Text);
            }

            try
            {
                if (!String.IsNullOrEmpty(IndexRangeTB.Text))
                {
                    NumericRange indexRange = NumericRange.Parse(IndexRangeTB.Text);
                }
            }
            catch (Exception)
            {
				MessageBox.Show("Please enter a valid index range.", this.Text);
            }

            DialogResult = DialogResult.OK;
        }

        private void SamplingIntervalSpecifiedCK_CheckedChanged(object sender, EventArgs e)
        {
            SamplingIntervalNC.Enabled = SamplingIntervalSpecifiedCK.Checked;
            QueueSizeNC.Enabled = QueueSizeSpecifiedCK.Checked;
        }

        private void NodeIdCTRL_IdentifierChanged(object sender, EventArgs e)
        {
            if (NodeIdCTRL.Reference != null)
            {
                DisplayNameTB.Text = m_session.NodeCache.GetDisplayText(NodeIdCTRL.Reference);
                NodeClassCB.SelectedItem = (NodeClass)NodeIdCTRL.Reference.NodeClass;
            }
        }
    }
}
