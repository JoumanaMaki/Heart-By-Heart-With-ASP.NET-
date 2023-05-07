using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.frontEnd
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (!IsValidEmail(email))
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Please enter a valid email address";
                return;
            }

            //check if email already exists in the database
            if (IsEmailExists(email))
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Email already exists. Please try another one";
                return;
            }

            //validate password strength
            if (!IsValidPassword(password))
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character";
                return;
            }
            // Get user input values
            string gender;
            if (RadioButton1.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            string username = txtUsername.Text;
          

            // Save user image to server
            string imageName = "";
            if (fileUpload.HasFile)
            {
                imageName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + fileUpload.FileName;
                fileUpload.SaveAs(Server.MapPath("images/" + imageName));
                fileUpload.SaveAs(Server.MapPath("../admin/images/" + imageName));
            }

            // Generate random OTP and send email to user
            string otp = GenerateOTP();
            SendOTPEmail(email, otp);

            // Store user input values and OTP in Session object
            Session["gender"] = gender;
            Session["email"] = email;
            Session["username"] = username;
            Session["password"] = password;
            Session["image"] = imageName;
            Session["otp"] = otp;



            // Redirect to OTP verification page
            Response.Redirect("~/frontEnd/VerifyOtp.aspx");
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
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

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8)
                return false;

            if (!password.Any(char.IsUpper))
                return false;

            if (!password.Any(char.IsLower))
                return false;

            if (!password.Any(char.IsDigit))
                return false;

            if (password.IndexOfAny("!@#$%^&*()_-+=[{]};:'\"\\|,.<>/?".ToCharArray()) == -1)
                return false;

            return true;
        }

        private string GenerateOTP()
        {
            // Generate a random 6-digit OTP
            Random random = new Random();
            int otpInt = random.Next(100000, 999999);
            return otpInt.ToString();
        }

        private void SendOTPEmail(string toEmail, string otp)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("heartbyheart0@gmail.com");
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = "Your OTP for account verification";
                mailMessage.Body = "Dear User,<br><br> Your OTP for account verification is: " + otp + "<br><br> Regards,<br> Your Website";
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("heartbyheart0@gmail.com", "mmyehkzhtvnpagfe");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Handle email sending exception here
            }
        }
    }
}