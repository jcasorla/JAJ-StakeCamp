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
    public partial class addWard : Form
    {
        public addWard()
        {
            InitializeComponent();
        }

        //*******************MAIN MENU LINK**********************************************
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

        //*******************ADD DEC FORM LINK*******************************************
        private void linkAddDecFrom(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addDecision addDecFrm = new addDecision();
            this.Hide();
            addDecFrm.Show();
            addDecFrm.Top = this.Top;
            addDecFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //VEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEA
        //*******************ADD WARD****************************************************
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            ManageCamp AddData = new ManageCamp();           
            AddData.WardID = tbWardName.Text;
            AddData.addWard();
           
            if (AddData.didNotwork == false)
            {
                MessageBox.Show("Record added succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when adding this record");
            }
        }
        //*******************************************************************************
    }
}
