using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using theResearchSite.UserNewsInteractionService;


namespace theResearchSite
{
    public partial class favorites : System.Web.UI.Page
    {
        
        UserNewsInteractionClient userNewsInteractionClient = new UserNewsInteractionClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"]==null)
            {
                Response.Redirect("logIn.aspx");
            }
            if (Session["newscart"] != null)
            {
                addCartFavorites();
            }
            else if (!IsPostBack)
            {
                populate();
            }
        }
        public void populate()
        {
            FavoriteList Allfavorites = userNewsInteractionClient.selectAllFavorits();


            //?
            int.TryParse(Session["userId"].ToString(), out int userId);
            foreach(Favorite favorite in Allfavorites.FindAll(x=>(x.user.IdUser != userId)))
            {
                Allfavorites.Remove(favorite);
            }


            //הצגת המועדפים
            lFavorites.Text += "<table class=\"favorite-table\"><tr>";

            foreach(Favorite favorite in Allfavorites)
            {
                lFavorites.Text += $"<table class=\"single-news\"><tr><td> <a href=\"singleNews.aspx?NewsId={favorite.news.Id}\"> <img class=\"Minor3Img\" src=\"{favorite.news.imagePath}\"/></a></td>";
                lFavorites.Text += $"<td> <div class=\"infoWrap\"> <div class=\"headLineNews\">{favorite.news.headLine}</div>  <div class=\"second-title\">  <div> {favorite.news.secondaryTitle.Trim()}</div> <div class=\"date-stuff\"> <div class=\"stuff-names\"></div>   <div class=\"date\">תאריך פרסום:{favorite.news.dateTimePublished.Date.ToString().Substring(0, 11).Trim()}</div> </div> </div> </div> </td></tr></table>";

            }
            lFavorites.Text += "</tr>/<table>";

        }
        //צריך לבדוק
        public void addCartFavorites()
        {
            bool ExistAllready = false;
           int.TryParse(Session["userId"].ToString(), out int userId);
            FavoriteList AllFavorites = userNewsInteractionClient.selectAllFavorits();
            ArrayList newsCart = (ArrayList)Session["newscart"];
            //בדיקה האם כבר קיים אז לא להוסיף
            foreach (int newsId in newsCart)
            {
                ExistAllready = false;
                foreach (Favorite favoriteTest in AllFavorites.FindAll(x=>x.user.IdUser==userId))
                {
                    if (favoriteTest.news.Id == newsId)
                        ExistAllready = true;
                }
                if (!ExistAllready)
                {
                    //מילוי המועדף במידע נחוץ
                    Favorite favorite = new Favorite();
                    favorite.news = new News();
                    favorite.news.Id = newsId;
                    favorite.user = new User();
                    favorite.user.Id = userId;
                    favorite.dateTimeAdded = DateTime.Now.Date;
                    userNewsInteractionClient.Add(EnumsuserNewsInteracrionType.favorite, favorite);
                }

            }
                populate();

        }

    }
}