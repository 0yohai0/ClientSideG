﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
            lCheckPasswordError.Text = "";
            lErrorEmail.Text = "";
            lErrorName.Text = "";
            lErrorPassword.Text = "";
            lErrorUserName.Text = "";
            //הגדרת משתנים
            string name = txbUserName.Text;
            string userName = txbUserName.Text;
            string email = txbEmail.Text;
            string password = txbPasswore.Text;


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
            HumanService.User user = new HumanService.User() { name = name, email = email, password = password,joinDate=DateTime.Now, authLevel = new HumanService.AuthLevel() { Id = 12 }, userName=userName };

            //בדיקה האם משתמש קיים כבר
            HumanService.HumanClient humanClient = new HumanService.HumanClient();
            HumanService.UserList users = humanClient.selectAllUsers();
            HumanService.User userTest = users.Find(x => (x.name == userName && x.password == password));

            if (userTest != null)
            {
                //הודעת שגיאה משתמש כבר קיים
                return;
            }
            try
            {
                 int rowEffected = humanClient.Add(HumanService.EnumshumanType.user, user);
                //בדיקות לאחר אינסרט
                if (rowEffected == 0)
                {
                    LgeneralError.Text = "הליך הרישום לא צלח";
                }
                if (rowEffected == 2)
                {
                    Response.Redirect("logIn.aspx");
                }
                if (rowEffected > 2)
                {
                    LgeneralError.Text = "שגיאה חמורה יש לפנות לעזרה";
                }
            }
            catch (FaultException<HumanService.ServiceFaultHumans> ex)
            {
                LgeneralError.Text = ex.Detail.Message;
               return;
            }
        }

        protected void btReset_Click(object sender, EventArgs e)
        {
            txbUserName.Text = "";
            txbPasswore.Text = "";
            txbEmail.Text = "";

            lCheckPasswordError.Text = "";
            lErrorEmail.Text = "";
            lErrorName.Text = "";
            lErrorPassword.Text = "";
            lErrorUserName.Text = "";

            RequiredFieldValidatorUserName.ErrorMessage = "";
            RequiredFieldValidatorEmail.ErrorMessage = "";
            regExEmail.ErrorMessage = "";
        }
    }
}