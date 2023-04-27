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

namespace wpfTheResearch
{
    /// <summary>
    /// Interaction logic for oneWorker.xaml
    /// </summary>

    public partial class oneWorker : Page
    {
        AuthLevelList auths;
        Worker worker = new Worker();
        private WorkerActions workerAction;
        public oneWorker()
        {
            InitializeComponent();
        }
        public oneWorker(Worker workerInfo,WorkerActions action, AuthLevelList auths) : this()
        {
            this.auths = auths;
            this.worker = workerInfo;
            this.workerAction = action;

            DataContext = worker;
            cmbAuths.ItemsSource = auths;
            cmbAuths.DataContext = worker.authLevel;

            cmbAuths.SelectedValuePath = "Id";
            cmbAuths.DisplayMemberPath = "name";
        }
        private void cmbAuths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbAuths.SelectedItem != null)
            {
                wpfTheResearch.HumanService.AuthLevel newAuth = new wpfTheResearch.HumanService.AuthLevel();
                int.TryParse(cmbAuths.SelectedValue.ToString(), out int id);
                newAuth.Id = id;
                wpfTheResearch.AuthService.AuthLevel authT = new wpfTheResearch.AuthService.AuthLevel();
                authT = (wpfTheResearch.AuthService.AuthLevel)cmbAuths.SelectedItem;
                newAuth.name = authT.name;
                worker.authLevel = newAuth;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = workerAction(worker);
            if (result == 0)
            {
                //שגיאה 
            }
            if (result == 2|| result==1)
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
    }
}
