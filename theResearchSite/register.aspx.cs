using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace theResearchSite
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btRegister_Click(object sender, EventArgs e)
        {
            //הגדרת משתנים
            string name = txbUserName.Text;
            string userName = txbUserName.Text;
            string email = txbEmail.Text;
            string password = txbPasswore.Text;
            string birthDateStr = Request.Form["dBirthDate"];

            DateTime.TryParse(birthDateStr, out DateTime birthDate);

            bool error = false;
            //בדיקות

            //בדיקת אורך
            if (password.Length < 8)
            {
                error = true;
            }

            if (name.Length > 12 || name.Length < 4)
            {
                error = true;
            }
            //בדיקת מייל
            if (!email.Contains('@'))
            {
                error = true;
            }
            if (error)
            {
                //הודעות שגיאה כתיבת נתונים שגויה
                return;
            }

            //יצירת אובייקט
            HumanService.User user = new HumanService.User() { name = name, email = email, password = password,birthDate=birthDate, authLevel = new HumanService.AuthLevel() { Id = 12 }, userName=userName };

            //בדיקה האם משתמש קיים כבר
            HumanService.HumanClient humanClient = new HumanService.HumanClient();
            HumanService.UserList users = humanClient.selectAllUsers();
            HumanService.User userTest = users.Find(x => (x.name == userName && x.password == password));

            if (userTest != null)
            {
                //הןדעת שגיאה משתמש כבר קיים
                return;
            }
            int rowEffected = humanClient.Add(HumanService.EnumshumanType.user, user);


            //בדיקות לאחר אינסרט
            if (rowEffected == 0)
            {

            }
            if (rowEffected == 2)
            {
                Response.Redirect("homePage.aspx");
            }
            if (rowEffected > 2)
            {
                //שגיאה חמורה
            }

        }

        protected void btReset_Click(object sender, EventArgs e)
        {
            txbUserName.Text = "";
            txbPasswore.Text = "";
            txbEmail.Text = "";
            RequiredFieldValidatorUserName.ErrorMessage = "";
            RequiredFieldValidatorEmail.ErrorMessage = "";
            regExEmail.ErrorMessage = "";
        }
    }
}