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
using wpfTheResearch.CategoryService;

namespace wpfTheResearch
{
    /// <summary>
    /// Interaction logic for showCategories.xaml
    /// </summary>
    public delegate int CategoryAction(Category category);
    public partial class showCategories : Page
    {
        static int i = 1;
        CategoryList categories;
        Category category = new Category();
        CategoriesClient client = new CategoriesClient();

        public int insertCategory(Category category)
        {
            int result = client.Add(category);
            categories.Add(category);
            populate();
            return result;
        }
        public int removeCategory(Category category)
        {
            int result = client.Remove(category);
            categories.Remove(category);
            populate();
            return result;
        }
        private void Insert(object sender, RoutedEventArgs e)
        {
            CategoryAction insert = new CategoryAction(insertCategory);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new oneCategory(insert, new Category()));
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            int result = client.Remove(category);
            if (result == 0)
            {
                //שגיאה
            }
            if (result == 1)
            {
                categories.Remove(category);
                populate();
            }
        }
        public showCategories() 
        {
            InitializeComponent();
            categories = client.selectAll();
            populate();

        }
        public void populate()
        {
            lvCategories.ItemsSource = null;
            lvCategories.ItemsSource = categories;

        }

        private void lvCategories_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            category = lvCategories.SelectedItem as Category;
        }

    }
}
