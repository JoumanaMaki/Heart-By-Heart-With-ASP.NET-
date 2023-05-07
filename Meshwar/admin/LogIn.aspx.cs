using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Meshwar.admin
{
    public partial class LogIn : System.Web.UI.Page
    {
        connection s = new connection();

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string hashedPassword = "";
            bool isValidUser = false;

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * FROM users WHERE email = @email", con);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string id = reader["Id"].ToString();
                 hashedPassword = reader["password"].ToString();
                string  name = reader["username"].ToString();
                string role = reader["role"].ToString();
           

                if (hashedPassword != "")
                {
                    isValidUser = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                }

                if (isValidUser)
                {
                   

                    Session["LoggedIn"] = true;
                    Session["UserId"] = id;
                    Session["UserName"] = name;
                    Session["role"] = role;
                    string url = "index.aspx?Id=" + id + "&name=" + name ;

                    Response.Redirect(url);
                }
                else
                {
                    lbmessage.Text = "The password is incorrect";
                }
            }
            else
            {
                lbmessage.Text = "The email does not exist";

            }
            con.Close();
        }
    }
}