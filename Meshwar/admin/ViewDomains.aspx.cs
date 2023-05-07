using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.admin
{
    public partial class ViewDomains : System.Web.UI.Page
    {
        connection s = new connection();
        public string query, constr, speciality;
        public string src;



        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");


        protected void Page_Load(object sender, EventArgs e)
        {

            string sessionValue = Session["role"] as string; // Get session variable value as a string

            if (String.Equals(sessionValue, "1", StringComparison.OrdinalIgnoreCase) || String.Equals(sessionValue, "2", StringComparison.OrdinalIgnoreCase))
            {
                con.Open();


                query = "SELECT * FROM domains ";







                // Step 2: Write an SQL query to retrieve the data

                // Step 3: Execute the SQL query
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                // Step 4: Bind the data to a DataTable or a List
                DataTable dt = new DataTable();
                dt.Load(reader);

                // Step 5: Create the Bootstrap table
                // Step 5: Create the Bootstrap table
                string html = "<table class='table table-hover  table-bordered'>";
                html += "<thead class='thead-dark'><tr><th>Name</th> <th>Edit</th> <th>Delete</th></tr></thead>";
                html += "<tbody>";

                // Step 6: Populate the Bootstrap table
                foreach (DataRow row in dt.Rows)
                {
                    

                    html += "<tr>";
                    html += "<td>" + row["domain"].ToString() + "</td>";
                    html += "<td><a href='Edit_domain.aspx?ID=" + row["Id"].ToString() + "'>  <img src ='images/edit.png'  style='width: 30px; height: 30px;'/></a></td>";
                    html += "<td><a href='Delete_domain.aspx?ID=" + row["Id"].ToString() + "'>  <img src ='images/delete.png'  style='width: 30px; height: 30px;'/></a></td>";
                    html += "</tr>";
                }

                html += "</tbody></table>";

                // Apply styles to the table
                myDiv.InnerHtml = "<div class='table-responsive'>" + html + "</div>";


                // Clean up resources
                reader.Close();
                con.Close();



            }
            else
            {
                // User is not authorized to access this page

                Response.Redirect("index.aspx?msg=As an admin you are not authorized to access this page. Please contact your super Admin!");
                Response.Write("<script>alert('You are not allowed to access this page.');</script>");

            }
        }
    }
}