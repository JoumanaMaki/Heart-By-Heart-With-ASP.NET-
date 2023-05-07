using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.admin
{
    public partial class Add_Domains : System.Web.UI.Page
    {

        connection s = new connection();
        protected void Page_Load(object sender, EventArgs e)
        {


            string sessionValue = Session["role"] as string; // Get session variable value as a string

            if (String.Equals(sessionValue, "1", StringComparison.OrdinalIgnoreCase))
            {
                // User is authorized to access this page
            }
            else if (String.Equals(sessionValue, "2", StringComparison.OrdinalIgnoreCase))
            { 
            
            }

            else
            {
                // User is not authorized to access this page

                Response.Redirect("index.aspx?msg=As an admin you are not authorized to access this page. Please contact your super Admin!");
                Response.Write("<script>alert('You are not allowed to access this page.');</script>");
            }
        }
    

        protected void txtReset_Click(object sender, EventArgs e)
        {
            txtDomain.Text = " ";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String add;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");

            // Check if the domain already exists
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM domains WHERE domain = @domain_name", conn);
            cmd.Parameters.AddWithValue("@domain_name", txtDomain.Text);
            conn.Open();
            int domainCount = (int)cmd.ExecuteScalar();
            conn.Close();

            if (domainCount > 0)
            {
                // Domain already exists, show error message
                Response.Write("<script> alert('Domain already exists')</script>");
            }
            else
            {
                // Domain doesn't exist, insert into database
                add = "insert into domains values('" + txtDomain.Text + "')";
                s.insert(add);
                Response.Write("<script> alert('Domain Added Successfully')</script>");
                txtDomain.Text = " ";
            }

        }
    }
}