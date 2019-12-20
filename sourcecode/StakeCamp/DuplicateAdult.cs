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
    public partial class DuplicateAdult : Form
    {
        public DuplicateAdult()

        {
            InitializeComponent();
        }
        private int id;
        private Adults validateAdult;

        public int ID
        {
            set
            {
                id = value;

            }
            get
            {
                return id;
            }
        }

        public Adults ValidateAdult
        {
            set
            {
                validateAdult = value;

            }
            get
            {
                return validateAdult;
            }
        }      

        private void editLinkBtn_Click(object sender, EventArgs e)
        {
            editAdultForm editLink = new editAdultForm();
            this.Hide();
            editLink.Show();
            editLink.Top = this.Top;
            editLink.Left = this.Left;
            this.Close();

        }

        private void DuplicateAdult_Load(object sender, EventArgs e)
        {
            label1.Text = validateAdult.FirstName + " " + validateAdult.LastName + " " + "is already found in the system ";
            label2.Text = "Is it the same person? ";

            DbCommand comm = GenericDataAccess.CreateCommand();

            string sql = "SELECT  * from adults where Adult_ID = ? ";
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@id";
            param.DbType = DbType.Int32;
            param.Value = id;
            comm.Parameters.Add(param);


            comm.CommandText = sql;
            //set the BindingSource DataSource
            validateAdult.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

            //set the DataGridView DataSource
            dg.DataSource = validateAdult.bSource;

        }

        private void addAdultbtn_Click(object sender, EventArgs e)
        {
            //**********Function Calls ***********
            validateAdult.AddEmergencyContactInfo();//calls function in order to add adult helpers emergency contact info
            validateAdult.AddAdult();//calls function in order to add adult helper
            validateAdult.Registration();// calls function in order to add adult helpers registration info
            validateAdult.AddMedicalInfo();//calls function in order to add adult helpers medical info
                       
            if (validateAdult.didNotwork == false)
            {
                MessageBox.Show("Record added succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when adding this record");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //back to add
            addDecision addDecFrm = new addDecision();
            this.Hide();
            addDecFrm.Show();
            addDecFrm.Top = this.Top;
            addDecFrm.Left = this.Left;
        }

        private void linkAMain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainMenu mainM = new mainMenu();
            this.Hide();
            mainM.Show();
            mainM.Top = this.Top;
            mainM.Left = this.Left;
            this.Close();
        }
    }
}
