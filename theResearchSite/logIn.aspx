<%@ Page Title="" Language="C#" MasterPageFile="~/TheResearchMasterPage.Master" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="theResearchSite.logIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="GeneralCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="glassWrap">
    <div class="login-page-wrap">
        <div>
        <div class="headLine">
            כניסה
        </div>
            <div>
                <input type="text" name="txbUserName" onkeyup="checkUserNameLogIn()" id="txbUserName" value="<%Response.Write(username);%>" class="input" placeholder="שם משתמש"/>
                <label id="lErrorUserName" class="error"></label>         
            </div>
            <div>
                <input type="text" name="txbPassword"  onkeyup="checkPasswordLogIn()" id="txbPassword" value="<%Response.Write(password);%>" class="input" placeholder="ססמה"/>
                 <label id="lErrorPassword" class="error"></label>               
            </div>
            <input type="submit" name="logIn" id="logIn"  class="action-button" value="כנס/י"/>
            <input type="submit" name="clear" id="clear" class="action-button" value="איפוס"/>
         </div>
    </div>
</div>
    <img src="generalImages/marsLeft.jpg" class="back" />
</asp:Content>
