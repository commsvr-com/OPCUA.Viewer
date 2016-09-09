//<summary>
//  Title   : Create secure channel
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

namespace CAS.OPC.UA.Viewer.Controls
{
    /// <summary>
    /// Prompts the user to create a new secure channel.
    /// </summary>
    public partial class CreateSecureChannelDlg : Form
    {
        public CreateSecureChannelDlg()
        {
            InitializeComponent();
        }

        private ITransportChannel m_channel;
        private ApplicationConfiguration m_configuration;
        private EndpointDescriptionCollection m_endpoints;
        private ServiceMessageContext m_messageContext;
        
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public ITransportChannel ShowDialog(
            ApplicationConfiguration      configuration,
            EndpointDescriptionCollection endpoints)
        {
            if (endpoints == null)      throw new ArgumentNullException("endpoints");
            if (configuration == null)  throw new ArgumentNullException("configuration");

            m_endpoints      = endpoints;
            m_configuration  = configuration;
            m_messageContext = configuration.CreateMessageContext();

            EndpointCB.Items.Clear();

            foreach (EndpointDescription endpoint in endpoints)
            {
                EndpointCB.Items.Add(endpoint.EndpointUrl);
            }

            if (EndpointCB.Items.Count > 0)
            {
                EndpointCB.SelectedIndex = 0;
            }
            
            OperationTimeoutNC.Value    = configuration.TransportQuotas.OperationTimeout;
            MaxMessageSizeNC.Value      = configuration.TransportQuotas.MaxMessageSize;
            MaxArrayLengthNC.Value      = configuration.TransportQuotas.MaxArrayLength;
            MaxStringLengthNC.Value     = configuration.TransportQuotas.MaxStringLength;
            MaxByteStringLengthNC.Value = configuration.TransportQuotas.MaxByteStringLength;

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }
                       
            // return the channel.
            return m_channel;
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                EndpointConfiguration configuration = EndpointConfiguration.Create(m_configuration);
        
                configuration.OperationTimeout    = (int)OperationTimeoutNC.Value;
                configuration.UseBinaryEncoding   = UseBinaryEncodingCK.Checked;
                configuration.MaxMessageSize      = (int)MaxMessageSizeNC.Value;
                configuration.MaxArrayLength      = (int)MaxArrayLengthNC.Value;
                configuration.MaxStringLength     = (int)MaxStringLengthNC.Value;
                configuration.MaxByteStringLength = (int)MaxByteStringLengthNC.Value;
                                
                ITransportChannel channel = SessionChannel.Create(
                    m_configuration,
                    m_endpoints[EndpointCB.SelectedIndex], 
                    configuration, 
                    m_configuration.SecurityConfiguration.ApplicationCertificate.Find(true),
                    m_messageContext);

                // create the channel.                   
                                                                   
                // open the channel.
                Cursor = Cursors.WaitCursor;

                m_channel = channel;

                // close the dialog.
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void EndpointCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = EndpointCB.SelectedIndex;

                if (index == -1)
                {
                    return;
                }

                EndpointDescription endpoint = m_endpoints[index];

                switch (endpoint.EncodingSupport)
                {
                    case BinaryEncodingSupport.Required:
                    {
                        UseBinaryEncodingCK.Checked = true;
                        UseBinaryEncodingCK.Enabled = false;
                        break;
                    }

                    case BinaryEncodingSupport.Optional:
                    {
                        UseBinaryEncodingCK.Checked = true;
                        UseBinaryEncodingCK.Enabled = true;
                        break;
                    }

                    default:
                    {
                        UseBinaryEncodingCK.Checked = false;
                        UseBinaryEncodingCK.Enabled = false;
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void DetailsBTN_Click(object sender, EventArgs e)
        {            
            try
            {
                int index = EndpointCB.SelectedIndex;

                if (index == -1)
                {
                    return;
                }

                new EndpointViewDlg().ShowDialog(m_endpoints[index]);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
