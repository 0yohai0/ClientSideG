using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using theResearchSite.UserNewsInteractionService;
using theResearchSite.CategoryService;
using System.Drawing;

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
            else if (!IsPostBack)
            {
                FavoriteList Allfavorites = userNewsInteractionClient.selectAllFavorits();
                Session["favorites"] = Allfavorites;
                populate(Allfavorites);
            }
        }
        public void populate(FavoriteList favorites)
        {
           //איפוס
           ddlCategory.Items.Clear();
           //מילוי שורת חיפוש
           CategoriesClient categoriesClient = new CategoriesClient();
            ddlCategory.Items.Add(new ListItem("בחר/י קטגוריה", "choose"));
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataTextField = "name";
            foreach(CategoryService.Category category in categoriesClient.selectAll())
            {
                ddlCategory.Items.Add(new ListItem(category.name, category.Id.ToString()));
            }

            lFavorites.Text = "";

            //סינון רשימה למועדפים של משתמש מסוים
            int.TryParse(Session["userId"].ToString(), out int userId);
            foreach(Favorite favorite in favorites.FindAll(x=>(x.user.IdUser != userId)))
            {
                favorites.Remove(favorite);
            }


            //הצגת המועדפים
            if(favorites.Count == 0)
            {
                lFavorites.Text = "<div class=\"empty-favorites-message\">אין כרגע מועדפים...</div>";
            }
            else
            {
                lFavorites.Text += "<div class=\"body-wrap\"> <table class=\"tb-favorites\">";
                lFavorites.Text += "<tr>";
                int i = 0;
                foreach (Favorite favorite in favorites)
                {
                    lFavorites.Text += "<td><table>";
                    lFavorites.Text += $"<tr><td class=\"img-td\"><a href=\"singleNews.aspx?NewsId={favorite.news.Id}\"><img class=\"favorite-img\" src=\"{favorite.news.imagePath}\"/></a></td></tr>";
                    lFavorites.Text += $"<tr><td class=\"news-head\"> {favorite.news.headLine}</td></tr>";
                    lFavorites.Text += "</table></td>";
                    i++;
                    if (i % 4 == 0)
                    {
                        lFavorites.Text += "</tr><tr>";
                    }
                }
                lFavorites.Text += "</tr></table></div>";
            }
        }

        protected void btSendDemarc_Click(object sender, EventArgs e)
        {
            CommentList comments = userNewsInteractionClient.selectAllComments();
            FavoriteList favorites = new FavoriteList();
            if (Session["changedFavorites"] == null)
            {
                foreach (Favorite favorite in (FavoriteList)Session["favorites"])
                {
                    favorites.Add(favorite);
                }
            }
            else
            {
                favorites = (FavoriteList)Session["changedFavorites"];
            }
           
            //מידע לתיחום
            string name = txbHeadLine.Text;
            if(name.Length>0)
            {
                foreach(Favorite favorite in ((FavoriteList)Session["favorites"]).FindAll(x=>!(x.news.headLine.Contains(name))))
                {
                    favorites.Remove(favorite);
                }
            }

            int commentCount = 0;
            if(ddlHasComment.SelectedIndex != -1 && ddlHasComment.SelectedIndex != 0)
            {
                if (ddlHasComment.SelectedValue.ToString() == "no")
                {
                    commentCount = 0;
                    foreach (Favorite favorite in ((FavoriteList)Session["favorites"]).FindAll(x => x.user.IdUser == (int)Session["userId"]))
                    {
                        commentCount = 0;
                        foreach (Comment comment in comments.FindAll(x => x.news.Id == favorite.news.Id && x.user.IdUser == (int)Session["userId"]))
                        {
                            commentCount++;
                        }
                        if (commentCount == 0)
                        {
                            favorites.Remove(favorite);
                        }
                    }
                }

                if (ddlHasComment.SelectedValue.ToString() == "yes")
                {
                    commentCount = 0;
                    foreach (Favorite favorite in ((FavoriteList)Session["favorites"]).FindAll(x => x.user.IdUser == (int)Session["userId"]))
                    {
                        commentCount = 0;
                        foreach (Comment comment in comments.FindAll(x => x.news.Id == favorite.news.Id && x.user.IdUser == (int)Session["userId"]))
                        {
                            commentCount++;
                        }
                        if (commentCount > 0)
                        {
                            favorites.Remove(favorite);
                        }
                    }
                }


            }
            //חיתוך לפי קטגוריה
            if(ddlCategory.SelectedIndex!=0 && ddlCategory.SelectedIndex!=-1)
            {
                foreach (Favorite favorite in ((FavoriteList)Session["favorites"]).FindAll(x => x.news.category.Id.ToString() != ddlCategory.SelectedValue.ToString()))
                {
                    favorites.Remove(favorite);
                }
            }
            Session["changedFavorites"] = favorites;
            populate(favorites);
        }

        protected void btSendSorting_Click(object sender, EventArgs e)
        {
            FavoriteList favorites = new FavoriteList();
            FavoriteList Sortedfavorites = new FavoriteList();
            if (Session["changedFavorites"] == null)
            {
                foreach (Favorite favorite in (FavoriteList)Session["favorites"])
                {
                    favorites.Add(favorite);
                }
            }
            else
            {
                favorites = (FavoriteList)Session["changedFavorites"];
            }
            //************
            if(ddlSortDirection.SelectedIndex != -1 && ddlSortDirection.SelectedIndex!=0)
            {
                if (ddlSortDirection.SelectedValue == "up")
                {
                    if (rbFavoritedDate.Checked)
                    {
                        foreach (Favorite favorite in favorites.OrderBy(x => x.dateTimeAdded))
                        {
                            Sortedfavorites.Add(favorite);
                        }
                    }
                    if (rbNewsDatePost.Checked)
                    {
                        foreach (Favorite favorite in favorites.OrderBy(x => x.news.dateTimePublished))
                        {
                            Sortedfavorites.Add(favorite);
                        }
                    }
                }
                if(ddlSortDirection.SelectedValue=="down")
                {
                    if (rbFavoritedDate.Checked)
                    {
                         foreach (Favorite favorite in favorites.OrderByDescending(x => x.dateTimeAdded))
                         {
                             Sortedfavorites.Add(favorite);
                         }
                    }
                    if (rbNewsDatePost.Checked)
                    {
                        foreach (Favorite favorite in favorites.OrderByDescending(x => x.news.dateTimePublished))
                        {
                            Sortedfavorites.Add(favorite);
                        }
                    }
                }
            }
           
            //************
            Session["changedFavorites"] = Sortedfavorites;
            populate(Sortedfavorites);
        }

        protected void btResetDemarc_Click(object sender, EventArgs e)
        {
            txbHeadLine.Text = "";
            ddlCategory.SelectedIndex = -1;
            ddlHasComment.SelectedIndex = -1;
        }

        protected void btResetSort_Click(object sender, EventArgs e)
        {
            ddlSortDirection.SelectedIndex = -1;
            rbFavoritedDate.Checked = false;
            rbNewsDatePost.Checked = false;
        }

        protected void btResetFavorites_Click(object sender, EventArgs e)
        {
            Session["changedFavorites"] = null;
            populate((FavoriteList)Session["favorites"]);
        }
    }
}