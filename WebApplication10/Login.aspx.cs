using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace WebApplication10
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        IDictionary<string, int> dict = new Dictionary<string, int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            Label3.Visible = false;
            LinkButton2.Visible = false;
            if (IsPostBack)
            {

            }
            
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                string email = TextBox1.Text;
                string pwd = password.Text;
                    string query = "select * from Validate2 where email = '" + email + "' and password = '" + pwd + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string isAdmin1 = sdr.GetString(3);
                    Session["email"] = email;
                    Session["password"] = pwd;

                    HttpCookie myCookie = new HttpCookie("auth");
                    myCookie["email"] = email;
                    myCookie["password"] = pwd;
                    Response.Cookies.Add(myCookie);
                    if (isAdmin1 == "1")
                    {
                        Response.Redirect("Admin.aspx");
                    }
                    else
                    {
                        Response.Redirect("Employee.aspx");
                    }
                }
                else
                {
                    Label2.Text = "Login Failed, re-enter password";
                    Label2.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}