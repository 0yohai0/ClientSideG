using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using theResearchSite.AuthService;
using theResearchSite.NewsService;

namespace theResearchSite
{
    public partial class GvNews : System.Web.UI.Page
    {
        AuthClient authClient = new AuthClient();
        AuthLevelList auths;
        NewsClient newsClient = new NewsClient();
        NewsList news;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["admin"]==null)
            //{
            //    Response.Redirect("homePage.aspx");
            //}
            if(!IsPostBack)
            {
                //שמירה בסשיון
                if (Session["news"] == null)
                {
                    Session["news"] = newsClient.selectAll();
                    Session["copy"] = newsClient.selectAll();
                }
                if (Session["auths"] == null)
                {
                    Session["auths"] = authClient.selectAll();
                }
                populate();
            }
        }
        public void populate()
        {
            news = (NewsList)Session["news"];
            gvNews.DataSource = news;
            gvNews.DataBind();

            auths = (AuthLevelList)Session["auths"];
            DropDownList ddlAuthsDemarc = (DropDownList)gvNews.FooterRow.FindControl("ddlAuthsDemarc");
            ddlAuthsDemarc.DataSource = auths;
            ddlAuthsDemarc.DataTextField = "name";
            ddlAuthsDemarc.DataValueField = "Id";
            ddlAuthsDemarc.DataBind();

        }


        protected void gvNews_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvNews.EditIndex = e.NewEditIndex;
            populate();
        }
        protected void gvNews_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvNews.EditIndex = -1;
            populate();
        }

        protected void gvNews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            NewsList CurrentNewsList = new NewsList();
            CurrentNewsList = (NewsList)Session["news"];

            Label idStr = (Label)gvNews.Rows[e.RowIndex].FindControl("Label1");
            int.TryParse(idStr.Text, out int idNews);

            TextBox txbHeadLine = (TextBox)gvNews.Rows[e.RowIndex].FindControl("txbHeadLine");
            TextBox txbSecTitle = (TextBox)gvNews.Rows[e.RowIndex].FindControl("txbSecTitle");
            TextBox txbImgPath = (TextBox)gvNews.Rows[e.RowIndex].FindControl("txbImgPath");
            TextBox txbDatePublished = (TextBox)gvNews.Rows[e.RowIndex].FindControl("txbDatePublished");
            DropDownList Auths = (DropDownList)gvNews.Rows[e.RowIndex].FindControl("ddlAuths");

            DateTime.TryParse(txbDatePublished.Text, out DateTime dateTimePublished);

            int.TryParse(Auths.SelectedValue, out int authId);
            string authName = Auths.SelectedItem.ToString();

            NewsService.AuthLevel currentAuth = new NewsService.AuthLevel();
            currentAuth.Id = authId;
            currentAuth.name = authName;

            News currentNews = new News();
            currentNews.Id = idNews;
            currentNews.headLine = txbHeadLine.Text;
            currentNews.secondaryTitle = txbSecTitle.Text;
            currentNews.AuthLevel = currentAuth;
            currentNews.dateTimePublished = dateTimePublished;
            currentNews.imagePath = txbImgPath.Text;

            foreach(News news in CurrentNewsList.FindAll(x =>x.Id == idNews))
            {
                currentNews.content = news.content;
                CurrentNewsList.Remove(news);
            }
            CurrentNewsList.Add(currentNews);
            newsClient.Update(currentNews);
            gvNews.EditIndex = -1;

            Session["news"] = CurrentNewsList;
            populate();
        }

        protected void gvNews_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            NewsList CurrentNews = new NewsList();
            CurrentNews = (NewsList)Session["news"];

            AuthLevelList CurrentAuth = new AuthLevelList();
            CurrentAuth = (AuthLevelList)Session["auths"]; 


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate) ||
                    e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Normal)
                    )
                {
                    DropDownList dllAuths = (DropDownList)e.Row.FindControl("ddlAuths");
                    dllAuths.DataSource = CurrentAuth;
                    dllAuths.DataTextField = "name";
                    dllAuths.DataValueField = "Id";
                    dllAuths.DataBind();
                }
            }
        }

        protected void gvNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            NewsList CurrentNews = new NewsList();
            CurrentNews = (NewsList)Session["news"];
                
            NewsList tNewsDemarced = new NewsList();
            tNewsDemarced = CurrentNews;

            if (e.CommandName == "demarc")
            {
                TextBox txbId = (TextBox)gvNews.FooterRow.FindControl("txbIdDemarc");
                TextBox txbHeadLine = (TextBox)gvNews.FooterRow.FindControl("txbHeadLineDemarc");

                int.TryParse(txbId.Text, out int IdNews);
                string headLine = txbHeadLine.Text;
                //TextBox txbDateTime = (TextBox)gvNews.FooterRow.FindControl("clDatePublishedDemarc");
                DropDownList ddlDemarc = (DropDownList)gvNews.FooterRow.FindControl("ddlAuthsDemarc");
                string AuthName = ddlDemarc.SelectedItem.ToString();

                if (IdNews > 0)
                {
                    foreach (News news in tNewsDemarced.FindAll(x => x.Id != IdNews))
                    {
                        tNewsDemarced.Remove(news);
                    }
                }
                if (headLine.Length > 0)
                {
                    foreach (News news in tNewsDemarced.FindAll(x => x.headLine != headLine))
                    {
                        tNewsDemarced.Remove(news);
                    }
                }
                if (AuthName.Length > 0)
                {
                    foreach (News news in tNewsDemarced.FindAll(x => x.AuthLevel.name != AuthName))
                    {
                        tNewsDemarced.Remove(news);
                    }
                }
                Session["news"] = tNewsDemarced;
                populate();
            }
            if(e.CommandName == "clear")
            {
                Session["news"] = (NewsList)Session["copy"];
                populate();
            }
        }
        public string getDirection(string sortExpression)
        {
            if (ViewState[sortExpression] == null)
            {
                ViewState[sortExpression] = "Desc";
            }
            ViewState[sortExpression] = ViewState[sortExpression].ToString() == "Desc" ? "Asc" : "Desc";

            return ViewState[sortExpression].ToString();
        }

        protected void gvNews_Sorting(object sender, GridViewSortEventArgs e)
        {
            NewsList CurrentNews = new NewsList();
            CurrentNews = (NewsList)Session["news"];

            string sortExpression = e.SortExpression;
            string dirc = getDirection(sortExpression);
            NewsList sortedNews = new NewsList();
            if(dirc == "Asc")
            {
                if (sortExpression == "IdNews")
                {
                    foreach (News news in CurrentNews.OrderBy(x => x.Id))
                    {
                        sortedNews.Add(news);
                    }
                }
                if (sortExpression == "HeadLine")
                {
                    foreach (News news in CurrentNews.OrderBy(x => x.headLine))
                    {
                        sortedNews.Add(news);
                    }
                }
                if (sortExpression == "seconderyTitle")
                {
                    foreach (News news in CurrentNews.OrderBy(x => x.secondaryTitle))
                    {
                        sortedNews.Add(news);
                    }
                }
                if (sortExpression == "dateTimePublished")
                {
                    foreach (News news in CurrentNews.OrderBy(x => x.headLine))
                    {
                        sortedNews.Add(news);
                    }
                }
                if (sortExpression == "IdAuthLevelNeeded")
                {
                    foreach (News news in CurrentNews.OrderBy(x => x.AuthLevel.name))
                    {
                        sortedNews.Add(news);
                    }
                }
            }
            if(dirc== "Desc")
            {
                if (sortExpression == "IdNews")
                {
                    foreach (News news in CurrentNews.OrderByDescending(x => x.Id))
                    {
                        sortedNews.Add(news);
                    }
                }
                if (sortExpression == "HeadLine")
                {
                    foreach (News news in CurrentNews.OrderByDescending(x => x.headLine))
                    {
                        sortedNews.Add(news);
                    }
                }
                if (sortExpression == "seconderyTitle")
                {
                    foreach (News news in CurrentNews.OrderByDescending(x => x.secondaryTitle))
                    {
                        sortedNews.Add(news);
                    }
                }
                if (sortExpression == "dateTimePublished")
                {
                    foreach (News news in CurrentNews.OrderByDescending(x => x.headLine))
                    {
                        sortedNews.Add(news);
                    }
                }
                if (sortExpression == "IdAuthLevelNeeded")
                {
                    foreach (News news in CurrentNews.OrderByDescending(x => x.AuthLevel.name))
                    {
                        sortedNews.Add(news);
                    }
                }
            }
            Session["news"] = sortedNews;
            populate();

        }
    }
}