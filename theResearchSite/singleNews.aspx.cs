
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using theResearchSite.NewsService;
using theResearchSite.UserNewsInteractionService;

namespace theResearchSite
{
    public partial class singleNews : System.Web.UI.Page
    {
        NewsService.NewsList news = new NewsService.NewsList();
       UserNewsInteractionService.UserNewsInteractionClient userNewsInteractionClient = new UserNewsInteractionService.UserNewsInteractionClient();
        static int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //בדיקה שהגיע מדף חדשות רבות
            if(Request["NewsId"]==null)
            {
                Response.Redirect("homePage.aspx");
            }
            if(!IsPostBack)
            {
                populate();
            }
            foreach (string key in Request.Form.AllKeys)
            {
               
                if (key.Length > 12)
                {
                    if (key == "btPostComment")
                    {
                        addComment();
                    }
             
                }

            }
           
         

        }
        public void populate()
        {
            //איפוס דף
            lSingleNews.Text = "";

            //-קבלת מזהה מURL
            int.TryParse(Request["NewsId"].ToString(), out int newsId);
            NewsClient newsClient = new NewsClient();
            news = newsClient.selectAll();
            NewsService.News singleNews = news.Find(x => (x.Id == newsId));

            //עדכון צפיות
            singleNews.viewsCount++;
            newsClient.Update(singleNews);

            //קבלת כל החדשות בנושא
            NewsList AllnewsInCategory = newsClient.selectAll();
            NewsList newsInCategory = new NewsList();

            //קבלת רשימת תגובות
            CommentList commentList = userNewsInteractionClient.selectAllComments();

            lSingleNews.Text += "<div class=\"body-wrap\">";
            lSingleNews.Text += "<div class=\"page-wrap \">";

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

            lSingleNews.Text += "<div  class=\"more-info-wrap flex-line-center\">";
            lSingleNews.Text += $"<div class=\"news-info flex-line-center\"> <div class=\"news-authers\">כותבים כותבים</div>  <div class=\"news-date\">{singleNews.dateTimePublished.Date.ToString().Substring(0, 11).Trim()}</div> </div>";
            lSingleNews.Text += "<div  class=\"user-news-interaction flex-line-center\"><div class=\"news-comments\"><i class='fas fa-comment-alt'></i> <div style=\"font-size:12px;\">12</div> </div> <div class=\"add-heart\">&#9829;</div></div>";
            lSingleNews.Text += "</div>";

            lSingleNews.Text += "<div class=\"news-text-wrap\">";
            if (singleNews.AuthLevel.name == "מנוי")
            {
                if (Session["subscribed"]!=null)
                {
                    lSingleNews.Text += $"<div class=\"text-design\">{singleNews.content}</div>";
                }
                else
                {
                    lSingleNews.Text += $"<div class=\"text-design\"> -תוכן למנויים- </div>";
                }
            }
            else
            {
                lSingleNews.Text += $"<div class=\"text-design\">{singleNews.content}</div>";
            }
                
          
            lSingleNews.Text += "</div>";


            //תגובות
            lSingleNews.Text += "<div class=\"comments-wrap  flex-culomn-center\">";
            lSingleNews.Text += "<div class=\"comments-headLine\">תגובות</div>";
            lSingleNews.Text += "<div class=\"create-comment-wrap flex-line-center\"> <div class=\"tbx-content-wrap\"><textarea placeholder=\"הקלד/י תגובה...\" name=\"comment-content-input\" class=\"txb-comment\"></textarea></div> <div class=\"bt-post-comment-wrap\"><input type=\"submit\" name=\"btPostComment\" class=\"bt-post-comment\" value=\"&#8617;\"/></div> </div>";

            //תגובה בודדת
            lSingleNews.Text += "<div style=\"max-height:300px; overflow:scroll; width:100%; justify-content:start!important;\">";
            foreach (Comment comment in commentList.FindAll(x=>(x.news.Id == newsId)))
               {
                   lSingleNews.Text += "<div class=\"flex-culomn-center comment-wrap\">";
                   lSingleNews.Text += $"<div class=\"comment-head-info flex-line-center\"> <div class=\"writer-name\">{comment.user.userName}</div>  <div class=\"date-published\">{comment.dateTimeAdded.ToString().Substring(0, 11).Trim()}</div> </div>";
                   lSingleNews.Text += $"<div class=\"comment-content-wrap\">{comment.content}</div>";
                   lSingleNews.Text += "</div>";
               }
            lSingleNews.Text += "</div>";

            lSingleNews.Text += "</div>";
            lSingleNews.Text += "</div>";
                             
            //חדשות בנושא
            lSingleNews.Text += "<div class=\"more-news-wrap flex-culomn-center\">";
            lSingleNews.Text += "<div class=\"more-news-headLine\">";
            lSingleNews.Text += "חדשות בנושא";
            lSingleNews.Text += "</div>";
            

            lSingleNews.Text += "<div class=\"scroll-me\">";
            foreach (NewsService.News news in AllnewsInCategory.FindAll(x => x.category.name == singleNews.category.name))
            {
                 lSingleNews.Text += "<div class=\"single-side-news-wrap flex-culomn-center\">";
                 lSingleNews.Text += $"<a href=\"singleNews.aspx?NewsId={news.Id}\"><img src=\"{news.imagePath}\" class=\"news-side-img\" /></a>";
                 lSingleNews.Text += $"<div class=\"side-news-headLine\">{news.headLine}</div>";
                 lSingleNews.Text += "</div>";
                 i++;
            }
            lSingleNews.Text += "</div>";


            lSingleNews.Text += "</div>";                
            lSingleNews.Text += "</div>";
            lSingleNews.Text += "</div>";
        }

        public void addComment()
        {
            //קבלת נתונים ובדיקות
            if (Session["user"] == null)
            {
                //לבינתיים
                Response.Redirect("logIn.aspx");
            }
            int.TryParse(Session["userId"].ToString(), out int userId);
            int.TryParse(Request["NewsId"].ToString(), out int newsId);

            Comment commentToAdd = new Comment();
            //חדשות
            UserNewsInteractionService.News newsToAdd = new UserNewsInteractionService.News();
            newsToAdd.Id = newsId;

            //משתמש
            UserNewsInteractionService.User userToAdd = new User();
            userToAdd.Id = userId;

            commentToAdd.content = Request.Form["comment-content-input"];
            commentToAdd.dateTimeAdded = DateTime.Now;
            commentToAdd.news = newsToAdd;
            commentToAdd.user = userToAdd;

            userNewsInteractionClient.Add(EnumsuserNewsInteracrionType.comment, commentToAdd);
            populate();

        }
    }
}