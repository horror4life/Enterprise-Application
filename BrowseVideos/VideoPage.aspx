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

                <asp:Table ID="Rankings" runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableHeaderCell ID="storyTitle" runat="server"></asp:TableHeaderCell>
                        <asp:TableHeaderCell ID="cineTitle" runat="server"></asp:TableHeaderCell>
                        <asp:TableHeaderCell ID="originTitle" runat="server"></asp:TableHeaderCell>
                        <asp:TableHeaderCell ID="diaTitle" runat="server"></asp:TableHeaderCell>
                        <asp:TableHeaderCell ID="characterTitle" runat="server"></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="story" runat="server"></asp:TableCell>
                        <asp:TableCell ID="cine" runat="server"></asp:TableCell>
                        <asp:TableCell ID="origin" runat="server"></asp:TableCell>
                        <asp:TableCell ID="dia" runat="server"></asp:TableCell>
                        <asp:TableCell ID="character" runat="server"></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

                    <asp:RadioButtonList ID="rankList" runat="server" RepeatDirection="Horizontal" Visible="false">
                        <asp:ListItem Value="1">Storytelling</asp:ListItem>
                        <asp:ListItem Value="2">Cinematography</asp:ListItem>
                        <asp:ListItem Value="3">Originality</asp:ListItem>
                        <asp:ListItem Value="4">Dialogue</asp:ListItem>
                        <asp:ListItem Value="5">Character Development</asp:ListItem>
                    </asp:RadioButtonList>
                <asp:Button ID="submitRank" runat="server" Text="Submit" Visible="false" OnClientClick="sendRanks" />
                
                <asp:ImageButton ID="upVote" runat="server" src="images/upArrow.png" height="50" visible="False" OnClick="likeVideo" />
                <asp:ImageButton ID="downVote" runat="server" src="images/downArrow.png" height="50" visible="False" OnClick="dislikeVideo" />

            </div>
        </div>

    <div id="footer">
        &copy Golden Needle Films
    </div>
    </form>
</body>
</html>
