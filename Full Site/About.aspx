<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/AboutStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Main" runat="server">
    <div class="Logo">
        <div id="topRightNav">
            <ul>
                <li><a href="Login.aspx" id="Log" runat="server">Sign in</a></li>
                <li><a href="Register.aspx" id="Reg" runat="server" onserverclick="check">Register</a></li>
            </ul>
        </div>
        <asp:Image ID="Logo" runat="server" ImageUrl="~/images/Golden Needle Films.png" />
    </div>
    <div id="topNav">
        <ul>
            <li><a href="Home.aspx" runat="server" onserverclick="HomeRedirect">Home</a></li>
            <li><a href="Browse.aspx" runat="server" onserverclick="BrowseRedirect">Browse</a></li>
            <li><a href="About.aspx" runat="server" onserverclick="AboutRedirect">About us</a></li>
        </ul>
    </div>
        <div id="Info">
            Have you ever wondered through millions upon millions of YouTube videos trying to find the perfect independent film? Have you
            ever posted an independent film on YouTube and waited for those sweet views? If you answered yes to either of those questions,
            then the answer to the question, "Did it work?" is probably a no.<br /><br />

            Created by three lazy guys in their capstone college class, Golden Needle Films is a site dedicated to the worldwide exposure
            of independent films and the creators of such films. We firmly believe that independent filmmakers have something to offer
            everyone in this declining "Golden Age" of Hollywood Cinema. Gone are the<br />trials of finding the errors in your art 
            as we begin anew, with your help we can create the new "Golden Age" using our groundbreaking advanced ranking system.<br /><br />
        </div>
        <div id="Footer">
            &copy Golden Needle Films
        </div>
    </form>
</body>
</html>
