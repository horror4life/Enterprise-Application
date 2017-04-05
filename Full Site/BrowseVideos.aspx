<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrowseVideos.aspx.cs" Inherits="BrowseVideos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
        #footer {
            position: absolute;
            bottom: 0px;
            left: 40%;
            right: 40%;
        }
        
    </style>
</head>
<body>
    <div class="Logo">
        <div id="topRightNav">
            <ul>
                <li><a id="Log" href="Login.aspx" runat="server">Sign in</a></li>
                <li><a id="Reg" href="Register.aspx" runat="server">Register</a></li>
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
            <div id="videoPadding">

                <asp:Label ID="videos" runat="server"></asp:Label>

                <asp:Table ID="VideoTable" runat="server" HorizontalAlign="Center"></asp:Table>

            </div>
        </div>
        

    <div id="footer" style="display: block; position: absolute; z-index: auto;">
        &copy Golden Needle Films
    </div>
    </form>
</body>
</html>
