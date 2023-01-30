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
using wpfTheResearch;
using WpfViewModelTheResearch;

namespace viewModelWpfTheResearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void hmiHomePage_Selected(object sender, RoutedEventArgs e)
        {
            currentFrame.Navigate(new homePage());
        }

        private void hmiShowUsers_Selected(object sender, RoutedEventArgs e)
        {
            currentFrame.Navigate(new showUsers());
        }

        private void hmilogOut_Selected(object sender, RoutedEventArgs e)
        {
            AuthorizationControl.authAdmin = false;
            currentFrame.Navigate(new homePage());

        }

        private void hmiFormula1Game_Selected(object sender, RoutedEventArgs e)
        {
            currentFrame.Navigate(new Formula1Game());
        }

        private void hmiabout_Selected(object sender, RoutedEventArgs e)
        {
            currentFrame.Navigate(new about());
        }


    }
}
