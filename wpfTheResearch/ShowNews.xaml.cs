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
using viewModelWpfTheResearch;
using WpfViewModelTheResearch;

namespace wpfTheResearch
{
    /// <summary>
    /// Interaction logic for ShowNews.xaml
    /// </summary>

    public partial class ShowNews : Page
    {
        //חדשות
        NewsList newsList = new NewsList();
        NewsClient newsClient = new NewsClient();
        NewsService.News currentNews;

        //קטגוריות
        CategoryList categories = new CategoryList();
        CategoriesClient categoriesClient = new CategoriesClient();

        //הרשאות
        AuthLevelList authLevels = new AuthLevelList();
        AuthClient authClient = new AuthClient();

        //תגובות
        UserNewsInteractionClient UserNewsInteractionClient = new UserNewsInteractionClient();
        CommentList comments = new CommentList();
        public ShowNews()
        {
            InitializeComponent();
            newsList = newsClient.selectAll();
            populate(newsList);

            comments = UserNewsInteractionClient.selectAllComments();

            //מילוי רשימות יורדות לתיחום
            cmbNewsAuthDemarc.ItemsSource = authClient.selectAll();
            cmbNewsAuthDemarc.SelectedValuePath = "Id";
            cmbNewsAuthDemarc.DisplayMemberPath = "name";

            cmbNewsCategoryDemarc.ItemsSource = categoriesClient.selectAll();
            cmbNewsCategoryDemarc.SelectedValuePath = "Id";
            cmbNewsCategoryDemarc.DisplayMemberPath = "name";


        }
        public void populate(NewsList list)
        {
            //איפוס
            wpNews.Children.Clear();

            foreach (NewsService.News news in list)
            {                   
                //stack-panel
                StackPanel spNews = new StackPanel();
                spNews.Width = 200;
                spNews.Height = 120;

                //כותרת
                Label lheadLine = new Label();
                lheadLine.Content = news.headLine;
                lheadLine.HorizontalAlignment = HorizontalAlignment.Center;

                //הוספת הכותרת לדיב
                spNews.Children.Add(lheadLine);

                //הוספת תמונה
                Image image = new Image();
                image.Name = "img" + news.Id;
                image.Width = 200;
                image.HorizontalAlignment = HorizontalAlignment.Center;
                image.Source = new BitmapImage(new Uri(news.imagePath, UriKind.Relative));

                image.MouseLeftButtonUp += new MouseButtonEventHandler(SendToSinglePage);
                spNews.Children.Add(image);


                //כמו דיב
                Border border = new Border();
                border.Width = 220;
                border.Height = 150;
                border.Child = spNews;
        
                wpNews.Children.Add(border);
            }
        }

        public void SendToSinglePage(object sender,EventArgs e )
        {
            Image newimage = new Image();
            string imgSrc = ((Image)sender).Name.Substring(3);
            int.TryParse(imgSrc, out int newsId);

            //מציאת חדשה שלחצו עליה
            currentNews = newsList.Find(x => x.Id == newsId);

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new singleNews(currentNews));


        }

        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            NewsList newsDemarc = new NewsList();
            foreach(NewsService.News news in newsList)
            {
                newsDemarc.Add(news);
            }


            //תיחומים
            if(txbNewsNameDemarc.Text != "")
            {
                foreach(NewsService.News news in newsDemarc.FindAll(x=>x.headLine != txbNewsNameDemarc.Text))
                {
                    newsDemarc.Remove(news);
                }
            }
            if(cmbNewsAuthDemarc.SelectedIndex != -1)
            {
                foreach (NewsService.News news in newsDemarc.FindAll(x => x.AuthLevel.Id.ToString() != cmbNewsAuthDemarc.SelectedValue.ToString()))
                {
                    newsDemarc.Remove(news);
                }
            }
            if (cmbNewsCategoryDemarc.SelectedIndex != -1)
            {
                foreach (NewsService.News news in newsDemarc.FindAll(x => x.category.Id.ToString() != cmbNewsCategoryDemarc.SelectedValue.ToString()))
                {
                    newsDemarc.Remove(news);
                }
            }
            //לבדוק מיונים אחרי מילוי מידע
            //מיונים
            NewsService.NewsList sortedNews = new NewsList();
            if(rbAsc.IsChecked == true)
            {
                if (cbComments.IsChecked == true)
                {
                    List<sortHelper> newsByComments = sortHelper.sortByCommentsList(newsList, comments);
                    newsByComments = newsByComments.OrderBy(x=>x.getQuantity()).ToList();   
                    foreach(sortHelper newsByComment in newsByComments)
                    {
                        sortedNews.Add(newsDemarc.Find(x => x.Id == newsByComment.getNews().Id));
                    }

                }
                if(cbDate.IsChecked == true)
                {
                    foreach(NewsService.News news in sortedNews.OrderBy(x=>x.dateTimePublished))
                    {
                        sortedNews.Add(news);
                    }
                }
                if(cbViews.IsChecked == true)
                {
                    foreach (NewsService.News news in sortedNews.OrderBy(x => x.viewsCount))
                    {
                        sortedNews.Add(news);
                    }
                }
                populate(sortedNews);
                    return;
            }

            if(rbDesc.IsChecked == true)
            {
                if (cbComments.IsChecked == true)
                {
                    List<sortHelper> newsByComments = sortHelper.sortByCommentsList(newsList, comments);
                    newsByComments = newsByComments.OrderByDescending(x => x.getQuantity()).ToList();

                    foreach (sortHelper newsByComment in newsByComments)
                    {
                        sortedNews.Add(newsDemarc.Find(x => x.Id == newsByComment.getNews().Id));
                    }
                }
              

                if (cbDate.IsChecked == true)
                {
                    foreach (NewsService.News news in sortedNews.OrderByDescending(x => x.dateTimePublished))
                    {
                        sortedNews.Add(news);
                    }
                }
                if (cbViews.IsChecked == true)
                {
                    foreach (NewsService.News news in sortedNews.OrderByDescending(x => x.viewsCount))
                    {
                        sortedNews.Add(news);
                    }
                }
                populate(sortedNews);
                return;
            }
           

            populate(newsDemarc);
        }
        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            cmbNewsAuthDemarc.SelectedIndex = -1;
            cmbNewsCategoryDemarc.SelectedIndex = -1;
            cbComments.IsChecked = false;
            cbDate.IsChecked = false;
            cbViews.IsChecked = false;

            populate(newsList);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (AuthorizationControl.authAdmin == false)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new homePage());
            }
        }
    }
}
