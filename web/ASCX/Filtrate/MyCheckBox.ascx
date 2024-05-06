<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyCheckBox.ascx.cs" Inherits="WebForm.ASCX.Filtrate.MyCheckBox" %>
<span>
    <asp:CheckBox ID="CheckBox1" runat="server" CssClass="btn-check" type="radio" />
    <label class="btn btn-outline-danger" for="<% = CheckBox1.ID  %>">Radio 1</label>
</span>
