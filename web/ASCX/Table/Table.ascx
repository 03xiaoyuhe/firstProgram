<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Table.ascx.cs" Inherits="ASCX_Table_Table" %>

<%@ Register Src="~/ASCX/Table/LineForHead.ascx" TagName="Table" TagPrefix="LineForHead" %>

<%@ Register Src="~/ASCX/Table/LineForBody.ascx" TagName="Table" TagPrefix="LineForBody" %>

<%@ Register Src="~/ASCX/Table/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>

<style type="text/css">
    table {
        position: relative;
        width: 100%;
        border-collapse: collapse;
    }

    .sticky-table {
        overflow: auto;
        height: 100%; /* 设置固定高度 */
        width: 100%;
        margin: auto;
    }

        .sticky-table td, .sticky-table th {
            /* 设置td,th宽度高度 */
            border: 1px solid #c7d8ee;
            max-width: 150px;
            height: 30px;
            padding: 5px;
        }

        .sticky-table th {
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
        background-color: #008c8c;
        color: #fff;
    }

    table tbody tr:nth-child(odd) {
        background-color: #eee;
    }

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
<%--<link rel="stylesheet" href="CSS/Table.css" />--%>

<div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>


            <asp:Panel ID="Panel1" runat="server">
                <div class="sticky-table">
                    <table>
                        <thead>
                            <div class="container text-center">
                                <div class="row">
                                    <div class="col" style="text-align:right">
                                        <div style="margin: 10px;">
                                            <asp:Button ID="OpenSearchBtn" runat="server" Text="刷新" />
                                        </div>
                                    </div>
                                    <div class="col-8">
                                        <div style="margin: 10px;">
                                            <asp:TextBox ID="TextBox1" runat="server" Width="200"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col">
                                    </div>
                                </div>
                            </div>
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
            </asp:Panel>
        </ContentTemplate>

    </asp:UpdatePanel>
</div>
