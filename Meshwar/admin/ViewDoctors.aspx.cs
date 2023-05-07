using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace Meshwar.admin
{
    public partial class ViewDoctors : System.Web.UI.Page
    {
        connection s = new connection();
        public string query, constr, speciality;
        public string src;

      

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");


        protected void Page_Load(object sender, EventArgs e)
        {

            con.Open();

            string sessionValue = Session["role"] as string; // Get session variable value as a string

            if (String.Equals(sessionValue, "1", StringComparison.OrdinalIgnoreCase))
            {
                query = "SELECT * FROM info ";
            }
            else
            {
                // The session variable is not equal to "myString"
                query = "SELECT * FROM info where publisher_id= '" + Session["UserId"] + "'";

            }






            // Step 2: Write an SQL query to retrieve the data

            // Step 3: Execute the SQL query
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataReader reader = cmd.ExecuteReader();

            // Step 4: Bind the data to a DataTable or a List
            DataTable dt = new DataTable();
            dt.Load(reader);

            // Step 5: Create the Bootstrap table
            // Step 5: Create the Bootstrap table
            string html = "<table class='table table-hover  table-bordered'>";
            html += "<thead class='thead-dark'><tr><th>Posted</th><th>Name</th><th>Speciality</th><th>Gender</th> <th>Edit</th> <th>Delete</th></tr></thead>";
            html += "<tbody>";

            // Step 6: Populate the Bootstrap table
            foreach (DataRow row in dt.Rows)
            {

                string query1 = "SELECT domain FROM domains where Id=@Id";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@Id", row["speciality"].ToString());
                SqlDataReader reader1 = cmd1.ExecuteReader();
                string speciality = "";
                if (reader1.Read())
                {
                    speciality = reader1["domain"].ToString();
                }
                reader1.Close();
                bool areEqual = row["is_published"].ToString().Equals("0", StringComparison.OrdinalIgnoreCase);

                if (areEqual)
                {
                    src = "images/notchecked.png";
                }
                else
                {
                    src = "images/check.png";
                }
                html += "<tr>";
                html += "<td witdh='40px'> <img  src='" + src + "' style='width: 30px; height: 30px;' </td>";
                html += "<td><a href='Doctor_details.aspx?ID=" + row["Id"].ToString() + "'>" + row["firstname"].ToString() + "</a></td>";
                html += "<td>"+ speciality + "</td>";
                html += "<td>" + row["gender"].ToString() + "</td>";
                html += "<td><a href='Edit_doctors.aspx?ID=" + row["Id"].ToString() + "'>  <img src ='images/edit.png'  style='width: 30px; height: 30px;'/></a></td>";
                html += "<td><a href='Delete_doctors.aspx?ID=" + row["Id"].ToString() + "'>  <img src ='images/delete.png'  style='width: 30px; height: 30px;'/></a></td>";
                html += "</tr>";
            }

            html += "</tbody></table>";

            // Apply styles to the table
            myDiv.InnerHtml = "<div class='table-responsive'>" + html + "</div>";


            // Clean up resources
            reader.Close();
            con.Close();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
    con.Open();

            string key = TextBox1.Text;

            if ((string)Session["role"] == "1")
            {
                query = "SELECT * FROM info WHERE firstname LIKE '%" + key + "%' ";

            }
            else
            {
                query = "SELECT * FROM info where publisher_id= '" + Session["UserId"] + "' AND firstname LIKE '%" + key + "%' ";
            }
            // Step 2: Write an SQL query to retrieve the data

            // Step 3: Execute the SQL query
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataReader reader = cmd.ExecuteReader();

            // Step 4: Bind the data to a DataTable or a List
            DataTable dt = new DataTable();
            dt.Load(reader);

            // Step 5: Create the Bootstrap table
            // Step 5: Create the Bootstrap table
            string html = "<table class='table table-hover  table-bordered'>";
            html += "<thead class='thead-dark'><tr><th>Posted</th><th>Name</th><th>Speciality</th><th>Gender</th> <th>Edit</th> <th>Delete</th></tr></thead>";
            html += "<tbody>";

            // Step 6: Populate the Bootstrap table
            foreach (DataRow row in dt.Rows)
            {

                string query1 = "SELECT domain FROM domains where Id=@Id";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@Id", row["speciality"].ToString());
                SqlDataReader reader1 = cmd1.ExecuteReader();
                string speciality = "";
                if (reader1.Read())
                {
                    speciality = reader1["domain"].ToString();
                }
                reader1.Close();
                bool areEqual = row["is_published"].ToString().Equals("0", StringComparison.OrdinalIgnoreCase);

                if (areEqual)
                {
                    src = "images/notchecked.png";
                }
                else
                {
                    src = "images/check.png";
                }
                html += "<tr>";
                html += "<td witdh='40px'> <img  src='" + src + "' style='width: 30px; height: 30px;' </td>";
                html += "<td><a href='Doctor_details.aspx?ID=" + row["Id"].ToString() + "'>" + row["firstname"].ToString() + "</a></td>";
                html += "<td>"+ speciality + "</td>";
                html += "<td>" + row["gender"].ToString() + "</td>";
                html += "<td><a href='Edit_doctors.aspx?ID=" + row["Id"].ToString() + "'>  <img src ='images/edit.png'  style='width: 30px; height: 30px;'/></a></td>";
                html += "<td><a href='Delete_doctors.aspx?ID=" + row["Id"].ToString() + "'>  <img src ='images/delete.png'  style='width: 30px; height: 30px;'/></a></td>";
                html += "</tr>";
            }

            html += "</tbody></table>";

            // Apply styles to the table
            myDiv.InnerHtml = "<div class='table-responsive'>" + html + "</div>";


            // Clean up resources
            reader.Close();
            con.Close();
        }

    }
}