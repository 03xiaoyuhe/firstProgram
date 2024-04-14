<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramShow.ascx.cs" Inherits="WebForm.ASCX.ProgramInform.ProgramShow" %>

<%@ Register Src="./ForProgramShow/ALineForProgremParter.ascx" TagName="LineForProgremParter" TagPrefix="ProgremInf" %>

<h2>一、基本信息</h2>
<table>
    <tr>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
    </tr>
    <tr>
        <td colspan="6"> <!-- input for 课题名称 -->
            <asp:Label ID="ProgromNameLable" runat="server" Text="课题名称"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="6"> <!-- input for 项目类别 -->
            <asp:Label ID="ProgromKindsLable" runat="server" Text="项目类别"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="6"> <!-- input for 项目负责人 -->
            <asp:Label ID="ProjromAdmNameLable" runat="server" Text="项目负责人"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="6"> <!-- input for 负责人所在单位 -->
            <asp:Label ID="ProgremAdmWhereLable" runat="server" Text="负责人所在单位"></asp:Label>
        </td>
    </tr>


</table>
<h2>二、项目负责人基本信息</h2>
<table>
    <tr>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
    </tr>
    <tr>
        <td colspan="2"> <!--input for 姓名-->
            <asp:Label ID="AdmNameLable" runat="server" Text="姓名"></asp:Label>
        </td>
        <td colspan="2"> <!-- input for 出生年月 -->
            <asp:Label ID="AdmBornLable" runat="server" Text="出生年月"></asp:Label>
        </td>
        <td colspan="2"> <!-- input for 性别 -->
            <asp:Label ID="AdmSexLable" runat="server" Text="性别"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2"> <!-- input for 职务 -->
            <asp:Label ID="AdmOrdLable" runat="server" Text="职务"></asp:Label>
        </td>
        <td colspan="2"> <!-- input for 职称 -->
            <asp:Label ID="AdmOrdNameLable" runat="server" Text="职称"></asp:Label>
        </td>
        <td colspan="2"> <!-- input for 专业 -->
            <asp:Label ID="AdmMarLable" runat="server" Text="专业"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="3"> <!-- input for 研究专长 -->
            <asp:Label ID="AdmMajBestLable" runat="server" Text="研究专长"></asp:Label>
        </td>
        <td colspan="3"> <!-- input for 现从事专业 -->
            <asp:Label ID="AdmNowDoLable" runat="server" Text="现从事专业"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="6"> <!-- input for 工作单位 -->
            <asp:Label ID="AdmJobWhereLable" runat="server" Text="工作单位"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="3"> <!-- input for 通信地址 -->
            <asp:Label ID="AdmPhoneWhereLable" runat="server" Text="通信地址"></asp:Label>
        </td>
        <td colspan="3"> <!-- input for 是否符合青年项目申报条件 -->
            <asp:Label ID="IsYoungProjremLable" runat="server" Text="是否符合青年项目申报条件"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="3"> <!-- input for 办公个电话 -->
            <asp:Label ID="AdmAdmPhoneLable" runat="server" Text="办公个电话"></asp:Label>
        </td>
        <td colspan="3"> <!-- input for 手机 -->
            <asp:Label ID="AdmPhoneLable" runat="server" Text="手机"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="6"> <!-- input for 电子邮箱 -->
            <asp:Label ID="AdmEmailLable" runat="server" Text="电子邮箱"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="6"> <lable style="font-size:large;font-weight:bolder;">项目主要参加人</lable> </td>
    </tr>
    <%for (int i = 0; i < DataForParts.Count; i++)
      { %>

        <ProgremInf:LineForProgremParter runat="server" ID ="<% = "LineForProgremParter" + i.ToString()%>" LineDataForParter="<% = DataForParts[i] %>"></ProgremInf:LineForProgremParter>

    <%
        } %>

    <tr>
        <td colspan="3"> <!-- input for 项目完成时间 -->
            <asp:Label ID="ProjectFinishLable" runat="server" Text="Label"></asp:Label>
        </td>
        <td colspan="3"> <!-- input for 最后成果形式 -->
            <asp:Label ID="ProjectEndLable" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
</table>
<h2>二、项目论证</h2>
<table>
    <tr>
        <td colspan="6"> <!-- input for 项目名称 -->
            <asp:Label ID="ProjectNameLable" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="6"> <!-- input for 本项目国内外研究现状述评、选题意义和价值。限 1200 字以内 -->
            <asp:Label ID="ProjectIntroduceLable" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="6"> <!-- input for 本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内 -->
            <asp:Label ID="ProjectMainIdeaLable" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="6"> <!-- input for 项目负责人和主要成员前期研究成果及参考文献。限填20项 -->
            <asp:Label ID="ProjectAheadLable" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
</table>
<h2>三、评审意见</h2>
<table>
    <tr>
        <td>
            <!-- input for 项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章 -->
            <asp:Label ID="WhereThinkLable" runat="server" Text="Label"></asp:Label>
            <div>
                <asp:Label ID="WhereThinkTimeLable" runat="server" Text="Label"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <!-- input for 专家组评审意见 -->
            <asp:Label ID="MajorThinkLable" runat="server" Text="Label"></asp:Label>
            <div>
                <asp:Label ID="MajorThinkTimeLable" runat="server" Text="Label"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <!-- input for 审批意见 -->
            <asp:Label ID="EndThinkLable" runat="server" Text="Label"></asp:Label>
            <div>
                <asp:Label ID="EndThinkTimeLable" runat="server" Text="Label"></asp:Label>
            </div>
        </td>
    </tr>
</table>

