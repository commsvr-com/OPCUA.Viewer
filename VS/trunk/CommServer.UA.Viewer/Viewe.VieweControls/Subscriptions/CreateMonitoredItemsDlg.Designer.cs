//<summary>
//  Title   : Create monitored items
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
    partial class CreateMonitoredItemsDlg
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( CreateMonitoredItemsDlg ) );
          this.ButtonsPN = new System.Windows.Forms.Panel();
          this.CancelBTN = new System.Windows.Forms.Button();
          this.ApplyBTN = new System.Windows.Forms.Button();
          this.SplitterPN = new System.Windows.Forms.SplitContainer();
          this.BrowseCTRL = new CAS.OPC.UA.Viewer.Controls.BrowseTreeCtrl();
          this.MonitoredItemsCTRL = new CAS.OPC.UA.Viewer.Controls.MonitoredItemConfigCtrl();
          this.MainPN = new System.Windows.Forms.Panel();
          this.ButtonsPN.SuspendLayout();
          this.SplitterPN.Panel1.SuspendLayout();
          this.SplitterPN.Panel2.SuspendLayout();
          this.SplitterPN.SuspendLayout();
          this.MainPN.SuspendLayout();
          this.SuspendLayout();
          // 
          // ButtonsPN
          // 
          this.ButtonsPN.Controls.Add( this.CancelBTN );
          this.ButtonsPN.Controls.Add( this.ApplyBTN );
          this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.ButtonsPN.Location = new System.Drawing.Point( 0, 395 );
          this.ButtonsPN.Name = "ButtonsPN";
          this.ButtonsPN.Size = new System.Drawing.Size( 793, 31 );
          this.ButtonsPN.TabIndex = 2;
          // 
          // CancelBTN
          // 
          this.CancelBTN.Anchor = System.Windows.Forms.AnchorStyles.Right;
          this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.CancelBTN.Location = new System.Drawing.Point( 714, 4 );
          this.CancelBTN.Name = "CancelBTN";
          this.CancelBTN.Size = new System.Drawing.Size( 75, 23 );
          this.CancelBTN.TabIndex = 1;
          this.CancelBTN.Text = "Close";
          this.CancelBTN.UseVisualStyleBackColor = true;
          this.CancelBTN.Click += new System.EventHandler( this.CancelBTN_Click );
          // 
          // ApplyBTN
          // 
          this.ApplyBTN.Anchor = System.Windows.Forms.AnchorStyles.Right;
          this.ApplyBTN.Location = new System.Drawing.Point( 633, 4 );
          this.ApplyBTN.Name = "ApplyBTN";
          this.ApplyBTN.Size = new System.Drawing.Size( 75, 23 );
          this.ApplyBTN.TabIndex = 4;
          this.ApplyBTN.Text = "Apply";
          this.ApplyBTN.UseVisualStyleBackColor = true;
          this.ApplyBTN.Click += new System.EventHandler( this.ApplyBTN_Click );
          // 
          // SplitterPN
          // 
          this.SplitterPN.Dock = System.Windows.Forms.DockStyle.Fill;
          this.SplitterPN.Location = new System.Drawing.Point( 3, 3 );
          this.SplitterPN.Name = "SplitterPN";
          // 
          // SplitterPN.Panel1
          // 
          this.SplitterPN.Panel1.Controls.Add( this.BrowseCTRL );
          // 
          // SplitterPN.Panel2
          // 
          this.SplitterPN.Panel2.Controls.Add( this.MonitoredItemsCTRL );
          this.SplitterPN.Size = new System.Drawing.Size( 787, 392 );
          this.SplitterPN.SplitterDistance = 276;
          this.SplitterPN.TabIndex = 3;
          // 
          // BrowseCTRL
          // 
          this.BrowseCTRL.AllowDrop = true;
          this.BrowseCTRL.AttributesCtrl = null;
          this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.BrowseCTRL.EnableDragging = true;
          this.BrowseCTRL.Location = new System.Drawing.Point( 0, 0 );
          this.BrowseCTRL.Name = "BrowseCTRL";
          this.BrowseCTRL.SessionTreeCtrl = null;
          this.BrowseCTRL.Size = new System.Drawing.Size( 276, 392 );
          this.BrowseCTRL.TabIndex = 1;
          this.BrowseCTRL.ItemsSelected += new CAS.OPC.UA.Viewer.Controls.NodesSelectedEventHandler( this.BrowseCTRL_ItemsSelected );
          // 
          // MonitoredItemsCTRL
          // 
          this.MonitoredItemsCTRL.AllowDrop = true;
          this.MonitoredItemsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MonitoredItemsCTRL.EnableDragging = true;
          this.MonitoredItemsCTRL.Instructions = null;
          this.MonitoredItemsCTRL.Location = new System.Drawing.Point( 0, 0 );
          this.MonitoredItemsCTRL.Name = "MonitoredItemsCTRL";
          this.MonitoredItemsCTRL.Size = new System.Drawing.Size( 507, 392 );
          this.MonitoredItemsCTRL.TabIndex = 1;
          // 
          // MainPN
          // 
          this.MainPN.Controls.Add( this.SplitterPN );
          this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MainPN.Location = new System.Drawing.Point( 0, 0 );
          this.MainPN.Name = "MainPN";
          this.MainPN.Padding = new System.Windows.Forms.Padding( 3, 3, 3, 0 );
          this.MainPN.Size = new System.Drawing.Size( 793, 395 );
          this.MainPN.TabIndex = 4;
          // 
          // CreateMonitoredItemsDlg
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 793, 426 );
          this.Controls.Add( this.MainPN );
          this.Controls.Add( this.ButtonsPN );
          this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
          this.Name = "CreateMonitoredItemsDlg";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Create Monitored Items";
          this.ButtonsPN.ResumeLayout( false );
          this.SplitterPN.Panel1.ResumeLayout( false );
          this.SplitterPN.Panel2.ResumeLayout( false );
          this.SplitterPN.ResumeLayout( false );
          this.MainPN.ResumeLayout( false );
          this.ResumeLayout( false );

        }

        #endregion

        private MonitoredItemConfigCtrl MonitoredItemsCTRL;
        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.SplitContainer SplitterPN;
        private BrowseTreeCtrl BrowseCTRL;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.Button ApplyBTN;
    }
}
