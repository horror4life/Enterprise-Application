<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="ForgetPasswordStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="topRightNav">
        <ul>
            <li><a href="Login.aspx">Sign in</a></li>
            <br />
            <li><a href="Register.aspx">Register</a></li>
        </ul>
        </div>
        <asp:Image ID="Image1" runat="server" ImageUrl="Logo2.png" />
        <div id="topNav">
        </div>
        <br />
        Type in your username:<br />
        <asp:TextBox ID="UserText" runat="server"></asp:TextBox><br />
        Type in your first name:
        <asp:TextBox ID="FirstText" runat="server"></asp:TextBox><br />
        Type in your last name:
        <asp:TextBox ID="LastText" runat="server"></asp:TextBox><br />
        Type in your e-mail address:
        <asp:TextBox ID="EmailText" runat="server" style="margin-left: 0px"></asp:TextBox><br />
        <asp:Button ID="UserSubmit" runat="server" OnClick="UsernameSubmit" Text="Submit" style="margin-left: 622px" />
        <br />
        <asp:Label ID="lblMessage" runat="server" />
    </div>
    </form>
</body>
</html>
