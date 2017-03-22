<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoPage.aspx.cs" Inherits="VideoPage" %>

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
                <asp:Table ID="videoInfo" runat="server" HorizontalAlign="Center">
                </asp:Table>
                
                <asp:ImageButton ID="upVote" runat="server" src="images/upArrow.png" height="50" visible="False" OnClick="likeVideo" />
                <asp:ImageButton ID="downVote" runat="server" src="images/downArrow.png" height="50" visible="False" OnClick="dislikeVideo" />
                <%--<input type="image" src="images/upArrow.png" height="50" id="upVote" runat="server" alt="Upvote Video" visible="False" />--%>
                <%--<input type="image" src="images/downArrow.png" height="50" id="downVote" runat="server" alt="Downvote Video" visible="False"   />--%>

            </div>
        </div>
    </form>
</body>
</html>
