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

namespace wpfTheResearch
{
    /// <summary>
    /// Interaction logic for oneAuth.xaml
    /// </summary>
    /// 
    public partial class oneAuth : Page
    {
        AuthAction authAction;
        AuthLevel auth;
        public oneAuth()
        {
            InitializeComponent();
        }
        public oneAuth(AuthAction action, AuthLevel authLevel):this()
        {
            authAction = action;
            auth = authLevel;
            DataContext = auth;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            int result = authAction(auth);
            //בדיקות תוצאות
            if(result == 0)
            {

            }
            if (result == 1)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                if (nav.CanGoBack)
                    nav.GoBack();
            }
            if (result > 1)
            {
                //שגיאה שעדיין, אין כדוגמתה
            }
        }
    }
}
