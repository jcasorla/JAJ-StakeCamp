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
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        //*******************ADD DECISION FORM*******************************************
        private void goaddDecision(object sender, EventArgs e)
        {
            addDecision addFrm = new addDecision();
            this.Hide();
            addFrm.Show();
            addFrm.Top = this.Top;
            addFrm.Left = this.Left;
        }
        //*******************************************************************************

        //*******************EDIT DECISION***********************************************
        private void goeditDecision(object sender, EventArgs e)
        {
            editDecision editDecFrm = new editDecision();
            this.Hide();
            editDecFrm.Show();
            editDecFrm.Top = this.Top;
            editDecFrm.Left = this.Left;
        }
        //*******************************************************************************

        //*******************REPORTS*****************************************************
        private void goReports(object sender, EventArgs e)
        {
            reportsForm reportsFrm = new reportsForm();
            this.Hide();
            reportsFrm.Show();
            reportsFrm.Top = this.Top;
            reportsFrm.Left = this.Left;
        }
        //*******************************************************************************

        //*******************TRANSFER****************************************************
        private void gotransfer(object sender, EventArgs e)
        {

            transfer transferFrm = new transfer();
            this.Hide();
            transferFrm.Show();
            transferFrm.Top = this.Top;
            transferFrm.Left = this.Left;
        }

        private void UserProBtn_Click(object sender, EventArgs e)
        {
            userProfile userProFrm = new userProfile();
            this.Hide();
            userProFrm.Show();
            userProFrm.Top = this.Top;
            userProFrm.Left = this.Left;
        }
        //*******************************************************************************
       
    }
}
