<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/handing.master" AutoEventWireup="true" CodeFile="QueryPage.aspx.cs" Inherits="QueryPage" %>

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
            float: left;
        }

        /* 侧边栏样式 */
        .sidebar {
            width: 100px;
            min-height: 600px;
            background-color: rgb(206, 221, 228)
        }

        /* 侧边栏按钮容器 */
        .sidebarButtomDiv {
            width: 100%;
        }



        .sidebarButtomHelpDiv {
            overflow: hidden;
        }

        /* 侧边栏按钮 */
        .sidebarButtom {
            text-align: left;
            width: 100%;
            border: none;
            background-color: rgb(0, 0, 0, 0.15);
            margin: 0;
            padding: 0;
        }

            .sidebarButtom:hover {
                background-color: rgb(0, 0, 0, 0.3)
            }

        /* 侧边栏子功能按钮前插图片 */
        .sidebarButtomImg {
            float: left;
            height: 25px;
            width: 25px;
        }

        /* 侧边栏子页 */
        .sidbarChildDiv {
            padding-left: 20px;
        }

        /* 功能区 */
        .functionDomain {
            overflow: hidden;
            min-height: 600px;
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

    <div id="tripleVessel" runat="server">
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
            --><asp:Button ID="filtrateBtm" runat="server" Text="筛选" CssClass="fenture1" OnClick="allNavigationBarBtm_Click" ValidationGroup="aaa2" /><!--
            --><asp:Button ID="pagingBtm" runat="server" Text="分页" CssClass="fenture1" OnClick="allNavigationBarBtm_Click" ValidationGroup="aaa" />

        </div>

        <!-- 侧边栏 -->
        <div class="sidebarDiv">


            <!-- 筛选对应的子功能-->
            <asp:PlaceHolder ID="filtrateSidebar" runat="server">

                <!-- 筛选及其子功能容器 -->
                <div class="sidebar">

                    <!-- 子功能一及其子功能容器 -->
                    <div>
                        <!-- 子功能一按键容器 -->
                        <div class="sidebarButtomDiv">

                            <img src="./img/homeHeadimg.jpg" class="sidebarButtomImg" />

                            <!-- 按钮辅助定位盒子 -->
                            <div class="sidebarButtomHelpDiv">

                                <!-- 子功能一按钮 -->
                                <asp:Button ID="filtratePrincipal" runat="server" Text="负责人" CssClass="sidebarButtom" OnClick="TreeButton_Click" ValidationGroup="aaa3" />
                            </div>

                        </div>

                        <!-- 子功能一子栏 -->
                        <asp:PlaceHolder ID="filtratePrincipalDiv" runat="server">
                            <div class="sidbarChildDiv">
                                111
                            </div>
                        </asp:PlaceHolder>
                    </div>

                    <!-- 子功能二及其子功能容器 -->
                    <div>
                        <!-- 子功能二按键容器 -->
                        <div class="sidebarButtomDiv">

                            <!-- 按钮前插图片 -->
                            <img src="./img/homeHeadimg.jpg" class="sidebarButtomImg" />

                            <!-- 按钮辅助定位盒子 -->
                            <div class="sidebarButtomHelpDiv">

                                <!-- 子功能二按钮 -->
                                <asp:Button ID="Button7" runat="server" Text="项目名称" CssClass="sidebarButtom" ValidationGroup="aaa3" />

                            </div>
                        </div>

                    </div>
                </div>

            </asp:PlaceHolder>


            <asp:PlaceHolder ID="PagingSidebar" runat="server" Visible="false">
                <!-- 筛选及其子功能容器 -->
                <div class="sidebar">

                    <!-- 子功能一及其子功能容器 -->
                    <div>
                        <!-- 子功能一按键容器 -->
                        <div class="sidebarButtomDiv">

                            <img src="./img/homeHeadimg.jpg" class="sidebarButtomImg" />

                            <!-- 按钮辅助定位盒子 -->
                            <div class="sidebarButtomHelpDiv">

                                <!-- 子功能一按钮 -->
                                <asp:Button ID="PagingSidebarButton1" runat="server" Text="负责人" CssClass="sidebarButtom" OnClick="TreeButton_Click" ValidationGroup="aaa3" />
                            </div>

                        </div>

                        <!-- 子功能一子栏 -->
                        <asp:PlaceHolder ID="PagingSidebarPlaceHolder1" runat="server">
                            <div class="sidbarChildDiv">
                                111
                            </div>
                        </asp:PlaceHolder>

                    </div>

                    <!-- 子功能二及其子功能容器 -->
                    <div>
                        <!-- 子功能二按键容器 -->
                        <div class="sidebarButtomDiv">

                            <!-- 按钮前插图片 -->
                            <img src="./img/homeHeadimg.jpg" class="sidebarButtomImg" />

                            <!-- 按钮辅助定位盒子 -->
                            <div class="sidebarButtomHelpDiv">

                                <!-- 子功能二按钮 -->
                                <asp:Button ID="PagingSidebarButton2" runat="server" Text="项目名称" CssClass="sidebarButtom" ValidationGroup="aaa" />

                            </div>
                        </div>

                        <!-- 子功能二子栏 -->
                        <asp:PlaceHolder ID="PagingSidebarPlaceHolder2" runat="server">
                            <div class="sidbarChildDiv">
                                111
                            </div>
                        </asp:PlaceHolder>

                    </div>

                </div>
            </asp:PlaceHolder>

            <%--            
            <!-- 功能二对应的子功能-->
            <asp:PlaceHolder  id="sidebar2" runat="server" Visible="false">
                <div class="sidebar">
                    <asp:Button ID="Button2" runat="server" Text="Button" CssClass="sidebarButtom" />
                    <asp:Button ID="Button4" runat="server" Text="Button" CssClass="sidebarButtom" />
                </div>
            </asp:PlaceHolder>
            --%>


            <%--            
            <!-- 功能三对应的子功能-->
            <asp:PlaceHolder  id="sidebar3" runat="server" Visible="false">
                <div class="sidebar">
                    <asp:Button ID="Button3" runat="server" Text="Button" CssClass="sidebarButtom" />
                    <asp:Button ID="Button5" runat="server" Text="Button" CssClass="sidebarButtom" />
                    <asp:Button ID="Button6" runat="server" Text="Button" CssClass="sidebarButtom" />
                </div>
            </asp:PlaceHolder>
            --%>


            <!-- 功能四对应的子功能-->
            <div id="sidebar4" runat="server" class="sidebar UnDisplay">
            </div>

        </div>

        <%--        <div id="functionDomain" runat="server" class="functionDomain">
            <div class="father">
                <input class="search" />
                <button class="btn">百度一下</button>
            </div>
        </div>--%>
    </div>
</asp:Content>

