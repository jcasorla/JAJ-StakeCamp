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
    public partial class wardCamperReport : Form
    {
        public wardCamperReport()
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

        //*******************CAMPER WARD QUERY*******************************************
        private void wardCamperReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'girlsCampDataSet.adults' table. You can move, or remove it, as needed.

            Reports.sql = "SELECT wards.Ward, customers.First_name, customers.Last_name, "+ 
                "customers.Address, customers.Home_Phone, customers.Cell_Phone, customers.Birth_Date, "+ 
                "customer_level_link.Level, nests.Nest_name, customers.Email "+
            "FROM nests "+ 
            "INNER JOIN ((levels INNER JOIN ((wards INNER JOIN customers ON wards.Ward = customers.Ward_id) "+ 
            "INNER JOIN customer_level_link "+ 
            "ON customers.CustomerID = customer_level_link.Customer_id) "+ 
            "ON levels.Level = customer_level_link.Level) "+ 
            "INNER JOIN girl_nest_link "+ 
            "ON customers.CustomerID = girl_nest_link.customerID) "+ 
            "ON nests.Nest_id = girl_nest_link.nest_id "+
            "ORDER by wards.Ward ";

            DbParameter param = Reports.comm.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.Int32;
            param.Value = Reports.Currentyear;
            Reports.comm.Parameters.Add(param);

            //DbParameter param2 = Reports.comm.CreateParameter();
            //param2.ParameterName = "@decision";
            //param2.DbType = DbType.String;
            //param2.Value = decision;
            //Reports.comm.Parameters.Add(param2);

            //, girl_guardian_link ggl, guardians g,
            //"c.CustomerID = ggl.customer_id and " +
            //"ggl.guardian_id = g.Guardian_ID and " +

            // order by First_Name, Last_Name asc";

            Reports.comm.CommandText = Reports.sql;
            //set the BindingSource DataSource
            Reports.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(Reports.comm);

            //set the DataGridView DataSource
            dg.DataSource = Reports.bSource;

        }
        //*******************************************************************************

        private void wardCamperbtn_Click(object sender, EventArgs e)
        {
            GirlCampReport.GetReport(Reports.sql, Reports.comm); 
        }
    }
}
