<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinesDataForParters.ascx.cs" Inherits="WebForm.ASCX.ProgramInform.ForProgramAdd.LinesDataForParters" %>

<%--
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
--%>

<style type="text/css">
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

<tr>
    <td>
        <div class="form-floating mb-3" style="margin: 5px auto;">
            <asp:TextBox runat="server" class="form-control" ID="NameTextBox" placeholder=""></asp:TextBox>
            <label for="floatingInput">姓名</label>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1"
                runat="server"
                ErrorMessage="请输入姓名"
                Font-Strikeout="False"
                ControlToValidate="NameTextBox"
                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
            </asp:RequiredFieldValidator>
        </div>
    </td>
    <td>
        <div class="form-floating mb-3" style="margin: 5px auto;">
            <asp:TextBox runat="server" class="form-control" ID="SexTextBox" placeholder=""></asp:TextBox>
            <label for="floatingInput">性别</label>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2"
                runat="server"
                ErrorMessage="请输入性别"
                Font-Strikeout="False"
                ControlToValidate="SexTextBox"
                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
            </asp:RequiredFieldValidator>
        </div>
    </td>
    <td>
        <div class="form-floating mb-3" style="margin: 5px auto;">
            <asp:TextBox runat="server" class="form-control" ID="BrothTextBox" placeholder=""></asp:TextBox>
            <label for="floatingInput">出生年月</label>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator3"
                runat="server"
                ErrorMessage="请输入出生年月"
                Font-Strikeout="False"
                ControlToValidate="BrothTextBox"
                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
            </asp:RequiredFieldValidator>
        </div>
    </td>
    <td>
        <div class="form-floating mb-3" style="margin: 5px auto;">
            <asp:TextBox runat="server" class="form-control" ID="JobTextBox" placeholder=""></asp:TextBox>
            <label for="floatingInput">职务、职称</label>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator4"
                runat="server"
                ErrorMessage="请职务、职称"
                Font-Strikeout="False"
                ControlToValidate="JobTextBox"
                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
            </asp:RequiredFieldValidator>
        </div>
    </td>
    <td colspan="2">
        <div class="form-floating mb-3" style="margin: 5px auto;">
            <asp:TextBox runat="server" class="form-control" ID="JobWhereTextBox" placeholder=""></asp:TextBox>
            <label for="floatingInput">工作单位</label>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator5"
                runat="server"
                ErrorMessage="请输入工作单位"
                Font-Strikeout="False"
                ControlToValidate="JobWhereTextBox"
                CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
            </asp:RequiredFieldValidator>
        </div>
    </td>
</tr>
