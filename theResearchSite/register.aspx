<%@ Page Title="" Language="C#" MasterPageFile="~/TheResearchMasterPage.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="theResearchSite.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="glassWrap">
        <div class="headLine">
            רישום
        </div>
        <div class="Registration-wrap">
            <div>
                <asp:TextBox ID="txbName" CssClass="input" placeholder="שם" runat="server"></asp:TextBox>
                <asp:Label ID="lErrorName" CssClass="error" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txbUserName" CssClass="input" placeholder="שם משתמש" runat="server"></asp:TextBox>
                <asp:Label ID="lErrorUserName" CssClass="error" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txbEmail" CssClass="input" placeholder="אימייל" runat="server"></asp:TextBox>
                <asp:Label ID="lErrorEmail" runat="server" CssClass="error" Text=""></asp:Label>
            </div>


            <div>
                <asp:TextBox ID="txbPasswore" CssClass="input" placeholder="ססמה" runat="server"></asp:TextBox>
                <asp:Label ID="lErrorPassword" runat="server" CssClass="error" Text=""></asp:Label>
            </div>

              <div>
                <asp:TextBox ID="txbCheckPassword" CssClass="input" placeholder="אימות ססמה" runat="server"></asp:TextBox>
                <asp:Label ID="lCheckPasswordError" runat="server" CssClass="error" Text=""></asp:Label>
            </div>
                <div>
                   <input type="date" id="dBirthDate" name="dBirthDate" class="input" />
                <asp:Label ID="Label1" runat="server" CssClass="error" Text=""></asp:Label>
            </div>

            <asp:Button ID="btRegister" OnClick="btRegister_Click" CssClass="action-button" runat="server" Text="רישום" />
            <asp:Button ID="btReset" OnClick="btReset_Click" CssClass="action-button" runat="server" Text="איפוס" />
        </div>
        <div class="validatePos">
            <div>
                <asp:RequiredFieldValidator 
                    CssClass="innerValidator"
                    ID="RequiredFieldValidatorUserName"
                    AutoPostBack="false"
                    runat="server" ControlToValidate="txbName"
                    ErrorMessage="שם משתמש נחוץ" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </div>

            <div>
                <asp:RequiredFieldValidator
                    CssClass="innerValidator"
                    ID="RequiredFieldValidatorEmail" 
                    AutoPostBack="false" runat="server"
                    ControlToValidate="txbEmail"
                    ErrorMessage=" אימייל נחוץ" ForeColor="Red">
                </asp:RequiredFieldValidator>
                </div>

              <div>
                   <asp:RegularExpressionValidator 
                    ID="regExEmail"
                    runat="server"
                    CssClass="innerValidator"
                    ErrorMessage="אימייל לא תקין"
                    ForeColor="Red"
                    ControlToValidate="txbEmail"
                    ValidationExpression="[a-z0-9]+@[a-z]+\.[a-z]+$">
                   </asp:RegularExpressionValidator>

            </div>
            <div>
                <asp:CompareValidator
                    ID="CompareValidator1" 
                    runat="server"
                    ForeColor="Red"
                    ControlToValidate="txbPasswore"
                    ControlToCompare="txbCheckPassword"
                    ErrorMessage="אימות ססמה לא דומה">
                </asp:CompareValidator>
            </div>
        </div>
    </div>


    <img src="generalImages/marsLeft.jpg" class="back" />
</asp:Content>
