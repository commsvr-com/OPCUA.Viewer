/* ========================================================================
 * Copyright (c) 2005-2010 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

namespace CAS.OPC.UA.Viewer.Controls
{
    partial class ClientForm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ClientForm ) );
          this.MainMenu = new System.Windows.Forms.MenuStrip();
          this.FileMI = new System.Windows.Forms.ToolStripMenuItem();
          this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
          this.NewWindowMI = new System.Windows.Forms.ToolStripMenuItem();
          this.TaskMI = new System.Windows.Forms.ToolStripMenuItem();
          this.browseNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.Discovery_RegisterMI = new System.Windows.Forms.ToolStripMenuItem();
          this.PerformanceTestMI = new System.Windows.Forms.ToolStripMenuItem();
          this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.opcUaEbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.rSSFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.licenseInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.openLogsContainingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.unlockSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.StatusStrip = new System.Windows.Forms.StatusStrip();
          this.ServerUrlLB = new System.Windows.Forms.ToolStripStatusLabel();
          this.ServerStatusLB = new System.Windows.Forms.ToolStripStatusLabel();
          this.EndpointSelectorCTRL = new CAS.OPC.UA.Viewer.Client.Controls.EndpointSelectorCtrl();
          this.panel1 = new System.Windows.Forms.Panel();
          this.toolStripMain = new System.Windows.Forms.ToolStrip();
          this.toolStripMainNewSessionButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripMainDeleteSessionButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripMainSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripMainLoadSubscriptionButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripMainSaveSubscriptionButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripMainSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripMainBrowseASButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripMainReadValueButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripMainWriteValueButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripMainSeparator3 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripMainSupportButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripMainOpcUaEbookButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripMainAboutButton = new System.Windows.Forms.ToolStripButton();
          this.SessionsPanel = new System.Windows.Forms.SplitContainer();
          this.SessionsCTRL = new CAS.OPC.UA.Viewer.Controls.SessionTreeCtrl();
          this.NotificationsCTRL = new CAS.OPC.UA.Viewer.Controls.NotificationMessageListCtrl();
          this.tabControl = new System.Windows.Forms.TabControl();
          this.tabPageBrowse = new System.Windows.Forms.TabPage();
          this.BrowseCTRL = new CAS.OPC.UA.Viewer.Controls.BrowseTreeCtrl();
          this.tabPageSubscriptions = new System.Windows.Forms.TabPage();
          this.maintenanceControlComponent = new CAS.Lib.CodeProtect.MaintenanceControlComponent( this.components );
          this.MainMenu.SuspendLayout();
          this.StatusStrip.SuspendLayout();
          this.panel1.SuspendLayout();
          this.toolStripMain.SuspendLayout();
          this.SessionsPanel.Panel1.SuspendLayout();
          this.SessionsPanel.Panel2.SuspendLayout();
          this.SessionsPanel.SuspendLayout();
          this.tabControl.SuspendLayout();
          this.tabPageBrowse.SuspendLayout();
          this.tabPageSubscriptions.SuspendLayout();
          this.SuspendLayout();
          // 
          // MainMenu
          // 
          this.MainMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.FileMI,
            this.TaskMI,
            this.helpToolStripMenuItem} );
          this.MainMenu.Location = new System.Drawing.Point( 0, 0 );
          this.MainMenu.Name = "MainMenu";
          this.MainMenu.Size = new System.Drawing.Size( 1016, 24 );
          this.MainMenu.TabIndex = 1;
          this.MainMenu.Text = "MainMenu";
          // 
          // FileMI
          // 
          this.FileMI.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.FileExit,
            this.toolStripMenuItem1,
            this.NewWindowMI} );
          this.FileMI.Name = "FileMI";
          this.FileMI.Size = new System.Drawing.Size( 37, 20 );
          this.FileMI.Text = "File";
          // 
          // FileExit
          // 
          this.FileExit.Name = "FileExit";
          this.FileExit.Size = new System.Drawing.Size( 154, 22 );
          this.FileExit.Text = "Exit";
          this.FileExit.Click += new System.EventHandler( this.FileExit_Click );
          // 
          // toolStripMenuItem1
          // 
          this.toolStripMenuItem1.Name = "toolStripMenuItem1";
          this.toolStripMenuItem1.Size = new System.Drawing.Size( 151, 6 );
          // 
          // NewWindowMI
          // 
          this.NewWindowMI.Image = ( (System.Drawing.Image)( resources.GetObject( "NewWindowMI.Image" ) ) );
          this.NewWindowMI.Name = "NewWindowMI";
          this.NewWindowMI.Size = new System.Drawing.Size( 154, 22 );
          this.NewWindowMI.Text = "New Window...";
          this.NewWindowMI.Click += new System.EventHandler( this.NewWindowMI_Click );
          // 
          // TaskMI
          // 
          this.TaskMI.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.browseNetworkToolStripMenuItem,
            this.Discovery_RegisterMI,
            this.PerformanceTestMI} );
          this.TaskMI.Name = "TaskMI";
          this.TaskMI.Size = new System.Drawing.Size( 51, 20 );
          this.TaskMI.Text = "Server";
          // 
          // browseNetworkToolStripMenuItem
          // 
          this.browseNetworkToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "browseNetworkToolStripMenuItem.Image" ) ) );
          this.browseNetworkToolStripMenuItem.Name = "browseNetworkToolStripMenuItem";
          this.browseNetworkToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
          this.browseNetworkToolStripMenuItem.Text = "Browse network";
          this.browseNetworkToolStripMenuItem.Click += new System.EventHandler( this.DiscoverServersMI_Click );
          // 
          // Discovery_RegisterMI
          // 
          this.Discovery_RegisterMI.Image = ( (System.Drawing.Image)( resources.GetObject( "Discovery_RegisterMI.Image" ) ) );
          this.Discovery_RegisterMI.Name = "Discovery_RegisterMI";
          this.Discovery_RegisterMI.Size = new System.Drawing.Size( 158, 22 );
          this.Discovery_RegisterMI.Text = "Register server";
          this.Discovery_RegisterMI.Click += new System.EventHandler( this.Discovery_RegisterMI_Click );
          // 
          // PerformanceTestMI
          // 
          this.PerformanceTestMI.Image = ( (System.Drawing.Image)( resources.GetObject( "PerformanceTestMI.Image" ) ) );
          this.PerformanceTestMI.Name = "PerformanceTestMI";
          this.PerformanceTestMI.Size = new System.Drawing.Size( 158, 22 );
          this.PerformanceTestMI.Text = "Stack Test...";
          this.PerformanceTestMI.Click += new System.EventHandler( this.PerformanceTestMI_Click );
          // 
          // helpToolStripMenuItem
          // 
          this.helpToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.opcUaEbookToolStripMenuItem,
            this.homeToolStripMenuItem,
            this.supportToolStripMenuItem,
            this.rSSFeedToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem,
            this.licenseInformationToolStripMenuItem,
            this.openLogsContainingFolderToolStripMenuItem} );
          this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
          this.helpToolStripMenuItem.Size = new System.Drawing.Size( 44, 20 );
          this.helpToolStripMenuItem.Text = "Help";
          // 
          // opcUaEbookToolStripMenuItem
          // 
          this.opcUaEbookToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "opcUaEbookToolStripMenuItem.Image" ) ) );
          this.opcUaEbookToolStripMenuItem.Name = "opcUaEbookToolStripMenuItem";
          this.opcUaEbookToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
          this.opcUaEbookToolStripMenuItem.Text = "OPC UA ebook";
          this.opcUaEbookToolStripMenuItem.Click += new System.EventHandler( this.opcUaEbookToolStripMenuItem_Click );
          // 
          // homeToolStripMenuItem
          // 
          this.homeToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "homeToolStripMenuItem.Image" ) ) );
          this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
          this.homeToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
          this.homeToolStripMenuItem.Text = "Home";
          this.homeToolStripMenuItem.ToolTipText = "Open homepage";
          this.homeToolStripMenuItem.Click += new System.EventHandler( this.homeToolStripMenuItem_Click );
          // 
          // supportToolStripMenuItem
          // 
          this.supportToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "supportToolStripMenuItem.Image" ) ) );
          this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
          this.supportToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
          this.supportToolStripMenuItem.Text = "Support";
          this.supportToolStripMenuItem.Click += new System.EventHandler( this.supportToolStripMenuItem_Click );
          // 
          // rSSFeedToolStripMenuItem
          // 
          this.rSSFeedToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "rSSFeedToolStripMenuItem.Image" ) ) );
          this.rSSFeedToolStripMenuItem.Name = "rSSFeedToolStripMenuItem";
          this.rSSFeedToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
          this.rSSFeedToolStripMenuItem.Text = "RSS Feeds";
          this.rSSFeedToolStripMenuItem.Click += new System.EventHandler( this.rSSFeedToolStripMenuItem_Click );
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size( 223, 6 );
          // 
          // aboutToolStripMenuItem
          // 
          this.aboutToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "aboutToolStripMenuItem.Image" ) ) );
          this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
          this.aboutToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
          this.aboutToolStripMenuItem.Text = "About OPC UA Viewer";
          this.aboutToolStripMenuItem.Click += new System.EventHandler( this.aboutToolStripMenuItem_Click );
          // 
          // licenseInformationToolStripMenuItem
          // 
          this.licenseInformationToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "licenseInformationToolStripMenuItem.Image" ) ) );
          this.licenseInformationToolStripMenuItem.Name = "licenseInformationToolStripMenuItem";
          this.licenseInformationToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
          this.licenseInformationToolStripMenuItem.Text = "License information";
          this.licenseInformationToolStripMenuItem.Click += new System.EventHandler( this.licenseInformationToolStripMenuItem_Click );
          // 
          // openLogsContainingFolderToolStripMenuItem
          // 
          this.openLogsContainingFolderToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "openLogsContainingFolderToolStripMenuItem.Image" ) ) );
          this.openLogsContainingFolderToolStripMenuItem.Name = "openLogsContainingFolderToolStripMenuItem";
          this.openLogsContainingFolderToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
          this.openLogsContainingFolderToolStripMenuItem.Text = "Open logs containing folder";
          this.openLogsContainingFolderToolStripMenuItem.Click += new System.EventHandler( this.openLogsContainingFolderToolStripMenuItem_Click );
          // 
          // unlockSoftwareToolStripMenuItem
          // 
          this.unlockSoftwareToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "unlockSoftwareToolStripMenuItem.Image" ) ) );
          this.unlockSoftwareToolStripMenuItem.Name = "unlockSoftwareToolStripMenuItem";
          this.unlockSoftwareToolStripMenuItem.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.K ) ) );
          this.unlockSoftwareToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
          this.unlockSoftwareToolStripMenuItem.Text = "Enter the unlock code";
          this.unlockSoftwareToolStripMenuItem.Click += new System.EventHandler( this.unlockSoftwareToolStripMenuItem_Click );
          // 
          // StatusStrip
          // 
          this.StatusStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.ServerUrlLB,
            this.ServerStatusLB} );
          this.StatusStrip.Location = new System.Drawing.Point( 0, 712 );
          this.StatusStrip.Name = "StatusStrip";
          this.StatusStrip.Size = new System.Drawing.Size( 1016, 22 );
          this.StatusStrip.TabIndex = 6;
          this.StatusStrip.Text = "statusStrip1";
          // 
          // ServerUrlLB
          // 
          this.ServerUrlLB.Name = "ServerUrlLB";
          this.ServerUrlLB.Size = new System.Drawing.Size( 79, 17 );
          this.ServerUrlLB.Text = "Disconnected";
          // 
          // ServerStatusLB
          // 
          this.ServerStatusLB.Name = "ServerStatusLB";
          this.ServerStatusLB.Size = new System.Drawing.Size( 49, 17 );
          this.ServerStatusLB.Text = "00:00:00";
          // 
          // EndpointSelectorCTRL
          // 
          this.EndpointSelectorCTRL.Dock = System.Windows.Forms.DockStyle.Top;
          this.EndpointSelectorCTRL.Location = new System.Drawing.Point( 0, 24 );
          this.EndpointSelectorCTRL.MaximumSize = new System.Drawing.Size( 2048, 27 );
          this.EndpointSelectorCTRL.MinimumSize = new System.Drawing.Size( 100, 27 );
          this.EndpointSelectorCTRL.Name = "EndpointSelectorCTRL";
          this.EndpointSelectorCTRL.Padding = new System.Windows.Forms.Padding( 1, 0, 0, 0 );
          this.EndpointSelectorCTRL.SelectedEndpoint = null;
          this.EndpointSelectorCTRL.Size = new System.Drawing.Size( 1016, 27 );
          this.EndpointSelectorCTRL.TabIndex = 2;
          this.EndpointSelectorCTRL.EndpointsChanged += new System.EventHandler( this.EndpointSelectorCTRL_OnChange );
          this.EndpointSelectorCTRL.ConnectEndpoint += new CAS.OPC.UA.Viewer.Client.Controls.ConnectEndpointEventHandler( this.EndpointSelectorCTRL_ConnectEndpoint );
          // 
          // panel1
          // 
          this.panel1.Controls.Add( this.toolStripMain );
          this.panel1.Controls.Add( this.SessionsPanel );
          this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel1.Location = new System.Drawing.Point( 0, 24 );
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size( 1016, 688 );
          this.panel1.TabIndex = 7;
          // 
          // toolStripMain
          // 
          this.toolStripMain.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMainNewSessionButton,
            this.toolStripMainDeleteSessionButton,
            this.toolStripMainSeparator1,
            this.toolStripMainLoadSubscriptionButton,
            this.toolStripMainSaveSubscriptionButton,
            this.toolStripMainSeparator2,
            this.toolStripMainBrowseASButton,
            this.toolStripMainReadValueButton,
            this.toolStripMainWriteValueButton,
            this.toolStripMainSeparator3,
            this.toolStripMainSupportButton,
            this.toolStripMainOpcUaEbookButton,
            this.toolStripMainAboutButton} );
          this.toolStripMain.Location = new System.Drawing.Point( 0, 0 );
          this.toolStripMain.Name = "toolStripMain";
          this.toolStripMain.Size = new System.Drawing.Size( 1016, 25 );
          this.toolStripMain.TabIndex = 12;
          this.toolStripMain.Text = "toolStrip1";
          // 
          // toolStripMainNewSessionButton
          // 
          this.toolStripMainNewSessionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.toolStripMainNewSessionButton.Enabled = false;
          this.toolStripMainNewSessionButton.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMainNewSessionButton.Image" ) ) );
          this.toolStripMainNewSessionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripMainNewSessionButton.Name = "toolStripMainNewSessionButton";
          this.toolStripMainNewSessionButton.Size = new System.Drawing.Size( 23, 22 );
          this.toolStripMainNewSessionButton.Text = "Create new session";
          this.toolStripMainNewSessionButton.Click += new System.EventHandler( this.toolStripMainNewSessionButton_Click );
          // 
          // toolStripMainDeleteSessionButton
          // 
          this.toolStripMainDeleteSessionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.toolStripMainDeleteSessionButton.Enabled = false;
          this.toolStripMainDeleteSessionButton.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMainDeleteSessionButton.Image" ) ) );
          this.toolStripMainDeleteSessionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripMainDeleteSessionButton.Name = "toolStripMainDeleteSessionButton";
          this.toolStripMainDeleteSessionButton.Size = new System.Drawing.Size( 23, 22 );
          this.toolStripMainDeleteSessionButton.Text = "Delete session";
          this.toolStripMainDeleteSessionButton.Click += new System.EventHandler( this.toolStripMainDeleteSessionButton_Click );
          // 
          // toolStripMainSeparator1
          // 
          this.toolStripMainSeparator1.Name = "toolStripMainSeparator1";
          this.toolStripMainSeparator1.Size = new System.Drawing.Size( 6, 25 );
          // 
          // toolStripMainLoadSubscriptionButton
          // 
          this.toolStripMainLoadSubscriptionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.toolStripMainLoadSubscriptionButton.Enabled = false;
          this.toolStripMainLoadSubscriptionButton.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMainLoadSubscriptionButton.Image" ) ) );
          this.toolStripMainLoadSubscriptionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripMainLoadSubscriptionButton.Name = "toolStripMainLoadSubscriptionButton";
          this.toolStripMainLoadSubscriptionButton.Size = new System.Drawing.Size( 23, 22 );
          this.toolStripMainLoadSubscriptionButton.Text = "Load subscriptions";
          this.toolStripMainLoadSubscriptionButton.Click += new System.EventHandler( this.toolStripMainLoadSubscriptionButton_Click );
          // 
          // toolStripMainSaveSubscriptionButton
          // 
          this.toolStripMainSaveSubscriptionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.toolStripMainSaveSubscriptionButton.Enabled = false;
          this.toolStripMainSaveSubscriptionButton.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMainSaveSubscriptionButton.Image" ) ) );
          this.toolStripMainSaveSubscriptionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripMainSaveSubscriptionButton.Name = "toolStripMainSaveSubscriptionButton";
          this.toolStripMainSaveSubscriptionButton.Size = new System.Drawing.Size( 23, 22 );
          this.toolStripMainSaveSubscriptionButton.Text = "Save subscriptions";
          this.toolStripMainSaveSubscriptionButton.Click += new System.EventHandler( this.toolStripMainSaveSubscriptionButton_Click );
          // 
          // toolStripMainSeparator2
          // 
          this.toolStripMainSeparator2.Name = "toolStripMainSeparator2";
          this.toolStripMainSeparator2.Size = new System.Drawing.Size( 6, 25 );
          // 
          // toolStripMainBrowseASButton
          // 
          this.toolStripMainBrowseASButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.toolStripMainBrowseASButton.Enabled = false;
          this.toolStripMainBrowseASButton.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMainBrowseASButton.Image" ) ) );
          this.toolStripMainBrowseASButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripMainBrowseASButton.Name = "toolStripMainBrowseASButton";
          this.toolStripMainBrowseASButton.Size = new System.Drawing.Size( 23, 22 );
          this.toolStripMainBrowseASButton.Text = "Browse Address Space";
          this.toolStripMainBrowseASButton.Click += new System.EventHandler( this.toolStripMainBrowseASButton_Click );
          // 
          // toolStripMainReadValueButton
          // 
          this.toolStripMainReadValueButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.toolStripMainReadValueButton.Enabled = false;
          this.toolStripMainReadValueButton.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMainReadValueButton.Image" ) ) );
          this.toolStripMainReadValueButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripMainReadValueButton.Name = "toolStripMainReadValueButton";
          this.toolStripMainReadValueButton.Size = new System.Drawing.Size( 23, 22 );
          this.toolStripMainReadValueButton.Text = "Read Items";
          this.toolStripMainReadValueButton.Click += new System.EventHandler( this.toolStripMainReadValueButton_Click );
          // 
          // toolStripMainWriteValueButton
          // 
          this.toolStripMainWriteValueButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.toolStripMainWriteValueButton.Enabled = false;
          this.toolStripMainWriteValueButton.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMainWriteValueButton.Image" ) ) );
          this.toolStripMainWriteValueButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripMainWriteValueButton.Name = "toolStripMainWriteValueButton";
          this.toolStripMainWriteValueButton.Size = new System.Drawing.Size( 23, 22 );
          this.toolStripMainWriteValueButton.Text = "Write Items";
          this.toolStripMainWriteValueButton.Click += new System.EventHandler( this.toolStripMainWriteValueButton_Click );
          // 
          // toolStripMainSeparator3
          // 
          this.toolStripMainSeparator3.Name = "toolStripMainSeparator3";
          this.toolStripMainSeparator3.Size = new System.Drawing.Size( 6, 25 );
          // 
          // toolStripMainSupportButton
          // 
          this.toolStripMainSupportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.toolStripMainSupportButton.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMainSupportButton.Image" ) ) );
          this.toolStripMainSupportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripMainSupportButton.Name = "toolStripMainSupportButton";
          this.toolStripMainSupportButton.Size = new System.Drawing.Size( 23, 22 );
          this.toolStripMainSupportButton.Text = "Feed back and technical support product email.";
          this.toolStripMainSupportButton.Click += new System.EventHandler( this.toolStripMainSupportButton_Click );
          // 
          // toolStripMainOpcUaEbookButton
          // 
          this.toolStripMainOpcUaEbookButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.toolStripMainOpcUaEbookButton.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMainOpcUaEbookButton.Image" ) ) );
          this.toolStripMainOpcUaEbookButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripMainOpcUaEbookButton.Name = "toolStripMainOpcUaEbookButton";
          this.toolStripMainOpcUaEbookButton.Size = new System.Drawing.Size( 23, 22 );
          this.toolStripMainOpcUaEbookButton.Text = "Open OPC UA ebook";
          this.toolStripMainOpcUaEbookButton.Click += new System.EventHandler( this.toolStripMainOpcUaEbookButton_Click );
          // 
          // toolStripMainAboutButton
          // 
          this.toolStripMainAboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.toolStripMainAboutButton.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMainAboutButton.Image" ) ) );
          this.toolStripMainAboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripMainAboutButton.Name = "toolStripMainAboutButton";
          this.toolStripMainAboutButton.Size = new System.Drawing.Size( 23, 22 );
          this.toolStripMainAboutButton.Text = "Show About dialog";
          this.toolStripMainAboutButton.Click += new System.EventHandler( this.aboutToolStripMenuItem_Click );
          // 
          // SessionsPanel
          // 
          this.SessionsPanel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                      | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.SessionsPanel.Location = new System.Drawing.Point( 0, 28 );
          this.SessionsPanel.Name = "SessionsPanel";
          // 
          // SessionsPanel.Panel1
          // 
          this.SessionsPanel.Panel1.Controls.Add( this.SessionsCTRL );
          // 
          // SessionsPanel.Panel2
          // 
          this.SessionsPanel.Panel2.Controls.Add( this.tabControl );
          this.SessionsPanel.Size = new System.Drawing.Size( 1016, 657 );
          this.SessionsPanel.SplitterDistance = 298;
          this.SessionsPanel.TabIndex = 11;
          // 
          // SessionsCTRL
          // 
          this.SessionsCTRL.AddressSpaceCtrl = null;
          this.SessionsCTRL.Configuration = null;
          this.SessionsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.SessionsCTRL.EnableDragging = false;
          this.SessionsCTRL.Location = new System.Drawing.Point( 0, 0 );
          this.SessionsCTRL.MessageContext = null;
          this.SessionsCTRL.Name = "SessionsCTRL";
          this.SessionsCTRL.NotificationMessagesCtrl = this.NotificationsCTRL;
          this.SessionsCTRL.ServerStatusCtrl = null;
          this.SessionsCTRL.Size = new System.Drawing.Size( 298, 630 );
          this.SessionsCTRL.TabIndex = 0;
          // 
          // NotificationsCTRL
          // 
          this.NotificationsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.NotificationsCTRL.Instructions = "Create a subscription to see notifications";
          this.NotificationsCTRL.Location = new System.Drawing.Point( 3, 3 );
          this.NotificationsCTRL.MaxMessageCount = 100;
          this.NotificationsCTRL.Name = "NotificationsCTRL";
          this.NotificationsCTRL.Size = new System.Drawing.Size( 700, 598 );
          this.NotificationsCTRL.TabIndex = 1;
          // 
          // tabControl
          // 
          this.tabControl.Controls.Add( this.tabPageBrowse );
          this.tabControl.Controls.Add( this.tabPageSubscriptions );
          this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tabControl.Location = new System.Drawing.Point( 0, 0 );
          this.tabControl.Name = "tabControl";
          this.tabControl.SelectedIndex = 0;
          this.tabControl.Size = new System.Drawing.Size( 714, 657 );
          this.tabControl.TabIndex = 0;
          this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler( this.tabControl_Selected );
          // 
          // tabPageBrowse
          // 
          this.tabPageBrowse.Controls.Add( this.BrowseCTRL );
          this.tabPageBrowse.Location = new System.Drawing.Point( 4, 22 );
          this.tabPageBrowse.Name = "tabPageBrowse";
          this.tabPageBrowse.Padding = new System.Windows.Forms.Padding( 3 );
          this.tabPageBrowse.Size = new System.Drawing.Size( 706, 631 );
          this.tabPageBrowse.TabIndex = 0;
          this.tabPageBrowse.Text = "Browse server";
          this.tabPageBrowse.UseVisualStyleBackColor = true;
          // 
          // BrowseCTRL
          // 
          this.BrowseCTRL.AttributesCtrl = null;
          this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
          this.BrowseCTRL.EnableDragging = false;
          this.BrowseCTRL.Location = new System.Drawing.Point( 3, 3 );
          this.BrowseCTRL.Name = "BrowseCTRL";
          this.BrowseCTRL.SessionTreeCtrl = this.SessionsCTRL;
          this.BrowseCTRL.Size = new System.Drawing.Size( 700, 598 );
          this.BrowseCTRL.TabIndex = 1;
          // 
          // tabPageSubscriptions
          // 
          this.tabPageSubscriptions.Controls.Add( this.NotificationsCTRL );
          this.tabPageSubscriptions.Location = new System.Drawing.Point( 4, 22 );
          this.tabPageSubscriptions.Name = "tabPageSubscriptions";
          this.tabPageSubscriptions.Padding = new System.Windows.Forms.Padding( 3 );
          this.tabPageSubscriptions.Size = new System.Drawing.Size( 706, 604 );
          this.tabPageSubscriptions.TabIndex = 1;
          this.tabPageSubscriptions.Text = "Subscriptions";
          this.tabPageSubscriptions.UseVisualStyleBackColor = true;
          // 
          // ClientForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 1016, 734 );
          this.Controls.Add( this.panel1 );
          this.Controls.Add( this.StatusStrip );
          this.Controls.Add( this.EndpointSelectorCTRL );
          this.Controls.Add( this.MainMenu );
          this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
          this.MainMenuStrip = this.MainMenu;
          this.Name = "ClientForm";
          this.Text = "OPC UA Viewer";
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.MainForm_FormClosing );
          this.MainMenu.ResumeLayout( false );
          this.MainMenu.PerformLayout();
          this.StatusStrip.ResumeLayout( false );
          this.StatusStrip.PerformLayout();
          this.panel1.ResumeLayout( false );
          this.panel1.PerformLayout();
          this.toolStripMain.ResumeLayout( false );
          this.toolStripMain.PerformLayout();
          this.SessionsPanel.Panel1.ResumeLayout( false );
          this.SessionsPanel.Panel2.ResumeLayout( false );
          this.SessionsPanel.ResumeLayout( false );
          this.tabControl.ResumeLayout( false );
          this.tabPageBrowse.ResumeLayout( false );
          this.tabPageSubscriptions.ResumeLayout( false );
          this.ResumeLayout( false );
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem TaskMI;
        private CAS.OPC.UA.Viewer.Client.Controls.EndpointSelectorCtrl EndpointSelectorCTRL;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ServerUrlLB;
        private System.Windows.Forms.ToolStripMenuItem PerformanceTestMI;
        private System.Windows.Forms.ToolStripMenuItem FileMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem FileExit;
        private System.Windows.Forms.ToolStripStatusLabel ServerStatusLB;
        private System.Windows.Forms.ToolStripMenuItem NewWindowMI;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rSSFeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Discovery_RegisterMI;
        private System.Windows.Forms.ToolStripMenuItem opcUaEbookToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripMainNewSessionButton;
        private System.Windows.Forms.ToolStripButton toolStripMainDeleteSessionButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMainSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripMainLoadSubscriptionButton;
        private System.Windows.Forms.ToolStripButton toolStripMainSaveSubscriptionButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMainSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripMainBrowseASButton;
        private System.Windows.Forms.ToolStripButton toolStripMainReadValueButton;
        private System.Windows.Forms.ToolStripButton toolStripMainWriteValueButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMainSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripMainSupportButton;
        private System.Windows.Forms.ToolStripButton toolStripMainOpcUaEbookButton;
        private System.Windows.Forms.ToolStripButton toolStripMainAboutButton;
        private System.Windows.Forms.SplitContainer SessionsPanel;
        protected SessionTreeCtrl SessionsCTRL;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageBrowse;
        protected BrowseTreeCtrl BrowseCTRL;
        private System.Windows.Forms.TabPage tabPageSubscriptions;
        private NotificationMessageListCtrl NotificationsCTRL;
        private System.Windows.Forms.ToolStripMenuItem licenseInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogsContainingFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlockSoftwareToolStripMenuItem;
        private CAS.Lib.CodeProtect.MaintenanceControlComponent maintenanceControlComponent;
    }
}
