<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectAll1.aspx.cs" Inherits="WebApplication1.functionPage.QF_ChildPage.selectAll" %>

<%--<pages enableEventValidation="false"/>--%>
<%@ Register Src="~/ASCX/Table/MyTable.ascx" TagName="Table" TagPrefix="Table" %>
<%@ Register Src="~/ASCX/Massage/PrintMassage.ascx" TagName="PrintMassage" TagPrefix="TPrintMassage" %>
<%@ Register Src="~/ASCX/Table/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>
<%@ Register Src="~/ASCX/Loading.ascx" TagName="Load" TagPrefix="Loading" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../assets/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="../..//bootstrap-5.3.0-alpha1-dist/css/bootstrap-reboot.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    
    <style>
        ul.pagination {
            display: inline-block;
        }

        .pagerlist {
            float: left;
            margin-left: 40%;
        }

        .pagination {
            display: inline-block;
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

        .pagination {
            display: inline-block;
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

        ul.pagination li {
            float: left;
            margin-right: 5px;
            border: #e2e2e2 1px solid;
        }

        .pagination > li {
            display: inline;
            cursor: pointer;
        }

            .pagination > li:first-child > a, .pagination > li:first-child > span {
                margin-left: 0;
                border-top-left-radius: 4px;
                border-bottom-left-radius: 4px;
            }

        ul.pagination li a, ul.pagination li a:link, ul.pagination li a:visited {
            display: block;
            padding: 0 10px;
            line-height: 24px;
            color: #666;
            font-size: 12px;
            text-decoration: none;
        }

        .pagination > li > a, .pagination > li > span {
            position: relative;
            float: left;
            padding: 2px 12px;
            margin-left: -1px;
            line-height: 1.42857143;
            color: #428bca;
            text-decoration: none;
            background-color: #fff;
            border: 1px solid #ddd;
        }
    </style>
    <script type="text/javascript">
        function TurnPage(type) {
            var currentPage = getQueryString("currentPage") == null ? 1 : parseInt(getQueryString("currentPage"));
            ////var maxPage = <%= maxPage%>;

            switch (type) {
                case 'f':
                    currentPage = 1;
                    break;
                case 'p':
                    if (currentPage <= 1) {
                        return;
                    }
                    else {
                        currentPage = currentPage - 1;
                    }
                    break;
                case 'n':
                    if (currentPage >= maxPage) {
                        return;
                    }
                    else {
                        currentPage = currentPage + 1;
                    }   
                    break;
                case 'e':
                    if (currentPage == maxPage) return;
                    currentPage = maxPage;
                    break;
                case 'a':
                    if (isNaN(parseInt(document.getElementById("txtInputNumber").value))) {
                        return;
                    } else if (parseInt(document.getElementById("txtInputNumber").value) > maxPage) {
                        alert("没有那么多页");
                        return;
                    } else {
                        currentPage = parseInt(document.getElementById("txtInputNumber").value);
                    }
                    break;
                default:
                    break;
            }

            if (!isNaN(currentPage) && currentPage > 0) {
                location.href = "?currentPage=" + currentPage;
            }
        }

    </script>
    <form id="form1" runat="server">
        <div class="container text-center">
            <div class="row">
                <div class="col" style="text-align: right">
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--<TPrintMassage:PrintMassage ID="aaa" runat="server" />--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server" OnLoad="PlaceHolder1_Load"></asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <div class="container text-center">
            <div class="row">
                <div class="col" style="text-align: right">
                    <div style="margin: 10px;">
                    </div>
                </div>
                <div class="col-8">
                    <div style="margin: 10px;">
                        <asp:Button ID="Button1" runat="server" Text="<" />
                        <asp:Label ID="Label1" runat="server" ></asp:Label>
                        <asp:Button ID="Button2" runat="server" Text=">" />
                    </div>
                </div>
                <div class="col">
                </div>
            </div>
        </div>
        <div class="container" style="text-align: center;">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="margin: 0;">
                <ul id="PagerID" class="pagination pagination-sm">
                    <li><a onclick="TurnPage('f')">首页 </a></li>
                    <li><a onclick="TurnPage('p')">上页 </a></li>
                    <li>
                        <span>页:
                                    <asp:Label ID="lbCurrentPage" runat="server">0</asp:Label>/<asp:Label ID="lbMaxPage" runat="server">0</asp:Label>
                        </span>
                    </li>
                    <li><a onclick="TurnPage('n')">下页 </a></li>
                    <li><a onclick="TurnPage('e')">末页 </a></li>
                    <li><a onclick="TurnPage('a')">GoTo </a></li>
                    <li>
                        <input type="text" id="txtInputNumber" style="width: 50px;">
                    </li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
