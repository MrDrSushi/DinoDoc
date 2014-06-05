using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DinoDoc
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void linklabelAlex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:aagons@yahoo.com");
        }

        private void linklabelBowsil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            Process.Start("mailto:bowsilameen@hotmail.com");
        }

        private void linklabelDinoDoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {           
            Process.Start("http://dinodoc.codeplex.com");
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {

        }

        
    }
}
