using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BCrypt.Net;
namespace Meshwar.frontEnd
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string is_premium;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string hashedPassword = "";
            bool isValidUser = false;

            // Check if the email exists in the database
        //    string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT password, is_premium FROM users WHERE email=@Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        hashedPassword = reader["password"].ToString();
                        Session["is_premium"]= reader["is_premium"].ToString();
                        is_premium = reader["is_premium"].ToString();
                    }
                    reader.Close();
                }
                connection.Close();
            }

            // Compare the hashed password with the input password using BCrypt
            if (hashedPassword != "")
            {
                isValidUser = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }

            if (isValidUser)
            {
                // Set authentication cookie
                Response.Write("<script> alert('LogIn Sent Successfully')</script>");
                
                Response.Redirect("Articles.aspx");
            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Either the email or password is incorrect";

            }
        }
    }
}
     