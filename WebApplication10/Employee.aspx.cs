using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace WebApplication10
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            HttpCookie mycookie = Request.Cookies["auth"];
            string email;
            
            if (mycookie!=null)
            {
                email = mycookie["email"];
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
//            int cid;
  //          int.TryParse(TextBox1.Text, out cid) ;
            string eid = TextBox2.Text;
            int pid;
            int.TryParse(TextBox3.Text, out pid);
            string projectTitle = TextBox4.Text;
            string comment = TextBox5.Text;
            string timestamp = TextBox6.Text;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Comments(employeeID, projectID, projectTitle, comment, timestamp) values (@employeeID, @projectID,@projectTitle,@comment,@timestamp)", conn);
                cmd.Parameters.AddWithValue("employeeID", eid);
                cmd.Parameters.AddWithValue("projectID", pid);
                cmd.Parameters.AddWithValue("projectTitle", projectTitle);
                cmd.Parameters.AddWithValue("comment", comment);
                cmd.Parameters.AddWithValue("timestamp", timestamp);

                HttpCookie revised = Request.Cookies["numberoftimes"];

                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                }
                finally
                { conn.Close(); }
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int pid;
            int.TryParse(TextBox7.Text, out pid);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select employeeID,comment from Comments where projectID=@projectID", conn);
                cmd.Parameters.AddWithValue("projectID", pid);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "Comments");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                conn.Close();
            }
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select count(commentsID) from Comments where projectID = @projectID", conn);
                cmd.Parameters.AddWithValue("projectID", pid);

                string numberofrevisions = cmd.ExecuteScalar().ToString();
                Label1.Text = numberofrevisions;
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Firebrick;
                conn.Close();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");


        }
    }
}