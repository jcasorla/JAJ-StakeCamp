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
    public partial class adultForm : Form
    {
        Adults adultHelper = new Adults();
        public adultForm()
        {
            InitializeComponent();
            wardComboBox();
            this.CampTabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.CampTabs.DrawItem += new DrawItemEventHandler(this.tabControl1_DrawItem);
        }

        //*******************CLEAR BUTTON ON ADULT TAB***********************************
        private void adultClearForm(object sender, EventArgs e)
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
            tbFName.Clear();
            tbLName.Clear();
            tbAddy.Clear();
            tbCity.Clear();
            tbState.Clear();
            tbPostCode.Clear();
            //adult homephone
            tbHomePhArea.Clear();
            tbHomePh3.Clear();
            tbHomePh4.Clear();
            //adult cellphone
            tbCellPhCell.Clear();
            tbCellPh3.Clear();
            tbCellPh4.Clear();
            tbEmail.Clear();
            ckbxRecReg.Checked = false;
            ckbxMedForm.Checked = false;
            ckbxRecConsent.Checked = false;
            ckbxRecMoney.Checked = false;
            tbMonth.Clear();
            tbDate.Clear();
            tbYear.Clear();
        }
        //*******************************************************************************

        //*******************CLEAR BUTTON ON MEDICAL TAB*********************************
        private void medClearForm(object sender, EventArgs e)
        {
            LimitRBTBox.Clear();
            AsthmaRB1.Checked = false;
            AsthmaRB2.Checked = false;
            MedsRB1.Checked = false;
            MedsRB2.Checked = false;
            AllergiesRB1.Checked = false;
            AllergiesRB2.Checked = false;

        }
        //*******************************************************************************

        //*******************CLEAR BUTTON ON EMERENCY CONTACT TAB************************
        private void emergClearForm(object sender, EventArgs e)
        {
            //emg contact tab
            lblPhNum.ForeColor = Color.Black;
            lblPhNum.BackColor = Color.White;

            tbECFName.Clear();
            tbECLName.Clear();
            tbECPhoneArea.Clear();
            tbECPhone3.Clear();
            tbECPhone4.Clear();
            tbRelat.Clear();
        }
        //*******************************************************************************

        //*******************LINK TO MAIN MENU ON ADULT TAB******************************
        private void linkAMainMenu(object sender, EventArgs e)
        {
            mainMenu mainM = new mainMenu();
            this.Hide();
            mainM.Show();
            mainM.Top = this.Top;
            mainM.Left = this.Left;
            this.Close();
        }
        //*******************************************************************************

        //*******************LINK TO MAIN MENU ON MEDICAL TAB****************************
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

        //*******************LINK TO MAIN MENU ON EMERGENCY CONTACT**********************
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

        //*******************NEXT BUTTON ON ADULT TAB************************************
        private void nextMedical(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpMedical;
        }
        //*******************************************************************************

        //*******************PREVIOUS & NEXT BUTTON ON MEDICAL TAB***********************
        private void prevAdult(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpAdult;
        }

        private void nextEmerCont(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpEmerCont;
        }
        //*******************************************************************************

        //*******************PREVIOUS BUTTON ON EMERGENCY CONTACT TAB********************
        private void prevMedical(object sender, EventArgs e)
        {
            CampTabs.SelectedTab = tpMedical;
        }
        //*******************************************************************************

        //*******************SUBMIT BUTTON***********************************************
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //adultHelper.numOfWorked = 0;
            bool valid1 = validateAdulttab();
            bool valid2 = validateAdultEmg();
            if (valid1 == true || valid2 == true)
            {

            }
            else
            {
                //*****Adult tab********
                if (cbWard.Text == string.Empty)//new 05/24
                {
                    adultHelper.WardID = "None";
                }
                else
                {
                    adultHelper.WardID = cbWard.Text;
                }
                if (tbAssignments.Text == string.Empty)
                {
                    adultHelper.AssignmentDescription = "";
                }
                else
                {
                    adultHelper.AssignmentDescription = tbAssignments.Text;
                }
                adultHelper.FirstName = tbFName.Text;
                adultHelper.LastName = tbLName.Text;

                if (tbMonth.Text == string.Empty || tbDate.Text == string.Empty || tbYear.Text == string.Empty)
                {
                    adultHelper.BirthDate = "";
                }
                else
                {
                    adultHelper.BirthDate = tbMonth.Text + "/" + tbDate.Text + "/" + tbYear.Text;
                }
                adultHelper.Address = tbAddy.Text;
                adultHelper.City = tbCity.Text;
                adultHelper.State = tbState.Text;
                adultHelper.ZipCode = tbPostCode.Text;
                if (tbHomePhArea.Text == string.Empty || tbHomePh3.Text == string.Empty || tbHomePh4.Text == string.Empty)
                {
                    adultHelper.HomePhone = "";
                }
                else
                {
                    //adult homephone
                    adultHelper.HomePhone = "(" + tbHomePhArea.Text + ") " + tbHomePh3.Text + "-" + tbHomePh4.Text;
                }
                if (tbCellPhCell.Text == string.Empty || tbCellPh3.Text == string.Empty || tbCellPh4.Text == string.Empty)
                {
                    adultHelper.CellPhone = "";
                }
                else
                {
                    //adult cellphone
                    adultHelper.CellPhone = "(" + tbCellPhCell.Text + ") " + tbCellPh3.Text + "-" + tbCellPh4.Text;
                }
                if (ckbxRecReg.Checked)   //*********figure out how to get value from checkbox
                {
                    adultHelper.RecievedRegistration = "Yes";
                }
                else
                {
                    adultHelper.RecievedRegistration = "No";

                }
                if (ckbxRecConsent.Checked)
                {
                    adultHelper.RecievedEmergencyConcent = "Yes";
                }
                else
                {
                    adultHelper.RecievedEmergencyConcent = "No";
                }
                if (ckbxMedForm.Checked)
                {
                    adultHelper.RecievedMedicalForm = "Yes";
                }
                else
                {
                    adultHelper.RecievedMedicalForm = "No";
                }

                if (ckbxRecMoney.Checked)
                {
                    adultHelper.RecievedPayment = "Yes";
                }
                else
                {
                    adultHelper.RecievedPayment = "No";
                }

                adultHelper.EnrollComments = addComBox.Text;



                //**********Medical Tab************
                if (AsthmaRB1.Checked)
                {
                    adultHelper.AsthmaYN = "Yes";
                }
                else if (AsthmaRB2.Checked)
                {
                    adultHelper.AsthmaYN = "No";
                }
                else
                {
                    adultHelper.AsthmaYN = "No";
                }
                if (MedsRB1.Checked)
                {
                    adultHelper.MedsYN = "Yes";
                }
                else if (MedsRB2.Checked)
                {
                    adultHelper.MedsYN = "No";
                }
                else
                {
                    adultHelper.MedsYN = "No";
                }
                if (AllergiesRB1.Checked)
                {
                    adultHelper.AllergyYN = "Yes";

                }
                else if (AllergiesRB2.Checked)
                {
                    adultHelper.AllergyYN = "No";
                }
                else
                {
                    adultHelper.AllergyYN = "No";
                }

                adultHelper.LimitDescription = LimitRBTBox.Text.Split(',');//jose



                //*******Emergency Contact Tab***********
                adultHelper.EmgFirstName = tbECFName.Text;
                adultHelper.EmgLastName = tbECLName.Text;
                if (tbECPhoneArea.Text == string.Empty || tbECPhone3.Text == string.Empty || tbECPhone4.Text == string.Empty)
                {
                    adultHelper.EmgPhone = "";
                }
                else
                {
                    //emg phone
                    adultHelper.EmgPhone = "(" + tbECPhoneArea.Text + ") " + tbECPhone3.Text + "-" + tbECPhone4.Text;
                }
                adultHelper.EmgRelationship = tbRelat.Text;

                if (adultHelper.duplicateAdultValidation() == true)
                {
                    int tempID = adultHelper.AdultID;
                    DuplicateAdult validateA = new DuplicateAdult();

                    validateA.ID = tempID;
                    validateA.ValidateAdult = adultHelper;



                    this.Hide();
                    validateA.Show();
                    validateA.Top = this.Top;
                    validateA.Left = this.Left;
                    this.Close();

                }
                else
                {
                    //**********Function Calls ***********
                    adultHelper.AddEmergencyContactInfo();//calls function in order to add adult helpers emergency contact info
                    adultHelper.AddAdult();//calls function in order to add adult helper
                    adultHelper.Registration();// calls function in order to add adult helpers registration info
                    adultHelper.AddMedicalInfo();//calls function in order to add adult helpers medical info

                    //if (adultHelper.numOfWorked == 8)
                    if(adultHelper.didNotwork == false)
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
        //*******************************************************************************

        //*******************ADD DECISION FORM LINK ON ADULT TAB*************************
        private void linkABackToAdd(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addDecision addDecFrm = new addDecision();
            this.Hide();
            addDecFrm.Show();
            addDecFrm.Top = this.Top;
            addDecFrm.Left = this.Left;
        }
        //*******************************************************************************

        //*******************ADD DECISION FORM LINK ON MEDICAL TAB***********************
        private void linkMBackToAdd(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addDecision addDecFrm = new addDecision();
            this.Hide();
            addDecFrm.Show();
            addDecFrm.Top = this.Top;
            addDecFrm.Left = this.Left;
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
        }

        //VVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        public void wardComboBox()
        {
            DbCommand comm2 = GenericDataAccess.CreateCommand();//t.Transportation_id, t.Transportation
            comm2.CommandText = "Select ward from wards";

            cbWard.DataSource = GenericDataAccess.ExecuteSelectCommand(comm2);
            cbWard.DisplayMember = "Ward";
            //cbCamperTrans.ValueMember = "Transportation_id";
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
            if (tbCellPhCell.Text != string.Empty || tbCellPh3.Text != string.Empty || tbCellPh4.Text != string.Empty)
            {
                if (tbCellPhCell.Text.Length != 3 || tbCellPh3.Text.Length != 3 || tbCellPh4.Text.Length != 4)
                {
                    MessageBox.Show("Please check that you are not missing numbers in the cellphone field");
                    problems = true;
                    label8.ForeColor = Color.White;
                    label8.BackColor = Color.Red;
                }
                else
                {
                    bool valid1 = isNumValid(tbCellPhCell.Text.ToString());
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
