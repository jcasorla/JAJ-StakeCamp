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
    public partial class userProfile : Form
    {
        public userProfile()
        {
            InitializeComponent();
        }

        ManageCamp editUser = new ManageCamp();
        
        //*******************LINK TO CHANGE USER ID**************************************
        private void linkchangeUserID(object sender, LinkLabelLinkClickedEventArgs e)
        {
            editUser.GetUserIDPW();
            changeUserID changeID = new changeUserID();
            changeID.userid = editUser.userid;
            this.Hide();
            changeID.Show();
            changeID.Top = this.Top;
            changeID.Left = this.Left;
        }
        //*******************************************************************************

        //*******************LINK TO CHANGE PASSWORD*************************************
        private void linkchangePassword(object sender, LinkLabelLinkClickedEventArgs e)
        {
            changePassword changePW = new changePassword();
            changePW.Password = editUser.password;
            
            this.Hide();
            changePW.Show();
            changePW.Top = this.Top;
            changePW.Left = this.Left;
        }

        //*******************DISPLAY USER ID & PW IN TEXTBOX*****************************
        private void displayIDnPW(object sender, EventArgs e)
        {
            editUser.GetUserIDPW();
            tbUserID.Text = editUser.Userid;
            tbPassword.Text = editUser.Password;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
