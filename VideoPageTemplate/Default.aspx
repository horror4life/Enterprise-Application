<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
    </style>
</head>
<body>
    <asp:Label runat="server" Visible="true"><a href = "#" > Sign In </a></asp:Label><br />
    <asp:Label runat="server" Visible="true"><a href = "#"> Register </a></asp:Label><br />

    <asp:Label runat="server" Visible="false"><a href = "#"> Sign Out </a></asp:Label><br />
    <asp:Label runat="server" Visible="false"><a href = "#"> Upload </a></asp:Label><br />
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Full View" />
            <asp:Label ID="videos" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
