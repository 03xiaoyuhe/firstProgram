<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JudgeAccounterPage.aspx.cs" Inherits="WebForm.functionPage.QF_ChildPage.JudgeAccounterPage" %>

<!-- 评委账号管理 -->

<%@ Register Src="~/ASCX/PageIndex.ascx" TagName="PageIndex" TagPrefix="PageIndex" %>
<%@ Register Src="~/ASCX/Table/MyTable.ascx" TagName="Table" TagPrefix="Table" %>
<%@ Register Src="~/ASCX/MassageForm/PrintMassage.ascx" TagName="PrintMassage" TagPrefix="TPrintMassage" %>
<%@ Register Src="~/ASCX/Table/ForMyTable/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>
<%@ Register Src="~/ASCX/Loading.ascx" TagName="Load" TagPrefix="Loading" %>

<%@ Register Src="~/ASCX/Filtrate/FiltrateForm.ascx" TagName="FiltrateForm" TagPrefix="Filtrate" %>

<!--D:\______myProgram\哲学与社会科学规划项目信息化管理平台\firstProgram\web\ASCX\Filtrate\FiltrateItemForm.ascx -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    
    <link href="../../../../assets/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="../../../../bootstrap-5.3.0-alpha1-dist/css/bootstrap-reboot.min.css" rel="stylesheet" />
    <style>
        .show-style {
            position: absolute;
            inset: 0px auto auto 0px;
            margin: 0px;
            margin-top: -10px;
            transform: translate3d(0px, 41.6px, 0px);
        }
        .showdow-only-top {
            box-shadow: 0px -10px 10px -10px #5E5E5E;
        }

        .TreeButtom {
            float: left;
            margin: 0 auto;
            border: none;
            background: none;
            position: absolute;
        }

        .Center {
            position: absolute;
            left: 50%;
            transform: translate(-50%,0);
        }

        .list-group {
            box-shadow: 0 0 10px 2px rgba(0,0,0, 0.3);
            visibility: hidden;
            opacity: 0;
            transition: opacity 0.5s;
            /*content: attr(data-descr);*/
            position: absolute;
            left: 12px;
            top: 24px;
            min-width: 200px;
            border: 1px #aaaaaa solid;
            border-radius: 10px;
            color: #000000;
            font-size: 14px;
            z-index: 1000;
        }
        span[data-descr] {
            position: relative;
            text-decoration: underline;
            background-color:#fff;
            color: #00f;
        }

            span[data-descr]:hover::after {
                content: attr(data-descr);
                position: absolute;
                left: 0;
                bottom:30px;
                min-width: 120px;
                border: 1px #aaaaaa solid;
                border-radius: 10px;
                padding: 12px;
            background-color:#fff;
                color: #000000;
                font-size: 14px;
                z-index: 1;
            }

        .mirrorRotateVertical {
            transform: rotateX(180deg); /* 垂直镜像翻转 */
        }
        /*
        span[data-descr] {
            position: relative;
            text-decoration: underline;
        }

            span[data-descr]:hover .list-group {
                opacity: 1;
                visibility: visible;
            }*/
    </style>
</head>
<body>
    <header style="height: 30px; border-bottom: 1px solid var(--bs-dark-bg-subtle); margin: 0 10px;">

        <div class="container text-center">
            <div class="row align-items-end">
                <div class="col">

                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">账号管理</li>
                            <li class="breadcrumb-item active" aria-current="page"><strong>评委账号管理</strong></li>
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </header>

    <form id="form1" runat="server">

        <div class="container text-left" style="width: 1000px">
            <div class="row align-items-end" style="margin-bottom: 10px;">
                <div class="col">
                    <h2 style="display: inline-block;">
                        <strong>&nbsp;评委账号管理</strong>
                    </h2>
                    
                    <a href="#" class="link-body-emphasis text-decoration-none rounded btn btn-sm btn-outline-dark" data-bs-toggle="modal" data-bs-target="#exampleModal">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-funnel" viewBox="0 0 16 16" style="margin: 0 auto;">
                            <path d="M1.5 1.5A.5.5 0 0 1 2 1h12a.5.5 0 0 1 .5.5v2a.5.5 0 0 1-.128.334L10 8.692V13.5a.5.5 0 0 1-.342.474l-3 1A.5.5 0 0 1 6 14.5V8.692L1.628 3.834A.5.5 0 0 1 1.5 3.5v-2zm1 .5v1.308l4.372 4.858A.5.5 0 0 1 7 8.5v5.306l2-.666V8.5a.5.5 0 0 1 .128-.334L13.5 3.308V2h-11z" />
                        </svg>
                    </a>

                    <span class="dropdown">
                        <a class="btn btn-sm btn-outline-dark dropdown-toggle link-body-emphasis" role="button"
                            target="dropdown1" onclick="test(this)" onblur="">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                                class="bi bi-filter-square" viewBox="0 0 16 16">
                                <path
                                    d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1h12zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z" />
                                <path
                                    d="M6 11.5a.5.5 0 0 1 .5-.5h3a.5.5 0 0 1 0 1h-3a.5.5 0 0 1-.5-.5zm-2-3a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zm-2-3a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-11a.5.5 0 0 1-.5-.5z" />
                            </svg>
                        </a>
                        <span class="dropdown-menu" id="dropdown1" style="padding: 0; z-index: 1000;padding:10px;">
                            <div class="card-body">
                                <p style="margin:5px;">
                                    <strong>排序:</strong>
                                    <span data-descr="切换排序方向" style="float: right;">
                                        <span id="Button2body" class="<% ="btn btn-light btn-sm "+(CountSort%2==0?"": "mirrorRotateVertical") %>" style="position: relative;" >
                                            <asp:Button ID="Button2" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Style="background: none; border: none; float: left; position: absolute; left: 0;z-index:100;" OnClick="Button2_Click" />
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-bar-chart" style="transform: rotate(90deg);" viewBox="0 0 16 16">
                                                <path d="M4 11H2v3h2v-3zm5-4H7v7h2V7zm5-5v12h-2V2h2zm-2-1a1 1 0 0 0-1 1v12a1 1 0 0 0 1 1h2a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1h-2zM6 7a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v7a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1V7zm-5 4a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v3a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1v-3z" />
                                            </svg>
                                        </span>
                                    </span>
                                </p>
                                <p class="card-text">
                                    <li class="list-group-item">
                                        <div class="d-grid">
                                            <asp:Button ID="Button4" class="btn btn-light btn-sm" runat="server" Text="立项编号" OnClick="Button4_Click" />
                                            <asp:Button ID="Button5" class="btn btn-light btn-sm" runat="server" Text="项目评级" OnClick="Button5_Click"/>
                                            <asp:Button ID="Button6" class="btn btn-light btn-sm" runat="server" Text="项目名称"  OnClick="Button6_Click"/>
                                            <asp:Button ID="Button3" class="btn btn-light btn-sm" runat="server" Text="项目完成时间" OnClick="Button3_Click" />
                                        </div>
                                    </li>
                                </p>
                            </div>
                        </span>
                    </span>
                </div>



                <div class="col text-right">
                    <div>
                        <!--style="float: right; width: 500px;"-->
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <span class="input-group">
                                    <asp:TextBox
                                        ID="TextBox1"
                                        runat="server"
                                        class="form-control form-control-sm"
                                        type="search"
                                        placeholder="输入搜索内容"
                                        aria-label=".form-control-sm example"></asp:TextBox>
                                    <asp:Button ID="Button1" class="btn btn-primary input-group-text" for="TextBox1" runat="server" Text="搜索" OnClick="Button1_Click" />
                                </span>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col">
                    <%--<div class="card" style="border-radius:10px; overflow:hidden;">--%>
                    <%--<TPrintMassage:PrintMassage ID="aaa" runat="server" />--%>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" OnLoad="PlaceHolder1_Load">
                                <Loading:Load runat="server" ID="Load" />
                            </asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <%--</div>--%>
                </div>
            </div>

            <div class="row text-center">
                <div class="col">
                    <PageIndex:PageIndex ID="aaa" runat="server" CssClass="Center" />
                </div>
            </div>
        </div>


        <!-- 筛选功能页 class="modal-dialog modal-dialog-centered" -->

        <div class="modal fade" id="exampleModal" style="background-color: rgba(0,0,0,0.2);" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">

            <Filtrate:FiltrateForm runat="server" ID="Filtrate" />
        </div>

    </form>
    <script src="../../../../JS/QueryFromPageJs.js"></script>
    <script src="../../../../JS/sidebars.js"></script>
    <script src="../../../../assets/dist/js/bootstrap.js"></script>
    <script type="text/javascript" src="../../../../assets/js/color-modes.js"></script>

    <script type="text/javascript">

        function test(obj) {
            let targetID = obj.getAttribute("target");
            let targetName = document.getElementById(targetID);
            console.log(targetName);
            console.log(targetName.classList);
            if (targetName.classList.contains("show")) {
                targetName.classList.remove("show");//show-style
                targetName.classList.remove("show-style");
            }
            else {
                targetName.classList.add("show");
                targetName.classList.add("show-style");
            }
        }

        function Translate(obj)
        {
            if(obj.classList.contains("mirrorRotateVertical")) obj.classList.remove("mirrorRotateVertical");
            else obj.classList.add("mirrorRotateVertical");
        }

    </script>
</body>
</html>
