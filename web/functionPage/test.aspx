<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="functionPage_test" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link href="../CSS/sidebars.css" rel="stylesheet" />


    <link rel="canonical" href="../bootstrap-5.3.2-examples/sidebars/sidebars.css" />

    <%--<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@docsearch/css@3" />--%>

    <link href="../assets/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href ="../CSS/ThemeColor.css"  rel="stylesheet"/>

    <script type="text/javascript" src="../JS/QueryFormJS.js"></script>
    
    <style type="text/css">
        /*通用属性*/

        .relVerticalCenter { /* 竖直margin必须为零否则会出bug */
            position: relative;
            top: 50%;
            transform: translate(0,-50%);
        }

        /*页面属性*/
        .page-head{
            background: var(--page-head-color);
            color : var(--page-head-word-color);
            width:100%;
            height:60px;
        }
        

        .title{
            font-weight:bold;
            font-style: oblique; 
            font-size:20px;
            /*color: #0000007d;*/
            color:var(--page-head-word-color-default);
            padding-right:10px; 
            border-right: solid 5px #0000007d;
        }




        .card{
            box-shadow: 0 0 5px  black;
            background: var(--page-sidebar-left-color);
        }
    </style>

</head>
<body >
    

    <header class="page-head" >
        <div class="relVerticalCenter">
            <a href="../home.aspx" class="relVerticalCenter align-items-center link-body-emphasis text-decoration-none" >
                <div class="logo"></div>
                <span class="title">
                    哲学与社会科学规划项目信息化管理平台
                </span>
            </a>
            <span>
                
                <button
                        data-bs-toggle="collapse"
                        data-bs-target="#ForProgrem"
                        aria-expanded="true"
                        aria-controls="ForProgrem"
                        for="option5">
                        项目管理
                </button><!--
                --><button
                        for="option6"
                        data-bs-toggle="collapse"
                        data-bs-target="#ForApplication"
                        aria-expanded="true"
                        aria-controls="ForApplication">
                        申请管理
                </button>
            </span>

        </div>
    </header>
    
    <main class="d-flex flex-nowrap">

        <div id="accordionExample" class="clearfix sidebarDiv " style="position: relative; height: 640px;">

            <!-- 项目管理功能栏 -->
            <div
                id="ForProgrem"
                class="collapse collapse-horizontal showing"
                data-bs-parent="#accordionExample">
                <div class="sidebar" style="width: 300px; height:650px; overflow: auto;padding:10px;">
                    <div class="card card-body" style="width: 100%">
                        <div class="d-flex align-items-center pb-3 mb-3 link-body-emphasis text-decoration-none border-bottom">
                            <svg class="bi pe-none me-2" width="30" height="24">
                                <use xlink:href="#bootstrap"></use>
                            </svg>
                            <span class="fs-5 fw-semibold">项目管理</span>
                        </div>
                        <ul class="list-unstyled ps-0">
                            <li class="mb-1">
                                <button class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed" data-bs-toggle="collapse" data-bs-target="#selectProgremInform-collapse" aria-expanded="true">
                                    项目信息查询
                                </button>
                                <div class="collapse" id="selectProgremInform-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded" onclick="selectAll(this)">显示全部</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">在研</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">结项</a></li>
                                    </ul>
                                </div>
                            </li>
                            <li class="mb-1">
                                <button class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed" data-bs-toggle="collapse" data-bs-target="#manageProgram-collapse" aria-expanded="false">
                                    项目信息管理
                                </button>
                                <div class="collapse" id="manageProgram-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded" onclick="addProgram()">快速插入</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">批量导入</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">修改</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Annually</a></li>
                                    </ul>
                                </div>
                            </li>
                            <li class="mb-1">
                                <button class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed" data-bs-toggle="collapse" data-bs-target="#orders-collapse" aria-expanded="false">
                                    Orders
       
                                </button>
                                <div class="collapse" id="orders-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">New</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Processed</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Shipped</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Returned</a></li>
                                    </ul>
                                </div>
                            </li>
                            <li class="border-top my-3"></li>
                            <li class="mb-1">
                                <button class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed" data-bs-toggle="collapse" data-bs-target="#account-collapse" aria-expanded="false">
                                    Account
       
                                </button>
                                <div class="collapse" id="account-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">New...</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Profile</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Settings</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Sign out</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>


            <!-- 申请管理功能栏 -->
            <div
                id="ForApplication"
                class="collapse collapse-horizontal showing sidebarDiv"
                data-bs-parent="#accordionExample">
                <div id="sidebarF" style="width: 300px; height: 650px; overflow: auto;padding:10px;">

                    <div class="card card-body" style="width: 100%;">
                        <div class="d-flex align-items-center pb-3 mb-3 link-body-emphasis text-decoration-none border-bottom">
                            <svg class="bi pe-none me-2" width="30" height="24">
                                <use xlink:href="#bootstrap"></use>
                            </svg>
                            <span class="fs-5 fw-semibold">申请管理</span>
                        </div>
                        <ul class="list-unstyled ps-0">
                            <li class="mb-1">
                                <button onclick="test(this)">test</button>
                            </li>
                            <li class="mb-1">

                                <button class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed" data-bs-toggle="collapse" data-bs-target="#home-collapse" aria-expanded="true">
                                    Home
       
                                </button>
                                <div class="collapse show" id="home-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Overview</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Updates</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Reports</a></li>
                                    </ul>
                                </div>
                            </li>
                            <li class="mb-1">
                                <button class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed" data-bs-toggle="collapse" data-bs-target="#dashboard-collapse" aria-expanded="false">
                                    Dashboard
                                </button>
                                <div class="collapse" id="dashboard-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Overview</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Weekly</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Monthly</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Annually</a></li>
                                    </ul>
                                </div>
                            </li>
                            <li class="mb-1">
                                <button class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed" data-bs-toggle="collapse" data-bs-target="#orders-collapse" aria-expanded="false">
                                    Orders
       
                                </button>
                                <div class="collapse" id="orders-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">New</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Processed</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Shipped</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Returned</a></li>
                                    </ul>
                                </div>
                            </li>
                            <li class="border-top my-3"></li>
                            <li class="mb-1">
                                <button class="btn btn-toggle d-inline-flex align-items-center rounded border-0 collapsed" data-bs-toggle="collapse" data-bs-target="#account-collapse" aria-expanded="false">
                                    Account
       
                                </button>
                                <div class="collapse" id="account-collapse">
                                    <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">New...</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Profile</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Settings</a></li>
                                        <li><a href="#" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Sign out</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>

        <div class="bg-body-tertiary border rounded-3" style="float: right; position: relative; overflow: hidden; width: 100%; height: 650px; margin-right: 30px; margin-top:10px;">
            <iframe id="test" src="" style="width: 100%; height: 100%"></iframe>
        </div>
    </main>
    <script src="../JS/sidebars.js"></script>
    <script src="../assets/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
