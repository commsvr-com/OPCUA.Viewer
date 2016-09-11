//<summary>
//  Title   : Endpoint selector
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
    partial class EndpointSelectorCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( EndpointSelectorCtrl ) );
          this.EndpointCB = new System.Windows.Forms.ComboBox();
          this.ConnectButton = new System.Windows.Forms.Button();
          this.ConnectPN = new System.Windows.Forms.Panel();
          this.endpointSelectorServerLabellabel1 = new System.Windows.Forms.Label();
          this.connectPNBrowseButton = new System.Windows.Forms.Button();
          this.ConnectPN.SuspendLayout();
          this.SuspendLayout();
          // 
          // EndpointCB
          // 
          this.EndpointCB.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.EndpointCB.FormattingEnabled = true;
          this.EndpointCB.Location = new System.Drawing.Point( 51, 4 );
          this.EndpointCB.Name = "EndpointCB";
          this.EndpointCB.Size = new System.Drawing.Size( 571, 21 );
          this.EndpointCB.TabIndex = 0;
          this.EndpointCB.SelectedIndexChanged += new System.EventHandler( this.EndpointCB_SelectedIndexChanged );
          // 
          // ConnectButton
          // 
          this.ConnectButton.Dock = System.Windows.Forms.DockStyle.Left;
          this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.ConnectButton.Location = new System.Drawing.Point( 3, 3 );
          this.ConnectButton.Name = "ConnectButton";
          this.ConnectButton.Size = new System.Drawing.Size( 72, 22 );
          this.ConnectButton.TabIndex = 1;
          this.ConnectButton.Text = "Connect";
          this.ConnectButton.UseVisualStyleBackColor = true;
          this.ConnectButton.Click += new System.EventHandler( this.ConnectButton_Click );
          // 
          // ConnectPN
          // 
          this.ConnectPN.Controls.Add( this.connectPNBrowseButton );
          this.ConnectPN.Controls.Add( this.ConnectButton );
          this.ConnectPN.Dock = System.Windows.Forms.DockStyle.Right;
          this.ConnectPN.Location = new System.Drawing.Point( 628, 0 );
          this.ConnectPN.Name = "ConnectPN";
          this.ConnectPN.Padding = new System.Windows.Forms.Padding( 3 );
          this.ConnectPN.Size = new System.Drawing.Size( 106, 28 );
          this.ConnectPN.TabIndex = 2;
          // 
          // endpointSelectorServerLabellabel1
          // 
          this.endpointSelectorServerLabellabel1.AutoSize = true;
          this.endpointSelectorServerLabellabel1.Location = new System.Drawing.Point( 5, 7 );
          this.endpointSelectorServerLabellabel1.Name = "endpointSelectorServerLabellabel1";
          this.endpointSelectorServerLabellabel1.Size = new System.Drawing.Size( 38, 13 );
          this.endpointSelectorServerLabellabel1.TabIndex = 3;
          this.endpointSelectorServerLabellabel1.Text = "Server";
          // 
          // connectPNBrowseButton
          // 
          this.connectPNBrowseButton.Dock = System.Windows.Forms.DockStyle.Right;
          this.connectPNBrowseButton.Image = ( (System.Drawing.Image)( resources.GetObject( "connectPNBrowseButton.Image" ) ) );
          this.connectPNBrowseButton.Location = new System.Drawing.Point( 81, 3 );
          this.connectPNBrowseButton.Name = "connectPNBrowseButton";
          this.connectPNBrowseButton.Size = new System.Drawing.Size( 22, 22 );
          this.connectPNBrowseButton.TabIndex = 5;
          this.connectPNBrowseButton.UseVisualStyleBackColor = true;
          this.connectPNBrowseButton.Click += new System.EventHandler( DiscoverServersButton_Click );
          // 
          // EndpointSelectorCtrl
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add( this.endpointSelectorServerLabellabel1 );
          this.Controls.Add( this.ConnectPN );
          this.Controls.Add( this.EndpointCB );
          this.MaximumSize = new System.Drawing.Size( 2048, 28 );
          this.MinimumSize = new System.Drawing.Size( 100, 28 );
          this.Name = "EndpointSelectorCtrl";
          this.Padding = new System.Windows.Forms.Padding( 2, 0, 0, 0 );
          this.Size = new System.Drawing.Size( 734, 28 );
          this.ConnectPN.ResumeLayout( false );
          this.ResumeLayout( false );
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EndpointCB;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Panel ConnectPN;
        private System.Windows.Forms.Label endpointSelectorServerLabellabel1;
        private System.Windows.Forms.Button connectPNBrowseButton;
    }
}
