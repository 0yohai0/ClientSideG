using System;
using System.Collections.Generic;
using System.Data;
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
using wpfTheResearch.HumanService;
using wpfTheResearch.NewsService;
using wpfTheResearch.UserNewsInteractionService;
using WpfViewModelTheResearch;

namespace wpfTheResearch
{
    /// <summary>
    /// Interaction logic for ShowComments.xaml
    /// </summary>
    public partial class ShowComments : Page
    {
        UserNewsInteractionClient client = new UserNewsInteractionClient();
        //כל השירותים הנחוצים

        CommentList comments = new CommentList();
        HumanClient HumanClient = new HumanClient();
        NewsClient newsClient = new NewsClient();
        Comment comment = new Comment();
        static int i=1;

        public void Delete(object sender, RoutedEventArgs e)
        {
            client.Remove(EnumsuserNewsInteracrionType.comment, comment);
            comments.Remove(comment);
            populate(comments);
        }
        public ShowComments()
        {
            InitializeComponent();
            comments = client.selectAllComments();

            //תיחומים
            cmbDemarcUser.ItemsSource = HumanClient.selectAllUsers();
            cmbDemarcNews.ItemsSource = newsClient.selectAll();

            populate(comments);
        }
        public void populate(CommentList list)
        {
            lvComments.ItemsSource = null;
            lvComments.ItemsSource = list;
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            populate(comments);
        }
        private void btDemarcation_Click_1(object sender, RoutedEventArgs e)
        {
            CommentList newComments = new CommentList();
            foreach(Comment comment in comments)
            {
                newComments.Add(comment);
            }
             //קבלת נתונים
            int.TryParse(txbIdComment.Text, out int id);
            string content = txbCommentTextName.Text;
            DateTime.TryParse(txbCommentDate.Text, out DateTime date);

            //צריך לבדוק שתיחום עובד
            if(id>0)
            {
                foreach(Comment comment in newComments.FindAll(x => x.Id != id))
                {
                    newComments.Remove(comment);                    
                }
            }
            if(content.Length > 0)
            {
                foreach (Comment comment in newComments.FindAll(x => x.content != content))
                {
                    newComments.Remove(comment);
                }
            }
            if (cmbDemarcNews.SelectedValue != null)
            {
                string newsIdStr = cmbDemarcNews.SelectedValue.ToString();
                foreach (Comment comment in newComments.FindAll(x => x.news.Id.ToString() != newsIdStr))
                {
                    newComments.Remove(comment);
                }
            }
            if (cmbDemarcUser.SelectedValue != null)
            {
                string userIdStr = cmbDemarcUser.SelectedValue.ToString();
                foreach (Comment comment in newComments.FindAll(x => x.user.Id.ToString() != userIdStr))
                {
                    newComments.Remove(comment);
                }
            }
            populate(newComments);
        }
        public int GetDirection()
        {
            i = i * -1;
            return i;
        }
        private void lvComments_Click(object sender, RoutedEventArgs e)
        {
            int direction = GetDirection();
            CommentList newComments = new CommentList();

            string colum = ((GridViewColumnHeader)e.OriginalSource).Column.Header.ToString();

            if (direction == 1)
            {
                if (colum == "מספר מזהה")
                {
                    foreach (Comment commentTry in comments.OrderBy(x => x.Id))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "תוכן תגובה")
                {
                    foreach (Comment commentTry in comments.OrderBy(x => x.content))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "שם משתמש")
                {
                    foreach (Comment commentTry in comments.OrderBy(x => x.user.userName))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "שם חדשה")
                {
                    foreach (Comment commentTry in comments.OrderBy(x => x.news.headLine))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "זמן הוספת תגובה")
                {
                    foreach (Comment commentTry in comments.OrderBy(x => x.dateTimeAdded))
                    {
                        newComments.Add(commentTry);
                    }
                }
            }

            else if (direction == -1)
            {
                if (colum == "מספר מזהה")
                {
                    foreach (Comment commentTry in comments.OrderByDescending(x => x.Id))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "תוכן תגובה")
                {
                    foreach (Comment commentTry in comments.OrderByDescending(x => x.content))
                    {
                        newComments.Add(commentTry);
                    }
                }

                if (colum == "שם משתמש")
                {
                    foreach (Comment commentTry in comments.OrderByDescending(x => x.user.userName))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "שם חדשה")
                {
                    foreach (Comment commentTry in comments.OrderByDescending(x => x.news.headLine))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "זמן הוספת תגובה")
                {
                    foreach (Comment commentTry in comments.OrderByDescending(x => x.dateTimeAdded))
                    {
                        newComments.Add(commentTry);
                    }
                }
            }
            populate(newComments);
        }

        private void lvComments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comment = lvComments.SelectedItem as Comment;
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
