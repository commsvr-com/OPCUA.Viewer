//<summary>
//  Title   : Data encoding
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
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class DataEncodingDlg : Form
    {
        #region Constructors
        public DataEncodingDlg()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Private Fields
        private Session m_session;
        private ReferenceDescriptionCollection m_encodings;
        #endregion
        
        #region Private Methods
        /// <summary>
        /// Formats the description.
        /// </summary>
        private void FormatDescription()
        {
            string text = DescriptionTB.Text;

            int state = 0;
            int start = 0;
            int offset = 0;

            for (int ii = 0; ii < 4096 && ii < text.Length; ii++)
            {
                if (text[ii] == '\r')
                {
                    offset--;
                }

                if (state == 0)
                {                    
                    if (text[ii] == '<')
                    {
                        start = ii;
                        state = 1;
                        continue;
                    }
                }
                
                if (state == 1)
                { 
                    if (Char.IsLetter(text[ii]))
                    {                          
                        DescriptionTB.SelectionStart  = start + offset;
                        DescriptionTB.SelectionLength = ii - start;
                        DescriptionTB.SelectionColor  = Color.Blue;
                        
                        string selection = DescriptionTB.SelectedText;
                                                    
                        start = ii;
                        state = 2;
                        continue;
                    }
                }
                                    
                if (state == 2)
                { 
                    if (Char.IsWhiteSpace(text[ii]) || text[ii] == '>' || text[ii] == '/')
                    {
                        DescriptionTB.SelectionStart  = start + offset;
                        DescriptionTB.SelectionLength = ii - start;
                        DescriptionTB.SelectionColor  = Color.Maroon;
                        
                        string selection = DescriptionTB.SelectedText;
                                                    
                        start = ii;

                        if (text[ii] == '>' || text[ii] == '/')
                        {
                            state = 0;
                        }
                        else
                        {
                            state = 3;
                        }

                        continue;
                    }
                }
                                    
                if (state == 3)
                { 
                    if (text[ii] == '>')
                    {
                        DescriptionTB.SelectionStart  = start + offset;
                        DescriptionTB.SelectionLength = ii - start + 1;
                        DescriptionTB.SelectionColor  = Color.Blue;
                        
                        string selection = DescriptionTB.SelectedText;
                                                    
                        start = ii+1;
                        state = 0;
                        continue;
                    }

                    if (Char.IsLetter(text[ii]))
                    {
                        start = ii;
                        state = 4;
                        continue;
                    }
                }
                                    
                if (state == 4)
                { 
                    if (text[ii] == '=')
                    {
                        DescriptionTB.SelectionStart  = start + offset;
                        DescriptionTB.SelectionLength = ii - start;
                        DescriptionTB.SelectionColor  = Color.Red;
                        
                        string selection = DescriptionTB.SelectedText;
                                                    
                        start = ii;
                        state = 5;
                        continue;
                    }
                }
                                    
                if (state == 5)
                { 
                    if (text[ii] == '"' || text[ii] == '\'')
                    {
                        state = 6;
                        continue;
                    }
                }
                                    
                if (state == 6)
                { 
                    if (text[ii] == '"' || text[ii] == '\'')
                    {
                        DescriptionTB.SelectionStart  = start + offset;
                        DescriptionTB.SelectionLength = ii - start + 1;
                        DescriptionTB.SelectionColor  = Color.Blue;
                        
                        string selection = DescriptionTB.SelectedText;
                                                    
                        start = ii+1;
                        state = 3;
                        continue;
                    }
                }
            }       
        }
        #endregion
        
        #region Event Handlers
        /// <summary>
        /// Prompts the user to specify the browse options.
        /// </summary>
        public bool ShowDialog(Session session, NodeId variableId)
        {
            if (session == null)    throw new ArgumentNullException("session");
            if (variableId == null) throw new ArgumentNullException("variableId");
            
            m_session   = session;
            m_encodings = session.ReadAvailableEncodings(variableId);

            foreach (ReferenceDescription encoding in m_encodings)
            {
                EncodingCB.Items.Add(encoding.ToString());
            }

            if (EncodingCB.Items.Count > 0)
            {
                EncodingCB.SelectedIndex = 0;
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            return true;
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {              
            DialogResult = DialogResult.OK;
        }

        private void EncodingCB_SelectedIndexChanged(object sender, EventArgs e)
        {            
            try
            {
                DescriptionTB.Text    = null;
                TypeNameTB.Text       = null;
                DictionaryNameTB.Text = null;
                TypeSystemNameTB.Text = null;

                if (EncodingCB.SelectedIndex < 0 || EncodingCB.SelectedIndex > m_encodings.Count)
                {
                    return;
                }

                // get the current encoding.
                ReferenceDescription encoding = m_encodings[EncodingCB.SelectedIndex];
                
                // find the desctiption.
                ReferenceDescription description = m_session.FindDataDescription((NodeId)encoding.NodeId);

                if (description == null)
                {
                    return;
                }
                
                TypeNameTB.Text = description.ToString();

                // find the dictionary.
                DataDictionary dictionary = m_session.FindDataDictionary((NodeId)description.NodeId);

                if (dictionary == null)
                {
                    return;
                }

                NodeId descriptionId = null;

                if (!ShowEntireDictionaryCHK.Checked)
                {
                    descriptionId = (NodeId)description.NodeId;
                }
                
                DictionaryNameTB.Text = dictionary.Name;
                TypeSystemNameTB.Text = dictionary.TypeSystemName;          
                DescriptionTB.Text    = dictionary.GetSchema(descriptionId);

                Cursor = Cursors.WaitCursor;
                
                try
                {
                    FormatDescription();
                }
                finally
                {
                    Cursor = Cursors.Default;
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
