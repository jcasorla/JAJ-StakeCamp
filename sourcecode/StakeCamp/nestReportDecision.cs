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
    public partial class nestReportDecision : Form
    {
        public nestReportDecision()
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
        private void btnnestAdults(object sender, EventArgs e)
        {
            nestAdultsReport nestAdultFrm = new nestAdultsReport();
            this.Hide();
            nestAdultFrm.Show();
            nestAdultFrm.Top = this.Top;
            nestAdultFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************CAMPER BUTTON***********************************************
        private void btnnestCamper(object sender, EventArgs e)
        {
            nestCamperReport nestCampFrm = new nestCamperReport();
            this.Hide();
            nestCampFrm.Show();
            nestCampFrm.Top = this.Top;
            nestCampFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************
    }
}
