using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Meshwar.frontEnd
{
    public partial class ContactUs : System.Web.UI.Page
    {

        connection s = new connection();
        public String query, constr;
        public SqlConnection con;

        protected void Button2_Click(object sender, EventArgs e)
        {

            // create a new SmtpClient object
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(TextBox2.Text);
            mailMessage.To.Add(new MailAddress("heartbyheart0@gmail.com"));
            mailMessage.Subject = "Feedback From" + TextBox1.Text;
            mailMessage.Body = "<p><strong>Name:</strong> " + TextBox1.Text + "</p>" +
                   "<p><strong>Email:</strong> " + TextBox2.Text + "</p>" +
                   "<p><strong>Message:</strong></p>" +
                   "<p>" + TextBox3.Text + "</p>";
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;


            smtpClient.Credentials = new NetworkCredential("heartbyheart0@gmail.com", "mmyehkzhtvnpagfe");
            smtpClient.Send(mailMessage);

            // Show a success message to the user
            Response.Write("<script> alert('Message Sent Successfully')</script>");
            reset_form();
            // lblMessage.Text = "Thank you for your feedback!";
            //  string add;
            //  add = "insert into messages values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
            //  s.insert(add);
            //  Response.Write("<script> alert('Message Sent Successfully')</script>");
            // reset_form();
        }
        public void reset_form()
        {
            TextBox3.Text = "";
            TextBox2.Text = "";
            TextBox1.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      

     

      
        
    }
}