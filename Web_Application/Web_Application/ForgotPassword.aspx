<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Web_Application.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2 style="font: bold; text-align: center">Forgot Password</h2>
            <table style="margin-left: auto; margin-right: auto;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtuname" runat="server"></asp:TextBox>
                        <!--<asp:RequiredFieldValidator ID="reqName" ControlToValidate="txtuname" runat="server" ErrorMessage="Please enter valid username"
                            ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>-->
                    </td>
                </tr>
                <tr></tr>
                <tr></tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="New Password"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtnewpasswd" runat="server" TextMode="Password"></asp:TextBox>
                        <!--<asp:RequiredFieldValidator ID="reqpasswd" ControlToValidate="txtnewpasswd" runat="server" ErrorMessage="Please enter new password"
                            ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>-->
                    </td>
                </tr>
                <tr></tr>
                <tr></tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtconfirmpasswd" runat="server" TextMode="Password"></asp:TextBox>
                        <!--<asp:RequiredFieldValidator ID="reqconfirmpasswd" ControlToValidate="txtconfirmpasswd" runat="server" ErrorMessage="Please enter confirm password"
                            ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>-->
                    </td>
                    <td>
                            <!--<asp:CompareValidator ID="Compare" runat="server"
                            ControlToCompare="txtnewpasswd" ControlToValidate="txtconfirmpasswd"
                            ErrorMessage="Password Mismatch" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>-->
                    </td>
                </tr>
                <tr></tr>
                <tr></tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="LinkButton" runat="server" OnClick="LinkButton2">Back to Login</asp:LinkButton>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="buttonPasswd" runat="server" Text="Submit" OnClick="button_Passwd" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
