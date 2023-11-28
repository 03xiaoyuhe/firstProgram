<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoughImformationForApplica.ascx.cs" Inherits="ASCX_RoughImformationForApplica" %>

<style type="text/css">
    .RI-body{
        width:100%;
        height:100%;
    }
</style>

<div >
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
                <%=dt.Rows[i]["emp_id"] %>
            </td>
            <td>
                <%=dt.Rows[i]["emp_number"] %>
            </td>
            <td>
                <%=dt.Rows[i]["emp_name"] %>
            </td>
            <td>
                <%=dt.Rows[i]["emp_dutier"] %>
            </td>
            <td>
                <%=dt.Rows[i]["emp_phone"] %>
            </td>
            <td>
                <%=dt.Rows[i]["emp_time"] %>
            </td>
            <td>
                <%=dt.Rows[i]["emp_result"] %>
            </td>
            <td>
                <%=dt.Rows[i]["emp_category"] %>
            </td>
            <td>
                <%=dt.Rows[i]["emp_change"] %>
            </td>
            <td>
                <%=dt.Rows[i]["emp_change_reson"] %>
            </td>
            <td>
                <%=dt.Rows[i]["emp_opinion"] %>
            </td>
        </tr>
        <% 
            }
        %>
    </table>
</div>