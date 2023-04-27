<%@ Page Title="" Language="C#" MasterPageFile="~/TheResearchMasterPage.Master" AutoEventWireup="true" CodeBehind="paymentComplete.aspx.cs" Inherits="theResearchSite.paymentComplete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="succsess-msg-wrap">
            <div class="success-msg" ">
                <asp:Label ID="ltransferId" runat="server" Text="קנייה מספר:"></asp:Label>
            </div>

                 <table class="tb-payment-info">
            <tr>
                <td>
                    מוצר:
                </td>
                <td>
                    מנוי שנתי
                </td>
            </tr>
            <tr>
               <td>
                   מחיר:
               </td> 

                <td>
                   <b>79.9 ש''ח</b>
                </td>
            </tr>
        </table>

            <div class="transfer-success">
                הושלמה בהצלחה!
            </div>
        </div>
       
</asp:Content>
