//<summary>
//  Title   : Host list
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
    partial class HostListDlg
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( HostListDlg ) );
          this.ButtonsPN = new System.Windows.Forms.Panel();
          this.OkBTN = new System.Windows.Forms.Button();
          this.CancelBTN = new System.Windows.Forms.Button();
          this.MainPN = new System.Windows.Forms.Panel();
          this.HostsCTRL = new CAS.OPC.UA.Viewer.Client.Controls.HostListCtrl();
          this.TopPN = new System.Windows.Forms.Panel();
          this.DomainNameCTRL = new CAS.OPC.UA.Viewer.Client.Controls.SelectHostCtrl();
          this.DomainLB = new System.Windows.Forms.Label();
          this.ButtonsPN.SuspendLayout();
          this.MainPN.SuspendLayout();
          this.TopPN.SuspendLayout();
          this.SuspendLayout();
          // 
          // ButtonsPN
          // 
          this.ButtonsPN.Controls.Add( this.OkBTN );
          this.ButtonsPN.Controls.Add( this.CancelBTN );
          this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.ButtonsPN.Location = new System.Drawing.Point( 2, 254 );
          this.ButtonsPN.Name = "ButtonsPN";
          this.ButtonsPN.Size = new System.Drawing.Size( 455, 31 );
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
          this.CancelBTN.Location = new System.Drawing.Point( 376, 4 );
          this.CancelBTN.Name = "CancelBTN";
          this.CancelBTN.Size = new System.Drawing.Size( 75, 23 );
          this.CancelBTN.TabIndex = 0;
          this.CancelBTN.Text = "Cancel";
          this.CancelBTN.UseVisualStyleBackColor = true;
          // 
          // MainPN
          // 
          this.MainPN.Controls.Add( this.HostsCTRL );
          this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MainPN.Location = new System.Drawing.Point( 2, 23 );
          this.MainPN.Name = "MainPN";
          this.MainPN.Padding = new System.Windows.Forms.Padding( 0, 3, 0, 0 );
          this.MainPN.Size = new System.Drawing.Size( 455, 231 );
          this.MainPN.TabIndex = 2;
          // 
          // HostsCTRL
          // 
          this.HostsCTRL.Cursor = System.Windows.Forms.Cursors.Default;
          this.HostsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.HostsCTRL.Instructions = null;
          this.HostsCTRL.Location = new System.Drawing.Point( 0, 3 );
          this.HostsCTRL.Name = "HostsCTRL";
          this.HostsCTRL.Size = new System.Drawing.Size( 455, 228 );
          this.HostsCTRL.TabIndex = 0;
          this.HostsCTRL.ItemsPicked += new CAS.OPC.UA.Viewer.Client.Controls.ListItemActionEventHandler( this.HostsCTRL_ItemsPicked );
          this.HostsCTRL.ItemsSelected += new CAS.OPC.UA.Viewer.Client.Controls.ListItemActionEventHandler( this.HostsCTRL_ItemsSelected );
          // 
          // TopPN
          // 
          this.TopPN.Controls.Add( this.DomainNameCTRL );
          this.TopPN.Controls.Add( this.DomainLB );
          this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
          this.TopPN.Location = new System.Drawing.Point( 2, 2 );
          this.TopPN.Name = "TopPN";
          this.TopPN.Size = new System.Drawing.Size( 455, 21 );
          this.TopPN.TabIndex = 1;
          // 
          // DomainNameCTRL
          // 
          this.DomainNameCTRL.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.DomainNameCTRL.CommandText = "Refresh";
          this.DomainNameCTRL.Location = new System.Drawing.Point( 47, 0 );
          this.DomainNameCTRL.Margin = new System.Windows.Forms.Padding( 0 );
          this.DomainNameCTRL.MaximumSize = new System.Drawing.Size( 4096, 21 );
          this.DomainNameCTRL.MinimumSize = new System.Drawing.Size( 400, 21 );
          this.DomainNameCTRL.Name = "DomainNameCTRL";
          this.DomainNameCTRL.Padding = new System.Windows.Forms.Padding( 2, 0, 0, 0 );
          this.DomainNameCTRL.SelectDomains = true;
          this.DomainNameCTRL.Size = new System.Drawing.Size( 408, 21 );
          this.DomainNameCTRL.TabIndex = 1;
          this.DomainNameCTRL.HostConnected += new System.EventHandler<CAS.OPC.UA.Viewer.Client.Controls.SelectHostCtrlEventArgs>( this.DomainNameCTRL_HostConnected );
          this.DomainNameCTRL.HostSelected += new System.EventHandler<CAS.OPC.UA.Viewer.Client.Controls.SelectHostCtrlEventArgs>( this.DomainNameCTRL_HostSelected );
          // 
          // DomainLB
          // 
          this.DomainLB.AutoSize = true;
          this.DomainLB.Location = new System.Drawing.Point( 0, 4 );
          this.DomainLB.Name = "DomainLB";
          this.DomainLB.Size = new System.Drawing.Size( 43, 13 );
          this.DomainLB.TabIndex = 0;
          this.DomainLB.Text = "Domain";
          this.DomainLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // HostListDlg
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 459, 285 );
          this.Controls.Add( this.MainPN );
          this.Controls.Add( this.TopPN );
          this.Controls.Add( this.ButtonsPN );
          this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
          this.MaximumSize = new System.Drawing.Size( 1024, 1024 );
          this.MinimumSize = new System.Drawing.Size( 467, 319 );
          this.Name = "HostListDlg";
          this.Padding = new System.Windows.Forms.Padding( 2, 2, 2, 0 );
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Discover Hosts";
          this.ButtonsPN.ResumeLayout( false );
          this.MainPN.ResumeLayout( false );
          this.TopPN.ResumeLayout( false );
          this.TopPN.PerformLayout();
          this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel MainPN;
        private HostListCtrl HostsCTRL;
        private SelectHostCtrl DomainNameCTRL;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Label DomainLB;
    }
}
