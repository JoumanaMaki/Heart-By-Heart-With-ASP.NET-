using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.admin
{
    public partial class AddArticles : System.Web.UI.Page
    {

        connection s = new connection();
        public String query, constr;
        public SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");

            // Define the SQL query to retrieve the dropdown list data
            string sql = "SELECT * FROM domains ";

            // Create the SqlCommand object
            SqlCommand cmd = new SqlCommand(sql, conn);

            // Open the SqlConnection
            conn.Open();

            // Execute the SqlCommand and retrieve a SqlDataReader object
            SqlDataReader reader = cmd.ExecuteReader();

            // Loop through the SqlDataReader to populate the dropdown list
            while (reader.Read())
            {
                ListItem item = new ListItem();

                item.Text = reader["domain"].ToString();
                DropDownList1.Items.Add(item);
            }

            // Close the SqlDataReader and SqlConnection objects
            reader.Close();
            conn.Close();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            
                String add;
              
                if (FileUpload1.HasFile)
            {
                string premium;
                  string folderPath = Server.MapPath("pdfs/");
                 string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                  string filePath = Path.Combine(folderPath, fileName);
                  FileUpload1.PostedFile.SaveAs(filePath);
             string   folderPath2 = Server.MapPath("../frontEnd/pdfs/");
                string fileName2 = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string filePath2 = Path.Combine(folderPath2, fileName2);
                FileUpload1.PostedFile.SaveAs(filePath2);
                if(RadioButton1.Checked)
                {
                    premium = "1";
                }
                else
                {
                    premium = "0";
                }

                int domaind_id = DropDownList1.SelectedIndex + 1;
                add = "insert into articles values('" + txtTitle.Text + "','" + txtAbstract.Text + "','" + txtNames.Text + "','" + Calendar1.SelectedDate + "','" +fileName+"','" + 0 + "','"+domaind_id+"','" + Session["UserId"] + "','"+premium+"')";
                    s.insert(add);
                    Response.Write("<script> alert('Articles Added Successfully')</script>");
                reset();
                }
            
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        public void reset()
        {
            txtTitle.Text = "";
            txtNames.Text = "";
            txtAbstract.Text = "";
        }
    }
}