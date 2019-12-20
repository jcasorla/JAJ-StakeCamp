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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //*******************PRESS ENTER TO LOGIN****************************************
        private void login(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginBT_Click(sender, e);
            }
        }
        //*******************************************************************************
       
        private void LoginBT_Click(object sender, EventArgs e)
        {
            string userID = tBUserId.Text;
            string pwd = TBpassword.Text;

            UserLogin loginData = GirlCampDbAccess.GetUserLogin(userID, pwd);


            if (loginData.UserId.Length > 0)
            {
                if (loginData.Password.Equals(pwd))
                {
                    mainMenu addCamp = new mainMenu();
                    this.Hide();
                    addCamp.Show();
                    addCamp.Top = this.Top;
                    addCamp.Left = this.Left;
                    
                }
                else
                {
                    errorMessage.Text = "UserId or Password doesn't match";
                }
            }
            else
            {
                errorMessage.Text = "No such user id";
            }
            
        }

       
    }
}
