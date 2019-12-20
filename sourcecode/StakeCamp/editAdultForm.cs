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
    public partial class editAdultForm : Form
    {
        public editAdultForm()
        {
            InitializeComponent();
            NestComboBox();
            TransComboBox();
            wardComboBox(); //*****VEA
            this.CampTabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.CampTabs.DrawItem += new DrawItemEventHandler(this.tabControl1_DrawItem);
        }
        public int tempNestID;
        public int tempTransID;

        //*******************CLEAR BUTTON ON ADULT TAB***********************************
        private void clearAdultForm(object sender, EventArgs e)
        {
            //adult tab
            label1.ForeColor = Color.Black;
            label1.BackColor = Color.White;

            label2.ForeColor = Color.Black;
            label2.BackColor = Color.White;

            label7.ForeColor = Color.Black;
            label7.BackColor = Color.White;

            label8.ForeColor = Color.Black;
            label8.BackColor = Color.White;

            label9.ForeColor = Color.Black;
            label9.BackColor = Color.White;

            DOBlabel.ForeColor = Color.Black;
            DOBlabel.BackColor = Color.White;

            label6.ForeColor = Color.Black;
            label6.BackColor = Color.White;

            cbWard.SelectedIndex = -1;
            tbAssignments.Clear();
            tbFName.Clear();
            tbLName.Clear();
            tbMonth.Clear();
            tbDate.Clear();
            tbYear.Clear();
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
        }
        //*******************************************************************************

        //*******************NEXT BUTTON ON ADULT TAB************************************
        private void goEnrollment(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpEnrollment;
        }
        //*******************************************************************************

        //*******************CLEAR BUTTON ON ENROLLMENT TAB******************************
        private void clearEnrollment(object sender, EventArgs e)
        {
            ckbxRecReg.Checked = false;
            ckbxMedForm.Checked = false;
            ckbxRecConsent.Checked = false;
            ckbxRecMoney.Checked = false;
            rtbAddComments.Clear();
        }
        //*******************************************************************************

        //*******************PREVIOUS BUTTON ON ENROLLMENT TAB***************************
        private void prevAdult(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpAdult;
        }
        //*******************************************************************************

        //*******************NEXT BUTTON ON ENROLLMENT TAB*******************************
        private void goMedical(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpMedical;
        }
        //*******************************************************************************

        //*******************CLEAR FORM BUTTON ON MEDICAL TAB****************************
        private void clearMedicalForm(object sender, EventArgs e)
        {
            rbAsthmaY.Checked = false;
            rbAsthmaN.Checked = false;
            rbMedsY.Checked = false;
            rbMedsN.Checked = false;
            rbAllergyY.Checked = false;
            rbAllergyN.Checked = false;
            LimitRBTBox.Clear();
        }
        //*******************************************************************************

        //*******************PREVIOUS BUTTON ON MEDICAL TAB******************************
        private void prevEnrollment(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpEnrollment;
        }
        //*******************************************************************************

        //*******************NEXT BUTTON ON MEDICAL TAB**********************************
        private void goEmerCont(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpEmerCont;
        }
        //*******************************************************************************

        //*******************CLEAR BUTTON ON EMERGENCY CONTACT TAB***********************
        private void clearEmerContForm(object sender, EventArgs e)
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
        //*******************************************************************************

        //*******************PREVIOUS BUTTON ON EMERGENCY TAB****************************
        private void prevMedical(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpMedical;
        }
        //*******************************************************************************

        //*******************NEXT BUTTON ON MISC TAB*************************************
        private void goMisc(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpMisc;
        }
        //*******************************************************************************

        //*******************CLEAR BUTTON ON MISC TAB************************************
        private void clearMiscForm(object sender, EventArgs e)
        {

            tbAdultNest.SelectedIndex = -1;
            tbAdultTrans.SelectedIndex = -1;

        }
        Adults dataAccessAdult = new Adults();

        private void editAdultForm_Load(object sender, EventArgs e)
        {
            //TODO: This line of code loads data into the 'girlsCampDataSet.nests' table. You can move, or remove it, as needed.
            DbCommand comm = GenericDataAccess.CreateCommand();

            comm.CommandText = "Select Adult_ID, First_Name, Last_Name " +
                "FROM adults INNER JOIN adult_assingments_link ON adults.Adult_ID = adult_assingments_link.AdultID " +
                "where AssingYear = ?" +
                "order by First_Name, Last_Name asc ";

            DbParameter param2 = comm.CreateParameter();//last year
            param2.ParameterName = "@Currentyear";
            param2.DbType = DbType.String;
            param2.Value = dataAccessAdult.Currentyear;
            comm.Parameters.Add(param2);


            //set the BindingSource DataSource
            dataAccessAdult.bSource.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

            //set the DataGridView DataSource
            dg.DataSource = dataAccessAdult.bSource;


            // dg.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);

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

        private void UpdAdultBtn_Click(object sender, EventArgs e)
        {           
            bool valid1 = validateAdulttab();
            if (valid1 == true)
            {

            }
            else
            {                
                dataAccessAdult.AssignmentDescription = tbAssignments.Text;
                dataAccessAdult.WardID = cbWard.Text;
                dataAccessAdult.FirstName = tbFName.Text;
                dataAccessAdult.LastName = tbLName.Text;
                dataAccessAdult.Address = tbAddy.Text;
                dataAccessAdult.City = tbCity.Text;
                dataAccessAdult.State = tbState.Text;
                dataAccessAdult.ZipCode = tbPostCode.Text;
                if (tbHomePhArea.Text == string.Empty || tbHomePh3.Text == string.Empty || tbHomePh4.Text == string.Empty)
                {
                    dataAccessAdult.HomePhone = "";
                }
                else
                {
                    //homephone
                    dataAccessAdult.HomePhone = "(" + tbHomePhArea.Text + ") " + tbHomePh3.Text + "-" + tbHomePh4.Text;
                }
                if (tbCellPhArea.Text == string.Empty || tbCellPh3.Text == string.Empty || tbCellPh4.Text == string.Empty)
                {
                    dataAccessAdult.CellPhone = "";
                }
                else
                {
                    //cellphone
                    dataAccessAdult.CellPhone = "(" + tbCellPhArea.Text + ") " + tbCellPh3.Text + "-" + tbCellPh4.Text;
                }
                if (tbMonth.Text == string.Empty || tbDate.Text == string.Empty || tbYear.Text == string.Empty)
                {
                    dataAccessAdult.BirthDate = "";
                }
                else
                {
                    dataAccessAdult.BirthDate = tbMonth.Text + "/" + tbDate.Text + "/" + tbYear.Text;
                }
                dataAccessAdult.Email = tbEmail.Text;
                dataAccessAdult.updateAdult();//updates the adult table
                DbCommand cmd = GenericDataAccess.CreateCommand();
                cmd.CommandText = "Select Adult_ID, First_Name, Last_Name " +
                    "FROM adults INNER JOIN adult_assingments_link ON adults.Adult_ID = adult_assingments_link.AdultID " +
                    "where AssingYear = ?" +
                    "order by First_Name, Last_Name asc ";

                DbParameter param2 = cmd.CreateParameter();//last year
                param2.ParameterName = "@Currentyear";
                param2.DbType = DbType.String;
                param2.Value = dataAccessAdult.Currentyear;
                cmd.Parameters.Add(param2);

                dg.DataSource = GenericDataAccess.ExecuteSelectCommand(cmd);
                dg.Update();

                if (dataAccessAdult.didNotwork == false)
                {
                    MessageBox.Show("Record updated succesfully");
                }
                else
                {
                    MessageBox.Show("It appears there was an error when updating this record");
                }
            }
        }

        private void UpdEnrollBtn_Click(object sender, EventArgs e)
        {           
            if (ckbxRecReg.Checked == true)
            {
                dataAccessAdult.RecievedRegistration = "Yes";

            }
            else
            {
                dataAccessAdult.RecievedRegistration = "No";
            }
            if (ckbxMedForm.Checked == true)
            {
                dataAccessAdult.RecievedMedicalForm = "Yes";
            }
            else
            {
                dataAccessAdult.RecievedMedicalForm = "No";
            }
            if (ckbxRecConsent.Checked == true)
            {
                dataAccessAdult.RecievedEmergencyConcent = "Yes";
            }
            else
            {
                dataAccessAdult.RecievedEmergencyConcent = "No";
            }
            if (ckbxRecMoney.Checked == true)
            {
                dataAccessAdult.RecievedPayment = "Yes";
            }
            else
            {
                dataAccessAdult.RecievedPayment = "No";

            }
            dataAccessAdult.EnrollComments = rtbAddComments.Text;
            dataAccessAdult.updateRegistration();

            if (dataAccessAdult.didNotwork == false)
            {
                MessageBox.Show("Record updated succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when updating this record");
            }
        }

        private void updMedBtn_Click(object sender, EventArgs e)
        {           
            if (rbAsthmaY.Checked == true)
            {
                dataAccessAdult.AsthmaYN = "Yes";
            }
            else
            {
                dataAccessAdult.AsthmaYN = "No";
            }
            if (rbMedsY.Checked == true)
            {
                dataAccessAdult.MedsYN = "Yes";
            }
            else
            {
                dataAccessAdult.MedsYN = "No";
            }
            if (rbAllergyY.Checked == true)
            {
                dataAccessAdult.AllergyYN = "Yes";

            }
            else
            {
                dataAccessAdult.AllergyYN = "No";
            }
            dataAccessAdult.updateMedicalInfo();
            LimitRBTBox.Text.Trim();
            dataAccessAdult.LimitDescription = LimitRBTBox.Text.Split(',');
            for (int i = 0; i < dataAccessAdult.LimitationsArray.Length; i++)
            {
                dataAccessAdult.LimitationsID = dataAccessAdult.LimitationsArray[i];
                dataAccessAdult.updateLimitationsInfo();
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
            }

            if (dataAccessAdult.didNotwork == false)
            {
                MessageBox.Show("Record updated succesfully");
            }
            else
            {
                MessageBox.Show("It appears there was an error when updating this record");
            }
        }

        private void UpdEcontactBtn_Click(object sender, EventArgs e)
        {            
            bool valid2 = validateAdultEmg();
            if (valid2 == true)
            {

            }
            else
            {
                dataAccessAdult.EmgFirstName = tbECFName.Text;
                dataAccessAdult.EmgLastName = tbECLName.Text;
                if (tbECPhoneArea.Text == string.Empty || tbECPhone3.Text == string.Empty || tbECPhone4.Text == string.Empty)
                {
                    dataAccessAdult.EmgPhone = "";
                }
                else
                {
                    //emg phone
                    dataAccessAdult.EmgPhone = "(" + tbECPhoneArea.Text + ") " + tbECPhone3.Text + "-" + tbECPhone4.Text;
                }
                dataAccessAdult.EmgRelationship = tbRelat.Text;
                dataAccessAdult.updateEmergencyContactInfo();

                if (dataAccessAdult.didNotwork == false)
                {
                    MessageBox.Show("Record updated succesfully");
                }
                else
                {
                    MessageBox.Show("It appears there was an error when updating this record");
                }
            }
        }

        private void UpdMiscBtn_Click(object sender, EventArgs e)
        {
            string updateYN = "";           
            string testTemp1 = tbAdultNest.Text.ToString();
            if (testTemp1 == string.Empty || tempNestID == 0)
            {
                MessageBox.Show("Please add Nest first ");
            }
            else
            {
                string temp1 = tbAdultNest.SelectedValue.ToString();
                int myParsedInt1 = Int32.Parse(temp1);
                dataAccessAdult.NestID = Convert.ToInt32(temp1);
                dataAccessAdult.updatAdultNestLink();
                updateYN = "Nest ";
            }
            string testTemp2 = tbAdultTrans.Text.ToString();
            if (testTemp2 == string.Empty || tempTransID == 0)
            {
                MessageBox.Show("Please add transportation first ");
            }
            else
            {
                string temp2 = tbAdultTrans.SelectedValue.ToString();
                int myParsedInt2 = Int32.Parse(temp2);
                dataAccessAdult.TransportID = Convert.ToInt32(temp2);
                dataAccessAdult.updateAdultTransLink();
                updateYN = "Transportation ";
            }

            if (dataAccessAdult.didNotwork == false)
            {
                MessageBox.Show("Record updated succesfully");
            }         
            else
            {
                MessageBox.Show("It appears there was an error when updating this record");
            }

        }

        private void tpMisc_Click(object sender, EventArgs e)
        {

        }
        public void NestComboBox()
        {
            //nest            
            DbCommand comm = GenericDataAccess.CreateCommand();
           
            comm.CommandText = "Select Nest_id, Nest_name from nests where NestYear=?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CurrentYear";
            param.DbType = DbType.Int32;
            param.Value = dataAccessAdult.Currentyear;
            comm.Parameters.Add(param);

            tbAdultNest.DataSource = GenericDataAccess.ExecuteSelectCommand(comm);
            tbAdultNest.DisplayMember = "Nest_name";
            tbAdultNest.ValueMember = "Nest_id";
            tbAdultNest.SelectedIndex = -1;

        }
        public void TransComboBox()
        {
            //transportation
            DbCommand comm2 = GenericDataAccess.CreateCommand();//t.Transportation_id, t.Transportation
            comm2.CommandText = "Select Transportation_id, Transportation from transportation";

            tbAdultTrans.DataSource = GenericDataAccess.ExecuteSelectCommand(comm2);
            tbAdultTrans.DisplayMember = "Transportation";
            tbAdultTrans.ValueMember = "Transportation_id";
            tbAdultTrans.SelectedIndex = -1;



        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (dg.Rows[e.RowIndex].Cells["Edit"].Selected)
            {
                ClearAll();
                string id = dg.Rows[e.RowIndex].Cells["Adult_ID"].Value.ToString();


                MessageBox.Show("You clicked on edit");
                dataAccessAdult.GetAdult(id);//calls function in order to retrieve data from Adults table                
                //********Adult tab************
                tbFName.Text = dataAccessAdult.FirstName;
                tbLName.Text = dataAccessAdult.LastName;
                tbAddy.Text = dataAccessAdult.Address;
                tbCity.Text = dataAccessAdult.City;
                tbState.Text = dataAccessAdult.State;
                tbPostCode.Text = dataAccessAdult.ZipCode;
                if (dataAccessAdult.HomePhone == string.Empty)
                {
                    //homephone
                    tbHomePhArea.Text = "";
                    tbHomePh3.Text = "";
                    tbHomePh4.Text = "";
                }
                else
                {
                    string[] hPhone = dataAccessAdult.HomePhone.Split('(', ')', ' ', '-');
                    //homephone
                    tbHomePhArea.Text = hPhone[1];
                    tbHomePh3.Text = hPhone[3];
                    tbHomePh4.Text = hPhone[4];
                }
                if (dataAccessAdult.CellPhone == string.Empty)
                {
                    //cellphone
                    tbCellPhArea.Text = "";
                    tbCellPh3.Text = "";
                    tbCellPh4.Text = "";
                }
                else
                {
                    string[] cPhone = dataAccessAdult.CellPhone.Split('(', ')', ' ', '-');
                    //cellphone
                    tbCellPhArea.Text = cPhone[1];
                    tbCellPh3.Text = cPhone[3];
                    tbCellPh4.Text = cPhone[4];
                }
                tbEmail.Text = dataAccessAdult.Email;
                if (dataAccessAdult.BirthDate == string.Empty)
                {
                    tbMonth.Text = "";
                    tbDate.Text = "";
                    tbYear.Text = "";
                }
                else
                {
                    string[] bDay = dataAccessAdult.BirthDate.Split('/', ' ');
                    tbMonth.Text = bDay[0];
                    tbDate.Text = bDay[1];
                    tbYear.Text = bDay[2];
                }

                tbAssignments.Text = dataAccessAdult.AssignmentDescription;
               
                cbWard.Text = dataAccessAdult.WardID;

                // *********Enrollment Tab***********              
                if (dataAccessAdult.RecievedRegistration == "Yes")
                {
                    ckbxRecReg.Checked = true;
                }
                else
                {
                    ckbxRecReg.Checked = false;
                }
                if (dataAccessAdult.RecievedMedicalForm == "Yes")
                {
                    ckbxMedForm.Checked = true;
                }
                else
                {
                    ckbxMedForm.Checked = false;
                }
                if (dataAccessAdult.RecievedEmergencyConcent == "Yes")
                {
                    ckbxRecConsent.Checked = true;
                }
                else
                {
                    ckbxRecConsent.Checked = false;
                }
                if (dataAccessAdult.RecievedPayment == "Yes")
                {
                    ckbxRecMoney.Checked = true;
                }
                else
                {
                    ckbxRecMoney.Checked = false;
                }

                LimitRBTBox.Text = dataAccessAdult.EnrollComments;




                //******Medical Tab**********                 
                if (dataAccessAdult.AsthmaYN == "Yes")
                {
                    rbAsthmaY.Checked = true;
                }
                else
                {
                    rbAsthmaN.Checked = true;
                }
                if (dataAccessAdult.MedsYN == "Yes")
                {

                    rbMedsY.Checked = true;

                }
                else
                {
                    rbMedsN.Checked = true;

                }
                if (dataAccessAdult.AllergyYN == "Yes")
                {
                    rbAllergyY.Checked = true;

                }
                else
                {
                    rbAllergyN.Checked = true;
                }
                string limitationString = "";
                for (int i = 0; i < dataAccessAdult.LimitDescription.Length; i++)//it is used to put all data in array in a string
                {
                    if (i == dataAccessAdult.LimitDescription.Length - 1)
                    {
                        limitationString += dataAccessAdult.LimitDescription[i];

                    }
                    else
                    {
                        limitationString += dataAccessAdult.LimitDescription[i] + ", ";
                    }


                }
                LimitRBTBox.Text = limitationString;

                //********Emergency Contact Tab
                tbECFName.Text = dataAccessAdult.EmgFirstName;
                tbECLName.Text = dataAccessAdult.EmgLastName;
                if (dataAccessAdult.EmgPhone == string.Empty)
                {
                    //emg phone
                    tbECPhoneArea.Text = "";
                    tbECPhone3.Text = "";
                    tbECPhone4.Text = "";
                }
                else
                {
                    string[] emphone = dataAccessAdult.EmgPhone.Split('(', ')', ' ', '-'); ;
                    //emg phone
                    tbECPhoneArea.Text = emphone[1];
                    tbECPhone3.Text = emphone[3];
                    tbECPhone4.Text = emphone[4];
                }
                tbRelat.Text = dataAccessAdult.EmgRelationship;

                //********misc tab*********                
                tbAdultNest.Text = dataAccessAdult.NestName;
                tempNestID = dataAccessAdult.NestID;
                tbAdultTrans.Text = dataAccessAdult.TransportationType;
                tempTransID = dataAccessAdult.TransportID;


            }
            else if (dg.Rows[e.RowIndex].Cells["Delete"].Selected)
            {

                dataAccessAdult.didNotwork = false;
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
                        string id = dg.Rows[e.RowIndex].Cells["Adult_ID"].Value.ToString();
                        MessageBox.Show("You clicked on delete");
                        int myParsedInt = Int32.Parse(id);
                        dataAccessAdult.AdultID = Convert.ToInt32(id);
                        dataAccessAdult.GetAdult(id);
                        dataAccessAdult.GetEnrollIDArray();//new 05/23
                        dataAccessAdult.GetAssingArray();//new 05/23

                        dataAccessAdult.deleteAssingAdultLink();
                        //new 05/23
                        for (int i = 0; i < dataAccessAdult.AssignArray.Length; i++)//left off
                        {
                            dataAccessAdult.AssignID = dataAccessAdult.AssignArray[i];
                            dataAccessAdult.deleteAssignmentInfo();
                        }
                        //end 05/23                           
                        dataAccessAdult.deleteEnrollAdultLink();

                        //new 05/23
                        for (int i = 0; i < dataAccessAdult.EnrollArray.Length; i++)
                        {
                            dataAccessAdult.EnrollID = dataAccessAdult.EnrollArray[i];
                            dataAccessAdult.deleteRegistration();
                        }//end new 05/23

                        dataAccessAdult.deleteLimitationsInfo();
                        dataAccessAdult.deleteMedicalInfo();

                        if (dataAccessAdult.TransportID == 0 || dataAccessAdult.TransportationType == string.Empty)
                        {

                        }
                        else
                        {
                            dataAccessAdult.deleteAdultTransLink();
                        }

                        if (dataAccessAdult.NestID == 0 || dataAccessAdult.NestName == string.Empty)
                        {

                        }
                        else
                        {
                            dataAccessAdult.deleteAdultNestLink();
                        }
                        //end 05/23
                        dataAccessAdult.deleteAdult();
                        dataAccessAdult.deleteEmergencyContactInfo();

                        dataAccessAdult.bSource.RemoveCurrent();//deletes current cell
                        Validate();
                        dataAccessAdult.bSource.EndEdit();//saves changes
                        ClearAll();

                        if (dataAccessAdult.didNotwork == false)
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
        public void ClearAll()
        {
            //adult tab
            label1.ForeColor = Color.Black;
            label1.BackColor = Color.White;

            label2.ForeColor = Color.Black;
            label2.BackColor = Color.White;

            label7.ForeColor = Color.Black;
            label7.BackColor = Color.White;

            label8.ForeColor = Color.Black;
            label8.BackColor = Color.White;

            label9.ForeColor = Color.Black;
            label9.BackColor = Color.White;

            DOBlabel.ForeColor = Color.Black;
            DOBlabel.BackColor = Color.White;

            label6.ForeColor = Color.Black;
            label6.BackColor = Color.White;

            //emg contact tab
            lblPhNum.ForeColor = Color.Black;
            lblPhNum.BackColor = Color.White;

            tbAssignments.Clear();
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

            rbAsthmaY.Checked = false;
            rbAsthmaN.Checked = false;
            rbMedsY.Checked = false;
            rbMedsN.Checked = false;
            rbAllergyY.Checked = false;
            rbAllergyN.Checked = false;
            LimitRBTBox.Clear();
            tbECFName.Clear();
            tbECLName.Clear();

            //emg phone
            tbECPhoneArea.Clear();
            tbECPhone3.Clear();
            tbECPhone4.Clear();

            tbRelat.Clear();

            tbAdultNest.SelectedIndex = -1;
            tbAdultTrans.SelectedIndex = -1;

        }

        private void PreviousEmgC(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpEmerCont;
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

        private void linkAMain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //back to main menu
            mainMenu mMenu = new mainMenu();
            this.Hide();
            mMenu.Show();
            mMenu.Top = this.Top;
            mMenu.Left = this.Left;
        }

        //VVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        public void wardComboBox()
        {
            DbCommand comm2 = GenericDataAccess.CreateCommand();//t.Transportation_id, t.Transportation
            comm2.CommandText = "Select ward from wards";

            cbWard.DataSource = GenericDataAccess.ExecuteSelectCommand(comm2);
            cbWard.DisplayMember = "Ward";          
            cbWard.SelectedIndex = -1;
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
        public bool validateAdulttab()//new 05/26
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
                    label9.ForeColor = Color.White;
                    label9.BackColor = Color.Red;
                }
                else
                {
                    if (Valid == true)
                    {
                    }

                    else
                    {
                        MessageBox.Show("Please make sure that email is in proper format");
                        label9.ForeColor = Color.White;
                        label9.BackColor = Color.Red;
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
                    DOBlabel.ForeColor = Color.White;
                    DOBlabel.BackColor = Color.Red;
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
                        DOBlabel.ForeColor = Color.White;
                        DOBlabel.BackColor = Color.Red;
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
        }//end new 05/26
        public bool validateAdultEmg()
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
