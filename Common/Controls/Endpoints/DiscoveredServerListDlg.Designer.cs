//<summary>
//  Title   : Discovered server list
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
    partial class DiscoveredServerListDlg
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( DiscoveredServerListDlg ) );
          this.ButtonsPN = new System.Windows.Forms.Panel();
          this.OkBTN = new System.Windows.Forms.Button();
          this.CancelBTN = new System.Windows.Forms.Button();
          this.MainPN = new System.Windows.Forms.Panel();
          this.ServersCTRL = new CAS.OPC.UA.Viewer.Client.Controls.DiscoveredServerListCtrl();
          this.TopPN = new System.Windows.Forms.Panel();
          this.HostNameLB = new System.Windows.Forms.Label();
          this.HostNameCTRL = new CAS.OPC.UA.Viewer.Client.Controls.SelectHostCtrl();
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
          this.MainPN.Location = new System.Drawing.Point( 2, 23 );
          this.MainPN.Name = "MainPN";
          this.MainPN.Padding = new System.Windows.Forms.Padding( 0, 3, 0, 0 );
          this.MainPN.Size = new System.Drawing.Size( 673, 330 );
          this.MainPN.TabIndex = 2;
          // 
          // ServersCTRL
          // 
          this.ServersCTRL.Cursor = System.Windows.Forms.Cursors.Default;
          this.ServersCTRL.DiscoveryTimeout = 0;
          this.ServersCTRL.DiscoveryUrl = null;
          this.ServersCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.ServersCTRL.Instructions = null;
          this.ServersCTRL.Location = new System.Drawing.Point( 0, 3 );
          this.ServersCTRL.Name = "ServersCTRL";
          this.ServersCTRL.Size = new System.Drawing.Size( 673, 327 );
          this.ServersCTRL.TabIndex = 0;
          this.ServersCTRL.ItemsPicked += new CAS.OPC.UA.Viewer.Client.Controls.ListItemActionEventHandler( this.ServersCTRL_ItemsPicked );
          this.ServersCTRL.ItemsSelected += new CAS.OPC.UA.Viewer.Client.Controls.ListItemActionEventHandler( this.ServersCTRL_ItemsSelected );
          // 
          // TopPN
          // 
          this.TopPN.Controls.Add( this.HostNameLB );
          this.TopPN.Controls.Add( this.HostNameCTRL );
          this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
          this.TopPN.Location = new System.Drawing.Point( 2, 2 );
          this.TopPN.Name = "TopPN";
          this.TopPN.Size = new System.Drawing.Size( 673, 21 );
          this.TopPN.TabIndex = 1;
          // 
          // HostNameLB
          // 
          this.HostNameLB.AutoSize = true;
          this.HostNameLB.Location = new System.Drawing.Point( 0, 4 );
          this.HostNameLB.Name = "HostNameLB";
          this.HostNameLB.Size = new System.Drawing.Size( 60, 13 );
          this.HostNameLB.TabIndex = 0;
          this.HostNameLB.Text = "Host Name";
          this.HostNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // HostNameCTRL
          // 
          this.HostNameCTRL.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.HostNameCTRL.CommandText = "Discover";
          this.HostNameCTRL.Location = new System.Drawing.Point( 63, 0 );
          this.HostNameCTRL.Margin = new System.Windows.Forms.Padding( 0 );
          this.HostNameCTRL.MaximumSize = new System.Drawing.Size( 4096, 24 );
          this.HostNameCTRL.MinimumSize = new System.Drawing.Size( 400, 21 );
          this.HostNameCTRL.Name = "HostNameCTRL";
          this.HostNameCTRL.Padding = new System.Windows.Forms.Padding( 2, 0, 0, 0 );
          this.HostNameCTRL.Size = new System.Drawing.Size( 610, 21 );
          this.HostNameCTRL.TabIndex = 1;
          this.HostNameCTRL.HostConnected += new System.EventHandler<CAS.OPC.UA.Viewer.Client.Controls.SelectHostCtrlEventArgs>( this.HostNameCTRL_HostConnected );
          this.HostNameCTRL.HostSelected += new System.EventHandler<CAS.OPC.UA.Viewer.Client.Controls.SelectHostCtrlEventArgs>( this.HostNameCTRL_HostSelected );
          // 
          // DiscoveredServerListDlg
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 677, 384 );
          this.Controls.Add( this.MainPN );
          this.Controls.Add( this.TopPN );
          this.Controls.Add( this.ButtonsPN );
          this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
          this.MaximumSize = new System.Drawing.Size( 1024, 1024 );
          this.MinimumSize = new System.Drawing.Size( 300, 300 );
          this.Name = "DiscoveredServerListDlg";
          this.Padding = new System.Windows.Forms.Padding( 2, 2, 2, 0 );
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Discover Servers";
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
        private DiscoveredServerListCtrl ServersCTRL;
        private SelectHostCtrl HostNameCTRL;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Label HostNameLB;
    }
}
