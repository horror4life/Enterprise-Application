<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~/Styles/HomeStyleSheet.css">
</head>
<body>
    <form id="Main" runat="server">
        <div class="Logo">
            <div id="topRightNav">
                <ul>
                    <li><a id="Log" href="Login.aspx" runat="server">Sign in</a></li>
                    <li><a id="Reg" href="Register.aspx" runat="server" onserverclick="check">Register</a></li>
                </ul>
            </div>
            <asp:Image ID="Logo" runat="server" ImageUrl="~/images/Golden Needle Films.png" />
        </div>
        <div id="topNav">
            <ul>
                <li><asp:LinkButton id="home" runat="server" OnClick="home1">Home</asp:LinkButton></li>
                <li><asp:LinkButton id="browse" runat="server" OnClick="browse1">Browse</asp:LinkButton></li>
                <li><asp:LinkButton id="about" runat="server" OnClick="about1">About Us</asp:LinkButton></li>
            </ul>
        </div>
        <div id="NewSection" >
            <h1> What's New? </h1>
            <asp:GridView ID="GridView1" onrowdatabound="GridView1_RowDataBound" runat="server">
            </asp:GridView>
        </div>
        <div id="Footer">
            &copy Golden Needle Films
        </div>
   </form>
</body>
</html>
