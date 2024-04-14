<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileImformationForm.ascx.cs" Inherits="WebForm.ASCX.FileUpLoad.FileImformationForm" %>

<style type="text/css">

</style>
<div style="width:100%">
    <asp:Label ID="FileNameLable" runat="server" Text="Label" ></asp:Label>
    <div style="float:right;">
        <asp:Label ID="FileSizeLable" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="DeleteButton" runat="server" Text="Button" OnClick="DeleteButton_Click" />
    </div>
</div>