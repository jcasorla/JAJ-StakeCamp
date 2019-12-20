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
    public partial class addCamperNest : Form
    {
        public addCamperNest()
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
      
        Girls editGirlsData = new Girls();

        private void AddCamperNest_load(object sender, EventArgs e)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();

            string sql = "SELECT  customers.CustomerID, customers.First_name, customers.Last_name " +
                "FROM (customers LEFT OUTER JOIN customer_level_link ON customers.CustomerID = customer_level_link.Customer_id) " +
                "LEFT OUTER JOIN girl_nest_link ON customers.CustomerID = girl_nest_link.customerID " +
                "where girl_nest_link.nest_id is null and LevelYear = ? "+   
                "order by First_Name, Last_Name asc";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.Int32;
            param.Value = editGirlsData.Currentyear;
            comm.Parameters.Add(param);


            comm.CommandText = sql;
            //set the BindingSource DataSource
            editGirlsData.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

            //set the DataGridView DataSource
            dg.DataSource = editGirlsData.bSource;

            NestComboBox();            
        }
        //*******************************************************************************
        public void NestComboBox()
        {
            //nest            
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select Nest_id, Nest_name from nests where NestYear=?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CurrentYear";
            param.DbType = DbType.Int32;
            param.Value = editGirlsData.Currentyear;
            comm.Parameters.Add(param);

            cbNest.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);
            cbNest.DisplayMember = "Nest_name";
            cbNest.ValueMember = "Nest_id";
            cbNest.SelectedIndex = -1;

        }

        private void assingGirlNestbt_Click(object sender, EventArgs e)
        {            
            //gets value from combo box
            string temp1 = cbNest.SelectedValue.ToString();
            int myParsedInt1 = Int32.Parse(temp1);
            editGirlsData.NestID = Convert.ToInt32(temp1);

            int rows = dg.Rows.Count;
          
                      
            for (int i = 0; i < rows; i++)
            {
                               
                string temp = dg.Rows[i].Cells["Select"].EditedFormattedValue.ToString();
               
                if (temp == "False")
                {

                }
                else if (temp == "True")
                {
                    //gets value from the girlID cell
                    string id = dg.Rows[i].Cells["CustomerID"].Value.ToString();
                    int myParsedInt = Int32.Parse(id);
                    editGirlsData.GirlID = Convert.ToInt32(id);
                    
                    editGirlsData.addGirlNestLink();                 
                    
                }

            }

            DbCommand cmd = GenericDataAccess.CreateCommand();
            string sql = "SELECT  customers.CustomerID, customers.First_name, customers.Last_name " +
                   "FROM (customers LEFT OUTER JOIN customer_level_link ON customers.CustomerID = customer_level_link.Customer_id) " +
                   "LEFT OUTER JOIN girl_nest_link ON customers.CustomerID = girl_nest_link.customerID " +
                   "where girl_nest_link.nest_id is null and LevelYear = ? " +
                   "order by First_Name, Last_Name asc";

            DbParameter param = cmd.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.Int32;
            param.Value = editGirlsData.Currentyear;
            cmd.Parameters.Add(param);
            

            cmd.CommandText = sql;
            dg.DataSource = GenericDataAccess.ExecuteSelectCommand(cmd);
            dg.Update();
           
            if (editGirlsData.didNotwork == false)
            {
                MessageBox.Show("Record added succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when adding this record");
            }
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

    }

     
}

