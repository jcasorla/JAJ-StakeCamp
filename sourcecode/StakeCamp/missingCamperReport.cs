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
    public partial class missingCamperReport : Form
    {
        public missingCamperReport()
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
        
        
        private void missingCamperReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'girlsCampDataSet.adults' table. You can move, or remove it, as needed.


            Reports.sql = "SELECT customers.First_name, customers.Last_name, " +
                "customers.Home_Phone, customers.Cell_Phone, customers.Email, customers.Birth_Date, " +
                "levels.Level, wards.Ward, nests.Nest_name, "+
                "Recieved_Registration, Recieved_Emg_Consent, Recieved_Medical_Form, Recieved_Payment, Comments " +               
            "FROM enrollment " +
            "INNER JOIN ((nests INNER JOIN ((wards INNER JOIN (levels INNER JOIN " +
                "(customers INNER JOIN customer_level_link ON customers.CustomerID " +
                "= customer_level_link.Customer_id) " +
            "ON levels.Level = customer_level_link.Level) " +
            "ON wards.Ward = customers.Ward_id) " +
            "INNER JOIN girl_nest_link ON customers.CustomerID = girl_nest_link.customerID) " +
            "ON nests.Nest_id = girl_nest_link.nest_id) " +
            "INNER JOIN enrollment_girl_link " +
            "ON customers.CustomerID = enrollment_girl_link.customerID) " +
            "ON enrollment.Enroll_ID = enrollment_girl_link.enrollmentID "+
             "WHERE EnrollYear =? and (enrollment.Recieved_Registration= 'No') " +
                "OR (enrollment.Recieved_Emg_Consent= 'No') " +
                "OR (enrollment.Recieved_Medical_Form= 'No') " +
                "OR (enrollment.Recieved_Payment='No') ";

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

        private void missingCamperbtn_Click(object sender, EventArgs e)
        {
            GirlCampReport.GetReport(Reports.sql, Reports.comm);
        }
    }
}
