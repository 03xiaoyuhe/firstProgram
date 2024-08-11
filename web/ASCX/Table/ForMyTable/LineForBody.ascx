<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LineForBody.ascx.cs" Inherits="WebForm.ASCX.Table.LineForBody" %>

<%@ Register Src="~/ASCX/Table/ForMyTable/CellForBody.ascx" TagName="Table" TagPrefix="CellForBody" %>

<%@ Register Src="~/ASCX/Table/ForMyTable/MyCheckBox.ascx" TagName="Table" TagPrefix="MyCheckBox" %>

<tr>
    <MyCheckBox:Table runat="server" ID ="checkBox"/>
    <asp:PlaceHolder ID = "CellHolder" runat="server"></asp:PlaceHolder>
</tr>