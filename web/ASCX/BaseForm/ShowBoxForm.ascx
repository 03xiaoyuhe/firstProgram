<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowBoxForm.ascx.cs" Inherits="WebForm.ASCX.BaseForm.ShowBoxForm" %>




<style type="text/css">
    .dataTable {
        width: 99%;
    }

    .dataDiv {
        border-radius: 5px;
        position: relative;
        height: 100%;
        width: 100%;
        margin: 5px;
        border: 1px solid rgba(0,0,0,0.5);
    }

        .dataDiv > .descrip {
            color: rgba(0,0,0,0.5);
            position: absolute;
            background-color: white;
            top: -10px;
            left: 10px;
        }

        .dataDiv > .data {
            padding: 10px;
            max-height: 500px;
            overflow: auto;
        }

        .dataDiv > .time {
            position: absolute;
            bottom: -10px;
            right: 10px;
            background-color: white;
        }

</style>

<div class="dataDiv">
    <div class="descrip">
        <asp:Label ID="DataHeadLable" runat="server" Text="未赋值"></asp:Label>
    </div>
    <div class="data">
            <asp:Label ID="DataLable" runat="server" Text="无任何数据"></asp:Label>
    </div>
</div>
