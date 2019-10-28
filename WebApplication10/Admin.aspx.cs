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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["email"] as string;
            Label4.Text = "Welcome " + username;
            Label4.Visible = true;
            Label4.ForeColor = System.Drawing.Color.DarkGreen;
        }
        /*protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "myTheme";
        }*/
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Projects values (@title1, @duration1, @client1)", conn);
                SqlParameter p1 = new SqlParameter("title1", TextBox1.Text);
                SqlParameter p2 = new SqlParameter("duration1", TextBox2.Text);
                SqlParameter p3 = new SqlParameter("client1", TextBox3.Text);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }
                Label5.Text = "Project created successfully";
                Label5.Visible = true;
                Label5.ForeColor = System.Drawing.Color.IndianRed;
                conn.Close();
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerateReports.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.SelectedRow;
            int myint;
            string text = row.Cells[2].Text;
            Int32.TryParse(text, out myint);
            Response.Redirect("DetailedStatus.aspx?projectID=" + myint);
        }

        /* protected void GridView1_RowSelecting(object sender, GridViewSelectEventArgs e)
         {
             GridViewRow row = (GridViewRow)GridView1.SelectedRow;
             Response.Redirect("DetailedStatus.aspx?projectID=" + row.Cells[2]);
         }*/
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
                //Label lbldeleteid = (Label)row.FindControl("lblID");
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete FROM Comments where CommentsID='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
                cmd.ExecuteNonQuery();
                //conn.Close();
                GridView1.DataBind();
            }
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllProjects.aspx");
        }
    }
}