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
using wpfTheResearch.AuthService;
using wpfTheResearch.HumanService;
using WpfViewModelTheResearch;


namespace viewModelWpfTheResearch
{
    /// <summary>
    /// Interaction logic for oneUser.xaml
    /// </summary>
    public partial class oneUser : Page
    {
        private UserActions action;
        User user = new User();
        AuthLevelList auths;

        public oneUser()
        {
            InitializeComponent();
        }
        public oneUser(UserActions action, User user, AuthLevelList authList) : this()
        {
            this.action = action;
            this.user = user;
           this.auths = authList;
            txbUserName.DataContext = user;
            txbEmail.DataContext = user;
            txbPassword.DataContext = user;
            cmbAuths.ItemsSource = auths;
            cmbAuths.DataContext = user.authLevel;
            cmbAuths.SelectedValuePath = "Id";
            cmbAuths.DisplayMemberPath = "name";

        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            int result = action(user);
            if (result == 0)
            {
                //שגיאה 
            }
            if (result == 2)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);

                if (nav.CanGoBack)
                    nav.GoBack();
            }
            if (result > 2)
            {
                //שגיאה שאין כדוגמתה
            }
        }

        private void cmbAuths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbAuths.SelectedItem != null)
            {
                wpfTheResearch.HumanService.AuthLevel newAuth = new wpfTheResearch.HumanService.AuthLevel();
                int.TryParse(cmbAuths.SelectedValue.ToString(), out int id);
                newAuth.Id = id;
                wpfTheResearch.AuthService.AuthLevel authT = new wpfTheResearch.AuthService.AuthLevel();
                authT = (wpfTheResearch.AuthService.AuthLevel)cmbAuths.SelectedItem;
                newAuth.name = authT.name;
                user.authLevel = newAuth;
            }
        }
    }
}
