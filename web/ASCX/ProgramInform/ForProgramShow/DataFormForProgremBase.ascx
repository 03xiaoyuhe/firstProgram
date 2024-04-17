<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataFormForProgremBase.ascx.cs" Inherits="WebForm.ASCX.ProgramInform.ForProgramShow.DataFormForProgremBase" %>

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
    <tr>
        <td colspan="6">
            <!-- input for 课题名称 -->
            <div class="dataDiv">
                <div class="descrip">课题名称</div>
                <div class="data">
                    <asp:Label ID="ProgromNameLable" runat="server" Text="课题名称"></asp:Label>
                </div>

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 项目类别 -->
            <div class="dataDiv">
                <div class="descrip">项目类别</div>
                <div class="data">
                    <asp:Label ID="ProgromKindsLable" runat="server" Text="项目类别"></asp:Label>

                </div>

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 项目负责人 -->
            <div class="dataDiv">
                <div class="descrip">项目负责人</div>
                <div class="data">
                    <asp:Label ID="ProjromAdmNameLable" runat="server" Text="项目负责人"></asp:Label>

                </div>

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 负责人所在单位 -->
            <div class="dataDiv">
                <div class="descrip">负责人所在单位</div>
                <div class="data">
                    <asp:Label ID="ProgremAdmWhereLable" runat="server" Text="负责人所在单位"></asp:Label>

                </div>

            </div>
        </td>
    </tr>

    <tr>
        <td colspan="3">
            <!-- input for 项目完成时间 -->
            <div class="dataDiv">
                <div class="descrip">项目完成时间</div>
                <div class="data">
                    <asp:Label ID="ProjectFinishLable" runat="server" Text="项目完成时间"></asp:Label>

                </div>

            </div>
        </td>
        <td colspan="3">
            <!-- input for 最后成果形式 -->
            <div class="dataDiv">
                <div class="descrip">最后成果形式</div>
                <div class="data">
                    <asp:Label ID="ProjectEndLable" runat="server" Text="最后成果形式"></asp:Label>

                </div>

            </div>
        </td>
    </tr>

</table>