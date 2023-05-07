using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.admin
{
    public partial class index : System.Web.UI.Page
    {
        int categoryCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Request.QueryString["Id"];
            string Name = Request.QueryString["name"];

            string message = Request.QueryString["msg"];

            if (!string.IsNullOrEmpty(message))
            {
                // Show a message dialog
                Response.Write("<script>alert('" + message + "');</script>");
            }
            ViewState["userCount"] = GetUsersCount();
            ViewState["infoCount"] = GetInfoCount();
            ViewState["articleCount"] = GetArticlesCount();
            ViewState["categoryCount"] = GetCategoriesCount();


        }
        protected int GetUsersCount()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM users", con);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }

        protected int GetInfoCount()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM info", con);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }

        protected int GetArticlesCount()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM articles", con);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }

        protected int GetCategoriesCount()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM domains", con);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }
    }
}