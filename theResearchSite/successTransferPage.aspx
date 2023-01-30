<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="successTransferPage.aspx.cs" Async="true" Inherits="theResearchSite.successTransferPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="GeneralCss.css" rel="stylesheet" />
</head>
<body class="success-body">
    <form id="form1" runat="server">
        <div class="succsess-msg-wrap">
            <div class="success-msg" ">
                <asp:Label ID="ltransferId" runat="server" Text="קנייה מספר:"></asp:Label>
            </div>
            <div class="transfer-success">
                הושלמה בהצלחה!
            </div>
        </div>
    </form>
    <script src="GeneralJS.js"></script>
</body>
</html>
