using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.frontEnd
{
    public partial class Articles : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");
            if (!IsPostBack)
            {
                // Define the SQL query to retrieve the dropdown list data
                string sql = "SELECT * FROM domains ";

                // Create the SqlCommand object
                SqlCommand cmd2 = new SqlCommand(sql, conn);

                // Open the SqlConnection
                conn.Open();

                // Execute the SqlCommand and retrieve a SqlDataReader object
                SqlDataReader reader = cmd2.ExecuteReader();
                ddlSpeciality.Items.Add("All");
                // Loop through the SqlDataReader to populate the dropdown list
                while (reader.Read())
                {
                    ListItem item = new ListItem();

                    item.Text = reader["domain"].ToString();
                    ddlSpeciality.Items.Add(item);

                }

                // Close the SqlDataReader and SqlConnection objects
                reader.Close();
                conn.Close();

            }

            string sessionValue = Session["is_premium"] as string; // Get session variable value as a string

            if (String.Equals(sessionValue, "1", StringComparison.OrdinalIgnoreCase))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT articles.Id, articles.title, articles.coworkers, domains.domain AS domain_name FROM articles INNER JOIN domains ON articles.domain = domains.id WHERE articles.is_published=1", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                ArticlesRepeater.DataSource = rdr;
                ArticlesRepeater.DataBind();

                rdr.Close();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT articles.Id, articles.title, articles.coworkers, domains.domain AS domain_name FROM articles INNER JOIN domains ON articles.domain = domains.id WHERE articles.is_published=1 AND is_premium=0", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                ArticlesRepeater.DataSource = rdr;
                ArticlesRepeater.DataBind();

                rdr.Close();
                con.Close();
            }
        }

        protected void ddlSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sessionValue = Session["is_premium"] as string; // Get session variable value as a string

            string selectedDomainID = ddlSpeciality.SelectedIndex.ToString();
          
            if (String.Equals(sessionValue, "1", StringComparison.OrdinalIgnoreCase))
            {
                if (selectedDomainID == "0")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT articles.Id, articles.title, articles.coworkers, domains.domain AS domain_name FROM articles INNER JOIN domains ON articles.domain = domains.id WHERE articles.is_published=1 ", con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    ArticlesRepeater.DataSource = rdr;
                    ArticlesRepeater.DataBind();

                    rdr.Close();
                    con.Close();
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT articles.Id, articles.title, articles.coworkers, domains.domain AS domain_name FROM articles INNER JOIN domains ON articles.domain = domains.id WHERE articles.is_published=1 AND articles.domain ='" + selectedDomainID+"'", con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    ArticlesRepeater.DataSource = rdr;
                    ArticlesRepeater.DataBind();

                    rdr.Close();
                    con.Close();
                }
            }
            else
            {
                if (selectedDomainID == "0")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT articles.Id, articles.title, articles.coworkers, domains.domain AS domain_name FROM articles INNER JOIN domains ON articles.domain = domains.id WHERE articles.is_published=1 AND articles.is_premium=0", con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    ArticlesRepeater.DataSource = rdr;
                    ArticlesRepeater.DataBind();

                    rdr.Close();
                    con.Close();
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT articles.Id, articles.title, articles.coworkers, domains.domain AS domain_name FROM articles INNER JOIN domains ON articles.domain = domains.id WHERE articles.is_published=1 AND articles.is_premium=0 AND articles.domain ='" + selectedDomainID + "'", con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    ArticlesRepeater.DataSource = rdr;
                    ArticlesRepeater.DataBind();

                    rdr.Close();
                    con.Close();
                }
            }
        }
    }
}