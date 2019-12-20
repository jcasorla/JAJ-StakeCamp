using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;

namespace StakeCamp
{
    public partial class editWards : Form
    {
        public editWards()
        {
            InitializeComponent();
        }
        ManageCamp EditData = new ManageCamp();

        //*******************MAIN MENU LINK**********************************************
        private void linkMainMenu(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************EDIT DECISION LINK******************************************
        private void linkEditDecision(object sender, LinkLabelLinkClickedEventArgs e)
        {
            editDecision editDecFrm = new editDecision();
            this.Hide();
            editDecFrm.Show();
            editDecFrm.Top = this.Top;
            editDecFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            

            if (dg1.Rows[e.RowIndex].Cells["Edit"].Selected)
            {
                string id = dg1.Rows[e.RowIndex].Cells["Ward"].Value.ToString();
                
                EditData.WardID = id;               
                MessageBox.Show("You clicked on edit");
                tbWardName.Text = id;               
                DbCommand comm = GenericDataAccess.CreateCommand();

                comm.CommandText = "Select Ward from wards";


                //set the BindingSource DataSource
                EditData.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

                //set the DataGridView DataSource
                dg1.DataSource = EditData.bSource;


                DataGridViewLinkColumn link1 = new DataGridViewLinkColumn();
                link1.HeaderText = "Edit";
                link1.Text = "Edit";
                link1.Name = "Edit";
                link1.Visible = true;
                link1.UseColumnTextForLinkValue = true;
                dg1.Columns.Add(link1);

                DataGridViewLinkColumn link2 = new DataGridViewLinkColumn();
                link2.HeaderText = "Delete";
                link2.Text = "Delete";
                link2.Name = "Delete";
                link2.Visible = true;
                link2.UseColumnTextForLinkValue = true;
                dg1.Columns.Add(link2);

                dg1.Update();

            }
            else if (dg1.Rows[e.RowIndex].Cells["Delete"].Selected)
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
                        string id = dg1.Rows[e.RowIndex].Cells["Ward"].Value.ToString();
                        EditData.WardID = id;
                        MessageBox.Show("You clicked on delete");

                        EditData.deleteWard();

                        EditData.bSource.RemoveCurrent();
                        Validate();
                        EditData.bSource.EndEdit();
                        tbWardName.Clear();
                        DbCommand comm = GenericDataAccess.CreateCommand();

                        comm.CommandText = "Select Ward from wards";


                        //set the BindingSource DataSource
                        EditData.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

                        //set the DataGridView DataSource
                        dg1.DataSource = EditData.bSource;


                        DataGridViewLinkColumn link1 = new DataGridViewLinkColumn();
                        link1.HeaderText = "Edit";
                        link1.Text = "Edit";
                        link1.Name = "Edit";
                        link1.Visible = true;
                        link1.UseColumnTextForLinkValue = true;
                        dg1.Columns.Add(link1);

                        DataGridViewLinkColumn link2 = new DataGridViewLinkColumn();
                        link2.HeaderText = "Delete";
                        link2.Text = "Delete";
                        link2.Name = "Delete";
                        link2.Visible = true;
                        link2.UseColumnTextForLinkValue = true;
                        dg1.Columns.Add(link2);

                        dg1.Update();

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

        //VVVVVVVVVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAA
        //*******************LOAD EDIT FORM**********************************************
        private void editWards_Load(object sender, EventArgs e)
        {
            //TODO: This line of code loads data into the 'girlsCampDataSet.wards' table. You can move, or remove it, as needed.
            DbCommand comm = GenericDataAccess.CreateCommand();

            comm.CommandText = "Select Ward from wards";
                      

            //set the BindingSource DataSource
            EditData.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

            //set the DataGridView DataSource
            dg1.DataSource = EditData.bSource;


            DataGridViewLinkColumn link1 = new DataGridViewLinkColumn();
            link1.HeaderText = "Edit";
            link1.Text = "Edit";
            link1.Name = "Edit";
            link1.Visible = true;
            link1.UseColumnTextForLinkValue = true;
            dg1.Columns.Add(link1);

            DataGridViewLinkColumn link2 = new DataGridViewLinkColumn();
            link2.HeaderText = "Delete";
            link2.Text = "Delete";
            link2.Name = "Delete";
            link2.Visible = true;
            link2.UseColumnTextForLinkValue = true;
            dg1.Columns.Add(link2);

            dg1.Update();
        }
        //*******************************************************************************
        //VVVVVVVVVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAA

        //VVVVVVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAa
        //*******************UPDATE WARD BUTTON***********************************
        private void btnUpdateWard(object sender, EventArgs e)
        {            
            EditData.WardID = tbWardName.Text;
            EditData.updateWard();

            DbCommand cmd = GenericDataAccess.CreateCommand();
            cmd.CommandText = "Select * from wards order by Ward asc";

            DbParameter param = cmd.CreateParameter();
            param.ParameterName = "@CurrentYear";
            param.DbType = DbType.Int32;
            param.Value = EditData.Currentyear;
            cmd.Parameters.Add(param);
            dg1.DataSource = GenericDataAccess.ExecuteSelectCommand(cmd);
            dg1.Update();
            tbWardName.Clear();

            if (EditData.didNotwork == false)
            {
                MessageBox.Show("Record updated succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when updating this record");
            }
        }
        //*******************************************************************************
        //VVVVVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    }
}
