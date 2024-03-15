<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/handing.master" AutoEventWireup="true" CodeBehind="home-test.aspx.cs" Inherits="WebForm.home_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <link href="../bootstrap-5.3.0-alpha1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../bootstrap-5.3.0-alpha1-dist/js/bootstrap.bundle.min.js"></script>

    <style>

        /* 通用功能 */
        .inline-table{
            display: inline-table;
        }

        /* 特定功能属性 */
        .Center {
            position: absolute;
            left: 50%;
            transform: translate(-50%,0);
        }

        /* 主页基本设定 */

        body{
            /* 设置背景图 并使其自适应大小 */
            background-image: url("../img/Home_img/HomeBackgroundImg.png");
            background-repeat: no-repeat;
            background-size: cover;

        }
        .body {

            min-width: 1200px;
            max-width: 1550px;
            margin: auto;
        }

        .chooseLoginManber {
            position: relative;
            height: 300px;
            width: 100%;
            margin: 0 auto;
            overflow: hidden;
        }

        .test {
            position: relative;
            margin-left: 10px;
            margin-right: 10px;
            /* 比例大小及辅助定位 */
            width: 200px;
            height: 240px;
            margin-top: 34px;
            display: inline-block;
            border-radius: 5px;
            border: solid 3px;
            border-color: rgb(0, 0, 0, 0.618);
            background-color:white;
            box-shadow: black 0px 0px 10px;
            font-size: 24px;
            max-width: 200px;
        }

            .test:hover {
                margin-top: 10px;
                width: 220px;
                height: 264px;
                font-size: 26.4px;
            max-width: 220px;
            }

        .test-imformation {
            position: absolute;
            left: 50%;
            top: 50%;
            transform: translate(-50%,-50%);
        }

        .test-imformation-img {
            position: relative;
            margin: 0 auto;
            height: 100px;
            width: 100px;
            /* 设置背景图 并使其自适应大小 */
            opacity: 0.618;
            background-repeat: no-repeat;
            background-size: contain;
            display: inline-table;
        }

        .test-imformation-text {
            color: rgba(0, 0, 0, 0.618);
            font-weight: bold;
        }

        .test-imformation-buttom{
            position:absolute;
            display:inline-table;

            height:100%;
            width:100%;

        }

        .test-buttom{
            border:none;
            cursor:pointer;
            width:100%;
            height:100%;
            background-color:rgba(0, 0, 0, 0.0);
        }

        .imformation {
            position: relative;
            margin: 0 auto;

            width: 80%;
            height:500px;

            border-radius: 5px;
            box-shadow: black 0px 0px 10px;
            overflow:hidden;
            margin-bottom:100px;

            
            background-color:rgb(101, 109, 255, 0.1);
        }

        .imformation-part {
            position: relative;

            width: 50%;
            height:100%;

            display: inline-table;
            box-shadow: black 0px 0px 10px;
            overflow:hidden;
            background-color:rgba(255,255,255,0.8);
        }

        .imformation-head{
            width:100%;
            height:35px;
            padding-left:5px;
            margin-bottom:5px;

            box-shadow: black 0px 0px 10px;

            color:rgba(0, 0, 0, 0.618);
            font-weight: bold;
            font-size:20px;

            background-color:rgb(101, 109, 255, 0.2);
        }

        .imformation-data-1{
            position:relative;
            margin:0;
            width:100%;
            height:30px;
            padding-left:5px;

        }

        .imformation-data-2 {
            position:relative;
            margin:0;
            width: 100%;
            height: 30px;
            padding-left: 5px;
            background-color:rgb(101, 109, 255, 0.15);
        }
    </style>

    <div class="body">
        <!-- 辅助定位 -->
        <div style="margin: 40px;">
        </div>

        <!-- 身份选择 -->
        <div class="chooseLoginManber">
            <div class="Center">
                <div class="test">
                    <div class="test-imformation">
                        <div class="test-imformation-img" style="background-image: url(img/Home_img/adm.png)"></div>
                        <div class="test-imformation-text">
                            科研人员
                        </div>
                    </div>
                    <!-- 按钮覆盖 -->
                    <div class="test-imformation-buttom">
                        <asp:Button  ID="testLogin" runat="server" Text="" CssClass="test-buttom"/>
                    </div>
                </div>

                <div class="test">
                    <div class="test-imformation">
                        <div class="test-imformation-img" style="background-image: url(img/Home_img/plo.png)"></div>
                        <div class="test-imformation-text">
                            工作人员
                        </div>
                    </div>
                    <!-- 按钮覆盖 -->
                    <div class="test-imformation-buttom">
                        <asp:Button ID="workerLogin" runat="server" Text="" CssClass="test-buttom" OnClientClick="WorkerLogin_Click" OnClick="workerLogin_Click" />
                    </div>
                </div>

                <div class="test">
                    <div class="test-imformation">
                        <div class="test-imformation-img" style="background-image: url(img/Home_img/adj.png)"></div>
                        <div class="test-imformation-text">
                            评委入口
                        </div>
                    </div>
                    <!-- 按钮覆盖 -->
                    <div class="test-imformation-buttom">
                        <asp:Button ID="argLogin" runat="server" Text="" CssClass="test-buttom" />
                    </div>
                </div>

            </div>

        </div>
        <!-- 信息公布栏 -->
        <div class="imformation">
            <!-- 信息发布栏一 -->
            <div class="imformation-part">
                <!-- 标题栏 -->
                <div class ="imformation-head inline-table">
                        操作手册
                </div>
            </div><!-- 
                信息发布栏二 
         --><div class="imformation-part">
                <!-- 标题栏 -->
                <div class ="imformation-head inline-table">
                        通知公告
                </div>
                <div class ="imformation-data-1">

                </div>
                <div class ="imformation-data-2">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

