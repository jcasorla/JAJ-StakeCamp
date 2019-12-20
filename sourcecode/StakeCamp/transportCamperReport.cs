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
    public partial class transportCamperReport : Form
    {
        public transportCamperReport()
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

        //*******************CAMPER TRANSPORT QUERY**************************************
        private void transportCamperReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'girlsCampDataSet.adults' table. You can move, or remove it, as needed.

            Reports.sql = "SELECT  customers.First_name, " +
                "customers.Last_name, customers.Address, customers.Home_Phone, customers.Cell_Phone, transportation.Transportation, " +
                "customers.Birth_Date, levels.Level, wards.Ward, nests.Nest_name, customers.Email " +
            "FROM nests " +
            "INNER JOIN ((wards INNER JOIN (levels INNER JOIN ((customers INNER JOIN " +
                "(transportation INNER JOIN transportation_customer_link " +
                "ON transportation.Transportation_id = transportation_customer_link.Transportation_id) " +
            "ON customers.CustomerID = transportation_customer_link.Customer_id) " +
            "INNER JOIN customer_level_link " +
            "ON customers.CustomerID = customer_level_link.Customer_id) " +
            "ON levels.Level = customer_level_link.Level) " +
            "ON wards.Ward = customers.Ward_id) " +
            "INNER JOIN girl_nest_link " +
            "ON customers.CustomerID = girl_nest_link.customerID) " +
            "ON nests.Nest_id = girl_nest_link.nest_id " +
            "where transYear = ? "+
            "ORDER by transportation.Transportation; ";

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

        private void transCamperbtn_Click(object sender, EventArgs e)
        {
            GirlCampReport.GetReport(Reports.sql, Reports.comm); 
        }

       
    }
}
