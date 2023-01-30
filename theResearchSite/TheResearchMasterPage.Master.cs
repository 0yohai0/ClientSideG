using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace theResearchSite
{
    public partial class TheResearchMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
        protected void btLogIn_Click(object sender, EventArgs e)
        {

            Response.Redirect("logIn.aspx");
        }

        protected void btLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("logIn.aspx");
        }
    }
}