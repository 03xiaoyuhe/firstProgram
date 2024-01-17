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
    <style>
        table {
            position:relative;
            height:100px;
            width:100%;
            border-collapse: collapse;
        }

        .sticky-table {
            overflow:auto;
            height: 500px; /* 设置固定高度 */
            width: 500px;
            margin: auto;
            margin-top: 200px;
        }

        .sticky-table td, .sticky-table th {
            /* 设置td,th宽度高度 */
            border: 1px solid #c7d8ee;
            width: 150px;
            min-width: 150px;
            height: 30px;
            padding: 5px;
        }

        .sticky-table th {
            position: sticky;
            top: 0; /* 首行永远固定在头部  */
            background-color: #eaf4ff; /*设置表头背景色*/
        }


        .sticky-table th:first-child {
            z-index: 2; /*表头的首列要在上面*/
        }

        .sticky-table th > div {
            width: 100%;
            white-space: normal;
            word-wrap: break-word;
            word-break: break-all;
        }

        /*.sticky-table table {
            table-layout: fixed;
        }*/
    </style>
    <form id="form1" runat="server">
        <div class="sticky-table">
        
            <table>
                <thead>
                    <tr>
                        <th>
                            测试
                        </th>
                        <th>222</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="height:10px;"></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style ="height:1000px;"></td>
                        <td></td>
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
