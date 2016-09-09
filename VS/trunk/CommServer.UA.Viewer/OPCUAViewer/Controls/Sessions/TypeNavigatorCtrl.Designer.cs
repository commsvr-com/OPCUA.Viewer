//<summary>
//  Title   : Type navigator
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

namespace CAS.OPC.UA.Viewer.Client
{
    partial class TypeNavigatorCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeNavigatorCtrl));
            this.TypePathCTRL = new System.Windows.Forms.ToolStrip();
            this.RootBTN = new System.Windows.Forms.ToolStripDropDownButton();
            this.childToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TypePathCTRL.SuspendLayout();
            this.SuspendLayout();
            // 
            // TypePathCTRL
            // 
            this.TypePathCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypePathCTRL.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TypePathCTRL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RootBTN});
            this.TypePathCTRL.Location = new System.Drawing.Point(0, 0);
            this.TypePathCTRL.Name = "TypePathCTRL";
            this.TypePathCTRL.Size = new System.Drawing.Size(679, 24);
            this.TypePathCTRL.TabIndex = 3;
            this.TypePathCTRL.Text = "toolStrip1";
            // 
            // RootBTN
            // 
            this.RootBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RootBTN.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.childToolStripMenuItem});
            this.RootBTN.Image = ((System.Drawing.Image)(resources.GetObject("RootBTN.Image")));
            this.RootBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RootBTN.Name = "RootBTN";
            this.RootBTN.Size = new System.Drawing.Size(45, 21);
            this.RootBTN.Text = "Root";
            this.RootBTN.ToolTipText = "Root";
            this.RootBTN.DropDownOpening += new System.EventHandler(this.RootBTN_DropDownOpening);
            this.RootBTN.Click += new System.EventHandler(this.RootBTN_Click);
            // 
            // childToolStripMenuItem
            // 
            this.childToolStripMenuItem.Name = "childToolStripMenuItem";
            this.childToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.childToolStripMenuItem.Text = "Child";
            // 
            // TypeNavigatorCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TypePathCTRL);
            this.MaximumSize = new System.Drawing.Size(3000, 24);
            this.MinimumSize = new System.Drawing.Size(0, 24);
            this.Name = "TypeNavigatorCtrl";
            this.Size = new System.Drawing.Size(679, 24);
            this.TypePathCTRL.ResumeLayout(false);
            this.TypePathCTRL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TypePathCTRL;
        private System.Windows.Forms.ToolStripDropDownButton RootBTN;
        private System.Windows.Forms.ToolStripMenuItem childToolStripMenuItem;

    }
}
