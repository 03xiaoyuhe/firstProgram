<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageIndex.ascx.cs" Inherits="WebForm.ASCX.PageIndex" %>

<style type="text/css">
    .button{
        width:50px;
        border:none;
        height:100%;
    }
    .button:hover{
        cursor:pointer;
    }
    .indexbutton{
        width:50px;
        border:none;
        height:100%;
        border-top: #0094ff 2px solid;
    }
    .indexbutton:hover{
        cursor:default;
    }
</style>

<div style="margin:0 auto;overflow:hidden;">
    <asp:Button ID="A0" runat="server" OnClick="Cleck" Text="<" CssClass ="button"/>
    <asp:Button ID="A1" runat="server" OnClick="Cleck" Visible="False" />
    <asp:Button ID="A2" runat="server" OnClick="Cleck" Visible="False"/>
    <asp:Button ID="A3" runat="server" OnClick="Cleck" Visible="False"/>
    <asp:Button ID="A4" runat="server" OnClick="Cleck" Visible="False"/>
    <asp:Button ID="A5" runat="server" OnClick="Cleck" Visible="False"/>
    <asp:Button ID="A6" runat="server" OnClick="Cleck" Visible="False"/>
    <asp:Button ID="A7" runat="server" OnClick="Cleck" Visible="False"/>
    <asp:Button ID="A8" runat="server" OnClick="Cleck" Visible="False"/>
    <asp:Button ID="A9" runat="server" OnClick="Cleck" Text=">" CssClass ="button"/>
</div>
