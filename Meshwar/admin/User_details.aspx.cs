using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.admin
{
    public partial class User_details : System.Web.UI.Page
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
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Id = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role = "null";
                                if (reader["role"].ToString() == "1")
                                {
                                    role = "Super Admin";
                                }
                                else if(reader["role"].ToString() == "2")
                                {
                                    role = "Admin";
                                }
                                else
                                {
                                    role = "User";
                                }
                                string gender = "null";
                                if (reader["gender"].ToString() == "Male")
                                {
                                    gender = "Male";
                                }
                                else
                                {
                                    gender = "Female";
                                }
                                // Set the values for the labels and image control

                                lblFirstName.Text = reader["username"].ToString();
                                
                                lbEmail.Text = reader["email"].ToString();
                                lbRole.Text = role;
                                lbGender.Text = gender;
                                // Set values for any additional fields here
                                image = reader["image"].ToString();
                                Image1.ImageUrl = "images/" + image;
                            }
                        }
                    }
                }
            }
        }
    }

}
    


