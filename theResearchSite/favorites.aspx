<%@ Page Title="" Language="C#" MasterPageFile="~/TheResearchMasterPage.Master" AutoEventWireup="true" CodeBehind="favorites.aspx.cs" Inherits="theResearchSite.favorites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="GeneralCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headLine-favorites">מועדפים</div>
    <asp:Label ID="lFavorites" runat="server" Text=""></asp:Label>
</asp:Content>
