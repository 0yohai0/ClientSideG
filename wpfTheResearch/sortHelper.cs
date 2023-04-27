using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfTheResearch.NewsService;
using wpfTheResearch.UserNewsInteractionService;

namespace wpfTheResearch
{
    public class sortHelper
    {
        private NewsService.News news;
        private int quantity;
       public sortHelper(NewsService.News news, int quantity)
       {
           this.news = news;
           this.quantity = quantity;
       }
        public int getQuantity()
        {
            return this.quantity;
        }
        public NewsService.News getNews()
        {
            return this.news;
        }
        public static List<sortHelper> sortByCommentsList(NewsList newsList, CommentList comments )
        {
            List<sortHelper> sorters = new List<sortHelper>();
            int i = 0;
            foreach(NewsService.News news in newsList)
            {
                foreach(Comment comment in comments)
                {
                    sorters.Add(new sortHelper(news, 0));
                    if(comment.news.Id == news.Id)
                    {
                        sorters[i].quantity++;
                    }
                }
                i++;
            }

            return sorters;
        }


    }
}
