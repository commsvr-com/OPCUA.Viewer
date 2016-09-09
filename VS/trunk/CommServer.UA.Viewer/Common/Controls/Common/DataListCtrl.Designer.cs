//<summary>
//  Title   : Data list
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
    /// <summary>
    /// 
    /// </summary>
    partial class DataListCtrl
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
            this.components = new System.ComponentModel.Container();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UpdatesMI = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator01 = new System.Windows.Forms.ToolStripSeparator();
            this.EditMI = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemsLV
            // 
            this.ItemsLV.ContextMenuStrip = this.PopupMenu;
            this.ItemsLV.MultiSelect = false;
            this.ItemsLV.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ItemsLV_MouseClick);
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdatesMI,
            this.RefreshMI,
            this.ClearMI,
            this.Separator01,
            this.EditMI});
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(136, 98);
            // 
            // UpdatesMI
            // 
            this.UpdatesMI.Checked = true;
            this.UpdatesMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UpdatesMI.Name = "UpdatesMI";
            this.UpdatesMI.Size = new System.Drawing.Size(135, 22);
            this.UpdatesMI.Text = "Auto Update";
            this.UpdatesMI.CheckedChanged += new System.EventHandler(this.UpdatesMI_CheckedChanged);
            // 
            // RefreshMI
            // 
            this.RefreshMI.Name = "RefreshMI";
            this.RefreshMI.Size = new System.Drawing.Size(135, 22);
            this.RefreshMI.Text = "Refresh";
            this.RefreshMI.Click += new System.EventHandler(this.RefreshMI_Click);
            // 
            // ClearMI
            // 
            this.ClearMI.Name = "ClearMI";
            this.ClearMI.Size = new System.Drawing.Size(135, 22);
            this.ClearMI.Text = "Clear";
            this.ClearMI.Click += new System.EventHandler(this.ClearMI_Click);
            // 
            // Separator01
            // 
            this.Separator01.Name = "Separator01";
            this.Separator01.Size = new System.Drawing.Size(132, 6);
            // 
            // EditMI
            // 
            this.EditMI.Name = "EditMI";
            this.EditMI.Size = new System.Drawing.Size(135, 22);
            this.EditMI.Text = "Edit Value...";
            this.EditMI.Click += new System.EventHandler(this.EditMI_Click);
            // 
            // DataListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "DataListCtrl";
            this.Controls.SetChildIndex(this.ItemsLV, 0);
            this.PopupMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        private System.Windows.Forms.ToolStripMenuItem UpdatesMI;
        private System.Windows.Forms.ToolStripMenuItem RefreshMI;
        private System.Windows.Forms.ToolStripMenuItem ClearMI;
        private System.Windows.Forms.ToolStripSeparator Separator01;
        private System.Windows.Forms.ToolStripMenuItem EditMI;
    }
}
