using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace StakeCamp
{
    public partial class EditCamperForm : Form
    {
        public EditCamperForm()
        {
            InitializeComponent();
        }

        private void updateLBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkMainMenu(object sender, EventArgs e)
        {
            mainMenu mainM = new mainMenu();
            this.Hide();
            mainM.Show();
            mainM.Top = this.Top;
            mainM.Left = this.Left;
        }

        private void updateForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'girlsCampDataSet.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.girlsCampDataSet.customers);
            // TODO: This line of code loads data into the 'girlsCampDataSet.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.girlsCampDataSet.customers);
            // TODO: This line of code loads data into the 'girlsCampDataSet.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.girlsCampDataSet.customers);
            // TODO: This line of code loads data into the 'girlsCampDataSet.adults' table. You can move, or remove it, as needed.
            
        }       

        private void dgEdit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            customersBindingSource.RemoveCurrent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.girlsCampDataSet);
        }
    }
}
