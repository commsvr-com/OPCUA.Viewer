//<summary>
//  Title   : Notificatin message list
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
    partial class NotificationMessageListCtrl
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( NotificationMessageListCtrl ) );
          this.PopupMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
          this.RepublishMI = new System.Windows.Forms.ToolStripMenuItem();
          this.DeleteMI = new System.Windows.Forms.ToolStripMenuItem();
          this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
          this.ClearMI = new System.Windows.Forms.ToolStripMenuItem();
          this.PopupMenu.SuspendLayout();
          this.SuspendLayout();
          // 
          // ItemsLV
          // 
          this.ItemsLV.ContextMenuStrip = this.PopupMenu;
          this.ItemsLV.MultiSelect = false;
          // 
          // PopupMenu
          // 
          this.PopupMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.RepublishMI,
            this.DeleteMI,
            this.Separator1,
            this.ClearMI} );
          this.PopupMenu.Name = "PopupMenu";
          this.PopupMenu.Size = new System.Drawing.Size( 153, 98 );
          // 
          // RepublishMI
          // 
          this.RepublishMI.Image = ( (System.Drawing.Image)( resources.GetObject( "RepublishMI.Image" ) ) );
          this.RepublishMI.Name = "RepublishMI";
          this.RepublishMI.Size = new System.Drawing.Size( 152, 22 );
          this.RepublishMI.Text = "Republish...";
          this.RepublishMI.Click += new System.EventHandler( this.RepublishMI_Click );
          // 
          // DeleteMI
          // 
          this.DeleteMI.Image = ( (System.Drawing.Image)( resources.GetObject( "DeleteMI.Image" ) ) );
          this.DeleteMI.Name = "DeleteMI";
          this.DeleteMI.Size = new System.Drawing.Size( 152, 22 );
          this.DeleteMI.Text = "Delete";
          this.DeleteMI.Click += new System.EventHandler( this.DeleteMI_Click );
          // 
          // Separator1
          // 
          this.Separator1.Name = "Separator1";
          this.Separator1.Size = new System.Drawing.Size( 149, 6 );
          // 
          // ClearMI
          // 
          this.ClearMI.Name = "ClearMI";
          this.ClearMI.Size = new System.Drawing.Size( 152, 22 );
          this.ClearMI.Text = "Clear";
          this.ClearMI.Click += new System.EventHandler( this.ClearMI_Click );
          // 
          // NotificationMessageListCtrl
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.Name = "NotificationMessageListCtrl";
          this.Controls.SetChildIndex( this.ItemsLV, 0 );
          this.PopupMenu.ResumeLayout( false );
          this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripMenuItem ClearMI;
        private System.Windows.Forms.ToolStripMenuItem DeleteMI;
        private System.Windows.Forms.ToolStripMenuItem RepublishMI;
    }
}
