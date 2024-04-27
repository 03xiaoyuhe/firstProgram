<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgremLoad.aspx.cs" Inherits="WebForm.functionPage.QF_ChildPage.ProgremLoad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:FileUpload runat ="server" ID="FileUpload1"/>
            <asp:Button ID="Button1" runat="server" Text="开始录入" OnClick="Button1_Click" />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h2>结果预览</h2>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server">未导入</asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
