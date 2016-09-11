//<summary>
//  Title   : Call method
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
    partial class CallMethodDlg
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( CallMethodDlg ) );
          this.ButtonsPN = new System.Windows.Forms.Panel();
          this.OkBTN = new System.Windows.Forms.Button();
          this.CancelBTN = new System.Windows.Forms.Button();
          this.MainPN = new System.Windows.Forms.SplitContainer();
          this.InputArgumentsCTRL = new CAS.OPC.UA.Viewer.Controls.ArgumentListCtrl();
          this.OutputArgumentsCTRL = new CAS.OPC.UA.Viewer.Controls.ArgumentListCtrl();
          this.ButtonsPN.SuspendLayout();
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
          this.ButtonsPN.Location = new System.Drawing.Point( 0, 137 );
          this.ButtonsPN.Name = "ButtonsPN";
          this.ButtonsPN.Size = new System.Drawing.Size( 495, 31 );
          this.ButtonsPN.TabIndex = 0;
          // 
          // OkBTN
          // 
          this.OkBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
          this.OkBTN.Location = new System.Drawing.Point( 4, 4 );
          this.OkBTN.Name = "OkBTN";
          this.OkBTN.Size = new System.Drawing.Size( 75, 23 );
          this.OkBTN.TabIndex = 0;
          this.OkBTN.Text = "Call";
          this.OkBTN.UseVisualStyleBackColor = true;
          this.OkBTN.Click += new System.EventHandler( this.OkBTN_Click );
          // 
          // CancelBTN
          // 
          this.CancelBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.CancelBTN.Location = new System.Drawing.Point( 416, 4 );
          this.CancelBTN.Name = "CancelBTN";
          this.CancelBTN.Size = new System.Drawing.Size( 75, 23 );
          this.CancelBTN.TabIndex = 1;
          this.CancelBTN.Text = "Cancel";
          this.CancelBTN.UseVisualStyleBackColor = true;
          this.CancelBTN.Click += new System.EventHandler( this.CancelBTN_Click );
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
          this.MainPN.Panel1.Controls.Add( this.InputArgumentsCTRL );
          // 
          // MainPN.Panel2
          // 
          this.MainPN.Panel2.Controls.Add( this.OutputArgumentsCTRL );
          this.MainPN.Size = new System.Drawing.Size( 495, 137 );
          this.MainPN.SplitterDistance = 65;
          this.MainPN.TabIndex = 2;
          // 
          // InputArgumentsCTRL
          // 
          this.InputArgumentsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.InputArgumentsCTRL.Instructions = "This method has no input arguments.";
          this.InputArgumentsCTRL.Location = new System.Drawing.Point( 0, 0 );
          this.InputArgumentsCTRL.Name = "InputArgumentsCTRL";
          this.InputArgumentsCTRL.Padding = new System.Windows.Forms.Padding( 3, 3, 3, 0 );
          this.InputArgumentsCTRL.Size = new System.Drawing.Size( 495, 65 );
          this.InputArgumentsCTRL.TabIndex = 1;
          // 
          // OutputArgumentsCTRL
          // 
          this.OutputArgumentsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.OutputArgumentsCTRL.Instructions = "This method has no output arguments.";
          this.OutputArgumentsCTRL.Location = new System.Drawing.Point( 0, 0 );
          this.OutputArgumentsCTRL.Name = "OutputArgumentsCTRL";
          this.OutputArgumentsCTRL.Padding = new System.Windows.Forms.Padding( 3, 0, 3, 3 );
          this.OutputArgumentsCTRL.Size = new System.Drawing.Size( 495, 68 );
          this.OutputArgumentsCTRL.TabIndex = 2;
          // 
          // CallMethodDlg
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 495, 168 );
          this.Controls.Add( this.MainPN );
          this.Controls.Add( this.ButtonsPN );
          this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
          this.Name = "CallMethodDlg";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Call Method";
          this.ButtonsPN.ResumeLayout( false );
          this.MainPN.Panel1.ResumeLayout( false );
          this.MainPN.Panel2.ResumeLayout( false );
          this.MainPN.ResumeLayout( false );
          this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private ArgumentListCtrl InputArgumentsCTRL;
        private System.Windows.Forms.SplitContainer MainPN;
        private ArgumentListCtrl OutputArgumentsCTRL;
    }
}
