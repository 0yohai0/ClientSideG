using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpfTheResearch.NewsService;
using wpfTheResearch.AuthService;
using wpfTheResearch.UserNewsInteractionService;
using System.Runtime.Remoting.Channels;
using wpfTheResearch.CategoryService;
using System.Security.Cryptography.X509Certificates;

namespace wpfTheResearch
{
    /// <summary>
    /// Interaction logic for singleNews.xaml
    /// </summary>
    public partial class singleNews : Page
    {
        //חדשות
        NewsList newsList = new NewsList();
        NewsClient newsClient = new NewsClient();
        NewsService.News news;

        //קטגוריות
        CategoryList categories = new CategoryList();
        CategoriesClient categoriesClient = new CategoriesClient();

        //הרשאות
        AuthLevelList authLevels = new AuthLevelList();
        AuthClient authClient = new AuthClient();

        //תגובות
        UserNewsInteractionClient UserNewsInteractionClient = new UserNewsInteractionClient();
        CommentList comments = new CommentList();

        //מועדפים
        FavoriteList favorites = new FavoriteList();
        public singleNews()
        {
            InitializeComponent();        
        }
        public singleNews(NewsService.News news):this()
        {
            this.news = news;
            DataContext = news;

            ImgNews.DataContext = news;
            txblCategory.DataContext = news.category;
            txblAuth.DataContext = news.AuthLevel;

            txblIdNews.Text+=" "+news.Id;
            txblLength.Text = news.content.Length.ToString();

            //מילוי תגובות
            comments = UserNewsInteractionClient.selectAllComments();
            populateComments();

            //מילוי נתונים
            favorites = UserNewsInteractionClient.selectAllFavorits();
            populateStats();

        }

        public void populateComments()
        {

            foreach (Comment comment in comments.FindAll(x => x.news.Id == news.Id))
            {
                TextBlock txblComment = new TextBlock();
                txblComment.Height = 28;
                txblComment.Text = comment.user.userName +": " + comment.content;
                spComments.Children.Add(txblComment);
             
            }
        }
        public void populateStats()
        {
            FavoriteList favoritesToNews = new FavoriteList();
            foreach(Favorite favorite in favorites.FindAll(x=>x.news.Id == news.Id))
            {
                favoritesToNews.Add(favorite);
            }

            CommentList commentsToNews = new CommentList();
            foreach(Comment comment in comments.FindAll(x=>x.news.Id == news.Id))
            {
                commentsToNews.Add(comment);
            }

            txblCommentsCount.Text = commentsToNews.Count.ToString();
            txblViewsCount.Text = news.viewsCount.ToString();
            txblFavoritedCount.Text = favoritesToNews.Count.ToString();
        }
    }
}
