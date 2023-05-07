using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.frontEnd
{
    public partial class article_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Retrieve the ID from the query string
            string id = Request.QueryString["ID"];

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True"))
            {
                con.Open();
                // Retrieve the main data using the first connection object
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM articles WHERE Id = @Id", con))
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
                                    cmd1.Parameters.AddWithValue("@Id", reader["domain"].ToString());
                                    using (SqlDataReader reader1 = cmd1.ExecuteReader())
                                    {
                                        if (reader1.Read())
                                        {
                                            speciality = reader1["domain"].ToString();
                                        }
                                    }
                                }
                            }

                            // If the article was found, display its information

                           
                            lbTitle.Text = reader["title"].ToString();
                            lbAbstract.Text = reader["abstract"].ToString();
                            lbCoworkers.Text = reader["coworkers"].ToString();
                            lbDate.Text = reader["releasedate"].ToString();
                            lbDomain.Text = speciality;




                            //  byte[] fileBytes = (byte[])reader["pdf"];
                            string fileName = (string)reader["pdf"];
                            pdfLink.NavigateUrl = "pdfs/" + fileName;
                            pdfLink.Text = "Article_PDF";
                        }

                        // close the reader and the database connection
                        reader.Close();
                        con.Close();

                    }
                }
            }
        }
    }
}
