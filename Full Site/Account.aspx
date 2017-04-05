<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/AccountStyles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .uploadText {
            margin-left: 740px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="topRightNav">
        <ul>
            <li><a id="Log" href="Login.aspx" runat="server">Sign in</a></li>
            <li><a id="Reg" href="Register.aspx" runat="server">Register</a></li>
        </ul>
        </div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Golden Needle Films.png" />
        <div id="topNav">
            <ul>
                <li><asp:LinkButton id="Home" runat="server" onclick="home1">Home</asp:LinkButton></li>
                <li><asp:LinkButton id="Browse" runat="server" onclick="browse1">Browse</asp:LinkButton></li>
                <li><asp:LinkButton id="About" runat="server" onclick="about1">About us</asp:LinkButton></li>
            </ul>
        </div>
        <br />
        <asp:LinkButton id="Upload" runat="server" onclick="upload1" CssClass="uploadText">Upload</asp:LinkButton>
        <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
