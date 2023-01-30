﻿using System;
using System.Collections.Generic;
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
using wpfTheResearch.HumanService;
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
        }
        private void btLogIn_Click(object sender, RoutedEventArgs e)
        {
            string email = txbEmail.Text;
            string password = txbPassword.Text;

            HumanClient humanClient = new HumanClient();         
            User user = new User() { email = email, password = password };
            UserList Allusers = humanClient.selectAllUsers();
            User TestUser = Allusers.Find(x=>(x.email == user.email) && (x.password == user.password));
            if(TestUser == null)
            {
                //משתמש לא קיים
                return;
            }

            string result = TestUser.authLevel.name;
            if (result == "מנהל")
            {
                AuthorizationControl.authAdmin = true;
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new showUsers());
            }

        }
    }
}