<%@ Page Title="" Language="C#" MasterPageFile="~/TheResearchMasterPage.Master" AutoEventWireup="true" CodeBehind="subscriptionPage.aspx.cs" Inherits="theResearchSite.subscriptionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="glassWrap login-page-wrap">
    <div class="head headLine">הצטרפות למנוי</div>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txbCreditNumber" placeholder="מספר כרטיס" runat="server" CssClass="input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="dExpaireDate" name="dExpaireDate" type="date" class="input" />
                </td>
            </tr>
            <tr>
                <td>                   
                  <asp:Button ID="btBuy" OnClick="btBuy_Click" CssClass="action-button" runat="server" Text="קניית מנוי" />
                  <asp:Button ID="btReset" CssClass="action-button" runat="server" Text="איפוס" />
                </td>
            </tr>
        </table>
    </div>
      <img src="generalImages/marsLeft.jpg" class="back" />
</asp:Content>
