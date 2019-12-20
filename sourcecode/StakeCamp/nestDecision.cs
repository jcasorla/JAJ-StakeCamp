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
    public partial class nestDecision : Form
    {
        public nestDecision()
        {
            InitializeComponent();
        }
        //*******************GO TO ADD NEST FORM*****************************************
        private void goaddNest(object sender, EventArgs e)
        {
            addNest addNestFrm = new addNest();
            this.Hide();
            addNestFrm.Show();
            addNestFrm.Top = this.Top;
            addNestFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************LINK TO ADD DECISION****************************************
        private void linkToAdd(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addDecision addDecisionFrm = new addDecision();
            this.Hide();
            addDecisionFrm.Show();
            addDecisionFrm.Top = this.Top;
            addDecisionFrm.Left = this.Left;
            this.Close();

        }
        //*******************************************************************************

        //*******************LINK TO MAIN MENU*******************************************
        private void linkMainMenu(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainMenu mainM = new mainMenu();
            this.Hide();
            mainM.Show();
            mainM.Top = this.Top;
            mainM.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************ADD ADULT NEST**********************************************
        private void goAddAdultNest(object sender, EventArgs e)
        {
            addAdultNest addAdultNestFrm = new addAdultNest();
            this.Hide();
            addAdultNestFrm.Show();
            addAdultNestFrm.Top = this.Top;
            addAdultNestFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************ADD CAMPER NEST*********************************************
        private void goAddCamperNest(object sender, EventArgs e)
        {
            addCamperNest addCamperNestFrm = new addCamperNest();
            this.Hide();
            addCamperNestFrm.Show();
            addCamperNestFrm.Top = this.Top;
            addCamperNestFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************
    }
}
