using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.admin
{
    public partial class ViewArticles : System.Web.UI.Page
    {
        private const string V = "Role";
        public string query;
        connection s = new connection();
        public string src;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

            con.Open();
            string sessionValue = Session["role"] as string; // Get session variable value as a string

            if (String.Equals(sessionValue, "1", StringComparison.OrdinalIgnoreCase))
            {
                query = "SELECT * FROM articles ";
            }
            else
            {
                // The session variable is not equal to "myString"
                query = "SELECT * FROM articles where publisher_id= '" + Session["UserId"] + "'";

            }

         

            // Step 2: Execute the SQL query
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            // Step 3: Bind the data to a DataTable or a List
            DataTable dt = new DataTable();
            dt.Load(reader);

            // Step 4: Create the Bootstrap table
            string html = "<table class='table table-hover  table-bordered'>";
            html += "<thead class='thead-dark'><tr><th>Published</th><th>Title</th><th>Abstract</th><th>Category</th><th>Author</th><th>Date</th><th>Edit</th><th>Delete</th></tr></thead>";
            html += "<tbody>";

            // Step 5: Populate the Bootstrap table
            foreach (DataRow row in dt.Rows)
            {


                string query1 = "SELECT domain FROM domains where Id=@Id";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@Id", row["domain"].ToString());
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
                html += "<td><a href='Article_details.aspx?ID=" + row["Id"].ToString() + "'>" + row["title"].ToString() + "</a></td>";
                html += "<td>" + row["abstract"].ToString() + "</td>";
                html += "<td>" + speciality + "</td>";
                html += "<td>" + row["coworkers"].ToString() + "</td>";
                html += "<td>" + Convert.ToDateTime(row["releasedate"]).ToString("yyyy-MM-dd") + "</td>";
             
                html += "<td><a href='Edit_Article.aspx?ID=" + row["Id"].ToString() + "'>  <img src ='images/edit.png'  style='width: 30px; height: 30px;'/></a></td>";
                html += "<td><a href='Delete_Article.aspx?ID=" + row["Id"].ToString() + "'>  <img src ='images/delete.png'  style='width: 30px; height: 30px;'/></a></td>";
                html += "</tr>";
            }

            html += "</tbody></table>";

            // Step 6: Display the Bootstrap table
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
                query = "SELECT * FROM articles WHERE title LIKE '%" + key + "%' ";

            }
            else
            {
                query = "SELECT * FROM articles where publisher_id= '" + Session["UserId"] + "' AND title LIKE '%" + key + "%' ";
            }
           
            // Step 2: Execute the SQL query
            SqlCommand cmd = new SqlCommand(query, con);
           
            SqlDataReader reader = cmd.ExecuteReader();

            // Step 3: Bind the data to a DataTable or a List
            DataTable dt = new DataTable();
            dt.Load(reader);

            // Step 4: Create the Bootstrap table
            string html = "<table class='table table-hover  table-bordered'>";
            html += "<thead class='thead-dark'><tr><th>Published</th><th>Title</th><th>Abstract</th><th>Category</th><th>Author</th><th>Date</th><th>Edit</th><th>Delete</th></tr></thead>";
            html += "<tbody>";

            // Step 5: Populate the Bootstrap table
            foreach (DataRow row in dt.Rows)
            {


                string query1 = "SELECT domain FROM domains where Id=@Id";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@Id", row["domain"].ToString());
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
                html += "<td><a href='Article_details.aspx?ID=" + row["Id"].ToString() + "'>" + row["title"].ToString() + "</a></td>";
                html += "<td>" + row["abstract"].ToString() + "</td>";
                html += "<td>" + speciality + "</td>";
                html += "<td>" + row["coworkers"].ToString() + "</td>";
                html += "<td>" + Convert.ToDateTime(row["releasedate"]).ToString("yyyy-MM-dd") + "</td>";

                html += "<td><a href='Edit_Article.aspx?ID=" + row["Id"].ToString() + "'>  <img src ='images/edit.png'  style='width: 30px; height: 30px;'/></a></td>";
                html += "<td><a href='Delete_Article.aspx?ID=" + row["Id"].ToString() + "'>  <img src ='images/delete.png'  style='width: 30px; height: 30px;'/></a></td>";
                html += "</tr>";
            }

            html += "</tbody></table>";

            // Step 6: Display the Bootstrap table
            myDiv.InnerHtml = "<div class='table-responsive'>" + html + "</div>";

            // Clean up resources
            reader.Close();
            con.Close();
           
        }
    }
}