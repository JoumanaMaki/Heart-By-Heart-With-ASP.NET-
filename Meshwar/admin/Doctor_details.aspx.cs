using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Meshwar.admin
{
    public partial class Doctor_details : System.Web.UI.Page
    {
        public int id;
        public string filename;
        string idString, image;
        connection s = new connection();
        public string query, constr;
        public string src, doctorId;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the ID from the query string
                string id = Request.QueryString["ID"];

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True"))
                {
                    con.Open();
                    // Retrieve the main data using the first connection object
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM info WHERE Id = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string speciality = "";
                                // Retrieve the additional data using a second connection object
                                using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True"))
                                {
                                    con1.Open();
                                    using (SqlCommand cmd1 = new SqlCommand("SELECT domain FROM domains where Id=@Id", con1))
                                    {
                                        cmd1.Parameters.AddWithValue("@Id", reader["speciality"].ToString());
                                        using (SqlDataReader reader1 = cmd1.ExecuteReader())
                                        {
                                            if (reader1.Read())
                                            {
                                                speciality = reader1["domain"].ToString();
                                            }
                                        }
                                    }
                                }
                                // Set the values for the labels and image control
                                Label1.Text = "Dr. " + reader["firstname"].ToString() + " " + reader["lastname"].ToString();
                                lblId.Text = reader["Id"].ToString();
                                lblFirstName.Text = reader["firstname"].ToString();
                                lblLastName.Text = reader["lastname"].ToString();
                                lbphoneNumber.Text = reader["phone"].ToString();
                                lbEmail.Text = reader["Email"].ToString();
                                lbAddress.Text = reader["address"].ToString();
                                lbSpeciality.Text = speciality;
                                // Set values for any additional fields here
                                image = reader["image"].ToString();
                                lbgender.Text = reader["gender"].ToString();
                                Image1.ImageUrl = image;
                            }
                        }
                    }
                }
            }
        }
    }
}
    
