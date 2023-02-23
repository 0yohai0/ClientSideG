
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using theResearchSite.UserNewsInteractionService;

namespace theResearchSite
{
    public partial class singleNews : System.Web.UI.Page
    {
        NewsService.NewsList news = new NewsService.NewsList();
        protected void Page_Load(object sender, EventArgs e)
        {
            //applicationUse
            if (Application[Request.Url.ToString()] == null)
            {
                Application[Request.Url.ToString()] = 0;
            }
            Application[Request.Url.ToString()] = (int)Application[Request.Url.ToString()]+1;

            //בדיקה שהגיע מדף חדשות רבות
            if(Request["NewsId"]==null)
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
            //-קבלת מזהה מURL
            int.TryParse(Request["NewsId"].ToString(), out int newsId);
            NewsService.NewsClient newsClient = new NewsService.NewsClient();
            news = newsClient.selectAll();
            NewsService.News singleNews = news.Find(x => (x.Id == newsId));

            lSingleNews.Text += "<div class=\"body-wrap\">";
            lSingleNews.Text += "<div class=\"page-wrap \">";

            lSingleNews.Text += "<div class=\"comments-wrap\">";
            lSingleNews.Text += "</div>";
                             
            lSingleNews.Text += "<div class=\"single-news-wrap flex-culomn-center\">";


            lSingleNews.Text += "<div class=\"news-head-wrap flex-line-center\">";

            lSingleNews.Text += "<div class=\"single-news-headers-wrap flex-culomn-center\">";
            lSingleNews.Text += $"<div class=\"single-news-head-line\">{singleNews.headLine}</div>";
            lSingleNews.Text += $"<div class=\"single-news-sec-title\">{singleNews.secondaryTitle}</div>";
            lSingleNews.Text += "</div>";

            lSingleNews.Text += "<div class=\"img-wrap\">";
            lSingleNews.Text += $"<img class=\"single-news-img\" src=\"{singleNews.imagePath}\"/>";
            lSingleNews.Text += "</div>";

            lSingleNews.Text += "</div>";

            lSingleNews.Text += "<div class=\"more-info-wrap flex-line-center\">";
            lSingleNews.Text += $"<div class=\"news-info flex-line-center\"> <div class=\"news-authers\">כותבים כותבים</div>  <div class=\"news-date\">{singleNews.dateTimePublished.Date.ToString().Substring(0,11).Trim()}</div> </div>";
            lSingleNews.Text += "<div class=\"user-news-interaction flex-line-center\"><div class=\"news-comments\"><i class='fas fa-comment-alt'></i></div> <div class=\"add-heart\">&#9829;</div></div>";
            lSingleNews.Text += "</div>";

            lSingleNews.Text += "<div class=\"news-text-wrap\">";
            lSingleNews.Text += $"<div class=\"text-design\">{singleNews.content}</div>";
            lSingleNews.Text += "</div>";

            lSingleNews.Text += "</div>";
                             
            lSingleNews.Text += "<div class=\"more-news-wrap flex-culomn-center\">";
            lSingleNews.Text += "</div>";
                             
            lSingleNews.Text += "</div>";
            lSingleNews.Text += "</div>";

 

        }
    }
}