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

namespace StakeCamp
{
    public class Girls : Camper
    {
        private int girlID;
        private string level;
        private int levelYear;
        private int maxAge;
        private int minAge;
        private int[] guardianArray;
        private int guardianID;//{
        private string guardEmail;
        private string guardFName;
        private string guardLName;
        private string guardHPhone;
        private string guardCPhone;
        private string guardAddress;
        private string guardState;
        private string guardCity;
        private string guardZipCode;

        public int GirlID
        {
            set
            {
                girlID = value;
            }
            get
            {
                return girlID;
            }
        }
        public string Level
        {
            set
            {
                level = value;

            }
            get
            {
                return level;
            }
        }
        public int LevelYear
        {
            set
            {
                levelYear = value;

            }
            get
            {
                return levelYear;
            }
        }
        public int MaxAge
        {
            set
            {
                maxAge = value;
            }
            get
            {
                return maxAge;
            }
        }
        public int MinAge
        {
            set
            {
                minAge = value;
            }
            get
            {
                return minAge;
            }
        }


        public int GuardianID//start contact
        {
            set
            {
                guardianID = value;
            }
            get
            {
                return guardianID;
            }
        }
        public int[] GuardianArray
        {
            set
            {
                guardianArray = value;
            }
            get
            {
                return guardianArray;
            }
        }
        public string GuardEmail
        {
            set
            {
                guardEmail = value;
            }
            get
            {
                return guardEmail;
            }
        }
        public string GuardFName
        {
            set
            {
                guardFName = value;
            }
            get
            {
                return guardFName;
            }
        }
        public string GuardLName
        {
            set
            {
                guardLName = value;
            }
            get
            {
                return guardLName;
            }
        }
        public string GuardHPhone
        {
            set
            {
                guardHPhone = value;
            }
            get
            {
                return guardHPhone;
            }
        }
        public string GuardCPhone
        {
            set
            {
                guardCPhone = value;
            }
            get
            {
                return guardCPhone;
            }
        }
        public string GuardAddress
        {
            set
            {
                guardAddress = value;
            }
            get
            {
                return guardAddress;
            }
        }
        public string GuardState
        {
            set
            {
                guardState = value;
            }
            get
            {
                return guardState;
            }
        }
        public string GuardCity
        {
            set
            {
                guardCity = value;
            }
            get
            {
                return guardCity;
            }
        }
        public string GuardZipCode
        {
            set
            {
                guardZipCode = value;
            }
            get
            {
                return guardZipCode;
            }
        }

        public void AddCamper()//start jose
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();
           
            sqlVariable = "Insert into customers(Last_name, First_name, Home_Phone, Cell_Phone, Email, Address, City, State, Zip_Code, Ward_id, Birth_Date, eContact_id)"
             + "values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                       
            cmd.Parameters.Add("@lastName", OleDbType.VarChar).Value = lastName;
            cmd.Parameters.Add("@firstName", OleDbType.VarChar).Value = firstName;
            cmd.Parameters.Add("@homePhone", OleDbType.VarChar).Value = homePhone;
            cmd.Parameters.Add("@cellPhone", OleDbType.VarChar).Value = cellPhone;
            cmd.Parameters.Add("@email", OleDbType.VarChar).Value = email;
            cmd.Parameters.Add("@address", OleDbType.VarChar).Value = address;
            cmd.Parameters.Add("@city", OleDbType.VarChar).Value = city;
            cmd.Parameters.Add("@state", OleDbType.VarChar).Value = state;
            cmd.Parameters.Add("@zipCode", OleDbType.VarChar).Value = zipCode;
            cmd.Parameters.Add("@wardID", OleDbType.VarChar).Value = wardID;
            cmd.Parameters.Add("@birthDate", OleDbType.VarChar).Value = birthDate;
            cmd.Parameters.Add("@emgContactID", OleDbType.VarChar).Value = emgContactID;

            if (getNumIdentity2(sqlVariable, cmd) == true)//checks it getNumIdentity returns true
            {
                girlID = numIdentity;//then it assigns the retrieved @@IDENTITY                
            }

            connToDB.Close();
            ADDLevelInfo();//calls function in order to add level information for the customer


        }//end jose
        public void ADDLevelInfo()//jose
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into customer_level_link(Customer_id, [Level], LevelYear)"
             + "values(?, ?, ?)";

            //customer_level_link(Customer_id, [Level], LevelYear)
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;
            cmd.Parameters.Add("@level", OleDbType.VarChar).Value = level;
            cmd.Parameters.Add("@CurrentYear", OleDbType.VarChar).Value = Currentyear;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close();
        }//end jose

        public void AddMedicalInfo()
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into girls_medical(customer_id, AsthmaYN, MedsYN, AllergiesYN)"
             + "values(?, ?, ?, ?)";

            //customer_level_link(Customer_id, [Level], LevelYear)
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;
            cmd.Parameters.Add("@asthmaYN", OleDbType.VarChar).Value = asthmaYN;
            cmd.Parameters.Add("@medsYN", OleDbType.VarChar).Value = medsYN;
            cmd.Parameters.Add("@allergyYN", OleDbType.VarChar).Value = allergyYN;

            if (getNumIdentity2(sqlVariable, cmd) == true)//checks it getNumIdentity returns true
            {
                medicalID = numIdentity;//then it assigns the retrieved @@IDENTITY 
            }

            //DataEntry(sqlVariable);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN           
            ADDLimitationsInfo();//***** calls function in roder to add limitations info***** 
        }
        public void ADDLimitationsInfo()
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            for (int i = 0; i < limitDescription.Length; i++)
            {
                OleDbCommand cmd = connToDB.CreateCommand();
                sqlVariable = "Insert into girl_limitations(customer_id, Description)"
                 + "values(?, ?)";

                //customer_level_link(Customer_id, [Level], LevelYear)
                cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;
                cmd.Parameters.Add("@limitDescription", OleDbType.VarChar).Value = limitDescription[i];

                if (getNumIdentity2(sqlVariable, cmd) == true)//checks it getNumIdentity returns true
                {
                    limitationsID = numIdentity;//then it assigns the retrieved @@IDENTITY 
                }
                //DataEntry(sqlVariable);//calls function in order to enter data into database
            }
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN    

        }
        //start jose
        public void AddGuardianInfo()//add a contact function
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into guardians(First_Name, Last_Name, Email, Home_Phone, Cell_Phone, Address, State, City, Zip_Code)"
             + "values(?, ?, ?, ?, ?, ?, ?, ?, ?)";

            //First_Name, Last_Name, Email, Home_Phone, Cell_Phone, Address, State, City, Zip_Code
            cmd.Parameters.Add("@guardFName", OleDbType.VarChar).Value = guardFName;
            cmd.Parameters.Add("@guardLName", OleDbType.VarChar).Value = guardLName;
            cmd.Parameters.Add("@guardEmail", OleDbType.VarChar).Value = guardEmail;
            cmd.Parameters.Add("@guardHPhone", OleDbType.VarChar).Value = guardHPhone;
            cmd.Parameters.Add("@guardCPhone", OleDbType.VarChar).Value = guardCPhone;
            cmd.Parameters.Add("@guardAddress", OleDbType.VarChar).Value = guardAddress;
            cmd.Parameters.Add("@guardState", OleDbType.VarChar).Value = guardState;
            cmd.Parameters.Add("@guardCity", OleDbType.VarChar).Value = guardCity;
            cmd.Parameters.Add("@guardzipCode", OleDbType.VarChar).Value = guardZipCode;


            if (getNumIdentity2(sqlVariable, cmd) == true)//checks it getNumIdentity returns true
            {
                guardianID = numIdentity;//then it assigns the retrieved @@IDENTITY 
            }
            connToDB.Close();
            AddGirlGuardianLink();

        }//end jose
        public void AddGirlGuardianLink()
        {
            string sqlVariable;
            connToDB.Open(); // THIS IS IMPORTANT

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into girl_guardian_link(guardian_id, customer_id)"
             + "values(?, ?)";

            //customer_level_link(Customer_id, [Level], LevelYear)
            cmd.Parameters.Add("@guardianID", OleDbType.VarChar).Value = guardianID;
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN   

        }
        //start jose
        public void AddEmergencyContactInfo()
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into emergency_contact(First_Name, Last_Name, Phone, Relationship)"
             + "values(?, ?, ?, ?)";

            //First_Name, Last_Name, Phone, Relationship
            cmd.Parameters.Add("@emgFirstName", OleDbType.VarChar).Value = emgFirstName;
            cmd.Parameters.Add("@emgLastName", OleDbType.VarChar).Value = emgLastName;
            cmd.Parameters.Add("@emgPhone", OleDbType.VarChar).Value = emgPhone;
            cmd.Parameters.Add("@emgRelationship", OleDbType.VarChar).Value = emgRelationship;

            if (getNumIdentity2(sqlVariable, cmd) == true)//checks it getNumIdentity returns true
            {
                emgContactID = numIdentity;//then it assigns the retrieved @@IDENTITY 
            }
            //DataEntry(sqlVariable);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN

        }//end jose
        public void Registration()
        {
            string sqlVariable;
            connToDB.Open(); // THIS IS IMPORTANT

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into enrollment(Recieved_Registration, Recieved_Emg_Consent, Recieved_Medical_Form, Recieved_Payment, Comments)"
             + "values(?, ?, ?, ?, ?)";

            //Recieved_Registration, Recieved_Emg_Consent, Recieved_Medical_Form, Recieved_Payment, Comments
            cmd.Parameters.Add("@recievedRegistration", OleDbType.VarChar).Value = recievedRegistration;
            cmd.Parameters.Add("@recievedEmergencyConcent", OleDbType.VarChar).Value = recievedEmergencyConcent;
            cmd.Parameters.Add("@recievedMedicalForm", OleDbType.VarChar).Value = recievedMedicalForm;
            cmd.Parameters.Add("@recievedPayment", OleDbType.VarChar).Value = recievedPayment;
            cmd.Parameters.Add("@enrollComments", OleDbType.VarChar).Value = enrollComments;

            if (getNumIdentity2(sqlVariable, cmd) == true)//checks it getNumIdentity returns true
            {
                enrollID = numIdentity;//then it assigns the retrieved @@IDENTITY 
            }
            //DataEntry(sqlVariable);//calls function in order to enter data into database
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
            addEnrollmentGirlLink();
        }
        public void DefaultRegistration()
        {
            string regist = "";
            string emergency = "";
            string medical = "";
            string payment = "";
            string enroll = "";
            string sqlVariable;
            connToDB.Open(); // THIS IS IMPORTANT

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into enrollment(Recieved_Registration, Recieved_Emg_Consent, Recieved_Medical_Form, Recieved_Payment, Comments)"
             + "values(?, ?, ?, ?, ?)";

            //Recieved_Registration, Recieved_Emg_Consent, Recieved_Medical_Form, Recieved_Payment, Comments

            cmd.Parameters.Add("@regist", OleDbType.VarChar).Value = regist;
            cmd.Parameters.Add("@emergency", OleDbType.VarChar).Value = emergency;
            cmd.Parameters.Add("@medical", OleDbType.VarChar).Value = medical;
            cmd.Parameters.Add("@payment", OleDbType.VarChar).Value = payment;
            cmd.Parameters.Add("@enroll", OleDbType.VarChar).Value = enroll;

            if (getNumIdentity2(sqlVariable, cmd) == true)//checks it getNumIdentity returns true
            {
                enrollID = numIdentity;//then it assigns the retrieved @@IDENTITY 
            }
            //DataEntry(sqlVariable);//calls function in order to enter data into database
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN           
        }
        public void addEnrollmentGirlLink()
        {
            connToDB.Open(); // THIS IS IMPORTANT
            string sqlVariable;
            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into enrollment_girl_link(enrollment_ID, EnrollYear, customerID)"
             + "values(?, ?, ?)";

            //Recieved_Registration, Recieved_Emg_Consent, Recieved_Medical_Form, Recieved_Payment, Comments
            cmd.Parameters.Add("@enrollID", OleDbType.VarChar).Value = enrollID;
            cmd.Parameters.Add("@Currentyear", OleDbType.VarChar).Value = Currentyear;
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN

        }
        public void GetCustomer(string custID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            int myParsedInt2 = Int32.Parse(custID);
            girlID = Convert.ToInt32(custID);

            comm.CommandText = "Select * from Customers where customerID = " +
                  girlID;//cusID
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                lastName = table.Rows[0]["Last_name"].ToString();//[1]
                firstName = table.Rows[0]["First_name"].ToString();//[2]               
                homePhone = table.Rows[0]["Home_Phone"].ToString();
                cellPhone = table.Rows[0]["Cell_Phone"].ToString();
                email = table.Rows[0]["Email"].ToString();
                address = table.Rows[0]["Address"].ToString();
                city = table.Rows[0]["City"].ToString();
                state = table.Rows[0]["State"].ToString();
                zipCode = table.Rows[0]["Zip_Code"].ToString();
                birthDate = table.Rows[0]["Birth_Date"].ToString();
                wardID = table.Rows[0]["Ward_id"].ToString();
                string temp = table.Rows[0]["eContact_id"].ToString();
                int myParsedInt = Int32.Parse(temp);
                emgContactID = Convert.ToInt32(temp);
                GetEContact();
                GetGirlMedical();
                GetCustomerLevelLink();
                GetGuardianLink();
                GetEnrollLink();
                GetGirlNestlink();
                GetGirlsTransLink();
            }
        }
        public void GetEContact()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from emergency_contact where Emergency_contactID = " +
                  emgContactID;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                emgFirstName = table.Rows[0]["First_Name"].ToString();//[1]
                emgLastName = table.Rows[0]["Last_Name"].ToString();//[2]               
                emgPhone = table.Rows[0]["Phone"].ToString();
                emgRelationship = table.Rows[0]["Relationship"].ToString();
            }
            else//***********new 05/18*************
            {
                emgFirstName = "";
                emgLastName = "";
                emgPhone = "";
                emgRelationship = "";
            }

        }
        public void GetGirlMedical()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from girls_medical where customer_id = " +
                  girlID;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                asthmaYN = table.Rows[0]["AsthmaYN"].ToString();//[1]
                medsYN = table.Rows[0]["MedsYN"].ToString();//[2]               
                allergyYN = table.Rows[0]["AllergiesYN"].ToString();
            }
            else//***********new 05/18*************
            {
                asthmaYN = "";
                medsYN = "";
                allergyYN = "";
            }
            GetGirlLimitations();
        }
        public void GetGirlLimitations()
        {

            string sqlVariable = "Select * from girl_limitations where customer_id = " +
                      girlID;


            int i = 0;
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = sqlVariable;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            limitDescription = new string[table.Rows.Count];
            limitationsArray = new int[table.Rows.Count];
            if (table.Rows.Count > 0)//left off here
            {
                do
                {
                    if (table.Rows.Count > 0)//might take out this if statement
                    {
                        string temp = table.Rows[i]["LimitationsID"].ToString();
                        int myParsedInt = Int32.Parse(temp);
                        limitationsArray[i] = Convert.ToInt32(temp);//gets the limitations id                    
                        limitDescription[i] = table.Rows[i]["Description"].ToString();//[1]                                       
                    }
                    i++;
                }
                while (i < limitDescription.Length);
            }
            else
            {
                limitDescription[i] = "";

            }
        }
        public void GetCustomerLevelLink()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from customer_level_link where Customer_id = ? and LevelYear=?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@girlID";
            param.DbType = DbType.String;
            param.Value = girlID;
            comm.Parameters.Add(param);

            DbParameter param2 = comm.CreateParameter();//last year
            param2.ParameterName = "@Currentyear";
            param2.DbType = DbType.String;
            param2.Value = Currentyear;
            comm.Parameters.Add(param2);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                level = table.Rows[0]["Level"].ToString();
                string temp = table.Rows[0]["LevelYear"].ToString();
                int myParsedInt = Int32.Parse(temp);
                levelYear = Convert.ToInt32(temp);
            }
            else//**********New
            {
                level = "";
            }
        }
        public void GetGuardianLink()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from girl_guardian_link where customer_id = " +
                  girlID;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            guardianArray = new int[table.Rows.Count];
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < guardianArray.Length; i++)
                {
                    if (table.Rows.Count > 0)//might take this out
                    {
                        string temp = table.Rows[i]["guardian_id"].ToString();
                        int myParsedInt = Int32.Parse(temp);
                        guardianArray[i] = Convert.ToInt32(temp);
                    }
                }
            }
            else//*************new 05/18 *************8
            {
                guardFName = "";
                guardLName = "";
                guardEmail = "";
                guardHPhone = "";
                guardCPhone = "";
                guardAddress = "";
                guardState = "";
                guardCity = "";
                guardZipCode = "";
            }

        }
        public void GetGuardian()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from guardians where Guardian_ID = " +
                  guardianID;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                guardFName = table.Rows[0]["First_Name"].ToString();//[1]
                guardLName = table.Rows[0]["Last_Name"].ToString();//[2]               
                guardEmail = table.Rows[0]["Email"].ToString();
                guardHPhone = table.Rows[0]["Home_Phone"].ToString();
                guardCPhone = table.Rows[0]["Cell_Phone"].ToString();
                guardAddress = table.Rows[0]["Address"].ToString();
                guardState = table.Rows[0]["State"].ToString();
                guardCity = table.Rows[0]["City"].ToString();
                guardZipCode = table.Rows[0]["Zip_Code"].ToString();
            }
        }
        public void GetEnrollLink()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from enrollment_girl_link where customerID = ? and EnrollYear =?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@girlID";
            param.DbType = DbType.String;
            param.Value = girlID;
            comm.Parameters.Add(param);

            DbParameter param2 = comm.CreateParameter();//last year
            param2.ParameterName = "@Currentyear";
            param2.DbType = DbType.String;
            param2.Value = Currentyear;
            comm.Parameters.Add(param2);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                string temp1 = table.Rows[0]["enrollment_ID"].ToString();//[1]
                int myParsedInt = Int32.Parse(temp1);
                enrollID = Convert.ToInt32(temp1);
                string temp2 = table.Rows[0]["EnrollYear"].ToString();//[2] 
                int myParsedInt2 = Int32.Parse(temp2);
                enrollYear = Convert.ToInt32(temp2);
                GetEnrollment();
            }
            else
            {
                recievedRegistration = "";
                recievedEmergencyConcent = "";
                recievedMedicalForm = "";
                recievedPayment = "";
                enrollComments = "";

            }

        }
        public void GetEnrollIDArray()//********* new 05/22 *****************
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from enrollment_girl_link where customerID = ?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@girlID";
            param.DbType = DbType.String;
            param.Value = girlID;
            comm.Parameters.Add(param);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            enrollArray = new int[table.Rows.Count];

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < enrollArray.Length; i++)
                {

                    string temp1 = table.Rows[i]["enrollment_ID"].ToString();//[1]
                    int myParsedInt = Int32.Parse(temp1);
                    enrollArray[i] = Convert.ToInt32(temp1);
                }

            }
        }
        public void GetEnrollment()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from enrollment where Enroll_ID = " +
                  enrollID;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                recievedRegistration = table.Rows[0]["Recieved_Registration"].ToString();//[1]
                recievedEmergencyConcent = table.Rows[0]["Recieved_Emg_Consent"].ToString();//[2]               
                recievedMedicalForm = table.Rows[0]["Recieved_Medical_Form"].ToString();
                recievedPayment = table.Rows[0]["Recieved_Payment"].ToString();
                enrollComments = table.Rows[0]["Comments"].ToString();
            }
        }
        public void GetGirlsTransLink()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from transportation_customer_link where Customer_id = ? and transYear =?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@girlID";
            param.DbType = DbType.String;
            param.Value = girlID;
            comm.Parameters.Add(param);

            DbParameter param2 = comm.CreateParameter();//last year
            param2.ParameterName = "@Currentyear";
            param2.DbType = DbType.String;
            param2.Value = Currentyear;
            comm.Parameters.Add(param2);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                string temp1 = table.Rows[0]["Transportation_id"].ToString();
                int myParsedInt = Int32.Parse(temp1);
                transportID = Convert.ToInt32(temp1);
                string temp2 = table.Rows[0]["transYear"].ToString();
                int myParsedInt2 = Int32.Parse(temp2);
                tripYear = Convert.ToInt32(temp2);
                GetTransportation();
            }
            else
            {
                transportationType = "";
            }

        }
        public void GetGirlNestlink()//fixed
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from girl_nest_link where customerID = " +
                  girlID;

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                string temp1 = table.Rows[0]["nest_id"].ToString();
                int myParsedInt = Int32.Parse(temp1);
                nestID = Convert.ToInt32(temp1);
                GetNest();
            }
            else
            {
                nestName = "";
            }


        }
        public void updateCamper()//VEA BEGIN
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "UPDATE customers SET Last_name=?, First_Name=?, Home_Phone=?, Cell_Phone=?, Email=?, Address=?, City=?, State=?, Zip_Code=?, Birth_Date=? ,Ward_id=?  WHERE CustomerID=?";

            //// @address, @city, @state, @zipCode, @wardID, @birthDate, @emgContactID
            cmd.Parameters.Add("@lastName", OleDbType.VarChar).Value = lastName;
            cmd.Parameters.Add("@firstName", OleDbType.VarChar).Value = firstName;
            cmd.Parameters.Add("@homePhone", OleDbType.VarChar).Value = homePhone;
            cmd.Parameters.Add("@cellPhone", OleDbType.VarChar).Value = cellPhone;
            cmd.Parameters.Add("@email", OleDbType.VarChar).Value = email;
            cmd.Parameters.Add("@address", OleDbType.VarChar).Value = address;
            cmd.Parameters.Add("@city", OleDbType.VarChar).Value = city;
            cmd.Parameters.Add("@state", OleDbType.VarChar).Value = state;
            cmd.Parameters.Add("@zipCode", OleDbType.VarChar).Value = zipCode;
            cmd.Parameters.Add("@birthDate", OleDbType.VarChar).Value = birthDate;
            cmd.Parameters.Add("@wardID", OleDbType.VarChar).Value = wardID;
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;
            //cmd.Parameters.Add("@emgContactID", OleDbType.VarChar).Value = emgContactID;          
            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
            updateLevelInfo();

        }//VEA END
        //*******************************************************************************

        //*******************DELETE CAMPER***********************************************
        public void deleteCamper()//vea begin
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from customers Where CustomerID=?";
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);
            connToDB.Close();
        }//vea end 

        public void updateLevelInfo()//VEA BEGIN
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update customer_level_link Set [Level]=? Where LevelYear=? and Customer_id=?";

            //customer_level_link(Customer_id, [Level], LevelYear)          
            cmd.Parameters.Add("@level", OleDbType.VarChar).Value = level;
            cmd.Parameters.Add("@CurrentYear", OleDbType.VarChar).Value = Currentyear;
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close();
        }//VEA END
        //*******************************************************************************

        //*******************DELETE LEVEL INFORMATION************************************
        public void deleteLevelInfo()//vea begin
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from customer_level_link Where Customer_id=?";
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close();//vea end
        }

        public void updateMedicalInfo()//VEA BEGIN//fixed
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update girls_medical Set AsthmaYN=?, MedsYN=?, AllergiesYN=? Where customer_id=?";

            //customer_level_link(Customer_id, [Level], LevelYear)           
            cmd.Parameters.Add("@asthmaYN", OleDbType.VarChar).Value = asthmaYN;
            cmd.Parameters.Add("@medsYN", OleDbType.VarChar).Value = medsYN;
            cmd.Parameters.Add("@allergyYN", OleDbType.VarChar).Value = allergyYN;
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);
            connToDB.Close();

        }//VEA END
        //*******************************************************************************

        //*******************DELETE MEDICAL INFORMATION**********************************
        public void deleteMedicalInfo()//vea begin
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from girls_medical Where customer_id=?";
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN 
        }//vea end 


        public void updateLimitationsInfo()//VEA BEGIN//fixed
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;
            sqlVariable = "Update girl_limitations Set Description=? Where customer_id=? and LimitationsID=?";
            for (int i = 0; i < limitDescription.Length; i++)
            {

                OleDbCommand cmd = connToDB.CreateCommand();

                cmd.Parameters.Add("@limitDescription", OleDbType.VarChar).Value = limitDescription[i];
                cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;
                cmd.Parameters.Add("@limitationsID", OleDbType.VarChar).Value = limitationsID;
                DataEntry2(sqlVariable, cmd);
            }
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN 
        }//VEA END
        //*******************************************************************************

        //*******************DELETE LIMITATIONS INFORMATION******************************
        public void deleteLimitationsInfo()
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from girl_limitations Where customer_id=?";
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }
        //*******************************************************************************

        //*******************UPDATE GUARDIAN INFORMATION*********************************
        public void updateGuardianInfo()//vea begin
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update guardians Set First_Name=?, Last_Name=?, Email=?, Home_Phone=?, Cell_Phone=?, Address=?, State=?, City=?, Zip_Code=? Where Guardian_ID=?";

            //First_Name, Last_Name, Email, Home_Phone, Cell_Phone, Address, State, City, Zip_Code
            cmd.Parameters.Add("@guardFName", OleDbType.VarChar).Value = guardFName;
            cmd.Parameters.Add("@guardLName", OleDbType.VarChar).Value = guardLName;
            cmd.Parameters.Add("@guardEmail", OleDbType.VarChar).Value = guardEmail;
            cmd.Parameters.Add("@guardHPhone", OleDbType.VarChar).Value = guardHPhone;
            cmd.Parameters.Add("@guardCPhone", OleDbType.VarChar).Value = guardCPhone;
            cmd.Parameters.Add("@guardAddress", OleDbType.VarChar).Value = guardAddress;
            cmd.Parameters.Add("@guardState", OleDbType.VarChar).Value = guardState;
            cmd.Parameters.Add("@guardCity", OleDbType.VarChar).Value = guardCity;
            cmd.Parameters.Add("@guardzipCode", OleDbType.VarChar).Value = guardZipCode;
            cmd.Parameters.Add("@guardianID", OleDbType.VarChar).Value = guardianID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }//vea end
        //*******************************************************************************

        //*******************DELETE GUARDIAN INFORMATION*********************************
        public void deleteGuardianInfo()//vea begin
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from guardians Where Guardian_ID=?";
            cmd.Parameters.Add("@guardianID", OleDbType.VarChar).Value = guardianID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();

        }//vea end
        //*******************************************************************************


        ////*******************UPDATE GIRL GUARDIAN LINK***********************************
        //public void updateGirlGuardianLink()//vea begin
        //{
        //    string sqlVariable;
        //    connToDB.Open(); // THIS IS IMPORTANT

        //    OleDbCommand cmd = connToDB.CreateCommand();

        //    sqlVariable = "Update girl_guardian_link Set(guardian_id=?, customer_id=? Where Medical_id=?, connToDB)";

        //    //customer_level_link(Customer_id, [Level], LevelYear)
        //    cmd.Parameters.Add("@guardianID", OleDbType.VarChar).Value = guardianID;
        //    cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

        //    DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

        //    connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN 
        //}//vea end
        ////*******************************************************************************

        //*******************DELETE GIRL GUARDIAN LINK***********************************
        public void deleteGirlGuardianLink()//vea begin
        {
            string sqlVariable;
            connToDB.Open(); // THIS IS IMPORTANT

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from girl_guardian_link Where customer_id=?";
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN 
        }//vea end
        //*******************************************************************************

        //*******************UPDATE EMERGENCY CONTACT INFORMATION************************
        public void updateEmergencyContactInfo()//vea begin//fixed
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update emergency_contact Set First_Name=?, Last_Name=?, Phone=?, Relationship=? Where Emergency_contactID=?";

            //First_Name, Last_Name, Phone, Relationship
            cmd.Parameters.Add("@emgFirstName", OleDbType.VarChar).Value = emgFirstName;
            cmd.Parameters.Add("@emgLastName", OleDbType.VarChar).Value = emgLastName;
            cmd.Parameters.Add("@emgPhone", OleDbType.VarChar).Value = emgPhone;
            cmd.Parameters.Add("@emgRelationship", OleDbType.VarChar).Value = emgRelationship;
            cmd.Parameters.Add("@emgContactID", OleDbType.VarChar).Value = emgContactID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }//vea end
        //*******************************************************************************

        //*******************DELETE EMERGENCY CONTACT INFORMATION************************
        public void deleteEmergencyContactInfo()//vea begin
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from emergency_contact Where Emergency_contactID=?";
            cmd.Parameters.Add("@emgContactID", OleDbType.VarChar).Value = emgContactID;

            DataEntry2(sqlVariable, cmd);
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }//vea end
        //*******************************************************************************


        //*******************UPDATE REGISTRATION*****************************************
        public void updateRegistration()//vea begin//fixed
        {
            string sqlVariable;
            connToDB.Open(); // THIS IS IMPORTANT

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update enrollment Set Recieved_Registration=?, Recieved_Emg_Consent=?, Recieved_Medical_Form=?, Recieved_Payment=?, Comments=? Where Enroll_ID";

            //Recieved_Registration, Recieved_Emg_Consent, Recieved_Medical_Form, Recieved_Payment, Comments
            cmd.Parameters.Add("@recievedRegistration", OleDbType.VarChar).Value = recievedRegistration;
            cmd.Parameters.Add("@recievedEmergencyConcent", OleDbType.VarChar).Value = recievedEmergencyConcent;
            cmd.Parameters.Add("@recievedMedicalForm", OleDbType.VarChar).Value = recievedMedicalForm;
            cmd.Parameters.Add("@recievedPayment", OleDbType.VarChar).Value = recievedPayment;
            cmd.Parameters.Add("@enrollComments", OleDbType.VarChar).Value = enrollComments;
            cmd.Parameters.Add("@enrollID", OleDbType.VarChar).Value = enrollID;

            DataEntry2(sqlVariable, cmd);
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN           
        }//vea end
        //*******************************************************************************

        //*******************DELETE REGISTRATION*****************************************
        public void deleteRegistration()//vea begin
        {
            string sqlVariable;
            connToDB.Open(); // THIS IS IMPORTANT

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from enrollment Where Enroll_ID";
            cmd.Parameters.Add("@enrollID", OleDbType.VarChar).Value = enrollID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN            
        }//vea end
        //*******************************************************************************

        //*******************UPDATE ENROLLMENT GIRL LINK*********************************
        //public void updateEnrollmentGirlLink()//vea begin
        //{
        //    connToDB.Open(); // THIS IS IMPORTANT
        //    string sqlVariable;
        //    OleDbCommand cmd = connToDB.CreateCommand();

        //    sqlVariable = "Update enrollment_girl_link Set enrollmentID=?, EnrollYear=?, customerID=? Where EnrollmentID=?";

        //    //Recieved_Registration, Recieved_Emg_Consent, Recieved_Medical_Form, Recieved_Payment, Comments
        //    cmd.Parameters.Add("@enrollID", OleDbType.VarChar).Value = enrollID;
        //    cmd.Parameters.Add("@Currentyear", OleDbType.VarChar).Value = Currentyear;
        //    cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

        //    DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database
        //    connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        //}//vea end
        ////*******************************************************************************

        //*******************DELETE ENROLLMENT GIRL LINK*********************************
        public void deleteEnrollmentGirlLink()//vea begin
        {
            connToDB.Open(); // THIS IS IMPORTANT
            string sqlVariable;
            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from enrollment_girl_link Where customerID=?";
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }//vea end

        //might take out later deleteEnrollmentGirlLink2()
        ////*******************************************************************************
        //public void deleteEnrollmentGirlLink2()//new 05/22
        //{           
        //    connToDB.Open(); // THIS IS IMPORTANT
        //    string sqlVariable;
        //    OleDbCommand cmd = connToDB.CreateCommand();

        //    sqlVariable = "Delete from enrollment_girl_link Where customerID=? and enrollmentID =? ";
        //    cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;
        //    cmd.Parameters.Add("@enrollID", OleDbType.VarChar).Value = enrollID;

        //    DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database
        //    connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        //}
        ////*******************************************************************************

        //*******************ADD TRANSPORTATION CUSTOMER LINK****************************
        public void addTransCustomerLink()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into transportation_customer_link(Transportation_id, Customer_id, transYear)"
                + "values(?, ?, ?)";

            cmd.Parameters.Add("@transportID", OleDbType.VarChar).Value = transportID;
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;
            cmd.Parameters.Add("@Currentyear", OleDbType.VarChar).Value = Currentyear;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

        public void updateTransCustomerLink()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update transportation_customer_link Set Transportation_id =? where Customer_id =? and transYear =?";
            cmd.Parameters.Add("@transportID", OleDbType.VarChar).Value = transportID;
            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;
            cmd.Parameters.Add("@Currentyear", OleDbType.VarChar).Value = Currentyear;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }


        //*******************DELETE TRANSPORTATION CUSTOMER LINK*************************
        public void deleteTransCustomerLink()//fixed 05/22
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from transportation_customer_link Where Customer_id=?";

            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************



        //*******************ADD GIRL NEST LINK******************************************
        public void addGirlNestLink()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into girl_nest_link(customerID, nest_id)"
                + "values(?, ?)";

            cmd.Parameters.Add("@girlID", OleDbType.VarChar).Value = girlID;
            cmd.Parameters.Add("@nestID", OleDbType.VarChar).Value = nestID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

        //*******************DELETE GIRL NEST LINK***************************************
        public void deleteGirlNestLink()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from girl_nest_link Where customerID=?";

            cmd.Parameters.Add("girlID", OleDbType.VarChar).Value = girlID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        public void updateGirlsNestLink()// VEA BEGIN//fixed
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update girl_nest_link Set nest_id=? Where customerID=?";

            cmd.Parameters.Add("@nestID", OleDbType.VarChar).Value = nestID;
            cmd.Parameters.Add("@customerID", OleDbType.VarChar).Value = girlID;


            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        public void GetAllGirlLinks()//left off 05/14
        {
            int oldYear = Currentyear - 1;
            DbCommand comm = GenericDataAccess.CreateCommand();

            comm.CommandText = "SELECT CustomerID " +
                "FROM customers INNER JOIN customer_level_link ON customers.CustomerID = customer_level_link.Customer_id " +
                "where LevelYear=?";

            DbParameter param3 = comm.CreateParameter();//last year
            param3.ParameterName = "@oldYear";
            param3.DbType = DbType.String;
            param3.Value = oldYear;
            comm.Parameters.Add(param3);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            int rowLength = table.Rows.Count;

            for (int i = 0; i < rowLength; i++)
            {

                string temp = table.Rows[i]["CustomerID"].ToString();
                int myParsedInt = Int32.Parse(temp);
                girlID = Convert.ToInt32(temp);

                //GetCustomerLevelLink();
                DbCommand cmd = GenericDataAccess.CreateCommand();

                cmd.CommandText = "Select * from customer_level_link where Customer_id = ? and LevelYear =?";


                DbParameter param = cmd.CreateParameter();
                param.ParameterName = "girlID@";
                param.DbType = DbType.String;
                param.Value = girlID;
                cmd.Parameters.Add(param);


                DbParameter param2 = cmd.CreateParameter();
                param2.ParameterName = "@oldYear";
                param2.DbType = DbType.String;
                param2.Value = oldYear;
                cmd.Parameters.Add(param2);

                DataTable table1 = GenericDataAccess.ExecuteSelectCommand(cmd);

                if (table1.Rows.Count > 0)
                {
                    level = table1.Rows[0]["Level"].ToString();
                }

                //******************************************
                //insert into customer_level_link table
                ADDLevelInfo();
                DefaultRegistration();
                addEnrollmentGirlLink();
                //maybe update the enrollment table to default state or just insert a new table
                //insert into enroll_girl_link table
                //********************************************

            }
        }
        public bool duplicateGirlValidation()
        {
            bool found = false;
            DbCommand comm = GenericDataAccess.CreateCommand();

            comm.CommandText = "Select * from Customers where First_name = ? and Last_name = ?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@firstName";
            param.DbType = DbType.String;
            param.Value = firstName;
            comm.Parameters.Add(param);

            DbParameter param2 = comm.CreateParameter();
            param2.ParameterName = "@lastName";
            param2.DbType = DbType.String;
            param2.Value = lastName;
            comm.Parameters.Add(param2);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                found = true;
                string temp = table.Rows[0]["CustomerID"].ToString();
                int myParsedInt = Int32.Parse(temp);
                girlID = Convert.ToInt32(temp);
            }
            return found;

        }
    }

}