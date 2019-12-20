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
    public partial class assignAdultReport : Form
    {
        public assignAdultReport()
        {
            InitializeComponent();
        }
        Adults Reports = new Adults();

        //*******************ADULT ASSIGNMENT QUERY**************************************
        private void assignAdultReport_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'girlsCampDataSet.adults' table. You can move, or remove it, as needed.

            Reports.sql = "SELECT assingments.Assingment_description, adults.First_Name, adults.Last_Name, adults.Home_Phone, adults.Cell_Phone, wards.Ward, nests.Nest_Name, adults.Email " +
            "FROM wards " +
            "INNER JOIN (nests INNER JOIN (assingments INNER JOIN ((adults INNER JOIN adult_assingments_link ON adults.Adult_ID = adult_assingments_link.AdultID) " +
            "INNER JOIN adult_nest_link " +
            "ON adults.Adult_ID = adult_nest_link.AdultID) " +
            "ON assingments.Assing_ID = adult_assingments_link.AssingID) " +
            "ON nests.Nest_id = adult_nest_link.Nest_id) " +
            "ON wards.Ward = adults.Ward " +
            "ORDER by assingments.Assingment_description";


            DbParameter param = Reports.comm.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.String;
            param.Value = Reports.Currentyear;
            Reports.comm.Parameters.Add(param);

            //DbParameter param2 = Reports.comm.CreateParameter();
            //param2.ParameterName = "@decision";
            //param2.DbType = DbType.String;
            //param2.Value = decision;
            //Reports.comm.Parameters.Add(param2);

            Reports.comm.CommandText = Reports.sql;
            //set the BindingSource DataSource
            Reports.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(Reports.comm);

            //set the DataGridView DataSource
            dg.DataSource = Reports.bSource;                 

        }
        //*******************************************************************************

        private void levelAdultbtn_Click(object sender, EventArgs e)
        {
            GirlCampReport.GetReport(Reports.sql, Reports.comm); 
        }

        private void linklabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //go to reports
            reportsForm reportsFrm = new reportsForm();
            this.Hide();
            reportsFrm.Show();
            reportsFrm.Top = this.Top;
            reportsFrm.Left = this.Left;
            this.Close();
        }

        private void linkUpdMainMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //go to main menu
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
            this.Close();
        }
    }
}
