<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/LoginStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Logo">
        <div id="topRightNav">
            <ul>
                <li><a href="Login.aspx">Sign in</a></li>
                <li><a href="Register.aspx">Register</a></li>
            </ul>
        </div>
        <asp:Image ID="Logo" runat="server" ImageUrl="~/images/Golden Needle Films.png" />
    </div>
    <div id="topNav">
        <ul>
            <li><a href="Home.aspx">Home</a></li>
            <li><a href="Browse.aspx">Browse</a></li>
            <li><a href="About.aspx">About us</a></li>
        </ul>
    </div>
    <div id="fields">
        E-mail<br />
        <asp:TextBox ID="email" runat="server" class="emailField" CssClass="auto-style1"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="emailValidate" runat="server" 
            ErrorMessage="**You must enter your email address**<br/>" ControlToValidate="email" EnableClientScript="false" ValidationGroup="submitClicked"/>
        Password<br />
        <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="passwordValidate" runat="server" 
            ErrorMessage="**You must enter your password**<br/>" ControlToValidate="password" EnableClientScript="false" ValidationGroup="submitClicked"/>
        <asp:Label ID="WrongInformation" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:Button ID="SubButton" runat="server" Text="Submit" class="SubButton" OnClick="logIn" validationgroup="submitClicked"/>
        <br /><a href="ForgetPassword.aspx">Forgot Password</a>
    </div>
    <div id="Footer">
        &copy Golden Needle Films
    </div>
    </form>
</body>
</html>
