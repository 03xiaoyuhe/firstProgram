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
            <h2>项目信息批量导入</h2>
            <label style="color:red">注意上传表必须包含首行，首行信息必须按照模板表，可以更改顺序，但不能更改内容</label><asp:Button ID="Button2" runat="server" Text="下载模板表" OnClick="Button2_Click"/><br />
            <asp:FileUpload runat ="server" ID="FileUpload1"/>
            <asp:Button ID="Button1" runat="server" Text="开始录入" OnClick="Button1_Click" />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h2>结果预览&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="下载错误数据行文件" OnClick="Button3_Click" /></h2>
            
            <div>
                <asp:PlaceHolder ID="PlaceHolder2" runat="server">未导入</asp:PlaceHolder>
            </div>
        </div>
    </form>
</body>
</html>
