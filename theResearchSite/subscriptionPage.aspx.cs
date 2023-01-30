using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            //קריאה לשירות רשת
            //צריך בדיקה

            creditCardService.creditServiceSoapClient credit = new creditCardService.creditServiceSoapClient();
            int result = credit.creditCardCheck(3, creditCardNumber, 100, expireDate, userID);

            //התייחסות לתוצאות ההעברה
            if(result< 0)
            {
                //להעביר לשירות שמטפל בשגיאות השונות
            }
            if(result > 0)
            {
                Response.Redirect($"successTransferPage.aspx?transferID={result}");
            }
        }
    }
}