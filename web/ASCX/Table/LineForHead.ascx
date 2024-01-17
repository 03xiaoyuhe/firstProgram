<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LineForHead.ascx.cs" Inherits="ASCX_Table_LineForHead" %>

<%@ Register Src="~/ASCX/Table/LineForTable.ascx" TagName="Table" TagPrefix="LineForTable" %>

<%@ Register Src="~/ASCX/Table/CellForTable.ascx" TagName="Table" TagPrefix="CellForTable" %>

<tr>
    <asp:PlaceHolder ID = "CellHolder" runat="server"></asp:PlaceHolder>
</tr>