<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilrUpLoadFormMain.ascx.cs" Inherits="WebForm.ASCX.FileUpLoad.FilrUpLoadFormMain" %>

<!-- 由于异步刷新控件导致文件上传控件放在updatePanel里时其他控件访问不到内容，考虑换写法 -->
<div style="width: 100%">
    <input type="file" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:FileUpload ID="fileLoadFunc" runat="server" AllowMultiple="True"/>
            <div style="float: right;">
                <asp:Button ID="LoadingButton" runat="server" Text="添加到列表" OnClick="LoadingButton_Click" />
                <asp:Button ID="SaveButton" runat="server" Text="上传到服务器" />
            </div>
            <asp:UpdatePanel ID="FileLoadingPanel" runat="server" OnLoad="FileLoadingPanel_Load" UpdateMode="Conditional"></asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
