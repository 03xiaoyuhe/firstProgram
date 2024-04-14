<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestP.aspx.cs" Inherits="WebForm.functionPage.TestP" %>

<%@ Register Src="~/ASCX/FileUpLoad/FilrUpLoadFormMain.ascx" TagPrefix="uc1" TagName="FilrUpLoadForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AjaxFrameworkMode="Disabled"></asp:ScriptManager>
        <uc1:FilrUpLoadForm runat="server" ID="test" />
    </form>
</body>
</html>
