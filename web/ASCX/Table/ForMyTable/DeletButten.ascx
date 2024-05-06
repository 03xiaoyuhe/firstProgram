<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeletButten.ascx.cs" Inherits="WebForm.ASCX.Table.DeletButten" %>

<td>
    <asp:Button ID="DetailButton" runat="server" CssClass="btn btn-sm" Text="详细信息" OnClick="DetailButton_Click"/>
    <asp:Button ID ="ResetButton" runat ="server" CssClass="btn btn-sm" Text ="修改" OnClick="ResetButton_Click" />
</td>