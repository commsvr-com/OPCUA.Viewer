//<summary>
//  Title   : Monitored item config
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
    partial class MonitoredItemConfigCtrl
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MonitoredItemConfigCtrl ) );
          this.PopupMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
          this.NewMI = new System.Windows.Forms.ToolStripMenuItem();
          this.EditMI = new System.Windows.Forms.ToolStripMenuItem();
          this.DeleteMI = new System.Windows.Forms.ToolStripMenuItem();
          this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
          this.SetSamplingIntervalMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SetFilterMI = new System.Windows.Forms.ToolStripMenuItem();
          this.SetMonitoringModeMI = new System.Windows.Forms.ToolStripMenuItem();
          this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
          this.MonitorMI = new System.Windows.Forms.ToolStripMenuItem();
          this.PopupMenu.SuspendLayout();
          this.SuspendLayout();
          // 
          // ItemsLV
          // 
          this.ItemsLV.ContextMenuStrip = this.PopupMenu;
          // 
          // PopupMenu
          // 
          this.PopupMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.NewMI,
            this.EditMI,
            this.DeleteMI,
            this.Separator1,
            this.SetSamplingIntervalMI,
            this.SetFilterMI,
            this.SetMonitoringModeMI,
            this.Separator2,
            this.MonitorMI} );
          this.PopupMenu.Name = "PopupMenu";
          this.PopupMenu.Size = new System.Drawing.Size( 197, 192 );
          // 
          // NewMI
          // 
          this.NewMI.Image = ( (System.Drawing.Image)( resources.GetObject( "NewMI.Image" ) ) );
          this.NewMI.Name = "NewMI";
          this.NewMI.Size = new System.Drawing.Size( 196, 22 );
          this.NewMI.Text = "New...";
          this.NewMI.Click += new System.EventHandler( this.NewMI_Click );
          // 
          // EditMI
          // 
          this.EditMI.Name = "EditMI";
          this.EditMI.Size = new System.Drawing.Size( 196, 22 );
          this.EditMI.Text = "Edit...";
          this.EditMI.Click += new System.EventHandler( this.EditMI_Click );
          // 
          // DeleteMI
          // 
          this.DeleteMI.Image = ( (System.Drawing.Image)( resources.GetObject( "DeleteMI.Image" ) ) );
          this.DeleteMI.Name = "DeleteMI";
          this.DeleteMI.Size = new System.Drawing.Size( 196, 22 );
          this.DeleteMI.Text = "Delete";
          this.DeleteMI.Click += new System.EventHandler( this.DeleteMI_Click );
          // 
          // Separator1
          // 
          this.Separator1.Name = "Separator1";
          this.Separator1.Size = new System.Drawing.Size( 193, 6 );
          // 
          // SetSamplingIntervalMI
          // 
          this.SetSamplingIntervalMI.Enabled = false;
          this.SetSamplingIntervalMI.Name = "SetSamplingIntervalMI";
          this.SetSamplingIntervalMI.Size = new System.Drawing.Size( 196, 22 );
          this.SetSamplingIntervalMI.Text = "Set Sampling Interval...";
          this.SetSamplingIntervalMI.Visible = false;
          // 
          // SetFilterMI
          // 
          this.SetFilterMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SetFilterMI.Image" ) ) );
          this.SetFilterMI.Name = "SetFilterMI";
          this.SetFilterMI.Size = new System.Drawing.Size( 196, 22 );
          this.SetFilterMI.Text = "Set Filter...";
          this.SetFilterMI.Click += new System.EventHandler( this.SetFilterMI_Click );
          // 
          // SetMonitoringModeMI
          // 
          this.SetMonitoringModeMI.Image = ( (System.Drawing.Image)( resources.GetObject( "SetMonitoringModeMI.Image" ) ) );
          this.SetMonitoringModeMI.Name = "SetMonitoringModeMI";
          this.SetMonitoringModeMI.Size = new System.Drawing.Size( 196, 22 );
          this.SetMonitoringModeMI.Text = "Set Monitoring Mode...";
          this.SetMonitoringModeMI.Click += new System.EventHandler( this.SetMonitoringModeMI_Click );
          // 
          // Separator2
          // 
          this.Separator2.Name = "Separator2";
          this.Separator2.Size = new System.Drawing.Size( 193, 6 );
          // 
          // MonitorMI
          // 
          this.MonitorMI.Image = ( (System.Drawing.Image)( resources.GetObject( "MonitorMI.Image" ) ) );
          this.MonitorMI.Name = "MonitorMI";
          this.MonitorMI.Size = new System.Drawing.Size( 196, 22 );
          this.MonitorMI.Text = "Monitor...";
          this.MonitorMI.Click += new System.EventHandler( this.MonitorMI_Click );
          // 
          // MonitoredItemConfigCtrl
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.Name = "MonitoredItemConfigCtrl";
          this.Controls.SetChildIndex( this.ItemsLV, 0 );
          this.PopupMenu.ResumeLayout( false );
          this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        private System.Windows.Forms.ToolStripMenuItem NewMI;
        private System.Windows.Forms.ToolStripMenuItem EditMI;
        private System.Windows.Forms.ToolStripMenuItem SetMonitoringModeMI;
        private System.Windows.Forms.ToolStripMenuItem DeleteMI;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripMenuItem SetFilterMI;
        private System.Windows.Forms.ToolStripMenuItem SetSamplingIntervalMI;
        private System.Windows.Forms.ToolStripSeparator Separator2;
        private System.Windows.Forms.ToolStripMenuItem MonitorMI;
    }
}
