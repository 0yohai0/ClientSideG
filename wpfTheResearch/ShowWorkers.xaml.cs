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
using System.Xml.Linq;
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
            workers = HumanClient.selectAllWorkers();
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
           
            int direction = GetDirection();
            WorkerList workersNow = new WorkerList();
            string colum = ((GridViewColumnHeader)e.OriginalSource).Column.Header.ToString();

            if (direction == 1)
            {
                if (colum == "שם")
                {
                    foreach (Worker worker in workers.OrderBy(x => x.name))
                    {
                        workersNow.Add(worker);                    
                    }
                }
                if (colum == "מספר מזהה")
                {
                    foreach (Worker worker in workers.OrderBy(x => x.Id))
                    {
                        workersNow.Add(worker);
                    }
                }
                if (colum == "ססמה")
                {
                    foreach (Worker worker in workers.OrderBy(x => x.password))
                    {
                        workersNow.Add(worker);
                    }
                }
                if (colum == "אימייל")
                {
                    foreach (Worker worker in workers.OrderBy(x => x.email))
                    {
                        workersNow.Add(worker);
                    }
                }
                if (colum == "רמת הרשאה")
                {
                    foreach (Worker worker in workers.OrderBy(x => x.authLevel.name))
                    {
                        workersNow.Add(worker);
                    }
                }
            }

            else if (direction == -1)
            {
                if (colum == "שם")
                {
                    foreach (Worker worker in workers.OrderByDescending(x => x.name))
                    {
                        workersNow.Add(worker);
                    }
                }
                if (colum == "מספר מזהה")
                {
                    foreach (Worker worker in workers.OrderByDescending(x => x.Id))
                    {
                        workersNow.Add(worker);
                    }
                }
                if (colum == "ססמה")
                {
                    foreach (Worker worker in workers.OrderByDescending(x => x.password))
                    {
                        workersNow.Add(worker);
                    }
                }
                if (colum == "אימייל")
                {
                    foreach (Worker worker in workers.OrderByDescending(x => x.email))
                    {
                        workersNow.Add(worker);
                    }
                }
                if (colum == "רמת הרשאה")
                {
                    foreach (Worker worker in workers.OrderByDescending(x => x.authLevel.name))
                    {
                        workersNow.Add(worker);
                    }
                }
            }
            populate(workersNow);
        }

        private void lvWorkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            worker = lvWorkers.SelectedItem as Worker;
        }

        private void btDemarcation_Click(object sender, RoutedEventArgs e)
        {
            WorkerList workersNow = new WorkerList();
            foreach (Worker worker in workers)
            {
                workersNow.Add(worker);
            }


            int.TryParse(txbIdWorker.Text, out int Id);


            string name = txbWorkerName.Text;

            string email = txbEmail.Text;

            string password = txbPassword.Text;

            wpfTheResearch.AuthService.AuthLevel newAuth = new wpfTheResearch.AuthService.AuthLevel();
            if (cmbDemarc.SelectedItem != null)
            {
                newAuth = cmbDemarc.SelectedItem as wpfTheResearch.AuthService.AuthLevel;
            }
            if (name.Length > 0)
            {
                foreach (Worker worker in workersNow.FindAll(x => (x.name != name)))
                {
                    workersNow.Remove(worker);
                }
            }
            if (Id != 0)
            {
                foreach (Worker worker in workersNow.FindAll(x => (x.Id != Id)))
                {
                    workersNow.Remove(worker);
                }
            }
            if (email.Length > 0)
            {
                foreach (Worker worker in workersNow.FindAll(x => (x.email != email)))
                {
                    workersNow.Remove(worker);
                }
            }
            if (password.Length > 0)
            {
                foreach (Worker worker in workersNow.FindAll(x => (x.password != password)))
                {
                    workersNow.Remove(worker);
                }
            }
            if (newAuth != null && newAuth.name != null && newAuth.name.Length > 0)
            {
                foreach (Worker worker in workersNow.FindAll(x => (x.authLevel.name != newAuth.name)))
                {
                    workersNow.Remove(worker);
                }
            }
            populate(workersNow);
        }
        public int GetDirection()
        {
            i = i * -1;
            return i;
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            populate(workers);
            txbIdWorker.Text = "";
            txbEmail.Text = "";
            txbPassword.Text = "";
            txbSalary.Text = "";
            txbWorkerName.Text = "";
            cmbDemarc.SelectedIndex = -1;
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
