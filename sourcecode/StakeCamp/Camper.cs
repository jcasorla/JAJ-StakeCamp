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
    public abstract class Camper
    {
        protected string lastName;
        protected string firstName;
        protected string homePhone;
        protected string cellPhone;
        protected string email;//added 5/5
        protected string address;
        protected string city;
        protected string state;
        protected string zipCode;
        protected string wardID;
        protected string birthDate;
        protected int medicalID;
        protected string asthmaYN;
        protected int limitationsID;
        protected int[] limitationsArray;//new 05 08
        protected string[] limitDescription; //jose       
        protected string allergyYN;
        protected string medsYN;
        protected string medsName;
        protected int nestID;
        protected int[] nestIDArray;
        protected string nestName;
        protected string[] nestNameArray;
        protected string nestDescription;
        protected string[] nestDescArray;
        protected int nestYear;
        protected int transportID;//{
        protected int tripYear;
        protected string transportationType;//}
        protected int enrollYear;//{
        protected int enrollID;
        protected int[] enrollArray;//*************new 05/22 ************
        protected string recievedRegistration;
        protected string recievedEmergencyConcent;
        protected string recievedMedicalForm;
        protected string recievedPayment;
        protected string enrollComments;//}        
        protected int emgContactID;//{
        protected string emgFirstName;
        protected string emgLastName;
        protected string emgPhone;
        protected string emgRelationship;//} 
        protected int numIdentity;//jose
        public OleDbConnection connToDB = new OleDbConnection(@GirlCampDBConfiguration.DbConnectionString);//jose
        public int Currentyear = DateTime.Now.Year;//code to retrieve the year from system
        public BindingSource bSource = new BindingSource();
        public DbCommand comm = GenericDataAccess.CreateCommand();
        public string sql;
        //public int numOfWorked;
        public bool didNotwork;

        public string LastName
        {
            set
            {
                lastName = value;
            }

            get
            {
                return lastName;
            }
        }
        public string FirstName
        {
            set
            {
                firstName = value;
            }

            get
            {
                return firstName;
            }
        }
        public string HomePhone
        {
            set
            {
                homePhone = value;
            }

            get
            {
                return homePhone;
            }
        }
        public string CellPhone
        {
            set
            {
                cellPhone = value;
            }

            get
            {
                return cellPhone;
            }
        }
        public string Email
        {
            set
            {
                email = value;
            }

            get
            {
                return email;
            }


        }
        public string Address
        {
            set
            {
                address = value;
            }

            get
            {
                return address;
            }
        }
        public string City
        {
            set
            {
                city = value;
            }

            get
            {
                return city;
            }
        }
        public string State
        {
            set
            {
                state = value;
            }

            get
            {
                return state;
            }
        }
        public string ZipCode
        {
            set
            {
                zipCode = value;
            }

            get
            {
                return zipCode;
            }
        }

        public string WardID//change back to string
        {
            set
            {
                wardID = value;
            }
            get
            {
                return wardID;
            }
        }

        public string BirthDate
        {
            set
            {
                birthDate = value;
            }
            get
            {
                return birthDate;
            }
        }

        public int MedicalID//start medical
        {
            set
            {
                medicalID = value;
            }
            get
            {
                return medicalID;
            }
        }

        public string AsthmaYN
        {
            set
            {
                asthmaYN = value;
            }
            get
            {
                return asthmaYN;
            }
        }

        public int LimitationsID
        {
            set
            {
                limitationsID = value;
            }
            get
            {
                return limitationsID;
            }
        }
        public int[] LimitationsArray//0508
        {
            set
            {
                limitationsArray = value;
            }
            get
            {
                return limitationsArray;
            }

        }

        public string[] LimitDescription//jose
        {
            set
            {
                limitDescription = value;
            }
            get
            {
                return limitDescription;
            }
        }

        public string AllergyYN
        {
            set
            {
                allergyYN = value;
            }
            get
            {
                return allergyYN;
            }
        }


        public string MedsYN
        {
            set
            {
                medsYN = value;
            }
            get
            {
                return medsYN;
            }
        }
        public string MedsName
        {
            set
            {
                medsName = value;
            }
            get
            {
                return medsName;
            }
        }//end medical
        public int NestID//start nest
        {
            set
            {
                nestID = value;
            }
            get
            {
                return nestID;
            }
        }
        public string NestName
        {
            set
            {
                nestName = value;
            }
            get
            {
                return nestName;
            }
        }
        public string NestDescription
        {
            set
            {
                nestDescription = value;
            }
            get
            {
                return nestDescription;
            }
        }
        public int NestYear
        {
            set
            {
                nestYear = value;
            }
            get
            {
                return nestYear;
            }
        }//end nest
        public int TransportID//start trip
        {
            set
            {
                transportID = value;
            }
            get
            {
                return transportID;
            }
        }
        public int TripYear
        {
            set
            {
                tripYear = value;
            }
            get
            {
                return tripYear;
            }
        }
        public string TransportationType
        {
            set
            {
                transportationType = value;
            }
            get
            {
                return transportationType;
            }
        }//end trip

        public int EnrollYear// start enroll
        {
            set
            {
                enrollYear = value;
            }
            get
            {
                return enrollYear;
            }
        }
        public int EnrollID
        {
            set
            {
                enrollID = value;
            }
            get
            {
                return enrollID;
            }

        }
        public int[] EnrollArray//*************new 05/22 ************
        {
            set
            {
                enrollArray = value;
            }
            get
            {
                return enrollArray;
            }


        }
        public string RecievedRegistration
        {
            set
            {
                recievedRegistration = value;
            }
            get
            {
                return recievedRegistration;
            }
        }
        public string RecievedEmergencyConcent
        {
            set
            {
                recievedEmergencyConcent = value;
            }
            get
            {
                return recievedEmergencyConcent;
            }
        }
        public string RecievedMedicalForm
        {
            set
            {
                recievedMedicalForm = value;
            }
            get
            {
                return recievedMedicalForm;
            }
        }

        public string RecievedPayment
        {
            set
            {
                recievedPayment = value;
            }
            get
            {
                return recievedPayment;
            }
        }


        public string EnrollComments
        {
            set
            {
                enrollComments = value;
            }
            get
            {
                return enrollComments;
            }
        } //end enroll

        public int EmgContactID//start contact
        {
            set
            {
                emgContactID = value;
            }
            get
            {
                return emgContactID;
            }
        }
        public string EmgFirstName
        {
            set
            {
                emgFirstName = value;
            }
            get
            {
                return emgFirstName;
            }
        }
        public string EmgLastName
        {
            set
            {
                emgLastName = value;
            }
            get
            {
                return emgLastName;
            }
        }
        public string EmgPhone
        {
            set
            {
                emgPhone = value;
            }
            get
            {
                return emgPhone;
            }
        }
        public string EmgRelationship
        {
            set
            {
                emgRelationship = value;
            }
            get
            {
                return emgRelationship;
            }
        }//end contact  
        protected int NumIdentity//jose
        {
            set
            {
                numIdentity = value;
            }
            get
            {
                return numIdentity;
            }
        }

        public void DataEntry2(string sqlVariable, OleDbCommand cmd)//this function executes sql statement
        {
            didNotwork = false;
            try
            {

                cmd.CommandText = sqlVariable;

                int numOfExcetution = cmd.ExecuteNonQuery(); // Return number of execution FYI if you want to use it you can get that number to assign it to variable


                if (numOfExcetution > 0)
                {                    
                    didNotwork = false;
                }
                else
                {
                    MessageBox.Show("HMMMM.... STRAAANGE");
                    didNotwork = true;

                }

            }
            catch (Exception theNameOfError)
            {

                MessageBox.Show(theNameOfError.Message);
                didNotwork = true;

            }


        }

        public bool getNumIdentity2(string sqlVariable, OleDbCommand cmd)//this function executes sql statementand retrieves @@IDENTITY
        {
            didNotwork = false;
            bool worked;

            try
            {
                cmd.CommandText = sqlVariable;

                // Return number of rows affected
                int numOfExcetution = cmd.ExecuteNonQuery();


                if (numOfExcetution > 0)
                {
                    cmd.CommandText = " SELECT @@IDENTITY ";
                    // return the identity value:
                    numIdentity = (int)cmd.ExecuteScalar();
                    worked = true;                   
                }
                else
                {
                    MessageBox.Show("HMMMM.... STRAAANGE");
                    worked = false;
                    didNotwork = true;
                }

            }
            catch (Exception theNameOfError)
            {

                MessageBox.Show(theNameOfError.Message);
                worked = false;
                didNotwork = true;
            }

            return worked;


        }    //end jose
        public void GetTransportation()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from transportation where Transportation_id = " +
                 transportID;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                transportationType = table.Rows[0]["Transportation"].ToString();
            }
            else
            {
                transportationType = "";
            }

        }
        public void GetNest()//fixed
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from nests where Nest_id = ? and NestYear = ?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@nestID";
            param.DbType = DbType.String;
            param.Value = nestID;
            comm.Parameters.Add(param);

            DbParameter param2 = comm.CreateParameter();//last year
            param2.ParameterName = "@Currentyear";
            param2.DbType = DbType.String;
            param2.Value = Currentyear;
            comm.Parameters.Add(param2);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                nestName = table.Rows[0]["Nest_name"].ToString();
                nestDescription = table.Rows[0]["Description"].ToString();
                string temp2 = table.Rows[0]["NestYear"].ToString();
                int myParsedInt2 = Int32.Parse(temp2);
                nestYear = Convert.ToInt32(temp2);
            }
            else
            {
                nestName = "";
            }

        }
        public void getWard()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from wards where Ward = ?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@wardID";
            param.DbType = DbType.String;
            param.Value = wardID;
            comm.Parameters.Add(param);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                wardID = table.Rows[0]["Ward"].ToString();
            }
        }

        ////*******************UPDATE TRANSPORTATION***************************************
        //public void updateTransportation()
        //{
        //    connToDB.Open();

        //    string sqlVariable;

        //    OleDbCommand cmd = connToDB.CreateCommand();

        //    sqlVariable = "Update transportation Set Transportation_id=? Where Transportation_id=?";

        //    cmd.Parameters.Add("@transportID", OleDbType.VarChar).Value = transportID;

        //    DataEntry2(sqlVariable, cmd);

        //    connToDB.Close();
        //}
        ////*******************************************************************************


        ////*******************DELETE TRANSPORTATION***************************************
        //public void deleteTransportation()
        //{
        //    connToDB.Open();

        //    string sqlVariable;

        //    OleDbCommand cmd = connToDB.CreateCommand();

        //    sqlVariable = "Delete from transportation Where Transportation_id=?, connToDB";

        //    cmd.Parameters.Add("@transportID", OleDbType.VarChar).Value = transportID;

        //    DataEntry2(sqlVariable, cmd);

        //    connToDB.Close();
        //}
        ////*******************************************************************************        

    }

}
