<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgremLoad.aspx.cs" Inherits="WebForm.functionPage.QF_ChildPage.ProgremLoad" %>

<!-- 申报项目批量导入页面 -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>


    <link rel="canonical" href="../../bootstrap-5.3.2-examples/sidebars/sidebars.css">

    <style>
        .upload > button {
            display: none;
        }

        .floatRight {
            float: right;
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
            <div style="width: 100px; height: 20px;"></div>
            <h2 style="margin-left: 30px;"><strong>申报项目信息批量导入</strong>
                <asp:Button ID="Button2" CssClass="btn btn-outline-dark" runat="server" Text="下载模板表" OnClick="Button2_Click" />
            </h2>
            <div style="margin-left:40px;">
                <asp:FileUpload runat="server" CssClass="btn btn-outline-dark upload" ID="FileUpload1" Style="height: 40px;" />
                <asp:Button ID="Button1" CssClass="btn btn-outline-dark" runat="server" Text="开始录入" OnClick="Button1_Click" />

                <label style="color: red">注意上传表必须包含首行，首行信息必须按照模板表，可以更改顺序，但不能更改内容</label><br />

            </div>

            <%--                <div style="width:70%;">
                    <div style="width: 100px; height: 10px;"></div>
                </div>--%>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
        <h3 style="margin-left: 30px;">结果预览
                    <asp:Button ID="Button3" CssClass="btn btn-outline-dark" runat="server" Text="下载错误数据行文件" OnClick="Button3_Click" />

        </h3>
        <div style="border-radius: 10px; margin: 10px; margin-left: 30px; margin-right: 30px; overflow: hidden;">
            <div class="accordion" id="accordionExample">
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingOne">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                            查看已导入数据 #1
                        </button>
                    </h2>
                    <div id="collapseOne" class="accordion-collapse collapse" aria-labelledby="headingOne" data-bs-parent="#accordionExample">
                        <div class="accordion-body">
                            <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                                <div style="width: 80%; margin: 0 auto; height: 265px;">未导入</div>
                            </asp:PlaceHolder>
                        </div>
                    </div>
                </div>
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingTwo">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                            查看重名信息 #2
                        </button>
                    </h2>
                    <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-bs-parent="#accordionExample">
                        <div class="accordion-body">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                                <div style="width: 80%; margin: 0 auto; height: 265px;">未导入</div>
                            </asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
<script src="../../JS/QueryFromPageJs.js"></script>
<script src="../../JS/sidebars.js"></script>
<script src="../../assets/dist/js/bootstrap.js"></script>
</html>
