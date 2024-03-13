<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test1.aspx.cs" Inherits="functionPage_test1" %>

<%@ Register Src="~/ASCX/PageIndex.ascx" TagName="PageIndex" TagPrefix="PageIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
   <form runat="server">
       <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
       <PageIndex:PageIndex ID="aaa" runat="server"/>
   </form>
</body>
</html>
