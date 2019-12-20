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
    public partial class reportsForm : Form
    {
        public reportsForm()
        {
            InitializeComponent();
        }
        //*******************LINK TO MAIN MENU*******************************************
        private void goMainMenu(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainMenu mainM = new mainMenu();
            this.Hide();
            mainM.Show();
            mainM.Top = this.Top;
            mainM.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************REPORTS FORM************************************************
        private void goReportsForm(object sender, EventArgs e)
        {
            if (cmbReports.Text == "Asthma")
            {
                asthmaReportDecision asthmaDec = new asthmaReportDecision();
                this.Hide();
                asthmaDec.Show();
                asthmaDec.Top = this.Top;
                asthmaDec.Left = this.Left;
                this.Close();
            }
            else if (cmbReports.Text == "Level")
            {
                LevelReportDecision levelFrm = new LevelReportDecision();
                this.Hide();
                levelFrm.Show();
                levelFrm.Top = this.Top;
                levelFrm.Left = this.Left;
                this.Close();
            }
            else if (cmbReports.Text == "Medications")
            {
                medicalReportDecision medicationFrm = new medicalReportDecision();
                this.Hide();
                medicationFrm.Show();
                medicationFrm.Top = this.Top;
                medicationFrm.Left = this.Left;
                this.Close();
            }
            else if (cmbReports.Text == "Missing Form/Payment")
            {
                missingReportDecision missingFrm = new missingReportDecision();
                this.Hide();
                missingFrm.Show();
                missingFrm.Top = this.Top;
                missingFrm.Left = this.Left;
                this.Close();
            }
            else if (cmbReports.Text == "Nest")
            {
                nestReportDecision nestFrm = new nestReportDecision();
                this.Hide();
                nestFrm.Show();
                nestFrm.Top = this.Top;
                nestFrm.Left = this.Left;
                this.Close();
            }
            else if (cmbReports.Text == "Transportation")
            {
                transportatioReportDecision transportationFrm = new transportatioReportDecision();
                this.Hide();
                transportationFrm.Show();
                transportationFrm.Top = this.Top;
                transportationFrm.Left = this.Left;
                this.Close();
            }
            else if (cmbReports.Text == "Ward")
            {
                wardReportDecision wardFrm = new wardReportDecision();
                this.Hide();
                wardFrm.Show();
                wardFrm.Top = this.Top;
                wardFrm.Left = this.Left;
                this.Close();
            }
            else
            {
                MessageBox.Show("You have not selected a report.");
            }
            //*******************************************************************************
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    exportReport asthmaFrm = new exportReport();
        //    this.Hide();
        //    asthmaFrm.Show();
        //    asthmaFrm.Top = this.Top;
        //    asthmaFrm.Left = this.Left;
        //    this.Close();
        //}
    }
}
