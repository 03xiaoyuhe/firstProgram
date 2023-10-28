<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/handing.master" AutoEventWireup="true" CodeFile="QueryPage.aspx.cs" Inherits="QueryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <style>
        /* 通用功能属性 */

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
            height: 60px;
        }

        /* 横幅样式 */
        .banner {
            /*background-color: rgb(0, 255, 144);*/
            border: 1px solid #000;
            text-align: left;
            overflow: hidden;
        }

        /* 横幅按钮未点击样式 */
        .fenture1 {
            height: 30px;
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
            border: none;
            background-color: rgb(0, 0, 0, 0.3);
            margin: 0;
            padding: 0;
            width: 80px;
            display: inline-block;
        }

        /* 搜索栏样式 */
        .searchDiv {
            overflow: hidden;
            margin-top: 1px;
            margin-bottom: 1px;
            padding: 0;
            height: 28px;
            border: solid 1px;
            text-align: end;
        }

        /* 搜索输入框样式 */
        .searchBox {
            padding-left: 16px;
            font-size: 16px;
            width: 100px;
            height: 30px;
            border: hidden;
        }

            .searchBox:focus {
                border: hidden;
            }

            .searchBox:hover {
                background-color: rgb(0, 0, 0, 0.30)
            }


        .searchBoxHelp{
            top: -1px;
            left: -1px;
            width: 100px;
            height: 30px;
            border: hidden;
        }
        /* 侧边栏容器 */
        .sidebarDiv {
            float: left;
        }

        /* 侧边栏样式 */
        .sidebar {
            width: 100px;
            /*background-color:antiquewhite;*/
            border: 1px solid #000;
            min-height: 600px;
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
            background-color: blue;
            margin: 0;
            padding: 0;
        }

            .sidebarButtom:hover {
                background-color: rgb(0, 0, 0, 0.15)
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


        .father{
				text-align: center;
				padding-top: 20px;
			}

        
			.input{
				width: 260px;
			}

            
			.btn{
				font-size: 16px;
				border-top-right-radius: 10px;
				border-bottom-right-radius: 10px;
				height: 44px;
				width: 100px;
				background: #4E6EF2;
				color: white;
				border-color: #4E6EF2;
				border: none; /* 边框线有一个立体感，去掉立体感 */
				vertical-align: top; /* 让这两个都顶部对齐 */
			}
    </style>
    <div id="tripleVessel" runat="server">
        <div class="help">
        </div>
        <!-- 横幅 -->
        <div id="banner" runat="server" class="banner">
            <div class="searchDiv" style="float: right">
         
            </div>

            <asp:Button ID="turnBackToHome" runat="server" Text="回到主页" CssClass="fenture1" OnClick="turnBackToHome_Click" ValidationGroup="aaa1"/><!--
            --><asp:Button ID="filtrateBtm" runat="server" Text="筛选" CssClass="fenture1" OnClick="allNavigationBarBtm_Click" ValidationGroup="aaa2"/><!--
            --><asp:Button ID="pagingBtm" runat="server" Text="分页" CssClass="fenture1" OnClick="allNavigationBarBtm_Click" ValidationGroup="aaa"/>

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
                                <asp:Button ID="filtratePrincipal" runat="server" Text="负责人" CssClass="sidebarButtom" OnClick="TreeButton_Click" ValidationGroup="aaa3"/>
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
                                <asp:Button ID="Button7" runat="server" Text="项目名称" CssClass="sidebarButtom" ValidationGroup="aaa3"/>

                            </div>
                        </div>

                    </div>
                </div>

            </asp:PlaceHolder>


            <asp:PlaceHolder ID="PagingSidebar" runat="server" Visible="false">
                <div class="sidebar">
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
                                    <asp:Button ID="PagingSidebarButton1" runat="server" Text="负责人" CssClass="sidebarButtom" OnClick="TreeButton_Click" ValidationGroup="aaa3"/>
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
                                    <asp:Button ID="PagingSidebarButton2" runat="server" Text="项目名称" CssClass="sidebarButtom" ValidationGroup="aaa"/>

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
        <div id="functionDomain" runat="server" class="functionDomain">
            <div class="father">
			    <input class="search"/><button class="btn">百度一下</button>
		    </div>
        </div>
    </div>
</asp:Content>

