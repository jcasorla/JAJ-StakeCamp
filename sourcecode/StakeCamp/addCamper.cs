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
    public partial class camperForm : Form
    {
        Girls girlCamper = new Girls();
        Adults adultHelper = new Adults();//added 0429
        public camperForm()
        {
            InitializeComponent();
            wardComboBox(); //*****VEA
            levelComboBox(); //*****VEA
            this.CampTabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.CampTabs.DrawItem += new DrawItemEventHandler(this.tabControl1_DrawItem);


        }

        //*******************CLEAR BUTTON ON CAMPER TAB**********************************
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

            label25.ForeColor = Color.Black;
            label25.BackColor = Color.White;

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
            //home phone
            tbHomePhArea.Clear();
            tbHomePh3.Clear();
            tbHomePh4.Clear();
            //cell phone
            tbCellAreaCode.Clear();
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

        }
        //*******************************************************************************

        //*******************CLEAR BUTTON ON GUARDIAN FORM*******************************
        private void guardClearForm(object sender, EventArgs e)
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

            sameAsCamperChkBox.Checked = false;
            tbGFName.Clear();
            tbGLName.Clear();
            tbGAddy.Clear();
            tbGCity.Clear();
            tbGState.Clear();
            tbGPostCode.Clear();
            //guardian1 homephone
            tbGHomeAreaCode.Clear();
            tbGHome3.Clear();
            tbGHome4.Clear();
            //guardian1 cellphone
            tbGCellAreaCode.Clear();
            tbGCell3.Clear();
            tbGCell4.Clear();
            tbGEmail.Clear();

            sameAsCamper2ChkBox.Checked = false;
            tbGFName2.Clear();
            tbGLName2.Clear();
            tbGAddy2.Clear();
            tbGCity2.Clear();
            tbGState2.Clear();
            tbGPostCode2.Clear();
            //guardian2 homephone
            tbGHome2AreaCode.Clear();
            tbGHome32.Clear();
            tbGHome42.Clear();
            //guardian2 cellphone
            tbGCell2AreaCode.Clear();
            tbGCell32.Clear();
            tbGCell42.Clear();
            tbGEmail2.Clear();
        }
        //*******************************************************************************

        //*******************CLEAR BUTTON ON MEDICAL TAB*********************************
        private void medClearForm(object sender, EventArgs e)
        {
            //cbAsthmatic.SelectedIndex = -1;
            LimitRBTBox.Clear(); ;
            AsthmaRB1.Checked = false;
            AsthmaRB2.Checked = false;
            MedsRB1.Checked = false;
            MedsRB2.Checked = false;
            AllergiesRB1.Checked = false;
            AllergiesRB2.Checked = false;

        }
        //*******************************************************************************

        //*******************CLEAR BUTTON ON EMERGENCY CONTACT***************************
        private void emergClearForm(object sender, EventArgs e)
        {
            //emg contact tab
            lblPhNum.ForeColor = Color.Black;
            lblPhNum.BackColor = Color.White;

            tbECFName.Clear();
            tbECLName.Clear();
            //emg phone
            tbECPhoneAreaCode.Clear();
            tbECPhone3.Clear();
            tbECPhone4.Clear();
            tbRelat.Clear();
        }
        //*******************************************************************************

        //*******************LINK TO MAIN MENU FROM CAMPER TAB***************************
        private void linkCMainMenu(object sender, EventArgs e)
        {
            mainMenu mainM = new mainMenu();
            this.Hide();
            mainM.Show();
            mainM.Top = this.Top;
            mainM.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //**************************LINK TO MAIN MENU FROM GUARDIAN TAB******************
        private void linkGMainMenu(object sender, EventArgs e)
        {
            mainMenu mainM = new mainMenu();
            this.Hide();
            mainM.Show();
            mainM.Top = this.Top;
            mainM.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************LINK TO MAIN MENU FROM MEDICAL TAB**************************
        private void linkMMainMenu(object sender, EventArgs e)
        {
            mainMenu mainM = new mainMenu();
            this.Hide();
            mainM.Show();
            mainM.Top = this.Top;
            mainM.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************LINK TO MAIN MENU FROM EMERGENCY CONTACT TAB****************
        private void linkECMainMenu(object sender, EventArgs e)
        {
            mainMenu mainM = new mainMenu();
            this.Hide();
            mainM.Show();
            mainM.Top = this.Top;
            mainM.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************NEXT BUTTON ON CAMPER FORM**********************************
        public void nextGuardian(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpGuardian;


        }
        //*******************************************************************************

        //new 05/22
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
        }//end new 05/22

        //*******************PREVIOUS & NEXT BUTTONS ON GUARDIAN TAB*********************
        private void prevCamper(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpCamper;
        }

        private void nextMedical(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpMedical;
        }
        //*******************************************************************************

        //*******************NEXT & PREVIOUS BUTTONS ON MEDICAL TAB**********************
        private void nextEmerCont(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpEmerCont;
        }

        private void prevGuardian(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpGuardian;
        }
        //*******************************************************************************

        //*******************PREVIOUS BUTTON ON EMERGENCY CONTACT************************
        private void prevMedical(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpMedical;
        }
        //*******************************************************************************

        //*******************SUBMIT BUTTON***********************************************
        private void btnSubmit_Click(object sender, EventArgs e)
        {           
            bool valid1 = validateCamperTab();
            bool valid2 = validateGuardianTab();
            bool valid3 = validateEmg();
            if (valid1 == true || valid2 == true || valid3 == true)
            {

            }
            else
            {
                //*****Camper Tab********

                if (cbAttenAs.Text == string.Empty)
                {
                    girlCamper.Level = "None";
                }
                else
                {
                    girlCamper.Level = cbAttenAs.Text;
                }
                if (cbWard.Text == string.Empty)
                {
                    girlCamper.WardID = "None";
                }
                else
                {
                    girlCamper.WardID = cbWard.Text;
                }
                girlCamper.FirstName = tbFName.Text;
                girlCamper.LastName = tbLName.Text;
                girlCamper.Address = tbAddy.Text;
                girlCamper.City = tbCity.Text;
                girlCamper.State = tbState.Text;
                girlCamper.ZipCode = tbPostCode.Text;
                //home phone
                if (tbHomePhArea.Text == string.Empty || tbHomePh3.Text == string.Empty || tbHomePh4.Text == string.Empty)
                {
                    girlCamper.HomePhone = "";
                }
                else
                {
                    girlCamper.HomePhone = "(" + tbHomePhArea.Text + ") " + tbHomePh3.Text + "-" + tbHomePh4.Text;//new 0524                      
                }
                if (tbCellAreaCode.Text == string.Empty || tbCellPh3.Text == string.Empty || tbCellPh4.Text == string.Empty)
                {
                    girlCamper.CellPhone = "";
                }
                else
                {
                    //cell phone
                    girlCamper.CellPhone = "(" + tbCellAreaCode.Text + ") " + tbCellPh3.Text + "-" + tbCellPh4.Text;
                }
                girlCamper.Email = tbEmail.Text;
                if (tbMonth.Text == string.Empty || tbMonth.Text == string.Empty || tbYear.Text == string.Empty)
                {
                    girlCamper.BirthDate = "";
                }
                else
                {
                    girlCamper.BirthDate = tbMonth.Text + "/" + tbDate.Text + "/" + tbYear.Text;
                }

                if (ckbxRecReg.Checked)   //*********figure out how to get value from checkbox
                {
                    girlCamper.RecievedRegistration = "Yes";
                }
                else
                {
                    girlCamper.RecievedRegistration = "No";

                }
                if (ckbxRecConsent.Checked)
                {
                    girlCamper.RecievedEmergencyConcent = "Yes";
                }
                else
                {
                    girlCamper.RecievedEmergencyConcent = "No";
                }
                if (ckbxMedForm.Checked)
                {
                    girlCamper.RecievedMedicalForm = "Yes";
                }
                else
                {
                    girlCamper.RecievedMedicalForm = "No";
                }

                if (ckbxRecMoney.Checked)
                {
                    girlCamper.RecievedPayment = "Yes";
                }
                else
                {
                    girlCamper.RecievedPayment = "No";
                }

                girlCamper.EnrollComments = rtbAddComments.Text;

                //guardian in its own function


                //**********Medical Tab********* 
                if (AsthmaRB1.Checked)
                {
                    girlCamper.AsthmaYN = "Yes";
                }
                else if (AsthmaRB2.Checked)
                {
                    girlCamper.AsthmaYN = "No";
                }
                else
                {
                    girlCamper.AsthmaYN = "No";
                }
                if (MedsRB1.Checked)
                {
                    girlCamper.MedsYN = "Yes";

                }
                else if (MedsRB2.Checked)
                {
                    girlCamper.MedsYN = "No";
                }
                else
                {
                    girlCamper.MedsYN = "No";
                }
                if (AllergiesRB1.Checked)
                {
                    girlCamper.AllergyYN = "Yes";
                }
                else if (AllergiesRB2.Checked)
                {
                    girlCamper.AllergyYN = "No";
                }
                else
                {
                    girlCamper.AllergyYN = "No";
                }
                LimitRBTBox.Text.Trim();
                girlCamper.LimitDescription = LimitRBTBox.Text.Split(',');//jose          

                //**********Emergency Contact Tab****************
                girlCamper.EmgFirstName = tbECFName.Text;
                girlCamper.EmgLastName = tbECLName.Text;
                //emg phone
                if (tbECPhoneAreaCode.Text == string.Empty || tbECPhone3.Text == string.Empty || tbECPhone4.Text == string.Empty)
                {
                    girlCamper.EmgPhone = "";
                }
                else
                {
                    girlCamper.EmgPhone = "(" + tbECPhoneAreaCode.Text + ") " + tbECPhone3.Text + "-" + tbECPhone4.Text;
                }
                girlCamper.EmgRelationship = tbRelat.Text;

                if (girlCamper.duplicateGirlValidation() == true)
                {
                    int tempID = girlCamper.GirlID;
                    DuplicateGirl validateG = new DuplicateGirl();

                    validateG.ID = tempID;
                    validateG.ValidateGirl = girlCamper;

                    validateG.Guard1FName = tbGFName.Text;
                    validateG.Guard1LName = tbGLName.Text;
                    validateG.Guard1Address = tbGAddy.Text;
                    validateG.Guard1City = tbGCity.Text;
                    validateG.Guard1State = tbGState.Text;
                    validateG.Guard1ZipCode = tbGPostCode.Text;
                    if (tbGHomeAreaCode.Text == string.Empty || tbGHome3.Text == string.Empty || tbGHome4.Text == string.Empty)
                    {
                        validateG.Guard1HPhone = "";
                    }
                    else
                    {
                        //guardian1 homephone
                        validateG.Guard1HPhone = "(" + tbGHomeAreaCode.Text + ") " + tbGHome3.Text + "-" + tbGHome4.Text;
                    }
                    if (tbGCellAreaCode.Text == string.Empty || tbGCell3.Text == string.Empty || tbGCell4.Text == string.Empty)
                    {
                        validateG.Guard1CPhone = "";
                    }
                    else
                    {
                        //guardian1 cellphone
                        validateG.Guard1CPhone = "(" + tbGCellAreaCode.Text + ") " + tbGCell3.Text + "-" + tbGCell4.Text;
                    }
                    validateG.Guard1Email = tbGEmail.Text;

                    //Guardian 2
                    validateG.Guard2FName = tbGFName2.Text;
                    validateG.Guard2LName = tbGLName2.Text;
                    validateG.Guard2Address = tbGAddy2.Text;
                    validateG.Guard2City = tbGCity2.Text;
                    validateG.Guard2State = tbGState2.Text;
                    validateG.Guard2ZipCode = tbGPostCode2.Text;
                    if (tbGHome2AreaCode.Text == string.Empty || tbGHome32.Text == string.Empty || tbGHome42.Text == string.Empty)
                    {
                        validateG.Guard2HPhone = "";
                    }
                    else
                    {
                        //guardian2 homephone
                        validateG.Guard2HPhone = "(" + tbGHome2AreaCode.Text + ") " + tbGHome32.Text + "-" + tbGHome42.Text;
                    }
                    //guardian2 cellphone
                    if (tbGCell2AreaCode.Text == string.Empty || tbGCell32.Text == string.Empty || tbGCell42.Text == string.Empty)
                    {
                        validateG.Guard2CPhone = "";
                    }
                    else
                    {
                        validateG.Guard2CPhone = "(" + tbGCell2AreaCode.Text + ") " + tbGCell32.Text + "-" + tbGCell42.Text;
                    }
                    validateG.Guard2Email = tbGEmail2.Text;

                    this.Hide();
                    validateG.Show();
                    validateG.Top = this.Top;
                    validateG.Left = this.Left;
                    this.Close();

                }
                else
                {
                    //**********Function Calls ***********
                    girlCamper.AddEmergencyContactInfo();//calls function in order to insert emergency contact info
                    girlCamper.AddCamper();//***calls function AddCamper***
                    girlCamper.Registration();//***calls function in order to add registration info***
                    callGuardian(); //**calls local function in order to call AddGuardianInfo() 2 times            
                    girlCamper.AddMedicalInfo();//***calls AddMedicalInfo function***
                                        
                    if(girlCamper.didNotwork == false)
                    {
                        MessageBox.Show("Record added succesfully");
                    }
                    else
                    {
                        MessageBox.Show("It appears there was an error when adding this record");
                    }
                    //****************************************************
                }
            }
        }

        //*******************************************************************************

        //*******************BACK TO ADD LINK ON CAMPER TAB******************************       
        public void callGuardian()
        {
            //*********Guardian Tab********
            //Guardian 1
            girlCamper.GuardFName = tbGFName.Text;
            girlCamper.GuardLName = tbGLName.Text;
            girlCamper.GuardAddress = tbGAddy.Text;
            girlCamper.GuardCity = tbGCity.Text;
            girlCamper.GuardState = tbGState.Text;
            girlCamper.GuardZipCode = tbGPostCode.Text;
            if (tbGHomeAreaCode.Text == string.Empty || tbGHome3.Text == string.Empty || tbGHome4.Text == string.Empty)
            {
                girlCamper.GuardHPhone = "";
            }
            else
            {
                //guardian1 homephone
                girlCamper.GuardHPhone = "(" + tbGHomeAreaCode.Text + ") " + tbGHome3.Text + "-" + tbGHome4.Text;
            }
            if (tbCellAreaCode.Text == string.Empty || tbGCell3.Text == string.Empty || tbGCell4.Text == string.Empty)
            {
                girlCamper.GuardCPhone = "";
            }
            else
            {
                //guardian1 cellphone
                girlCamper.GuardCPhone = "(" + tbGCellAreaCode.Text + ") " + tbGCell3.Text + "-" + tbGCell4.Text;
            }
            girlCamper.GuardEmail = tbGEmail.Text;
            girlCamper.AddGuardianInfo();//***calls AddGuardianInfo in order to insert data***



            //Guardian 2
            girlCamper.GuardFName = tbGFName2.Text;
            girlCamper.GuardLName = tbGLName2.Text;
            girlCamper.GuardAddress = tbGAddy2.Text;
            girlCamper.GuardCity = tbGCity2.Text;
            girlCamper.GuardState = tbGState2.Text;
            girlCamper.GuardZipCode = tbGPostCode2.Text;
            if (tbGHome2AreaCode.Text == string.Empty || tbGHome32.Text == string.Empty || tbGHome42.Text == string.Empty)
            {
                girlCamper.GuardHPhone = "";
            }
            else
            {
                //guardian2 homephone
                girlCamper.GuardHPhone = "(" + tbGHome2AreaCode.Text + ") " + tbGHome32.Text + "-" + tbGHome42.Text;
            }
            if (tbGCell2AreaCode.Text == string.Empty || tbGCell32.Text == string.Empty || tbGCell42.Text == string.Empty)
            {
                girlCamper.GuardCPhone = "";
            }
            else
            {
                //guardian2 cellphone
                girlCamper.GuardCPhone = "(" + tbGCell2AreaCode.Text + ") " + tbGCell32.Text + "-" + tbGCell42.Text;
            }
            girlCamper.GuardEmail = tbGEmail2.Text;
            girlCamper.AddGuardianInfo();//***calls AddGuardianInfo in order to insert data***


        }
        private void linkCBackToAdd(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addDecision addDecFrm = new addDecision();
            this.Hide();
            addDecFrm.Show();
            addDecFrm.Top = this.Top;
            addDecFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************ADD DECISION FORM LINK ON GUARDIAN BUTTON*******************
        private void linkGBackToAdd(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addDecision addDecFrm = new addDecision();
            this.Hide();
            addDecFrm.Show();
            addDecFrm.Top = this.Top;
            addDecFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************ADD DECISION FROM LINK ON MEDICAL TAB***********************
        private void linkMBackToAdd(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addDecision addDecFrm = new addDecision();
            this.Hide();
            addDecFrm.Show();
            addDecFrm.Top = this.Top;
            addDecFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************ADD DECISION FORM LINK ON EMERGENCY CONTACT TAB*************
        private void linkECBackToAdd(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addDecision addDecFrm = new addDecision();
            this.Hide();
            addDecFrm.Show();
            addDecFrm.Top = this.Top;
            addDecFrm.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************AUTO FILL CHECKBOX FOR GUARDIAN 1***************************
        private void autofill1(object sender, EventArgs e)
        {
            tbGAddy.Text = tbAddy.Text;
            tbGCity.Text = tbCity.Text;
            tbGState.Text = tbState.Text;
            tbGPostCode.Text = tbPostCode.Text;
            //guardian1 homephone
            tbGHomeAreaCode.Text = tbHomePhArea.Text;
            tbGHome3.Text = tbHomePh3.Text;
            tbGHome4.Text = tbHomePh4.Text;
        }
        //*******************************************************************************

        //*******************AUTO FILL CHECKBOX FOR GUARDIAN 2***************************
        private void autofill2(object sender, EventArgs e)
        {
            tbGAddy2.Text = tbAddy.Text;
            tbGCity2.Text = tbCity.Text;
            tbGState2.Text = tbState.Text;
            tbGPostCode2.Text = tbPostCode.Text;
            //guardian1 homephone
            tbGHome2AreaCode.Text = tbHomePhArea.Text;
            tbGHome32.Text = tbHomePh3.Text;
            tbGHome42.Text = tbHomePh4.Text;
        }

        //*******************************************************************************

        public void wardComboBox()
        {
            DbCommand comm2 = GenericDataAccess.CreateCommand();//t.Transportation_id, t.Transportation
            comm2.CommandText = "Select ward from wards";

            cbWard.DataSource = GenericDataAccess.ExecuteSelectCommand(comm2);
            cbWard.DisplayMember = "Ward";
            //cbWard.ValueMember = "Ward";
            cbWard.SelectedIndex = -1;
        }
        //VVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

        //VVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        public void levelComboBox()
        {
            DbCommand comm2 = GenericDataAccess.CreateCommand();//t.Transportation_id, t.Transportation
            comm2.CommandText = "Select [level] from levels";

            cbAttenAs.DataSource = GenericDataAccess.ExecuteSelectCommand(comm2);
            cbAttenAs.DisplayMember = "Level";
            //cbAttenAs.ValueMember = "[Level]";
            cbAttenAs.SelectedIndex = -1;
        }
        //VVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
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
            //new 05/22

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

                    if (valid1 == true && valid2 == true && valid3 && true)
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
            if (tbCellAreaCode.Text != string.Empty || tbCellPh3.Text != string.Empty || tbCellPh4.Text != string.Empty)
            {
                if (tbCellAreaCode.Text.Length != 3 || tbCellPh3.Text.Length != 3 || tbCellPh4.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the cellphone field");
                    problems = true;
                    label8.ForeColor = Color.White;
                    label8.BackColor = Color.Red;
                }
                else
                {
                    bool valid1 = isNumValid(tbCellAreaCode.Text.ToString());
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
                    label25.ForeColor = Color.White;
                    label25.BackColor = Color.Red;
                }
                else
                {
                    if (Valid == true)
                    {
                    }

                    else
                    {
                        MessageBox.Show("Please make sure that email is in proper format");
                        label25.ForeColor = Color.White;
                        label25.BackColor = Color.Red;
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
            }//end new 05/22                

            return problems;
        }
        public bool validateGuardianTab()
        {
            bool problem = false;
            //guardian 1 homephone
            if (tbGHomeAreaCode.Text != string.Empty || tbGHome3.Text != string.Empty || tbGHome4.Text != string.Empty)
            {
                if (tbGHomeAreaCode.Text.Length != 3 || tbGHome3.Text.Length != 3 || tbGHome4.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the guardian 1 homephone field");
                    lblHomePh.ForeColor = Color.White;
                    lblHomePh.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    bool valid1 = isNumValid(tbGHomeAreaCode.Text.ToString());
                    bool valid2 = isNumValid(tbGHome3.Text.ToString());
                    bool valid3 = isNumValid(tbGHome4.Text.ToString());
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
            if (tbGCellAreaCode.Text != string.Empty || tbGCell3.Text != string.Empty || tbGCell4.Text != string.Empty)
            {
                if (tbGCellAreaCode.Text.Length != 3 || tbGCell3.Text.Length != 3 || tbGCell4.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the guardian 1 cellphone field");
                    lblCellPh.ForeColor = Color.White;
                    lblCellPh.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    bool valid1 = isNumValid(tbGCellAreaCode.Text.ToString());
                    bool valid2 = isNumValid(tbGCell3.Text.ToString());
                    bool valid3 = isNumValid(tbGCell4.Text.ToString());
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
            if (tbGHome2AreaCode.Text != string.Empty || tbGHome32.Text != string.Empty || tbGHome42.Text != string.Empty)
            {
                if (tbGHome2AreaCode.Text.Length != 3 || tbGHome32.Text.Length != 3 || tbGHome42.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the guardian 2 homephone field");
                    label20.ForeColor = Color.White;
                    label20.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    bool valid1 = isNumValid(tbGHome2AreaCode.Text.ToString());
                    bool valid2 = isNumValid(tbGHome32.Text.ToString());
                    bool valid3 = isNumValid(tbGHome42.Text.ToString());
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
            if (tbGCell2AreaCode.Text != string.Empty || tbGCell32.Text != string.Empty || tbGCell42.Text != string.Empty)
            {
                if (tbGCell2AreaCode.Text.Length != 3 || tbGCell32.Text.Length != 3 || tbGCell42.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the guardian 2 cellphone field");
                    label21.ForeColor = Color.White;
                    label21.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    bool valid1 = isNumValid(tbGCell2AreaCode.Text.ToString());
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
            if (tbECPhoneAreaCode.Text != string.Empty || tbECPhone3.Text != string.Empty || tbECPhone4.Text != string.Empty)
            {
                if (tbECPhoneAreaCode.Text.Length != 3 || tbECPhone3.Text.Length != 3 || tbECPhone4.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the emergency contact phone field");
                    lblPhNum.ForeColor = Color.White;
                    lblPhNum.BackColor = Color.Red;
                    problem = true;
                }
                else
                {
                    bool valid1 = isNumValid(tbECPhoneAreaCode.Text.ToString());
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
