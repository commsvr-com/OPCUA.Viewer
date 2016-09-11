//<summary>
//  Title   : Select node
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
    partial class SelectNodesDlg
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SelectNodesDlg ) );
          this.ButtonsPN = new System.Windows.Forms.Panel();
          this.OkBTN = new System.Windows.Forms.Button();
          this.CancelBTN = new System.Windows.Forms.Button();
          this.BrowsePanel = new System.Windows.Forms.SplitContainer();
          this.MainPN = new System.Windows.Forms.SplitContainer();
          this.BrowseCTRL = new CAS.OPC.UA.Viewer.Controls.BrowseTreeCtrl();
          this.AttributesCTRL = new CAS.OPC.UA.Viewer.Controls.AttributeListCtrl();
          this.NodeListCTRL = new CAS.OPC.UA.Viewer.Controls.NodeListCtrl();
          this.ButtonsPN.SuspendLayout();
          this.BrowsePanel.Panel1.SuspendLayout();
          this.BrowsePanel.Panel2.SuspendLayout();
          this.BrowsePanel.SuspendLayout();
          this.MainPN.Panel1.SuspendLayout();
          this.MainPN.Panel2.SuspendLayout();
          this.MainPN.SuspendLayout();
          this.SuspendLayout();
          // 
          // ButtonsPN
          // 
          this.ButtonsPN.Controls.Add( this.OkBTN );
          this.ButtonsPN.Controls.Add( this.CancelBTN );
          this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.ButtonsPN.Location = new System.Drawing.Point( 0, 435 );
          this.ButtonsPN.Name = "ButtonsPN";
          this.ButtonsPN.Size = new System.Drawing.Size( 792, 31 );
          this.ButtonsPN.TabIndex = 0;
          // 
          // OkBTN
          // 
          this.OkBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
          this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.OkBTN.Location = new System.Drawing.Point( 4, 4 );
          this.OkBTN.Name = "OkBTN";
          this.OkBTN.Size = new System.Drawing.Size( 75, 23 );
          this.OkBTN.TabIndex = 0;
          this.OkBTN.Text = "OK";
          this.OkBTN.UseVisualStyleBackColor = true;
          // 
          // CancelBTN
          // 
          this.CancelBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.CancelBTN.Location = new System.Drawing.Point( 713, 4 );
          this.CancelBTN.Name = "CancelBTN";
          this.CancelBTN.Size = new System.Drawing.Size( 75, 23 );
          this.CancelBTN.TabIndex = 1;
          this.CancelBTN.Text = "Cancel";
          this.CancelBTN.UseVisualStyleBackColor = true;
          // 
          // BrowsePanel
          // 
          this.BrowsePanel.Dock = System.Windows.Forms.DockStyle.Fill;
          this.BrowsePanel.Location = new System.Drawing.Point( 0, 0 );
          this.BrowsePanel.Name = "BrowsePanel";
          // 
          // BrowsePanel.Panel1
          // 
          this.BrowsePanel.Panel1.Controls.Add( this.BrowseCTRL );
          // 
          // BrowsePanel.Panel2
          // 
          this.BrowsePanel.Panel2.Controls.Add( this.AttributesCTRL );
          this.BrowsePanel.Size = new System.Drawing.Size( 792, 285 );
          this.BrowsePanel.SplitterDistance = 375;
          this.BrowsePanel.TabIndex = 0;
          // 
          // MainPN
          // 
          this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MainPN.Location = new System.Drawing.Point( 0, 0 );
          this.MainPN.Name = "MainPN";
          this.MainPN.Orientation = System.Windows.Forms.Orientation.Horizontal;
          // 
          // MainPN.Panel1
          // 
          this.MainPN.Panel1.Controls.Add( this.BrowsePanel );
          // 
          // MainPN.Panel2
          // 
          this.MainPN.Panel2.Controls.Add( this.NodeListCTRL );
          this.MainPN.Size = new System.Drawing.Size( 792, 435 );
          this.MainPN.SplitterDistance = 285;
          this.MainPN.TabIndex = 1;
          // 
          // BrowseCTRL
          // 
          this.BrowseCTRL.AllowDrop = true;
          this.BrowseCTRL.AttributesCtrl = this.AttributesCTRL;
          this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.BrowseCTRL.EnableDragging = true;
          this.BrowseCTRL.Location = new System.Drawing.Point( 0, 0 );
          this.BrowseCTRL.Name = "BrowseCTRL";
          this.BrowseCTRL.SessionTreeCtrl = null;
          this.BrowseCTRL.Size = new System.Drawing.Size( 375, 285 );
          this.BrowseCTRL.TabIndex = 1;
          this.BrowseCTRL.ItemsSelected += new CAS.OPC.UA.Viewer.Controls.NodesSelectedEventHandler( this.BrowseCTRL_NodesSelected );
          // 
          // AttributesCTRL
          // 
          this.AttributesCTRL.AllowDrop = true;
          this.AttributesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.AttributesCTRL.EnableDragging = true;
          this.AttributesCTRL.Instructions = null;
          this.AttributesCTRL.Location = new System.Drawing.Point( 0, 0 );
          this.AttributesCTRL.Name = "AttributesCTRL";
          this.AttributesCTRL.ReadOnly = false;
          this.AttributesCTRL.Size = new System.Drawing.Size( 413, 285 );
          this.AttributesCTRL.TabIndex = 1;
          // 
          // NodeListCTRL
          // 
          this.NodeListCTRL.AllowDrop = true;
          this.NodeListCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.NodeListCTRL.EnableDragging = true;
          this.NodeListCTRL.Instructions = null;
          this.NodeListCTRL.Location = new System.Drawing.Point( 0, 0 );
          this.NodeListCTRL.Name = "NodeListCTRL";
          this.NodeListCTRL.Size = new System.Drawing.Size( 792, 146 );
          this.NodeListCTRL.TabIndex = 0;
          // 
          // SelectNodesDlg
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 792, 466 );
          this.Controls.Add( this.MainPN );
          this.Controls.Add( this.ButtonsPN );
          this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
          this.Name = "SelectNodesDlg";
          this.Text = "Select Nodes";
          this.ButtonsPN.ResumeLayout( false );
          this.BrowsePanel.Panel1.ResumeLayout( false );
          this.BrowsePanel.Panel2.ResumeLayout( false );
          this.BrowsePanel.ResumeLayout( false );
          this.MainPN.Panel1.ResumeLayout( false );
          this.MainPN.Panel2.ResumeLayout( false );
          this.MainPN.ResumeLayout( false );
          this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.SplitContainer BrowsePanel;
        private BrowseTreeCtrl BrowseCTRL;
        private AttributeListCtrl AttributesCTRL;
        private System.Windows.Forms.SplitContainer MainPN;
        private NodeListCtrl NodeListCTRL;
    }
}
