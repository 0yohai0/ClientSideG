using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using theResearchSite.HumanService;

namespace theResearchSite
{
    public partial class subscriptionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("logIn.aspx");
            }
        }

        protected void btBuy_Click(object sender, EventArgs e)
        {
            //קבלת מידע
            int.TryParse(txbCreditNumber.Text, out int creditCardNumber);
            int.TryParse(Session["userId"].ToString(), out int userID);
            DateTime.TryParse(Request.Form["dExpaireDate"], out DateTime expireDate);

            //בדיקות
            bool error = false;
            //בדיקת ת.ז לשם ההדגמה
            IdService.IdToolsSoapClient idToolsSoapClient = new IdService.IdToolsSoapClient();
            error = idToolsSoapClient.CheckIsraelIdNum(txbId.Text);
            creditCardService.creditServiceSoapClient credit = new creditCardService.creditServiceSoapClient();

            //קריאה לשירות רשת
            int result = credit.creditCardCheck(4, creditCardNumber, 100, expireDate, userID);

            //התייחסות לתוצאות ההעברה
            if(result< 0)
            {
                //להעביר לשירות שמטפל בשגיאות השונות
            }
            if(result > 0)
            {
                Session["subscribed"] = true;
                //עדכון רמת הרשאה
                HumanClient humanClient = new HumanClient();
                User userToUpdate = new User();
                UserList users = humanClient.selectAllUsers();
                userToUpdate = users.Find(x => x.IdUser == userID);
                userToUpdate.authLevel.Id = 16;
                userToUpdate.authLevel.name = "מנוי";
                int rows = humanClient.Update(EnumshumanType.user, userToUpdate);

                if(rows == 2)
                {
                    //שליחה לדף הצלחה
                    Response.Redirect($"paymentComplete.aspx?transferID={result}");
                }
                //צריך טיפול בשגיאות
             
            }
        }
    }
}