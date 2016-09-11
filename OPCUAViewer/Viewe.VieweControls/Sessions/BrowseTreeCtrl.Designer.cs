//<summary>
//  Title   : Browse tree
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
    partial class BrowseTreeCtrl
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( BrowseTreeCtrl ) );
          this.PopupMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
          this.BrowseOptionsMI = new System.Windows.Forms.ToolStripMenuItem();
          this.ShowReferencesMI = new System.Windows.Forms.ToolStripMenuItem();
          this.Separator01 = new System.Windows.Forms.ToolStripSeparator();
          this.BrowseMI = new System.Windows.Forms.ToolStripMenuItem();
          this.ViewAttributesMI = new System.Windows.Forms.ToolStripMenuItem();
          this.ReadMI = new System.Windows.Forms.ToolStripMenuItem();
          this.HistoryReadMI = new System.Windows.Forms.ToolStripMenuItem();
          this.WriteMI = new System.Windows.Forms.ToolStripMenuItem();
          this.HistoryUpdateMI = new System.Windows.Forms.ToolStripMenuItem();
          this.EncodingsMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SubscribeMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SubscribeNewMI = new System.Windows.Forms.ToolStripMenuItem();
          this.CallMI = new System.Windows.Forms.ToolStripMenuItem();
          this.Separator02 = new System.Windows.Forms.ToolStripSeparator();
          this.SelectMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SelectItemMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SelectChildrenMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SelectSeparatorMI = new System.Windows.Forms.ToolStripSeparator();
          this.BrowseRefreshMI = new System.Windows.Forms.ToolStripMenuItem();
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
            this.BrowseOptionsMI,
            this.ShowReferencesMI,
            this.Separator01,
            this.BrowseMI,
            this.ViewAttributesMI,
            this.ReadMI,
            this.HistoryReadMI,
            this.WriteMI,
            this.HistoryUpdateMI,
            this.EncodingsMI,
            this.SubscribeMI,
            this.CallMI,
            this.Separator02,
            this.SelectMI,
            this.SelectSeparatorMI,
            this.BrowseRefreshMI} );
          this.PopupMenu.Name = "PopupMenu";
          this.PopupMenu.Size = new System.Drawing.Size( 167, 330 );
          // 
          // BrowseOptionsMI
          // 
          this.BrowseOptionsMI.Enabled = false;
          this.BrowseOptionsMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseOptionsMI.Image" ) ) );
          this.BrowseOptionsMI.Name = "BrowseOptionsMI";
          this.BrowseOptionsMI.Size = new System.Drawing.Size( 166, 22 );
          this.BrowseOptionsMI.Text = "Browse Options...";
          this.BrowseOptionsMI.Click += new System.EventHandler( this.BrowseOptionsMI_Click );
          // 
          // ShowReferencesMI
          // 
          this.ShowReferencesMI.Checked = true;
          this.ShowReferencesMI.CheckOnClick = true;
          this.ShowReferencesMI.CheckState = System.Windows.Forms.CheckState.Checked;
          this.ShowReferencesMI.Enabled = false;
          this.ShowReferencesMI.Name = "ShowReferencesMI";
          this.ShowReferencesMI.Size = new System.Drawing.Size( 166, 22 );
          this.ShowReferencesMI.Text = "Show References";
          this.ShowReferencesMI.CheckedChanged += new System.EventHandler( this.ShowReferencesMI_CheckedChanged );
          // 
          // Separator01
          // 
          this.Separator01.Name = "Separator01";
          this.Separator01.Size = new System.Drawing.Size( 163, 6 );
          // 
          // BrowseMI
          // 
          this.BrowseMI.Enabled = false;
          this.BrowseMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseMI.Image" ) ) );
          this.BrowseMI.Name = "BrowseMI";
          this.BrowseMI.Size = new System.Drawing.Size( 166, 22 );
          this.BrowseMI.Text = "Browse...";
          this.BrowseMI.Click += new System.EventHandler( this.BrowseMI_Click );
          // 
          // ViewAttributesMI
          // 
          this.ViewAttributesMI.Enabled = false;
          this.ViewAttributesMI.Image = ( (System.Drawing.Image)( resources.GetObject( "ViewAttributesMI.Image" ) ) );
          this.ViewAttributesMI.Name = "ViewAttributesMI";
          this.ViewAttributesMI.Size = new System.Drawing.Size( 166, 22 );
          this.ViewAttributesMI.Text = "View Attributes...";
          this.ViewAttributesMI.Click += new System.EventHandler( this.ViewAttributesMI_Click );
          // 
          // ReadMI
          // 
          this.ReadMI.Enabled = false;
          this.ReadMI.Image = ( (System.Drawing.Image)( resources.GetObject( "ReadMI.Image" ) ) );
          this.ReadMI.Name = "ReadMI";
          this.ReadMI.Size = new System.Drawing.Size( 166, 22 );
          this.ReadMI.Text = "Read..";
          this.ReadMI.Click += new System.EventHandler( this.ReadMI_Click );
          // 
          // HistoryReadMI
          // 
          this.HistoryReadMI.Enabled = false;
          this.HistoryReadMI.Image = ( (System.Drawing.Image)( resources.GetObject( "HistoryReadMI.Image" ) ) );
          this.HistoryReadMI.Name = "HistoryReadMI";
          this.HistoryReadMI.Size = new System.Drawing.Size( 166, 22 );
          this.HistoryReadMI.Text = "History Read...";
          this.HistoryReadMI.Click += new System.EventHandler( this.HistoryReadMI_Click );
          // 
          // WriteMI
          // 
          this.WriteMI.Enabled = false;
          this.WriteMI.Image = ( (System.Drawing.Image)( resources.GetObject( "WriteMI.Image" ) ) );
          this.WriteMI.Name = "WriteMI";
          this.WriteMI.Size = new System.Drawing.Size( 166, 22 );
          this.WriteMI.Text = "Write...";
          this.WriteMI.Click += new System.EventHandler( this.WriteMI_Click );
          // 
          // HistoryUpdateMI
          // 
          this.HistoryUpdateMI.Enabled = false;
          this.HistoryUpdateMI.Image = ( (System.Drawing.Image)( resources.GetObject( "HistoryUpdateMI.Image" ) ) );
          this.HistoryUpdateMI.Name = "HistoryUpdateMI";
          this.HistoryUpdateMI.Size = new System.Drawing.Size( 166, 22 );
          this.HistoryUpdateMI.Text = "History Update...";
          // 
          // EncodingsMI
          // 
          this.EncodingsMI.Enabled = false;
          this.EncodingsMI.Image = ( (System.Drawing.Image)( resources.GetObject( "EncodingsMI.Image" ) ) );
          this.EncodingsMI.Name = "EncodingsMI";
          this.EncodingsMI.Size = new System.Drawing.Size( 166, 22 );
          this.EncodingsMI.Text = "View Encodings...";
          this.EncodingsMI.Click += new System.EventHandler( this.EncodingsMI_Click );
          // 
          // SubscribeMI
          // 
          this.SubscribeMI.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.SubscribeNewMI} );
          this.SubscribeMI.Enabled = false;
          this.SubscribeMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SubscribeMI.Image" ) ) );
          this.SubscribeMI.Name = "SubscribeMI";
          this.SubscribeMI.Size = new System.Drawing.Size( 166, 22 );
          this.SubscribeMI.Text = "Subscribe";
          // 
          // SubscribeNewMI
          // 
          this.SubscribeNewMI.Enabled = false;
          this.SubscribeNewMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SubscribeNewMI.Image" ) ) );
          this.SubscribeNewMI.Name = "SubscribeNewMI";
          this.SubscribeNewMI.Size = new System.Drawing.Size( 107, 22 );
          this.SubscribeNewMI.Text = "New...";
          this.SubscribeNewMI.Click += new System.EventHandler( this.SubscribeNewMI_Click );
          // 
          // CallMI
          // 
          this.CallMI.Enabled = false;
          this.CallMI.Image = ( (System.Drawing.Image)( resources.GetObject( "CallMI.Image" ) ) );
          this.CallMI.Name = "CallMI";
          this.CallMI.Size = new System.Drawing.Size( 166, 22 );
          this.CallMI.Text = "Call...";
          this.CallMI.Click += new System.EventHandler( this.CallMI_Click );
          // 
          // Separator02
          // 
          this.Separator02.Name = "Separator02";
          this.Separator02.Size = new System.Drawing.Size( 163, 6 );
          // 
          // SelectMI
          // 
          this.SelectMI.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.SelectItemMI,
            this.SelectChildrenMI} );
          this.SelectMI.Enabled = false;
          this.SelectMI.Name = "SelectMI";
          this.SelectMI.Size = new System.Drawing.Size( 166, 22 );
          this.SelectMI.Text = "Select";
          // 
          // SelectItemMI
          // 
          this.SelectItemMI.Enabled = false;
          this.SelectItemMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SelectItemMI.Image" ) ) );
          this.SelectItemMI.Name = "SelectItemMI";
          this.SelectItemMI.Size = new System.Drawing.Size( 153, 22 );
          this.SelectItemMI.Text = "Select Item";
          this.SelectItemMI.Click += new System.EventHandler( this.SelectItemMI_Click );
          // 
          // SelectChildrenMI
          // 
          this.SelectChildrenMI.Enabled = false;
          this.SelectChildrenMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SelectChildrenMI.Image" ) ) );
          this.SelectChildrenMI.Name = "SelectChildrenMI";
          this.SelectChildrenMI.Size = new System.Drawing.Size( 153, 22 );
          this.SelectChildrenMI.Text = "Select Children";
          this.SelectChildrenMI.Click += new System.EventHandler( this.SelectChildrenMI_Click );
          // 
          // SelectSeparatorMI
          // 
          this.SelectSeparatorMI.Name = "SelectSeparatorMI";
          this.SelectSeparatorMI.Size = new System.Drawing.Size( 163, 6 );
          // 
          // BrowseRefreshMI
          // 
          this.BrowseRefreshMI.Enabled = false;
          this.BrowseRefreshMI.Image = ( (System.Drawing.Image)( resources.GetObject( "BrowseRefreshMI.Image" ) ) );
          this.BrowseRefreshMI.Name = "BrowseRefreshMI";
          this.BrowseRefreshMI.Size = new System.Drawing.Size( 166, 22 );
          this.BrowseRefreshMI.Text = "Refresh";
          this.BrowseRefreshMI.Click += new System.EventHandler( this.BrowseRefreshMI_Click );
          // 
          // BrowseTreeCtrl
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.Name = "BrowseTreeCtrl";
          this.Controls.SetChildIndex( this.NodesTV, 0 );
          this.PopupMenu.ResumeLayout( false );
          this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        internal System.Windows.Forms.ToolStripMenuItem BrowseOptionsMI;
        private System.Windows.Forms.ToolStripSeparator Separator02;
        private System.Windows.Forms.ToolStripMenuItem BrowseRefreshMI;
        internal System.Windows.Forms.ToolStripMenuItem SelectMI;
        internal System.Windows.Forms.ToolStripMenuItem ShowReferencesMI;
        internal System.Windows.Forms.ToolStripMenuItem ViewAttributesMI;
        private System.Windows.Forms.ToolStripSeparator Separator01;
        private System.Windows.Forms.ToolStripSeparator SelectSeparatorMI;
        internal System.Windows.Forms.ToolStripMenuItem CallMI;
        internal System.Windows.Forms.ToolStripMenuItem SubscribeMI;
        internal System.Windows.Forms.ToolStripMenuItem SelectItemMI;
        internal System.Windows.Forms.ToolStripMenuItem SelectChildrenMI;
        internal System.Windows.Forms.ToolStripMenuItem WriteMI;
        internal System.Windows.Forms.ToolStripMenuItem ReadMI;
        internal System.Windows.Forms.ToolStripMenuItem SubscribeNewMI;
        internal System.Windows.Forms.ToolStripMenuItem EncodingsMI;
        internal System.Windows.Forms.ToolStripMenuItem HistoryReadMI;
        internal System.Windows.Forms.ToolStripMenuItem HistoryUpdateMI;
        internal System.Windows.Forms.ToolStripMenuItem BrowseMI;
    }
}
