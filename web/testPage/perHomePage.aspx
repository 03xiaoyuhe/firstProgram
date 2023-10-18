<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/handing.master" AutoEventWireup="true" CodeFile="perHomePage.aspx.cs" Inherits="perMainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" CssClass="tripleVessel">

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
        .banner{
            background-color:rgb(0, 255, 144);
            text-align:left;
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
            background-color:antiquewhite;
            min-height:600px;
        }

        /* 侧边栏按钮 */
        .sidebarButtom{
            width:100%;
            border:none;
            background-color:rgb(0, 0, 0, 0.00);
            margin:0;
            padding:0;
            display:block;
        }
        
        .sidebarButtom:hover{
            background-color:rgb(0, 0, 0, 0.15)
        }

        /* 功能区 */
        .functionDomain{
            overflow:hidden;
            min-height:600px;
            background-color:burlywood;
        }

    </style>
    <div id ="tripleVessel" runat ="server" >
        <div class ="help"></div>
        <!-- 横幅 -->
        <div id ="banner" runat ="server" class="banner">
                <asp:Button ID="fenture1" runat="server" Text="功能1" CssClass="fenture1" OnClick="fenture1_Click" /><!--
                --><asp:Button ID="fenture2" runat="server" Text="功能2" CssClass="fenture1" OnClick="fenture2_Click" /><!--
                --><asp:Button ID="fenture3" runat="server" Text="功能3" CssClass="fenture1" OnClick="fenture3_Click" />
        </div>

        <!-- 侧边栏 -->
        <div class="sidebarDiv">

            <!-- 功能一对应的子功能-->
            <div id ="sidebar1" runat ="server" class="sidebar" style="display:none">
                <asp:Button ID="Button1" runat="server" Text="Button" CssClass="sidebarButtom"/>
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

