<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectAll.aspx.cs" Inherits="WebForm.functionPage.QF_ChildPage.selectAll1" %>

<%@ Register Src="~/ASCX/PageIndex.ascx" TagName="PageIndex" TagPrefix="PageIndex" %>
<%--<pages enableEventValidation="false"/>--%>
<%@ Register Src="~/ASCX/Table/MyTable.ascx" TagName="Table" TagPrefix="Table" %>
<%@ Register Src="~/ASCX/MassageForm/PrintMassage.ascx" TagName="PrintMassage" TagPrefix="TPrintMassage" %>
<%@ Register Src="~/ASCX/Table/ForMyTable/DeletButten.ascx" TagName="Table" TagPrefix="DeletButten" %>
<%@ Register Src="~/ASCX/Loading.ascx" TagName="Load" TagPrefix="Loading" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../assets/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="../..//bootstrap-5.3.0-alpha1-dist/css/bootstrap-reboot.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style> 
        
        .Center {
            position: absolute;
            left: 50%;
            transform: translate(-50%,0);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container text-center">
                <div class="row">
                    <div class="col" style="text-align: right">
                        <div style="margin: 10px;">
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
            <div style="height:500px;">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <%--<TPrintMassage:PrintMassage ID="aaa" runat="server" />--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" OnLoad="PlaceHolder1_Load"></asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="position:absolute;width:100%">
                <div class="Center" style="margin:0 auto;">
                            <PageIndex:PageIndex ID="aaa" runat="server" CssClass="Center"/>
                </div>
            </div>
    </form>
</body>
</html>
