<%@ Page Language="C#" AutoEventWireup="true" CodeFile="exceltodbfnew.aspx.cs" Inherits="account_exceltodbfnew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
         td{
            border :1px double ;
            padding :1px 4px;
        }
        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 1px;
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h4>Excel导入数据到Sql Server数据库中与反向导出</h4>
        <hr />
        <div>
            <table class="auto-style1">
                <tr>
                    <td style="color: #009900; font-weight: bold">源/目标excel文件</td>
                    <td style="color: #0000FF; font-weight: bold">源/目标数据库文件</td>
                    <td style="background-color: #EBEBEB">本地文件上传服务器</td>
                </tr>
                <tr>
                    <td style="width:35%" rowspan="2">
                        <asp:ListBox ID="ListBox1" runat="server" Height="140px"  Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"  ></asp:ListBox>
                    </td>
                    <td style="width:35%" rowspan="2">
                        <asp:ListBox ID="ListBox2" runat="server" Height="140px"  Width="100%"></asp:ListBox>
                    </td>
                    <td style="background-color: #EBEBEB">选择本地xls文件：</td>
                </tr>
                <tr>
                    <td style="background-color: #EBEBEB">
                        <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="Solid" />
                    </td>
                </tr>
                <tr>
                    <td>对应sheet表名：</td>
                    <td>导入导出模式：</td>
                    <td style="background-color: #EBEBEB">
                        <asp:Button ID="Button3" runat="server" Text="上传文件" Font-Bold="True" ForeColor="Blue" OnClick="Button3_Click" Font-Size="12pt" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ListBox ID="ListBox3" runat="server" Height="140px"  Width="100%"></asp:ListBox>
                    </td>
                    <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Height="31px" BorderStyle="Solid" style="margin:auto">
                        <asp:ListItem>覆盖</asp:ListItem>
                        <asp:ListItem>追加</asp:ListItem>
                    </asp:RadioButtonList>
        
                    </td>
                    <td style="background-color: #EBEBEB">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/imagesnew/china.gif" Height="99px" Width="143px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="xlsTOdbf导入" Font-Bold="True" ForeColor="#009900" OnClick="Button1_Click" Font-Size="12pt" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="dbfTOxls导出" Font-Bold="True" ForeColor="Blue" Font-Size="12pt" />
                    </td>
                    <td style="background-color: #EBEBEB">
                        <asp:Button ID="btnDelete" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="#CC3399" Text="删除源EXCEL文件" OnClick="btnDelete_Click" OnClientClick="return confirm('您确定要删除吗？确定删除请确定！');" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                        <asp:HiddenField ID="HiddenField3" runat="server" />
                    </td>
                </tr>
            </table>
           
        </div>


         <div id="grid1" runat="server">


          <table class="auto-style1">
              <tr>
                  <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" Width="100%" BorderStyle="Solid" HorizontalAlign="Left">
                        <SelectedRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Button ID="btnReturn" runat="server" BorderStyle="Inset" Height="27px" OnClick="btnReturn_Click" Text="返回" Width="152px" Font-Bold="True" />
                  </td>
              </tr>
          </table>


      </div>
    </form>
</body>
</html>
