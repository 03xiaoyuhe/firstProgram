<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyTable.ascx.cs" Inherits="WebForm.ASCX.Table.MyTable" %>

<%@ Register Src="~/ASCX/Table/ForMyTable/LineForHead.ascx" TagName="Table" TagPrefix="LineForHead" %>

<%@ Register Src="~/ASCX/Table/ForMyTable/LineForBody.ascx" TagName="Table" TagPrefix="LineForBody" %>

<%@ Register Src="~/ASCX/Table/ForMyTable/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>

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
            max-width: 150px;
            height: 30px;
            padding: 5px;
        }

        .sticky-table th {
            background-color: #525b66;
            color: #fff;
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
<%--<link rel="stylesheet" href="CSS/Table.css" />
--%>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <span style="margin-left:10px;"><asp:Button ID="Button1" runat="server" CssClass="btn btn-outline-dark small" Text="全选" OnClick="Unnamed_Click" /></span>
            <div style="float:right;margin-right:10px;">对选择的操作:&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID ="DeletButton" runat ="server" CssClass="btn btn-outline-dark" Text ="删除" OnClick="DeletButton_Click"/></div>
            <asp:Panel ID="Panel1" runat="server" >
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
            </asp:Panel>
        </ContentTemplate>

    </asp:UpdatePanel>
