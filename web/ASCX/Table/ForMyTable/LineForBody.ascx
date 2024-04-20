<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LineForBody.ascx.cs" Inherits="WebForm.ASCX.Table.LineForBody" %>

<%@ Register Src="~/ASCX/Table/ForMyTable/CellForBody.ascx" TagName="Table" TagPrefix="CellForBody" %>

<%@ Register Src="~/ASCX/Table/ForMyTable/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>

<tr>
    <asp:PlaceHolder ID = "CellHolder" runat="server"></asp:PlaceHolder>
</tr>