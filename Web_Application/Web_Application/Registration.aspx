<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Web_Application.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h2 style="font:bold;text-align:center">Registration Page</h2>
        <table style = "margin-left : auto; margin-right:auto;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr></tr>
            <tr></tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Mobile"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtMobile" TextMode="Phone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr></tr>
            <tr></tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Username"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr></tr>
            <tr></tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr></tr>
            <tr></tr>
            <tr></tr>
            <tr></tr>
            <tr>
                <td> 
                </td>
                <td colspan="2">
                   <asp:Button ID="btnSave" runat="server" Text="Register" OnClick="btnSave_Click"/>
                </td>
            </tr>
            <tr></tr>
        </table>
        <h3 style="text-align:center;font:bold">Please Login if you are already registered</h3>
        <div style="text-align:center">
        <asp:Button ID="bttonlogin" runat="server" Text="Login" OnClick="btn_Login" />
        </div>
        <br />
    </div>
    </form>
</body>
</html>
