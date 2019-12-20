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
    public partial class wardReportDecision : Form
    {
        public wardReportDecision()
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
        private void btnAdultWardRep(object sender, EventArgs e)
        {
            wardAdultsReport wardAdRepFrm = new wardAdultsReport();
            this.Hide();
            wardAdRepFrm.Show();
            wardAdRepFrm.Top = this.Top;
            wardAdRepFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************CAMPER BUTTON***********************************************
        private void btnCampWardRep(object sender, EventArgs e)
        {
            wardCamperReport wardCampRepFrm = new wardCamperReport();
            this.Hide();
            wardCampRepFrm.Show();
            wardCampRepFrm.Top = this.Top;
            wardCampRepFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************
    }
}
