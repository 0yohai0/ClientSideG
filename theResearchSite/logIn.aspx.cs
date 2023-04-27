using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace theResearchSite
{
    public partial class logIn : System.Web.UI.Page
    {
        public string username = "";
        public string password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //אם עוגייה קיימת מיחוי אוטומטי
            HttpCookie userInfo = Request.Cookies["userInfo"];
            if (userInfo!=null)
            {
                username = userInfo["userName"];
                password =userInfo["password"];
            }
            if (Session["authLevel"] != null)
            {
                Response.Redirect("homePage.aspx");
            }
            foreach (string key in Request.Form.AllKeys)
            {
                if (key == "logIn")
                {
                    logInClick();
                }
                if (key == "clear")
                {
                    Clear();
                }
            }
        }

        protected void logInClick()
        {
            //הגדרת משתנים
            string userName = Request["txbUserName"].ToString();
            string password = Request["txbPassword"].ToString();
            bool error = false;

            //בדיקות

            //אורך
            if (userName.Length > 12 || userName.Length < 5)
            {
                error = true;
            }
            if (password.Length < 6 || password.Length > 12)
            {
                error = true;
            }

            int countUpper = 0;
            int countInt = 0;
            int specialCount = 0;

            foreach (char ch in password)
            {
                int i = Convert.ToInt32(ch);
                if (i > 32 && i < 48)
                {
                    specialCount++;
                }
                if (char.IsUpper(ch))
                {
                    countUpper++;
                }
                if (int.TryParse(ch + "".Trim(), out int num))
                {
                    countInt++;
                }
            }
            if (countUpper == 0)
            {
                error = true;
            }
            if (countInt == 0)
            {
                error = true;
            }
            if (error)
            {
                return;
            }

            HumanService.HumanClient humanClient = new HumanService.HumanClient();
            HumanService.UserList users= humanClient.selectAllUsers();
            //חיתוך לפי שם וססמה
            HumanService.User userTest = users.Find(x => (x.userName == userName && x.password == password));

            //אם אין משתמש כזה הוא לא קיים- הוצאת שגיאה
            if (userTest == null)
            {
                //הוצאת שגיאה
            }
            //אם קיים משתמש לתת הרשאה
            if (userTest != null)
            {
                //הכנסת נתונים לעוגייה
                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo.Values["userName"] = userName;
                userInfo.Values["password"] = password;
                userInfo.Expires = DateTime.Now.AddDays(100);
                Response.Cookies.Add(userInfo);

                Session["fromLogIn"] = true;

                string authLevel = userTest.authLevel.name;

                if (authLevel == "משתמש")
                {
                    Session["user"] = true;
                    Session["userId"] = userTest.IdUser;
                    Response.Redirect("favorites.aspx");
                }
                if (authLevel == "מנוי")
                {
                    Session["user"] = true;
                    Session["subscribed"] = true;
                    Session["userId"] = userTest.IdUser;
                    Response.Redirect("favorites.aspx");
                }
                if (authLevel == "עיתונאי")
                {
                    Session["journalist"] = true;
                    Response.Redirect("homePage.aspx");
                }
                if (authLevel =="עורך")
                {
                    Session["editor"] = true;
                    Response.Redirect("homePage.aspx");
                }
                if (authLevel == "מנהל")
                {
                    Session["admin"] = true;
                    Response.Redirect("GvNews.aspx");
                }
            }
        }



        public void Clear()
        {
        }
    }
}