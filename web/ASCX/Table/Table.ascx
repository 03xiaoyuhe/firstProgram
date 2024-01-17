<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Table.ascx.cs" Inherits="ASCX_Table_Table" %>

<%@ Register Src="~/ASCX/Table/LineForHead.ascx" TagName="Table" TagPrefix="LineForHead" %>

<%@ Register Src="~/ASCX/Table/LineForBody.ascx" TagName="Table" TagPrefix="LineForBody" %>

<%@ Register Src="~/ASCX/Table/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>

<style type="text/css">
    table {
        position: relative;
        height: 100px;
        width: 100%;
        border-collapse: collapse;
    }

    .sticky-table {
        overflow: auto;
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
<%--<link rel="stylesheet" href="CSS/Table.css" />--%>

<div class="sticky-table">
    <table>
        <thead>
            <asp:PlaceHolder ID="HeadHolder" runat="server"></asp:PlaceHolder>
        </thead>
        <tbody>
            <asp:PlaceHolder ID="BodyHolder" runat="server"></asp:PlaceHolder>
        </tbody>
    </table>
</div>
