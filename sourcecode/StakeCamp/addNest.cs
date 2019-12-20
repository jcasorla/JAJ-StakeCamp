using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;

namespace StakeCamp
{
    public partial class addNest : Form
    {
        public addNest()
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
        //VEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEA
        //*******************************************************************************
        private void buttonSubmit_Click(object sender, EventArgs e)
        {            
            ManageCamp AddData = new ManageCamp();            
            AddData.NestName = nestNametbx.Text;
            AddData.NestDescription = nestDescTbx.Text;
            AddData.insertNest();
          
            if (AddData.didNotwork == false)
            {
                MessageBox.Show("Record added succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when adding this record");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //back to add
            addDecision addDecFrm = new addDecision();
            this.Hide();
            addDecFrm.Show();
            addDecFrm.Top = this.Top;
            addDecFrm.Left = this.Left;
        }
        //*******************************************************************************
    }
}
