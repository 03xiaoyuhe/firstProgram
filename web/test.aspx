<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>
<%--<pages enableEventValidation="false"/>--%>
<%@ Register Src="~/ASCX/Table/Table.ascx" TagName="Table" TagPrefix="Table" %>
<%@ Register Src="~/ASCX/Massage/PrintMassage.ascx" TagName="PrintMassage" TagPrefix="TPrintMassage" %>

<%@ Register Src="~/ASCX/Table/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link href="assets/dist/css/bootstrap.min.css" rel="stylesheet">
        <link href="./bootstrap-5.3.0-alpha1-dist/css/bootstrap-reboot.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--<TPrintMassage:PrintMassage ID="aaa" runat="server" />--%>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server" OnLoad="PlaceHolder1_Load"></asp:PlaceHolder>
    </form>
</body>
</html>
