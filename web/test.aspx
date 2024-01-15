<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

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
        <div style="height:1000px;"></div>
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
    </form>
</body>
</html>
