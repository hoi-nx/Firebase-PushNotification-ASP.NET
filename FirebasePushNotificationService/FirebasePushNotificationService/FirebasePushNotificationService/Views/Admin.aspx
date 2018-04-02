<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="FirebasePushNotificationService.Views.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Title</div>
        <asp:TextBox ID="txtTitle" runat="server" Height="30px" Width="574px"></asp:TextBox>
        <br />
        <br />
        ND:<br />
        <asp:TextBox ID="txtND" runat="server" Height="191px" OnTextChanged="TextBox2_TextChanged" TextMode="MultiLine" Width="571px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnPush" runat="server" Height="56px" OnClick="btnPush_Click" Text="Push Notification" Width="569px" />
        <br />
        <br />
        KQ<br />
        <br />
        <asp:TextBox ID="txtKQ" runat="server" Height="125px" TextMode="MultiLine" Width="567px"></asp:TextBox>
        <br />
    </form>
</body>
</html>
