<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Table.ascx.cs" Inherits="ASCX_Table_Table" %>

<%@ Register Src="~/ASCX/Table/LineForHead.ascx" TagName="Table" TagPrefix="LineForHead" %>

<%@ Register Src="~/ASCX/Table/LineForBody.ascx" TagName="Table" TagPrefix="LineForBody" %>

<%@ Register Src="~/ASCX/Table/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>

<%--<link rel="stylesheet" href="CSS/Table.css" />--%>
<table>
    <thead>
    </thead>
    <tbody>
        <asp:PlaceHolder ID="HeadHolder" runat="server">

        </asp:PlaceHolder>
        <asp:PlaceHolder ID ="BodyHolder" runat="server">

        </asp:PlaceHolder>
    </tbody>
</table>
