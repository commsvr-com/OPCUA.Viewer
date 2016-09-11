//<summary>
//  Title   : String value editor
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
    partial class StringValueEditDlg
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( StringValueEditDlg ) );
          this.ButtonsPN = new System.Windows.Forms.Panel();
          this.OkBTN = new System.Windows.Forms.Button();
          this.CancelBTN = new System.Windows.Forms.Button();
          this.MainPN = new System.Windows.Forms.Panel();
          this.ValueTB = new System.Windows.Forms.TextBox();
          this.ButtonsPN.SuspendLayout();
          this.MainPN.SuspendLayout();
          this.SuspendLayout();
          // 
          // ButtonsPN
          // 
          this.ButtonsPN.Controls.Add( this.OkBTN );
          this.ButtonsPN.Controls.Add( this.CancelBTN );
          this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.ButtonsPN.Location = new System.Drawing.Point( 0, 24 );
          this.ButtonsPN.Name = "ButtonsPN";
          this.ButtonsPN.Size = new System.Drawing.Size( 252, 31 );
          this.ButtonsPN.TabIndex = 0;
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
          this.CancelBTN.Location = new System.Drawing.Point( 173, 4 );
          this.CancelBTN.Name = "CancelBTN";
          this.CancelBTN.Size = new System.Drawing.Size( 75, 23 );
          this.CancelBTN.TabIndex = 0;
          this.CancelBTN.Text = "Cancel";
          this.CancelBTN.UseVisualStyleBackColor = true;
          // 
          // MainPN
          // 
          this.MainPN.Controls.Add( this.ValueTB );
          this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MainPN.Location = new System.Drawing.Point( 0, 0 );
          this.MainPN.Name = "MainPN";
          this.MainPN.Padding = new System.Windows.Forms.Padding( 3 );
          this.MainPN.Size = new System.Drawing.Size( 252, 24 );
          this.MainPN.TabIndex = 1;
          // 
          // ValueTB
          // 
          this.ValueTB.Dock = System.Windows.Forms.DockStyle.Fill;
          this.ValueTB.Location = new System.Drawing.Point( 3, 3 );
          this.ValueTB.MinimumSize = new System.Drawing.Size( 4, 20 );
          this.ValueTB.Multiline = true;
          this.ValueTB.Name = "ValueTB";
          this.ValueTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
          this.ValueTB.Size = new System.Drawing.Size( 246, 20 );
          this.ValueTB.TabIndex = 0;
          this.ValueTB.Text = "Default";
          // 
          // StringValueEditDlg
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 252, 55 );
          this.Controls.Add( this.MainPN );
          this.Controls.Add( this.ButtonsPN );
          this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
          this.MaximizeBox = false;
          this.MinimumSize = new System.Drawing.Size( 221, 89 );
          this.Name = "StringValueEditDlg";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Edit String Value";
          this.ButtonsPN.ResumeLayout( false );
          this.MainPN.ResumeLayout( false );
          this.MainPN.PerformLayout();
          this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.TextBox ValueTB;
    }
}
