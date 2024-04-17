<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataFormForParters.ascx.cs" Inherits="WebForm.ASCX.ProgramInform.ForProgramShow.DataFormForParters" %>


<%@ Register Src="./ALineForProgremParter.ascx" TagName="LineForProgremParter" TagPrefix="ProgremInf" %>


<style type="text/css">
    .dataTable{
        width:99%;
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
        }

        .dataDiv > .time {
            position: absolute;
            bottom: -10px;
            right: 10px;
            background-color: white;
        }
</style>

<table class="dataTable">
    <tr>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
    </tr>
    <asp:PlaceHolder runat="server" ID ="DataPutPlaceHolder" ></asp:PlaceHolder>
</table>