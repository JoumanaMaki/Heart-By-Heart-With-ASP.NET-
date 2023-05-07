using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Meshwar { 
    public class connection
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");


        public void insert(string s)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close(); 
        }
        public SqlDataReader viewAll(string s) { 
            con.Open();
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }


    }

}