using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Meshwar.frontEnd
{
    public partial class index : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string query = "SELECT TOP 3 d.Id, d.firstname, d.lastname, do.domain AS Speciality, d.image FROM info d JOIN domains do ON d.speciality = do.Id WHERE d.is_published=1";
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            DoctorsRepeater.DataSource = dataTable;
                            DoctorsRepeater.DataBind();
                        }
                    }
                }

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 4 articles.Id, articles.title, articles.coworkers, domains.domain AS domain_name FROM articles INNER JOIN domains ON articles.domain = domains.id WHERE is_published=1", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                ArticlesRepeater.DataSource = rdr;
                ArticlesRepeater.DataBind();

                rdr.Close();
                con.Close();
            }
        }
    }
}