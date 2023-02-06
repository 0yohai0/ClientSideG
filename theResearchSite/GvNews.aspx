<%@ Page Title="" Language="C#" MasterPageFile="~/TheResearchMasterPage.Master" AutoEventWireup="true" CodeBehind="GvNews.aspx.cs" Inherits="theResearchSite.GvNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid-wrap">
            <asp:GridView runat="server" ID="gvNews" AutoGenerateColumns="False" DataKeyNames="Id"
        OnRowEditing="gvNews_RowEditing" OnRowCancelingEdit="gvNews_RowCancelingEdit" OnRowDataBound="gvNews_RowDataBound"
        OnRowCommand="gvNews_RowCommand" OnRowUpdating="gvNews_RowUpdating" ShowFooter="true" CssClass="grid" BorderColor="#336666" BorderStyle="Double">

        <Columns>
            <asp:TemplateField HeaderText="מספר מזהה" InsertVisible="False" SortExpression="IdNews">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Id") %>' ID="Label1"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Id") %>' ID="lId"></asp:Label>
                </ItemTemplate>

                <FooterTemplate>
                    <asp:TextBox ID="txbIdDemarc" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="כותרת ראשית" SortExpression="HeadLine">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%#Bind("headLine") %>' ID="txbHeadLine"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("headLine") %>' ID="Label2"></asp:Label>
                </ItemTemplate>


                <FooterTemplate>
                    <asp:TextBox ID="txbHeadLineDemarc" runat="server"></asp:TextBox>
                </FooterTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="כותרת משנית" SortExpression="seconderyTitle">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("secondaryTitle") %>' ID="txbSecTitle"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("secondaryTitle") %>' ID="Label3"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="תאריך פרסום" SortExpression="dateTimePublished">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("dateTimePublished") %>' ID="txbDatePublished"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("dateTimePublished") %>' ID="Label4"></asp:Label>
                </ItemTemplate>

                <FooterTemplate>
                    <input type="date" runat="server" name="clDatePublishedDemarc" id="clDatePublishedDemarc" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="תוכן" SortExpression="content">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("content") %>' ID="txbContent"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("content") %>' ID="Label5"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="הרשאה נחוצה" SortExpression="IdAuthLevelNeeded">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlAuths" runat="server"></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("authLevel.name") %>' ID="Label6"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlAuthsDemarc" runat="server"></asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="תמונה" SortExpression="imagePath">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("imagePath") %>' ID="txbImgPath"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("imagePath") %>' ID="Label7"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton runat="server" Text="עדכון" CommandName="Update" CausesValidation="True" ID="lkUpdate"></asp:LinkButton>&nbsp;<asp:LinkButton runat="server" Text="ביטול" CommandName="Cancel" CausesValidation="False" ID="lkCancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="עריכה" CommandName="Edit" CausesValidation="False" ID="lkEdit"></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btDemarc" CommandName="demarc" runat="server" Text="תיחום" />
                    <asp:Button ID="btClear" CommandName="clear" runat="server" Text="איפוס" />
                </FooterTemplate>
            </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333"></FooterStyle>

        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#336666" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="White" ForeColor="#333333"></RowStyle>

        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#487575"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#275353"></SortedDescendingHeaderStyle>
    </asp:GridView>
    </div>
</asp:Content>
