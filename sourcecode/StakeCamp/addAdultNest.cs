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
    public partial class addAdultNest : Form
    {
        public addAdultNest()
        {
            InitializeComponent();
        }

        //*******************LINK TO MAIN MENU*******************************************
        private void linkMainMenu(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
            this.Close();
        }    
       
        Adults editData = new Adults();
        private void AdultNest_load(object sender, EventArgs e)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();

            string sql = "SELECT adults.Adult_ID, adults.First_Name, adults.Last_Name " +
                "FROM (adults LEFT OUTER JOIN adult_assingments_link ON adults.Adult_ID = adult_assingments_link.AdultID) "+
                "LEFT OUTER JOIN adult_nest_link ON adults.Adult_ID = adult_nest_link.AdultID "+
                 "where adult_nest_link.Nest_id is null and AssingYear =? "+
                 "order by First_Name, Last_Name asc ";
                    

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CurrentYear";
            param.DbType = DbType.Int32;
            param.Value = editData.Currentyear;
            comm.Parameters.Add(param);
           
            comm.CommandText = sql;
            //set the BindingSource DataSource
            editData.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

            //set the DataGridView DataSource
            dg.DataSource = editData.bSource;
          
            NestComboBox();            
        }
        public void NestComboBox()
        {
            //nest            
            DbCommand comm = GenericDataAccess.CreateCommand();           
            comm.CommandText = "Select Nest_id, Nest_name from nests where NestYear=?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CurrentYear";
            param.DbType = DbType.Int32;
            param.Value = editData.Currentyear;
            comm.Parameters.Add(param);

            cbNest.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);
            cbNest.DisplayMember = "Nest_name";
            cbNest.ValueMember = "Nest_id";
            cbNest.SelectedIndex = -1;

        }

        private void AssingNestButton_Click(object sender, EventArgs e)
        {
           
            // gets value from combo box
            string temp1 = cbNest.SelectedValue.ToString();
            int myParsedInt1 = Int32.Parse(temp1);
            editData.NestID = Convert.ToInt32(temp1);

            int rows = dg.Rows.Count;
                                   
            int count =0;
            for (int i = 0; i < rows; i++)
            {
               
                string temp = dg.Rows[i].Cells["Select"].EditedFormattedValue.ToString();
                
                if (temp == "False")
                {
                                        
                }
                else if (temp == "True")
                {
                    //gets value from the Adultsid cell
                    string id = dg.Rows[i].Cells["Adult_ID"].Value.ToString();
                    int myParsedInt = Int32.Parse(id);
                    editData.AdultID = Convert.ToInt32(id);                    
                 
                    editData.addAdultNestLink();//calls function in order to assign nest to adult
                   
                    count++;
                }
                
            }
           
            DbCommand cmd = GenericDataAccess.CreateCommand();
            string sql = "SELECT adults.Adult_ID, adults.First_Name, adults.Last_Name " +
                "FROM (adults LEFT OUTER JOIN adult_assingments_link ON adults.Adult_ID = adult_assingments_link.AdultID) " +
                "LEFT OUTER JOIN adult_nest_link ON adults.Adult_ID = adult_nest_link.AdultID " +
                 "where adult_nest_link.Nest_id is null and AssingYear =? " +
                 "order by First_Name, Last_Name asc ";


            DbParameter param = cmd.CreateParameter();
            param.ParameterName = "@CurrentYear";
            param.DbType = DbType.Int32;
            param.Value = editData.Currentyear;
            cmd.Parameters.Add(param);
         
            cmd.CommandText = sql;
           
            dg.DataSource = GenericDataAccess.ExecuteSelectCommand(cmd);
            dg.Update();
          
            if (editData.didNotwork == false)
            {
                MessageBox.Show("Record added succesfully");
            }
            else
            {
               MessageBox.Show("It appears there was an error when adding this record");
            }
        }
          

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
