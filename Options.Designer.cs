namespace DinoDoc
{
    partial class frmOptions
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLogicalOptions = new System.Windows.Forms.ComboBox();
            this.cmbDateOptions = new System.Windows.Forms.ComboBox();
            this.cmbSizeOptions = new System.Windows.Forms.ComboBox();
            this.chkFileDate = new System.Windows.Forms.CheckBox();
            this.chkFileSize = new System.Windows.Forms.CheckBox();
            this.chkOverwriteFiles = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSimulationMode = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTimeoutCalc = new System.Windows.Forms.Label();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.numericTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblAuthenticationMethod = new System.Windows.Forms.Label();
            this.rbAuthenticationMethod_POST = new System.Windows.Forms.RadioButton();
            this.rbAuthenticationMethod_PUT = new System.Windows.Forms.RadioButton();
            this.chkClaimsAuthentication = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbLogicalOptions);
            this.groupBox1.Controls.Add(this.cmbDateOptions);
            this.groupBox1.Controls.Add(this.cmbSizeOptions);
            this.groupBox1.Controls.Add(this.chkFileDate);
            this.groupBox1.Controls.Add(this.chkFileSize);
            this.groupBox1.Controls.Add(this.chkOverwriteFiles);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File and Folder Options";
            // 
            // cmbLogicalOptions
            // 
            this.cmbLogicalOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicalOptions.Enabled = false;
            this.cmbLogicalOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLogicalOptions.FormattingEnabled = true;
            this.cmbLogicalOptions.Items.AddRange(new object[] {
            "Use Size \"OR\" Date to determine the overwrite",
            "Use Size \"AND\" Date to determine the overwrite"});
            this.cmbLogicalOptions.Location = new System.Drawing.Point(38, 110);
            this.cmbLogicalOptions.Name = "cmbLogicalOptions";
            this.cmbLogicalOptions.Size = new System.Drawing.Size(326, 21);
            this.cmbLogicalOptions.TabIndex = 5;
            // 
            // cmbDateOptions
            // 
            this.cmbDateOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateOptions.Enabled = false;
            this.cmbDateOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDateOptions.FormattingEnabled = true;
            this.cmbDateOptions.Items.AddRange(new object[] {
            "= Equals",
            "< Greater Than",
            "> Less Than",
            "<= Less Than or Equal To",
            ">= Greater Than or Equal To",
            "<>Different"});
            this.cmbDateOptions.Location = new System.Drawing.Point(159, 83);
            this.cmbDateOptions.Name = "cmbDateOptions";
            this.cmbDateOptions.Size = new System.Drawing.Size(205, 21);
            this.cmbDateOptions.TabIndex = 4;
            // 
            // cmbSizeOptions
            // 
            this.cmbSizeOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSizeOptions.Enabled = false;
            this.cmbSizeOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSizeOptions.FormattingEnabled = true;
            this.cmbSizeOptions.Items.AddRange(new object[] {
            "= Equals",
            "< Greater Than",
            "> Less Than",
            "<= Less Than or Equal To",
            ">= Greater Than or Equal To",
            "<>Different"});
            this.cmbSizeOptions.Location = new System.Drawing.Point(159, 56);
            this.cmbSizeOptions.Name = "cmbSizeOptions";
            this.cmbSizeOptions.Size = new System.Drawing.Size(205, 21);
            this.cmbSizeOptions.TabIndex = 2;
            // 
            // chkFileDate
            // 
            this.chkFileDate.AutoSize = true;
            this.chkFileDate.Enabled = false;
            this.chkFileDate.Location = new System.Drawing.Point(38, 83);
            this.chkFileDate.Name = "chkFileDate";
            this.chkFileDate.Size = new System.Drawing.Size(105, 17);
            this.chkFileDate.TabIndex = 3;
            this.chkFileDate.Text = "If Source Date is";
            this.chkFileDate.UseVisualStyleBackColor = true;
            // 
            // chkFileSize
            // 
            this.chkFileSize.AutoSize = true;
            this.chkFileSize.Enabled = false;
            this.chkFileSize.Location = new System.Drawing.Point(38, 56);
            this.chkFileSize.Name = "chkFileSize";
            this.chkFileSize.Size = new System.Drawing.Size(102, 17);
            this.chkFileSize.TabIndex = 1;
            this.chkFileSize.Text = "If Source Size is";
            this.chkFileSize.UseVisualStyleBackColor = true;
            // 
            // chkOverwriteFiles
            // 
            this.chkOverwriteFiles.AutoSize = true;
            this.chkOverwriteFiles.Location = new System.Drawing.Point(17, 31);
            this.chkOverwriteFiles.Name = "chkOverwriteFiles";
            this.chkOverwriteFiles.Size = new System.Drawing.Size(134, 17);
            this.chkOverwriteFiles.TabIndex = 0;
            this.chkOverwriteFiles.Text = "Overwrite Existing Files";
            this.chkOverwriteFiles.UseVisualStyleBackColor = true;
            this.chkOverwriteFiles.CheckedChanged += new System.EventHandler(this.chkOverwriteFiles_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::DinoDoc.Properties.Resources.Cancel;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.Location = new System.Drawing.Point(425, 58);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 31);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Image = global::DinoDoc.Properties.Resources.Confirm;
            this.buttonOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOK.Location = new System.Drawing.Point(425, 22);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 31);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkSimulationMode);
            this.panel1.Location = new System.Drawing.Point(12, 342);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 55);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Perform all operations using the selected options but without any impact";
            // 
            // chkSimulationMode
            // 
            this.chkSimulationMode.AutoSize = true;
            this.chkSimulationMode.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSimulationMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSimulationMode.ForeColor = System.Drawing.SystemColors.Highlight;
            this.chkSimulationMode.Location = new System.Drawing.Point(16, 11);
            this.chkSimulationMode.Name = "chkSimulationMode";
            this.chkSimulationMode.Size = new System.Drawing.Size(119, 17);
            this.chkSimulationMode.TabIndex = 1;
            this.chkSimulationMode.Text = "Simulation Mode";
            this.chkSimulationMode.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTimeoutCalc);
            this.groupBox2.Controls.Add(this.lblTimeOut);
            this.groupBox2.Controls.Add(this.numericTimeout);
            this.groupBox2.Controls.Add(this.lblAuthenticationMethod);
            this.groupBox2.Controls.Add(this.rbAuthenticationMethod_POST);
            this.groupBox2.Controls.Add(this.rbAuthenticationMethod_PUT);
            this.groupBox2.Controls.Add(this.chkClaimsAuthentication);
            this.groupBox2.Location = new System.Drawing.Point(12, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 129);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Authentication Options";
            // 
            // lblTimeoutCalc
            // 
            this.lblTimeoutCalc.AutoSize = true;
            this.lblTimeoutCalc.Location = new System.Drawing.Point(199, 103);
            this.lblTimeoutCalc.Name = "lblTimeoutCalc";
            this.lblTimeoutCalc.Size = new System.Drawing.Size(96, 13);
            this.lblTimeoutCalc.TabIndex = 6;
            this.lblTimeoutCalc.Text = "seconds (1 minute)";
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(31, 103);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(105, 13);
            this.lblTimeOut.TabIndex = 4;
            this.lblTimeOut.Text = "Connection Timeout:";
            // 
            // numericTimeout
            // 
            this.numericTimeout.Location = new System.Drawing.Point(146, 99);
            this.numericTimeout.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericTimeout.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericTimeout.Name = "numericTimeout";
            this.numericTimeout.Size = new System.Drawing.Size(46, 20);
            this.numericTimeout.TabIndex = 5;
            this.numericTimeout.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericTimeout.ValueChanged += new System.EventHandler(this.numericTimeout_ValueChanged);
            // 
            // lblAuthenticationMethod
            // 
            this.lblAuthenticationMethod.AutoSize = true;
            this.lblAuthenticationMethod.Location = new System.Drawing.Point(31, 65);
            this.lblAuthenticationMethod.Name = "lblAuthenticationMethod";
            this.lblAuthenticationMethod.Size = new System.Drawing.Size(117, 13);
            this.lblAuthenticationMethod.TabIndex = 1;
            this.lblAuthenticationMethod.Text = "Authentication Method:";
            // 
            // rbAuthenticationMethod_POST
            // 
            this.rbAuthenticationMethod_POST.AutoSize = true;
            this.rbAuthenticationMethod_POST.Location = new System.Drawing.Point(222, 63);
            this.rbAuthenticationMethod_POST.Name = "rbAuthenticationMethod_POST";
            this.rbAuthenticationMethod_POST.Size = new System.Drawing.Size(54, 17);
            this.rbAuthenticationMethod_POST.TabIndex = 3;
            this.rbAuthenticationMethod_POST.Text = "POST";
            this.rbAuthenticationMethod_POST.UseVisualStyleBackColor = true;
            // 
            // rbAuthenticationMethod_PUT
            // 
            this.rbAuthenticationMethod_PUT.AutoSize = true;
            this.rbAuthenticationMethod_PUT.Checked = true;
            this.rbAuthenticationMethod_PUT.Location = new System.Drawing.Point(159, 63);
            this.rbAuthenticationMethod_PUT.Name = "rbAuthenticationMethod_PUT";
            this.rbAuthenticationMethod_PUT.Size = new System.Drawing.Size(47, 17);
            this.rbAuthenticationMethod_PUT.TabIndex = 2;
            this.rbAuthenticationMethod_PUT.TabStop = true;
            this.rbAuthenticationMethod_PUT.Text = "PUT";
            this.rbAuthenticationMethod_PUT.UseVisualStyleBackColor = true;
            // 
            // chkClaimsAuthentication
            // 
            this.chkClaimsAuthentication.AutoSize = true;
            this.chkClaimsAuthentication.Location = new System.Drawing.Point(31, 30);
            this.chkClaimsAuthentication.Name = "chkClaimsAuthentication";
            this.chkClaimsAuthentication.Size = new System.Drawing.Size(217, 17);
            this.chkClaimsAuthentication.TabIndex = 0;
            this.chkClaimsAuthentication.Text = "Enforce the use of Claims Authentication";
            this.chkClaimsAuthentication.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(370, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(370, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(370, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(38, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "* coming soon";
            // 
            // frmOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(517, 411);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox chkOverwriteFiles;
        private System.Windows.Forms.CheckBox chkFileSize;
        private System.Windows.Forms.CheckBox chkFileDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSimulationMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkClaimsAuthentication;
        private System.Windows.Forms.Label lblAuthenticationMethod;
        private System.Windows.Forms.RadioButton rbAuthenticationMethod_POST;
        private System.Windows.Forms.RadioButton rbAuthenticationMethod_PUT;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.NumericUpDown numericTimeout;
        private System.Windows.Forms.Label lblTimeoutCalc;
        private System.Windows.Forms.ComboBox cmbSizeOptions;
        private System.Windows.Forms.ComboBox cmbDateOptions;
        private System.Windows.Forms.ComboBox cmbLogicalOptions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}