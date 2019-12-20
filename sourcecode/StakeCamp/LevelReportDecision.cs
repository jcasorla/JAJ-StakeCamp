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
    public partial class LevelReportDecision : Form
    {
        public LevelReportDecision()
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
        private void adultbutton_Click(object sender, EventArgs e)
        {
            assignAdultReport assignAdultFrm = new assignAdultReport();
            this.Hide();
            assignAdultFrm.Show();
            assignAdultFrm.Top = this.Top;
            assignAdultFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************CAMPER BUTTON***********************************************
        private void btnCamperLvl(object sender, EventArgs e)
        {
            levelCamperReport campReportFrm = new levelCamperReport();
            this.Hide();
            campReportFrm.Show();
            campReportFrm.Top = this.Top;
            campReportFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************
    }
}
