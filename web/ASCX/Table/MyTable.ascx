<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyTable.ascx.cs" Inherits="WebForm.ASCX.Table.MyTable" %>

<%@ Register Src="~/ASCX/Table/ForMyTable/LineForHead.ascx" TagName="Table" TagPrefix="LineForHead" %>

<%@ Register Src="~/ASCX/Table/ForMyTable/LineForBody.ascx" TagName="Table" TagPrefix="LineForBody" %>

<style type="text/css">
    table {
        width: 100%;
        border-collapse: collapse;
    }

    .sticky-table {
        overflow: auto;
        width: 100%;
    }

        .sticky-table td, .sticky-table th {
            /* 设置td,th宽度高度 */
            border: 1px solid #c7d8ee;
            border-right:none;
            border-left:none;
            max-width: 150px;
            height: 30px;
            padding: 5px;
        }

        .sticky-table th {
            background-color: var(--bs-dark-bg-subtle);
            color: black;
            position: sticky;
            top: 0; /* 首行永远固定在头部  */
            font-weight: normal;
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



    table caption {
        font-size: 2em;
        font-weight: bold;
        margin: 1em 0;
    }

    th, td {
        border: 1px solid #999;
        text-align: center;
        padding: 20px 0;
    }

    table thead tr {
        background-color: var(--bs-body-color);
        color: #fff;
    }
/*
    table tbody tr:nth-child(odd) {
        background-color: #eee;
    }*/

    table tbody tr:hover {
        background-color: #ccc;
    }

    table tbody tr td:first-child {
        color: #f40;
    }

    table tfoot tr td {
        text-align: right;
        padding-right: 20px;
    }

    /*.sticky-table table {
            table-layout: fixed;
        }*/
</style>
<%--<link rel="stylesheet" href="CSS/Table.css" />
--%>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
                <div id ="stickytable" class="sticky-table" runat="server">
                    <table>
                        <thead>
                            <asp:PlaceHolder ID="HeadHolder" runat="server"></asp:PlaceHolder>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="BodyHolder" runat="server"></asp:PlaceHolder>
                        </tbody>
                    </table>
                    <asp:PlaceHolder ID="NullMassage" runat="server" Visible="False">
                        <div style="width: 100%; text-align: center; font-weight: bold; color: rgb(128, 128, 128)">无任何数据</div>
                    </asp:PlaceHolder>
                </div>
        </ContentTemplate>

    </asp:UpdatePanel>
