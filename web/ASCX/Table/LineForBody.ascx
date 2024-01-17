<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LineForBody.ascx.cs" Inherits="ASCX_Table_LineForBody" %>

<%@ Register Src="~/ASCX/Table/LineForTable.ascx" TagName="Table" TagPrefix="LineForTable" %>

<%@ Register Src="~/ASCX/Table/CellForTable.ascx" TagName="Table" TagPrefix="CellForTable" %>

<%@ Register Src="~/ASCX/Table/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>

<tr>
    <asp:PlaceHolder ID = "CellHolder" runat="server"></asp:PlaceHolder>
</tr>