using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApplication10
{
    public partial class GenerateReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = (string)Session["email"];
            Label5.Text = "Welcome " + username;
            Label5.ForeColor = System.Drawing.Color.Aquamarine;
            
        }
        /*conn.Open();
                SqlCommand cmd = new SqlCommand("Select employeeID,comment from Comments where projectID=@projectID", conn);

        cmd.Parameters.AddWithValue("projectID", pid);
                DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "Comments");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                conn.Close();
*/
       /* protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string parameter = DropDownList1.SelectedValue;
            string valueofparameter = TextBox1.Text;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand cmd = new SqlCommand("Select * from Projects where @parameter=@valueofparameter", conn);
                cmd.Parameters.AddWithValue("parameter", parameter);
                cmd.Parameters.AddWithValue("valueofparameter", valueofparameter);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "Projects");
                GridView2.DataBind();
                conn.Close();
            }
        }*/

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string parameter = DropDownList1.SelectedValue.ToString();
            string valueofparameter = TextBox1.Text;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand cmd = new SqlCommand("Select Id,title,duration,client from Projects where title=@valueofparameter", conn);
                //cmd.Parameters.AddWithValue("@parameter", parameter);
                cmd.Parameters.AddWithValue("@valueofparameter", valueofparameter);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "Projects");
                GridView2.DataSource = ds;
                GridView2.DataBind();
                GridView2.Visible = true;
//                //SqlDataReader sdr = cmd.ExecuteReader();
                
                /*while(sdr.Read())
                {
                    BulletedList1.Items.Add(sdr["parameter"].ToString);
                }*/
                conn.Close();
            }

        }

    }
}