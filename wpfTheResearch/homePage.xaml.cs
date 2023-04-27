using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Policy;
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
using wpfTheResearch;
using wpfTheResearch.HumanService;
using wpfTheResearch.ValidationService;
using WpfViewModelTheResearch;

namespace viewModelWpfTheResearch
{

    /// <summary>
    /// Interaction logic for homePage.xaml
    /// </summary>
   
    public partial class homePage : Page
    {
        public homePage()
        {
            InitializeComponent();
            if (Application.GetCookie(new Uri(@"C:\Junk\PersMC")) != null)
            {
                string cookieContent = Application.GetCookie(new Uri(@"C:\Junk\PersMC"));
                string[] towParts = cookieContent.Split(';');
                string[] email = towParts[0].Split('=');
                string[] password = towParts[1].Split('=');

                txbEmail.Text = email[1];
                txbPassword.Text = password[1];
            }
        }
        private void btLogIn_Click(object sender, RoutedEventArgs e)
        {
            string email = txbEmail.Text;
            string password = txbPassword.Text;

            HumanClient humanClient = new HumanClient();         
            User user = new User() { email = email, password = password };
            UserList Allusers = humanClient.selectAllUsers();
            User TestUser = Allusers.Find(x=>(x.email == user.email) && (x.password == user.password));

            //בדיקת מייל לפי רנד
            ValidationSoapClient validationSoapClient = new ValidationSoapClient();
            if (!validationSoapClient.isEmail(email))
            {
                emailError.Text = "אימייל לא תקין";
            }
            if(TestUser == null)
            {
                //משתמש לא קיים
                return; 
            }

            string result = TestUser.authLevel.name;
            if (result == "מנהל")
            {


                AuthorizationControl.authAdmin = true;

                string cookieEmail = $"email={txbEmail.Text};expires=Sat, 12-Oct-2024 00:00:00 GMT";
                string cookiePassword = $"password={txbPassword.Text};expires=Sat, 12-Oct-2024 00:00:00 GMT";

                Uri cookieUrui1 = new Uri(@"C:\Junk\PersMC");
                Uri cookieUrui2 = new Uri(@"C:\Junk\PersMC");

                Application.SetCookie(cookieUrui1, cookieEmail);
                Application.SetCookie(cookieUrui2 , cookiePassword);

                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new showUsers());
            }

        }
    }
}
