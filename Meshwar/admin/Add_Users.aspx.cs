using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.admin
{
    public partial class Add_Users : System.Web.UI.Page
    {

        string path;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionValue = Session["role"] as string; // Get session variable value as a string

            if (String.Equals(sessionValue, "1", StringComparison.OrdinalIgnoreCase))
            {
                // User is authorized to access this page
            }
            else
            {
                // User is not authorized to access this page
                
                Response.Redirect("index.aspx?msg=As an admin you are not authorized to access this page. Please contact your super Admin!");
                Response.Write("<script>alert('You are not allowed to access this page.');</script>");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get the input values from the form
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string gender;
            if (RadioButton1.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            // Check if the file upload control has a file
            if (FileUpload1.HasFile)
            {
                // Get the file name and extension

                string fileExtension = Path.GetExtension(FileUpload1.FileName);

                // Check if the file extension is valid
                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".png")
                {
                    // Generate a random number to append to the file name
                    Random rnd = new Random();
                    int number = rnd.Next(1, 13);

                    // Save the file to the server
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                    string newFileName = fileNameWithoutExtension + number + fileExtension;
                    FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "admin/images/" + newFileName);
                    

                    path = newFileName;

                    // Save the file to the images folder
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("images/") + newFileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("../frontEnd/images/") + newFileName);
                
            }
                else
                {
                    // Invalid file extension
                    Response.Write("<script>alert('Invalid file type. Please upload an image file.')</script>");
                    return;
                }
            }

            // Check if the email already exists in the database
            if (IsEmailExists(email))
            {
                // Email already exists
                Response.Write("<script>alert('Email already exists. Please use a different email.')</script>");
                return;
            }

            // Check if the password is valid
            if (!IsPasswordValid(password))
            {
                // Invalid password
                Response.Write("<script>alert('Invalid password. Password should be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number.')</script>");
                return;
            }

            // Hash the password using bcrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Insert the data to the database
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");
            string query = "INSERT INTO users (username, email, password,role, gender, image, is_premium) VALUES (@Username, @Email, @Password,@Role, @Gender, @Photo, @Premium)";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", hashedPassword);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Role","2");
            command.Parameters.AddWithValue("@Photo", path);
            command.Parameters.AddWithValue("@Premium", 1);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();

            // Show a success message
            Response.Write("<script>alert('User added successfully.')</script>");
            reset();
        }

        private bool IsEmailExists(string email)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");

            string query = "SELECT COUNT(*) FROM users WHERE email = @Email";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            connection.Open();
            int count = (int)command.ExecuteScalar();
            connection.Close();
            return count > 0;
        }

        private bool IsPasswordValid(string password)
        {
            // Password should be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
            return regex.IsMatch(password);


        }
        protected void reset()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
        }
        protected void txtReset_Click(object sender, EventArgs e)
        {
            reset();

        }
    }
}