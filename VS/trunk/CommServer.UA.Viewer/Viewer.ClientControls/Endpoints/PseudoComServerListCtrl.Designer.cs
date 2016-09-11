//<summary>
//  Title   : PseudoComServer list
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
    partial class PseudoComServerListCtrl
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
            this.NewMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigureMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigureEndpointMI = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemsLV
            // 
            this.ItemsLV.ContextMenuStrip = this.PopupMenu;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMI,
            this.ConfigureMI,
            this.ConfigureEndpointMI,
            this.DeleteMI});
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(232, 114);
            // 
            // NewMI
            // 
            this.NewMI.Name = "NewMI";
            this.NewMI.Size = new System.Drawing.Size(231, 22);
            this.NewMI.Text = "Discover Servers...";
            this.NewMI.Click += new System.EventHandler(this.NewMI_Click);
            // 
            // ConfigureMI
            // 
            this.ConfigureMI.Name = "ConfigureMI";
            this.ConfigureMI.Size = new System.Drawing.Size(231, 22);
            this.ConfigureMI.Text = "Edit COM Identity...";
            this.ConfigureMI.Click += new System.EventHandler(this.ConfigureMI_Click);
            // 
            // ConfigureEndpointMI
            // 
            this.ConfigureEndpointMI.Name = "ConfigureEndpointMI";
            this.ConfigureEndpointMI.Size = new System.Drawing.Size(231, 22);
            this.ConfigureEndpointMI.Text = "Edit Endpoint Configuration...";
            this.ConfigureEndpointMI.Click += new System.EventHandler(this.ConfigureEndpointMI_Click);
            // 
            // DeleteMI
            // 
            this.DeleteMI.Name = "DeleteMI";
            this.DeleteMI.Size = new System.Drawing.Size(231, 22);
            this.DeleteMI.Text = "Delete";
            this.DeleteMI.Click += new System.EventHandler(this.DeleteMI_Click);
            // 
            // PseudoComServerListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "PseudoComServerListCtrl";
            this.Controls.SetChildIndex(this.ItemsLV, 0);
            this.PopupMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        private System.Windows.Forms.ToolStripMenuItem NewMI;
        private System.Windows.Forms.ToolStripMenuItem ConfigureMI;
        private System.Windows.Forms.ToolStripMenuItem DeleteMI;
        private System.Windows.Forms.ToolStripMenuItem ConfigureEndpointMI;

    }
}
