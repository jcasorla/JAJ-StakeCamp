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
    public partial class transCamper : Form
    {
        public transCamper()
        {
            InitializeComponent();
        }

        //*******************LINK MAIN MENU**********************************************
        private void linkMainMenu(object sender, EventArgs e)
        {
            mainMenu mainM = new mainMenu();
            this.Hide();
            mainM.Show();
            mainM.Top = this.Top;
            mainM.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************ADD DECISION FORM LINK**************************************
        private void linkAddDecForm(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addDecision addDecFrm = new addDecision();
            this.Hide();
            addDecFrm.Show();
            addDecFrm.Top = this.Top;
            addDecFrm.Left = this.Left;
            this.Close();
        }
        Girls girlTrans = new Girls();
        private void girlTransport_load(object sender, EventArgs e)
        {

            DbCommand comm = GenericDataAccess.CreateCommand();
            string sql = "SELECT customers.CustomerID, customers.First_name, customers.Last_name " +
                "FROM (customers LEFT OUTER JOIN transportation_customer_link ON customers.CustomerID = transportation_customer_link.Customer_id) " +
                "LEFT OUTER JOIN customer_level_link ON customers.CustomerID = customer_level_link.Customer_id " +
                "where LevelYear = ? and Transportation_id is null "+
                "order by First_Name, Last_Name asc";
          
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.Int32;
            param.Value = girlTrans.Currentyear;
            comm.Parameters.Add(param);

            

            comm.CommandText = sql;
            //set the BindingSource DataSource
            girlTrans.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

            //set the DataGridView DataSource
            dg.DataSource = girlTrans.bSource;
            TransComboBox();

        }
        public void TransComboBox()
        {
            //nest            
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from transportation";


            TransportCB.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);
            TransportCB.DisplayMember = "Transportation";
            TransportCB.ValueMember = "Transportation_id";
            TransportCB.SelectedIndex = -1;

        }

        private void AssginTranBt_Click(object sender, EventArgs e)
        {            
            //Transportation_id 1 = Bus 1
            //Transportation_id 2 = Bus 2
            //Transportation_id 3 = Vehicle

            // gets value from combo box
            string temp1 = TransportCB.SelectedValue.ToString();
            int myParsedInt1 = Int32.Parse(temp1);
            girlTrans.TransportID = Convert.ToInt32(temp1);

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
                    girlTrans.GirlID = Convert.ToInt32(id);
                    girlTrans.addTransCustomerLink();
                }

            }

            DbCommand cmd = GenericDataAccess.CreateCommand();
            string sql = "SELECT customers.CustomerID, customers.First_name, customers.Last_name " +
               "FROM (customers LEFT OUTER JOIN transportation_customer_link ON customers.CustomerID = transportation_customer_link.Customer_id) " +
               "LEFT OUTER JOIN customer_level_link ON customers.CustomerID = customer_level_link.Customer_id " +
               "where LevelYear = ? and Transportation_id is null " +
               "order by First_Name, Last_Name asc";            

            DbParameter param = cmd.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.Int32;
            param.Value = girlTrans.Currentyear;
            cmd.Parameters.Add(param);

            cmd.CommandText = sql;
            dg.DataSource = GenericDataAccess.ExecuteSelectCommand(cmd);
            dg.Update();
           
            if (girlTrans.didNotwork == false)
            {
                MessageBox.Show("Record added succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when adding this record");
            }
        } 

    }
}
