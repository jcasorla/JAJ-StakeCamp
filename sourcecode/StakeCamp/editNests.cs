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
    public partial class editNests : Form
    {
        public editNests()
        {
            InitializeComponent();
        }



        //*******************LOAD EDIT NESTS FORM****************************************

        ManageCamp EditData = new ManageCamp();
        private void editNests_Load(object sender, EventArgs e)
        {

            //TODO: This line of code loads data into the 'girlsCampDataSet.nests' table. You can move, or remove it, as needed.
            DbCommand comm = GenericDataAccess.CreateCommand();

            comm.CommandText = "Select Nest_id, Nest_name from nests where NestYear=? order by Nest_name asc";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CurrentYear";
            param.DbType = DbType.Int32;
            param.Value = EditData.Currentyear;
            comm.Parameters.Add(param);


            //set the BindingSource DataSource
            EditData.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

            //set the DataGridView DataSource
            dg.DataSource = EditData.bSource;


            DataGridViewLinkColumn link1 = new DataGridViewLinkColumn();
            link1.HeaderText = "Edit";
            link1.Text = "Edit";
            link1.Name = "Edit";
            link1.Visible = true;
            link1.UseColumnTextForLinkValue = true;
            dg.Columns.Add(link1);

            DataGridViewLinkColumn link2 = new DataGridViewLinkColumn();
            link2.HeaderText = "Delete";
            link2.Text = "Delete";
            link2.Name = "Delete";
            link2.Visible = true;
            link2.UseColumnTextForLinkValue = true;
            dg.Columns.Add(link2);

            dg.Update();

        }
        //*******************************************************************************

        //*******************MAIN MENU LINK**********************************************
        private void linkMainMenu(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
        }
        //*******************************************************************************

        //*******************EDIT DECISION LINK******************************************
        private void linkEditDecision(object sender, LinkLabelLinkClickedEventArgs e)
        {
            editDecision editDecFrm = new editDecision();
            this.Hide();
            editDecFrm.Show();
            editDecFrm.Top = this.Top;
            editDecFrm.Left = this.Left; ;
        }

        private void buttonDelete_Click(object sender, EventArgs e)//update button
        {           
            EditData.NestName = nestNametbx.Text;
            EditData.updateNest();
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select Nest_id, Nest_name from nests where NestYear=? order by Nest_name asc";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CurrentYear";
            param.DbType = DbType.Int32;
            param.Value = EditData.Currentyear;
            comm.Parameters.Add(param);


            //set the BindingSource DataSource
            EditData.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

            //set the DataGridView DataSource
            dg.DataSource = EditData.bSource;


            DataGridViewLinkColumn link1 = new DataGridViewLinkColumn();
            link1.HeaderText = "Edit";
            link1.Text = "Edit";
            link1.Name = "Edit";
            link1.Visible = true;
            link1.UseColumnTextForLinkValue = true;
            dg.Columns.Add(link1);

            DataGridViewLinkColumn link2 = new DataGridViewLinkColumn();
            link2.HeaderText = "Delete";
            link2.Text = "Delete";
            link2.Name = "Delete";
            link2.Visible = true;
            link2.UseColumnTextForLinkValue = true;
            dg.Columns.Add(link2);

            dg.Update();
            nestNametbx.Clear();


            if (EditData.didNotwork == false)
            {
                MessageBox.Show("Record updated succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when updating this record");
            }

        }


        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            

            if (dg.Rows[e.RowIndex].Cells["Edit"].Selected)
            {
                string id = dg.Rows[e.RowIndex].Cells["Nest_id"].Value.ToString();
                int myParsedInt = Int32.Parse(id);
                EditData.NestID = Convert.ToInt32(id);
                MessageBox.Show("You clicked on edit");
                EditData.GetNest();
                nestNametbx.Text = EditData.NestName;

            }
            else if (dg.Rows[e.RowIndex].Cells["Delete"].Selected)
            {
                DialogResult deleteButton1 =
                    MessageBox.Show(
                    "Are you sure you want to delete this record?",
                    "Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (deleteButton1 == DialogResult.Yes)
                {
                    DialogResult deleteButton2 =
                       MessageBox.Show(
                       "Are you really sure you want to delete this record?",
                       "Delete",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button2);
                    if (deleteButton2 == DialogResult.Yes)
                    {
                        nestNametbx.Clear();
                        string id = dg.Rows[e.RowIndex].Cells["Nest_id"].Value.ToString();
                        int myParsedInt = Int32.Parse(id);
                        EditData.NestID = Convert.ToInt32(id);
                        MessageBox.Show("You clicked on delete");

                        EditData.deleteNest();

                        EditData.bSource.RemoveCurrent();
                        Validate();
                        EditData.bSource.EndEdit();
                        DbCommand comm = GenericDataAccess.CreateCommand();

                        comm.CommandText = "Select Nest_id, Nest_name from nests where NestYear=? order by Nest_name asc";

                        DbParameter param = comm.CreateParameter();
                        param.ParameterName = "@CurrentYear";
                        param.DbType = DbType.Int32;
                        param.Value = EditData.Currentyear;
                        comm.Parameters.Add(param);


                        //set the BindingSource DataSource
                        EditData.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

                        //set the DataGridView DataSource
                        dg.DataSource = EditData.bSource;


                        DataGridViewLinkColumn link1 = new DataGridViewLinkColumn();
                        link1.HeaderText = "Edit";
                        link1.Text = "Edit";
                        link1.Name = "Edit";
                        link1.Visible = true;
                        link1.UseColumnTextForLinkValue = true;
                        dg.Columns.Add(link1);

                        DataGridViewLinkColumn link2 = new DataGridViewLinkColumn();
                        link2.HeaderText = "Delete";
                        link2.Text = "Delete";
                        link2.Name = "Delete";
                        link2.Visible = true;
                        link2.UseColumnTextForLinkValue = true;
                        dg.Columns.Add(link2);

                        dg.Update();


                        if (EditData.didNotwork == false)
                        {
                            MessageBox.Show("Record deleted succesfully");
                        }
                        else
                        {
                            MessageBox.Show("It appears there was an error when deleted this record");
                        }


                    }
                }

            }           
        }
        //*******************************************************************************
    }
}
