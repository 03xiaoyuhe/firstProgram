<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoughImformation.ascx.cs" Inherits="ASCX_RoughImformation" %>
<style type="text/css">
    .RI-body {
        width: 100%;
        height: 100%;
    }
    /* typography */

    html {
        font-family: "helvetica neue", helvetica, arial, sans-serif;
    }

    thead th,
    tfoot th {
        font-family: "Rock Salt", cursive;
    }

    th {
        letter-spacing: 2px;
    }

    td {
        letter-spacing: 1px;
    }

    tbody td {
        text-align: center;
    }

    tfoot th {
        text-align: right;
    }

    thead, tfoot {
        background: url(leopardskin.jpg);
        color: white;
        text-shadow: 1px 1px 1px black;
    }

        thead th, tfoot th, tfoot td {
            background: linear-gradient(to bottom, rgba(0,0,0,0.1), rgba(0,0,0,0.5));
            border: 3px solid purple;
        }

    tbody tr:nth-child(odd) {
        background-color: #ff33cc;
    }

    tbody tr:nth-child(even) {
        background-color: #e495e4;
    }

    tbody tr {
        background-image: url(noise.png);
    }

    table {
        background-color: #ff33cc;
    }
</style>

<link href="../bootstrap-5.3.0-alpha1-dist/css/bootstrap.min.css" rel="stylesheet" />
<script type="text/jscript" src="../bootstrap-5.3.0-alpha1-dist/js/bootstrap.bundle.min.js"></script>

<div>
    <table class="Table"
        cellpadding="0"
        cellspacing="0"
        style="border-top: 1px solid Gray; border-left: 1px solid Gray; border-bottom: 1px solid Gray; border-collapse: collapse; text-align: center; margin: auto"
        border="1px"
        bordercolor="Gray">
        <tr>
            <td>立项编号</td>
            <td>项目编号</td>
            <td>项目名称</td>
            <td>项目负责人</td>
            <td>手机号</td>
            <td>立项时间</td>
            <td>成果形式</td>
            <td>项目类别</td>
            <td>变更内容</td>
            <td>变更内容原因</td>
            <td>管理单位意见</td>
        </tr>

        <%
            for (int i = 0; i < dt.Rows.Count; i++)
            {%>
        <tr>
            <td>
                <%=dt.Rows[i]["user_id"] %>
            </td>
            <td>
                <%=dt.Rows[i]["gender"] %>
            </td>
            <td>
                <%=dt.Rows[i]["contact_number"] %>
            </td>
            <td>
                <%=dt.Rows[i]["email"] %>
            </td>
            <td>
                <%=dt.Rows[i]["date_of_birth"] %>
            </td>
            <td>
                <%=dt.Rows[i]["education_degree"] %>
            </td>
            <td>
                <%=dt.Rows[i]["position"] %>
            </td>
            <td>
                <%=dt.Rows[i]["workplace"] %>
            </td>
            <td>
                <%=dt.Rows[i]["workplace"] %>
            </td>
            <td>
                <%=dt.Rows[i]["workplace"] %>
            </td>
            <td>
                <%=dt.Rows[i]["workplace"] %>
            </td>
        </tr>
        <% 
            }
        %>
    </table>

</div>
