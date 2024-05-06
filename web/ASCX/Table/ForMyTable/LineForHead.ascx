<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LineForHead.ascx.cs" Inherits="WebForm.ASCX.Table.LineForHead" %>

<%@ Register Src="~/ASCX/Table/ForMyTable/CellForHead.ascx" TagName="Table" TagPrefix="CellForTable" %>

<%@ Register Src="~/ASCX/Table/ForMyTable/CheckBoxTree.ascx" TagName="Table" TagPrefix="CheckBoxTree" %>

<tr>
    <CheckBoxTree:Table runat="server" ID="checkBox" />
    <asp:PlaceHolder ID = "CellHolder" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <th>
            <asp:Button ID ="DeletButton" runat ="server" CssClass="btn btn-light btn-sm" Text ="删除" OnClick="DeletButton_Click" style="background-color:var(--bs-danger);color:white;"/>
        </th>
    </asp:PlaceHolder>
</tr>