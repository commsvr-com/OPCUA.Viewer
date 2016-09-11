//<summary>
//  Title   : Browse types dialog
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

using CAS.OPC.UA.Viewer.Client;
namespace CAS.OPC.UA.Viewer.Controls
{
    partial class BrowseTypesDlg
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( BrowseTypesDlg ) );
          this.ButtonsPN = new System.Windows.Forms.Panel();
          this.OkBTN = new System.Windows.Forms.Button();
          this.CancelBTN = new System.Windows.Forms.Button();
          this.MainPN = new System.Windows.Forms.Panel();
          this.TypeHierarchyCTRL = new CAS.OPC.UA.Viewer.Client.TypeHierarchyListCtrl();
          this.TypeNavigatorCTRL = new CAS.OPC.UA.Viewer.Client.TypeNavigatorCtrl();
          this.ButtonsPN.SuspendLayout();
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
          this.ButtonsPN.TabIndex = 1;
          // 
          // OkBTN
          // 
          this.OkBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
          this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.OkBTN.Location = new System.Drawing.Point( 4, 4 );
          this.OkBTN.Name = "OkBTN";
          this.OkBTN.Size = new System.Drawing.Size( 75, 23 );
          this.OkBTN.TabIndex = 1;
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
          this.CancelBTN.TabIndex = 0;
          this.CancelBTN.Text = "Cancel";
          this.CancelBTN.UseVisualStyleBackColor = true;
          // 
          // MainPN
          // 
          this.MainPN.Controls.Add( this.TypeHierarchyCTRL );
          this.MainPN.Controls.Add( this.TypeNavigatorCTRL );
          this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MainPN.Location = new System.Drawing.Point( 0, 0 );
          this.MainPN.Name = "MainPN";
          this.MainPN.Padding = new System.Windows.Forms.Padding( 2, 2, 2, 0 );
          this.MainPN.Size = new System.Drawing.Size( 792, 435 );
          this.MainPN.TabIndex = 2;
          // 
          // TypeHierarchyCTRL
          // 
          this.TypeHierarchyCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.TypeHierarchyCTRL.Instructions = null;
          this.TypeHierarchyCTRL.Location = new System.Drawing.Point( 2, 26 );
          this.TypeHierarchyCTRL.Name = "TypeHierarchyCTRL";
          this.TypeHierarchyCTRL.Size = new System.Drawing.Size( 788, 409 );
          this.TypeHierarchyCTRL.TabIndex = 0;
          // 
          // TypeNavigatorCTRL
          // 
          this.TypeNavigatorCTRL.Dock = System.Windows.Forms.DockStyle.Top;
          this.TypeNavigatorCTRL.Location = new System.Drawing.Point( 2, 2 );
          this.TypeNavigatorCTRL.MaximumSize = new System.Drawing.Size( 3000, 24 );
          this.TypeNavigatorCTRL.MinimumSize = new System.Drawing.Size( 0, 24 );
          this.TypeNavigatorCTRL.Name = "TypeNavigatorCTRL";
          this.TypeNavigatorCTRL.Size = new System.Drawing.Size( 788, 24 );
          this.TypeNavigatorCTRL.TabIndex = 1;
          this.TypeNavigatorCTRL.TypeSelected += new CAS.OPC.UA.Viewer.Client.TypeNavigatorEventHandler( this.TypeNavigatorCTRL_TypeSelected );
          // 
          // BrowseTypesDlg
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 792, 466 );
          this.Controls.Add( this.MainPN );
          this.Controls.Add( this.ButtonsPN );
          this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
          this.Name = "BrowseTypesDlg";
          this.Text = "Browse Types";
          this.ButtonsPN.ResumeLayout( false );
          this.MainPN.ResumeLayout( false );
          this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel MainPN;
        private TypeHierarchyListCtrl TypeHierarchyCTRL;
        private TypeNavigatorCtrl TypeNavigatorCTRL;

    }
}
