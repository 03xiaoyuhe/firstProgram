<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgremLoad.aspx.cs" Inherits="WebForm.functionPage.QF_ChildPage.ProgremLoad" %>
<!-- 申报项目批量导入页面 -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>


    <link rel="canonical" href="../../bootstrap-5.3.2-examples/sidebars/sidebars.css">

    <style>
        .floatRight{
            float:right;
        }
    </style>

    <%--<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@docsearch/css@3" />--%>

    <link href="../../assets/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="../../CSS/sidebars.css" rel="stylesheet" />
    <link href="../../CSS/ThemeColor.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="width: 100%;">
        <div style="width: 100%">
            <div style="width: 80%; margin: 0 auto;">

                <div style="width: 100px; height: 20px;"></div>
                <h2>申报项目信息批量导入</h2>
                <label style="color: red">注意上传表必须包含首行，首行信息必须按照模板表，可以更改顺序，但不能更改内容</label><br />
                <div style="width:70%;">

                    <asp:Button ID="Button2" CssClass="btn btn-outline-dark" runat="server" Text="下载模板表" OnClick="Button2_Click" />
                    <asp:Button ID="Button3" CssClass="btn btn-outline-dark floatRight" runat="server" Text="下载错误数据行文件" OnClick="Button3_Click" /><br />
                    <div style="width: 100px; height: 10px;"></div>
                    <asp:FileUpload runat="server" CssClass="btn btn-outline-dark" ID="FileUpload1" />
                    <asp:Button ID="Button1" CssClass="btn btn-outline-dark floatRight" runat="server" Text="开始录入" OnClick="Button1_Click" />
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <h2>结果预览&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h2>

            </div>
            <div style="border-radius:10px; margin:10px; overflow:hidden;">
                <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                    <div style="width: 80%; margin: 0 auto;">未导入</div>
                </asp:PlaceHolder>
            </div>
        </div>
    </form>
</body>
<script src="../../JS/QueryFromPageJs.js"></script>
<script src="../../JS/sidebars.js"></script>
</html>
