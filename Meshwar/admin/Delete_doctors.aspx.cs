using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.admin
{
    public partial class Delete_doctors : System.Web.UI.Page
    {

        public string id;
        connection s = new connection();
       
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["ID"];
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM info WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("ViewDoctors.aspx");
        }
    }
}