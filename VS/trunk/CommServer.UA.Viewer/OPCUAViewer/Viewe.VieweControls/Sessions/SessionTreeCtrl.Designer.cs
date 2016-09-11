//<summary>
//  Title   : Session tree
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

namespace CAS.OPC.UA.Viewer.Controls
{
    partial class SessionTreeCtrl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.components = new System.ComponentModel.Container();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SessionTreeCtrl ) );
          this.PopupMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
          this.NewWindowMI = new System.Windows.Forms.ToolStripMenuItem();
          this.NewSessionMI = new System.Windows.Forms.ToolStripMenuItem();
          this.DeleteMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SessionSaveMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SessionLoadMI = new System.Windows.Forms.ToolStripMenuItem();
          this.Separator01 = new System.Windows.Forms.ToolStripSeparator();
          this.BrowseMI = new System.Windows.Forms.ToolStripMenuItem();
          this.BrowseAllMI = new System.Windows.Forms.ToolStripMenuItem();
          this.BrowseObjectsMI = new System.Windows.Forms.ToolStripMenuItem();
          this.BrowseServerViewsMI = new System.Windows.Forms.ToolStripMenuItem();
          this.BrowseObjectTypesMI = new System.Windows.Forms.ToolStripMenuItem();
          this.BrowseVariableTypesMI = new System.Windows.Forms.ToolStripMenuItem();
          this.BrowseDataTypesMI = new System.Windows.Forms.ToolStripMenuItem();
          this.BrowseReferenceTypesMI = new System.Windows.Forms.ToolStripMenuItem();
          this.BrowseEventTypesMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SubscriptionMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SubscriptionCreateMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SubscriptionMonitorMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SubscriptionEnabledPublishingMI = new System.Windows.Forms.ToolStripMenuItem();
          this.ReadMI = new System.Windows.Forms.ToolStripMenuItem();
          this.WriteMI = new System.Windows.Forms.ToolStripMenuItem();
          this.PopupMenu.SuspendLayout();
          this.SuspendLayout();
          // 
          // NodesTV
          // 
          this.NodesTV.ContextMenuStrip = this.PopupMenu;
          this.NodesTV.LineColor = System.Drawing.Color.Black;
          // 
          // PopupMenu
          // 
          this.PopupMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.NewWindowMI,
            this.NewSessionMI,
            this.DeleteMI,
            this.SessionSaveMI,
            this.SessionLoadMI,
            this.Separator01,
            this.BrowseMI,
            this.SubscriptionMI,
            this.ReadMI,
            this.WriteMI} );
          this.PopupMenu.Name = "PopupMenu";
          this.PopupMenu.Size = new System.Drawing.Size( 184, 230 );
          // 
          // NewWindowMI
          // 
          this.NewWindowMI.Image = ( (System.Drawing.Image)( resources.GetObject( "NewWindowMI.Image" ) ) );
          this.NewWindowMI.Name = "NewWindowMI";
          this.NewWindowMI.Size = new System.Drawing.Size( 183, 22 );
          this.NewWindowMI.Text = "New Window...";
          this.NewWindowMI.Click += new System.EventHandler( this.NewWindowMI_Click );
          // 
          // NewSessionMI
          // 
          this.NewSessionMI.Enabled = false;
          this.NewSessionMI.Image = ( (System.Drawing.Image)( resources.GetObject( "NewSessionMI.Image" ) ) );
          this.NewSessionMI.Name = "NewSessionMI";
          this.NewSessionMI.Size = new System.Drawing.Size( 183, 22 );
          this.NewSessionMI.Text = "New Session...";
          this.NewSessionMI.Click += new System.EventHandler( this.NewSessionMI_Click );
          // 
          // DeleteMI
          // 
          this.DeleteMI.Enabled = false;
          this.DeleteMI.Image = ( (System.Drawing.Image)( resources.GetObject( "DeleteMI.Image" ) ) );
          this.DeleteMI.Name = "DeleteMI";
          this.DeleteMI.Size = new System.Drawing.Size( 183, 22 );
          this.DeleteMI.Text = "Delete session";
          this.DeleteMI.Click += new System.EventHandler( this.DeleteMI_Click );
          // 
          // SessionSaveMI
          // 
          this.SessionSaveMI.Enabled = false;
          this.SessionSaveMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SessionSaveMI.Image" ) ) );
          this.SessionSaveMI.Name = "SessionSaveMI";
          this.SessionSaveMI.Size = new System.Drawing.Size( 183, 22 );
          this.SessionSaveMI.Text = "Save Subscriptions...";
          this.SessionSaveMI.Click += new System.EventHandler( this.SessionSaveMI_Click );
          // 
          // SessionLoadMI
          // 
          this.SessionLoadMI.Enabled = false;
          this.SessionLoadMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SessionLoadMI.Image" ) ) );
          this.SessionLoadMI.Name = "SessionLoadMI";
          this.SessionLoadMI.Size = new System.Drawing.Size( 183, 22 );
          this.SessionLoadMI.Text = "Load Subscriptions...";
          this.SessionLoadMI.Click += new System.EventHandler( this.SessionLoadMI_Click );
          // 
          // Separator01
          // 
          this.Separator01.Name = "Separator01";
          this.Separator01.Size = new System.Drawing.Size( 180, 6 );
          // 
          // BrowseMI
          // 
          this.BrowseMI.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.BrowseAllMI,
            this.BrowseObjectsMI,
            this.BrowseServerViewsMI,
            this.BrowseObjectTypesMI,
            this.BrowseVariableTypesMI,
            this.BrowseDataTypesMI,
            this.BrowseReferenceTypesMI,
            this.BrowseEventTypesMI} );
          this.BrowseMI.Enabled = false;
          this.BrowseMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseMI.Image" ) ) );
          this.BrowseMI.Name = "BrowseMI";
          this.BrowseMI.Size = new System.Drawing.Size( 183, 22 );
          this.BrowseMI.Text = "Browse";
          // 
          // BrowseAllMI
          // 
          this.BrowseAllMI.Enabled = false;
          this.BrowseAllMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseAllMI.Image" ) ) );
          this.BrowseAllMI.Name = "BrowseAllMI";
          this.BrowseAllMI.Size = new System.Drawing.Size( 178, 22 );
          this.BrowseAllMI.Text = "All";
          this.BrowseAllMI.Click += new System.EventHandler( this.BrowseAllMI_Click );
          // 
          // BrowseObjectsMI
          // 
          this.BrowseObjectsMI.Enabled = false;
          this.BrowseObjectsMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseObjectsMI.Image" ) ) );
          this.BrowseObjectsMI.Name = "BrowseObjectsMI";
          this.BrowseObjectsMI.Size = new System.Drawing.Size( 178, 22 );
          this.BrowseObjectsMI.Text = "Objects";
          this.BrowseObjectsMI.Click += new System.EventHandler( this.BrowseObjectsMI_Click );
          // 
          // BrowseServerViewsMI
          // 
          this.BrowseServerViewsMI.Enabled = false;
          this.BrowseServerViewsMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseServerViewsMI.Image" ) ) );
          this.BrowseServerViewsMI.Name = "BrowseServerViewsMI";
          this.BrowseServerViewsMI.Size = new System.Drawing.Size( 178, 22 );
          this.BrowseServerViewsMI.Text = "Server Defined View";
          this.BrowseServerViewsMI.DropDownOpening += new System.EventHandler( this.BrowseServerViewsMI_DropDownOpening );
          // 
          // BrowseObjectTypesMI
          // 
          this.BrowseObjectTypesMI.Enabled = false;
          this.BrowseObjectTypesMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseObjectTypesMI.Image" ) ) );
          this.BrowseObjectTypesMI.Name = "BrowseObjectTypesMI";
          this.BrowseObjectTypesMI.Size = new System.Drawing.Size( 178, 22 );
          this.BrowseObjectTypesMI.Text = "Object Types...";
          this.BrowseObjectTypesMI.Click += new System.EventHandler( this.BrowseObjectTypesMI_Click );
          // 
          // BrowseVariableTypesMI
          // 
          this.BrowseVariableTypesMI.Enabled = false;
          this.BrowseVariableTypesMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseVariableTypesMI.Image" ) ) );
          this.BrowseVariableTypesMI.Name = "BrowseVariableTypesMI";
          this.BrowseVariableTypesMI.Size = new System.Drawing.Size( 178, 22 );
          this.BrowseVariableTypesMI.Text = "Variable Types...";
          this.BrowseVariableTypesMI.Click += new System.EventHandler( this.BrowseVariableTypesMI_Click );
          // 
          // BrowseDataTypesMI
          // 
          this.BrowseDataTypesMI.Enabled = false;
          this.BrowseDataTypesMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseDataTypesMI.Image" ) ) );
          this.BrowseDataTypesMI.Name = "BrowseDataTypesMI";
          this.BrowseDataTypesMI.Size = new System.Drawing.Size( 178, 22 );
          this.BrowseDataTypesMI.Text = "DataTypes...";
          this.BrowseDataTypesMI.Click += new System.EventHandler( this.BrowseDataTypesMI_Click );
          // 
          // BrowseReferenceTypesMI
          // 
          this.BrowseReferenceTypesMI.Enabled = false;
          this.BrowseReferenceTypesMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseReferenceTypesMI.Image" ) ) );
          this.BrowseReferenceTypesMI.Name = "BrowseReferenceTypesMI";
          this.BrowseReferenceTypesMI.Size = new System.Drawing.Size( 178, 22 );
          this.BrowseReferenceTypesMI.Text = "ReferenceTypes...";
          this.BrowseReferenceTypesMI.Click += new System.EventHandler( this.BrowseReferenceTypesMI_Click );
          // 
          // BrowseEventTypesMI
          // 
          this.BrowseEventTypesMI.Enabled = false;
          this.BrowseEventTypesMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseEventTypesMI.Image" ) ) );
          this.BrowseEventTypesMI.Name = "BrowseEventTypesMI";
          this.BrowseEventTypesMI.Size = new System.Drawing.Size( 178, 22 );
          this.BrowseEventTypesMI.Text = "Event Types...";
          this.BrowseEventTypesMI.Click += new System.EventHandler( this.BrowseEventTypesMI_Click );
          // 
          // SubscriptionMI
          // 
          this.SubscriptionMI.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.SubscriptionCreateMI,
            this.SubscriptionMonitorMI,
            this.SubscriptionEnabledPublishingMI} );
          this.SubscriptionMI.Enabled = false;
          this.SubscriptionMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SubscriptionMI.Image" ) ) );
          this.SubscriptionMI.Name = "SubscriptionMI";
          this.SubscriptionMI.Size = new System.Drawing.Size( 183, 22 );
          this.SubscriptionMI.Text = "Subscription";
          // 
          // SubscriptionCreateMI
          // 
          this.SubscriptionCreateMI.Enabled = false;
          this.SubscriptionCreateMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SubscriptionCreateMI.Image" ) ) );
          this.SubscriptionCreateMI.Name = "SubscriptionCreateMI";
          this.SubscriptionCreateMI.Size = new System.Drawing.Size( 168, 22 );
          this.SubscriptionCreateMI.Text = "New...";
          this.SubscriptionCreateMI.Click += new System.EventHandler( this.SubscriptionCreateMI_Click );
          // 
          // SubscriptionMonitorMI
          // 
          this.SubscriptionMonitorMI.Enabled = false;
          this.SubscriptionMonitorMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SubscriptionMonitorMI.Image" ) ) );
          this.SubscriptionMonitorMI.Name = "SubscriptionMonitorMI";
          this.SubscriptionMonitorMI.Size = new System.Drawing.Size( 168, 22 );
          this.SubscriptionMonitorMI.Text = "Monitor...";
          this.SubscriptionMonitorMI.Click += new System.EventHandler( this.SubscriptionMonitorMI_Click );
          // 
          // SubscriptionEnabledPublishingMI
          // 
          this.SubscriptionEnabledPublishingMI.CheckOnClick = true;
          this.SubscriptionEnabledPublishingMI.Enabled = false;
          this.SubscriptionEnabledPublishingMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SubscriptionEnabledPublishingMI.Image" ) ) );
          this.SubscriptionEnabledPublishingMI.Name = "SubscriptionEnabledPublishingMI";
          this.SubscriptionEnabledPublishingMI.Size = new System.Drawing.Size( 168, 22 );
          this.SubscriptionEnabledPublishingMI.Text = "Enable Publishing";
          this.SubscriptionEnabledPublishingMI.Click += new System.EventHandler( this.SubscriptionEnabledPublishingMI_Click );
          // 
          // ReadMI
          // 
          this.ReadMI.Enabled = false;
          this.ReadMI.Image = ( (System.Drawing.Image)( resources.GetObject( "ReadMI.Image" ) ) );
          this.ReadMI.Name = "ReadMI";
          this.ReadMI.Size = new System.Drawing.Size( 183, 22 );
          this.ReadMI.Text = "Read...";
          this.ReadMI.Click += new System.EventHandler( this.ReadMI_Click );
          // 
          // WriteMI
          // 
          this.WriteMI.Enabled = false;
          this.WriteMI.Image = ( (System.Drawing.Image)( resources.GetObject( "WriteMI.Image" ) ) );
          this.WriteMI.Name = "WriteMI";
          this.WriteMI.Size = new System.Drawing.Size( 183, 22 );
          this.WriteMI.Text = "Write...";
          this.WriteMI.Click += new System.EventHandler( this.WriteMI_Click );
          // 
          // SessionTreeCtrl
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.Name = "SessionTreeCtrl";
          this.Controls.SetChildIndex( this.NodesTV, 0 );
          this.PopupMenu.ResumeLayout( false );
          this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        private System.Windows.Forms.ToolStripSeparator Separator01;
        internal System.Windows.Forms.ToolStripMenuItem NewSessionMI;
        internal System.Windows.Forms.ToolStripMenuItem DeleteMI;
        internal System.Windows.Forms.ToolStripMenuItem BrowseMI;
        internal System.Windows.Forms.ToolStripMenuItem BrowseAllMI;
        internal System.Windows.Forms.ToolStripMenuItem BrowseObjectsMI;
        internal System.Windows.Forms.ToolStripMenuItem BrowseServerViewsMI;
        internal System.Windows.Forms.ToolStripMenuItem SubscriptionMI;
        internal System.Windows.Forms.ToolStripMenuItem SubscriptionCreateMI;
        internal System.Windows.Forms.ToolStripMenuItem SubscriptionEnabledPublishingMI;
        internal System.Windows.Forms.ToolStripMenuItem BrowseEventTypesMI;
        internal System.Windows.Forms.ToolStripMenuItem ReadMI;
        internal System.Windows.Forms.ToolStripMenuItem WriteMI;
        internal System.Windows.Forms.ToolStripMenuItem SubscriptionMonitorMI;
        internal System.Windows.Forms.ToolStripMenuItem SessionSaveMI;
        internal System.Windows.Forms.ToolStripMenuItem SessionLoadMI;
        private System.Windows.Forms.ToolStripMenuItem NewWindowMI;
        internal System.Windows.Forms.ToolStripMenuItem BrowseObjectTypesMI;
        internal System.Windows.Forms.ToolStripMenuItem BrowseVariableTypesMI;
        internal System.Windows.Forms.ToolStripMenuItem BrowseDataTypesMI;
        internal System.Windows.Forms.ToolStripMenuItem BrowseReferenceTypesMI;
    }
}
