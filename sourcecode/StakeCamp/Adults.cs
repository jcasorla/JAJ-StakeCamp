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
    public class Adults : Camper
    {

        private int adultID;//new
        private int[] adultArray;
        private int assignID;
        private int[] assignArray;
        private int assignYear;
        private string assignmentDescription;
        private int assignmentYear;       
       



        public int AdultID
        {
            set
            {
                adultID = value;
            }
            get
            {
                return adultID;
            }

        }
        public int[] AdultArray//new
        {
            set
            {
                adultArray = value;
            }
            get
            {
                return adultArray;
            }

        }
        public int AssignID
        {
            set
            {
                assignID = value;
            }
            get
            {
                return assignID;
            }
        }
        public int[] AssignArray
        {
            set
            {
                assignArray = value;
            }
            get
            {
                return assignArray;
            }
        }
        public int AssignYear
        {
            set
            {
                assignYear = value;
            }
            get
            {
                return assignYear;
            }

        }

        public string AssignmentDescription
        {
            set
            {
                assignmentDescription = value;
            }
            get
            {
                return assignmentDescription;
            }
        }
        public int AssignmentYear
        {
            set
            {
                assignmentYear = value;
            }
            get
            {
                return assignmentYear;
            }
        }
        public void AddAdult()
        {

            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into adults(Last_Name, First_Name, Home_Phone, Cell_Phone, Address, City, State, Zip_Code, Ward, Birth_Date, eContact_id)"
             + "values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

            //(Last_Name, First_Name, Home_Phone, Cell_Phone, Address, City, State, Zip_Code, Birth_Date)"//eContact_id)
            cmd.Parameters.Add("@lastName", OleDbType.VarChar).Value = lastName;
            cmd.Parameters.Add("@firstName", OleDbType.VarChar).Value = firstName;
            cmd.Parameters.Add("@homePhone", OleDbType.VarChar).Value = homePhone;
            cmd.Parameters.Add("@cellPhone", OleDbType.VarChar).Value = cellPhone;
            cmd.Parameters.Add("@address", OleDbType.VarChar).Value = address;
            cmd.Parameters.Add("@city", OleDbType.VarChar).Value = city;
            cmd.Parameters.Add("@state", OleDbType.VarChar).Value = state;
            cmd.Parameters.Add("@zipCode", OleDbType.VarChar).Value = zipCode;
            cmd.Parameters.Add("@wardID", OleDbType.VarChar).Value = wardID;
            cmd.Parameters.Add("@birthDate", OleDbType.VarChar).Value = birthDate;
            cmd.Parameters.Add("@emgContactID", OleDbType.VarChar).Value = emgContactID;  
          
            if (getNumIdentity2(sqlVariable, cmd) == true)//checks it getNumIdentity returns true
            {
                adultID = numIdentity;//then it assigns the retrieved @@IDENTITY //************change
            }
            //DataEntry(sqlVariable);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
            AddAssingmentInfo();//calls function in order to add assingment to adult
        }//end jose
            
        public void AddAssingmentInfo()
        {
            //Assingment_description
            connToDB.Open(); // THIS IS IMPORTANT
            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into assingments(Assingment_description)"
             + "values(?)";

          
            cmd.Parameters.Add("@assignmentDescription", OleDbType.VarChar).Value = assignmentDescription;
                

            if (getNumIdentity2(sqlVariable, cmd) == true)//checks it getNumIdentity returns true
            {
                assignID = numIdentity;//then it assigns the retrieved @@IDENTITY 
            }
            //DataEntry(sqlVariable);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
            AddAssingAdultLink();//calls function in order to add an assingment adult link

        }
        public void AddAssingAdultLink()
        {
            
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into adult_assingments_link(AdultID, AssingID, AssingYear)"
             + "values(?, ?, ?)";


            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
            cmd.Parameters.Add("@assignID", OleDbType.VarChar).Value = assignID;
            cmd.Parameters.Add("@Currentyear", OleDbType.VarChar).Value = Currentyear;
         

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
            
        }
        public void AddMedicalInfo()
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into adults_medical(adult_id, AsthmaYN, MedsYN, AllergiesYN)"
             + "values(?, ?, ?, ?)";


            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
            cmd.Parameters.Add("@asthmaYN", OleDbType.VarChar).Value = asthmaYN;
            cmd.Parameters.Add("@medsYN", OleDbType.VarChar).Value = medsYN;
            cmd.Parameters.Add("@allergyYN", OleDbType.VarChar).Value = allergyYN;
        

            if (getNumIdentity2(sqlVariable, cmd) == true)//checks it getNumIdentity returns true
            {
                medicalID = numIdentity;//then it assigns the retrieved @@IDENTITY 
            }
            //DataEntry(sqlVariable);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN 
            ADDLimitationsInfo();//calls function in order to add limitations info for adult

        }
        public void ADDLimitationsInfo()
        {
            string sqlVariable;
            connToDB.Open(); // THIS IS IMPORTANT

            for (int i = 0; i < limitDescription.Length; i++)
            {
                OleDbCommand cmd = connToDB.CreateCommand();
                //MessageBox.Show(limitDescription[i]);//test
                sqlVariable = "Insert into adult_limitations(adult_id, Description)"
                 + "values(?, ?)";

                //customer_level_link(Customer_id, [Level], LevelYear)
                cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
                //cmd.Parameters.Add("@limitation", OleDbType.VarChar).Value = limitation;
                cmd.Parameters.Add("@limitDescription", OleDbType.VarChar).Value = limitDescription[i];

                if (getNumIdentity2(sqlVariable, cmd) == true)//checks it getNumIdentity returns true
                {
                    limitationsID = numIdentity;//then it assigns the retrieved @@IDENTITY 
                }
                //DataEntry(sqlVariable);//calls function in order to enter data into database
            }
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN    
        }
        public void AddEmergencyContactInfo()//start jose
        {
            connToDB.Open(); // THIS IS IMPORTANT
            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into emergency_contact(First_Name, Last_Name, Phone, Relationship)"
             + "values(?, ?, ?, ?)";
           
            cmd.Parameters.Add("@emgFirstName", OleDbType.VarChar).Value = emgFirstName;
            cmd.Parameters.Add("@emgLastName", OleDbType.VarChar).Value = emgLastName;
            cmd.Parameters.Add("@emgPhone", OleDbType.VarChar).Value = emgPhone;
            cmd.Parameters.Add("@emgRelationship", OleDbType.VarChar).Value = emgRelationship;
                     

            if (getNumIdentity2(sqlVariable,cmd) == true)//checks it getNumIdentity returns true
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
            AddEnrollAdultLink();//calls function in order to add an enrollment adult link
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
        public void AddEnrollAdultLink()
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;
            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into enrollment_adult_link(EnrollmentID, adultID, Enroll_Year)"
             + "values(?, ?, ?)";
                       

            cmd.Parameters.Add("@enrollID", OleDbType.VarChar).Value = enrollID;
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
            cmd.Parameters.Add("@Currentyear", OleDbType.VarChar).Value = Currentyear;
           
        
            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN

        }  
        public void GetAdult(string id)//fixed
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            int myParsedInt2 = Int32.Parse(id);
            adultID = Convert.ToInt32(id);

            comm.CommandText = "Select * from adults where Adult_ID = " +
                  adultID;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                lastName = table.Rows[0]["Last_Name"].ToString();//[1]
                firstName = table.Rows[0]["First_Name"].ToString();//[2]               
                homePhone = table.Rows[0]["Home_Phone"].ToString();
                cellPhone = table.Rows[0]["Cell_Phone"].ToString();
                email = table.Rows[0]["Email"].ToString();
                address = table.Rows[0]["Address"].ToString();
                city = table.Rows[0]["City"].ToString();
                state = table.Rows[0]["State"].ToString();
                zipCode = table.Rows[0]["Zip_Code"].ToString();
                wardID = table.Rows[0]["Ward"].ToString();
                birthDate = table.Rows[0]["Birth_Date"].ToString();
                string temp = table.Rows[0]["eContact_id"].ToString();
                int myParsedInt = Int32.Parse(temp);
                emgContactID = Convert.ToInt32(temp);
                GetEmcontact();
                GetAdultMedical();
                GetAdultsAssignlink();
                GetAEnrollLink();
                GetAdultNestlink();
                GetAdultTransLink();
            }
        }

        public void GetEmcontact()//fixed
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
            else//***********new 05/18 *************
            {
                emgFirstName = "";
                emgLastName = "";
                emgPhone = "";
                emgRelationship = "";  
            }

        }
        public void GetAdultMedical()//fixed
        {

            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from adults_medical where adult_id = " +
                  adultID;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                asthmaYN = table.Rows[0]["AsthmaYN"].ToString();//[1]
                medsYN = table.Rows[0]["MedsYN"].ToString();//[2]               
                allergyYN = table.Rows[0]["AllergiesYN"].ToString();
            }
            else//***********new 05/18 *************
            {
                asthmaYN = "";
                medsYN = "";
                allergyYN = "";

            }
            GetAdultLimitations();

        }
        public void GetAdultLimitations()//fixed
        {
            string sqlVariable = "Select * from adult_limitations where adult_id = " +
                      adultID;


            int i = 0;
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = sqlVariable;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            limitDescription = new string[table.Rows.Count];
            limitationsArray = new int[table.Rows.Count];
            if (table.Rows.Count > 0)
            {
                do
                {
                    if (table.Rows.Count > 0)//might take it out later
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
            else//***********new 05/18 *************
            {
                limitDescription[i] = "";
            }

        }
        public void GetAdultsAssignlink()//fixed
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from adult_assingments_link where AdultID = ? and AssingYear=?";
            
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@adultID";
            param.DbType = DbType.String;
            param.Value = adultID;
            comm.Parameters.Add(param);

            DbParameter param2 = comm.CreateParameter();//last year
            param2.ParameterName = "@Currentyear";
            param2.DbType = DbType.String;
            param2.Value = Currentyear;
            comm.Parameters.Add(param2);
                 
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                string temp = table.Rows[0]["AssingID"].ToString();
                int myParsedInt = Int32.Parse(temp);
                assignID = Convert.ToInt32(temp);

                string temp2 = table.Rows[0]["AssingYear"].ToString();
                int myParsedInt2 = Int32.Parse(temp2);
                assignYear = Convert.ToInt32(temp2);
                getAssignments();
            }
            else//***********new 05/18 *************
            {
                assignmentDescription = "";

            }
            

        }
        public void GetAssingArray()//05/23
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from adult_assingments_link where AdultID = ?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@adultID";
            param.DbType = DbType.String;
            param.Value = adultID;
            comm.Parameters.Add(param);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            assignArray = new int[table.Rows.Count];

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < assignArray.Length; i++)
                {
                    string temp = table.Rows[i]["AssingID"].ToString();
                    int myParsedInt = Int32.Parse(temp);
                    assignArray[i] = Convert.ToInt32(temp);
                }
            }          
        }

        public void getAssignments()//fixed
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from assingments where Assing_ID = " +
                  assignID;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                assignmentDescription = table.Rows[0]["Assingment_description"].ToString();
            }
            else//***********new 05/18 *************
            {
                assignmentDescription = "";

            }
        }       
        public void GetAEnrollLink()//fixed
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from enrollment_adult_link where adultID = ? and Enroll_Year = ?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@adultID";
            param.DbType = DbType.String;
            param.Value = adultID;
            comm.Parameters.Add(param);

            DbParameter param2 = comm.CreateParameter();//last year
            param2.ParameterName = "@Currentyear";
            param2.DbType = DbType.String;
            param2.Value = Currentyear;
            comm.Parameters.Add(param2);

                
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                string temp1 = table.Rows[0]["EnrollmentID"].ToString();//[1]
                int myParsedInt = Int32.Parse(temp1);
                enrollID = Convert.ToInt32(temp1);
                string temp2 = table.Rows[0]["Enroll_Year"].ToString();//[2] 
                int myParsedInt2 = Int32.Parse(temp2);
                enrollYear = Convert.ToInt32(temp2);
                GetAEnrollment();
            }
            else//***********new 05/18 *************
            {
                recievedRegistration = "";
                recievedEmergencyConcent = "";
                recievedMedicalForm = "";
                recievedPayment = "";
                enrollComments = "";

            }       

        }
        public void GetEnrollIDArray()//********* new 05/23 *****************
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from enrollment_adult_link where adultID = ?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@adultID";
            param.DbType = DbType.String;
            param.Value = adultID;
            comm.Parameters.Add(param);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            enrollArray = new int[table.Rows.Count];

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < enrollArray.Length; i++)
                {

                    string temp1 = table.Rows[i]["EnrollmentID"].ToString();//[1]
                    int myParsedInt = Int32.Parse(temp1);
                    enrollArray[i] = Convert.ToInt32(temp1);                    
                }

            }
        }
        public void GetAEnrollment()//fixed
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "SELECT * " +
                "FROM enrollment " +
                "where Enroll_ID = ? ";               

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@enrollID";
            param.DbType = DbType.String;
            param.Value = enrollID;
            comm.Parameters.Add(param);     
           
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                recievedRegistration = table.Rows[0]["Recieved_Registration"].ToString();//[1]
                recievedEmergencyConcent = table.Rows[0]["Recieved_Emg_Consent"].ToString();//[2]               
                recievedMedicalForm = table.Rows[0]["Recieved_Medical_Form"].ToString();
                recievedPayment = table.Rows[0]["Recieved_Payment"].ToString();
                enrollComments = table.Rows[0]["Comments"].ToString();
            }
            else//***********new 05/18 *************
            {
                recievedRegistration = "";
                recievedEmergencyConcent = "";
                recievedMedicalForm = "";
                recievedPayment = "";
                enrollComments = "";

            }
        }
        public void GetAdultNestlink()//fixed
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from adult_nest_link where AdultID = " +
                  adultID;
            
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                string temp1 = table.Rows[0]["Nest_id"].ToString();
                int myParsedInt = Int32.Parse(temp1);
                nestID = Convert.ToInt32(temp1);
                GetNest();
            }

            else//***********new 05/18 *************
            {
                nestName = "";
            }
            
         
        }       
      
        public void GetAdultTransLink()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from adult_transportation_link where Adult_id = ? and trans_year=? ";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@adultID";
            param.DbType = DbType.String;
            param.Value = adultID;
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
                string temp2 = table.Rows[0]["trans_year"].ToString();
                int myParsedInt2 = Int32.Parse(temp2);
                tripYear = Convert.ToInt32(temp2);
                GetTransportation();
            }
            else//***********new 05/18 *************
            {
                transportationType = "";
            }
            
            

        }
        //public void GetTransportation()//take it out later
        //{
        //     DbCommand comm = GenericDataAccess.CreateCommand();
        //     comm.CommandText = "Select * from transportation where Transportation_id = " +
        //          transportID;
        //    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

        //    if (table.Rows.Count > 0)
        //    {
        //        transportationType = table.Rows[0]["Transportation"].ToString();              
        //    }

        //}
        //VEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEAVEA

        //*******************UPDATE ADULT************************************************
        public void updateAdult()//VEA BEGIN//******works**********
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update adults Set Last_Name=?, First_Name=?, Home_Phone=?, Cell_Phone=?, Email =? , Address=?, City=?, State=?, Zip_Code=?, Birth_Date=? Where Adult_ID=?";

            //(Last_Name, First_Name, Home_Phone, Cell_Phone, Address, City, State, Zip_Code, Birth_Date"//eContact_id)
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
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
                     
            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database          

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
            updateAssingAdultLink();
        }//VEA END
        //*******************************************************************************

        //*******************DELETE ADULT************************************************
        public void deleteAdult()//VEA BEGIN
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from adults Where Adult_ID=?";
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
          

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }//VEA END
        //*******************************************************************************

        //*******************UPDATE GUARDIAN*********************************************
        //public void updateGuardianAdult()//VEA BEGIN
        //{
        //    connToDB.Open(); // THIS IS IMPORTANT

        //    string sqlVariable;

        //    OleDbCommand cmd = connToDB.CreateCommand();

        //    sqlVariable = "Update adults Set Last_Name=?, First_Name=?, Home_Phone=?, Cell_Phone=?, Address=?, City=?, State=?, Zip_Code=? Where Adult_ID=?";

        //    //(Last_Name, First_Name, Home_Phone, Cell_Phone, Address, City, State, Zip_Code)
        //    cmd.Parameters.Add("@lastName", OleDbType.VarChar).Value = lastName;
        //    cmd.Parameters.Add("@firstName", OleDbType.VarChar).Value = firstName;
        //    cmd.Parameters.Add("@homePhone", OleDbType.VarChar).Value = homePhone;
        //    cmd.Parameters.Add("@cellPhone", OleDbType.VarChar).Value = cellPhone;
        //    cmd.Parameters.Add("@address", OleDbType.VarChar).Value = address;
        //    cmd.Parameters.Add("@city", OleDbType.VarChar).Value = city;
        //    cmd.Parameters.Add("@state", OleDbType.VarChar).Value = state;
        //    cmd.Parameters.Add("@zipCode", OleDbType.VarChar).Value = zipCode;

        //    DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

        //    connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN

        //}// VEA END
        //*******************************************************************************

        ////*******************DELETE GUARDIAN*********************************************
        //public void deleteGuardianAdult()
        //{
        //    connToDB.Open(); // THIS IS IMPORTANT

        //    string sqlVariable;

        //    OleDbCommand cmd = connToDB.CreateCommand();

        //    sqlVariable = "Delete from adults Where Adult_ID=?";

        //    //(Last_Name, First_Name, Home_Phone, Cell_Phone, Address, City, State, Zip_Code)
        //    cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
        //    cmd.Parameters.Add("@lastName", OleDbType.VarChar).Value = lastName;
        //    cmd.Parameters.Add("@firstName", OleDbType.VarChar).Value = firstName;
        //    cmd.Parameters.Add("@homePhone", OleDbType.VarChar).Value = homePhone;
        //    cmd.Parameters.Add("@cellPhone", OleDbType.VarChar).Value = cellPhone;
        //    cmd.Parameters.Add("@address", OleDbType.VarChar).Value = address;
        //    cmd.Parameters.Add("@city", OleDbType.VarChar).Value = city;
        //    cmd.Parameters.Add("@state", OleDbType.VarChar).Value = state;
        //    cmd.Parameters.Add("@zipCode", OleDbType.VarChar).Value = zipCode;

        //    DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

        //    connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        //}

        //private void DataEntry2(string sqlVariable)
        //{
        //    throw new NotImplementedException();
        //}// VEA END
        //*******************************************************************************

        //*******************UPDATE ASSIGNMENT INFORMATION*******************************
        public void updateAssignmentInfo()//VEA BEGIN//works
        {
            //Assingment_description
            connToDB.Open(); // THIS IS IMPORTANT
            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update assingments Set Assingment_description=? Where Assing_ID=?";          

            cmd.Parameters.Add("@assignmentDescription", OleDbType.VarChar).Value = assignmentDescription;
            cmd.Parameters.Add("@assignID", OleDbType.VarChar).Value = assignID;  

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }//VEA END
        //*******************************************************************************

        //*******************DELETE ASSIGNMENT INFORMATION*******************************
        public void deleteAssignmentInfo()
        {
            //Assingment_description
            connToDB.Open(); // THIS IS IMPORTANT
            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from assingments Where Assing_ID=?";
            cmd.Parameters.Add("@assignID", OleDbType.VarChar).Value = assignID;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }
        //*******************************************************************************

        //*******************UPDATE ASSIGNMENT ADULT LINK********************************
        public void updateAssingAdultLink()//VEA BEGIN//works
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update adult_assingments_link Set AssingID=? Where AssingYear=? and AdultID=?";

            cmd.Parameters.Add("@assignID", OleDbType.VarChar).Value = assignID;                     
            cmd.Parameters.Add("@Currentyear", OleDbType.VarChar).Value = Currentyear;
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;            

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
            updateAssignmentInfo();
        }//VEA END
        //*******************************************************************************

        //*******************DELETE ASSIGNMENT ADULT LINK********************************
        public void deleteAssingAdultLink()
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from adult_assingments_link Where AdultID =?"; 
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;  

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
            //deleteAssignmentInfo();
        }
        //*******************************************************************************

        //*******************UPDATE MEDICAL INFORMATION**********************************
        public void updateMedicalInfo()//VEA BEGIN//fixed
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update adults_medical Set adult_id=?, AsthmaYN=?, MedsYN=?, AllergiesYN=? Where adult_id=?";

            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
            cmd.Parameters.Add("@asthmaYN", OleDbType.VarChar).Value = asthmaYN;
            cmd.Parameters.Add("@medsYN", OleDbType.VarChar).Value = medsYN;
            cmd.Parameters.Add("@allergyYN", OleDbType.VarChar).Value = allergyYN;
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN 
        }// VEA END
        //*******************************************************************************

        //*******************DELETE MEDICAL INFORMATION**********************************
        public void deleteMedicalInfo()//VEA BEGIN
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from adults_medical Where adult_id=?";

            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;           

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN 
        }
        //*******************************************************************************

        //*******************UPDATE LIMITATIONS INFORMATION******************************
        public void updateLimitationsInfo()//VEA BEGIN//fixed
        {
            connToDB.Open(); // THIS IS IMPORTANT
            string sqlVariable;
            sqlVariable = "Update adult_limitations Set Description=? Where adult_id=?";

            for (int i = 0; i < limitDescription.Length; i++)
            {

                OleDbCommand cmd = connToDB.CreateCommand();

                cmd.Parameters.Add("@limitDescription", OleDbType.VarChar).Value = limitDescription[i];
                cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;              
                DataEntry2(sqlVariable, cmd);
            }  
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }//VEA END
        //*******************************************************************************

        //*******************DELETE LIMITATIONS INFORMATION******************************
        public void deleteLimitationsInfo()//VEA BEGIN
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from adult_limitations Where adult_id=?";           
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
          

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }//VEA END
        //*******************************************************************************

        //*******************UPDATE EMERGENCY CONTACT INFORMATION************************
        public void updateEmergencyContactInfo()//VEA BEGIN//fixed
        {
            connToDB.Open(); // THIS IS IMPORTANT
            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update emergency_contact Set First_Name=?, Last_Name=?, Phone=?, Relationship=? Where Emergency_contactID=?";

            cmd.Parameters.Add("@emgFirstName", OleDbType.VarChar).Value = emgFirstName;
            cmd.Parameters.Add("@emgLastName", OleDbType.VarChar).Value = emgLastName;
            cmd.Parameters.Add("@emgPhone", OleDbType.VarChar).Value = emgPhone;
            cmd.Parameters.Add("@emgRelationship", OleDbType.VarChar).Value = emgRelationship;
            cmd.Parameters.Add("@emgContactID", OleDbType.VarChar).Value = emgContactID;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }//VEA END
        //*******************************************************************************

        //*******************DELETE EMERGENCY CONTACT INFORMATION************************
        public void deleteEmergencyContactInfo()//VEA BEGIN
        {
            connToDB.Open(); // THIS IS IMPORTANT
            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from emergency_contact Where Emergency_contactID=?";
            cmd.Parameters.Add("@emgContactID", OleDbType.VarChar).Value = emgContactID;
           

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }//VEA END
        //*******************************************************************************

        //*******************UPDATE REGISTRATION*****************************************
        public void updateRegistration()//VEA BEGIN//works
        {
            string sqlVariable;
            connToDB.Open(); // THIS IS IMPORTANT

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update enrollment Set Recieved_Registration=?, Recieved_Emg_Consent=?, Recieved_Medical_Form=?, Recieved_Payment=?, Comments=? Where Enroll_ID=?";

            //Recieved_Registration, Recieved_Emg_Consent, Recieved_Medical_Form, Recieved_Payment, Comments
            cmd.Parameters.Add("@recievedRegistration", OleDbType.VarChar).Value = recievedRegistration;
            cmd.Parameters.Add("@recievedEmergencyConcent", OleDbType.VarChar).Value = recievedEmergencyConcent;
            cmd.Parameters.Add("@recievedMedicalForm", OleDbType.VarChar).Value = recievedMedicalForm;
            cmd.Parameters.Add("@recievedPayment", OleDbType.VarChar).Value = recievedPayment;
            cmd.Parameters.Add("@enrollComments", OleDbType.VarChar).Value = enrollComments;
            cmd.Parameters.Add("@enrollID", OleDbType.VarChar).Value = enrollID;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN2
        }//VEA END
        //*******************************************************************************

        //*******************DELETE REGISTRATION*****************************************
        public void deleteRegistration()//VEA BEGIN
        {
            string sqlVariable;
            connToDB.Open(); // THIS IS IMPORTANT

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from enrollment Where Enroll_ID=?";
            cmd.Parameters.Add("@enrollID", OleDbType.VarChar).Value = enrollID;

            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database
            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }//VEA END
        //*******************************************************************************

        ////*******************UPDATE ENROLLMENT ADULT LINK********************************
        //public void updateEnrollAdultLink()//VEA BEGIN
        //{
        //    connToDB.Open(); // THIS IS IMPORTANT

        //    string sqlVariable;
        //    OleDbCommand cmd = connToDB.CreateCommand();

        //    sqlVariable = "Update enrollment_adult_link Set EnrollmentID=?, adultID=?  Where EnrollmentID=? and Enroll_Year=?";

        //    cmd.Parameters.Add("@enrollID", OleDbType.VarChar).Value = enrollID;
        //    cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
        //    cmd.Parameters.Add("@Currentyear", OleDbType.VarChar).Value = Currentyear;

        //    DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database
        //    connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        //}//VEA END
        ////*******************************************************************************

        //*******************DELETE ENROLLMENT ADULT LINK********************************
        public void deleteEnrollAdultLink()//VEA BEGIN
        {
            connToDB.Open(); // THIS IS IMPORTANT

            string sqlVariable;
            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from enrollment_adult_link Where adultID=?";
            
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;


            DataEntry2(sqlVariable, cmd);//calls function in order to enter data into database

            connToDB.Close(); // THIS IS MORE IMPORTAN THAN OPEN
        }//VEA END
        //*******************************************************************************

        //*******************ADD ADULT TRANSPORTATION LINK*******************************
        public void addAdultTransLink()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into adult_transportation_link(Transportation_id, Adult_id, trans_year)"
                + "values(?, ?, ?)";

            cmd.Parameters.Add("@transportID", OleDbType.VarChar).Value = transportID;
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
            cmd.Parameters.Add("@CurrentYear", OleDbType.VarChar).Value = Currentyear;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

        //*******************UPDATE TRANSPORTATION **************************************
        public void updateAdultTransLink()
        {
            //Transportation_id 1 = Bus 1
            //Transportation_id 2 = Bus 2
            //Transportation_id 3 = Vehicle

            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update adult_transportation_link Set Transportation_id=? Where Adult_id=? and trans_year=?";
            cmd.Parameters.Add("@transportID", OleDbType.VarChar).Value = transportID;
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
            cmd.Parameters.Add("@CurrentYear", OleDbType.VarChar).Value = Currentyear;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

        //*******************DELETE ADULT TRANSPORTATION LINK****************************
        public void deleteAdultTransLink()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from adult_transportation_link Where Adult_id=?";
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

     

        //*******************ADD ADULT NEST LINK*****************************************
        public void addAdultNestLink()
        {          
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into adult_nest_link(AdultID, Nest_id)"
               + "values(?, ?)";

            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
            cmd.Parameters.Add("@nestID", OleDbType.VarChar).Value = nestID;          

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

        //*******************DELETE ADULT NEST LINK**************************************
        public void deleteAdultNestLink()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from adult_nest_link where AdultID=?";
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        public void updatAdultNestLink()// VEA BEGIN
        {
            //MessageBox.Show(adultID.ToString());
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update adult_nest_link Set Nest_id=? Where AdultID=?";

            cmd.Parameters.Add("@nestID", OleDbType.VarChar).Value = nestID;
            cmd.Parameters.Add("@adultID", OleDbType.VarChar).Value = adultID;
          
            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

        public void GetAllAdultLinks()//left off 05/14
        {
            int oldYear = Currentyear - 1;
            DbCommand comm = GenericDataAccess.CreateCommand();           

            comm.CommandText = "SELECT Adult_ID "+
                "FROM adults INNER JOIN adult_assingments_link ON adults.Adult_ID = adult_assingments_link.AdultID "+
                "WHERE AssingYear = ?";

            DbParameter param3 = comm.CreateParameter();//last year
            param3.ParameterName = "@oldYear";
            param3.DbType = DbType.String;
            param3.Value = oldYear;
            comm.Parameters.Add(param3);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            int rowLength = table.Rows.Count;

            for (int i = 0; i < rowLength; i++)
            {
               
                string temp = table.Rows[i]["Adult_ID"].ToString();
                int myParsedInt = Int32.Parse(temp);
                adultID = Convert.ToInt32(temp);

                DbCommand cmd = GenericDataAccess.CreateCommand();
                cmd.CommandText = "Select * from adult_assingments_link where AdultID = ? and AssingYear = ?";

                DbParameter param = cmd.CreateParameter();
                param.ParameterName = "@adultID";
                param.DbType = DbType.String;
                param.Value = adultID;
                cmd.Parameters.Add(param);


                DbParameter param2 = cmd.CreateParameter();//last year
                param2.ParameterName = "@oldYear";
                param2.DbType = DbType.String;
                param2.Value = oldYear;
                cmd.Parameters.Add(param2);
                     
                DataTable table1 = GenericDataAccess.ExecuteSelectCommand(cmd);

                if (table1.Rows.Count > 0)
                {
                    string temp2 = table1.Rows[0]["AssingID"].ToString();
                    int myParsedInt2 = Int32.Parse(temp2);
                    assignID = Convert.ToInt32(temp2);
                    getAssignments();
                }              
               

                ////******************************************************
                ////insert into assignments table
                AddAssingmentInfo();
                ////insert into adult_assingments_links table
                //AddAssingAdultLink();
                ////maybe update the enrollment table to default state or insert
                DefaultRegistration();   
                ////insert into enroll_adult_link table
                AddEnrollAdultLink();
                ////******************************************************
                
             
            }

        }     

        //new
        public bool duplicateAdultValidation()
        {
            bool found = false;
            DbCommand comm = GenericDataAccess.CreateCommand();

            comm.CommandText = "Select * from adults where First_Name = ? and Last_Name = ?";

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
                string temp = table.Rows[0]["Adult_ID"].ToString();
                int myParsedInt = Int32.Parse(temp);
                adultID = Convert.ToInt32(temp);               
            }
            return found;

        } 
    }
}
