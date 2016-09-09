//<summary>
//  Title   : Address space dialog
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
    partial class AddressSpaceDlg
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AddressSpaceDlg ) );
          this.MainPN = new System.Windows.Forms.SplitContainer();
          this.BrowseCTRL = new CAS.OPC.UA.Viewer.Controls.BrowseTreeCtrl();
          this.AttributesCTRL = new CAS.OPC.UA.Viewer.Controls.AttributeListCtrl();
          this.MainPN.Panel1.SuspendLayout();
          this.MainPN.Panel2.SuspendLayout();
          this.MainPN.SuspendLayout();
          this.SuspendLayout();
          // 
          // MainPN
          // 
          this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MainPN.Location = new System.Drawing.Point( 0, 0 );
          this.MainPN.Name = "MainPN";
          // 
          // MainPN.Panel1
          // 
          this.MainPN.Panel1.Controls.Add( this.BrowseCTRL );
          // 
          // MainPN.Panel2
          // 
          this.MainPN.Panel2.Controls.Add( this.AttributesCTRL );
          this.MainPN.Size = new System.Drawing.Size( 815, 532 );
          this.MainPN.SplitterDistance = 271;
          this.MainPN.TabIndex = 1;
          // 
          // BrowseCTRL
          // 
          this.BrowseCTRL.AttributesCtrl = this.AttributesCTRL;
          this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.BrowseCTRL.EnableDragging = false;
          this.BrowseCTRL.Location = new System.Drawing.Point( 0, 0 );
          this.BrowseCTRL.Name = "BrowseCTRL";
          this.BrowseCTRL.SessionTreeCtrl = null;
          this.BrowseCTRL.Size = new System.Drawing.Size( 271, 532 );
          this.BrowseCTRL.TabIndex = 0;
          // 
          // AttributesCTRL
          // 
          this.AttributesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.AttributesCTRL.Instructions = null;
          this.AttributesCTRL.Location = new System.Drawing.Point( 0, 0 );
          this.AttributesCTRL.Name = "AttributesCTRL";
          this.AttributesCTRL.ReadOnly = false;
          this.AttributesCTRL.Size = new System.Drawing.Size( 540, 532 );
          this.AttributesCTRL.TabIndex = 0;
          // 
          // AddressSpaceDlg
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 815, 532 );
          this.Controls.Add( this.MainPN );
          this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
          this.Name = "AddressSpaceDlg";
          this.Text = "Browse Address Space";
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.AddressSpaceDlg_FormClosing );
          this.MainPN.Panel1.ResumeLayout( false );
          this.MainPN.Panel2.ResumeLayout( false );
          this.MainPN.ResumeLayout( false );
          this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainPN;
        private BrowseTreeCtrl BrowseCTRL;
        private AttributeListCtrl AttributesCTRL;
    }
}
