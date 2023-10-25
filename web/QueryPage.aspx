<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/handing.master" AutoEventWireup="true" CodeFile="QueryPage.aspx.cs" Inherits="QueryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <style>

        /* 特定功能属性 */

        /* 三栏页面 */
        #tripleVessel{
            height:100%;
            background-color:blue;
            overflow:hidden;
        }

        /* 辅助定位盒子 */
        .help{
            height:60px;
        }

        /* 横幅样式 */
        .banner {
            /*background-color: rgb(0, 255, 144);*/
            border: 1px solid #000;
            text-align: left;
        }

        /* 横幅按钮未点击样式 */
        .fenture1{
            border:none;
            background-color:rgb(0, 0, 0, 0.00);
            margin:0;
            padding:0;
            width:80px;
            display:inline-block;
        }

        /* 横幅按钮聚焦动态 */
        .fenture1:hover{
            background-color:rgb(0, 0, 0, 0.15)
        }

        /* 横幅按钮点击后样式 */
        .fenture1OverCleck{
            border:none;
            background-color:rgb(0, 0, 0, 0.3);
            margin:0;
            padding:0;
            width:80px;
            display:inline-block;
        }

        /* 侧边栏容器 */
        .sidebarDiv{
            float:left;
        }

        /* 侧边栏样式 */
        .sidebar{
            width:100px;
            /*background-color:antiquewhite;*/
            border :1px solid #000;
            min-height:600px;
        }

        /* 侧边栏按钮容器 */
        .sidebarButtomDiv{
            width:100%;
        }

        .sidebarButtomHelpDiv{
            overflow:hidden;
        }

        /* 侧边栏按钮 */
        .sidebarButtom{
            text-align: left;
            width:100%;
            border:none;
            background-color:blue;
            margin:0;
            padding:0;
        }
        
        .sidebarButtom:hover{
            background-color:rgb(0, 0, 0, 0.15)
        }

        /* 侧边栏子功能按钮前插图片 */
        .sidebarButtomImg{
            float:left;
            height:25px;
            width:25px;
        }

        /* 侧边栏子页 */
        .sidbarChildDiv{
            padding-left :20px;
        }

        /* 功能区 */
        .functionDomain{
            overflow:hidden;
            min-height:600px;
            /*background-color:burlywood;*/
        }

    </style>
    <div id ="tripleVessel" runat ="server" >
        <div class ="help">

        </div>
        <!-- 横幅 -->
        <div id ="banner" runat ="server" class="banner">
            <asp:Button ID="turnBackToHome" runat="server" Text="回到主页" CssClass="fenture1" OnClick="turnBackToHome_Click"/><!--
            --><asp:Button ID="filtrateBtm" runat="server" Text="筛选" CssClass="fenture1" OnClick="filtrateBtm_Click" /><!--
            --><asp:Button ID="fenture2" runat="server" Text="功能2" CssClass="fenture1" OnClick="fenture2_Click" /><!--
            --><asp:Button ID="fenture3" runat="server" Text="功能3" CssClass="fenture1" OnClick="fenture3_Click" />
        </div>

        <!-- 侧边栏 -->
        <div class="sidebarDiv">

            <!-- 筛选对应的子功能-->
            <div id ="filtrateSidebar" runat ="server" class="sidebar" style="display:none">

                <!-- 子功能一按键容器 -->
                <div class="sidebarButtomDiv">
                    <img src ="./img/homeHeadimg.jpg" class ="sidebarButtomImg"/>

                    <!-- 按钮辅助定位盒子 -->
                    <div class ="sidebarButtomHelpDiv">

                        <!-- 子功能一按钮 -->
                        <asp:Button ID="filtratePrincipal" runat="server" Text="负责人" CssClass="sidebarButtom" OnClick="filtratePrincipal_Click" />
                    </div>
                </div>

                <!-- 筛选侧边栏子栏 -->
                <div id ="filtratePrincipalDiv" runat ="server" class="sidbarChildDiv" style="display:none">
                    111
                </div>


                <!-- 子功能二按键容器 -->
                <div class="sidebarButtomDiv">

                    <!-- 按钮前插图片 -->
                    <img src="./img/homeHeadimg.jpg" class="sidebarButtomImg" />

                    <!-- 按钮辅助定位盒子 -->
                    <div class="sidebarButtomHelpDiv">

                        <!-- 子功能二按钮 -->
                        <asp:Button ID="Button7" runat="server" Text="项目名称" CssClass="sidebarButtom" />

                    </div>
                </div>
            </div>

            <!-- 功能二对应的子功能-->
            <div id ="sidebar2" runat ="server" class="sidebar" style="display:none">
                <asp:Button ID="Button2" runat="server" Text="Button" CssClass="sidebarButtom"/>
                <asp:Button ID="Button4" runat="server" Text="Button" CssClass="sidebarButtom"/>
            </div>

            <!-- 功能三对应的子功能-->
            <div id ="sidebar3" runat ="server" class="sidebar" style="display:none">
                <asp:Button ID="Button3" runat="server" Text="Button" CssClass="sidebarButtom"/>
                <asp:Button ID="Button5" runat="server" Text="Button" CssClass="sidebarButtom"/>
                <asp:Button ID="Button6" runat="server" Text="Button" CssClass="sidebarButtom"/>
            </div>
        
            <!-- 功能四对应的子功能-->
            <div id ="sidebar4" runat ="server" class="sidebar" style="display:none">

            </div>

        </div>
        <div id ="functionDomain" runat="server" class="functionDomain">
            111
        </div>
    </div>
</asp:Content>

