//<summary>
//  Title   : Base list
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
    partial class BaseListCtrl
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
            this.ItemsLV = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ItemsLV
            // 
            this.ItemsLV.AllowDrop = true;
            this.ItemsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsLV.FullRowSelect = true;
            this.ItemsLV.Location = new System.Drawing.Point(0, 0);
            this.ItemsLV.Name = "ItemsLV";
            this.ItemsLV.Size = new System.Drawing.Size(541, 412);
            this.ItemsLV.TabIndex = 0;
            this.ItemsLV.UseCompatibleStateImageBehavior = false;
            this.ItemsLV.View = System.Windows.Forms.View.Details;
            this.ItemsLV.DragEnter += new System.Windows.Forms.DragEventHandler(this.ItemsLV_DragEnter);
            this.ItemsLV.DragDrop += new System.Windows.Forms.DragEventHandler(this.ItemsLV_DragDrop);
            this.ItemsLV.DoubleClick += new System.EventHandler(this.ItemsLV_DoubleClick);
            this.ItemsLV.SelectedIndexChanged += new System.EventHandler(this.ItemsLV_SelectedIndexChanged);
            this.ItemsLV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ItemsLV_MouseUp);
            this.ItemsLV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ItemsLV_MouseMove);
            this.ItemsLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ItemsLV_MouseDown);
            // 
            // BaseListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ItemsLV);
            this.Name = "BaseListCtrl";
            this.Size = new System.Drawing.Size(541, 412);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
