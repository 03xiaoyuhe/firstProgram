<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DBHelperTest.aspx.cs" Inherits="DBHelperTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server"></asp:Table>
            <table class="Table" cellpadding="0" cellspacing="0" style=" border-top: 1px solid Gray;
                        border-left: 1px solid Gray; border-bottom: 1px solid Gray; border-collapse: collapse;
                        text-align: center; margin:auto" width="50%" border="1px" bordercolor="Gray">
            <tr>
                <td>姓名</td>
                <td>年龄</td>

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
    </form>
</body>
</html>
