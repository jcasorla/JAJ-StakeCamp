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
    public partial class missingAdultsReport : Form
    {
        public missingAdultsReport()
        {
            InitializeComponent();
        }
        Adults Reports = new Adults();

        //*******************ADULTS MISSING QUERY****************************************
        private void missingAdultsReport_Load(object sender, EventArgs e)
        {           
            // TODO: This line of code loads data into the 'girlsCampDataSet.adults' table. You can move, or remove it, as needed.

            Reports.sql = "SELECT adults.First_Name, adults.Last_Name, adults.Address, adults.Home_Phone, adults.Cell_Phone, adults.Birth_Date, assingments.Assingment_description, wards.Ward, nests.Nest_name, " +
                "adults.Email, enrollment.Recieved_Registration, enrollment.Recieved_Emg_Consent, enrollment.Recieved_Medical_Form, enrollment.Recieved_Payment, enrollment.Comments " +
                "FROM enrollment INNER JOIN ((nests INNER JOIN ((wards INNER JOIN (assingments INNER JOIN (adults INNER JOIN adult_assingments_link ON adults.Adult_ID=adult_assingments_link.AdultID) " +
                "ON assingments.Assing_ID=adult_assingments_link.AssingID) ON wards.Ward=adults.Ward) INNER JOIN adult_nest_link ON adults.Adult_ID=adult_nest_link.AdultID) ON nests.Nest_id=adult_nest_link.Nest_id) " +
                "INNER JOIN enrollment_adult_link ON adults.Adult_ID=enrollment_adult_link.adultID) ON enrollment.Enroll_ID=enrollment_adult_link.EnrollmentID " +
                "WHERE Enroll_Year = ? and (enrollment.Recieved_Registration= 'No') " +
                "OR (enrollment.Recieved_Emg_Consent= 'No') " +
                "OR (enrollment.Recieved_Medical_Form= 'No') " +
                "OR (enrollment.Recieved_Payment='No') ";


            DbParameter param = Reports.comm.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.String;
            param.Value = Reports.Currentyear;
            Reports.comm.Parameters.Add(param);



            Reports.comm.CommandText = Reports.sql;
            //set the BindingSource DataSource
            Reports.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(Reports.comm);

            //set the DataGridView DataSource
            dg.DataSource = Reports.bSource;                 
        }
        //*******************************************************************************
        private void missingAdultbtn_Click(object sender, EventArgs e)
        {
            GirlCampReport.GetReport(Reports.sql, Reports.comm);
        }

        private void linklabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //goreports
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
            mMenu.Left = this.Left;
            this.Close();
        }
    }
}
