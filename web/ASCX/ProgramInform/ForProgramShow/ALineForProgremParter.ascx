<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ALineForProgremParter.ascx.cs" Inherits="WebForm.ASCX.ProgramInform.ForProgramShow.ALineForProgremParter" %>
<style type="text/css">
    .dataDiv {
        border-radius: 5px;
        position: relative;
        height: 100%;
        width: 100%;
        margin: 10px;
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
<tr>
    <td>
        <div class="dataDiv">
            <div class="descrip">姓名</div>
            <div class="data">
                <!-- input for 姓名 -->
                <asp:Label ID="NameLable" runat="server" Text="姓名"></asp:Label>

            </div>

        </div>
    </td>
    <td>
        <div class="dataDiv">
            <div class="descrip">性别</div>
            <div class="data">
                <!-- input for 性别 -->
                <asp:Label ID="SexLable" runat="server" Text="性别"></asp:Label>
            </div>

        </div>
    </td>
    <td>
        <div class="dataDiv">
            <div class="descrip">出生年月</div>
            <div class="data">
                <!-- input for 出生年月 -->
                <asp:Label ID="BrothLable" runat="server" Text="出生年月"></asp:Label>
            </div>

        </div>
    </td>
    <td>
        <div class="dataDiv">
            <div class="descrip">职务、职称</div>
            <div class="data">

                <!-- input for 职务、职称 -->
                <asp:Label ID="JobLable" runat="server" Text="职务、职称"></asp:Label>
            </div>

        </div>
    </td>
    <td colspan="2">
        <div class="dataDiv">
            <div class="descrip">工作单位</div>
            <div class="data">

                <!-- input for 工作单位 -->
                <asp:Label ID="JobWhereLable" runat="server" Text="工作单位"></asp:Label>
            </div>

        </div>
    </td>
</tr>
