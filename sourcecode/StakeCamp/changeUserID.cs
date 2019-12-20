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
    public partial class changeUserID : Form
    {
        public changeUserID()
        {
            InitializeComponent();
        }

        ManageCamp editUser = new ManageCamp();
        
        public string userid;
        
        //*******************GET/SET USER ID*********************************************
        public string Userid
        {
            set
            {
                userid = value;
            }
            get
            {
                return userid;
            }
        }      
        //*******************************************************************************

        //*******************SUBMIT NEW ID***********************************************
        private void submitNewID(object sender, EventArgs e)
        {
            if (tbNewUserID.Text != tbVerifyUserID.Text)
            {
                MessageBox.Show("Your userID does not match!");
                tbNewUserID.Clear();
                tbVerifyUserID.Clear();
                tbNewUserID.Focus();
            }
            else
            {
                editUser.Userid = userid;
                editUser.newUserID = tbNewUserID.Text;
                editUser.updateUserID();
            }
            if (editUser.didNotwork == false)
            {
                MessageBox.Show("Usei ID Updated Succesfuly");
            }
            else
            {
                MessageBox.Show("It appears there was in error when updating the User ID");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userProfile userProFrm = new userProfile();
            this.Hide();
            userProFrm.Show();
            userProFrm.Top = this.Top;
            userProFrm.Left = this.Left;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
        }

      
    }
}
