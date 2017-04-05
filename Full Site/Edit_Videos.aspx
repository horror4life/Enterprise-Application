<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit_Videos.aspx.cs" Inherits="Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/EditVideoStyles.css" rel="stylesheet" type="text/css" />
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
                <li><asp:LinkButton href="Home.aspx" runat="server" onserverclick="home1">Home</asp:LinkButton></li>
                <li><asp:LinkButton href="Browse.aspx" runat="server" onserverclick="browse1">Browse</asp:LinkButton></li>
                <li><asp:LinkButton href="About.aspx" runat="server" onserverclick="about1">About us</asp:LinkButton></li>
            </ul>
        </div>
        <br />
        <br />
        <div id="midNav">
            <ul>
                <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" runat="server"></asp:GridView>
                <li></li><asp:Button ID="updateVideo1" runat="server" OnClick="UpdateVideo1" Text="Update" style="margin-left: 96px" />
            </ul>
        </div>
        <br />
    </div>
    </form>
</body>
</html>
