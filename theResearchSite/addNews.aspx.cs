using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using theResearchSite.CategoryService;

namespace theResearchSite
{
    public partial class addNews : System.Web.UI.Page
    {
            CategoriesClient categoriesClient = new CategoriesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                populate();
            }
            if(fuNewsImg.HasFile)
            {
               populateImg();
            }
        }
        public void populateImg()
        {
            fuNewsImg.SaveAs("C:\\Users\\everybody\\Desktop\\newsImages\\"+fuNewsImg.FileName);
            imgNews.Src = "newsImages/" + fuNewsImg.FileName;
        }
        public void populate()
        {
            CategoryList categories = categoriesClient.selectAll();
            ddlCategories.DataSource = categories;
            ddlCategories.Items.Add(new ListItem("", "-1"));
            ddlCategories.DataTextField = "name";
            ddlCategories.DataValueField = "Id";
            ddlCategories.DataBind();
        }

        protected void txbHeadLine_TextChanged(object sender, EventArgs e)
        {
            headLine.InnerHtml = txbHeadLine.Text;
         
        }

        protected void txbSecTitle_TextChanged(object sender, EventArgs e)
        {
            secTitle.InnerHtml = txbSecTitle.Text;
        }

        protected void txbContent_TextChanged(object sender, EventArgs e)
        {
            string contentText = txbContent.Text;

            string result = contentText.Replace("\r\n", "<br/>");
            content.InnerHtml = result;
           
        }
    }
}