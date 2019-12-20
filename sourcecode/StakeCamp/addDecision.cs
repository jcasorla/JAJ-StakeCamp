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
    public partial class addDecision : Form
    {
        public addDecision()
        {
            InitializeComponent();
        }
        //*******************GO TO ADD CAMPER********************************************
        private void goaddCamperForm(object sender, EventArgs e)
        {
            camperForm addCamp = new camperForm();
            this.Hide();
            addCamp.Show();
            addCamp.Top = this.Top;
            addCamp.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************GO TO ADD ADULT*********************************************
        private void goaddAdultForm(object sender, EventArgs e)
        {
            adultForm addCamp = new adultForm();
            this.Hide();
            addCamp.Show();
            addCamp.Top = this.Top;
            addCamp.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************GO TO NEST DECISION*****************************************
        private void gonestDecision(object sender, EventArgs e)
        {
            nestDecision nestDecFrm = new nestDecision();
            this.Hide();
            nestDecFrm.Show();
            nestDecFrm.Top = this.Top;
            nestDecFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************GO TO ADD WARD**********************************************
        private void goAddWardForm(object sender, EventArgs e)
        {
            addWard addWardFrm = new addWard();
            this.Hide();
            addWardFrm.Show();
            addWardFrm.Top = this.Top;
            addWardFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************
        private void goMainMenu(object sender, EventArgs e)
        {
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************GO TO TRANSPORTATION DECISION FORM**************************
        private void gotransportDecisionForm(object sender, EventArgs e)
        {
            transportDecision transFrm = new transportDecision();
            this.Hide();
            transFrm.Show();
            transFrm.Top = this.Top;
            transFrm.Left = this.Left;
            this.Close();
        }

        private void buttonWards_Click(object sender, EventArgs e)
        {
            addWard transFrm = new addWard();
            this.Hide();
            transFrm.Show();
            transFrm.Top = this.Top;
            transFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************
    }
}
