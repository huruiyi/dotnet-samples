<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApiDemo.aspx.cs" Inherits="WebApp.Page.ApiDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:Button ID="btnSendGetRequest" runat="server" Text="Send Get request" OnClick="btnSendRequest_Click" />
        <asp:Button ID="btnSendPostRequest" runat="server" Text="Send Post request" OnClick="btnSendPostRequest_Click" />
    </div>
</form>
</body>
</html>
