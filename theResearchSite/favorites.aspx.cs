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
            foreach(Favorite favorite in Allfavorites)
            {


            }

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