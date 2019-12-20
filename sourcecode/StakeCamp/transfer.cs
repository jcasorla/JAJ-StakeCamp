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
    public partial class transfer : Form
    {
        public transfer()
        {
            InitializeComponent();
        }

        private void linkMainMenu(object sender, LinkLabelLinkClickedEventArgs e)
        {

            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
            this.Close();
        }
        Adults transAdult = new Adults();
        Girls transGirl = new Girls();

        private void transfer_Load(object sender, EventArgs e)
        {
            int oldYear = transAdult.Currentyear - 1;
            label1.Text = ("Transfer data from: " + oldYear.ToString());
           
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            transAdult.GetAllAdultLinks();
            transGirl.GetAllGirlLinks();
            if (transAdult.didNotwork == false || transGirl.didNotwork == false)
            {
                MessageBox.Show("Transfer succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when transferring data");
            }
        }
       
    }
}
