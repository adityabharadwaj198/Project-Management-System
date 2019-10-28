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
    public partial class ViewAllProjects : System.Web.UI.Page
    {
                /*
         *             string parameter = DropDownList1.SelectedValue;
            string valueofparameter = TextBox1.Text;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand cmd = new SqlCommand("Select * from Projects where @parameter=@valueofparameter", conn);
                cmd.Parameters.AddWithValue("parameter", parameter);
                cmd.Parameters.AddWithValue("valueofparameter", valueofparameter);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "Projects");
                GridView1.DataBind();
                conn.Close();
            }

         * /
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["email"] as string;
            Label3.Text = "Welcome " + username;
            Label3.ForeColor = System.Drawing.Color.Aquamarine;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Projects", conn);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "Projects");
                GridView1.DataBind();
                conn.Close();

            }
        }

    }
}