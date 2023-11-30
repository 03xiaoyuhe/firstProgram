<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Test.ascx.cs" Inherits="ASCX_Test" %>

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
        
            <table class="Table" cellpadding="0" cellspacing="0" style=" border-top: 1px solid Gray;
                        border-left: 1px solid Gray; border-bottom: 1px solid Gray; border-collapse: collapse;
                        text-align: center; margin:auto" width="50%" border="1px" bordercolor="Gray">
            <tr>
                <th>姓名</th>
                <th>年龄</th>

            </tr>
            
                <%
                    for (int i = 0; i < 50; i++)
                    {%> 
                        <tr>
                            <td>
                                1
                            </td>
                            <td>
                                2
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
