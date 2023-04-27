<%@ Page Title="" Language="C#" MasterPageFile="~/TheResearchMasterPage.Master" AutoEventWireup="true" CodeBehind="favorites.aspx.cs" Inherits="theResearchSite.favorites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="GeneralCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="search-bar flex-culomn-center">
        <div class="flex-line-center search-single-bar">

            <div>
               <asp:Button ID="btResetDemarc" OnClick="btResetDemarc_Click" CssClass="reset-bt"  runat="server" Text="&#8634;" /> 
            </div>

            <div>
                <asp:TextBox ID="txbHeadLine" CssClass="txb-headLine-search" placeholder="כותרת ראשית" runat="server"></asp:TextBox>
            </div>
            <div>
                 <asp:DropDownList ID="ddlCategory"  CssClass="ddl-sort" runat="server">
                 </asp:DropDownList>
            </div>
             <div>
                 <asp:DropDownList ID="ddlHasComment"  CssClass="ddl-sort"  runat="server">
                        <asp:ListItem>האם הגבת לחדשה</asp:ListItem>
                        <asp:ListItem Value="yes">כן</asp:ListItem>
                        <asp:ListItem Value="no">לא</asp:ListItem>
                 </asp:DropDownList>
            </div>
            <div>
                <asp:Button ID="btSendDemarc" CssClass="bt-send-search" OnClick="btSendDemarc_Click" runat="server" Text="תיחום" />
            </div>
           
        </div>
         <div  class="flex-line-center  search-single-bar">
             <div runat="server">
                 <asp:Button ID="btResetSort" OnClick="btResetSort_Click" CssClass="reset-bt"  runat="server" Text="&#8634;" /> 
            </div>

             <div>
                    <asp:RadioButton ID="rbNewsDatePost" CssClass="rb-sort" GroupName="sort" Text="תאריך פרסום חדשה" runat="server" />
                    <asp:RadioButton ID="rbFavoritedDate" CssClass="rb-sort" GroupName="sort" Text="תאריך העדפה" runat="server" />            
             </div>   
             <div>
                    <asp:DropDownList ID="ddlSortDirection" CssClass="ddl-sort ddl-sort-dir" runat="server">
                        <asp:ListItem>כיוון מיון</asp:ListItem>
                        <asp:ListItem Value="up">עולה</asp:ListItem>
                        <asp:ListItem Value="down">יורד</asp:ListItem>
                    </asp:DropDownList>
             </div>

              <div>
                <asp:Button ID="btSendSorting"  CssClass="bt-send-search" OnClick="btSendSorting_Click" runat="server" Text="סינון" />
            </div>
        </div>
        <div>
            <asp:Button ID="btResetFavorites" OnClick="btResetFavorites_Click" CssClass="reset-bt-all" runat="server" Text="איפוס" />
        </div>
    </div>
    <asp:Label ID="lFavorites" runat="server" Text=""></asp:Label>
</asp:Content>
