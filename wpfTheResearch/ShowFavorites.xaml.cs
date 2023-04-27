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
using viewModelWpfTheResearch;
using wpfTheResearch.HumanService;
using wpfTheResearch.NewsService;
using wpfTheResearch.UserNewsInteractionService;
using WpfViewModelTheResearch;

namespace wpfTheResearch
{
    /// <summary>
    /// Interaction logic for ShowFavorites.xaml
    /// </summary>
    public partial class ShowFavorites : Page
    {
        static int i=1;
        FavoriteList favorites = new FavoriteList();
        UserNewsInteractionClient UserNewsInteractionClient = new UserNewsInteractionClient();
        NewsClient newsClient = new NewsClient();
        HumanClient HumanClient = new HumanClient();
        Favorite favorite = new Favorite();

        public ShowFavorites()
        {
            InitializeComponent();
            favorites = UserNewsInteractionClient.selectAllFavorits();


            //לתיחומים
            cmbDemarcUser.ItemsSource = HumanClient.selectAllUsers();
            cmbDemarcNews.ItemsSource = newsClient.selectAll();

            populate(favorites);
        }
        public void populate(FavoriteList list)
        {
            lvFavorites.ItemsSource = null;
            lvFavorites.ItemsSource = list;
        }
        private void lvFavorites_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvFavorites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            favorite = lvFavorites.SelectedItem as Favorite;
        }

        private void btDemarcation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {

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
