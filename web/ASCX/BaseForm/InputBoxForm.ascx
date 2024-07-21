<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InputBoxForm.ascx.cs" Inherits="WebForm.ASCX.BaseForm.InputBoxForm" %>

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


<div class="form-floating mb-3" style="margin: 5px auto;">
    <asp:TextBox runat="server" class="form-control" ID="InputTextBox" TextMode="MultiLine" placeholder=""></asp:TextBox>
    <label id="NoteLable" runat="server" for="<% = InputTextBox.ID %>"><% = Note %></label>
    <asp:RequiredFieldValidator
        ID="RequiredFieldValidator"
        runat="server"
        ErrorMessage="未设置"
        Font-Strikeout="true"
        ControlToValidate="InputTextBox"
        CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px" 
        Enabled ="false" >
    </asp:RequiredFieldValidator>
</div>
