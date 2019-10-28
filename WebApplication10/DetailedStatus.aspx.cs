using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10
{
    public partial class DetailedStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)Session["email"];
            Label3.Text = "Welcome " + email;
            Label3.ForeColor = System.Drawing.Color.Aquamarine;
            int projectID;
            Int32.TryParse(Request.QueryString["projectID"], out projectID);
            Console.WriteLine(projectID);
        }
    }
}