<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrowseVideos.aspx.cs" Inherits="BrowseVideos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
    </style>
</head>
<body>
    <div class="Logo">
        <div id="topRightNav">
            <ul>
                <li><a href="Login.aspx">Sign in</a></li>
                <li><a href="Register.aspx">Register</a></li>
            </ul>
        </div>
        <asp:Image ID="Logo" runat="server" ImageUrl="images/Golden Needle Films.png" />
    </div>
    <div id="topNav">
        <ul>
            <li><a href="Home.aspx">Home</a></li>
            <li><a href="BrowseVideos.aspx">Browse</a></li>
            <li><a href="About.aspx">About us</a></li>
        </ul>
    </div>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="videos" runat="server"></asp:Label>
            <asp:Table ID="VideoTable" runat="server">
                
            </asp:Table>
        </div>
    </form>
</body>
</html>
