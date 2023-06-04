using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using theResearchSite.CategoryService;
using theResearchSite.NewsService;

namespace theResearchSite
{
    public partial class newsInCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["categoryname"] == null)
            {
                Response.Redirect("homePage.aspx");
            }
            if(!IsPostBack)
            {
                populate();
            }
        }
        public void populate()
        {
            //איפוס
            lNews.Text = "";
            CategoryService.CategoriesClient categoriesClient = new CategoryService.CategoriesClient();
            CategoryList categories = categoriesClient.selectAll();

            CategoryService.Category category = (CategoryService.Category)categories.Find(x => x.name == Request["categoryname"].ToString());

            NewsService.NewsClient newsClient = new NewsService.NewsClient();
            NewsList news = newsClient.selectAll();

            lNews.Text += "<div class=\"category-header\">";
            lNews.Text += $"{category.name}";
            lNews.Text += "</div>";

            lNews.Text += "<div class=\"body-wrap\">";
            foreach (News newsSingle in news.FindAll(x=> x.category.name == category.name))
            {
                //מילוי חדשות בקטגוריה

                lNews.Text += "<div class=\"single-news-in-one-category\">";

                lNews.Text += $"<img class=\"single-news-in-one-category-img\" src=\"{newsSingle.imagePath}\"/>";

                //קבוצת המידע
                lNews.Text += "<div class=\"single-news-in-one-category-info\">";
                lNews.Text += $"<div class=\"single-news-in-one-category-headLine\">{newsSingle.headLine}</div>";

                lNews.Text += $"<div class=\"single-news-in-one-category-content\">{newsSingle.secondaryTitle}</div>";

                lNews.Text += $"<div class=\"single-news-in-one-category-more-info\"> <div class=\"date-of-news\">{newsSingle.dateTimePublished.Date.ToString().Substring(0, 10)}</div> </div>";
                lNews.Text += "</div>";

                lNews.Text += "</div>";

            }
            lNews.Text += "</div>";


        }
    }
}