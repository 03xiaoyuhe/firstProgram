<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/handing.master" AutoEventWireup="true" CodeFile="QueryFormTest.aspx.cs" Inherits="functionPage_QueryForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="../bootstrap-5.3.0-alpha1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../bootstrap-5.3.0-alpha1-dist/js/bootstrap.bundle.min.js"></script>
    <style>
        /* 通用功能属性 */
        /* 竖直居中 使用相对定位*/
        .relVerticalCenter { /* 竖直margin必须为零否则会出bug */
            position: relative;
            top: 50%;
            transform: translate(0,-50%);
        }

        /* 将标签设置为显示 */
        .Display {
            display: block;
        }

        /* 将标签设置为不可见 */
        .UnDisplay {
            display: none;
        }
        /* 特定功能属性 */

        .QF-body {
            position: relative;
            min-width: 1200px;
            max-width: 1550px;
            margin: auto;
            /* 设置背景图 并使其自适应大小 */
            background-image: url("img/homeHeadImg.jpg");
            background-repeat: no-repeat;
            background-size: contain;
            height: 100%;
        }


        /* 三栏页面 */
        #tripleVessel {
            height: 100%;
            background-color: blue;
            overflow: hidden;
        }

        /* 辅助定位盒子 */
        .help {
            height: 40px;
        }

        /* 横幅样式 */
        .banner {
            border-top: 2px solid #4E6EF2;
            background-color: rgb(233, 235, 239);
            text-align: left;
            overflow: hidden;
        }

        /* 横幅按钮未点击样式 */
        .fenture1 {
            height: 40px;
            border: none;
            background-color: rgb(0, 0, 0, 0.00);
            margin: 0;
            padding: 0;
            width: 80px;
            display: inline-block;
        }

            /* 横幅按钮聚焦动态 */
            .fenture1:hover {
                background-color: rgb(0, 0, 0, 0.15)
            }

        /* 横幅按钮点击后样式 */
        .fenture1OverCleck {
            height: 40px;
            border: none;
            background-color: rgb(0, 0, 0, 0.3);
            margin: 0;
            padding: 0;
            width: 80px;
            display: inline-block;
        }

        /* 搜索栏样式 */
        .searchDiv {
            width: 300px;
            overflow: hidden;
            padding: 0;
            height: 30px;
            text-align: end;
        }

        /* 搜索输入框样式 */
        .searchBox {
            padding-left: 16px;
            font-size: 16px;
            width: 100%;
            background: rgb(223, 234, 244);
        }

            .searchBox:focus {
                border: hidden;
            }

            .searchBox:hover {
                background-color: rgb(0, 0, 0, 0.30)
            }

        .searchBoxHelp {
            top: -1px;
            left: -1px;
            width: 100px;
            height: 30px;
            border: hidden;
        }

        .searchButtonDiv {
            height: 28px;
            float: right;
        }

        /* 侧边栏容器 */
        .sidebarDiv {
            position: relative;
            float: left;
            height: 640px;
        }

        /* 侧边栏样式 */
        .sidebar {
            width: 200px;
            height: 100%;
            background-color: rgb(206, 221, 228);
            overflow: hidden;
        }

        .sidebarAllDiv {
            overflow: hidden;
            width: 100%;
            padding: 0;
            margin: 0;
            border-radius: 0;
            background-color:rgba(0, 0, 0, 0);
        }

        /* 侧边栏按钮容器 */
        .sidebarButtomDiv {
            background-color: rgb(255, 255, 255);
            width: 100%;
        }

            .sidebarButtomDiv:hover {
                background-color: rgb(229.5, 229.5, 229.5, 0.9)
            }


        .sidebarButtomHelpDiv {
            overflow: hidden;
        }

        /* 侧边栏按钮 */
        .sidebarButtom {
            background-color: rgb(0, 0, 0, 0);
            text-align: left;
            width: 100%;
            height:25px;
            border: none;
            margin: 0;
            padding: 0;
        }


        /* 侧边栏子功能按钮前插图片 */
        .sidebarButtomImg {
            float:right;
            height: 25px;
            width: 25px; /*
            background-color: rgb(0, 0, 0, 0.15);*/
        }

        /* 侧边栏子页 */
        .sidbarChildDiv {
            padding-left: 20px;
            background-color:rgba(0, 0, 0, 0);
        }

        /* 功能区 */
        .functionDomain {
            overflow: hidden;
            min-height: 600px;
            height: 640px;
            /*background-color:burlywood;*/
        }


        .father {
            text-align: center;
            padding-top: 20px;
        }


        .input {
            width: 260px;
        }


        .btn {
            width: 100%;
            height: 100%;
            font-size: 12px;
            background: #4E6EF2;
            color: white;
            border-color: #4E6EF2;
            border: none; /* 边框线有一个立体感，去掉立体感 */
            /*vertical-align: top;*/ /* 让这两个都顶部对齐 */
        }

            .btn:hover {
                background: rgb(149, 205, 243);
            }
    </style>


    <div id="tripleVessel" class="QF-body" runat="server">
        <div class="help">
        </div>
        <!-- 横幅 -->
        <div id="banner" runat="server" class="banner">

            <div style="float: right; height: 30px; border-radius: 7px; overflow: hidden; border: 1px solid #4E6EF2; margin: 5px auto; padding: 0;">
                <div class="input-group mb-3 searchDiv" style="height: 30px;">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control searchBox" Style="width: 80%; height: 100%">搜索</asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="搜索" class="btn btn-outline-secondary" Style="width: 20%; height: 100%" />
                </div>
            </div>


            <asp:Button ID="turnBackToHome" runat="server" Text="回到主页" CssClass="fenture1" OnClick="turnBackToHome_Click" ValidationGroup="aaa1" /><!--
        --><asp:Button ID="filtrateBtm" runat="server" Text="项目" CssClass="fenture1" OnClick="allNavigationBarBtm_Click" ValidationGroup="aaa2" /><!--
        --><asp:Button ID="pagingBtm" runat="server" Text="申请" CssClass="fenture1" OnClick="allNavigationBarBtm_Click" ValidationGroup="aaa" /><!--
        --><asp:Button ID="settingBtm" runat="server" Text="设置" CssClass="fenture1" OnClick="allNavigationBarBtm_Click" ValidationGroup="aaa4" />

        </div>

        <!-- 侧边栏 -->
        <div class="sidebarDiv">


            <!-- 项目对应的子功能-->
            <asp:PlaceHolder ID="filtrateSidebar" runat="server">

                <!-- 项目及其子功能容器 -->
                <div class="sidebar">


                    <!-- 显示全部 按钮及其子功能容器 -->
                    <div class="sidebarAllDiv">
                        <!-- 显示全部 按键容器 -->
                        <div class="sidebarButtomDiv">
                            
                            <!-- 按钮前插图片 -->
                            <svg 
                                xmlns="http://www.w3.org/2000/svg" 
                                width="16" height="16" 
                                fill="currentColor" 
                                class="sidebarButtomImg bi bi-box-arrow-in-right" 
                                viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M6 3.5a.5.5 0 0 1 .5-.5h8a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-8a.5.5 0 0 1-.5-.5v-2a.5.5 0 0 0-1 0v2A1.5 1.5 0 0 0 6.5 14h8a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-8A1.5 1.5 0 0 0 5 3.5v2a.5.5 0 0 0 1 0z" />
                                <path fill-rule="evenodd" d="M11.854 8.354a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5H1.5a.5.5 0 0 0 0 1h8.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3z" />
                            </svg>
                            <!-- 按钮辅助定位盒子 -->
                            <div class="sidebarButtomHelpDiv">

                                <!-- 显示全部 按钮 -->
                                <asp:Button ID="ShowAll" runat="server" Text="显示全部" CssClass="sidebarButtom" ValidationGroup="aaa3" OnClick="ShowAll_Click" />

                            </div>
                        </div>

                    </div>

                    <!-- 筛选 及其子功能容器 -->
                    <div class="accordion accordion-flush sidebarAllDiv" id="accordionFlushExample">
                        <div class="accordion-item">
                            <h2 class="accordion-header sidebarButtomHelpDiv">
                                <button
                                    class="accordion-button collapsed sidebarButtom"
                                    type="button"
                                    data-bs-toggle="collapse"
                                    data-bs-target="#flush-collapseOne"
                                    aria-expanded="false"
                                    aria-controls="flush-collapseOne">
                                    筛选
                                </button>
                            </h2>
                            <div id="flush-collapseOne" class="accordion-collapse collapse" data-bs-parent="#accordionFlushExample">

                                <div class="sidbarChildDiv">

                                    <!-- 精确筛选 按钮及其子功能容器 -->
                                    <div class="sidebarAllDiv">
                                        <!-- 精确筛选 按键容器 -->
                                        <div class="sidebarButtomDiv">

                                            <!-- 按钮前插图片 -->
                                            <svg
                                                xmlns="http://www.w3.org/2000/svg"
                                                width="16" height="16"
                                                fill="currentColor"
                                                class="sidebarButtomImg bi bi-box-arrow-in-right"
                                                viewBox="0 0 16 16">
                                                <path fill-rule="evenodd" d="M6 3.5a.5.5 0 0 1 .5-.5h8a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-8a.5.5 0 0 1-.5-.5v-2a.5.5 0 0 0-1 0v2A1.5 1.5 0 0 0 6.5 14h8a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-8A1.5 1.5 0 0 0 5 3.5v2a.5.5 0 0 0 1 0z" />
                                                <path fill-rule="evenodd" d="M11.854 8.354a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5H1.5a.5.5 0 0 0 0 1h8.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3z" />
                                            </svg>

                                            <!-- 按钮辅助定位盒子 -->
                                            <div class="sidebarButtomHelpDiv">

                                                <!-- 精确筛选 按钮 -->
                                                <asp:Button ID="Button3" runat="server" Text="精确筛选" CssClass="sidebarButtom" ValidationGroup="aaa3" OnClick="AccurateSizingBtn_Click" />

                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            </asp:PlaceHolder>


            <!-- 申请对应子功能 -->
            <asp:PlaceHolder ID="PagingSidebar" runat="server" Visible="false">

                <!-- 筛选及其子功能容器 -->
                <div class="sidebar">

                    <!-- 显示全部 按钮及其子功能容器 -->
                    <div class="sidebarAllDiv">
                        <!-- 显示全部 按键容器 -->
                        <div class="sidebarButtomDiv">

                            <!-- 按钮前插图片 -->
                            <svg 
                                xmlns="http://www.w3.org/2000/svg" 
                                width="16" height="16" 
                                fill="currentColor" 
                                class="sidebarButtomImg bi bi-box-arrow-in-right" 
                                viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M6 3.5a.5.5 0 0 1 .5-.5h8a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-8a.5.5 0 0 1-.5-.5v-2a.5.5 0 0 0-1 0v2A1.5 1.5 0 0 0 6.5 14h8a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-8A1.5 1.5 0 0 0 5 3.5v2a.5.5 0 0 0 1 0z" />
                                <path fill-rule="evenodd" d="M11.854 8.354a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5H1.5a.5.5 0 0 0 0 1h8.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3z" />
                            </svg>

                            <!-- 按钮辅助定位盒子 -->
                            <div class="sidebarButtomHelpDiv">

                                <!-- 显示全部 按钮 -->
                                <asp:Button ID="ShowAllApplica" runat="server" Text="显示全部" CssClass="sidebarButtom" ValidationGroup="aaa3" OnClick="ShowAllApplica_Click" />

                            </div>
                        </div>

                    </div>

                    <!-- 子功能一及其子功能容器 -->
                    <!-- 筛选 及其子功能容器 -->
                    <div class="accordion accordion-flush sidebarAllDiv" id="accordionFlushExampl">
                        <div class="accordion-item">
                            <h2 class="accordion-header sidebarButtomHelpDiv">
                                <button
                                    class="accordion-button collapsed sidebarButtom"
                                    type="button"
                                    data-bs-toggle="collapse"
                                    data-bs-target="#flush-collapseOn"
                                    aria-expanded="false"
                                    aria-controls="flush-collapseOn">
                                    筛选
                                </button>
                            </h2>
                            <div id="flush-collapseOn" class="accordion-collapse collapse" data-bs-parent="#accordionFlushExampl">

                                <div class="sidbarChildDiv">

                                    <!-- 精确筛选 按钮及其子功能容器 -->
                                    <div class="sidebarAllDiv">
                                        <!-- 精确筛选 按键容器 -->
                                        <div class="sidebarButtomDiv">

                                            <!-- 按钮前插图片 -->
                                            <svg
                                                xmlns="http://www.w3.org/2000/svg"
                                                width="16" height="16"
                                                fill="currentColor"
                                                class="sidebarButtomImg bi bi-box-arrow-in-right"
                                                viewBox="0 0 16 16">
                                                <path fill-rule="evenodd" d="M6 3.5a.5.5 0 0 1 .5-.5h8a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-8a.5.5 0 0 1-.5-.5v-2a.5.5 0 0 0-1 0v2A1.5 1.5 0 0 0 6.5 14h8a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-8A1.5 1.5 0 0 0 5 3.5v2a.5.5 0 0 0 1 0z" />
                                                <path fill-rule="evenodd" d="M11.854 8.354a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5H1.5a.5.5 0 0 0 0 1h8.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3z" />
                                            </svg>

                                            <!-- 按钮辅助定位盒子 -->
                                            <div class="sidebarButtomHelpDiv">

                                                <!-- 精确筛选 按钮 -->
                                                <asp:Button ID="Button2" runat="server" Text="精确筛选" CssClass="sidebarButtom" ValidationGroup="aaa3" OnClick="AccurateSizingBtn_Click" />

                                            </div>

                                        </div>

                                    </div>

                                    
                                    <!-- 精确筛选 按钮及其子功能容器 -->
                                    <div class="sidebarAllDiv">
                                        <!-- 精确筛选 按键容器 -->
                                        <div class="sidebarButtomDiv">

                                            <!-- 按钮前插图片 -->
                                            <svg
                                                xmlns="http://www.w3.org/2000/svg"
                                                width="16" height="16"
                                                fill="currentColor"
                                                class="sidebarButtomImg bi bi-box-arrow-in-right"
                                                viewBox="0 0 16 16">
                                                <path fill-rule="evenodd" d="M6 3.5a.5.5 0 0 1 .5-.5h8a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-8a.5.5 0 0 1-.5-.5v-2a.5.5 0 0 0-1 0v2A1.5 1.5 0 0 0 6.5 14h8a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-8A1.5 1.5 0 0 0 5 3.5v2a.5.5 0 0 0 1 0z" />
                                                <path fill-rule="evenodd" d="M11.854 8.354a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5H1.5a.5.5 0 0 0 0 1h8.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3z" />
                                            </svg>

                                            <!-- 按钮辅助定位盒子 -->
                                            <div class="sidebarButtomHelpDiv">

                                                <!-- 精确筛选 按钮 -->
                                                <asp:Button ID="Button4" runat="server" Text="精确筛选" CssClass="sidebarButtom" ValidationGroup="aaa3" OnClick="AccurateSizingBtn_Click" />

                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </asp:PlaceHolder>


            <!-- 设置对应的子功能-->
            <asp:PlaceHolder ID="SettingPlaceHolder" runat="server">

                <!-- 设置及其子功能容器 -->
                <div class="sidebar">


                    <!-- 显示设置 按钮及其子功能容器 -->
                    <div class="sidebarAllDiv">
                        <!-- 显示全部 按键容器 -->
                        <div class="sidebarButtomDiv">

                            <!-- 按钮前插图片 -->
                            <svg 
                                xmlns="http://www.w3.org/2000/svg" 
                                width="16" height="16" 
                                fill="currentColor" 
                                class="sidebarButtomImg bi bi-box-arrow-in-right" 
                                viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M6 3.5a.5.5 0 0 1 .5-.5h8a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-8a.5.5 0 0 1-.5-.5v-2a.5.5 0 0 0-1 0v2A1.5 1.5 0 0 0 6.5 14h8a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-8A1.5 1.5 0 0 0 5 3.5v2a.5.5 0 0 0 1 0z" />
                                <path fill-rule="evenodd" d="M11.854 8.354a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5H1.5a.5.5 0 0 0 0 1h8.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3z" />
                            </svg>

                            <!-- 按钮辅助定位盒子 -->
                            <div class="sidebarButtomHelpDiv">

                                <!-- 显示全部 按钮 -->
                                <asp:Button ID="displaySettingBtn" runat="server" Text="显示设置" CssClass="sidebarButtom" ValidationGroup="aaa3" OnClick="displaySettingBtn_Click" />

                            </div>
                        </div>

                    </div>


                    <!-- 账户设置 按钮及其子功能容器 -->
                    <div class="sidebarAllDiv">
                        <!-- 账户设置 按键容器 -->
                        <div class="sidebarButtomDiv">

                            <!-- 按钮前插图片 -->
                            <svg 
                                xmlns="http://www.w3.org/2000/svg" 
                                width="16" height="16" 
                                fill="currentColor" 
                                class="sidebarButtomImg bi bi-box-arrow-in-right" 
                                viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M6 3.5a.5.5 0 0 1 .5-.5h8a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-8a.5.5 0 0 1-.5-.5v-2a.5.5 0 0 0-1 0v2A1.5 1.5 0 0 0 6.5 14h8a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-8A1.5 1.5 0 0 0 5 3.5v2a.5.5 0 0 0 1 0z" />
                                <path fill-rule="evenodd" d="M11.854 8.354a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5H1.5a.5.5 0 0 0 0 1h8.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3z" />
                            </svg>

                            <!-- 按钮辅助定位盒子 -->
                            <div class="sidebarButtomHelpDiv">

                                <!-- 显示全部 按钮 -->
                                <asp:Button ID="AccountSetupBtn" runat="server" Text="账户设置" CssClass="sidebarButtom" ValidationGroup="aaa3" OnClick="AccountSetupBtn_Click" />

                            </div>
                        </div>

                    </div>

                </div>

            </asp:PlaceHolder>

        </div>
        <!-- 内容页 -->
        <div class="functionDomain">
            <asp:PlaceHolder ID="DataView" runat="server"></asp:PlaceHolder>
        </div>

        <!-- 精确筛选页 -->
        <%--<asp:PlaceHolder ID=""></asp:PlaceHolder>--%>

    </div>
</asp:Content>

