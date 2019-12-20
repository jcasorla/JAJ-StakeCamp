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
    public partial class levelCamperReport : Form
    {
        public levelCamperReport()
        {
            InitializeComponent();
        }

        private void goMainMenu(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
            this.Close();
        }

        private void goReports(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reportsForm reportsFrm = new reportsForm();
            this.Hide();
            reportsFrm.Show();
            reportsFrm.Top = this.Top;
            reportsFrm.Left = this.Left;
            this.Close();
        }
        Girls Reports = new Girls();

        //*******************CAMPER LEVELS QUERY*****************************************
        private void levelCamperReport_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'girlsCampDataSet.adults' table. You can move, or remove it, as needed.

            Reports.sql = "SELECT levels.[Level], customers.First_Name, customers.Last_Name, customers.Home_Phone, customers.Cell_Phone, customers.Birth_Date, wards.Ward, nests.Nest_name " +
            "FROM wards "+ 
            "INNER JOIN (nests INNER JOIN (levels INNER JOIN ((customers INNER JOIN customer_level_link ON customers.CustomerID = customer_level_link.Customer_id) "+ 
            "INNER JOIN girl_nest_link "+ 
            "ON customers.CustomerID = girl_nest_link.customerID) "+ 
            "ON levels.Level = customer_level_link.Level) "+
            "ON nests.Nest_id = girl_nest_link.nest_id) "+ 
            "ON wards.Ward = customers.Ward_id " +
            "where LevelYear =? "+
            "ORDER by levels.[Level] ";


            DbParameter param = Reports.comm.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.Int32;
            param.Value = Reports.Currentyear;
            Reports.comm.Parameters.Add(param);

            Reports.comm.CommandText = Reports.sql;
            //set the BindingSource DataSource
            Reports.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(Reports.comm);

            //set the DataGridView DataSource
            dg.DataSource = Reports.bSource;


        }
        //*******************************************************************************

        //*******************LINK TO MAIN MENU*******************************************
        private void linkMainMenu(object sender, LinkLabelLinkClickedEventArgs e)
        {

            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Left = this.Left;
            this.Close();

        }

        private void levelCamperbtn_Click(object sender, EventArgs e)
        {
            GirlCampReport.GetReport(Reports.sql, Reports.comm); 
        }

      
    }
}
