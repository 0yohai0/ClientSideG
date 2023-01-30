using ModelTheResearch;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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

namespace WpfViewModelTheResearch
{
    /// <summary>
    /// Interaction logic for Formula1Game.xaml
    /// </summary>
    public partial class Formula1Game : Page
    {
         static Driver driverBet;
         Driver driver1 = new Driver("אנטון");
         Driver driver2 = new Driver("ברטולומאו");
         Driver driver3 = new Driver("לואיג'י");


        RaceGameUser raceGameUser = new RaceGameUser();
        public Formula1Game()
        {
            InitializeComponent();
        }
        public void populateMoney()
        {
            tbxAmountHaving.Text = raceGameUser.MoneyInGame.ToString();
        }
        public Formula1Game(Driver driver):this()
        {
            txblInfo.Text = "המנצח הוא"+driver.Name;
            if(driver == driverBet)
            {
                raceGameUser.MoneyInGame-=100;
            }
            else
            {
                raceGameUser.MoneyInGame += 100;

            }
        }

        private void btDriver1Bet_Click(object sender, RoutedEventArgs e)
        {
            driverBet = driver1;
            UpdateBetInfo();
        }

        private void btDriver2Bet_Click(object sender, RoutedEventArgs e)
        {
            driverBet = driver2;
            UpdateBetInfo();
        }
        
        private void btDriver3Bet_Click(object sender, RoutedEventArgs e)
        {
            driverBet = driver3;
            UpdateBetInfo();
        }

        private void tbToTheRace_Click(object sender, RoutedEventArgs e)
        {
            FormulaCar car2 = new FormulaCar("black", driver2);
            FormulaCar car3 = new FormulaCar("green", driver3);
            FormulaCar car1 = new FormulaCar("white", driver1);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new  RacePage(car1,car2,car3));
        }
        public void UpdateBetInfo()
        {
            int.TryParse(tbxAmountBetting.Text, out int amount);
            txblInfo.Text =  driverBet.Name+" --> "+amount;
            raceGameUser.MoneyBet = amount;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            populateMoney();
        }
    }
}
