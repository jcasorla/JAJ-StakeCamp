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
    public partial class transportatioReportDecision : Form
    {
        public transportatioReportDecision()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reportsForm reportsFrm = new reportsForm();
            this.Hide();
            reportsFrm.Show();
            reportsFrm.Top = this.Top;
            reportsFrm.Left = this.Left;
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
            this.Close();
        }

        //*******************ADULT BUTTON************************************************
        private void btnAdultTransRep(object sender, EventArgs e)
        {
            transportAdultsReport transAdRepFrm = new transportAdultsReport();
            this.Hide();
            transAdRepFrm.Show();
            transAdRepFrm.Top = this.Top;
            transAdRepFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************CAMPER BUTTON***********************************************
        private void btnCamperTransRep(object sender, EventArgs e)
        {
            transportCamperReport transCampRepFrm = new transportCamperReport();
            this.Hide();
            transCampRepFrm.Show();
            transCampRepFrm.Top = this.Top;
            transCampRepFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

    }
}
