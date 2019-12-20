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
    public partial class transportDecision : Form
    {
        public transportDecision()
        {
            InitializeComponent();
        }

        //*******************GO TRANS ADULT*********************************************
        private void gotransCamper(object sender, EventArgs e)
        {
            transAdult transAdultFrm = new transAdult();
            this.Hide();
            transAdultFrm.Show();
            transAdultFrm.Top = this.Top;
            transAdultFrm.Left = this.Left;
        }
        //*******************************************************************************

        //*******************GO TRANS CAMPER*********************************************
        private void goCamper(object sender, EventArgs e)
        {
            transCamper transCamperFrm = new transCamper();
            this.Hide();
            transCamperFrm.Show();
            transCamperFrm.Top = this.Top;
            transCamperFrm.Left = this.Left;
        }
        //*******************************************************************************

        //*******************LINK TO ADD*************************************************
        private void linkToAdd(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addDecision addDecisionFrm = new addDecision();
            this.Hide();
            addDecisionFrm.Show();
            addDecisionFrm.Top = this.Top;
            addDecisionFrm.Left = this.Left;
        }
        //*******************************************************************************

        //*******************LINK TO MAIN MENU*******************************************
        private void linkToMain(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainMenu mainMenuFrm = new mainMenu();
            this.Hide();
            mainMenuFrm.Show();
            mainMenuFrm.Top = this.Top;
            mainMenuFrm.Left = this.Left;
        }
        //*******************************************************************************




    }
}
