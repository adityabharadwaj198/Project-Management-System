using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication10
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Password1_TextChanged(object sender, EventArgs e)
        {

        }

        private static bool ReadSingleRow (IDataRecord record, string password)
        {
            if (record[3].ToString() == password)
                return true;
            else
                return false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //SqlCommand com = new SqlCommand("strlogin", conn);
            //com.CommandType = System.Data.CommandType.StoredProcedure;
            //SqlParameter p1 = new SqlParameter("email", TextBox1.Text);
            //SqlParameter p2 = new SqlParameter("password", Password1.Text);
            //com.Parameters.Add(p1);
            //com.Parameters.Add(p2);
            //conn.Open();
            //SqlDataReader rd = com.ExecuteReader();
            //if (rd.HasRows)
            //{
            //    Label1.Text = "Login successful";
            //    Label1.Visible = true;
            //}
            //else
            //{
            //    Label1.Text = "invalid";
            //    Label1.Visible = true;
            //}
            conn.Open();

            string email = TextBox1.Text;
            string password = Password1.Text;

            string query = "select * from OldPasswords where email = '" + email + "' and password = '"+password + "' order by timestamp";
            SqlCommand check = new SqlCommand(query, conn);
            check.CommandType = System.Data.CommandType.Text;
            SqlDataReader sdr = check.ExecuteReader();
            bool canuse = true;
            int count = 5;
            while(sdr.Read())
            {
                if (ReadSingleRow((IDataRecord)sdr, password))
                    {
                    canuse = false;
                    }
                count--;
                if (count == 0)
                    break;
            }
            sdr.Close();
            if (canuse == true)
            {
                SqlCommand cmd3 = new SqlCommand("select * from Validate where email = '" + email+ "'", conn);
                SqlDataReader sdr3 = cmd3.ExecuteReader();
                //string em = sdr3.GetString(0);
                //string p = sdr3.GetString(1);
                //Label1.Text = em +" "+ p;
                //Label1.Visible = true;
                if (sdr3.HasRows)
                {
                    sdr3.Close();
                    string query2 = "update Validate set password = '" + password + "' where email = '" + email + "'";
                    SqlCommand cmdHasRow = new SqlCommand(query, conn);
                    cmdHasRow.CommandType = System.Data.CommandType.Text;
                    cmdHasRow.ExecuteNonQuery();
                }
                else
                {
                    sdr3.Close();
                    SqlCommand cmd = new SqlCommand("insert into Validate values (@email1, @password1)", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlParameter p1 = new SqlParameter("email1", TextBox1.Text);
                    SqlParameter p2 = new SqlParameter("password1", Password1.Text);
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                SqlCommand cmd2 = new SqlCommand("insert into OldPasswords(timestamp, email, password) values (@timestamp1, @email2, @password2)", conn);
                cmd2.CommandType = System.Data.CommandType.Text;
                SqlParameter p3 = new SqlParameter("timestamp1", DateTime.Now);
                SqlParameter p4 = new SqlParameter("email2", TextBox1.Text);
                SqlParameter p5 = new SqlParameter("password2", Password1.Text);
                cmd2.Parameters.Add(p3);
                cmd2.Parameters.Add(p4);
                cmd2.Parameters.Add(p5);

                cmd2.ExecuteNonQuery();
                Label1.Text = "registration success!";
                Label1.Visible = true;
            }
            else
            {
                Label1.Text = "Your password must be different from your last 5 passwords";
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Visible = true;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}