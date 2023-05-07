using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.admin
{
    public partial class Edit_domain : System.Web.UI.Page
    {
        connection s = new connection();
        public string query, constr, id;
        public string src, doctorId;

        protected void txtReset_Click(object sender, EventArgs e)
        {
            txtDomain.Text = " ";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            con.Open();
       
            SqlCommand cmd = new SqlCommand("update domains set domain = '" + txtDomain.Text + "' where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            con.Close();
            Response.Write("<script> alert('Domain updated Successfully')</script>");
            txtDomain.Text = " ";

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["ID"];
            if (!IsPostBack)
            {
                // Retrieve the ID from the query string
                string id = Request.QueryString["ID"];

                SqlCommand cmd1 = new SqlCommand("SELECT * FROM domains WHERE Id = @Id", con);
                cmd1.Parameters.AddWithValue("@Id", id);
                // Execute the command and retrieve the data
                con.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {

                    txtDomain.Text = reader1["domain"].ToString();


                }

                reader1.Close();
                con.Close();
            }
        }
    }
}