<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Userregistration.aspx.cs" Inherits="Three_Tier_Project.Userregistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">  
<head id="Head1" runat="server">  
<title></title>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div style="margin: 0px auto; padding-left: 370px; padding-right: 30px;overflow: auto;">  
        <div>  
            <table width="50%">  
                <tr>  
                    <td colspan="2" height:60 px align="center">  
                        <b>Login Page </b>
                    </td>  
                </tr>  
                <tr>  
                    <td> Name </td>  
                    <td>  
           <asp:TextBox ID="txtname" Width="150px" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>  
                        Address </td>  
                    <td>  
            <asp:TextBox ID="txAddress" Width="150px" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td> EmailID </td>  
             <td>  
            <asp:TextBox ID="txtEmailid" Width="150px" runat="server"></asp:TextBox>  
             </td>  
                </tr>  
                <tr>  
                    <td> Mobile Number</td>  
                    <td>  
            <asp:TextBox ID="txtmobile" Width="150px" runat="server"></asp:TextBox>  
                    </td>  
                </tr>   
            </table>  
        </div>  
    </div>  
    </form>  
</body>  
</html>  

