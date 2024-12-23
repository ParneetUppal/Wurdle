using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp.Parneet.Kaur
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Text = "ABOUT VEHICLE QUOTE";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size=new Size(400,400);
            this.btnaboutformOK.Click += BtnaboutformOK_Click;
        }

        private void BtnaboutformOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.etsy.com/listing/1399479274/race-car-svg-sports-car-clipart-vehicle");
        }
    }
}
