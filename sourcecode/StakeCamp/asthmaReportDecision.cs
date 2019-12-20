using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StakeCamp
{
    public partial class asthmaReportDecision : Form
    {
        public asthmaReportDecision()
        {
            InitializeComponent();
        }

        private void goAsthmaAdult(object sender, EventArgs e)
        {
            asthmaAdultReport asthmaAdult = new asthmaAdultReport();
            this.Hide();
            asthmaAdult.Show();
            asthmaAdult.Top = this.Top;
            asthmaAdult.Left = this.Left;
            this.Close();
        }

        private void btnCamper_Click(object sender, EventArgs e)
        {
            asthmaCamperReport asthmaAdult = new asthmaCamperReport();
            this.Hide();
            asthmaAdult.Show();
            asthmaAdult.Top = this.Top;
            asthmaAdult.Left = this.Left;
            this.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // got to main menu
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //go back to reports
            reportsForm reportsFrm = new reportsForm();
            this.Hide();
            reportsFrm.Show();
            reportsFrm.Top = this.Top;
            reportsFrm.Left = this.Left;
            this.Close();
        }
    }
}
