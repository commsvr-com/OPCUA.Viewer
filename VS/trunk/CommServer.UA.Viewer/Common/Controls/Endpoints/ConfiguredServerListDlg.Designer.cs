//<summary>
//  Title   : Configured server list
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

namespace CAS.OPC.UA.Viewer.Client.Controls
{
    partial class ConfiguredServerListDlg
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ConfiguredServerListDlg ) );
          this.ButtonsPN = new System.Windows.Forms.Panel();
          this.OkBTN = new System.Windows.Forms.Button();
          this.CancelBTN = new System.Windows.Forms.Button();
          this.MainPN = new System.Windows.Forms.Panel();
          this.ServersCTRL = new CAS.OPC.UA.Viewer.Client.Controls.ConfiguredServerListCtrl();
          this.ButtonsPN.SuspendLayout();
          this.MainPN.SuspendLayout();
          this.SuspendLayout();
          // 
          // ButtonsPN
          // 
          this.ButtonsPN.Controls.Add( this.OkBTN );
          this.ButtonsPN.Controls.Add( this.CancelBTN );
          this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.ButtonsPN.Location = new System.Drawing.Point( 2, 353 );
          this.ButtonsPN.Name = "ButtonsPN";
          this.ButtonsPN.Size = new System.Drawing.Size( 673, 31 );
          this.ButtonsPN.TabIndex = 0;
          // 
          // OkBTN
          // 
          this.OkBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
          this.OkBTN.Location = new System.Drawing.Point( 4, 4 );
          this.OkBTN.Name = "OkBTN";
          this.OkBTN.Size = new System.Drawing.Size( 75, 23 );
          this.OkBTN.TabIndex = 1;
          this.OkBTN.Text = "OK";
          this.OkBTN.UseVisualStyleBackColor = true;
          this.OkBTN.Click += new System.EventHandler( this.OkBTN_Click );
          // 
          // CancelBTN
          // 
          this.CancelBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.CancelBTN.Location = new System.Drawing.Point( 594, 4 );
          this.CancelBTN.Name = "CancelBTN";
          this.CancelBTN.Size = new System.Drawing.Size( 75, 23 );
          this.CancelBTN.TabIndex = 0;
          this.CancelBTN.Text = "Cancel";
          this.CancelBTN.UseVisualStyleBackColor = true;
          // 
          // MainPN
          // 
          this.MainPN.Controls.Add( this.ServersCTRL );
          this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MainPN.Location = new System.Drawing.Point( 2, 2 );
          this.MainPN.Name = "MainPN";
          this.MainPN.Padding = new System.Windows.Forms.Padding( 0, 3, 0, 0 );
          this.MainPN.Size = new System.Drawing.Size( 673, 351 );
          this.MainPN.TabIndex = 1;
          // 
          // ServersCTRL
          // 
          this.ServersCTRL.Cursor = System.Windows.Forms.Cursors.Default;
          this.ServersCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.ServersCTRL.Instructions = null;
          this.ServersCTRL.Location = new System.Drawing.Point( 0, 3 );
          this.ServersCTRL.Name = "ServersCTRL";
          this.ServersCTRL.Size = new System.Drawing.Size( 673, 348 );
          this.ServersCTRL.TabIndex = 0;
          this.ServersCTRL.ItemsSelected += new CAS.OPC.UA.Viewer.Client.Controls.ListItemActionEventHandler( this.ServersCTRL_ItemsSelected );
          // 
          // ConfiguredServerListDlg
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 677, 384 );
          this.Controls.Add( this.MainPN );
          this.Controls.Add( this.ButtonsPN );
          this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
          this.MaximumSize = new System.Drawing.Size( 1024, 1024 );
          this.MinimumSize = new System.Drawing.Size( 300, 300 );
          this.Name = "ConfiguredServerListDlg";
          this.Padding = new System.Windows.Forms.Padding( 2, 2, 2, 0 );
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Configure Servers";
          this.ButtonsPN.ResumeLayout( false );
          this.MainPN.ResumeLayout( false );
          this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel MainPN;
        private ConfiguredServerListCtrl ServersCTRL;
    }
}
