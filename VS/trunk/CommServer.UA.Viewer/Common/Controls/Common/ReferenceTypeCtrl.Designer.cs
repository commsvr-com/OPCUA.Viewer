//<summary>
//  Title   : Reference type
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
    partial class ReferenceTypeCtrl
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
            this.ReferenceTypesCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ReferenceTypesCB
            // 
            this.ReferenceTypesCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ReferenceTypesCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReferenceTypesCB.FormattingEnabled = true;
            this.ReferenceTypesCB.Location = new System.Drawing.Point(0, 0);
            this.ReferenceTypesCB.Name = "ReferenceTypesCB";
            this.ReferenceTypesCB.Size = new System.Drawing.Size(200, 21);
            this.ReferenceTypesCB.TabIndex = 0;
            this.ReferenceTypesCB.SelectedIndexChanged += new System.EventHandler(this.ReferenceTypesCB_SelectedIndexChanged);
            // 
            // ReferenceTypeCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReferenceTypesCB);
            this.MaximumSize = new System.Drawing.Size(4096, 21);
            this.MinimumSize = new System.Drawing.Size(200, 21);
            this.Name = "ReferenceTypeCtrl";
            this.Size = new System.Drawing.Size(200, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ReferenceTypesCB;
    }
}
