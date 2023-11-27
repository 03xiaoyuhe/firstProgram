<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/handing.master" AutoEventWireup="true" CodeFile="WorkerLogin.aspx.cs" Inherits="WorkerLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="../bootstrap-5.3.0-alpha1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../bootstrap-5.3.0-alpha1-dist/js/bootstrap.bundle.min.js"></script>

    <style>
        .body {
            position: absolute;
            height: 100%;
            width: 100%;
            padding-top: 40px;
            background-color: rgb(0, 0, 0, 0.2);
        }

        .Login {
            height: 600px;
            width: 400px;
            margin: 0 auto;
            position: relative;
            top: 50%;
            transform: translate(0,-50%);
            background-color: white;
            box-shadow: black 0px 0px 5px;
            padding: 10px;
        }

        .Header {
            border-bottom: 2px solid;
            border-color: rgb(0, 0, 255, 0.3);
            margin-bottom: 30px;
        }

        .Input {
            margin: 0 auto;
            background-color: rgb(0, 0, 0, 0.2);
            border-radius: 5px;
            overflow: hidden;
        }

        .imformation {
            padding-right: 10px;
            padding-left: 10px;
            position: relative;
            top: 50%;
            transform: translate(0,-50%);
            margin: 0 auto;
        }

        .Body {
            width: 90%;
            margin: 0 auto;
            position: absolute;
            /*top: 50%;*/
            left: 50%;
            transform: translate(-50%,0);
        }

        .Footer {
            position: absolute;
            bottom: 0;
            text-align: end;
            width: 100%;
            padding-right: 15px;
            padding-bottom: 5px;
        }
    </style>
    <div class="body">
        <!-- 登陆界面 -->
        <div class="Login">
            <div class="page-header">

                <div class="modal-header Header">
                    <h1 class="modal-title fs-5 makeCharBolder">登陆</h1>
                </div>
            </div>
            <!-- 登陆页主体 -->
            <div class="modal-body Body">

                <!-- 用户名输入框 -->
                <div class="mb-3">
                    <label for="recipient-name" class="col-form-label">用户名:</label>
                    <asp:TextBox ID="userName" runat="server" CssClass="putOnShowBorder form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="checkNameNull" runat="server" ErrorMessage="请输入用户名" Font-Strikeout="False" ControlToValidate="userName" CssClass="setCharRed setCharSizeSmall"></asp:RequiredFieldValidator>
                </div>

                <!-- 密码输入框 -->
                <div class="mb-3">
                    <label for="message-text" class="col-form-label">密码:</label>
                    <asp:TextBox ID="userPwd" runat="server" CssClass="putOnShowBorder form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="checkPwdNull" runat="server" ErrorMessage="请输入密码" Font-Strikeout="False" ControlToValidate="userPwd" CssClass="setCharRed setCharSizeSmall"></asp:RequiredFieldValidator>
                </div>
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/Home.aspx">
                    没有账号？马上注册->

                </asp:HyperLink>
            </div>

            <!-- 登陆页尾部 -->
            <div class="modal-footer Footer">
                <!-- 登陆按钮 -->
                <asp:Button ID="BtmLogin" runat="server" Text="登陆"  CssClass="btn btn-primary" OnClick="BtmLogin_Click" />
                <span style="width: 2px;"></span>
                <button type="button" class="btn btn-secondary " data-bs-dismiss="modal">Close</button>
            </div>
        </div>
    </div>

</asp:Content>

