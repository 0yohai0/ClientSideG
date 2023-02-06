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
using wpfTheResearch.HumanService;
using wpfTheResearch.NewsService;
using wpfTheResearch.UserNewsInteractionService;

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
            populate();
        }
        public ShowComments()
        {
            InitializeComponent();
            comments = client.selectAllComments();

            //תיחומים
            cmbDemarcUser.ItemsSource = HumanClient.selectAllUsers();
            cmbDemarcNews.ItemsSource = newsClient.selectAll();

            populate();
        }
        public void populate()
        {
            lvComments.ItemsSource = null;
            lvComments.ItemsSource = comments;
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            populate();
        }
        private void btDemarcation_Click_1(object sender, RoutedEventArgs e)
        {
            CommentList newComments = new CommentList();
            newComments = comments;
             //קבלת נתונים
            int.TryParse(txbIdComment.Text, out int id);
            string content = txbCommentTextName.Text;
            DateTime.TryParse(txbCommentDate.Text, out DateTime date);

            string userIdStr = cmbDemarcUser.SelectedValue.ToString();
            string newsIdStr = cmbDemarcNews.SelectedValue.ToString();

            int.TryParse(userIdStr, out int userId);
            int.TryParse(newsIdStr, out int newsId);
            //צריך לבדוק שתיחום עובד
            if(id>0)
            {
                foreach(Comment comment in newComments.FindAll(x => x.Id != id))
                {
                    newComments.Remove(comment);                    
                }
            }
            if (userId > 0)
            {
                foreach (Comment comment in newComments.FindAll(x => x.user.Id != userId))
                {
                    newComments.Remove(comment);
                }
            }
            if(newsId > 0)
            {
                foreach (Comment comment in newComments.FindAll(x => x.news.Id != newsId))
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
            newComments = comments;

            if (direction == 1)
            {
                if (colum == "מספר מזהה")
                {
                    foreach (Comment commentTry in newComments.OrderBy(x => x.Id))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "תוכן תגובה")
                {
                    foreach (Comment commentTry in newComments.OrderBy(x => x.content))
                    {
                        newComments.Add(commentTry);
                    }
                }

                if (colum == "שם משתמש")
                {
                    foreach (Comment commentTry in newComments.OrderBy(x => x.user.userName))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "שם חדשה")
                {
                    foreach (Comment commentTry in newComments.OrderBy(x => x.news.headLine))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "זמן הוספת תגובה")
                {
                    foreach (Comment commentTry in newComments.OrderBy(x => x.dateTimeAdded))
                    {
                        newComments.Add(commentTry);
                    }
                }
            }

            else if (direction == -1)
            {
                if (colum == "מספר מזהה")
                {
                    foreach (Comment commentTry in newComments.OrderByDescending(x => x.Id))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "תוכן תגובה")
                {
                    foreach (Comment commentTry in newComments.OrderByDescending(x => x.content))
                    {
                        newComments.Add(commentTry);
                    }
                }

                if (colum == "שם משתמש")
                {
                    foreach (Comment commentTry in newComments.OrderByDescending(x => x.user.userName))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "שם חדשה")
                {
                    foreach (Comment commentTry in newComments.OrderByDescending(x => x.news.headLine))
                    {
                        newComments.Add(commentTry);
                    }
                }
                if (colum == "זמן הוספת תגובה")
                {
                    foreach (Comment commentTry in newComments.OrderByDescending(x => x.dateTimeAdded))
                    {
                        newComments.Add(commentTry);
                    }
                }
            }
        }

        private void lvComments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comment = lvComments.SelectedItem as Comment;
        }
    }
}
