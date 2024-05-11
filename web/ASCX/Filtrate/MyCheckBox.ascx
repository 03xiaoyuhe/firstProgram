<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyCheckBox.ascx.cs" Inherits="WebForm.ASCX.Filtrate.MyCheckBox" %>
<span>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">

    </asp:PlaceHolder>
    <%--<asp:CheckBox ID="CheckBox1" runat="server" CssClass="btn-check" type="radio" />--%>

    <label class="btn btn-outline-dark btn-sm" for="<% = $"{Text}1"  %>"><% = Text %></label>
</span>
