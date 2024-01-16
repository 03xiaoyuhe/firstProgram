<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Table.ascx.cs" Inherits="ASCX_Table_Table" %>

<%@ Register Src="~/ASCX/Table/LineForHead.ascx" TagName="Table" TagPrefix="LineForHead" %>


<%@ Register Src="~/ASCX/Table/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>

<link rel="stylesheet" href="CSS/Table.css" />
<table>
    <thead>
        <asp:PlaceHolder ID="HeadHolder" runat="server">

        </asp:PlaceHolder>
    </thead>
    <tbody>
        <asp:PlaceHolder ID ="BodyHolder" runat="server">

        </asp:PlaceHolder>
    </tbody>
</table>
