using AdminManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminManager.Context
{
    public class DBContext
    {
        public List<UserLoginModels> getAllUserLogin(){
            List<UserLoginModels> listULogin = new List<UserLoginModels>();
            string connString = ConfigurationManager.ConnectionStrings["stringCapstone"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Username, Passwords from Users",con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                UserLoginModels user = new UserLoginModels(rd.GetValue(0).ToString(), rd.GetValue(1).ToString());
                listULogin.Add(user);
            }
            con.Close();
            return listULogin;
        }
    }
}