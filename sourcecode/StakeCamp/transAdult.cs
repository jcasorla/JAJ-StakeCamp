using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.OleDb;

namespace StakeCamp
{
    public partial class transAdult : Form
    {
        public transAdult()
        {
            InitializeComponent();
        }

        Adults adultTrans = new Adults();
        
        //*******************LOAD ADULT TRANSPORTATION***********************************
        private void adultTransport_Load(object sender, EventArgs e)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            string sql = "SELECT  adults.Adult_ID, adults.First_Name, adults.Last_Name " +
                "FROM (adults LEFT OUTER JOIN adult_transportation_link ON adults.Adult_ID = adult_transportation_link.Adult_id) "+
                "LEFT OUTER JOIN adult_assingments_link ON adults.Adult_ID = adult_assingments_link.AdultID "+
                "where AssingYear = ? and Transportation_id is null "; 
          
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.Int32;
            param.Value = adultTrans.Currentyear;
            comm.Parameters.Add(param);
            

            // order by First_Name, Last_Name asc";

            comm.CommandText = sql;
            //set the BindingSource DataSource
            adultTrans.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

            //set the DataGridView DataSource
            dg1.DataSource = adultTrans.bSource;
            TransComboBox();
        }
        //*******************************************************************************
        
        //*******************TRANSPORTATION COMBO BOX************************************
        public void TransComboBox()
        {
            //nest            
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from transportation";

            cbTransport.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);
            cbTransport.DisplayMember = "Transportation";
            cbTransport.ValueMember = "Transportation_id";
            cbTransport.SelectedIndex = -1;
        }
        //*******************************************************************************

        //*******************ASSIGN TRANSPORTATION***************************************
        private void btnAssignTrans(object sender, EventArgs e)
        {           
            //Transportation_id 1 = Bus 1
            //Transportation_id 2 = Bus 2
            //Transportation_id 3 = Vehicle

            // gets value from combo box
            string temp1 = cbTransport.SelectedValue.ToString();
            int myParsedInt1 = Int32.Parse(temp1);
            adultTrans.TransportID = Convert.ToInt32(temp1);           
            int rows = dg1.Rows.Count;           

            for (int i = 0; i < rows; i++)
            { 
                string temp = dg1.Rows[i].Cells["Select"].EditedFormattedValue.ToString();
              
                if (temp == "False")
                {

                }
                else if (temp == "True")
                {
                    //gets value from the girlID cell
                    string id = dg1.Rows[i].Cells["Adult_ID"].Value.ToString();
                    int myParsedInt = Int32.Parse(id);
                    adultTrans.AdultID = Convert.ToInt32(id);
                    adultTrans.addAdultTransLink();                  
                }
            }

            DbCommand cmd = GenericDataAccess.CreateCommand();
            string sql = "SELECT  adults.Adult_ID, adults.First_Name, adults.Last_Name " +
               "FROM (adults LEFT OUTER JOIN adult_transportation_link ON adults.Adult_ID = adult_transportation_link.Adult_id) " +
               "LEFT OUTER JOIN adult_assingments_link ON adults.Adult_ID = adult_assingments_link.AdultID " +
               "where AssingYear = ? and Transportation_id is null ";

            DbParameter param = cmd.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.Int32;
            param.Value = adultTrans.Currentyear;
            cmd.Parameters.Add(param);

            cmd.CommandText = sql;
            dg1.DataSource = GenericDataAccess.ExecuteSelectCommand(cmd);
            dg1.Update();
          
            if (adultTrans.didNotwork == false)
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
            //go main menu
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
            this.Close();
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
