<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="LoginStyles.css" rel="stylesheet" type="text/css" />
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
        <asp:Image ID="Logo" runat="server" ImageUrl="~/Golden Needle Films.png" />
    </div>
    <div id="topNav">
        <ul>
            <li><a href="Home.aspx">Home</a></li>
            <li><a href="Browse.aspx">Browse</a></li>
            <li><a href="About.html">About us</a></li>
        </ul>
    </div>
    <div id="fields">
        E-mail:
        <asp:TextBox ID="TextBox1" runat="server" class="emailField"></asp:TextBox><br />
        Password:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
        <asp:Button ID="SubButton" runat="server" Text="Submit" class="SubButton" />
    </div>
    </form>
</body>
</html>
