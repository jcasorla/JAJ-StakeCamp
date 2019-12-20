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
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();
        }

        ManageCamp editUser = new ManageCamp();
        
        protected string password;

        //*******************GET/SET PASSWORD********************************************
        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }
        //*******************************************************************************

        //*******************SUBMIT NEW PASSWORD*****************************************
        private void submitNewPW(object sender, EventArgs e)
        {
            if (tbNewPassword.Text != tbVerifyPassword.Text)
            {
                MessageBox.Show("Your password does not match!");
                tbNewPassword.Clear();
                tbVerifyPassword.Clear();
                tbNewPassword.Focus();
            }
            else
            {
                editUser.Password = password;
                editUser.newPassword = tbNewPassword.Text;
                editUser.updateUserPW();
                if (editUser.didNotwork == false)
                {
                    MessageBox.Show("Password Updated Succesfuly");
                }
                else
                {
                    MessageBox.Show("It appears there was in error when updating the password");
                }
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
        //*******************************************************************************

    }
}
