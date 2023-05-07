using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meshwar.admin
{
    public partial class Edit_doctors : System.Web.UI.Page
    {
        public string id, gender, path, is_published;
        public string filename;
        string idString, image;
        connection s = new connection();
        public string query, constr;
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
                ddlSpeciality.Items.Add(item);
            }

            // Close the SqlDataReader and SqlConnection objects
            reader.Close();
            conn.Close();


            id = Request.QueryString["ID"];
            if (!IsPostBack)
            {
                // Retrieve the ID from the query string
                string id = Request.QueryString["ID"];

                SqlCommand cmd1 = new SqlCommand("SELECT * FROM info WHERE Id = @Id", con);
                cmd1.Parameters.AddWithValue("@Id", id);

                // Execute the command and retrieve the data
                con.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    txtFirstName.Text = reader1["firstname"].ToString();
                    txtLastName.Text = reader1["lastname"].ToString();


                    txtNumber.Text = reader1["phone"].ToString();
                    txtEmail.Text = reader1["Email"].ToString();
                    txtAddress.Text = reader1["address"].ToString();

                    // Retrieve the value from the database
                    string specialityValue = reader1["speciality"].ToString();
                    int selectedIndex;
                    if (int.TryParse(specialityValue, out selectedIndex))
                    {
                        selectedIndex -= 1;
                        ddlSpeciality.SelectedIndex = selectedIndex;
                    }// your value from db

                    // Set the selected index of the ComboBox


                    // Set values for any additional fields here
                    //FileUpload1.FileName = reader["image"];
                    if (reader1["gender"].ToString() == "Male")
                    {
                        RadioButton1.Checked = true;
                    }
                    else
                    {
                        RadioButton2.Checked = true;
                    }
                    if (reader1["is_published"].ToString() == "0")
                    {
                        RadioButton4.Checked = true;
                    }
                    else
                    {
                        RadioButton3.Checked = true;
                    }


                }

                reader.Close();
                con.Close();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            filename = FileUpload1.FileName;
            FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "admin/images/" + FileUpload1.FileName);
            path = "images/" + filename;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("images/") + filename);
            FileUpload1.PostedFile.SaveAs(Server.MapPath("../frontEnd/images/") + filename);

            if (RadioButton1.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            if (RadioButton3.Checked)
            {
                is_published = "1";
            }
            else
            {
                is_published = "0";
            }
            con.Open();
            // SqlCommand cmd = new SqlCommand("update info set firstname='"+txtFirstName.Text+"', lastname='"+txtLastName.Text+"', email='"+txtEmail.Text+"',phone='"+txtNumber.Text+"', speciality='"+ddlSpeciality.Text+"',address='"+txtAddress.Text+"', image='"+path+"',is_published='"+is_published+"', gender='"+gender+"' WHERE Id='"+id+"'", con);

            SqlCommand cmd = new SqlCommand("UPDATE info SET firstname=@FirstName, lastname=@LastName, email=@Email, phone=@Phone, speciality=@Speciality, address=@Address, image=@Image, is_published=@IsPublished, gender=@Gender WHERE Id=@Id", con);

            int spec = ddlSpeciality.SelectedIndex + 1;
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Phone", txtNumber.Text);
            cmd.Parameters.AddWithValue("@Speciality", spec);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Image", path);
            cmd.Parameters.AddWithValue("@IsPublished", is_published);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();


            //  cmd.CommandType = CommandType.Text;
            // cmd.ExecuteNonQuery();
            Response.Write("<script> alert('Dotor Updated Successfully')</script>");
            con.Close();
            reset_doctors();
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