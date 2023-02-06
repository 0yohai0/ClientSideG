
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

            //הצגה

            lSingleNews.Text += "<table class=\"tb-single-item\"> ";
            //כותרת ראשית
            lSingleNews.Text += $" <tr> <td class=\"single-item-headLine\">{singleNews.headLine}</td> </tr>";
           //כותרת משנית        
            lSingleNews.Text += $" <tr> <td class=\"single-item-secondary-title\" >{singleNews.secondaryTitle}</td> </tr>";
            //תמונה             
            lSingleNews.Text += $" <tr> <td><img src={singleNews.imagePath} class=\"img-news\" /></td> </tr>";
            //אינטראקצית משתמש  
            lSingleNews.Text += $" <tr> <td class=\"\"><div> <divclass=\"single-item-date\">{singleNews.dateTimePublished.Date.ToString().Substring(0, 11).Trim()}</div> <div class=\"single-item-writers-and-editors\">צפיות בכתבה:{Application[Request.Url.ToString()]}</div>  </div></td> </tr>";
            //תוכן            
            lSingleNews.Text += $" <tr> <td  class=\"single-item-content\"> <div class=\"first-letter\">  {singleNews.content[0]}</div> <div style=\"display:inline;\"> {singleNews.content.Substring(1)}</div> </td> </tr>";

            lSingleNews.Text += "</table> ";

        }
    }
}