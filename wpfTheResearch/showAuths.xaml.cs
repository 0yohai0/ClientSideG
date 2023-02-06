using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
using wpfTheResearch.AuthService;

namespace wpfTheResearch
{
    /// <summary>
    /// Interaction logic for showAuths.xaml
    /// </summary>
    public delegate int AuthAction(AuthLevel authLevel);
    public partial class showAuths : Page
    {
        static int i=1;
        AuthLevelList authLevels;
        AuthLevel authLevel = new AuthLevel();
        AuthClient authClient = new AuthClient();

        public int insertAuth(AuthLevel auth)
        {
            int result = authClient.Add(auth);
            authLevels.Add(auth);
            populate(authLevels);
            return result;
        }
        private void Insert(object sender, RoutedEventArgs e)
        {
            AuthAction authAction = new AuthAction(insertAuth);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new oneAuth(authAction, new AuthLevel()));
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            int result = authClient.remove(authLevel);
            if(result==0)
            {
                //שגיאה
            }
            if(result==1)
            {
               authLevels.Remove(authLevel);
               populate(authLevels);
            }
        }
        public showAuths()
        {
            InitializeComponent();
            AuthClient client = new AuthClient();
            authLevels = client.selectAll();
            populate(authLevels);            
        }
        public void populate(AuthLevelList authLevelsGiven)
        {
            lvAuths.ItemsSource = null;
            lvAuths.ItemsSource = authLevelsGiven;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //if (AuthorizationControl.authAdmin == false)
            //{
            //    NavigationService nav = NavigationService.GetNavigationService(this);
            //    nav.Navigate(new homePage());
            //}
        }

        private void btDemarcation_Click(object sender, RoutedEventArgs e)
        {
            string name = txbAuthName.Text;
            int.TryParse(txbIdAuth.Text, out int id);

            AuthLevelList newAuthLevels = new AuthLevelList();
            newAuthLevels = authLevels;

            if (name.Length > 0)
            {
                foreach (AuthLevel auth in newAuthLevels.FindAll(x => x.name != name))
                {
                    newAuthLevels.Remove(auth);
                }
            }
            if(id>0)
            {
                foreach (AuthLevel auth in newAuthLevels.FindAll(x => x.Id != id))
                {
                    newAuthLevels.Remove(auth);
                }
            }          
            populate(newAuthLevels);
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            populate(authLevels);
        }

        private void lvAuths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            authLevel = lvAuths.SelectedItem as AuthLevel;
        }

        public int GetDirection()
        {
            i = i * -1;
            return i;
        }

        private void lvAuths_Click(object sender, RoutedEventArgs e)
        {
            int direction = GetDirection();
            AuthLevelList authLevelsSort = new AuthLevelList();
            string colum = ((GridViewColumnHeader)e.OriginalSource).Column.Header.ToString();

            if(direction == 1)
            {

                if (colum == "שם הרשאה")
                {
                    foreach (AuthLevel auth in authLevels.OrderBy(x => x.name))
                    {
                        authLevelsSort.Add(auth);
                    }
                }
                if (colum == "מספר מזהה")
                {
                    foreach (AuthLevel auth in authLevels.OrderBy(x => x.Id))
                    {
                        authLevelsSort.Add(auth);
                    }
                }
            }
            else if(direction == -1)
            {
                if (colum == "שם הרשאה")
                {
                    foreach (AuthLevel auth in authLevels.OrderByDescending(x => x.name))
                    {
                        authLevelsSort.Add(auth);
                    }
                }
                if (colum == "מספר מזהה")
                {
                    foreach (AuthLevel auth in authLevels.OrderByDescending(x => x.Id))
                    {
                        authLevelsSort.Add(auth);
                    }
                }
            }
            populate(authLevelsSort);
        }
    }
}
