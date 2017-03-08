<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="UploadStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="topRightNav">
        <ul>
            <li><a href="Login.aspx">Sign in</a></li>
            <br />
            <li><a href="Register.aspx">Register</a></li>
        </ul>
        </div>
        <asp:Image ID="Image1" runat="server" ImageUrl="Logo2.png" />
        <div id="topNav">
            <ul>
                <li><a href="Home.aspx">Home</a></li>
                <li><a href="Browse.aspx">Browse</a></li>
                <li><a href="About.aspx">About us</a></li>
            </ul>
        </div>
        <br />
        <p style="margin-left: 440px">Select a video file:
            <asp:FileUpload ID="FileUpload1" runat="server" style="margin-left: 3px" /></p>
        <asp:Button Text="Upload" runat="server" OnClick="FTPUpload" Width="122px" style="margin-left: 564px" />
        <br />
        <asp:Label ID="lblMessage" runat="server" />
    </div>
    
    </form>
</body>
</html>
