using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace theResearchSite
{
    public partial class successTransferPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && Request["transferID"]!=null)
            {
                ltransferId.Text += Request["transferID"];
            }
        }
    }
}