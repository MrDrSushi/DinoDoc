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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLogicalAND = new System.Windows.Forms.CheckBox();
            this.chkFileDate = new System.Windows.Forms.CheckBox();
            this.chkFileSize = new System.Windows.Forms.CheckBox();
            this.chkOverwriteFiles = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSimulationMode = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAuthenticationMethod = new System.Windows.Forms.Label();
            this.rbAuthenticationMethod_POST = new System.Windows.Forms.RadioButton();
            this.rbAuthenticationMethod_PUT = new System.Windows.Forms.RadioButton();
            this.chkClaimsAuthentication = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLogicalAND);
            this.groupBox1.Controls.Add(this.chkFileDate);
            this.groupBox1.Controls.Add(this.chkFileSize);
            this.groupBox1.Controls.Add(this.chkOverwriteFiles);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File and Folder Options";
            // 
            // chkLogicalAND
            // 
            this.chkLogicalAND.AutoSize = true;
            this.chkLogicalAND.Enabled = false;
            this.chkLogicalAND.Location = new System.Drawing.Point(38, 105);
            this.chkLogicalAND.Name = "chkLogicalAND";
            this.chkLogicalAND.Size = new System.Drawing.Size(339, 17);
            this.chkLogicalAND.TabIndex = 6;
            this.chkLogicalAND.Text = "use \"AND\" comparisson for overwriting conditions when combined";
            this.chkLogicalAND.UseVisualStyleBackColor = true;
            // 
            // chkFileDate
            // 
            this.chkFileDate.AutoSize = true;
            this.chkFileDate.Enabled = false;
            this.chkFileDate.Location = new System.Drawing.Point(38, 82);
            this.chkFileDate.Name = "chkFileDate";
            this.chkFileDate.Size = new System.Drawing.Size(313, 17);
            this.chkFileDate.TabIndex = 5;
            this.chkFileDate.Text = "Overwrite = If Source Date is Different from Target (File Date)";
            this.chkFileDate.UseVisualStyleBackColor = true;
            // 
            // chkFileSize
            // 
            this.chkFileSize.AutoSize = true;
            this.chkFileSize.Enabled = false;
            this.chkFileSize.Location = new System.Drawing.Point(38, 59);
            this.chkFileSize.Name = "chkFileSize";
            this.chkFileSize.Size = new System.Drawing.Size(307, 17);
            this.chkFileSize.TabIndex = 4;
            this.chkFileSize.Text = "Overwrite = If Source Size is Different from Target (File Size)";
            this.chkFileSize.UseVisualStyleBackColor = true;
            // 
            // chkOverwriteFiles
            // 
            this.chkOverwriteFiles.AutoSize = true;
            this.chkOverwriteFiles.Location = new System.Drawing.Point(17, 36);
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
            this.buttonCancel.TabIndex = 2;
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
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkSimulationMode);
            this.panel1.Location = new System.Drawing.Point(12, 286);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 55);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 13);
            this.label1.TabIndex = 3;
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
            this.chkSimulationMode.TabIndex = 2;
            this.chkSimulationMode.Text = "Simulation Mode";
            this.chkSimulationMode.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAuthenticationMethod);
            this.groupBox2.Controls.Add(this.rbAuthenticationMethod_POST);
            this.groupBox2.Controls.Add(this.rbAuthenticationMethod_PUT);
            this.groupBox2.Controls.Add(this.chkClaimsAuthentication);
            this.groupBox2.Location = new System.Drawing.Point(12, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 110);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Authentication Options";
            // 
            // lblAuthenticationMethod
            // 
            this.lblAuthenticationMethod.AutoSize = true;
            this.lblAuthenticationMethod.Location = new System.Drawing.Point(31, 72);
            this.lblAuthenticationMethod.Name = "lblAuthenticationMethod";
            this.lblAuthenticationMethod.Size = new System.Drawing.Size(114, 13);
            this.lblAuthenticationMethod.TabIndex = 4;
            this.lblAuthenticationMethod.Text = "Authentication Method";
            // 
            // rbAuthenticationMethod_POST
            // 
            this.rbAuthenticationMethod_POST.AutoSize = true;
            this.rbAuthenticationMethod_POST.Location = new System.Drawing.Point(231, 68);
            this.rbAuthenticationMethod_POST.Name = "rbAuthenticationMethod_POST";
            this.rbAuthenticationMethod_POST.Size = new System.Drawing.Size(54, 17);
            this.rbAuthenticationMethod_POST.TabIndex = 2;
            this.rbAuthenticationMethod_POST.Text = "POST";
            this.rbAuthenticationMethod_POST.UseVisualStyleBackColor = true;
            // 
            // rbAuthenticationMethod_PUT
            // 
            this.rbAuthenticationMethod_PUT.AutoSize = true;
            this.rbAuthenticationMethod_PUT.Checked = true;
            this.rbAuthenticationMethod_PUT.Location = new System.Drawing.Point(168, 68);
            this.rbAuthenticationMethod_PUT.Name = "rbAuthenticationMethod_PUT";
            this.rbAuthenticationMethod_PUT.Size = new System.Drawing.Size(47, 17);
            this.rbAuthenticationMethod_PUT.TabIndex = 1;
            this.rbAuthenticationMethod_PUT.TabStop = true;
            this.rbAuthenticationMethod_PUT.Text = "PUT";
            this.rbAuthenticationMethod_PUT.UseVisualStyleBackColor = true;
            // 
            // chkClaimsAuthentication
            // 
            this.chkClaimsAuthentication.AutoSize = true;
            this.chkClaimsAuthentication.Location = new System.Drawing.Point(34, 35);
            this.chkClaimsAuthentication.Name = "chkClaimsAuthentication";
            this.chkClaimsAuthentication.Size = new System.Drawing.Size(217, 17);
            this.chkClaimsAuthentication.TabIndex = 0;
            this.chkClaimsAuthentication.Text = "Enforce the use of Claims Authentication";
            this.chkClaimsAuthentication.UseVisualStyleBackColor = true;
            // 
            // frmOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(517, 356);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox chkOverwriteFiles;
        private System.Windows.Forms.CheckBox chkFileSize;
        private System.Windows.Forms.CheckBox chkFileDate;
        private System.Windows.Forms.CheckBox chkLogicalAND;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSimulationMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkClaimsAuthentication;
        private System.Windows.Forms.Label lblAuthenticationMethod;
        private System.Windows.Forms.RadioButton rbAuthenticationMethod_POST;
        private System.Windows.Forms.RadioButton rbAuthenticationMethod_PUT;
    }
}