namespace DinoDoc
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.flSourceDig = new System.Windows.Forms.FolderBrowserDialog();
            this.directoryEntry = new System.DirectoryServices.DirectoryEntry();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvStatus = new System.Windows.Forms.ListView();
            this.tvcSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvcFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvcTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvcStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContextMenuLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuLog_SaveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_clearAllLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.grpboxAuthentication = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserDomain = new System.Windows.Forms.TextBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.rdProvide = new System.Windows.Forms.RadioButton();
            this.rdDefault = new System.Windows.Forms.RadioButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFiles_SaveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFile_Print = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFile_PrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTools_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp_About = new System.Windows.Forms.ToolStripMenuItem();
            this.btUpload = new System.Windows.Forms.Button();
            this.txtDestinationURL = new System.Windows.Forms.TextBox();
            this.lbDesPath = new System.Windows.Forms.Label();
            this.btSourceFolder = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.lbSource = new System.Windows.Forms.Label();
            this.LogStatus = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.MenuFile_ClearLogs = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ContextMenuLog.SuspendLayout();
            this.grpboxAuthentication.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // flSourceDig
            // 
            this.flSourceDig.Description = "Source Location for Import";
            this.flSourceDig.ShowNewFolderButton = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvStatus);
            this.splitContainer1.Panel1.Controls.Add(this.grpboxAuthentication);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip);
            this.splitContainer1.Panel1.Controls.Add(this.btUpload);
            this.splitContainer1.Panel1.Controls.Add(this.txtDestinationURL);
            this.splitContainer1.Panel1.Controls.Add(this.lbDesPath);
            this.splitContainer1.Panel1.Controls.Add(this.btSourceFolder);
            this.splitContainer1.Panel1.Controls.Add(this.txtSourcePath);
            this.splitContainer1.Panel1.Controls.Add(this.lbSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LogStatus);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(11, 5, 11, 5);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 662);
            this.splitContainer1.SplitterDistance = 477;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvStatus
            // 
            this.lvStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tvcSource,
            this.tvcFile,
            this.tvcTarget,
            this.tvcStatus});
            this.lvStatus.ContextMenuStrip = this.ContextMenuLog;
            this.lvStatus.FullRowSelect = true;
            this.lvStatus.Location = new System.Drawing.Point(3, 122);
            this.lvStatus.Margin = new System.Windows.Forms.Padding(1);
            this.lvStatus.Name = "lvStatus";
            this.lvStatus.Size = new System.Drawing.Size(1275, 350);
            this.lvStatus.TabIndex = 11;
            this.lvStatus.UseCompatibleStateImageBehavior = false;
            this.lvStatus.View = System.Windows.Forms.View.Details;
            // 
            // tvcSource
            // 
            this.tvcSource.Text = "Source";
            this.tvcSource.Width = 325;
            // 
            // tvcFile
            // 
            this.tvcFile.Text = "File";
            this.tvcFile.Width = 348;
            // 
            // tvcTarget
            // 
            this.tvcTarget.Text = "Target";
            this.tvcTarget.Width = 409;
            // 
            // tvcStatus
            // 
            this.tvcStatus.Text = "Status";
            this.tvcStatus.Width = 144;
            // 
            // ContextMenuLog
            // 
            this.ContextMenuLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuLog_SaveLog,
            this.toolStripSeparator6,
            this.toolStrip_clearAllLogs});
            this.ContextMenuLog.Name = "contextMenuStrip";
            this.ContextMenuLog.Size = new System.Drawing.Size(147, 54);
            // 
            // ContextMenuLog_SaveLog
            // 
            this.ContextMenuLog_SaveLog.Name = "ContextMenuLog_SaveLog";
            this.ContextMenuLog_SaveLog.Size = new System.Drawing.Size(146, 22);
            this.ContextMenuLog_SaveLog.Text = "Save Log...";
            this.ContextMenuLog_SaveLog.Click += new System.EventHandler(this.MenuFile_SaveLog_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(143, 6);
            // 
            // toolStrip_clearAllLogs
            // 
            this.toolStrip_clearAllLogs.Name = "toolStrip_clearAllLogs";
            this.toolStrip_clearAllLogs.Size = new System.Drawing.Size(146, 22);
            this.toolStrip_clearAllLogs.Text = "Clear All Logs";
            this.toolStrip_clearAllLogs.Click += new System.EventHandler(this.MenuFile_ClearLogs_Clicks);
            // 
            // grpboxAuthentication
            // 
            this.grpboxAuthentication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpboxAuthentication.Controls.Add(this.label1);
            this.grpboxAuthentication.Controls.Add(this.label3);
            this.grpboxAuthentication.Controls.Add(this.label2);
            this.grpboxAuthentication.Controls.Add(this.txtUserDomain);
            this.grpboxAuthentication.Controls.Add(this.txtUserPassword);
            this.grpboxAuthentication.Controls.Add(this.txtUserName);
            this.grpboxAuthentication.Controls.Add(this.rdProvide);
            this.grpboxAuthentication.Controls.Add(this.rdDefault);
            this.grpboxAuthentication.Location = new System.Drawing.Point(992, 15);
            this.grpboxAuthentication.Name = "grpboxAuthentication";
            this.grpboxAuthentication.Size = new System.Drawing.Size(276, 101);
            this.grpboxAuthentication.TabIndex = 8;
            this.grpboxAuthentication.TabStop = false;
            this.grpboxAuthentication.Text = "Authentication Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "D&omain";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "User &Name";
            // 
            // txtUserDomain
            // 
            this.txtUserDomain.Enabled = false;
            this.txtUserDomain.Location = new System.Drawing.Point(91, 68);
            this.txtUserDomain.Name = "txtUserDomain";
            this.txtUserDomain.Size = new System.Drawing.Size(140, 20);
            this.txtUserDomain.TabIndex = 7;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Enabled = false;
            this.txtUserPassword.Location = new System.Drawing.Point(91, 46);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(140, 20);
            this.txtUserPassword.TabIndex = 5;
            this.txtUserPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.AccessibleName = "";
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(91, 23);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(140, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // rdProvide
            // 
            this.rdProvide.AutoSize = true;
            this.rdProvide.Location = new System.Drawing.Point(196, 0);
            this.rdProvide.Name = "rdProvide";
            this.rdProvide.Size = new System.Drawing.Size(57, 17);
            this.rdProvide.TabIndex = 1;
            this.rdProvide.Text = "S&upply";
            this.rdProvide.UseVisualStyleBackColor = true;
            this.rdProvide.CheckedChanged += new System.EventHandler(this.rdProvide_CheckedChanged);
            // 
            // rdDefault
            // 
            this.rdDefault.AutoSize = true;
            this.rdDefault.Checked = true;
            this.rdDefault.Location = new System.Drawing.Point(139, 0);
            this.rdDefault.Name = "rdDefault";
            this.rdDefault.Size = new System.Drawing.Size(59, 17);
            this.rdDefault.TabIndex = 0;
            this.rdDefault.TabStop = true;
            this.rdDefault.Text = "D&efault";
            this.rdDefault.UseVisualStyleBackColor = true;
            this.rdDefault.CheckedChanged += new System.EventHandler(this.rdDefault_CheckedChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuTools,
            this.MenuHelp});
            this.menuStrip.Location = new System.Drawing.Point(3, 3);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(137, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile_ClearLogs,
            this.MenuFiles_SaveLog,
            this.toolStripSeparator1,
            this.MenuFile_Print,
            this.MenuFile_PrintPreview,
            this.toolStripSeparator2,
            this.MenuFile_Exit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(37, 20);
            this.MenuFile.Text = "&File";
            // 
            // MenuFiles_SaveLog
            // 
            this.MenuFiles_SaveLog.Name = "MenuFiles_SaveLog";
            this.MenuFiles_SaveLog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuFiles_SaveLog.Size = new System.Drawing.Size(170, 22);
            this.MenuFiles_SaveLog.Text = "Save &Log...";
            this.MenuFiles_SaveLog.Click += new System.EventHandler(this.MenuFile_SaveLog_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // MenuFile_Print
            // 
            this.MenuFile_Print.Image = ((System.Drawing.Image)(resources.GetObject("MenuFile_Print.Image")));
            this.MenuFile_Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFile_Print.Name = "MenuFile_Print";
            this.MenuFile_Print.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.MenuFile_Print.Size = new System.Drawing.Size(170, 22);
            this.MenuFile_Print.Text = "&Print";
            this.MenuFile_Print.Click += new System.EventHandler(this.MenuFile_Print_Click);
            // 
            // MenuFile_PrintPreview
            // 
            this.MenuFile_PrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("MenuFile_PrintPreview.Image")));
            this.MenuFile_PrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFile_PrintPreview.Name = "MenuFile_PrintPreview";
            this.MenuFile_PrintPreview.Size = new System.Drawing.Size(170, 22);
            this.MenuFile_PrintPreview.Text = "Print Pre&view";
            this.MenuFile_PrintPreview.Click += new System.EventHandler(this.MenuFile_PrintPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // MenuFile_Exit
            // 
            this.MenuFile_Exit.Name = "MenuFile_Exit";
            this.MenuFile_Exit.Size = new System.Drawing.Size(170, 22);
            this.MenuFile_Exit.Text = "E&xit";
            this.MenuFile_Exit.Click += new System.EventHandler(this.MenuFile_Exit_Click);
            // 
            // MenuTools
            // 
            this.MenuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTools_Options});
            this.MenuTools.Name = "MenuTools";
            this.MenuTools.Size = new System.Drawing.Size(48, 20);
            this.MenuTools.Text = "&Tools";
            // 
            // MenuTools_Options
            // 
            this.MenuTools_Options.Image = ((System.Drawing.Image)(resources.GetObject("MenuTools_Options.Image")));
            this.MenuTools_Options.Name = "MenuTools_Options";
            this.MenuTools_Options.Size = new System.Drawing.Size(116, 22);
            this.MenuTools_Options.Text = "&Options";
            this.MenuTools_Options.Click += new System.EventHandler(this.MenuTools_Options_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHelp_About});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(44, 20);
            this.MenuHelp.Text = "&Help";
            // 
            // MenuHelp_About
            // 
            this.MenuHelp_About.Name = "MenuHelp_About";
            this.MenuHelp_About.Size = new System.Drawing.Size(152, 22);
            this.MenuHelp_About.Text = "&About...";
            this.MenuHelp_About.Click += new System.EventHandler(this.MenuHelp_About_Click);
            // 
            // btUpload
            // 
            this.btUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpload.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btUpload.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btUpload.Image = global::DinoDoc.Properties.Resources.Upload_Green_48x48;
            this.btUpload.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btUpload.Location = new System.Drawing.Point(875, 23);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(78, 77);
            this.btUpload.TabIndex = 7;
            this.btUpload.Text = "Upload";
            this.btUpload.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btUpload.UseVisualStyleBackColor = true;
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // txtDestinationURL
            // 
            this.txtDestinationURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationURL.Location = new System.Drawing.Point(116, 73);
            this.txtDestinationURL.Name = "txtDestinationURL";
            this.txtDestinationURL.Size = new System.Drawing.Size(739, 20);
            this.txtDestinationURL.TabIndex = 6;
            this.txtDestinationURL.Text = "http://stark/Shared Documents";
            // 
            // lbDesPath
            // 
            this.lbDesPath.AutoSize = true;
            this.lbDesPath.Location = new System.Drawing.Point(19, 73);
            this.lbDesPath.Name = "lbDesPath";
            this.lbDesPath.Size = new System.Drawing.Size(85, 13);
            this.lbDesPath.TabIndex = 5;
            this.lbDesPath.Text = "&Destination URL";
            // 
            // btSourceFolder
            // 
            this.btSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSourceFolder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSourceFolder.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btSourceFolder.Image = global::DinoDoc.Properties.Resources.SourceFolder;
            this.btSourceFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSourceFolder.Location = new System.Drawing.Point(814, 23);
            this.btSourceFolder.Name = "btSourceFolder";
            this.btSourceFolder.Size = new System.Drawing.Size(41, 44);
            this.btSourceFolder.TabIndex = 4;
            this.btSourceFolder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSourceFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btSourceFolder.UseVisualStyleBackColor = true;
            this.btSourceFolder.Click += new System.EventHandler(this.btSourceFolder_Click);
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.AccessibleName = "sourcePath";
            this.txtSourcePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourcePath.Location = new System.Drawing.Point(117, 36);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(691, 20);
            this.txtSourcePath.TabIndex = 3;
            this.txtSourcePath.Text = "c:\\temp";
            // 
            // lbSource
            // 
            this.lbSource.AutoSize = true;
            this.lbSource.Location = new System.Drawing.Point(38, 36);
            this.lbSource.Name = "lbSource";
            this.lbSource.Size = new System.Drawing.Size(66, 13);
            this.lbSource.TabIndex = 2;
            this.lbSource.Text = "&Source Path";
            // 
            // LogStatus
            // 
            this.LogStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogStatus.ContextMenuStrip = this.ContextMenuLog;
            this.LogStatus.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogStatus.HideSelection = false;
            this.LogStatus.Location = new System.Drawing.Point(2, 1);
            this.LogStatus.Name = "LogStatus";
            this.LogStatus.Size = new System.Drawing.Size(1276, 153);
            this.LogStatus.TabIndex = 10;
            this.LogStatus.Text = "";
            this.LogStatus.WordWrap = false;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.FileName = "DinoDoc Import";
            this.saveFileDialog.Filter = "Log files|*.rtf|All files|*.*";
            this.saveFileDialog.InitialDirectory = "Desktop";
            this.saveFileDialog.Title = "Save Import Log";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.StripProgressBar});
            this.StatusStrip.Location = new System.Drawing.Point(0, 640);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1284, 22);
            this.StatusStrip.TabIndex = 13;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(1269, 17);
            this.StatusLabel.Spring = true;
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // StripProgressBar
            // 
            this.StripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StripProgressBar.Name = "StripProgressBar";
            this.StripProgressBar.Size = new System.Drawing.Size(500, 16);
            this.StripProgressBar.Visible = false;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(100, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // MenuFile_ClearLogs
            // 
            this.MenuFile_ClearLogs.Name = "MenuFile_ClearLogs";
            this.MenuFile_ClearLogs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.MenuFile_ClearLogs.Size = new System.Drawing.Size(170, 22);
            this.MenuFile_ClearLogs.Text = "&Clear Log";
            this.MenuFile_ClearLogs.Click += new System.EventHandler(this.MenuFile_ClearLogs_Clicks);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 662);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DinoDoc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ContextMenuLog.ResumeLayout(false);
            this.grpboxAuthentication.ResumeLayout(false);
            this.grpboxAuthentication.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog flSourceDig;
        private System.DirectoryServices.DirectoryEntry directoryEntry;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpboxAuthentication;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.RadioButton rdProvide;
        private System.Windows.Forms.RadioButton rdDefault;
        private System.Windows.Forms.Button btUpload;
        private System.Windows.Forms.TextBox txtDestinationURL;
        private System.Windows.Forms.Label lbDesPath;
        private System.Windows.Forms.Button btSourceFolder;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Label lbSource;
        private System.Windows.Forms.RichTextBox LogStatus;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ContextMenuStrip ContextMenuLog;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuLog_SaveLog;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar StripProgressBar;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFiles_SaveLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile_Print;
        private System.Windows.Forms.ToolStripMenuItem MenuFile_PrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuFile_Exit;
        private System.Windows.Forms.ToolStripMenuItem MenuTools;
        private System.Windows.Forms.ToolStripMenuItem MenuTools_Options;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp_About;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserDomain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_clearAllLogs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView lvStatus;
        private System.Windows.Forms.ColumnHeader tvcSource;
        private System.Windows.Forms.ColumnHeader tvcFile;
        private System.Windows.Forms.ColumnHeader tvcTarget;
        private System.Windows.Forms.ColumnHeader tvcStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem MenuFile_ClearLogs;

    }
}

