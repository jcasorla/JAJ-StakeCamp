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
    public static class GenericDataAccess
    {
        static GenericDataAccess()
        {
        }

        //return a command object
        public static DbCommand CreateCommand()
        {
            string dataProviderName =
                GirlCampDBConfiguration.DbProviderName;
            string connectionString =
                GirlCampDBConfiguration.DbConnectionString;
            DbProviderFactory factory =
                DbProviderFactories.GetFactory(dataProviderName);

            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = connectionString;

            DbCommand comm = conn.CreateCommand();

            comm.CommandType = CommandType.Text;

            return comm;

        }


        public static DataTable ExecuteSelectCommand(DbCommand command)//returns record set
        {
            DataTable table;
            try
            {
                command.Connection.Open();
                DbDataReader reader = command.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
            return table;
        }

        //update, delete, insert

        public static int ExecuteNonQuery(DbCommand command)
        {
            int affectedRows = -1;
            try
            {
                command.Connection.Open();
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();

            }
            return affectedRows;
        }

        public static string ExecuteScalar(DbCommand command)
        {
            string value = "";
            try
            {
                command.Connection.Open();
                value = command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
            return value;
        }
    }//end class
}
