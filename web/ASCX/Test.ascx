<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Test.ascx.cs" Inherits="WebForm.ASCX.Test" %>

<link href="../CSS/Style.css" rel="stylesheet" />

<style type="text/css">
    .T-body {
        width: 100%;
    }

    .turnDiv {
        width: 100%;
    }

    .turnTable {
        margin: 0 auto;
    }

    .tableImf td, Table tr {
        border: 1px solid;
        border-color: black;
    }

    .form-div{
        overflow:auto;
        height:600px;
    }
</style>

<div class="T-body">
    <div class="form-div">
        
        <div>
            <table class="Table" cellpadding="0" cellspacing="0" style=" border-top: 1px solid Gray;
                        border-left: 1px solid Gray; border-bottom: 1px solid Gray; border-collapse: collapse;
                        text-align: center; margin:auto" width="50%" border="1px" bordercolor="Gray">
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
