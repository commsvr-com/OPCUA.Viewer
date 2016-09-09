//<summary>
//  Title   : Browse list
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

using System.Collections.Generic;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    /// <summary>
    /// Displays a list of references for a node.
    /// </summary>
    public partial class BrowseListCtrl : CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowseListCtrl"/> class.
        /// </summary>
        public BrowseListCtrl()
        {
            InitializeComponent();
			SetColumns(m_ColumnNames);
        }

        #region Private Fields
        private Session m_session;
       
		// The columns to display in the control.		
		private readonly object[][] m_ColumnNames = new object[][]
		{
			new object[] { "Type",   HorizontalAlignment.Left, null },  
			new object[] { "Target", HorizontalAlignment.Left, null }
		};
		#endregion
            
        /// <summary>
        /// Initializes the control with a set of items.
        /// </summary>
        public void Initialize(Session session, ExpandedNodeId nodeId)
        {
            ItemsLV.Items.Clear();
            m_session = session;

            if (m_session == null)
            {
                return;
            }

            ILocalNode node = m_session.NodeCache.Find(nodeId) as ILocalNode;

            if (node == null)
            {
                return;
            }

            IList<IReference> references = null;

            references = node.References.Find(ReferenceTypes.NonHierarchicalReferences, false, true, m_session.TypeTree);

            for (int ii = 0; ii < references.Count; ii++)
            {
                AddItem(references[ii]);
            }
            
            references = node.References.Find(ReferenceTypes.NonHierarchicalReferences, true, true, m_session.TypeTree);

            for (int ii = 0; ii < references.Count; ii++)
            {
                AddItem(references[ii]);
            }

            AdjustColumns();
        }

        #region Overridden Methods
        /// <see cref="CAS.OPC.UA.Viewer.Client.Controls.BaseListCtrl.UpdateItem(ListViewItem,object)" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
            IReference reference = item as IReference;

			if (reference == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}
            
            IReferenceType referenceType = m_session.NodeCache.Find(reference.ReferenceTypeId) as IReferenceType;

            if (referenceType != null)
            {
                if (reference.IsInverse)
                {
			        listItem.SubItems[0].Text = Utils.Format("{0}", referenceType.InverseName);
                }
                else
                {
			        listItem.SubItems[0].Text = Utils.Format("{0}", referenceType.DisplayName);
                }
            }
            else
            {
			    listItem.SubItems[0].Text = Utils.Format("{0}", reference.ReferenceTypeId);
            }
            
            INode target = m_session.NodeCache.Find(reference.TargetId) as INode;

            if (target != null)
            {
			    listItem.SubItems[1].Text = Utils.Format("{0}", target.DisplayName);
            }
            else
            {
			    listItem.SubItems[1].Text = Utils.Format("{0}", reference.TargetId);
            }
            
            listItem.ImageKey = GuiUtils.GetTargetIcon(m_session, NodeClass.ReferenceType, null);
			listItem.Tag = reference;
        }
        #endregion
    }
}
