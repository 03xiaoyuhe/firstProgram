<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<%@ Register Src="~/ASCX/Table/Table.ascx" TagName="Table" TagPrefix="Table" %>
<%@ Register Src="~/ASCX/Massage/PrintMassage.ascx" TagName="PrintMassage" TagPrefix="TPrintMassage" %>

<%@ Register Src="~/ASCX/Table/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <link rel="stylesheet" href="CSS/Table.css" />
    <form id="form1" runat="server">
        <div>
        
            <table>
                <thead>
                    <tr>
                        <td>
                            测试
                        </td>
                    </tr>
                </thead>
                <tbody style="height: 500px; overflow: auto; background: red">
                    <tr>
                        <td style="height: 600px;"></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <asp:PlaceHolder ID="PlaceHolder1" runat="server">

        </asp:PlaceHolder>
        <TPrintMassage:PrintMassage ID="aaa" runat="server" />
    </form>
</body>
</html>
