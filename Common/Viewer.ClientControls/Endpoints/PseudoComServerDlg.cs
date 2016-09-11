//<summary>
//  Title   : PseudoComServer
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
using System.Text;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Configuration;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// Prompts the user to edit a PseudoComServerDlg.
    /// </summary>
    public partial class PseudoComServerDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes the dialog.
        /// </summary>
        public PseudoComServerDlg()
        {
            InitializeComponent();

            foreach (ComSpecification value in Enum.GetValues(typeof(ComSpecification)))
            {
                SpecificationCB.Items.Add(value);
            }
        }
        #endregion

        #region Private Fields
        private EndpointComIdentity m_comIdentity;
        #endregion

        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public EndpointComIdentity ShowDialog(ConfiguredEndpoint endpoint)
        {
            if (endpoint == null) throw new ArgumentNullException("endpoint");

            m_comIdentity = endpoint.ComIdentity;

            // assign a default prog id/clsid.
            if (String.IsNullOrEmpty(m_comIdentity.ProgId))
            {
                m_comIdentity.ProgId = PseudoComServer.CreateProgIdFromUrl(ComSpecification.DA, endpoint.EndpointUrl.ToString());
                m_comIdentity.Clsid = ConfigUtils.CLSIDFromProgID(m_comIdentity.ProgId);

                if (m_comIdentity.Clsid == Guid.Empty)
                {
                    m_comIdentity.Clsid = Guid.NewGuid();
                }
            }

            SpecificationCB.SelectedItem = m_comIdentity.Specification;
            ClsidTB.Text  = m_comIdentity.Clsid.ToString();
            ProgIdTB.Text = m_comIdentity.ProgId;

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }
                        
            return m_comIdentity;      
        }
        #endregion

        #region Private Methods
        #endregion

        #region Event Handlers
        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                Guid clsid = Guid.Empty;

                try
                {
                    clsid = new Guid(ClsidTB.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please specify a valid CLSID.");
                    return;
                }

                string progId = ProgIdTB.Text;

                if (String.IsNullOrEmpty(progId))
                {
                    MessageBox.Show("Please specify a valid ProgID.");
                    return;
                }

                m_comIdentity.Specification = (ComSpecification)SpecificationCB.SelectedItem;
                m_comIdentity.Clsid = clsid;
                m_comIdentity.ProgId = progId;

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void SpecificationCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string progId = ProgIdTB.Text;

                if (!String.IsNullOrEmpty(progId))
                {
                    StringBuilder buffer = new StringBuilder();
                    ComSpecification specification = (ComSpecification)SpecificationCB.SelectedItem;

                    switch (specification)
                    {
                        case ComSpecification.DA:
                        {
                            buffer.Append("OpcDa.");
                            break;
                        }

                        case ComSpecification.AE:
                        {
                            buffer.Append("OpcAe.");
                            break;
                        }

                        case ComSpecification.HDA:
                        {
                            buffer.Append("OpcHda.");
                            break;
                        }
                    }

                    int index = progId.IndexOf('.');

                    if (index != -1)
                    {
                        buffer.Append(progId.Substring(index+1));
                    }
                    else
                    {
                        buffer.Append(progId);
                    }

                    ProgIdTB.Text = buffer.ToString();
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
