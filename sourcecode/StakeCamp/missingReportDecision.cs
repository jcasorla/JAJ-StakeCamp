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
    public partial class missingReportDecision : Form
    {
        public missingReportDecision()
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
        
        //*******************ADULTS BUTTON***********************************************
        private void btnAdultsMissing(object sender, EventArgs e)
        {
            missingAdultsReport missAdRepFrm = new missingAdultsReport();
            this.Hide();
            missAdRepFrm.Show();
            missAdRepFrm.Top = this.Top;
            missAdRepFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************CAMPER BUTTON***********************************************
        private void btnCamperMissing(object sender, EventArgs e)
        {
            missingCamperReport missCampRepFrm = new missingCamperReport();
            this.Hide();
            missCampRepFrm.Show();
            missCampRepFrm.Top = this.Top;
            missCampRepFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************
    }
}
