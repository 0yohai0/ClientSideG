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
            if(list.Count == 0)
            {
                StackPanel spNews = new StackPanel();
                spNews.Width = 400;
                spNews.Height = 200;

                //כותרת
                Label lheadLine = new Label();
                lheadLine.Content = "אין חדשות בעלות נתונים אלו...";
                lheadLine.HorizontalAlignment = HorizontalAlignment.Center;
                lheadLine.FontSize = 30;

                //הוספת הכותרת לדיב
                spNews.Children.Add(lheadLine);

                wpNews.Children.Add(spNews);
            }
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
          
        
        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            txbNewsNameDemarc.Text = "";
            cmbNewsAuthDemarc.SelectedIndex = -1;
            cmbNewsCategoryDemarc.SelectedIndex = -1;
            rbComments.IsChecked = false;
            rbDate.IsChecked = false;
            rbViews.IsChecked = false;
            rbAsc.IsChecked = false;
            rbDesc.IsChecked = false;


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

        private void btSort_Click(object sender, RoutedEventArgs e)
        {
            NewsList sortedNews = new NewsList();
            comments = UserNewsInteractionClient.selectAllComments();
            List<sortHelper> sortNewsByComments = sortHelper.sortByCommentsList(newsList, comments);


            if(rbAsc.IsChecked  == true)
            {
                if(rbViews.IsChecked == true)
                {
                    foreach(NewsService.News news in newsList.OrderBy(x=>x.viewsCount))
                    {
                        sortedNews.Add(news);
                    }
                }
                if (rbComments.IsChecked == true)
                {
                    foreach (sortHelper sortHelper in sortNewsByComments.OrderBy(x => x.getQuantity()))
                    {
                        foreach (NewsService.News news in newsList.FindAll(x => x.Id == sortHelper.getNews().Id))
                        {
                            sortedNews.Add(news);
                        }
                    }                   
                }
                if (rbDate.IsChecked == true)
                {
                    foreach (NewsService.News news in newsList.OrderBy(x => x.dateTimePublished))
                    {
                        sortedNews.Add(news);
                    }
                }
            }




            if (rbDesc.IsChecked == true)
            {
                if (rbViews.IsChecked == true)
                {
                    foreach (NewsService.News news in newsList.OrderByDescending(x => x.viewsCount))
                    {
                        sortedNews.Add(news);
                    }
                }
                if (rbComments.IsChecked == true)
                {
                    foreach (sortHelper sortHelper in sortNewsByComments.OrderByDescending(x => x.getQuantity()))
                    {
                        foreach (NewsService.News news in newsList.FindAll(x => x.Id == sortHelper.getNews().Id))
                        {
                            sortedNews.Add(news);
                        }
                    }
                }
                if (rbDate.IsChecked == true)
                {
                    foreach (NewsService.News news in newsList.OrderByDescending(x => x.dateTimePublished))
                    {
                        sortedNews.Add(news);
                    }
                }
            }

            populate(sortedNews);
        }

        private void btDemarc_Click(object sender, RoutedEventArgs e)
        {
            NewsList newsDemarc = new NewsList();
            foreach (NewsService.News news in newsList)
            {
                newsDemarc.Add(news);
            }


            //תיחומים
            if (txbNewsNameDemarc.Text != "")
            {
                foreach (NewsService.News news in newsDemarc.FindAll(x => x.headLine != txbNewsNameDemarc.Text))
                {
                    newsDemarc.Remove(news);
                }
            }
            if (cmbNewsAuthDemarc.SelectedIndex != -1)
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
            populate(newsDemarc);
        }
    }
}
