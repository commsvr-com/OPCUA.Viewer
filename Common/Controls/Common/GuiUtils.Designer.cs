//<summary>
//  Title   : Gui utils
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
    partial class GuiUtils
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
          this.components = new System.ComponentModel.Container();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( GuiUtils ) );
          this.ImageList = new System.Windows.Forms.ImageList( this.components );
          this.SuspendLayout();
          // 
          // ImageList
          // 
          ImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "ImageList.ImageStream" ) ) );
          ImageList.TransparentColor = System.Drawing.Color.Transparent;
          ImageList.Images.SetKeyName( 0, "SimpleItem" );
          ImageList.Images.SetKeyName( 1, "Object" );
          ImageList.Images.SetKeyName( 2, "FolderOld" );
          ImageList.Images.SetKeyName( 3, "Area" );
          ImageList.Images.SetKeyName( 4, "Variable" );
          ImageList.Images.SetKeyName( 5, "Property" );
          ImageList.Images.SetKeyName( 6, "Method" );
          ImageList.Images.SetKeyName( 7, "ReferenceType" );
          ImageList.Images.SetKeyName( 8, "DataType" );
          ImageList.Images.SetKeyName( 9, "View" );
          ImageList.Images.SetKeyName( 10, "ExpandPlus" );
          ImageList.Images.SetKeyName( 11, "ExpandMinus" );
          ImageList.Images.SetKeyName( 12, "VariableType" );
          ImageList.Images.SetKeyName( 13, "ObjectType" );
          ImageList.Images.SetKeyName( 14, "Info" );
          ImageList.Images.SetKeyName( 15, "Server" );
          ImageList.Images.SetKeyName( 16, "ServerStopped" );
          ImageList.Images.SetKeyName( 17, "Computer" );
          ImageList.Images.SetKeyName( 18, "Network" );
          ImageList.Images.SetKeyName( 19, "Folder" );
          ImageList.Images.SetKeyName( 20, "SelectedFolder" );
          ImageList.Images.SetKeyName( 21, "Process" );
          ImageList.Images.SetKeyName( 22, "Certificate" );
          ImageList.Images.SetKeyName( 23, "CertificateStore" );
          ImageList.Images.SetKeyName( 24, "Users" );
          ImageList.Images.SetKeyName( 25, "Service" );
          ImageList.Images.SetKeyName( 26, "InvalidCertificate" );
          ImageList.Images.SetKeyName( 27, "Drive" );
          ImageList.Images.SetKeyName( 28, "ServiceGroup" );
          ImageList.Images.SetKeyName( 29, "Desktop" );
          ImageList.Images.SetKeyName( 30, "SingleUser" );
          ImageList.Images.SetKeyName( 31, "UserGroup" );
          ImageList.Images.SetKeyName( 32, "RedCross" );
          ImageList.Images.SetKeyName( 33, "GreenCheck" );
          ImageList.Images.SetKeyName( 34, "UsersRedCross" );
          // 
          // GuiUtils
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Name = "GuiUtils";
          this.ResumeLayout( false );

        }

        #endregion
    }
}
