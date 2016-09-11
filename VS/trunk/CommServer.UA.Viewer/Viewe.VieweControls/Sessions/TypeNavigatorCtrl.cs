//<summary>
//  Title   : Type navigator
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

namespace CAS.OPC.UA.Viewer.Client
{
    public partial class TypeNavigatorCtrl : UserControl
    {
        #region Constructors
        public TypeNavigatorCtrl()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Private Fields
        private Session m_session;
        private event TypeNavigatorEventHandler m_TypeSelected;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Raised when a type is selected in the control.
        /// </summary>
        public event TypeNavigatorEventHandler TypeSelected
        {
            add { m_TypeSelected += value; }
            remove { m_TypeSelected -= value; }
        }

        /// <summary>
        /// Initializes the control.
        /// </summary>
        public void Initialize(Session session, NodeId typeId)
        {
            if (session == null)
            {
                RootBTN.Visible = false;
                return;
            }

            ILocalNode root = session.NodeCache.Find(typeId) as ILocalNode;

            if (root == null)
            {
                RootBTN.Visible = false;
                return;
            }

            m_session = session;

            RootBTN.Text = Utils.Format("{0}", root.DisplayName);
            RootBTN.Visible = true;
            RootBTN.Tag = root;
        }
        #endregion

        #region Event Handlers
        private void RootBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripDropDownButton button = sender as ToolStripDropDownButton;

                if (button == null)
                {
                    return;
                }
                
                ILocalNode node = button.Tag as ILocalNode;

                if (node == null)
                {
                    return;
                }

                bool found = false;

                for (int ii = 0; ii < TypePathCTRL.Items.Count; ii++)
                {
                    if (Object.ReferenceEquals(TypePathCTRL.Items[ii].Tag, node))
                    {
                        found = true;
                        continue;
                    }

                    if (found)
                    {
                        TypePathCTRL.Items.Remove(TypePathCTRL.Items[ii]);
                    }
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void RootBTN_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                ToolStripDropDownButton button = sender as ToolStripDropDownButton;

                if (button == null)
                {
                    return;
                }

                button.DropDownItems.Clear();

                ILocalNode node = button.Tag as ILocalNode;

                if (node == null)
                {
                    return;
                }
                
                IList<IReference> subtypes = node.References.Find(
                    ReferenceTypeIds.HasSubtype,
                    false,
                    false,
                    m_session.TypeTree);

                for (int ii = 0; ii < subtypes.Count; ii++)
                {
                    ILocalNode subtype = m_session.NodeCache.Find(subtypes[ii].TargetId) as ILocalNode;

                    if (subtype == null)
                    {
                        continue;
                    }

                    string text = Utils.Format("{0}", subtype);

                    ToolStripMenuItem child = new ToolStripMenuItem(text);
                    child.Tag = subtype;
                    child.Click += new EventHandler(ChildBTN_Click);
                    button.DropDownItems.Add(child);
                }

                button.ShowDropDownArrow = (button.DropDownItems.Count == 0);

                if (m_TypeSelected != null)
                {
                    m_TypeSelected(this, new TypeNavigatorEventArgs(node));
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        void ChildBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

                if (menuItem == null)
                {
                    return;
                }
                
                ILocalNode node = menuItem.Tag as ILocalNode;

                if (node == null)
                {
                    return;
                }                

                bool found = false;

                for (int ii = 0; ii < TypePathCTRL.Items.Count; ii++)
                {
                    if (Object.ReferenceEquals(TypePathCTRL.Items[ii], menuItem.OwnerItem))
                    {
                        found = true;
                        continue;
                    }

                    if (found)
                    {
                        TypePathCTRL.Items.Remove(TypePathCTRL.Items[ii]);
                    }
                }
                
                if (!found)
                {
                    return;
                }

                string text = Utils.Format("{0}", node.DisplayName);
                
                ToolStripDropDownButton button = new ToolStripDropDownButton(text);

                button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
                button.Name = Utils.Format("Type{0}BTN", TypePathCTRL.Items.Count);
                button.Size = new System.Drawing.Size(48, 21);
                button.Text = Utils.Format("{0}", node.DisplayName);
                button.DropDownOpening += RootBTN_DropDownOpening;
                button.Click += RootBTN_Click;
                button.Tag = node;

                TypePathCTRL.Items.Add(button);

                if (m_TypeSelected != null)
                {
                    m_TypeSelected(this, new TypeNavigatorEventArgs(node));
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }

    /// <summary>
    /// Arguments provided when a type is picked in the control.
    /// </summary>
    public class TypeNavigatorEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TypeNavigatorEventArgs(ILocalNode node)
        {
            m_node = node;
        }

        /// <summary>
        /// The node that was picked.
        /// </summary>
        public ILocalNode Node
        {
            get { return m_node; }
        }

        private ILocalNode m_node;
    }

    /// <summary>
    /// Uses to receive notifications when the control raises events.
    /// </summary>
    public delegate void TypeNavigatorEventHandler(object sender, TypeNavigatorEventArgs e);
}
