<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="WebForm.Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:PlaceHolder ID="ucHolder" runat="server"></asp:PlaceHolder>
    </div>
    <div>
        <asp:Button ID="btnAddUC" runat="server" Text="Add User Control" />
    </div>
    </form>
</body>
</html>
