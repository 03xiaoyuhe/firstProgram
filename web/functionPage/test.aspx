<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebForm.functionPage.test" %>

<%@ Register Src="~/ASCX/PageIndex.ascx" TagName="PageIndex" TagPrefix="PageIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请选择要上传的文件：<asp:FileUpload ID="fileup" runat="server" OnLoad="fileup_DataBinding" AllowMultiple="True" />
            <asp:Button ID="btnUpload" runat="server" Text="开始上传"  OnClick="btnUpload_Click"/>
            <asp:Button ID="Button1" runat="server" Text="Button" />
            <br />
            <asp:Literal ID="lblMsg" runat="server"></asp:Literal>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
