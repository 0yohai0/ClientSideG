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
using wpfTheResearch.AuthService;
using wpfTheResearch.HumanService;
using WpfViewModelTheResearch;

namespace wpfTheResearch
{
    /// <summary>
    /// Interaction logic for ShowWorkers.xaml
    /// </summary>

    public delegate int WorkerActions(Worker worker);
    public partial class ShowWorkers : Page
    {
        static int i = 1;
        HumanClient HumanClient = new HumanClient();
        AuthClient authClient = new AuthClient();
      

        AuthLevelList auths = new AuthLevelList();
        WorkerList workers = new WorkerList();
        Worker worker = new Worker();
        public ShowWorkers()
        {
            InitializeComponent();
            workers = HumanClient.selectAllWorkers();

            //הרשאות
            auths = authClient.selectAll();
            //מילוי רשימות יורדות
            cmbDemarc.ItemsSource = auths;
            //הצגת נתונים
            populate(workers);
        }
        public void populate(WorkerList list)
        {
            lvWorkers.ItemsSource = null;
            lvWorkers.ItemsSource = list;         
        }
        public int insertWorker(Worker workerToAdd)
        {
            workerToAdd.joinDate = DateTime.Now;
            int row = HumanClient.Add(EnumshumanType.worker, workerToAdd);
            workers.Add(workerToAdd);
            populate(workers);
            return row;
        }
        public int updateWorker(Worker workerToUpdate)
        {
            int rows = HumanClient.Update(EnumshumanType.worker, workerToUpdate);
            populate(workers);
            return rows;
        }
        private void Insert(object sender, RoutedEventArgs e)
        {
            WorkerActions insert = new WorkerActions(insertWorker);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new oneWorker(new Worker(),insert, authClient.selectAll()));
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            WorkerActions insert = new WorkerActions(updateWorker);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new oneWorker(worker, insert, authClient.selectAll()));
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            workers.Remove(worker);
            HumanClient.Remove(EnumshumanType.worker, worker);
            populate(workers);
        }

        private void lvWorkers_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorizationControl.authAdmin == false)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new homePage());
            }
        }

        private void lvWorkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            worker = lvWorkers.SelectedItem as Worker;
        }

        private void btDemarcation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            populate(workers);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
