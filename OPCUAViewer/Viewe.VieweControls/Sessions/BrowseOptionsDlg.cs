//<summary>
//  Title   : Browse options
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
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class BrowseOptionsDlg : Form
    {
        #region Constructors
        public BrowseOptionsDlg()
        {
            InitializeComponent();

            foreach (object value in Enum.GetValues(typeof(BrowseDirection)))
            {
                BrowseDirectionCB.Items.Add(value);
            }

            BrowseDirectionCB.SelectedIndex = 0;
        }
        #endregion
        
        #region Private Fields
        private Browser m_browser;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Prompts the user to specify the browse options.
        /// </summary>
        public bool ShowDialog(Browser browser)
        {
            if (browser == null) throw new ArgumentNullException("browser");

            m_browser = browser;
            ReferenceTypeCTRL.Initialize(m_browser.Session, null);

            ViewIdTB.Text         = null;
            ViewTimestampDP.Value = ViewTimestampDP.MinDate;
            ViewVersionNC.Value   = 0;

            if (browser.View != null)
            {
                ViewIdTB.Text         = String.Format("{0}", browser.View.ViewId);
                ViewVersionNC.Value   = browser.View.ViewVersion;
                ViewVersionCK.Checked = browser.View.ViewVersion != 0;

                if (browser.View.Timestamp > ViewTimestampDP.MinDate)
                {                
                    ViewTimestampDP.Value   = browser.View.Timestamp ;
                    ViewTimestampCK.Checked = true;
                }
            }

            MaxReferencesReturnedNC.Value    = browser.MaxReferencesReturned;
            BrowseDirectionCB.SelectedItem   = browser.BrowseDirection;
            ReferenceTypeCTRL.SelectedTypeId = browser.ReferenceTypeId;
            IncludeSubtypesCK.Checked        = browser.IncludeSubtypes;
            NodeClassMaskCK.Checked          = browser.NodeClassMask != 0;             

            NodeClassList.Items.Clear();

            foreach (NodeClass value in Enum.GetValues(typeof(NodeClass)))
            {
                if (value == NodeClass.Unspecified)
                {
                    continue;
                }

                int index = NodeClassList.Items.Add(value);
                NodeClassList.SetItemChecked(index, (browser.NodeClassMask & (int)value) != 0);
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            return true;
        }
        #endregion
        
        #region Event Handlers
        private void ViewIdTB_TextChanged(object sender, EventArgs e)
        {
            ViewTimestampCK.Enabled = ViewVersionCK.Enabled = !String.IsNullOrEmpty(ViewIdTB.Text);
        }

        private void NodeClassMask_CheckedChanged(object sender, EventArgs e)
        {            
            NodeClassList.Enabled = NodeClassMaskCK.Checked;     
        }

        private void ViewVersionCK_CheckedChanged(object sender, EventArgs e)
        {
            ViewVersionNC.Enabled = ViewVersionCK.Checked;
        }

        private void ViewTimestampCK_CheckedChanged(object sender, EventArgs e)
        {
            ViewTimestampDP.Enabled = ViewTimestampCK.Checked;
        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                Browser browser = new Browser(m_browser.Session);

                browser.BrowseDirection = BrowseDirection.Forward;
                browser.NodeClassMask   = (int)NodeClass.View | (int)NodeClass.Object;
                browser.ReferenceTypeId = ReferenceTypeIds.Organizes;
                browser.IncludeSubtypes = true;

                ReferenceDescription reference = new SelectNodeDlg().ShowDialog(browser, Objects.ViewsFolder);

                if (reference != null)
                {
                    if (reference.NodeClass != NodeClass.View)
                    {
				        MessageBox.Show("Please select a valid view node id.", this.Text);
                        return;
                    }

                    ViewIdTB.Text = Utils.Format("{0}", reference.NodeId);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            NodeId viewId = null;

            try
            {
                viewId = NodeId.Parse(ViewIdTB.Text);
            }
            catch (Exception)
            {
				MessageBox.Show("Please enter a valid node id for the view id.", this.Text);
            }
            
            try
            {
                ViewDescription view = null;

                if (!NodeId.IsNull(viewId) || ViewTimestampCK.Checked || ViewVersionCK.Checked)
                {
                    view = new ViewDescription();

                    view.ViewId      = viewId;
                    view.Timestamp   = DateTime.MinValue;
                    view.ViewVersion = 0;

                    if (ViewTimestampCK.Checked && ViewTimestampDP.Value > ViewTimestampDP.MinDate)
                    {
                        view.Timestamp = ViewTimestampDP.Value;
                    }
                    
                    if (ViewVersionCK.Checked)
                    {
                        view.ViewVersion = (uint)ViewVersionNC.Value;
                    }
                }

                m_browser.View                  = view;
                m_browser.MaxReferencesReturned = (uint)MaxReferencesReturnedNC.Value;
                m_browser.BrowseDirection       = (BrowseDirection)BrowseDirectionCB.SelectedItem;
                m_browser.NodeClassMask         = (int)NodeClass.View | (int)NodeClass.Object;
                m_browser.ReferenceTypeId       = ReferenceTypeCTRL.SelectedTypeId;
                m_browser.IncludeSubtypes       = IncludeSubtypesCK.Checked;
                m_browser.NodeClassMask         = 0;

                int nodeClassMask = 0;

                foreach (NodeClass nodeClass in NodeClassList.CheckedItems)
                {
                    nodeClassMask |= (int)nodeClass;
                }

                m_browser.NodeClassMask = nodeClassMask;
                
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
