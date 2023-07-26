<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2 style="font:bold;text-align:center">User Registration Form</h2>
            <table cellpadding="0" cellspacing="0" style="margin-left: auto; margin-right: auto;border-collapse: separate;
        border-spacing: 0 15px;align-items:center;padding:15px;border-spacing:20px">
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Username  "></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtUsername" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Password  "></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Confirm Password  "></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
                    </td>
                    <td>
                        <asp:CompareValidator ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmPassword" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Email  "></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtEmail" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                            ControlToValidate="txtEmail" runat="server" />
                        <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Mobile  "></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtmobile" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button Text="Submit" runat="server" OnClick="RegisterUser" />
                    </td>
                    <td></td>
                </tr>
            </table>
            <h3 style="text-align: center; font: bold">Please Login if you are already registered</h3>
            <div style="text-align: center">
                <asp:HyperLink ID="Login" BorderStyle="Solid" runat="server" Text="Login" NavigateUrl="~/Login.aspx"></asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
