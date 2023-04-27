using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using theResearchSite.CategoryService;
using theResearchSite.NewsService;

namespace theResearchSite
{
    public partial class addNews : System.Web.UI.Page
    {
         CategoriesClient categoriesClient = new CategoriesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //בדיקות
            //if(Session["עיתונאי"] == null)
            //{
            //    Response.Redirect("homePage.aspx");
            //}
               
            if(!IsPostBack)
            {
                populate();
            }       
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

        protected void BtsaveImg_Click(object sender, EventArgs e)
        {
            if (fuNewsImg.HasFile)
            {
                fuNewsImg.SaveAs("C:\\theResearch\\clientSide\\theResearchSite\\newsImages\\" + fuNewsImg.FileName.ToString());
                imgNews.Src = "newsImages/" + fuNewsImg.FileName;
                Session["imgSrc"] = "newsImages/" + fuNewsImg.FileName;
            }
        }

        protected void btSendNews_Click(object sender, EventArgs e)
        {
            //קבלת מידע
            string headLine = txbHeadLine.Text;
            string secTitle = txbSecTitle.Text;
            string content = txbContent.Text;

            //קטגוריה
            int.TryParse(ddlCategories.SelectedValue.ToString(), out int categoryId);
            string categoryName = ddlCategories.SelectedItem.ToString();
            //הרשאה
            NewsService.AuthLevel auth = new NewsService.AuthLevel();
            auth.Id = 12;
            auth.name = "משתמש";


            News newsToAdd = new News();
            newsToAdd.headLine = headLine;
            newsToAdd.secondaryTitle = secTitle;
            newsToAdd.content = content;
            newsToAdd.category = new NewsService.Category();
            newsToAdd.category.Id = categoryId;
            newsToAdd.category.name = categoryName;
            newsToAdd.AuthLevel = auth;
            newsToAdd.dateTimePublished = DateTime.Now;
            newsToAdd.imagePath = Session["imgSrc"].ToString();


            NewsClient client = new NewsClient();
            int result = client.Add(newsToAdd);

            if(result == 0)
            {
                //שגיאה
            }
            if (result == 1)
            {
                //עובד
                Response.Redirect("homePage.aspx");
            }
            if (result > 1)
            {
                //שגיאה שאין כדוגמתה
            }
        }
    }
}