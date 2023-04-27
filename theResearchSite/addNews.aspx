<%@ Page Title="" Language="C#" MasterPageFile="~/TheResearchMasterPage.Master" AutoEventWireup="true" CodeBehind="addNews.aspx.cs" Inherits="theResearchSite.addNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrap">

        <div class="editor-wrap">
            <div class="page-head-line">
                יצירת חדשה
            </div>

            <div class="head-topics-edit">
                <div>
                    <asp:TextBox ID="txbHeadLine" AutoPostBack="true" OnTextChanged="txbHeadLine_TextChanged" placeholder="כותרת ראשית" CssClass="head-text" runat="server"></asp:TextBox>
                </div>

                <div>
                    <asp:TextBox ID="txbSecTitle" AutoPostBack="true" OnTextChanged="txbSecTitle_TextChanged" placeholder="כותרת משנית" CssClass="head-text" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="content-wrap">
                <asp:TextBox ID="txbContent"  AutoPostBack="true"  OnTextChanged="txbContent_TextChanged" placeholder="תוכן כתבה" CssClass="content-box" TextMode="MultiLine" MaxLength="1200" runat="server"></asp:TextBox>
            </div>
            <div class="more-info-to-add">
                <div>
                    <asp:DropDownList ID="ddlCategories" CssClass="ddl-categories" runat="server"></asp:DropDownList>
                </div>

                 <div class="flex-line-center">
                     <asp:FileUpload ID="fuNewsImg" CssClass="file-img" runat="server" />
                     <asp:Button ID="BtsaveImg" runat="server" OnClick="BtsaveImg_Click" Text="שמירת תמונה" />
                </div>
            </div>
            <div class="bt-send-wrap flex-line-center" >
               <asp:Button ID="btSendNews" CssClass="bt-send" runat="server" OnClick="btSendNews_Click" Text="שליחה" />
            </div>
        </div>

        <div class="single-news-wrap special-wrap-news flex-culomn-center">

            <div class="news-head-wrap flex-line-center">

                <div class="single-news-headers-wrap flex-culomn-center">
                    <div id="headLine" runat="server" class="single-news-head-line">כותרת ראשית</div>
                    <div id="secTitle" runat="server" class="single-news-sec-title">כותרת משנית</div>
                </div>

                <div class="img-wrap">
                    <img id="imgNews" runat="server"  class="single-news-img" src="" title="תמונה לחדשה"/>
                </div>

            </div>

            <div class="more-info-wrap flex-line-center">
                <div class="news-info flex-line-center">
                    <div class="news-authers"></div>
                    <div class="news-date"></div>
                </div>
                <div class="user-news-interaction flex-line-center">
                    <div class="news-comments"></div>
                    <div class="add-heart"></div>
                </div>
            </div>

            <div class="news-text-wrap">
                <div id="content" runat="server" class="text-design">תוכן הכתבה</div>
            </div>

        </div>
    </div>
</asp:Content>
