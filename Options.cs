using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security;
using System.Security.Permissions;

using Microsoft.Win32;

using DinoDoc.Properties;


namespace DinoDoc
{    
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Settings.Default.OptionsOverwriteFiles = chkOverwriteFiles.Checked;
            Settings.Default.OptionsUseFileSize = chkFileSize.Checked;
            Settings.Default.OptionsUseFileDate = chkFileDate.Checked;

            Settings.Default.OptionsOverwriteDateOperator = cmbDateOptions.SelectedItem.ToString();
            Settings.Default.OptionsOverwriteSizeOperator = cmbSizeOptions.SelectedItem.ToString();
            Settings.Default.OptionsOverwriteLogicalOperator = cmbLogicalOptions.SelectedItem.ToString();

            Settings.Default.OptionsUseClaimsAuthentication = chkClaimsAuthentication.Checked;
            Settings.Default.OptionsAuthenticationMethod = rbAuthenticationMethod_PUT.Checked ? "PUT" : "POST";
            Settings.Default.OptionsTimeOut = numericTimeout.Value;

            Settings.Default.OptionsSimulationMode = chkSimulationMode.Checked;

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            chkOverwriteFiles.Checked = Settings.Default.OptionsOverwriteFiles;
            chkFileSize.Checked = Settings.Default.OptionsUseFileSize;
            chkFileDate.Checked = Settings.Default.OptionsUseFileDate;

            cmbDateOptions.SelectedItem = Settings.Default.OptionsOverwriteDateOperator;
            cmbSizeOptions.SelectedItem = Settings.Default.OptionsOverwriteSizeOperator;
            cmbLogicalOptions.SelectedItem = Settings.Default.OptionsOverwriteLogicalOperator;

            chkClaimsAuthentication.Checked = Settings.Default.OptionsUseClaimsAuthentication;

            rbAuthenticationMethod_PUT.Checked = Settings.Default.OptionsAuthenticationMethod == "PUT";
            rbAuthenticationMethod_POST.Checked = !rbAuthenticationMethod_PUT.Checked;

            numericTimeout.Value = Settings.Default.OptionsTimeOut;

            chkSimulationMode.Checked = Settings.Default.OptionsSimulationMode;
        }

        private void chkOverwriteFiles_CheckedChanged(object sender, EventArgs e)
        {
            chkFileSize.Enabled = chkOverwriteFiles.Checked;
            chkFileDate.Enabled = chkOverwriteFiles.Checked;
            
            cmbSizeOptions.Enabled = chkOverwriteFiles.Checked;
            cmbDateOptions.Enabled = chkOverwriteFiles.Checked;

            cmbLogicalOptions.Enabled = chkOverwriteFiles.Checked;
        }

        private void numericTimeout_ValueChanged(object sender, EventArgs e)
        {
            lblTimeoutCalc.Text = "seconds (" + Math.Round(numericTimeout.Value / 60, 1, MidpointRounding.ToEven) + " minute";
            lblTimeoutCalc.Text += (numericTimeout.Value == 60) ? ")" : "s)";
        }
    }
}