<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2 style="text-align:center;font:bold">Welcome to Login Page!!</h2>
            <table style="margin-left:auto;margin-right:auto;">
                <tr>
                    <td>
                    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtuname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr></tr>
                <tr></tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                     </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtpasswd" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr></tr>
                <tr></tr>
                <tr></tr>
                <tr>
                    <td> 
                        <asp:LinkButton ID="LinkButton" runat="server" onclick="ForgotPassword_Button">Forgot Password??</asp:LinkButton>
                    </td>
                    <td colspan="2" style="text-align:center">
                        <asp:Button ID="bttonLogin" runat="server" Text="Login" OnClick="LoginUser" />
                    </td>
                </tr>
                <tr></tr>
                <tr></tr>
                <tr>
                    <td></td>
                    <td>
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
