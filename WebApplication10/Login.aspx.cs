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
                int result;
                if (!dict.TryGetValue(email, out result))
                {
                    dict.Add(email, 0);
                }
                if (result <= 5)
                {
                    dict[email]++;
                    string query = "select * from Validate where email = '" + email + "' and password = '" + pwd + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    { 
                        Label2.Text = "Login successful";
                        sdr.Close();
                        string query2 = "select * from OldPasswords where email = '" + email + "'and password = '" + pwd + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, conn);
                        SqlDataReader sdr2 = cmd2.ExecuteReader();
                        if (sdr2.Read())
                        {
                            //DateTime time1 = Convert.ToDateTime(sdr2["timestamp"]);
                            DateTime time1 = sdr2.GetDateTime(1);
                            Label3.Text = time1.ToString();
                            Label3.Visible = true;
                            if ((DateTime.Now - time1).TotalDays > 14)
                            {
                                Label3.Text = "It's been 14 days, Change your password!";
                                Label3.ForeColor = System.Drawing.Color.Red;
                                Label3.Visible = true;
                                LinkButton2.Text = "Go to Registration Page";
                                LinkButton2.ForeColor = System.Drawing.Color.DarkBlue;
                                LinkButton2.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    Label2.Text = "Your account has been locked";
                    Label2.ForeColor = System.Drawing.Color.Red;
                    Label2.Visible = true;
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