//<summary>
//  Title   : Select host
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
    partial class SelectHostCtrl
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
            this.HostsCB = new System.Windows.Forms.ComboBox();
            this.ConnectPN = new System.Windows.Forms.Panel();
            this.ConnectBTN = new System.Windows.Forms.Button();
            this.ConnectPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // HostsCB
            // 
            this.HostsCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HostsCB.FormattingEnabled = true;
            this.HostsCB.Location = new System.Drawing.Point(0, 0);
            this.HostsCB.Name = "HostsCB";
            this.HostsCB.Size = new System.Drawing.Size(578, 21);
            this.HostsCB.TabIndex = 0;
            this.HostsCB.SelectedIndexChanged += new System.EventHandler(this.HostsCB_SelectedIndexChanged);
            // 
            // ConnectPN
            // 
            this.ConnectPN.Controls.Add(this.ConnectBTN);
            this.ConnectPN.Dock = System.Windows.Forms.DockStyle.Right;
            this.ConnectPN.Location = new System.Drawing.Point(581, 0);
            this.ConnectPN.Margin = new System.Windows.Forms.Padding(0);
            this.ConnectPN.Name = "ConnectPN";
            this.ConnectPN.Size = new System.Drawing.Size(74, 21);
            this.ConnectPN.TabIndex = 1;
            // 
            // ConnectBTN
            // 
            this.ConnectBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectBTN.Location = new System.Drawing.Point(0, 0);
            this.ConnectBTN.Name = "ConnectBTN";
            this.ConnectBTN.Size = new System.Drawing.Size(74, 21);
            this.ConnectBTN.TabIndex = 0;
            this.ConnectBTN.Text = "Connect";
            this.ConnectBTN.UseVisualStyleBackColor = true;
            this.ConnectBTN.Click += new System.EventHandler(this.ConnectBTN_Click);
            // 
            // SelectHostCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConnectPN);
            this.Controls.Add(this.HostsCB);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(4096, 21);
            this.MinimumSize = new System.Drawing.Size(400, 21);
            this.Name = "SelectHostCtrl";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.Size = new System.Drawing.Size(655, 21);
            this.ConnectPN.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox HostsCB;
        private System.Windows.Forms.Panel ConnectPN;
        private System.Windows.Forms.Button ConnectBTN;
    }
}
