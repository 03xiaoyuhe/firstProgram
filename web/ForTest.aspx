<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForTest.aspx.cs" Inherits="WebForm.ForTest" %>
<!-- D:\______myProgram\web\firstProgram\web\ASCX\ProgramInform\ProgramAdd.ascx -->


<%@ Register Src="~/ASCX/MassageForm/PrintMassage.ascx" TagName="Massage" TagPrefix="TMassage" %>
<%@ Register Src="~/ASCX/Table/ForDataTable/ControlFormCell.ascx" TagName="ControlButton" TagPrefix="Table" %>


<%@ Register Src="~/ASCX/Table/ForDataTable/BodyLine.ascx" TagName="BodyLine" TagPrefix="Table" %>

<%@ Register Src="~/ASCX/MassageForm/PrintMassage.ascx" TagPrefix="AAA" TagName="MMM" %>

<%@ Register Src="~/ASCX/BaseForm/ShowBoxForm.ascx" TagName="ProgremInf" TagPrefix="ProgremInf" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../assets/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../assets/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:90%;margin:0 auto;">
            <Table:ControlButton runat="server" ID="Test" />
            <Table:BodyLine runat="server" ID="BodyLine1" />
            <TMassage:Massage runat="server" id="aaa"  ></TMassage:Massage>
        </div>
    </form>
</body>
</html>
