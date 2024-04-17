<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataFormForThinking.ascx.cs" Inherits="WebForm.ASCX.ProgramInform.ForProgramShow.DataFormForThinking" %>

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
        <td>
            <!-- input for 项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章 -->
            <div class="dataDiv">
                <div class="descrip">项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章</div>
                <div class="data">
                    <asp:Label ID="WhereThinkLable" runat="server" Text="项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章"></asp:Label>
                </div>
                <div class="time">
                    <!-- 时间 -->
                    <asp:Label ID="WhereThinkTimeLable" runat="server" Text="年--月--日"></asp:Label>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <!-- input for 专家组评审意见 -->
            <div class="dataDiv">
                <div class="descrip">专家组评审意见</div>
                <div class="data">
                    <asp:Label ID="MajorThinkLable" runat="server" Text="专家组评审意见"></asp:Label>
                </div>
                <div class="time">
                    <!-- 时间 -->
                    <asp:Label ID="MajorThinkTimeLable" runat="server" Text="年--月--日"></asp:Label>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <!-- input for 审批意见 -->
            <div class="dataDiv">
                <div class="descrip">审批意见</div>
                <div class="data">

                    <asp:Label ID="EndThinkLable" runat="server" Text="审批意见"></asp:Label>
                </div>
                <div class="time">
                    <!-- 时间 -->
                    <asp:Label ID="EndThinkTimeLable" runat="server" Text="年--月--日"></asp:Label>
                </div>
            </div>
        </td>
    </tr>
</table>
