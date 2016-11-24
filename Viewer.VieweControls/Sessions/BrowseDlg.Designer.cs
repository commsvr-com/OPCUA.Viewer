//<summary>
//  Title   : Browse dialog
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
    partial class BrowseDlg
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( BrowseDlg ) );
          this.MainPN = new System.Windows.Forms.Panel();
          this.BrowseCTRL = new CAS.OPC.UA.Viewer.Controls.BrowseListCtrl();
          this.TopPN = new System.Windows.Forms.Panel();
          this.NodeCTRL = new System.Windows.Forms.ComboBox();
          this.ForwardBTN = new System.Windows.Forms.Button();
          this.BackBTN = new System.Windows.Forms.Button();
          this.MainPN.SuspendLayout();
          this.TopPN.SuspendLayout();
          this.SuspendLayout();
          // 
          // MainPN
          // 
          this.MainPN.Controls.Add( this.BrowseCTRL );
          this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MainPN.Location = new System.Drawing.Point( 0, 27 );
          this.MainPN.Name = "MainPN";
          this.MainPN.Padding = new System.Windows.Forms.Padding( 3 );
          this.MainPN.Size = new System.Drawing.Size( 702, 378 );
          this.MainPN.TabIndex = 1;
          // 
          // BrowseCTRL
          // 
          this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.BrowseCTRL.Instructions = null;
          this.BrowseCTRL.Location = new System.Drawing.Point( 3, 3 );
          this.BrowseCTRL.Name = "BrowseCTRL";
          this.BrowseCTRL.Position = 0;
          this.BrowseCTRL.Size = new System.Drawing.Size( 696, 372 );
          this.BrowseCTRL.TabIndex = 0;
          this.BrowseCTRL.PositionChanged += new System.EventHandler( this.BrowseCTRL_PositionChanged );
          this.BrowseCTRL.PositionAdded += new System.EventHandler( this.BrowseCTRL_PositionAdded );
          // 
          // TopPN
          // 
          this.TopPN.Controls.Add( this.NodeCTRL );
          this.TopPN.Controls.Add( this.ForwardBTN );
          this.TopPN.Controls.Add( this.BackBTN );
          this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
          this.TopPN.Location = new System.Drawing.Point( 0, 0 );
          this.TopPN.Name = "TopPN";
          this.TopPN.Size = new System.Drawing.Size( 702, 27 );
          this.TopPN.TabIndex = 2;
          // 
          // NodeCTRL
          // 
          this.NodeCTRL.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                      | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.NodeCTRL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.NodeCTRL.FormattingEnabled = true;
          this.NodeCTRL.Location = new System.Drawing.Point( 57, 3 );
          this.NodeCTRL.Name = "NodeCTRL";
          this.NodeCTRL.Size = new System.Drawing.Size( 642, 21 );
          this.NodeCTRL.TabIndex = 2;
          this.NodeCTRL.SelectedIndexChanged += new System.EventHandler( this.NodeCTRL_SelectedIndexChanged );
          // 
          // ForwardBTN
          // 
          this.ForwardBTN.Location = new System.Drawing.Point( 30, 3 );
          this.ForwardBTN.Margin = new System.Windows.Forms.Padding( 0 );
          this.ForwardBTN.Name = "ForwardBTN";
          this.ForwardBTN.Size = new System.Drawing.Size( 24, 21 );
          this.ForwardBTN.TabIndex = 1;
          this.ForwardBTN.Text = ">";
          this.ForwardBTN.UseVisualStyleBackColor = true;
          this.ForwardBTN.Click += new System.EventHandler( this.ForwardBTN_Click );
          // 
          // BackBTN
          // 
          this.BackBTN.Location = new System.Drawing.Point( 3, 3 );
          this.BackBTN.Name = "BackBTN";
          this.BackBTN.Size = new System.Drawing.Size( 24, 21 );
          this.BackBTN.TabIndex = 0;
          this.BackBTN.Text = "<";
          this.BackBTN.UseVisualStyleBackColor = true;
          this.BackBTN.Click += new System.EventHandler( this.BackBTN_Click );
          // 
          // BrowseDlg
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 702, 405 );
          this.Controls.Add( this.MainPN );
          this.Controls.Add( this.TopPN );
          this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
          this.Name = "BrowseDlg";
          this.Text = "Browse Address Space";
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.AddressSpaceDlg_FormClosing );
          this.MainPN.ResumeLayout( false );
          this.TopPN.ResumeLayout( false );
          this.ResumeLayout( false );

        }

        #endregion

        private BrowseListCtrl BrowseCTRL;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button BackBTN;
        private System.Windows.Forms.ComboBox NodeCTRL;
        private System.Windows.Forms.Button ForwardBTN;
    }
}
