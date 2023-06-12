<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Three_Tier_Project.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID= "Label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID ="txtuname" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtpassword" runat="server" Text="Password"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
