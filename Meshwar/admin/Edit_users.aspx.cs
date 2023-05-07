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
    public partial class Edit_users : System.Web.UI.Page
    {
        public string id, gender, path, is_published;
        public string filename;
        string idString, image;
        connection s = new connection();

        protected void txtReset_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            string gender;
            if (RadioButton1.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            string fileExtension = Path.GetExtension(FileUpload1.FileName);

       
                // Generate a random number to append to the file name
                Random rnd = new Random();
                int number = rnd.Next(1, 13);

                // Save the file to the server
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                string newFileName = fileNameWithoutExtension + number + fileExtension;
                FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "admin/images/" + newFileName);


                path = newFileName;

                // Save the file to the images folder
                FileUpload1.PostedFile.SaveAs(Server.MapPath("images/") + newFileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("../frontEnd/images/") + newFileName);

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);
            SqlCommand cmd = new SqlCommand("update users set username = '" + txtUsername.Text + "',email='"+txtEmail.Text+"', password='"+hashedPassword+"',image='"+path+"', gender='"+gender+"'  where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            con.Close();
            Response.Write("<script> alert('User updated Successfully')</script>");
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        public string query, constr;
        public string src, doctorId;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jomana\source\repos\Meshwar\Meshwar\App_Data\Doctors.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["ID"];
            if (!IsPostBack)
            {
                // Retrieve the ID from the query string
                string id = Request.QueryString["ID"];

                SqlCommand cmd1 = new SqlCommand("SELECT * FROM users WHERE Id = @Id", con);
                cmd1.Parameters.AddWithValue("@Id", id);
                // Execute the command and retrieve the data
                con.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {

                    txtEmail.Text = reader1["email"].ToString();
                    txtUsername.Text = reader1["username"].ToString();
                    string gender = reader1["gender"].ToString();

                }
                if (gender == "Male")
                {
                    RadioButton1.Checked = true;
                }
                else
                {
                    RadioButton2.Checked = true;
                }
                reader1.Close();
                con.Close();
            }
        }
    }
}
