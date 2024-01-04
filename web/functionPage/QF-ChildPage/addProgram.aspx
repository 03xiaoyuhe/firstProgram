<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addProgram.aspx.cs" Inherits="functionPage_QF_ChildPage_addProgramData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="../../assets/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/mhDoLbDldZc3qpsJHpLogda//BVZbgYuw6kof4u2FrCedxOtgRZDTHgHUhOCVim" crossorigin="anonymous"></script>
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

        .program-errorBox{
            display:inline-block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:80%;margin:0 auto;">
            <div class="fs-1">项目信息</div>
            <table style="width:100%">
                <tr>
                    <td>
                        <div class="form-floating mb-3" style="margin:0 auto;">
                            <asp:TextBox 
                                id="ProgramIDInput" 
                                runat="server" 
                                class="form-control" 
                                placeholder=""
                                >
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
                        <div class="form-floating mb-3" style="margin:5px auto;">
                            <asp:TextBox runat="server" class="form-control" id="floatingInput" placeholder=""></asp:TextBox>
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
                        <div class="form-floating" style="margin:5px auto;">
                            <asp:TextBox id="floatingTextarea" runat="server" TextMode="MultiLine" class="form-control" placeholder="Leave a comment here"  style="min-height:125px;"></asp:TextBox>
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
                        <div class="form-floating mb-3" style="margin:5px auto;">
                            <asp:TextBox id="PhoneNum" runat="server" class="form-control" placeholder=""></asp:TextBox>
                            <label for="PhoneNum">负责人电话号码</label>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator3"
                                runat="server"
                                ErrorMessage="请输入负责人电话号码"
                                Font-Strikeout="False"
                                ControlToValidate="PhoneNum"
                                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                            </asp:RequiredFieldValidator>
                        </div>
                        
                    </td>
                    <td>
                        <div class="form-floating mb-3" style="margin:5px auto;">
                            <asp:TextBox id="DoForm" runat="server" class="form-control" placeholder=""></asp:TextBox>
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
                        <div class="form-floating" style="margin:5px auto;">
                            <asp:TextBox id="DoTextarea" runat="server" TextMode="MultiLine" class="form-control" placeholder="Leave a comment here"  style="min-height:125px;"></asp:TextBox>
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
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="submit" runat="server" Text="提交" CssClass="addProgram-submit btn btn-outline-dark" OnClick="submit_Click"/>
                        <style type="text/css">
                            .addProgram-submit{
                                margin:0;
                                float:left ;
                            }
                        </style>
                    </td>
                    
                    <td>
                        <asp:Button ID="clear" runat="server" Text="清除"  CssClass="addProgram-clear btn btn-outline-dark" OnClick="clear_Click" ValidationGroup="NEXT" />
                        <style type="text/css">
                            .addProgram-clear{
                                margin:0;
                                float:right;
                            }
                        </style>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
