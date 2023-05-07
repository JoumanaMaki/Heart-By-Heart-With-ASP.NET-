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
    public partial class Add_Doctors : System.Web.UI.Page
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
                ddlSpeciality.Items.Add(item);
            }

            // Close the SqlDataReader and SqlConnection objects
            reader.Close();
            conn.Close();
        }

        protected void txtReset_Click(object sender, EventArgs e)
        {
            reset_doctors();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String add;
            string path, filename,gender;
            if (FileUpload1.HasFile)
            {
                filename = FileUpload1.FileName;
                FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "admin/images/"+FileUpload1.FileName);
                FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "frontEnd/images/" + FileUpload1.FileName);

                path = "images/"+ filename;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("images/")+filename);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("../frontEnd/images/") + filename);
                // string fileName = Path.GetFileName(FileUpload1.FileName);
                // string fileExtension = Path.GetExtension(FileUpload1.FileName);

                // Generate a unique identifier for the image
                // string uniqueId = Guid.NewGuid().ToString();

                // Save the uploaded file to a folder on the server
                /// string filePath = Server.MapPath("images/") + uniqueId + fileExtension;
                //Console.WriteLine(filePath);
                ///  FileUpload1.SaveAs(filePath);
                /// FileUpload1.SaveAs(Server.MapPath("images/") + System.IO.Path.GetFileName(FileUpload1.FileName));
                ///  string linkPath = "images/" + System.IO.Path.GetFileName(FileUpload1.FileName); ;
                if (RadioButton1.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }

                int domaind_id = ddlSpeciality.SelectedIndex + 1;

                add = "insert into info values('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtEmail.Text + "','" + txtNumber.Text + "','" + domaind_id + "','" + txtAddress.Text + "','" + path + "','" + 0 + "','"+gender+"','"+Session["UserId"] +"')";
                s.insert(add);
                Response.Write("<script> alert('Dotor Added Successfully')</script>");
                reset_doctors();
            }
        }
        public void reset_doctors()
        {
            txtAddress.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNumber.Text = "";
            txtEmail.Text = "";
           
          


        }
    }
}