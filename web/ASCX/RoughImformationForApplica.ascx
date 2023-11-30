<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoughImformationForApplica.ascx.cs" Inherits="ASCX_RoughImformationForApplica" %>

<link href="../CSS/Style.css" rel="stylesheet" />
<style type="text/css">
    .RI-body {
        width: 100%;
        height: 100%;
    }

    .turnDiv {
        width: 100%;
    }

    .turnTable {
        margin: 0 auto;
    }
    
    .form-div{
        overflow:auto;
        height:600px;
    }
</style>

<div>
    <div class="form-div">
        <table class="table-data"
            cellpadding="0"
            cellspacing="0"
            style="border-top: 1px solid Gray; border-left: 1px solid Gray; border-bottom: 1px solid Gray; border-collapse: collapse; text-align: center; margin: auto"
            border="1px"
            bordercolor="Gray">
            <tr>
                <th>立项编号</th>
                <th>项目编号</th>
                <th>项目名称</th>
                <th>项目负责人</th>
                <th>手机号</th>
                <th>立项时间</th>
                <th>成果形式</th>
                <th>项目类别</th>
                <th>变更内容</th>
                <th>变更内容原因</th>
                <th>管理单位意见</th>
            </tr>

            <%
                for (int i = 0; i < dt.Rows.Count; i++)
                {%>
            <tr>
                <td>
                    <%=dt.Rows[i]["username"] %>
                </td>
                <td>
                    <%=dt.Rows[i]["username"] %>
                </td>
                <td>
                    <%=dt.Rows[i]["username"] %>
                </td>
                <td>
                    <%=dt.Rows[i]["username"] %>
                </td>
                <td>
                    <%=dt.Rows[i]["username"] %>
                </td>
                <td>
                    <%=dt.Rows[i]["username"] %>
                </td>
                <td>
                    <%=dt.Rows[i]["username"] %>
                </td>
                <td>
                    <%=dt.Rows[i]["username"] %>
                </td>
                <td>
                    <%=dt.Rows[i]["username"] %>
                </td>
                <td>
                    <%=dt.Rows[i]["username"] %>
                </td>
                <td>
                    <%=dt.Rows[i]["username"] %>
                </td>
            </tr>
            <% 
                }
            %>
        </table>
    </div>


    <div class="turnDiv">
        <table class="turnTable table-buttom">
            <tr>
                <td>
                    <button class="btn btn-secondary ">&laquo;</button>
                </td>
                <td>
                    <button class="btn btn-secondary "><</button>
                </td>
                <td>
                    <div class="btn btn-secondary ">2/5</div>
                </td>
                <td>
                    <button class="btn btn-secondary ">></button>
                </td>
                <td>
                    <button class="btn btn-secondary ">&raquo;</button>
                </td>
            </tr>
        </table>
    </div>
</div>
