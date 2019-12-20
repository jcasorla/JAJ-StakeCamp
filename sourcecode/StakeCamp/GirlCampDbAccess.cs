using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
//using System.Data.OleDb;
using System.Configuration;

namespace StakeCamp
{
    public struct Customer
    {
        public string FirstName;
        public string LastName;
    }

    public struct UserLogin
    {
        public string UserId;
        public string Password;
    }


    public static class GirlCampDbAccess
    {
        public static Customer GetCustomer(string custID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from Customers where customerID = " +
                custID;
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            Customer details = new Customer();
            if (table.Rows.Count > 0)
            {
                details.FirstName = table.Rows[0]["First_name"].ToString();
                details.LastName = table.Rows[0]["Last_name"].ToString();
            }
            return details;
        }

        public static UserLogin GetUserLogin(string userid, string password)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from UserLogin where User_id =?";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@userid";
            param.DbType = DbType.String;
            param.Value = userid;
            comm.Parameters.Add(param);

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            UserLogin details = new UserLogin();
            if (table.Rows.Count > 0)
            {
                details.UserId  = table.Rows[0]["User_id"].ToString();
                details.Password = table.Rows[0]["Password"].ToString();
            }
            return details;
        }

        public static int InsertIntoNests(string name, string discription)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Insert into nests(Nest_name, Description) values(@name, @discription)";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@name";
            param.DbType = DbType.String;
            param.Value = name;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@discription";
            param.DbType = DbType.String;
            param.Value = discription;
            comm.Parameters.Add(param);


            int results = -1;
            try
            {
                results = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return results;


        }

        public static DataTable GetNestRecords()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from nests";
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            return table;
        }
    }
}
