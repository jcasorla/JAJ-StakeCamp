using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;
using System.Windows.Forms;

namespace StakeCamp
{
    class ManageCamp : Camper
    {
        public string userid;//vea
        public string password;//vea
        public string newUserID;//vea
        public string newPassword;//vea

        //VVVVVVVVVVVVVVEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        public string Userid
        {
            set
            {
                userid = value;
            }
            get
            {
                return userid;
            }
        }
        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }
        public string NewUserID
        {
            set
            {
                newUserID = value;
            }
            get
            {
                return newUserID;
            }
        }
        public string NewPassword
        {
            set
            {
                newPassword = value;
            }
            get
            {
                return newPassword;
            }
        }
        //VVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAAA

        //*******************ADD WARD****************************************************

        public void addWard()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into wards(Ward)" + "values(?)";

            cmd.Parameters.Add("@wardID", OleDbType.VarChar).Value = wardID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }

        //*******************************************************************************

        //*******************UPDATE WARD*************************************************
        public void updateWard()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update wards Set Ward=? Where Ward=?";

            cmd.Parameters.Add("@wardID", OleDbType.VarChar).Value = wardID;
            cmd.Parameters.Add("@wardID", OleDbType.VarChar).Value = wardID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

        //*******************DELETE WARD*************************************************
        public void deleteWard()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from wards Where Ward=?";

            cmd.Parameters.Add("@wardID", OleDbType.VarChar).Value = wardID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }

        //*******************************************************************************

        //*******************INSERT INTO NEST********************************************
        public void insertNest()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Insert into nests(Nest_name, Description, NestYear)" + "values(?,?,?)";

            cmd.Parameters.Add("@nestName", OleDbType.VarChar).Value = nestName;
            cmd.Parameters.Add("@nestDescription", OleDbType.VarChar).Value = nestDescription;
            cmd.Parameters.Add("@Currentyear", OleDbType.VarChar).Value = Currentyear;
            //nest year = current year
            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

        //*******************UPDATE NEST*************************************************
        public void updateNest()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update nests Set Nest_name=? Where Nest_id=?";//, Description=?

            cmd.Parameters.Add("@nestName", OleDbType.VarChar).Value = nestName;
            //cmd.Parameters.Add("@nestDescription", OleDbType.VarChar).Value = nestDescription;
            cmd.Parameters.Add("@nestID", OleDbType.VarChar).Value = nestID;
            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

        //*******************DELETE NEST*************************************************
        public void deleteNest()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Delete from nests Where Nest_id=?";

            cmd.Parameters.Add("@nestID", OleDbType.VarChar).Value = nestID;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

        //*******************GET USER ID/PW**********************************************
        public void GetUserIDPW()//fixed
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "Select * from UserLogin";

            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            if (table.Rows.Count > 0)
            {
                userid = table.Rows[0]["User_id"].ToString();
                password = table.Rows[0]["Password"].ToString();
            }
        }
        //*******************************************************************************

        //*******************UPDATE USER ID**********************************************
        public void updateUserID()
        {
            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();

            sqlVariable = "Update UserLogin Set User_id=? where User_id=? ";

            cmd.Parameters.Add("@newUserID", OleDbType.VarChar).Value = newUserID;
            cmd.Parameters.Add("@userid", OleDbType.VarChar).Value = userid;


            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
        //*******************************************************************************

        //*******************UPDATE USER PASSWORD****************************************
        public void updateUserPW()
        {
            //MessageBox.Show("newPassword: " + newPassword);
            // MessageBox.Show("password: " + password);

            connToDB.Open();

            string sqlVariable;

            OleDbCommand cmd = connToDB.CreateCommand();
            // sqlVariable = "Update UserLogin Set User_id=? where User_id=? ";

            sqlVariable = "Update UserLogin Set [Password]=? Where [Password]=?";

            cmd.Parameters.Add("@newPassword", OleDbType.VarChar).Value = newPassword;
            cmd.Parameters.Add("@password", OleDbType.VarChar).Value = password;

            DataEntry2(sqlVariable, cmd);

            connToDB.Close();
        }
    }
}
