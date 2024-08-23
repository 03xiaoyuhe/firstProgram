<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryForm.aspx.cs" Inherits="WebForm.functionPage.QueryForm" %>

<%@ Register Src="~/ASCX/DefaultNONE.ascx" TagPrefix="uc1" TagName="DefaultNONE" %>
<%@ Register Src="~/ASCX/MassageForm/PrintMassage.ascx" TagName="Massage" TagPrefix="TMassage" %>
<%@ Register Src="~/ASCX/MassageForm/PrintMassage.ascx" TagPrefix="AAA" TagName="MMM" %>

<!DOCTYPE html lang="zh-CN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <%--<meta name="generator" content="Hugo 0.118.2">--%>
    <title>哲学与社会科学规划项目信息化管理平台 · 用户主页</title>

    <link rel="icon" href="../../img/logo.png" type="image/x-icon" />





    <%--<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@docsearch/css@3" />--%>



    <style>
        body{
            min-width:1435px;
        }

        .mergin li {
            margin-left: 5px;
            margin-right: 5px;
        }

        .logo { /*
            position: absolute;
            top: 50%;
            transform: translate(0,-50%);*/
            /* 设置背景图 并使其自适应大小 */
            background-image: url("../img/logo.png");
            background-repeat: no-repeat;
            background-size: contain;
            display: inline-table;
            height: 25px;
            width: 25px;
            background-color: white;
        }


        /* 侧边栏容器 */
        .sidebarDiv {
            position: relative;
            float: left;
        }


        /* 功能区 */
        .functionDomain {
            overflow: hidden;
            /*background-color:burlywood;*/
        }


        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            user-select: none;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }

        .b-example-divider {
            width: 100%;
            height: 3rem;
            background-color: rgba(0, 0, 0, .1);
            border: solid rgba(0, 0, 0, .15);
            border-width: 1px 0;
            box-shadow: inset 0 .5em 1.5em rgba(0, 0, 0, .1), inset 0 .125em .5em rgba(0, 0, 0, .15);
        }

        .b-example-vr {
            flex-shrink: 0;
            width: 1.5rem;
            height: 100vh;
        }

        .bi {
            vertical-align: -.125em;
            fill: currentColor;
        }

        .nav-scroller {
            position: relative;
            z-index: 2;
            height: 2.75rem;
            overflow-y: hidden;
        }

            .nav-scroller .nav {
                display: flex;
                flex-wrap: nowrap;
                padding-bottom: 1rem;
                margin-top: -1px;
                overflow-x: auto;
                text-align: center;
                white-space: nowrap;
                -webkit-overflow-scrolling: touch;
            }

        .btn-bd-primary {
            --bd-violet-bg: #712cf9;
            --bd-violet-rgb: 112.520718, 44.062154, 249.437846;
            --bs-btn-font-weight: 600;
            --bs-btn-color: var(--bs-white);
            --bs-btn-bg: var(--bd-violet-bg);
            --bs-btn-border-color: var(--bd-violet-bg);
            --bs-btn-hover-color: var(--bs-white);
            --bs-btn-hover-bg: #6528e0;
            --bs-btn-hover-border-color: #6528e0;
            --bs-btn-focus-shadow-rgb: var(--bd-violet-rgb);
            --bs-btn-active-color: var(--bs-btn-hover-color);
            --bs-btn-active-bg: #5a23c8;
            --bs-btn-active-border-color: #5a23c8;
        }

        .bd-mode-toggle {
            z-index: 100;
        }

            .bd-mode-toggle .dropdown-menu .active .bi {
                display: block !important;
            }

        .clearfix:after {
            clear: both;
            display: block;
            content: ".";
            visibility: hidden;
            height: 0;
        }

        .clearfix {
            zoom: 1;
        }
    </style>


    <!-- Custom styles for this template -->
    <link href="../../CSS/sidebars.css" rel="stylesheet" />
    <link href="../../CSS/ThemeColor.css" rel="stylesheet" />
    <link href="../../assets/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="canonical" href="../../bootstrap-5.3.2-examples/sidebars/sidebars.css"/>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    

    <style type="text/css">
        .page-head {
            --page-head-color: #092f50;
            --page-head-word-color: #f4f9fd;
            background-color: var(--page-head-color);
            color: var(--page-head-word-color);
        }

        .title {
            font-weight: bold;
            font-style: oblique;
            font-size: 18px;
            /*color: #0000007d;*/
            color: var(--page-head-word-color);
            padding-right: 10px;
            border-right: solid 3px #e9ede0;
        }
    </style>
    <style type="text/css">
        .btn-toggle-nav a{
            color:black;
        }

        .btn-toggle-nav a:hover{
            color:var(--bs-tertiary-color);
        }

        .left {
            float: left;
        }

        .right {
            float:right;
            overflow: hidden;
        }

        .test {
            margin: 10px;
            overflow: hidden !important;
            width: 0;
            height: 570px;
            float: left;
            transition: width 0.3s;
            display: block;
        }

        .test-show {
            width: 280px;
        }

        .unshow {
            margin: 0;
            visibility: hidden;
            border: none;
        }
        
        .test-control-checked {
            box-shadow: inset 0 0px 10px 0px #0000008f;
        }
    </style>
</head>   

<body style=" background-color: #e9ede0;">

    <%--  <svg xmlns="http://www.w3.org/2000/svg" class="d-none">
        <symbol id="check2" viewBox="0 0 16 16">
            <path d="M13.854 3.646a.5.5 0 0 1 0 .708l-7 7a.5.5 0 0 1-.708 0l-3.5-3.5a.5.5 0 1 1 .708-.708L6.5 10.293l6.646-6.647a.5.5 0 0 1 .708 0z" />
        </symbol>
        <symbol id="circle-half" viewBox="0 0 16 16">
            <path d="M8 15A7 7 0 1 0 8 1v14zm0 1A8 8 0 1 1 8 0a8 8 0 0 1 0 16z" />
        </symbol>
        <symbol id="moon-stars-fill" viewBox="0 0 16 16">
            <path d="M6 .278a.768.768 0 0 1 .08.858 7.208 7.208 0 0 0-.878 3.46c0 4.021 3.278 7.277 7.318 7.277.527 0 1.04-.055 1.533-.16a.787.787 0 0 1 .81.316.733.733 0 0 1-.031.893A8.349 8.349 0 0 1 8.344 16C3.734 16 0 12.286 0 7.71 0 4.266 2.114 1.312 5.124.06A.752.752 0 0 1 6 .278z" />
            <path d="M10.794 3.148a.217.217 0 0 1 .412 0l.387 1.162c.173.518.579.924 1.097 1.097l1.162.387a.217.217 0 0 1 0 .412l-1.162.387a1.734 1.734 0 0 0-1.097 1.097l-.387 1.162a.217.217 0 0 1-.412 0l-.387-1.162A1.734 1.734 0 0 0 9.31 6.593l-1.162-.387a.217.217 0 0 1 0-.412l1.162-.387a1.734 1.734 0 0 0 1.097-1.097l.387-1.162zM13.863.099a.145.145 0 0 1 .274 0l.258.774c.115.346.386.617.732.732l.774.258a.145.145 0 0 1 0 .274l-.774.258a1.156 1.156 0 0 0-.732.732l-.258.774a.145.145 0 0 1-.274 0l-.258-.774a1.156 1.156 0 0 0-.732-.732l-.774-.258a.145.145 0 0 1 0-.274l.774-.258c.346-.115.617-.386.732-.732L13.863.1z" />
        </symbol>
        <symbol id="sun-fill" viewBox="0 0 16 16">
            <path d="M8 12a4 4 0 1 0 0-8 4 4 0 0 0 0 8zM8 0a.5.5 0 0 1 .5.5v2a.5.5 0 0 1-1 0v-2A.5.5 0 0 1 8 0zm0 13a.5.5 0 0 1 .5.5v2a.5.5 0 0 1-1 0v-2A.5.5 0 0 1 8 13zm8-5a.5.5 0 0 1-.5.5h-2a.5.5 0 0 1 0-1h2a.5.5 0 0 1 .5.5zM3 8a.5.5 0 0 1-.5.5h-2a.5.5 0 0 1 0-1h2A.5.5 0 0 1 3 8zm10.657-5.657a.5.5 0 0 1 0 .707l-1.414 1.415a.5.5 0 1 1-.707-.708l1.414-1.414a.5.5 0 0 1 .707 0zm-9.193 9.193a.5.5 0 0 1 0 .707L3.05 13.657a.5.5 0 0 1-.707-.707l1.414-1.414a.5.5 0 0 1 .707 0zm9.193 2.121a.5.5 0 0 1-.707 0l-1.414-1.414a.5.5 0 0 1 .707-.707l1.414 1.414a.5.5 0 0 1 0 .707zM4.464 4.465a.5.5 0 0 1-.707 0L2.343 3.05a.5.5 0 1 1 .707-.707l1.414 1.414a.5.5 0 0 1 0 .708z" />
        </symbol>
    </svg>

    <div class="dropdown position-fixed bottom-0 end-0 mb-3 me-3 bd-mode-toggle">
        <button class="btn btn-bd-primary py-2 dropdown-toggle d-flex align-items-center"
            id="bd-theme"
            type="button"
            aria-expanded="false"
            data-bs-toggle="dropdown"
            aria-label="Toggle theme (auto)">
            <svg class="bi my-1 theme-icon-active" width="1em" height="1em">
                <use href="#circle-half"></use>
            </svg>
            <span class="visually-hidden" id="bd-theme-text">Toggle theme</span>
        </button>
        <ul class="mergin dropdown-menu dropdown-menu-end shadow" aria-labelledby="bd-theme-text">
            <li>
                <button type="button" class="dropdown-item d-flex align-items-center" data-bs-theme-value="light" aria-pressed="false">
                    <svg class="bi me-2 opacity-50 theme-icon" width="1em" height="1em">
                        <use href="#sun-fill"></use>
                    </svg>
                    Light
                        <svg class="bi ms-auto d-none" width="1em" height="1em">
                            <use href="#check2"></use>
                        </svg>
                </button>
            </li>
            <li>
                <button type="button" class="dropdown-item d-flex align-items-center" data-bs-theme-value="dark" aria-pressed="false">
                    <svg class="bi me-2 opacity-50 theme-icon" width="1em" height="1em">
                        <use href="#moon-stars-fill"></use></svg>
                    Dark
                   
                        <svg class="bi ms-auto d-none" width="1em" height="1em">
                            <use href="#check2"></use></svg>
                </button>
            </li>
            <li>
                <button type="button" class="dropdown-item d-flex align-items-center active" data-bs-theme-value="auto" aria-pressed="true">
                    <svg class="bi me-2 opacity-50 theme-icon" width="1em" height="1em">
                        <use href="#circle-half"></use></svg>
                    Auto
                   
                        <svg class="bi ms-auto d-none" width="1em" height="1em">
                            <use href="#check2"></use></svg>
                </button>
            </li>
        </ul>
    </div>
    --%>


    <script type="text/javascript" src="../JS/QueryFormJS.js"></script>
    
    <header class="border-bottom page-head" style="height:50px;padding:0 20px;padding-top:5px;">
        <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
            <a href="../home.aspx"
                class="d-flex align-items-center mb-2 mb-lg-0 link-body-emphasis text-decoration-none">
                <div class="title">
                    哲学与社会科学规划项目信息化管理平台
                </div>
            </a>
            <ul class="mergin nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0"
                style="margin-left: 50px;">
                <li>
                    <button type="button" class="btn btn-outline-light testchoose" onclick="test(this)" target="test1" style="border: none; ">项目信息管理</button>
                </li>
                <li>
                    <button type="button" class="btn btn-outline-light testchoose" onclick="test(this)" target="test2" style="border: none; ">人员信息管理</button>
                </li>
                <li>
                    <button type="button" class="btn btn-outline-light testchoose" onclick="test(this)" target="test3" style="border: none;" >账号管理</button>
                </li>
            </ul>

            <div class="col-12 col-lg-auto mb-3 mb-lg-0 me-lg-3" role="search">
                <input type="search" class="form-control" placeholder="Search..." aria-label="Search" />
            </div>

            <div class="dropdown text-end">
                <a href="#" class="d-block link-body-emphasis text-decoration-none dropdown-toggle"
                    data-bs-toggle="dropdown" aria-expanded="false">
                    <img src="../img/帐户.png" alt="mdo" width="32" height="32" class="rounded-circle">
                </a>
                <ul class="dropdown-menu text-small">
                    <li><a class="dropdown-item" href="#" onclick="AccountSetting()">账号设置</a></li>
                    <li><a class="dropdown-item" href="#">显示设置</a></li>
                    <hr class="dropdown-divider" />
                    <li><a class="dropdown-item" href="#">Sign out</a></li>
                </ul>
            </div>
        </div>
    </header>



    

    <main class="flex-nowrap"style="height:650px;width:100%;">
        <div class="sidebarDiv left">
            <div id="test1" class="test test-show">
                <!-- 项目管理功能栏 -->
                <div style="width: 280px; height: 570px; overflow: auto;">
                    <div class="card card-body" style="width: 100%">
                        <div
                            class="d-flex align-items-center pb-3 mb-3 link-body-emphasis text-decoration-none border-bottom">
                            <svg class="bi pe-none me-2" width="30" height="24">
                                <use xlink:href="#bootstrap"></use>
                            </svg>
                            <span class="fs-5 fw-semibold">项目管理</span>
                        </div>
                        <ul class="list-unstyled ps-0">
                            <li class="mb-1">
                                <button
                                    class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed"
                                    data-bs-toggle="collapse" data-bs-target="#selectProgremInform-collapse"
                                    aria-expanded="true">
                                    信息导入
                                </button>
                                <div class="collapse show" id="selectProgremInform-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                                onclick="addProgram(this)">快速添加</a></li>
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                                onclick="programLoad(this)">批量导入</a></li>
                                        <%--<li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                             onclick="OngoingProjectLoadPage()">在研项目</a>
                                        </li>
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                             onclick="EndingProjectLoadPage()">结项项目</a>
                                        </li>--%>
                                    </ul>
                                </div>
                            </li>
                            <li class="mb-1">
                                <button
                                    class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed"
                                    data-bs-toggle="collapse" data-bs-target="#manageProgram-collapse"
                                    aria-expanded="false">
                                    信息查询
                                </button>
                                <div class="collapse" id="manageProgram-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li>
                                            <a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                                onclick="selectAll(this)">显示全部</a>
                                        </li>
                                        <li>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                            <li class="mb-1">
                                <button
                                    class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed"
                                    data-bs-toggle="collapse" data-bs-target="#orders-collapse" aria-expanded="false">
                                    信息导出
                                </button>
                                <div class="collapse" id="orders-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                             onclick="OutForEndProgremPage()">年度结项名单</a>
                                        </li>
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded" 
                                            onclick="OutForDeclareProgremPage()">年度项目情况统计表</a>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>

            </div>
            <div id="test2" class="test">

                <!-- 参加人信息管理功能栏 -->

                <div style="width: 280px; height: 570px; overflow: auto;">

                    <div class="card card-body" style="width: 100%">
                        <div
                            class="d-flex align-items-center pb-3 mb-3 link-body-emphasis text-decoration-none border-bottom">
                            <svg class="bi pe-none me-2" width="30" height="24">
                                <use xlink:href="#bootstrap"></use>
                            </svg>
                            <span class="fs-5 fw-semibold">人员信息管理</span>
                        </div>
                        <ul class="list-unstyled ps-0">
                            <li class="mb-1">

                                <button
                                    class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed"
                                    data-bs-toggle="collapse" data-bs-target="#people-dataLoad" aria-expanded="true">
                                    信息录入
                                </button>

                                <div class="collapse show" id="people-dataLoad">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                                onclick="addPeople(this)">快速添加</a>
                                        </li>
                                        <li>
                                            <a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                                onclick="PeopleInform()">批量导入</a>
                                        </li>
<%--                                        <li>
                                            <a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                             onclick="UpdatePeopleInform()">批量更改</a>
                                        </li>--%>
                                    </ul>
                                </div>
                            </li>

                        </ul>
                        <ul class="list-unstyled ps-0">
                            <li class="mb-1">

                                <button
                                    class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed"
                                    data-bs-toggle="collapse" data-bs-target="#people-select" aria-expanded="false">
                                    信息查询
                                </button>

                                <div class="collapse" id="people-select">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li>
                                            <a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                                onclick="PersonInformSelectPage()">显示全部</a>
                                        </li>
                                    </ul>
                                </div>
                            </li>

                        </ul>
                    </div>
                </div>

            </div>
            <div id="test3" class="test">
                <!-- 账号管理功能栏 -->
                <div style="width: 280px; height: 570px; overflow: auto;">

                    <div class="card card-body" style="width: 100%">
                        <div
                            class="d-flex align-items-center pb-3 mb-3 link-body-emphasis text-decoration-none border-bottom">
                            <svg class="bi pe-none me-2" width="30" height="24">
                                <use xlink:href="#bootstrap"></use>
                            </svg>
                            <span class="fs-5 fw-semibold">账号管理</span>
                        </div>
                        <ul class="list-unstyled ps-0">
                            <li class="mb-1">
                                <button
                                    class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed"
                                    data-bs-toggle="collapse" data-bs-target="#accient-collapse" aria-expanded="true">
                                    账号管理
                                </button>
                                <div class="collapse show" id="accient-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                             onclick="ApplicantAcconterSelectPage()">申报人员账号</a>
                                        </li>
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                             onclick="JudgeAccounterPage()">评委账号</a>
                                        </li>
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded"
                                             onclick="StaffManagrmentSelectPage()">工作人员账号</a>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                            <li class="mb-1">
                                <button
                                    class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed"
                                    data-bs-toggle="collapse" data-bs-target="#accient-creat-collapse"
                                    aria-expanded="false">
                                    账号批量生成
                                </button>
                                <div class="collapse" id="accient-creat-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded">申报人员账号</a>
                                        </li>
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded">评委账号</a>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                            <li class="mb-1">
                                <button
                                    class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed"
                                    data-bs-toggle="collapse" data-bs-target="#accient-inform-collapse"
                                    aria-expanded="false">
                                    账号信息绑定
                                </button>
                                <div class="collapse" id="accient-inform-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#"
                                                class="link-body-emphasis d-inline-flex text-decoration-none rounded">申报人员账号</a>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                            <li class="border-top my-3"></li>

                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="right" style="padding: 10px;width:1130px;">

            <div class="" style="overflow: auto; width: 100%; height: 650px;">
                <iframe id="test" src="./QF-ChildPage/UnChoosePage.aspx"
                    style="width: 100%; height: 100%">D:\______myProgram\哲学与社会科学规划项目信息化管理平台\firstProgram\web\functionPage\QF-ChildPage\UnChoosePage.aspx
                </iframe>
            </div>
        </div>
    </main>

    <form runat="server">

        <TMassage:Massage runat="server" ID="aaa"></TMassage:Massage>

    </form>
    <script type="text/javascript">

        // 显示所有项目信息逻辑
        function selectAll() {
            document.getElementById("test").src = "QF-ChildPage/ForProject/selectAll.aspx";
        }

        // 快速添加项目
        function addProgram() {
            document.getElementById("test").src = "QF-ChildPage/ForProject/addProgram.aspx";
        }
        // 快速添加人员
        function addPeople() {
            document.getElementById("test").src = "QF-ChildPage/ForPeople/PeopleInformAdd.aspx";
        }
        // PeopleInform.aspx

        function programLoad() {
            document.getElementById("test").src = "QF-ChildPage/ForProject/ProgremLoad.aspx";
        }

        function PeopleInform() {
            document.getElementById("test").src = "QF-ChildPage/ForPeople/PeopleInform.aspx";
        }

        function OutForEndProgremPage() {
            document.getElementById("test").src = "QF-ChildPage/ForProject/OutForEndProgremPage.aspx";
        }

        function OutForDeclareProgremPage() {
            document.getElementById("test").src = "QF-ChildPage/ForProject/OutForDeclareProgremPage.aspx";
        }

        function ApplicantAcconterSelectPage() {
            document.getElementById("test").src = "QF-ChildPage/ForAcconterApplicantAcconterSelectPage.aspx";
        }

        function JudgeAccounterPage() {
            document.getElementById("test").src = "QF-ChildPage/ForAcconter/JudgeAccounterPage.aspx";
        }
        //JudgeAccounterPage
        // 测试
        function test() {
            document.getElementById("test").src = "https://www.bilibili.com/";
        }

        // PersonInformSelectPage
        function PersonInformSelectPage() {
            document.getElementById("test").src = "QF-ChildPage/ForPeople/PersonInformSelectPage.aspx";
        }

        // StaffManagrmentSelectPage
        function StaffManagrmentSelectPage() {
            document.getElementById("test").src = "QF-ChildPage/ForPeopleStaffManagrmentSelectPage.aspx";
        }

        // OngoingProjectLoadPage
        function OngoingProjectLoadPage() {
            document.getElementById("test").src = "QF-ChildPage/ForProject/OngoingProjectLoadPage.aspx";
        }

        // AccountSetting
        function AccountSetting() {
            document.getElementById("test").src = "QF-ChildPage/ForAccount/AccountSetting.aspx";
        }

        // EndingProjectLoadPage
        function EndingProjectLoadPage() {
            document.getElementById("test").src = "QF-ChildPage/ForProject/EndingProjectLoadPage.aspx";
        }

        // UpdatePeopleInform
        function UpdatePeopleInform() {
            document.getElementById("test").src = "QF-ChildPage/ForPeople/UpdatePeopleInform.aspx";
        }

    </script>

    
<script  type="text/javascript">

    let testToShow;
    let testToHide;

    let testShow = document.getElementsByClassName("test");
    for (let i = 0; i < testShow.length; i++) {
        if (!testShow[i].classList.contains("test-show")) testShow[i].classList.add("unshow");
    }

    function test(obj) {
        /// 获取所有控制按钮
        let testchoosecontain = document.getElementsByClassName("testchoose")

        /// 将所有控制按钮初始化为初始状态
        for (let i = 0; i < testchoosecontain.length; i++) {
            if (testchoosecontain[i].classList.contains("btn-light")) testchoosecontain[i].classList.remove("btn-light");
            if (testchoosecontain[i].classList.contains("test-control-checked")) testchoosecontain[i].classList.remove("test-control-checked");
            if (!testchoosecontain[i].classList.contains("btn-outline-light")) testchoosecontain[i].classList.add("btn-outline-light");
        }

        let ID = obj.getAttribute("target");
        /// 获取触发按钮绑定的盒子
        let targetDiv = document.getElementById(ID);

        testToShow = null;
        testToHide = null;

        let testShow = document.getElementsByClassName("test");
        let testShowed = document.getElementsByClassName("test-show");

        /// 清除所有盒子的动画完播事件
        for (let i = 0; i < testShow.length; i++) {
            testShow[i].transitionend = () => { };
            if (!testShow[i].classList.contains("test-show")) testShow[i].classList.add("unshow");
        }

        /// 判断是隐藏当前盒子还是显示当前盒子
        if (!targetDiv.classList.contains("test-show")) {

            if (obj.classList.contains("btn-outline-light")) {
                obj.classList.remove("btn-outline-light");
                obj.classList.add("btn-light");
                obj.classList.add("test-control-checked");
            }
            if (!obj.classList.contains("test-control-checked")) obj.classList.add("test-control-checked");

            console.log(testShowed);
            testToShow = targetDiv;
            if (testShowed.length > 0) {
                testToHide = testShowed[0];
            }
        }
        else {

            testToHide = targetDiv;
        }


        /// 判断是否有盒子需要隐藏
        if (testToHide != null) {
            testToHide.classList.remove("test-show");
            testToHide.ontransitionend = () => {
                testToHide.classList.add("unshow");
                if (testToShow != null) {
                    testToShow.classList.remove("unshow");
                    testToShow.classList.add("test-show");
                }
            };
        }
        else {
            testToShow.classList.remove("unshow");
            testToShow.classList.add("test-show");
        }
    }
</script>

    
    <script type="text/javascript" src="../../assets/dist/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript" src="../../assets/js/color-modes.js"></script>
    <script type="text/javascript" src="../../JS/QueryFromPageJs.js"></script>
    <script type="text/javascript" src="../../JS/sidebars.js"></script>
</body>
</html>
