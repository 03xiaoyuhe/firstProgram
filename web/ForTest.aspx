<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForTest.aspx.cs" Inherits="WebForm.ForTest" %>
<!-- D:\______myProgram\web\firstProgram\web\ASCX\ProgramInform\ProgramAdd.ascx -->

<%@ Register Src="~/ASCX/ProgramInform/ProgramShow.ascx" TagName="ProgremInf" TagPrefix="ProgremInf" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:90%;margin:0 auto;">
           <ProgremInf:ProgremInf runat="server" ID ="ProgremInf"></ProgremInf:ProgremInf>

        </div>
    </form>
</body>
</html>
