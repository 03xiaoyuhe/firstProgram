<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeopleInform.aspx.cs" Inherits="WebForm.functionPage.QF_ChildPage.PeopleInform" %>

<!-- 人员信息批量导入页面 -->
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
    
    <header style="height: 30px; border-bottom: 1px solid var(--bs-dark-bg-subtle); margin: 0 10px;">

        <div class="container text-center">
            <div class="row align-items-end">
                <div class="col">

                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">人员信息管理</li>
                            <li class="breadcrumb-item">信息管理</li>
                            <li class="breadcrumb-item active" aria-current="page"><strong>人员信息批量导入</strong></li>
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </header>

    <form id="form1" runat="server" style="width: 100%;height:620px;overflow:auto;">
        <div style="width: 100%">
            <%--<div style="width: 100px; height: 20px;"></div>--%>
            <div style="margin:0 40px;">
                <div>
                    <div class="container text-left"  style="width:900px">
<%--                        <div class="row">
                            <div class="col">
                                <h2>
                                    <strong>人员信息批量导入</strong>
                                </h2>
                            </div>
                        </div>--%>
                        <div class="row">
                            <div class="col" style="margin:5px 0;">
                                <asp:Button ID="Button3" CssClass="btn btn-secondary" runat="server" Text="下载错误数据行文件" OnClick="Button3_Click" />
                                <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="下载模板表" OnClick="Button2_Click" />
                            </div>
                            <div class="col">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="input-group">
                                    <asp:FileUpload runat="server" ID="FileUpload1" class="form-control btn-primary" Style="height: 40px;" />
                                    <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="开始录入" OnClick="Button1_Click" for="FileUpload1" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="alert alert-danger" role="alert" style="margin:10px 0;">
                                    注意上传表必须包含首行，首行信息必须按照模板表，可以更改顺序，但不能更改内容
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <h3 style="margin-left: 30px;">结果预览
                                </h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">

                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
                                                    <div style="width: 80%; margin: 0 auto; height: 160px;">未导入</div>
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
                                                    <div style="width: 80%; margin: 0 auto; height: 160px;">未导入</div>
                                                </asp:PlaceHolder>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%--                <div style="width:70%;">
                    <div style="width: 100px; height: 10px;"></div>
                </div>--%>

        </div>


    </form>
</body>
<script src="../../JS/QueryFromPageJs.js"></script>
<script src="../../JS/sidebars.js"></script>
<script src="../../assets/dist/js/bootstrap.js"></script>
</html>
