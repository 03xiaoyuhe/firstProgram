<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logintest.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link rel="stylesheet" href="swiper/swiper-3.4.2.min.css"/>
        <script src="swiper/swiper-3.4.2.min.js"></script>
        <link href="bootstrap-5.3.0-alpha1-dist/css/bootstrap.min.css" rel="stylesheet" />
        <script src="bootstrap-5.3.0-alpha1-dist/js/bootstrap.bundle.min.js" ></script>
        <script>

        </script>
        <title></title>
        <style>
            #login{
                width:400px;
                margin:auto;
                border-width:2px;
                border-color:black;
                border-radius:10px;
                background-color: white;
                box-shadow: 0 0 10px 2px rgba(126, 126, 126, 0.556);
            }

            .example1
            {
            background-color:rgba(126, 126, 126, 0.556);
            }

            .putOnShowBorder{
                border:solid;
                border-width:1px;
                border-color:darkgrey;
            }

            .setCharRed{
                color:red;
            }

            .setCharSizeSmall{
                font-size:10px;
            }

            .makeCharBolder{
                font-weight:bolder;
            }
        </style>
    </head>

    <body>
        <form id="form1" runat="server">
             <div id ="unLogin" runat ="server" >

                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@mdo">登陆</button> 
                <asp:PlaceHolder ID="aaa" runat="server"></asp:PlaceHolder>
    
                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-fullscreen example1">
                        <div class="modal-content example1" aria-expanded="undefined">

                            <div id ="login" runat="server">
                                <div class="modal-header">
                                    <h1 class="modal-title fs-5 makeCharBolder">登陆</h1>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">

                                    <div class="mb-3">
                                        <label for="recipient-name" class="col-form-label">用户名:</label>
                                        <asp:TextBox ID="userName" runat="server"  CssClass="putOnShowBorder form-control" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="checkNameNull" runat="server" ErrorMessage="请输入用户名" Font-Strikeout="False" ControlToValidate="userName" CssClass ="setCharRed setCharSizeSmall"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="mb-3">
                                        <label for="message-text" class="col-form-label">密码:</label>
                                        <asp:TextBox ID="userPwd" runat="server" CssClass="putOnShowBorder form-control" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="checkPwdNull" runat="server" ErrorMessage="请输入密码" Font-Strikeout="False" ControlToValidate="userPwd" CssClass ="setCharRed setCharSizeSmall"></asp:RequiredFieldValidator>

                                    </div>

                                    <asp:CheckBox ID="CheckAdm" runat="server" Text="管理员登陆" />
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CheckLoginSuccess" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox1" Visible="false"></asp:RequiredFieldValidator>
                                </div>
                                <div class="modal-footer">

                                    <asp:Button ID="BtmLogin" runat="server" Text="登陆" OnClick="BtmLogin_Click" CssClass="btn btn-primary"/>

                                    <!--<button type="button" class="btn btn-primary">登&nbsp;陆</button>-->
                                    <button type="button" class="btn btn-secondary " data-bs-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

             </div>
            <div id ="LoginSuccess" runat="server" style ="display:none;">
                <div class="btn btn-primary">登陆成功</div>
            </div>
            
        </form>
    </body>
</html>
