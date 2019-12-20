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
    public partial class editDecision : Form
    {
        public editDecision()
        {
            InitializeComponent();
        }

        //*******************EDIT ADULT FORM*********************************************
        private void goeditAdult(object sender, EventArgs e)
        {
            editAdultForm editAdultFrm = new editAdultForm();
            this.Hide();
            editAdultFrm.Show();
            editAdultFrm.Top = this.Top;
            editAdultFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************EDIT CAMPER FORM********************************************
        private void goeditCamper(object sender, EventArgs e)
        {
            editCamperForm editCamperFrm = new editCamperForm();
            this.Hide();
            editCamperFrm.Show();
            editCamperFrm.Top = this.Top;
            editCamperFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************EDIT NESTS FORM*********************************************
        private void goeditNests(object sender, EventArgs e)
        {
            editNests editNestFrm = new editNests();
            this.Hide();
            editNestFrm.Show();
            editNestFrm.Top = this.Top;
            editNestFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************EDIT WARDS FORM*********************************************
        private void goeditWards(object sender, EventArgs e)
        {
            editWards editWardsFrm = new editWards();
            this.Hide();
            editWardsFrm.Show();
            editWardsFrm.Top = this.Top;
            editWardsFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************LINK TO MAIN MENU*******************************************
        private void linkMainMenu(object sender, LinkLabelLinkClickedEventArgs e)
        {

            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************
    }
}
