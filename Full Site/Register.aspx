<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/RegisterStyles.css" rel="stylesheet" type="text/css" runat="server"/>
</head>
<body>
    <form id="Main" runat="server">
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
    <div class="Fields">
        First Name<br />
        <asp:TextBox ID="FirstName" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="FirstNameValidate" runat="server" 
            ErrorMessage="**You must enter your first name**<br/>" ControlToValidate="FirstName" EnableClientScript="false" ValidationGroup="submitClicked"/>
        Last Name<br />
        <asp:TextBox ID="LastName" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="LastNameValidate" runat="server" 
            ErrorMessage="**You must enter your last name**<br/>" ControlToValidate="LastName" EnableClientScript="false" ValidationGroup="submitClicked"/>
        Email<br />
        <asp:TextBox ID="Email" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="emailValidate" runat="server" 
            ErrorMessage="**You must enter an Email Address**<br/>" ControlToValidate="Email" EnableClientScript="false" ValidationGroup="submitClicked"/>
        Username<br />
        <asp:TextBox ID="Username" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="**You must enter a Username**<br/>" ControlToValidate="Username" EnableClientScript="false" ValidationGroup="submitClicked"/>
        Password<br />
        <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="PasswordValidate" runat="server" 
            ErrorMessage="**You must enter your password**<br/>" ControlToValidate="Password" EnableClientScript="false" ValidationGroup="submitClicked"/>
        Confirm Password<br />
        <asp:TextBox ID="ConfirmPassword" TextMode="Password" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="ConfirmPasswordValidate" runat="server" 
            ErrorMessage="**You must confirm password**<br/>" ControlToValidate="ConfirmPassword" EnableClientScript="false" ValidationGroup="submitClicked"/>
        <asp:Label ID="ConfirmPasswordWrong" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:Button ID="SubButton" runat="server" Text="Submit" OnClick="Finish" validationgroup="submitClicked"/>
    </div>
    <div id="Footer">
        &copy Golden Needle Films
    </div>
    </form>
</body>
</html>
