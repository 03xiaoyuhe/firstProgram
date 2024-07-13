<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPage.aspx.cs" Inherits="WebForm.functionPage.QF_ChildPage.ResetPage" %>

<%@ Register Src="~/ASCX/ProgramInform/ProgramAdd.ascx" TagName="ProgremInform" TagPrefix="ProgremInf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <%--<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">--%>
    <link href="../../assets/dist/css/bootstrap.min.css" rel="stylesheet" />
    <%--<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/mhDoLbDldZc3qpsJHpLogda//BVZbgYuw6kof4u2FrCedxOtgRZDTHgHUhOCVim" crossorigin="anonymous"></script>--%>
    <script src="../../assets/js/color-modes.js"></script>
    <style>
        /* 将字体设为红色 */
        .setCharRed {
            color: red;
        }

        /* 缩小字体 */
        .setCharSizeSmall {
            font-size: 10px;
        }

        .program-errorBox {
            display: inline-block;
        }


        .index_box {
            position: fixed; /*相对于浏览器进行定位*/
            bottom: 50px;
            right: 0;
            /*background:-webkit-linear-gradient(top, rgba(0,0,0,1),rgba(0,0,0,0));*/
            max-height: 40%;
            overflow: auto;
        }

            .index_box::-webkit-scrollbar {
                display: none
            }

        .ppshade {
            background: linear-gradient( rgba(255, 255, 255, 0.001),blue); /* 溢出部分那显示渐变 */
            overflow: hidden;
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div style="width: 80%; margin: 0 auto;">
            <div class="fs-1">项目信息</div>
            
               <div style="width:100%;height:490px;overflow:auto;">

                <ProgremInf:ProgremInform runat="server" ID ="ProgremInf"></ProgremInf:ProgremInform>

            </div>


            <table style="width: 100%">
                <tr>
<%--                    <td>
                        <div class="form-floating mb-3" style="margin: 5px auto;">
                            <asp:TextBox
                                ID="ProgramIDInput"
                                runat="server"
                                class="form-control"
                                placeholder="">
                            </asp:TextBox>
                            <label for="ProgramIDInput">
                                立项编号
                            </label>
                            <asp:RequiredFieldValidator
                                ID="checkNumberNull"
                                runat="server"
                                ErrorMessage="请输入立项编号"
                                Font-Strikeout="False"
                                ControlToValidate="ProgramIDInput"
                                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                            </asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3" style="margin: 5px auto;">
                            <asp:TextBox runat="server" class="form-control" ID="floatingInput" placeholder=""></asp:TextBox>
                            <label for="floatingInput">项目名称</label>

                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1"
                                runat="server"
                                ErrorMessage="请输入项目名称"
                                Font-Strikeout="False"
                                ControlToValidate="floatingInput"
                                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                            </asp:RequiredFieldValidator>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="form-floating" style="margin: 5px auto;">
                            <asp:TextBox ID="floatingTextarea" runat="server" TextMode="MultiLine" class="form-control" placeholder="Leave a comment here" Style="min-height: 125px;"></asp:TextBox>
                            <label for="floatingTextarea">
                                项目描述
                            </label>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2"
                                runat="server"
                                ErrorMessage="请输入项目描述"
                                Font-Strikeout="False"
                                ControlToValidate="floatingTextarea"
                                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                            </asp:RequiredFieldValidator>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-floating mb-3" style="margin: 5px auto;">
                            <asp:TextBox ID="PhoneNum" runat="server" class="form-control" placeholder=""></asp:TextBox>
                            <label for="PhoneNum">小队Id</label>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator3"
                                runat="server"
                                ErrorMessage="请输入小队Id"
                                Font-Strikeout="False"
                                ControlToValidate="PhoneNum"
                                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                            </asp:RequiredFieldValidator>
                        </div>

                    </td>
                    <td>
                        <div class="form-floating mb-3" style="margin: 5px auto;">
                            <asp:TextBox ID="DoForm" runat="server" class="form-control" placeholder=""></asp:TextBox>
                            <label for="DoForm">成果形式</label>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator4"
                                runat="server"
                                ErrorMessage="请输入成果形式"
                                Font-Strikeout="False"
                                ControlToValidate="ProgramIDInput"
                                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                            </asp:RequiredFieldValidator>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="form-floating" style="margin: 5px auto;">
                            <asp:TextBox ID="DoTextarea" runat="server" TextMode="MultiLine" class="form-control" placeholder="Leave a comment here" Style="min-height: 125px;"></asp:TextBox>
                            <label for="DoTextarea">成果描述</label>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator5"
                                runat="server"
                                ErrorMessage="请输入成果描述"
                                Font-Strikeout="False"
                                ControlToValidate="DoTextarea"
                                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                            </asp:RequiredFieldValidator>
                        </div>

                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:Button ID="submit" runat="server" Text="提交" CssClass="addProgram-submit btn btn-outline-dark" OnClick="submit_Click" />
                        <style type="text/css">
                            .addProgram-submit {
                                margin: 0;
                                float: left;
                            }
                        </style>
                    </td>

                    <td>
                        <asp:Button ID="clear" runat="server" Text="清除" CssClass="addProgram-clear btn btn-outline-dark" OnClick="clear_Click" ValidationGroup="NEXT" />
                        <style type="text/css">
                            .addProgram-clear {
                                margin: 0;
                                float: right;
                            }
                        </style>
                    </td>
                </tr>
            </table>



        </div>

        <div class="z-3 ppshade">
            <div class="index_box">
                <asp:PlaceHolder ID="errroMassage" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </form>
</body>
</html>
