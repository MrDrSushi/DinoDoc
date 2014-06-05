namespace DinoDoc
{
    partial class frmAbout
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.linklabelDinoDoc = new System.Windows.Forms.LinkLabel();
            this.linklabelBowsil = new System.Windows.Forms.LinkLabel();
            this.linklabelAlex = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.linklabelDinoDoc);
            this.panel1.Controls.Add(this.linklabelBowsil);
            this.panel1.Controls.Add(this.linklabelAlex);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 290);
            this.panel1.TabIndex = 0;
            // 
            // linklabelDinoDoc
            // 
            this.linklabelDinoDoc.AutoSize = true;
            this.linklabelDinoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklabelDinoDoc.Location = new System.Drawing.Point(46, 256);
            this.linklabelDinoDoc.Name = "linklabelDinoDoc";
            this.linklabelDinoDoc.Size = new System.Drawing.Size(160, 15);
            this.linklabelDinoDoc.TabIndex = 7;
            this.linklabelDinoDoc.TabStop = true;
            this.linklabelDinoDoc.Text = "http://dinodoc.codeplex.com";
            this.linklabelDinoDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linklabelDinoDoc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabelDinoDoc_LinkClicked);
            // 
            // linklabelBowsil
            // 
            this.linklabelBowsil.AutoSize = true;
            this.linklabelBowsil.Location = new System.Drawing.Point(248, 176);
            this.linklabelBowsil.Name = "linklabelBowsil";
            this.linklabelBowsil.Size = new System.Drawing.Size(135, 13);
            this.linklabelBowsil.TabIndex = 6;
            this.linklabelBowsil.TabStop = true;
            this.linklabelBowsil.Text = "bowsilameen@hotmail.com";
            this.linklabelBowsil.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabelBowsil_LinkClicked);
            // 
            // linklabelAlex
            // 
            this.linklabelAlex.AutoSize = true;
            this.linklabelAlex.Location = new System.Drawing.Point(156, 148);
            this.linklabelAlex.Name = "linklabelAlex";
            this.linklabelAlex.Size = new System.Drawing.Size(105, 13);
            this.linklabelAlex.TabIndex = 5;
            this.linklabelAlex.TabStop = true;
            this.linklabelAlex.Text = "aagons@yahoo.com";
            this.linklabelAlex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabelAlex_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(360, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "DinoDoc is an open source project hosted at CodePlex:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Based on an existing project from Bowsil Ameen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Developed by Alex Gonsales";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "version 1.00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DinoDoc.Properties.Resources.DinoDoc_Logo_1;
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(431, 100);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Image = global::DinoDoc.Properties.Resources.Confirm;
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.Location = new System.Drawing.Point(402, 314);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(72, 23);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 349);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linklabelBowsil;
        private System.Windows.Forms.LinkLabel linklabelAlex;
        private System.Windows.Forms.LinkLabel linklabelDinoDoc;
    }
}