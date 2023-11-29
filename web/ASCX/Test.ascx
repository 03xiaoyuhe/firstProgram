<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Test.ascx.cs" Inherits="ASCX_Test" %>
<style type="text/css">
    .T-body {
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
        background-color: rgba(0, 0, 0, 0.2);
    }

    tbody tr:nth-child(even) {
        background-color: rgba(0, 0, 0, 0.1);
    }

    tbody tr {
        background-image: url(noise.png);
    }

    table {
        background-color: rgba(255, 255, 255, 1);
    }
</style>

<div class="T-body">
    
            <table class="Table" cellpadding="0" cellspacing="0" style=" border-top: 1px solid Gray;
                        border-left: 1px solid Gray; border-bottom: 1px solid Gray; border-collapse: collapse;
                        text-align: center; margin:auto" width="50%" border="1px" bordercolor="Gray">
            <tr>
                <td style ="background-color:rgb(100, 114, 117, 0.88)">姓名</td>
                <td style ="background-color:rgb(100, 114, 117, 0.88)">年龄</td>

            </tr>
            
                <%
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {%> 
                        <tr>
                            <td>
                                <%=dt.Rows[i]["name"] %>
                            </td>
                            <td>
                                <%=dt.Rows[i]["password"] %>
                            </td>
                       </tr>
                 <% 
                    }
                 %>
            
        </table>
</div>