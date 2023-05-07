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
    public partial class Edit_Article : System.Web.UI.Page
    {
        connection s = new connection();
        public string query, constr,id;
        public string src, doctorId;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");


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

            id = Request.QueryString["ID"];
            if (!IsPostBack)
            {
                // Retrieve the ID from the query string
                string id = Request.QueryString["ID"];

                SqlCommand cmd1 = new SqlCommand("SELECT * FROM articles WHERE Id = @Id", con);
                cmd1.Parameters.AddWithValue("@Id", id);
                // Execute the command and retrieve the data
                con.Open();
                SqlDataReader reader1= cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    txtAbstract.Text = reader1["abstract"].ToString();
                    txtTitle.Text = reader1["title"].ToString();


                    txtNames.Text = reader1["coworkers"].ToString();

                    string specialityValue = reader1["domain"].ToString();
                    int selectedIndex;
                    if (int.TryParse(specialityValue, out selectedIndex))
                    {
                        selectedIndex -= 1;
                        DropDownList1.SelectedIndex = selectedIndex;
                    }// your value from db
                    if (reader1["is_published"].ToString() == "0")
                    {
                        RadioButton4.Checked = true;
                    }
                    else
                    {
                        RadioButton3.Checked = true;
                    }

                    if (reader1["is_premium"].ToString() == "1")
                    {
                        RadioButton1.Checked = true;
                    }
                    else
                    {
                        RadioButton2.Checked = true;
                    }


                }

                reader.Close();
                con.Close();
            }
            }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string premium;
            if (RadioButton1.Checked)
            {
                premium = "1";
            }
            else
            {
                premium = "0";
            }
            string published;
            if (RadioButton3.Checked)
            {
                published = "1";
            }
            else
            {
                published = "0";
            }
            if (FileUpload1.HasFile)
            {
                string folderPath = Server.MapPath("pdfs/");
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                FileUpload1.PostedFile.SaveAs(filePath);



                string folderPath2 = Server.MapPath("../frontEnd/pdfs/");
                
                string filePath2 = Path.Combine(folderPath2, fileName);
                FileUpload1.PostedFile.SaveAs(filePath2);

                con.Open();
                int spec = DropDownList1.SelectedIndex + 1;

                SqlCommand cmd = new SqlCommand("update articles set title = '" + txtTitle.Text + "', abstract ='" + txtAbstract.Text + "', coworkers='" + txtNames.Text + "', releasedate='" + Calendar1.SelectedDate + "', pdf='" + fileName + "',is_published='" + published + "',domain='" + spec + "',is_premium='"+premium+"' where Id=@Id",con);
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script> alert('Article updated Successfully')</script>");

                reset();
            }

        }


        public void reset()
        {
            txtTitle.Text = "";
            txtNames.Text = "";
            txtAbstract.Text = "";
          
        }
    }
}