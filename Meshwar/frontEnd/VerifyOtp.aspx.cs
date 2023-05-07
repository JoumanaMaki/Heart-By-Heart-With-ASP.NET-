using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.frontEnd
{
    public partial class VerifyOtp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            // Get the email and OTP from the session
            string email = Session["email"].ToString();
            string otp = Session["otp"].ToString();

            // Check if the entered OTP matches the stored OTP
            if (txtOTP.Text == otp)
            {
                // If OTP is valid, insert user info into the database
                string username = Session["username"].ToString();
                string gender = Session["gender"].ToString();
                string password = Session["password"].ToString();
               
                string image = Session["image"].ToString();
                InsertUser(username, gender, email, password, image);
                Response.Write("<script> alert('User Created Successfully')</script>");

                // Redirect to the login page
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblError.Visible = true;
                // If OTP is invalid, show an error message
                lblError.Text = "Invalid OTP. Please try again.";
            }
        }

        private void InsertUser(string username, string gender, string email, string password, string image)
        {
            // Insert user info into the database
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True")
)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (username, gender, email, password, role, image, is_premium) VALUES (@username, @gender, @email, @password, @role, @image, @premium)");
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@premium", 1);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@role", 3);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}