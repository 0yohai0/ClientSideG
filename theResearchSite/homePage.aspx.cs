using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using theResearchSite.NewsService;
using theResearchSite.CategoryService;

namespace theResearchSite
{
    public partial class homePage : System.Web.UI.Page
    {
        ArrayList newsCart;
        static NewsService.NewsClient NewsClient = new NewsService.NewsClient();
        NewsService.NewsList newsStart = NewsClient.selectAll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["newscart"] == null)
            {
                newsCart = new ArrayList();
            }
            if (Session["newscart"] != null)
            {
                newsCart = (ArrayList)Session["newscart"];
            }
            foreach (string key in Request.Form.AllKeys)
            {

                if (key.Length > 13)
                {
                    if (key.Substring(0,13) == "addToNewsCart")
                    {
                        int.TryParse(key.Substring(13), out int newsId);
                        addToCart(newsId);
                    }
                }

            }
            if (!IsPostBack)
            {
                populate();
            }
        }
        public void populate()
        {
            //רשימת קטגוריות
            CategoryList categoryList = new CategoryList();
            CategoriesClient categoriesClient = new CategoriesClient();
            categoryList = categoriesClient.selectAll();

            // הגדרת רשימת חדשות וסידור לפי תאריך
            List<News> news = newsStart.OrderByDescending(x => x.dateTimePublished).ToList();

            lNews.Text += "<div class=\"category-head-line-demarc\">";
            foreach(CategoryService.Category category in categoryList)
            {
                lNews.Text += "<div class=\"single-category-demarc\">";
                lNews.Text += $"<a class=\"category-head-line-link\" href=\"#{category.name}\">{category.name}</a>";
                
                lNews.Text += "</div>";

                if (categoryList[categoryList.Count-1] != category)
                {
                    lNews.Text += "<div class=\"single-category-demarc\">";
                    lNews.Text += "|";
                    lNews.Text += "</div>";
                }
               
            }
            lNews.Text += "</div>";
            lNews.Text += "<div class=\"body-wrap\">";
          

            lNews.Text += "<div class=\"wrap-center\">";
            lNews.Text += "<div class=\"first-news-block\">";

            lNews.Text += $"<div class=\"first-single-news\"><img class=\"big-picture-news\" src=\"{news[0].imagePath}\"/> <div class=\"try\"> <div class=\"main-headLine\">{news[0].headLine}</div></div> </div>";

            lNews.Text += "<div class=\"trio-news\">";

            foreach(News singleNews in news.Skip(1).Take(3))
            {
                lNews.Text += "<div class=\"single-top-news-small\">";

                lNews.Text += $"<div class=\"img-minor-wrap\"><img class=\"img-full\" src=\"{singleNews.imagePath}\" /></div>";

                lNews.Text += "<div class=\"info-wrap\">";

                lNews.Text += $"<div class=\"header-wrap\"> <div class=\"single-top-news-headLine\">{singleNews.headLine}</div> <div class=\"category\">|{singleNews.category.name}</div> </div>";
                lNews.Text += $"<div class=\"single-top-news-secTitle\">{singleNews.secondaryTitle}</div>";
                lNews.Text += $"<div class=\"single-top-news-bottomLine\"> <div><input type=\"submit\" id=\"addToNewsCart\" name=\"addToNewsCart{singleNews.Id}\" value=\"&#9829;\" class=\"bt-add-to-favorits\"/> </div>   <div class=\"\">{singleNews.dateTimePublished.Date.ToString().Substring(0,10)}</div> </div>";

                lNews.Text += "</div>";

                lNews.Text += "</div>";

            } 

       
            lNews.Text += "</div>";
            lNews.Text += "</div>";
            lNews.Text += "</div>";

            //בניית קבוצות לפי קטגוריות
            List<NewsList> newsByCategories = new List<NewsList>();
            newsByCategories = newsByCategory(news);

            lNews.Text += "<div class=\"second-block-news-wrap\">";

            foreach (NewsList newsList in newsByCategories.OrderByDescending(x=>x.Count))
            {
                if(newsList.Count!=0)
                {
                    lNews.Text += "<div class=\"news-line-wrap\">";

                    lNews.Text += $"<div id=\"{newsList[0].category.name}\" class=\"category-head\">";
                    lNews.Text += $"<div class=\"category-head-name\">{newsList[0].category.name}</div> <div class=\"more-category-link\"> <a class=\"category-link-design\" href=\"a\">לעוד חדשות בנושא</a> </div>";
                    lNews.Text += "</div>";

                    lNews.Text += "<div class=\"news-in-category\">";
                    for(int i = 0; i<newsList.Count && i<4; i++)
                    {
                        lNews.Text += "<div class=\"single-horizontal-news\">";

                        lNews.Text += "<div class=\"single-news-img-medium-wrap\">";
                        lNews.Text += $"<abbr title=\"{newsList[i].headLine}\"><img class=\"single-news-img-medium\" src=\"{newsList[i].imagePath}\"/> </abbr>";
                        lNews.Text += "</div>";

                        lNews.Text += "<div class=\"single-news-headLine\">";
                        lNews.Text += $"{newsList[i].headLine}";
                        lNews.Text += "</div>";

                        lNews.Text += "<div class=\"single-news-more-info\">";
                        lNews.Text += $"<div class=\"bt-add-to-favorits\"><input type=\"submit\" id=\"addToNewsCart\" name=\"addToNewsCart{newsList[i].Id}\" value=\"&#9829;\" class=\"bt-add-to-favorits\"/></div><div class=\"single-news-category\">|{newsList[i].category.name}</div>";
                        lNews.Text += "</div>";

                        lNews.Text += "</div>";
                    }             

                    lNews.Text += "</div>";

                    lNews.Text += "</div>";
                }
            }
          lNews.Text += "</div>";

          lNews.Text += "</div>";

        }
        public List<NewsList> newsByCategory(List<News> news)
        {
            CategoryList categoryList = new CategoryList();
            CategoriesClient categoriesClient = new CategoriesClient();
            categoryList = categoriesClient.selectAll();


            List<NewsList> listOfCaregories = new List<NewsList>();
            foreach (CategoryService.Category c in categoryList)
            {
                NewsList newsToAdd = new NewsList();
                foreach(News singleNews in news.FindAll(x=>x.category.Id == c.Id))
                {
                    newsToAdd.Add(singleNews);
                }
                listOfCaregories.Add(newsToAdd);
            }

            return listOfCaregories;
        }

        public void addToCart(int newsId)
        {
            if (Session["user"] == null)
                return;
            //בדיקה באם קיים
            if (newsCart.Count>0)
            {
               foreach(int Id in newsCart)
               {
                   if (newsId == Id)
                       return;
               }
            }

            newsCart.Add(newsId);
            Session["newscart"] = newsCart;
        }
    }
}