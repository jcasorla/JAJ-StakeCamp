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
    public partial class startPage : Form
    {
        public startPage()
        {
            InitializeComponent();

            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += new EventHandler(OnTick);
            timer.Enabled = true;
            timer.Start();
            //timer.Stop();
        }

        public void OnTick(object s, EventArgs ea)
        {
            Login loginFrm = new Login();
            this.Hide();
            loginFrm.Show();
            loginFrm.Top = this.Top;
            loginFrm.Left = this.Left;

            Timer t = (Timer)s;
            t.Stop();    
            
        }
        
    }
}
        
