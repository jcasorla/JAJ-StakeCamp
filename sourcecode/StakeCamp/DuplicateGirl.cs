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
    public partial class DuplicateGirl : Form
    {       
        public DuplicateGirl()
        {
            InitializeComponent();
        }

        private int id;
        private Girls validateGirl;
        //guardian 1
        public string Guard1FName;
        public string Guard1LName;
        public string Guard1Address;
        public string Guard1City;
        public string Guard1State;
        public string Guard1ZipCode;
        public string Guard1HPhone;
        public string Guard1CPhone;
        public string Guard1Email;
        //guardian 2
        public string Guard2FName;
        public string Guard2LName;
        public string Guard2Address;
        public string Guard2City;
        public string Guard2State;
        public string Guard2ZipCode;
        public string Guard2HPhone;
        public string Guard2CPhone;
        public string Guard2Email;

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

        public Girls ValidateGirl
        {
            set
            {
                validateGirl = value;

            }
            get
            {
                return validateGirl;
            }
        }      

       // Girls validateGirl = new Girls();
        private void GirlDuplicate_Load(object sender, EventArgs e)
        {
            label1.Text = validateGirl.FirstName + " " + validateGirl.LastName + " " + "is already found in the system ";
            label2.Text = "Is it the same person? ";            

            DbCommand comm = GenericDataAccess.CreateCommand();

            string sql = "SELECT  * from customers where CustomerID = ? ";
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@id";
            param.DbType = DbType.Int32;
            param.Value = id;
            comm.Parameters.Add(param);


            comm.CommandText = sql;
            //set the BindingSource DataSource
            validateGirl.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

            //set the DataGridView DataSource
            dg.DataSource = validateGirl.bSource;
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {           
            //**********Function Calls ***********
            validateGirl.AddEmergencyContactInfo();//calls function in order to insert emergency contact info
            validateGirl.AddCamper();//***calls function AddCamper***
            validateGirl.Registration();//***calls function in order to add registration info***
            callGuardian2(); //**calls local function in order to call AddGuardianInfo() 2 times            
            validateGirl.AddMedicalInfo();//***calls AddMedicalInfo function***

           
            if (validateGirl.didNotwork == false)
            {
                MessageBox.Show("Record added succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when adding this record");
            }
        }

        private void editlinkbtn_Click(object sender, EventArgs e)
        {
            editCamperForm editLink = new editCamperForm();
            this.Hide();
            editLink.Show();
            editLink.Top = this.Top;
            editLink.Left = this.Left;
            this.Close();
        }
        public void callGuardian2()
        {   
            //*********Guardian Tab********
            //Guardian 1
            validateGirl.GuardFName = Guard1FName;
            validateGirl.GuardLName = Guard1LName;
            validateGirl.GuardAddress = Guard1Address;
            validateGirl.GuardCity = Guard1City;
            validateGirl.GuardState = Guard1State;
            validateGirl.GuardZipCode = Guard1ZipCode;
            validateGirl.GuardHPhone = Guard1HPhone;
            validateGirl.GuardCPhone = Guard1CPhone;
            validateGirl.GuardEmail = Guard1Email;
            validateGirl.AddGuardianInfo();//***calls AddGuardianInfo in order to insert data***
                    
        
            //Guardian 2
            validateGirl.GuardFName = Guard2FName;
            validateGirl.GuardLName = Guard2LName;
            validateGirl.GuardAddress = Guard2Address;
            validateGirl.GuardCity = Guard2City;
            validateGirl.GuardState = Guard2State;
            validateGirl.GuardZipCode = Guard2ZipCode;
            validateGirl.GuardHPhone = Guard2HPhone;
            validateGirl.GuardCPhone = Guard2CPhone;
            validateGirl.GuardEmail = Guard2Email;
            validateGirl.AddGuardianInfo();//***calls AddGuardianInfo in order to insert data***         
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addDecision addDecFrm = new addDecision();
            this.Hide();
            addDecFrm.Show();
            addDecFrm.Top = this.Top;
            addDecFrm.Left = this.Left;
        }

        private void linkECMain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
