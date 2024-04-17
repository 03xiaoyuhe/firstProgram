<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataFormForDoc.ascx.cs" Inherits="WebForm.ASCX.ProgramInform.ForProgramShow.DataFormForDoc" %>


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
        <td colspan="6">
            <!-- input for 本项目国内外研究现状述评、选题意义和价值。限 1200 字以内 -->
            <div class="dataDiv">
                <div class="descrip">本项目国内外研究现状述评、选题意义和价值。限 1200 字以内</div>
                <div class="data">
                    <asp:Label ID="ProjectIntroduceLable" runat="server" Text="本项目国内外研究现状述评、选题意义和价值。限 1200 字以内"></asp:Label>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内 -->
            <div class="dataDiv">
                <div class="descrip">本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内</div>
                <div class="data">
                    <asp:Label ID="ProjectMainIdeaLable" runat="server" Text="本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内"></asp:Label>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 项目负责人和主要成员前期研究成果及参考文献。限填20项 -->
            <div class="dataDiv">
                <div class="descrip">项目负责人和主要成员前期研究成果及参考文献。限填20项</div>
                <div class="data">
                    <asp:Label ID="ProjectAheadLable" runat="server" Text="项目负责人和主要成员前期研究成果及参考文献。限填20项"></asp:Label>
                </div>

            </div>
        </td>
    </tr>
</table>
