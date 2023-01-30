using ModelTheResearch;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfViewModelTheResearch
{
    /// <summary>
    /// Interaction logic for RacePage.xaml
    /// </summary>
    public partial class RacePage : Page
    {
        public NavigationService nav;
        public FormulaCar car1;
        public FormulaCar car2;
        public FormulaCar car3;
        public RacePage()
        {
            InitializeComponent();
        }
        public RacePage(FormulaCar car1, FormulaCar car2, FormulaCar car3) : this()
        {
            this.car1 = car1;
            this.car2 = car2;
            this.car3 = car3;
            populateRace();
        }
        public async Task populateRace()
        {
            await Task.Delay(1000);
            Formula1Race race1 = new Formula1Race(0);
            Formula1Race race2 = new Formula1Race(0);
            Formula1Race race3 = new Formula1Race(0);

            Task car1Drive = drive1(race1);
            Task car2Drive = drive2(race2);
            Task car3Drive = drive3(race3);

            await car1Drive;
            await car2Drive;
            await car3Drive;

            //יצירת אובייקט לרשימה שתתמיין לפי כמה זמן לקח לסיים מסלול
            CarInRace carInRace1 = new CarInRace(car1, race1);
            CarInRace carInRace2 = new CarInRace(car2, race2);
            CarInRace carInRace3 = new CarInRace(car3, race3);

            List<CarInRace> raceList = new List<CarInRace>();
            raceList.Add(carInRace1);
            raceList.Add(carInRace2);
            raceList.Add(carInRace3);

            raceList = raceList.OrderBy(x=>x.Formula1Race.TotalTime).ToList();
            GoWinner(raceList[0].Car.Driver);
           
        }
        public void GoWinner(Driver driver)
        {
            nav.Navigate(new Formula1Game(driver));
        }
        public async Task drive1(Formula1Race race)
        {
            for (int i = 1; i <= 50; i++)
            {
                await Task.Run(() => race.TaskRace1(car1));
                tbxlFollow1.Text += "*";
            }         
        }
        public async Task drive2(Formula1Race race)
        {
            for (int i = 1; i <= 50; i++)
            {
                await Task.Run(() => race.TaskRace2(car2));
                tbxlFollow2.Text += "*";
            }
        }
        public async Task drive3(Formula1Race race)
        {
            for (int i = 1; i <= 50; i++)
            {
                await Task.Run(() => race.TaskRace3(car3));
                tbxlFollow3.Text += "*";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);

        }
    }
}
