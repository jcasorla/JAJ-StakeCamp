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
    public partial class medicalReportDecision : Form
    {
        public medicalReportDecision()
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
        private void btnmedicationAdults(object sender, EventArgs e)
        {
            medicationAdultsReport medAdFrm = new medicationAdultsReport();
            this.Hide();
            medAdFrm.Show();
            medAdFrm.Top = this.Top;
            medAdFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************CAMPER BUTTON***********************************************
        private void btnmedicationCamp(object sender, EventArgs e)
        {
            medicationCamperReport medCampFrm = new medicationCamperReport();
            this.Hide();
            medCampFrm.Show();
            medCampFrm.Top = this.Top;
            medCampFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************
    }
}
