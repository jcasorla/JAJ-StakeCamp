using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace StakeCamp
{
    public partial class editCamperForm : Form
    {
        public editCamperForm()
        {
            InitializeComponent();
            NestComboBox();
            TransComboBox();
            levelComboBox();//*****VEA
            wardComboBox();
            this.CampTabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.CampTabs.DrawItem += new DrawItemEventHandler(this.tabControl1_DrawItem);
        }
        public int tempNestID;
        public int tempTransID;

        private void campClearForm(object sender, EventArgs e)
        {
            //camper tab
            label1.ForeColor = Color.Black;
            label1.BackColor = Color.White;

            label2.ForeColor = Color.Black;
            label2.BackColor = Color.White;

            label7.ForeColor = Color.Black;
            label7.BackColor = Color.White;

            label8.ForeColor = Color.Black;
            label8.BackColor = Color.White;

            label28.ForeColor = Color.Black;
            label28.BackColor = Color.White;

            birthDateLbl.ForeColor = Color.Black;
            birthDateLbl.BackColor = Color.White;

            label6.ForeColor = Color.Black;
            label6.BackColor = Color.White;

            cbAttenAs.SelectedIndex = -1;
            cbWard.SelectedIndex = -1;
            tbFName.Clear();
            tbLName.Clear();
            tbAddy.Clear();
            tbCity.Clear();
            tbState.Clear();
            tbPostCode.Clear();
            //homephone
            tbHomePhArea.Clear();
            tbHomePh3.Clear();
            tbHomePh4.Clear();
            //cellphone
            tbCellPhArea.Clear();
            tbCellPh3.Clear();
            tbCellPh4.Clear();

            tbEmail.Clear();
            tbMonth.Clear();
            tbDate.Clear();
            tbYear.Clear();
        }

        public void nextEnrollment(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpEnrollment;

        }

        private void enrollClearForm(object sender, EventArgs e)
        {
            ckbxRecReg.Checked = false;
            ckbxMedForm.Checked = false;
            ckbxRecConsent.Checked = false;
            ckbxRecMoney.Checked = false;
            rtbAddComments.Clear();
        }

        private void nextGuardian(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpGuardian;
        }

        private void clearGuardForm(object sender, EventArgs e)
        {
            //guardian tab

            lblHomePh.ForeColor = Color.Black;
            lblHomePh.BackColor = Color.White;

            lblCellPh.ForeColor = Color.Black;
            lblCellPh.BackColor = Color.White;

            label20.ForeColor = Color.Black;
            label20.BackColor = Color.White;

            label21.ForeColor = Color.Black;
            label21.BackColor = Color.White;

            lblPostCode.ForeColor = Color.Black;
            lblPostCode.BackColor = Color.White;

            lblEmail.ForeColor = Color.Black;
            lblEmail.BackColor = Color.White;

            label19.ForeColor = Color.Black;
            label19.BackColor = Color.White;

            label22.ForeColor = Color.Black;
            label22.BackColor = Color.White;

            tbGFName.Clear();
            tbGLName.Clear();
            tbGAddy.Clear();
            tbGCity.Clear();
            tbGState.Clear();
            tbGPostCode.Clear();
            //guardian 1 homephone
            tbGHomeArea.Clear();
            tbGHomePh3.Clear();
            tbGHomePh4.Clear();
            //guardian 1 cellphone
            tbGCellArea.Clear();
            tbGCellPh3.Clear();
            tbGCellPh4.Clear();

            tbGEmail.Clear();
            tbGFName2.Clear();
            tbGLName2.Clear();
            tbGAddy2.Clear();
            tbGCity2.Clear();
            tbGState2.Clear();
            tbGPostCode2.Clear();
            //guardian 2 homephone
            tbGHomeArea2.Clear();
            tbGHomePh32.Clear();
            tbGHomePh42.Clear();
            //guardian 2 cellphone
            tbGCellArea2.Clear();
            tbGCell32.Clear();
            tbGCell42.Clear();

            tbGEmail2.Clear();
        }

        private void nextMedical(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpMedical;
        }

        private void clearMedForm(object sender, EventArgs e)
        {

            rbAsthmaY.Checked = false;
            rbAsthmaN.Checked = false;
            rbMedsY.Checked = false;
            rbMedsN.Checked = false;
            rbAllergyY.Checked = false;
            rbAllergyN.Checked = false;
            rbtLimitations.Clear();
        }

        private void nextEmerContact(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpEmerCont;
        }

        private void clearEmerForm(object sender, EventArgs e)
        {
            //emg contact tab
            lblPhNum.ForeColor = Color.Black;
            lblPhNum.BackColor = Color.White;
            tbECFName.Clear();
            tbECLName.Clear();
            //emg phone
            tbECPhoneArea.Clear();
            tbECPhone3.Clear();
            tbECPhone4.Clear();

            tbRelat.Clear();
        }

        private void goCamper(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpCamper;
        }

        private void goEnrollment(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpEnrollment;
        }

        private void goGuardian(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpGuardian;
        }

        private void goMedical(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpMedical;
        }


        Girls dataAccess = new Girls();
        private void editCamperForm_Load(object sender, EventArgs e)
        {           

            // TODO: This line of code loads data into the 'girlsCampDataSet.nests' table. You can move, or remove it, as needed.
            DbCommand comm = GenericDataAccess.CreateCommand();

            comm.CommandText = "Select CustomerID, First_name, Last_name " +
                "FROM customers INNER JOIN customer_level_link ON customers.CustomerID = customer_level_link.Customer_id " +
                "where LevelYear = ? " +
                "order by Last_name asc";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Currentyear";
            param.DbType = DbType.Int32;
            param.Value = dataAccess.Currentyear;
            comm.Parameters.Add(param);

            //set the BindingSource DataSource
            dataAccess.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

            //set the DataGridView DataSource
            dg.DataSource = dataAccess.bSource;
          
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



        private void UdtCamperBtn_Click(object sender, EventArgs e)
        {           
            bool valid1 = validateCamperTab();
            if (valid1 == true)
            {

            }
            else
            {
                dataAccess.Level = cbAttenAs.Text;
                dataAccess.WardID = cbWard.Text;
                dataAccess.FirstName = tbFName.Text;
                dataAccess.LastName = tbLName.Text;
                dataAccess.Address = tbAddy.Text;
                dataAccess.City = tbCity.Text;
                dataAccess.State = tbState.Text;
                dataAccess.ZipCode = tbPostCode.Text;
                if (tbHomePhArea.Text == string.Empty || tbHomePh3.Text == string.Empty || tbHomePh4.Text == string.Empty)
                {
                    dataAccess.HomePhone = "";
                }
                else
                {
                    //homephone
                    dataAccess.HomePhone = "(" + tbHomePhArea.Text + ") " + tbHomePh3.Text + "-" + tbHomePh4.Text;
                }
                if (tbCellPhArea.Text == string.Empty || tbCellPh3.Text == string.Empty || tbCellPh4.Text == string.Empty)
                {
                    dataAccess.CellPhone = "";
                }
                else
                {
                    //cellphone
                    dataAccess.CellPhone = "(" + tbCellPhArea.Text + ") " + tbCellPh3.Text + "-" + tbCellPh4.Text;
                }
                if (tbMonth.Text == string.Empty || tbDate.Text == string.Empty || tbYear.Text == string.Empty)
                {
                    dataAccess.BirthDate = "";
                }
                else
                {
                    dataAccess.BirthDate = tbMonth.Text + "/" + tbDate.Text + "/" + tbYear.Text;
                }
                dataAccess.Email = tbEmail.Text;
                dataAccess.updateCamper();//updates the customer table
                DbCommand cmd = GenericDataAccess.CreateCommand();

                cmd.CommandText = "Select CustomerID, First_name, Last_name " +
                   "FROM customers INNER JOIN customer_level_link ON customers.CustomerID = customer_level_link.Customer_id " +
                   "where LevelYear = ? " +
                   "order by Last_name asc";

                DbParameter param = cmd.CreateParameter();
                param.ParameterName = "@Currentyear";
                param.DbType = DbType.Int32;
                param.Value = dataAccess.Currentyear;
                cmd.Parameters.Add(param);

                dg.DataSource = GenericDataAccess.ExecuteSelectCommand(cmd);
                dg.Update();

                if (dataAccess.didNotwork == false)
                {
                    MessageBox.Show("Record updated succesfully");
                }
                else
                {
                    MessageBox.Show("It appears there was an error when updating this record");
                }
            }
        }


        private void updEnrollBtn_Click(object sender, EventArgs e)
        {            
            if (ckbxRecReg.Checked == true)
            {
                dataAccess.RecievedRegistration = "Yes";

            }
            else
            {
                dataAccess.RecievedRegistration = "No";
            }
            if (ckbxMedForm.Checked == true)
            {
                dataAccess.RecievedMedicalForm = "Yes";
            }
            else
            {
                dataAccess.RecievedMedicalForm = "No";
            }
            if (ckbxRecConsent.Checked == true)
            {
                dataAccess.RecievedEmergencyConcent = "Yes";
            }
            else
            {
                dataAccess.RecievedEmergencyConcent = "No";
            }
            if (ckbxRecMoney.Checked == true)
            {
                dataAccess.RecievedPayment = "Yes";
            }
            else
            {
                dataAccess.RecievedPayment = "No";

            }
            dataAccess.EnrollComments = rtbAddComments.Text;
            dataAccess.updateRegistration();

            if (dataAccess.didNotwork == false)
            {
                MessageBox.Show("Record updated succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when updating this record");
            }
        }

        private void updGuardBtn_Click(object sender, EventArgs e)
        {           
            bool valid2 = validateGuardianTab();
            if (valid2 == true)
            {

            }
            else
            {
                for (int i = 0; i < dataAccess.GuardianArray.Length; i++)
                {
                    dataAccess.GuardianID = dataAccess.GuardianArray[i];
                    if (i == 0)
                    {
                        dataAccess.GuardFName = tbGFName.Text;
                        dataAccess.GuardLName = tbGLName.Text;
                        dataAccess.GuardAddress = tbGAddy.Text;
                        dataAccess.GuardCity = tbGCity.Text;
                        dataAccess.GuardState = tbGState.Text;
                        dataAccess.GuardZipCode = tbGPostCode.Text;
                        if (tbGHomeArea.Text == string.Empty || tbGHomePh3.Text == string.Empty || tbGHomePh4.Text == string.Empty)
                        {
                            dataAccess.GuardHPhone = "";
                        }
                        else
                        {
                            //guardian 1 homephone
                            dataAccess.GuardHPhone = "(" + tbGHomeArea.Text + ") " + tbGHomePh3.Text + "-" + tbGHomePh4.Text;
                        }
                        if (tbGCellArea.Text == string.Empty || tbGCellPh3.Text == string.Empty || tbGCellPh4.Text == string.Empty)
                        {
                            dataAccess.GuardCPhone = "";
                        }
                        else
                        {
                            //guardian 1 cellphone
                            dataAccess.GuardCPhone = "(" + tbGCellArea.Text + ") " + tbGCellPh3.Text + "-" + tbGCellPh4.Text;
                        }
                        dataAccess.GuardEmail = tbGEmail.Text;
                        dataAccess.updateGuardianInfo();
                    }
                    if (i == 1)
                    {
                        dataAccess.GuardFName = tbGFName2.Text;
                        dataAccess.GuardLName = tbGLName2.Text;
                        dataAccess.GuardAddress = tbGAddy2.Text;
                        dataAccess.GuardCity = tbGCity2.Text;
                        dataAccess.GuardState = tbGState2.Text;
                        dataAccess.GuardZipCode = tbGPostCode2.Text;
                        if (tbGHomeArea2.Text == string.Empty || tbGHomePh32.Text == string.Empty || tbGHomePh42.Text == string.Empty)
                        {
                            dataAccess.GuardHPhone = "";
                        }
                        else
                        {
                            //guardian 2 homephone
                            dataAccess.GuardHPhone = "(" + tbGHomeArea2.Text + ") " + tbGHomePh32.Text + "-" + tbGHomePh42.Text;
                        }
                        if (tbGCellArea2.Text == string.Empty || tbGCell32.Text == string.Empty || tbGCell42.Text == string.Empty)
                        {
                            dataAccess.GuardCPhone = "";
                        }
                        else
                        {
                            //guardian 2 cellphone
                            dataAccess.GuardCPhone = "(" + tbGCellArea2.Text + ") " + tbGCell32.Text + "-" + tbGCell42.Text;
                        }
                        dataAccess.GuardEmail = tbGEmail2.Text;
                        dataAccess.updateGuardianInfo();


                        if (dataAccess.didNotwork == false)
                        {
                            MessageBox.Show("Record updated succesfully");
                        }
                        else
                        {
                            MessageBox.Show("It appears there was an error when updating this record");
                        }
                    }
                }
            }

        }

        private void UpdMedBtn_Click(object sender, EventArgs e)
        {           
            if (rbAsthmaY.Checked == true)
            {
                dataAccess.AsthmaYN = "Yes";
            }
            else
            {
                dataAccess.AsthmaYN = "No";
            }
            if (rbMedsY.Checked == true)
            {
                dataAccess.MedsYN = "Yes";
            }
            else
            {
                dataAccess.MedsYN = "No";
            }
            if (rbAllergyY.Checked == true)
            {
                dataAccess.AllergyYN = "Yes";

            }
            else
            {
                dataAccess.AllergyYN = "No";
            }
            dataAccess.updateMedicalInfo();
            LimitRBTBox.Text.Trim();
            dataAccess.LimitDescription = rbtLimitations.Text.Split(',');
            for (int i = 0; i < dataAccess.LimitationsArray.Length; i++)
            {
                dataAccess.LimitationsID = dataAccess.LimitationsArray[i];
                dataAccess.updateLimitationsInfo();
                //******start Validation*********
                //if (dataAccess.LimitDescription < 0)
                //{
                //    //then delete existing limitations
                //}
                //else if (dataAccess.LimitDescription > dataAccess.LimitationsArray)
                //{
                //    //add more limitations depending on how much more bigger is limitationsArray
                //    //then updtate existing limitations

                //}
                //else
                //{
                //    //update existing limitations
                //    //dataAccess.LimitationsID = dataAccess.LimitationsArray[i];
                //    //dataAccess.updateLimitationsInfo();
                //}
                //*********End Validation*******

                //similar concept for guardians


                if (dataAccess.didNotwork == false)
                {
                    MessageBox.Show("Record updated succesfully");
                }
                else
                {
                    MessageBox.Show("It appears there was an error when updating this record");
                }
            }
        }

        private void UpdEContactBtn_Click(object sender, EventArgs e)
        {           
            bool valid3 = validateEmg();
            if (valid3 == true)
            {

            }
            else
            {
                dataAccess.EmgFirstName = tbECFName.Text;
                dataAccess.EmgLastName = tbECLName.Text;
                if (tbECPhoneArea.Text == string.Empty || tbECPhone3.Text == string.Empty || tbECPhone4.Text == string.Empty)
                {
                    dataAccess.EmgPhone = "";
                }
                else
                {
                    //emg phone
                    dataAccess.EmgPhone = "(" + tbECPhoneArea.Text + ") " + tbECPhone3.Text + "-" + tbECPhone4.Text;
                }
                dataAccess.EmgRelationship = tbRelat.Text;
                dataAccess.updateEmergencyContactInfo();

                if (dataAccess.didNotwork == false)
                {
                    MessageBox.Show("Record updated succesfully");
                }
                else
                {
                    MessageBox.Show("It appears there was an error when updating this record");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           
            string id = dg.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();

            if (dg.Rows[e.RowIndex].Cells["Edit"].Selected)
            {
                clearAll();
                MessageBox.Show("You clicked on edit");
                dataAccess.GetCustomer(id);//calls function in order to retrieve data from customers table                
                //********Camper Tab************
                tbFName.Text = dataAccess.FirstName;
                tbLName.Text = dataAccess.LastName;
                tbAddy.Text = dataAccess.Address;
                tbCity.Text = dataAccess.City;
                tbState.Text = dataAccess.State;
                tbPostCode.Text = dataAccess.ZipCode;
                if (dataAccess.HomePhone == string.Empty)
                {
                    tbHomePhArea.Text = "";
                    tbHomePh3.Text = "";
                    tbHomePh4.Text = "";
                }
                else
                {
                    string[] hPhone = dataAccess.HomePhone.Split('(', ')', ' ', '-');
                    //homephone
                    tbHomePhArea.Text = hPhone[1];
                    tbHomePh3.Text = hPhone[3];
                    tbHomePh4.Text = hPhone[4];
                }

                if (dataAccess.CellPhone == string.Empty)
                {
                    tbCellPhArea.Text = "";
                    tbCellPh3.Text = "";
                    tbCellPh4.Text = "";
                }
                else
                {
                    string[] cPhone = dataAccess.CellPhone.Split('(', ')', ' ', '-');
                    //cellphone
                    tbCellPhArea.Text = cPhone[1];
                    tbCellPh3.Text = cPhone[3];
                    tbCellPh4.Text = cPhone[4];
                }

                tbEmail.Text = dataAccess.Email;
                if (dataAccess.BirthDate == string.Empty)
                {
                    tbMonth.Text = "";
                    tbDate.Text = "";
                    tbYear.Text = "";
                }
                else
                {
                    string[] bDay = dataAccess.BirthDate.Split('/', ' ');
                    tbMonth.Text = bDay[0];
                    tbDate.Text = bDay[1];
                    tbYear.Text = bDay[2];
                }
                cbAttenAs.Text = dataAccess.Level;
               
                cbWard.Text = dataAccess.WardID;

                //*******Guardian Tab*********
                for (int i = 0; i < dataAccess.GuardianArray.Length; i++)
                {
                    dataAccess.GuardianID = dataAccess.GuardianArray[i];
                    if (i == 0)
                    {
                        dataAccess.GetGuardian();
                        tbGFName.Text = dataAccess.GuardFName;
                        tbGLName.Text = dataAccess.GuardLName;
                        tbGAddy.Text = dataAccess.GuardAddress;
                        tbGCity.Text = dataAccess.GuardCity;
                        tbGState.Text = dataAccess.GuardState;
                        tbGPostCode.Text = dataAccess.GuardZipCode;
                        if (dataAccess.GuardHPhone == string.Empty)
                        {
                            tbGHomeArea.Text = "";
                            tbGHomePh3.Text = "";
                            tbGHomePh4.Text = "";
                        }
                        else
                        {
                            string[] g1home = dataAccess.GuardHPhone.Split('(', ')', ' ', '-');
                            //guardian 1 homephone
                            tbGHomeArea.Text = g1home[1];
                            tbGHomePh3.Text = g1home[3];
                            tbGHomePh4.Text = g1home[4];
                        }
                        if (dataAccess.GuardCPhone == string.Empty)
                        {
                            tbGCellArea.Text = "";
                            tbGCellPh3.Text = "";
                            tbGCellPh4.Text = "";
                        }
                        else
                        {
                            string[] g1cell = dataAccess.GuardCPhone.Split('(', ')', ' ', '-');
                            //guardian 1 cellphone
                            tbGCellArea.Text = g1cell[1];
                            tbGCellPh3.Text = g1cell[3];
                            tbGCellPh4.Text = g1cell[4];
                        }

                        tbGEmail.Text = dataAccess.GuardEmail;

                    }
                    if (i == 1)
                    {
                        dataAccess.GetGuardian();
                        tbGFName2.Text = dataAccess.GuardFName;
                        tbGLName2.Text = dataAccess.GuardLName;
                        tbGAddy2.Text = dataAccess.GuardAddress;
                        tbGCity2.Text = dataAccess.GuardCity;
                        tbGState2.Text = dataAccess.GuardState;
                        tbGPostCode2.Text = dataAccess.GuardZipCode;
                        if (dataAccess.GuardHPhone == string.Empty)
                        {
                            tbGHomeArea2.Text = "";
                            tbGHomePh32.Text = "";
                            tbGHomePh42.Text = "";
                        }
                        else
                        {
                            string[] g2home = dataAccess.GuardHPhone.Split('(', ')', ' ', '-');
                            //guardian 1 homephone
                            tbGHomeArea2.Text = g2home[1];
                            tbGHomePh32.Text = g2home[3];
                            tbGHomePh42.Text = g2home[4];
                        }

                        if (dataAccess.GuardCPhone == string.Empty)
                        {
                            tbGCellArea2.Text = "";
                            tbGCell32.Text = "";
                            tbGCell42.Text = "";
                        }
                        else
                        {
                            string[] g2cell = dataAccess.GuardCPhone.Split('(', ')', ' ', '-');
                            //guardian 1 cellphone
                            tbGCellArea2.Text = g2cell[1];
                            tbGCell32.Text = g2cell[3];
                            tbGCell42.Text = g2cell[4];
                        }

                        tbGEmail2.Text = dataAccess.GuardEmail;

                    }
                }
                // *********Enrollment Tab***********              
                if (dataAccess.RecievedRegistration == "Yes")
                {
                    ckbxRecReg.Checked = true;
                }
                else
                {
                    ckbxRecReg.Checked = false;
                }
                if (dataAccess.RecievedMedicalForm == "Yes")
                {
                    ckbxMedForm.Checked = true;
                }
                else
                {
                    ckbxMedForm.Checked = false;
                }
                if (dataAccess.RecievedEmergencyConcent == "Yes")
                {
                    ckbxRecConsent.Checked = true;
                }
                else
                {
                    ckbxRecConsent.Checked = false;
                }
                if (dataAccess.RecievedPayment == "Yes")
                {
                    ckbxRecMoney.Checked = true;
                }
                else
                {
                    ckbxRecMoney.Checked = false;
                }

                rtbAddComments.Text = dataAccess.EnrollComments;




                //******Medical Tab**********                 
                if (dataAccess.AsthmaYN == "Yes")
                {
                    rbAsthmaY.Checked = true;
                }
                else
                {
                    rbAsthmaN.Checked = true;
                }
                if (dataAccess.MedsYN == "Yes")
                {

                    rbMedsY.Checked = true;

                }
                else
                {
                    rbMedsN.Checked = true;

                }
                if (dataAccess.AllergyYN == "Yes")
                {
                    rbAllergyY.Checked = true;

                }
                else
                {
                    rbAllergyN.Checked = true;
                }
                string limitationString = "";
                for (int i = 0; i < dataAccess.LimitDescription.Length; i++)//it is used to put all data in array in a string
                {
                    if (i == dataAccess.LimitDescription.Length - 1)
                    {
                        limitationString += dataAccess.LimitDescription[i];

                    }
                    else
                    {
                        limitationString += dataAccess.LimitDescription[i] + ", ";
                    }


                }
                rbtLimitations.Text = limitationString;

                //********Emergency Contact Tab
                tbECFName.Text = dataAccess.EmgFirstName;
                tbECLName.Text = dataAccess.EmgLastName;
                if (dataAccess.EmgPhone == string.Empty)
                {
                    tbECPhoneArea.Text = "";
                    tbECPhone3.Text = "";
                    tbECPhone4.Text = "";
                }
                else
                {
                    string[] emphone = dataAccess.EmgPhone.Split('(', ')', ' ', '-'); ;
                    //emg phone
                    tbECPhoneArea.Text = emphone[1];
                    tbECPhone3.Text = emphone[3];
                    tbECPhone4.Text = emphone[4];
                }

                tbRelat.Text = dataAccess.EmgRelationship;

                //********misc tab*********
                cbCamperNest.Text = dataAccess.NestName;
                tempNestID = dataAccess.NestID;//new
                cbCamperTrans.Text = dataAccess.TransportationType;
                tempTransID = dataAccess.TransportID;//new
            }
            else if (dg.Rows[e.RowIndex].Cells["Delete"].Selected)
            {
                dataAccess.didNotwork = false;
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

                        MessageBox.Show("You clicked on delete");

                        int myParsedInt = Int32.Parse(id);
                        dataAccess.GirlID = Convert.ToInt32(id);
                        dataAccess.GetGuardianLink();
                        dataAccess.GetCustomer(id);
                        dataAccess.GetEnrollIDArray();

                        dataAccess.deleteLevelInfo();
                        dataAccess.deleteLimitationsInfo();
                        dataAccess.deleteMedicalInfo();

                        dataAccess.deleteEnrollmentGirlLink();

                        dataAccess.deleteGirlGuardianLink();


                        for (int i = 0; i < dataAccess.GuardianArray.Length; i++)
                        {
                            dataAccess.GuardianID = dataAccess.GuardianArray[i];
                            if (i == 0)
                            {
                                dataAccess.deleteGuardianInfo();
                            }
                            if (i == 1)
                            {
                                dataAccess.deleteGuardianInfo();
                            }
                        }

                        //new 05/23
                        if (dataAccess.TransportID == 0 || dataAccess.TransportationType == string.Empty)
                        {

                        }
                        else
                        {
                            dataAccess.deleteTransCustomerLink();
                        }
                        if (dataAccess.NestID == 0 || dataAccess.NestName == string.Empty)
                        {

                        }
                        else
                        {
                            dataAccess.deleteGirlNestLink();
                        }//end 05/23

                        for (int i = 0; i < dataAccess.EnrollArray.Length; i++)
                        {
                            dataAccess.EnrollID = dataAccess.EnrollArray[i];
                            dataAccess.deleteRegistration();
                        }
                        dataAccess.deleteCamper();
                        dataAccess.deleteEmergencyContactInfo();



                        dataAccess.bSource.RemoveCurrent();//deletes current cell
                        Validate();//{
                        dataAccess.bSource.EndEdit();//saves changes
                        clearAll();


                        //**************Misc Tab***************
                        cbCamperNest.SelectedIndex = -1;
                        cbCamperTrans.SelectedIndex = -1;

                        if (dataAccess.didNotwork == false)
                        {
                            MessageBox.Show("Record deleted succesfully");
                        }                      
                        else
                        {
                            MessageBox.Show("It appears there was an error when deleting this record");
                        }

                    }

                }
            }



        }
        public void clearAll()
        {
            //camper tab
            label1.ForeColor = Color.Black;
            label1.BackColor = Color.White;

            label2.ForeColor = Color.Black;
            label2.BackColor = Color.White;

            label7.ForeColor = Color.Black;
            label7.BackColor = Color.White;

            label8.ForeColor = Color.Black;
            label8.BackColor = Color.White;

            label28.ForeColor = Color.Black;
            label28.BackColor = Color.White;

            birthDateLbl.ForeColor = Color.Black;
            birthDateLbl.BackColor = Color.White;

            label6.ForeColor = Color.Black;
            label6.BackColor = Color.White;



            //guardian tab

            lblHomePh.ForeColor = Color.Black;
            lblHomePh.BackColor = Color.White;

            lblCellPh.ForeColor = Color.Black;
            lblCellPh.BackColor = Color.White;

            label20.ForeColor = Color.Black;
            label20.BackColor = Color.White;

            label21.ForeColor = Color.Black;
            label21.BackColor = Color.White;

            lblPostCode.ForeColor = Color.Black;
            lblPostCode.BackColor = Color.White;

            lblEmail.ForeColor = Color.Black;
            lblEmail.BackColor = Color.White;

            label19.ForeColor = Color.Black;
            label19.BackColor = Color.White;

            label22.ForeColor = Color.Black;
            label22.BackColor = Color.White;



            //emg contact tab
            lblPhNum.ForeColor = Color.Black;
            lblPhNum.BackColor = Color.White;

            cbAttenAs.SelectedIndex = -1;
            cbWard.SelectedIndex = -1;
            tbFName.Clear();
            tbLName.Clear();
            tbAddy.Clear();
            tbCity.Clear();
            tbState.Clear();
            tbPostCode.Clear();

            //homephone
            tbHomePhArea.Clear();
            tbHomePh3.Clear();
            tbHomePh4.Clear();

            //cellphone
            tbCellPhArea.Clear();
            tbCellPh3.Clear();
            tbCellPh4.Clear();

            tbEmail.Clear();
            tbMonth.Clear();
            tbDate.Clear();
            tbYear.Clear();

            ckbxRecReg.Checked = false;
            ckbxMedForm.Checked = false;
            ckbxRecConsent.Checked = false;
            ckbxRecMoney.Checked = false;
            rtbAddComments.Clear();

            tbGFName.Clear();
            tbGLName.Clear();
            tbGAddy.Clear();
            tbGCity.Clear();
            tbGState.Clear();
            tbGPostCode.Clear();
            //guardian 1 homephone
            tbGHomeArea.Clear();
            tbGHomePh3.Clear();
            tbGHomePh4.Clear();

            //guardian 1 cellphone
            tbGCellArea.Clear();
            tbGCellPh3.Clear();
            tbGCellPh4.Clear();

            tbGEmail.Clear();
            tbGFName2.Clear();
            tbGLName2.Clear();
            tbGAddy2.Clear();
            tbGCity2.Clear();
            tbGState2.Clear();
            tbGPostCode2.Clear();

            //guardian 2 homephone
            tbGHomeArea2.Clear();
            tbGHomePh32.Clear();
            tbGHomePh42.Clear();

            //guardian 2 cellphone
            tbGCellArea2.Clear();
            tbGCell32.Clear();
            tbGCell42.Clear();

            tbGEmail2.Clear();

            rbAsthmaY.Checked = false;
            rbAsthmaN.Checked = false;
            rbMedsY.Checked = false;
            rbMedsN.Checked = false;
            rbAllergyY.Checked = false;
            rbAllergyN.Checked = false;
            rbtLimitations.Clear();

            //***********Emergency contact***********
            tbECFName.Clear();
            tbECLName.Clear();
            //emg phone
            tbECPhoneArea.Clear();
            tbECPhone3.Clear();
            tbECPhone4.Clear();

            tbRelat.Clear();

        }


        private void UpdateMiscbtn_Click(object sender, EventArgs e)
        {
            string updateYN = "";           
            string testTemp1 = cbCamperNest.Text.ToString();
            if (testTemp1 == string.Empty || tempNestID == 0)
            {
                MessageBox.Show("Please add Nest first ");
            }
            else
            {
                string temp1 = cbCamperNest.SelectedValue.ToString();
                int myParsedInt1 = Int32.Parse(temp1);
                dataAccess.NestID = Convert.ToInt32(temp1);
                dataAccess.updateGirlsNestLink();
                updateYN = "Nest ";
            }
            string testTemp2 = cbCamperTrans.Text.ToString();
            if (testTemp2 == string.Empty || tempTransID == 0)
            {
                MessageBox.Show("Please add transportation first ");
            }
            else
            {
                string temp2 = cbCamperTrans.SelectedValue.ToString();
                int myParsedInt2 = Int32.Parse(temp2);
                dataAccess.TransportID = Convert.ToInt32(temp2);
                dataAccess.updateTransCustomerLink();
                updateYN = "Transportation ";
            }

            if (dataAccess.didNotwork  == false)
            {
                MessageBox.Show("Record updated succesfully");
            }           
            else
            {
                MessageBox.Show("It appears there was an error when updating this record");
            }

        }
        public void NestComboBox()
        {
            //nest            
            DbCommand comm = GenericDataAccess.CreateCommand();           
            comm.CommandText = "Select Nest_id, Nest_name from nests where NestYear=?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CurrentYear";
            param.DbType = DbType.Int32;
            param.Value = dataAccess.Currentyear;
            comm.Parameters.Add(param);

            cbCamperNest.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);
            cbCamperNest.DisplayMember = "Nest_name";
            cbCamperNest.ValueMember = "Nest_id";
            cbCamperNest.SelectedIndex = -1;

        }
        public void TransComboBox()
        {
            //transportation
            DbCommand comm2 = GenericDataAccess.CreateCommand();//t.Transportation_id, t.Transportation
            comm2.CommandText = "Select Transportation_id, Transportation from transportation";

            cbCamperTrans.DataSource = GenericDataAccess.ExecuteSelectCommand(comm2);
            cbCamperTrans.DisplayMember = "Transportation";
            cbCamperTrans.ValueMember = "Transportation_id";
            cbCamperTrans.SelectedIndex = -1;
        }

        private void PreviousMisc_Click(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpEmerCont;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = Misc;
        }

        private void clearMisc_Click(object sender, EventArgs e)
        {
            cbCamperNest.SelectedIndex = -1;
            cbCamperTrans.SelectedIndex = -1;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //back to edit
            editDecision editDecFrm = new editDecision();
            this.Hide();
            editDecFrm.Show();
            editDecFrm.Top = this.Top;
            editDecFrm.Left = this.Left; ;

        }

        private void linkECMain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //back to main menu
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
        }
        //VVVVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        public void wardComboBox()
        {
            DbCommand comm2 = GenericDataAccess.CreateCommand();
            comm2.CommandText = "Select ward from wards";

            cbWard.DataSource = GenericDataAccess.ExecuteSelectCommand(comm2);
            cbWard.DisplayMember = "Ward";           
            cbWard.SelectedIndex = -1;
        }
        //VVVVVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

        //VVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        public void levelComboBox()
        {
            DbCommand comm2 = GenericDataAccess.CreateCommand();//t.Transportation_id, t.Transportation
            comm2.CommandText = "Select [level] from levels";

            cbAttenAs.DataSource = GenericDataAccess.ExecuteSelectCommand(comm2);
            cbAttenAs.DisplayMember = "Level";           
            cbAttenAs.SelectedIndex = -1;
        }
        //VVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

        //new 05/26
        private bool isNumValid(string num)
        {

            int n = 0;
            try
            {
                n = Int32.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool isEmail(string email)
        {
            foreach (char c in email)
            {
                if (c == '@')
                {
                    return false;
                }
            }
            return true;
        }//end new 05/26

        public bool validateCamperTab()
        {
            bool problems = false;
            if (tbFName.Text == string.Empty)
            {
                MessageBox.Show("First Name is a required field");
                label1.ForeColor = Color.White;
                label1.BackColor = Color.Red;
                problems = true;

            }
            if (tbLName.Text == string.Empty)
            {
                MessageBox.Show("Last Name is a required field");
                label2.ForeColor = Color.White;
                label2.BackColor = Color.Red;
                problems = true;

            }
            

            //homephone
            if (tbHomePhArea.Text != string.Empty || tbHomePh3.Text != string.Empty || tbHomePh4.Text != string.Empty)
            {
                if (tbHomePhArea.Text.Length != 3 || tbHomePh3.Text.Length != 3 || tbHomePh4.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the homephone field");
                    label7.ForeColor = Color.White;
                    label7.BackColor = Color.Red;
                    problems = true;
                }
                else
                {
                    bool valid1 = isNumValid(tbHomePhArea.Text.ToString());
                    bool valid2 = isNumValid(tbHomePh3.Text.ToString());
                    bool valid3 = isNumValid(tbHomePh4.Text.ToString());

                    if (valid1 == true && valid2 == true && valid3 == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please check that you entered only numbers in the homephone field");
                        label7.ForeColor = Color.White;
                        label7.BackColor = Color.Red;
                        problems = true;
                    }
                }
            }

            //cellphone
            if (tbCellPhArea.Text != string.Empty || tbCellPh3.Text != string.Empty || tbCellPh4.Text != string.Empty)
            {
                if (tbCellPhArea.Text.Length != 3 || tbCellPh3.Text.Length != 3 || tbCellPh4.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the cellphone field");
                    problems = true;
                    label8.ForeColor = Color.White;
                    label8.BackColor = Color.Red;
                }
                else
                {
                    bool valid1 = isNumValid(tbCellPhArea.Text.ToString());
                    bool valid2 = isNumValid(tbCellPh3.Text.ToString());
                    bool valid3 = isNumValid(tbCellPh4.Text.ToString());
                    if (valid1 == true && valid2 == true && valid3 == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please check that you entered only numbers in the cellphone field");
                        problems = true;
                        label8.ForeColor = Color.White;
                        label8.BackColor = Color.Red;
                    }
                }
            }

            if (tbEmail.Text != string.Empty)
            {
                string EmailRegex = "^((?>[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+\\x20*|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\"\\x20*)*(?<angle><))?((?!\\.)(?>\\.?[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+)+|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\")@(((?!-)[a-zA-Z\\d\\-]+(?<!-)\\.)+[a-zA-Z]{2,}|\\[(((?(?<!\\[)\\.)(25[0-5]|2[0-4]\\d|[01]?\\d?\\d)){4}|[a-zA-Z\\d\\-]*[a-zA-Z\\d]:((?=[\\x01-\\x7f])[^\\\\\\[\\]]|\\\\[\\x01-\\x7f])+)\\])(?(angle)>)$";
                Regex re = new Regex(EmailRegex);
                bool Valid = re.IsMatch(tbEmail.Text.ToString());
                if (isEmail(tbEmail.Text.ToString()))
                {
                    MessageBox.Show("Please make sure that email is in proper format");
                    problems = true;
                    label28.ForeColor = Color.White;
                    label28.BackColor = Color.Red;
                }
                else
                {
                    if (Valid == true)
                    {
                    }

                    else
                    {
                        MessageBox.Show("Please make sure that email is in proper format");
                        label28.ForeColor = Color.White;
                        label28.BackColor = Color.Red;
                        problems = true;
                    }

                }
            }
            if (tbYear.Text != string.Empty || tbDate.Text != string.Empty || tbMonth.Text != string.Empty)
            {
                if (tbYear.Text.Length != 4 || tbDate.Text.Length != 2 || tbMonth.Text.Length != 2)
                {
                    MessageBox.Show("please check that you entered the birthdate in the correct format");
                    problems = true;
                    birthDateLbl.ForeColor = Color.White;
                    birthDateLbl.BackColor = Color.Red;
                }
                else
                {
                    bool valid1 = isNumValid(tbYear.Text.ToString());
                    bool valid2 = isNumValid(tbDate.Text.ToString());
                    bool valid3 = isNumValid(tbMonth.Text.ToString());
                    if (valid1 == true && valid2 == true && valid3 == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please check that you entered only numbers in the birthdate field");
                        problems = true;
                        birthDateLbl.ForeColor = Color.White;
                        birthDateLbl.BackColor = Color.Red;
                    }

                }
            }
            if (tbPostCode.Text != string.Empty)
            {
                if (tbPostCode.Text.Length != 5)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the guardian 2 zipcode field");
                    problems = true;
                    label6.ForeColor = Color.White;
                    label6.BackColor = Color.Red;
                }
                else
                {
                    if (isNumValid(tbPostCode.Text.ToString()))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please check that you entered only numbers in the zipcode field");
                        problems = true;
                        label6.ForeColor = Color.White;
                        label6.BackColor = Color.Red;
                    }
                }
            }               

            return problems;
        }
        public bool validateGuardianTab()
        {
            bool problem = false;
            //guardian 1 homephone
            if (tbGHomeArea.Text != string.Empty || tbGHomePh3.Text != string.Empty || tbGHomePh4.Text != string.Empty)
            {
                if (tbGHomeArea.Text.Length != 3 || tbGHomePh3.Text.Length != 3 || tbGHomePh4.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the guardian 1 homephone field");
                    lblHomePh.ForeColor = Color.White;
                    lblHomePh.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    bool valid1 = isNumValid(tbGHomeArea.Text.ToString());
                    bool valid2 = isNumValid(tbGHomePh3.Text.ToString());
                    bool valid3 = isNumValid(tbGHomePh4.Text.ToString());
                    if (valid1 == true && valid2 == true && valid3 == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please check that you entered only numbers in the guardian 1 homephone field");
                        lblHomePh.ForeColor = Color.White;
                        lblHomePh.BackColor = Color.Red;
                        problem = true;
                    }
                }
            }

            //guardian 1 cellphone
            if (tbGCellArea.Text != string.Empty || tbGCellPh3.Text != string.Empty || tbGCellPh4.Text != string.Empty)
            {
                if (tbGCellArea.Text.Length != 3 || tbGCellPh3.Text.Length != 3 || tbGCellPh4.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the guardian 1 cellphone field");
                    lblCellPh.ForeColor = Color.White;
                    lblCellPh.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    bool valid1 = isNumValid(tbGCellArea.Text.ToString());
                    bool valid2 = isNumValid(tbGCellPh3.Text.ToString());
                    bool valid3 = isNumValid(tbGCellPh4.Text.ToString());
                    if (valid1 == true && valid2 == true && valid3 == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please check that you entered only numbers in the guardian 1 cellphone field");
                        lblCellPh.ForeColor = Color.White;
                        lblCellPh.BackColor = Color.Red;
                        problem = true;
                    }
                }
            }

            //guardian2 homephone            
            if (tbGHomeArea2.Text != string.Empty || tbGHomePh32.Text != string.Empty || tbGHomePh42.Text != string.Empty)
            {
                if (tbGHomeArea2.Text.Length != 3 || tbGHomePh32.Text.Length != 3 || tbGHomePh42.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the guardian 2 homephone field");
                    label20.ForeColor = Color.White;
                    label20.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    bool valid1 = isNumValid(tbGHomeArea2.Text.ToString());
                    bool valid2 = isNumValid(tbGHomePh32.Text.ToString());
                    bool valid3 = isNumValid(tbGHomePh42.Text.ToString());
                    if (valid1 == true && valid2 == true && valid3 == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please check that you entered only numbers in the guardian 2 homephone field");
                        label20.ForeColor = Color.White;
                        label20.BackColor = Color.Red;
                        problem = true;
                    }
                }
            }

            //guardian2 cellphone           
            if (tbGCellArea2.Text != string.Empty || tbGCell32.Text != string.Empty || tbGCell42.Text != string.Empty)
            {
                if (tbGCellArea2.Text.Length != 3 || tbGCell32.Text.Length != 3 || tbGCell42.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the guardian 2 cellphone field");
                    label21.ForeColor = Color.White;
                    label21.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    bool valid1 = isNumValid(tbGCellArea2.Text.ToString());
                    bool valid2 = isNumValid(tbGCell32.Text.ToString());
                    bool valid3 = isNumValid(tbGCell42.Text.ToString());
                    if (valid1 == true && valid2 == true && valid3 == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please check that you entered only numbers in the guardian 2 cellphone field");
                        label21.ForeColor = Color.White;
                        label21.BackColor = Color.Red;
                        problem = true;
                    }
                }
            }

            if (tbGPostCode.Text != string.Empty)
            {
                if (tbGPostCode.Text.Length != 5)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the guardian 1 zipcode field");
                    lblPostCode.ForeColor = Color.White;
                    lblPostCode.BackColor = Color.Red;
                    problem = true;
                }
                else
                {

                    if (isNumValid(tbGPostCode.Text.ToString()))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please check that you entered only numbers in the guardian 1 zipcode field");
                        lblPostCode.ForeColor = Color.White;
                        lblPostCode.BackColor = Color.Red;
                        problem = true;
                    }
                }
            }
            if (tbGEmail.Text != string.Empty)
            {
                string EmailRegex = "^((?>[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+\\x20*|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\"\\x20*)*(?<angle><))?((?!\\.)(?>\\.?[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+)+|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\")@(((?!-)[a-zA-Z\\d\\-]+(?<!-)\\.)+[a-zA-Z]{2,}|\\[(((?(?<!\\[)\\.)(25[0-5]|2[0-4]\\d|[01]?\\d?\\d)){4}|[a-zA-Z\\d\\-]*[a-zA-Z\\d]:((?=[\\x01-\\x7f])[^\\\\\\[\\]]|\\\\[\\x01-\\x7f])+)\\])(?(angle)>)$";
                Regex re = new Regex(EmailRegex);
                bool Valid = re.IsMatch(tbGEmail.Text.ToString());
                if (isEmail(tbGEmail.Text.ToString()))
                {
                    MessageBox.Show("Please make sure that email is in proper format");
                    lblEmail.ForeColor = Color.White;
                    lblEmail.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    if (Valid == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please make sure that email is in proper format");
                        lblEmail.ForeColor = Color.White;
                        lblEmail.BackColor = Color.Red;
                        problem = true;

                    }
                }
            }
            if (tbGPostCode2.Text != string.Empty)
            {
                if (tbGPostCode2.Text.Length != 5)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the guardian 2 zipcode field");
                    label19.ForeColor = Color.White;
                    label19.BackColor = Color.Red;
                    problem = true;
                }
                else
                {

                    if (isNumValid(tbGPostCode2.Text.ToString()))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please check that you entered only numbers in the guardian 2 zipcode field");
                        label19.ForeColor = Color.White;
                        label19.BackColor = Color.Red;
                        problem = true;
                    }
                }
            }
            if (tbGEmail2.Text != string.Empty)
            {
                string EmailRegex = "^((?>[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+\\x20*|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\"\\x20*)*(?<angle><))?((?!\\.)(?>\\.?[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+)+|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\")@(((?!-)[a-zA-Z\\d\\-]+(?<!-)\\.)+[a-zA-Z]{2,}|\\[(((?(?<!\\[)\\.)(25[0-5]|2[0-4]\\d|[01]?\\d?\\d)){4}|[a-zA-Z\\d\\-]*[a-zA-Z\\d]:((?=[\\x01-\\x7f])[^\\\\\\[\\]]|\\\\[\\x01-\\x7f])+)\\])(?(angle)>)$";
                Regex re = new Regex(EmailRegex);
                bool Valid = re.IsMatch(tbGEmail2.Text.ToString());
                if (isEmail(tbGEmail2.Text.ToString()))
                {
                    MessageBox.Show("Please make sure that email is in proper format");
                    label22.ForeColor = Color.White;
                    label22.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    if (Valid == true)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Please make sure that email is in proper format");
                        label22.ForeColor = Color.White;
                        label22.BackColor = Color.Red;
                        problem = true;
                    }


                }
            }
            return problem;
        }
        public bool validateEmg()
        {
            bool problem = false;
            if (tbECPhoneArea.Text != string.Empty || tbECPhone3.Text != string.Empty || tbECPhone4.Text != string.Empty)
            {
                if (tbECPhoneArea.Text.Length != 3 || tbECPhone3.Text.Length != 3 || tbECPhone4.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the emergency contact phone field");
                    lblPhNum.ForeColor = Color.White;
                    lblPhNum.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    bool valid1 = isNumValid(tbECPhoneArea.Text.ToString());
                    bool valid2 = isNumValid(tbECPhone3.Text.ToString());
                    bool valid3 = isNumValid(tbECPhone4.Text.ToString());
                    if (valid1 == true && valid2 == true && valid3 == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please check that you entered only numbers in the emergency contact phone field");
                        lblPhNum.ForeColor = Color.White;
                        lblPhNum.BackColor = Color.Red;
                        problem = true;
                    }
                }
            }

            return problem;
        }
        private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Font f;
            Brush backBrush;
            Brush foreBrush;

            if (e.Index == this.CampTabs.SelectedIndex)
            {
                f = new Font(e.Font, FontStyle.Italic | FontStyle.Bold);

                backBrush = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.DodgerBlue, Color.LightSteelBlue, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                foreBrush = Brushes.Snow;
            }
            else
            {
                f = e.Font;
                backBrush = new SolidBrush(e.BackColor);
                foreBrush = new SolidBrush(e.ForeColor);
            }

            string tabName = this.CampTabs.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            e.Graphics.FillRectangle(backBrush, e.Bounds);
            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString(tabName, f, foreBrush, r, sf);

            sf.Dispose();
            if (e.Index == this.CampTabs.SelectedIndex)
            {
                f.Dispose();
                backBrush.Dispose();
            }
            else
            {
                backBrush.Dispose();
                foreBrush.Dispose();
            }
        }

    }
}
