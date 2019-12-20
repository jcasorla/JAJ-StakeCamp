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
    public partial class asthmaCamperReport : Form
    {
        public asthmaCamperReport()
        {
            InitializeComponent();
        }

       
        Girls Reports = new Girls();
        string decision = "Yes";
       
        private void exportReport_Load(object sender, EventArgs e)
        {            
            // TODO: This line of code loads data into the 'girlsCampDataSet.adults' table. You can move, or remove it, as needed.

            Reports.sql = "select c.First_name, c.Last_name, c.Address, c.Home_Phone, c.Cell_Phone, c.Email, c.Birth_Date, cla.Level,  w.Ward, n.Nest_name " +
                "from customers c, customer_level_link cla, wards w,  girl_nest_link gnl, nests n, girls_medical gm " +
                "where c.CustomerID = cla.Customer_id and " +
                "c.Ward_id = w.Ward and " +
                "c.CustomerID = gnl.customerID and " +
                "gnl.nest_id = n.Nest_id and " +
                "c.CustomerID = gm.customer_id and " +//cla.LevelYear = @Currentyear and
                "cla.LevelYear = ? and gm.AsthmaYN = ?" + 
                "order by cla.level, Last_Name asc";

            DbParameter param = Reports.comm.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.Int32;
            param.Value = Reports.Currentyear;
            Reports.comm.Parameters.Add(param);

            DbParameter param2 = Reports.comm.CreateParameter();
            param2.ParameterName = "@decision";
            param2.DbType = DbType.String;
            param2.Value = decision;
            Reports.comm.Parameters.Add(param2);

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

        //*******************LINK TO MAIN MENU*******************************************
        private void linkMainMenu(object sender, LinkLabelLinkClickedEventArgs e)
        {

            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
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

        private void buttonExport_Click(object sender, EventArgs e)
        {
            GirlCampReport.GetReport(Reports.sql, Reports.comm); 
        }
        //*******************************************************************************
    }
}
