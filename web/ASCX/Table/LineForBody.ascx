<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LineForBody.ascx.cs" Inherits="WebForm.ASCX.Table.LineForBody" %>

<%@ Register Src="~/ASCX/Table/CellForBody.ascx" TagName="Table" TagPrefix="CellForBody" %>

<%@ Register Src="~/ASCX/Table/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>

<tr>
    <asp:PlaceHolder ID = "CellHolder" runat="server"></asp:PlaceHolder>
</tr>