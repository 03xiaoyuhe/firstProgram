<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramShow.ascx.cs" Inherits="WebForm.ASCX.ProgramInform.ProgramShow" %>

<%@ Register Src="./ForProgramShow/ALineForProgremParter.ascx" TagName="LineForProgremParter" TagPrefix="ProgremInf" %>

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

<h2>一、基本信息</h2>
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
<h2>二、项目负责人基本信息</h2>
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
        <td colspan="2">
            <!--input for 姓名-->
            <div class="dataDiv">
                <div class="descrip">姓名</div>
                <div class="data">
                    <asp:Label ID="AdmNameLable" runat="server" Text="姓名"></asp:Label>

                </div>

            </div>
        </td>
        <td colspan="2">
            <!-- input for 出生年月 -->
            <div class="dataDiv">
                <div class="descrip">出生年月</div>
                <div class="data">
                    <asp:Label ID="AdmBornLable" runat="server" Text="出生年月"></asp:Label>

                </div>

            </div>
        </td>
        <td colspan="2">
            <!-- input for 性别 -->
            <div class="dataDiv">
                <div class="descrip">性别</div>
                <div class="data">
                    <asp:Label ID="AdmSexLable" runat="server" Text="性别"></asp:Label>

                </div>

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <!-- input for 职务 -->
            <div class="dataDiv">
                <div class="descrip">职务</div>
                <div class="data">
                    <asp:Label ID="AdmOrdLable" runat="server" Text="职务"></asp:Label>

                </div>

            </div>
        </td>
        <td colspan="2">
            <!-- input for 职称 -->
            <div class="dataDiv">
                <div class="descrip">职称</div>
                <div class="data">
                    <asp:Label ID="AdmOrdNameLable" runat="server" Text="职称"></asp:Label>

                </div>

            </div>
        </td>
        <td colspan="2">
            <!-- input for 专业 -->
            <div class="dataDiv">
                <div class="descrip">专业</div>
                <div class="data">
                    <asp:Label ID="AdmMarLable" runat="server" Text="专业"></asp:Label>

                </div>

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <!-- input for 研究专长 -->
            <div class="dataDiv">
                <div class="descrip">研究专长</div>
                <div class="data">
                    <asp:Label ID="AdmMajBestLable" runat="server" Text="研究专长"></asp:Label>

                </div>

            </div>
        </td>
        <td colspan="3">
            <!-- input for 现从事专业 -->
            <div class="dataDiv">
                <div class="descrip">现从事专业</div>
                <div class="data">
                    <asp:Label ID="AdmNowDoLable" runat="server" Text="现从事专业"></asp:Label>

                </div>

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 工作单位 -->
            <div class="dataDiv">
                <div class="descrip">工作单位</div>
                <div class="data">
                    <asp:Label ID="AdmJobWhereLable" runat="server" Text="工作单位"></asp:Label>

                </div>

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <!-- input for 通信地址 -->
            <div class="dataDiv">
                <div class="descrip">通信地址</div>
                <div class="data">
                    <asp:Label ID="AdmPhoneWhereLable" runat="server" Text="通信地址"></asp:Label>

                </div>

            </div>
        </td>
        <td colspan="3">
            <!-- input for 是否符合青年项目申报条件 -->
            <div class="dataDiv">
                <div class="descrip">是否符合青年项目申报条件</div>
                <div class="data">
                    <asp:Label ID="IsYoungProjremLable" runat="server" Text="是否符合青年项目申报条件"></asp:Label>

                </div>

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <!-- input for 办公个电话 -->
            <div class="dataDiv">
                <div class="descrip">办公个电话</div>
                <div class="data">

                    <asp:Label ID="AdmAdmPhoneLable" runat="server" Text="办公个电话"></asp:Label>
                </div>

            </div>
        </td>
        <td colspan="3">
            <!-- input for 手机 -->
            <div class="dataDiv">
                <div class="descrip">手机</div>
                <div class="data">

                    <asp:Label ID="AdmPhoneLable" runat="server" Text="手机"></asp:Label>
                </div>

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 电子邮箱 -->
            <div class="dataDiv">
                <div class="descrip">电子邮箱</div>
                <div class="data">

                    <asp:Label ID="AdmEmailLable" runat="server" Text="电子邮箱"></asp:Label>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <lable style="font-size: large; font-weight: bolder;">项目主要参加人</lable>
        </td>
    </tr>
    <ProgremInf:LineForProgremParter runat="server" ID="LineForProgremParter"></ProgremInf:LineForProgremParter>
    <!-- 用于放置项目成员信息 -->
    <asp:PlaceHolder runat="server" ID="LineForProgremParterPut"></asp:PlaceHolder>
</table>
<h2>二、项目论证</h2>
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
<h2>三、评审意见</h2>
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

