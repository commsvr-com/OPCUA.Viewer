//<summary>
//  Title   : Event filter
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
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using CAS.OPC.UA.Viewer.Client.Controls;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Controls
{
    public partial class EventFilterDlg : Form
    {
        #region Constructors
        public EventFilterDlg()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Fields
        private Session m_session;
        private EventFilter m_filter;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public EventFilter ShowDialog(Session session, EventFilter filter, bool editWhereClause)
        {
            if (session == null) throw new ArgumentNullException("session");
            if (filter == null)  throw new ArgumentNullException("filter");
            
            m_session = session;
            m_filter  = filter;

            BrowseCTRL.SetView(m_session, BrowseViewType.EventTypes, null);
            SelectClauseCTRL.Initialize(session, filter.SelectClauses);
            ContentFilterCTRL.Initialize(session, filter.WhereClause);
            FilterOperandsCTRL.Initialize(session, null, -1);

            MoveBTN_Click((editWhereClause)?NextBTN:BackBTN, null);

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return m_filter;
        }
        #endregion
        
        #region Event Handlers
        private void BrowseCTRL_ItemsSelected(object sender, NodesSelectedEventArgs e)
        {
            try
            {
                foreach (ReferenceDescription reference in e.References)
                {
                    if (reference.ReferenceTypeId == ReferenceTypeIds.HasProperty || reference.IsForward)
                    {
                        SelectClauseCTRL.AddSelectClause(reference);
                    }
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ContentFilterCTRL_ItemsSelected(object sender, ListItemActionEventArgs e)
        {
            try
            {
                if (e.Items.Count > 0)
                {
                    foreach (object item in e.Items)
                    {
                        List<ContentFilterElement> elements = ContentFilterCTRL.GetElements();

                        for (int ii = 0; ii < elements.Count; ii++)
                        {
                            if (Object.ReferenceEquals(elements[ii], item))
                            {
                                FilterOperandsCTRL.Initialize(m_session, elements, ii);
                            }
                        }

                        break;
                    }
                }
                else
                {
                    FilterOperandsCTRL.Initialize(m_session, null, -1);       
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void MoveBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == NextBTN)
                {           
                    BackBTN.Visible            = true;
                    NextBTN.Visible            = false;
                    OkBTN.Visible              = true;
                    ContentFilterCTRL.Visible  = true;
                    FilterOperandsCTRL.Visible = true;
                    BrowseCTRL.Visible         = false;
                    SelectClauseCTRL.Visible   = false;
                }

                else if (sender == BackBTN)
                {           
                    BackBTN.Visible            = false;
                    NextBTN.Visible            = true;
                    OkBTN.Visible              = false;
                    ContentFilterCTRL.Visible  = false;
                    FilterOperandsCTRL.Visible = false;
                    BrowseCTRL.Visible         = true;
                    SelectClauseCTRL.Visible   = true;
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                EventFilter filter = new EventFilter();

                filter.SelectClauses.AddRange(SelectClauseCTRL.GetSelectClauses());
                filter.WhereClause = ContentFilterCTRL.GetFilter();
                
                EventFilter.Result result = filter.Validate(new FilterContext(m_session.NamespaceUris, m_session.TypeTree));

                if (ServiceResult.IsBad(result.Status))
                {
                    throw ServiceResultException.Create(StatusCodes.BadEventFilterInvalid, result.GetLongString());
                }

                m_filter = filter;

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
