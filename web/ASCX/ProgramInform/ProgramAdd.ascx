<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramAdd.ascx.cs" Inherits="WebForm.ASCX.ProgramInform.ProgramAdd" %>

<%@ Register Src="./ForProgramAdd/ALineDataForParters.ascx" TagName="LineForProgremParter" TagPrefix="ProgremInf" %>

<style type="text/css">
    /* 将字体设为红色 */
    .setCharRed {
        color: red;
    }

    /* 缩小字体 */
    .setCharSizeSmall {
        font-size: 10px;
    }

    .program-errorBox {
        display: inline-block;
    }


    .index_box {
        position: fixed; /*相对于浏览器进行定位*/
        bottom: 50px;
        right: 0;
        /*background:-webkit-linear-gradient(top, rgba(0,0,0,1),rgba(0,0,0,0));*/
        max-height: 40%;
        overflow: auto;
    }

        .index_box::-webkit-scrollbar {
            display: none
        }

    .ppshade {
        background: linear-gradient( rgba(255, 255, 255, 0.001),blue); /* 溢出部分那显示渐变 */
        overflow: hidden;
        margin-right: 10px;
    }

    
    .dataTable{
        width:100%;
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



<%--
    <div class="form-floating mb-3" style="margin: 5px auto;">
        <asp:TextBox runat="server" class="form-control" ID="floatingInput" placeholder=""></asp:TextBox>
        <label for="floatingInput">项目名称</label>
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator1"
            runat="server"
            ErrorMessage="请输入项目名称"
            Font-Strikeout="False"
            ControlToValidate="floatingInput"
            CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
        </asp:RequiredFieldValidator>
    </div>
--%>
<%--    
    <tr>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
        <th></th>
    </tr>
--%>
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
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="ProgromNameTextBox" placeholder=""></asp:TextBox>
                <label for="ProgromNameTextBox">课题名称</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1"
                    runat="server"
                    ErrorMessage="请输入课题名称"
                    Font-Strikeout="False"
                    ControlToValidate="ProgromNameTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 项目类别 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="ProgromKindsTextBox" placeholder=""></asp:TextBox>
                <label for="ProgromKindsTextBox">项目类别</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2"
                    runat="server"
                    ErrorMessage="请输入项目类别"
                    Font-Strikeout="False"
                    ControlToValidate="ProgromKindsTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 项目负责人 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="ProjromAdmNameTextBox" placeholder=""></asp:TextBox>
                <label for="ProjromAdmNameTextBox">项目负责人</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3"
                    runat="server"
                    ErrorMessage="请输入项目负责人"
                    Font-Strikeout="False"
                    ControlToValidate="ProjromAdmNameTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 负责人所在单位 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="ProgremAdmWhereTextBox" placeholder=""></asp:TextBox>
                <label for="ProgremAdmWhereTextBox">负责人所在单位</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4"
                    runat="server"
                    ErrorMessage="请输入负责人所在单位"
                    Font-Strikeout="False"
                    ControlToValidate="ProgremAdmWhereTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>

    <tr>
        <td colspan="3">
            <!-- input for 项目完成时间 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="ProjectFinishTextBox" placeholder=""></asp:TextBox>
                <label for="ProjectFinishTextBox">项目完成时间</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5"
                    runat="server"
                    ErrorMessage="请输入项目完成时间"
                    Font-Strikeout="False"
                    ControlToValidate="ProjectFinishTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
        <td colspan="3">
            <!-- input for 最后成果形式 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="ProjectEndTextBox" placeholder=""></asp:TextBox>
                <label for="ProjectEndTextBox">最后成果形式</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator6"
                    runat="server"
                    ErrorMessage="请输入最后成果形式"
                    Font-Strikeout="False"
                    ControlToValidate="ProjectEndTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
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
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmNameTextBox" placeholder=""></asp:TextBox>
                <label for="AdmNameTextBox">最后成果形式</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator7"
                    runat="server"
                    ErrorMessage="请输入最后成果形式"
                    Font-Strikeout="False"
                    ControlToValidate="AdmNameTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
        <td colspan="2">
            <!-- input for 出生年月 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmBornTextBox" placeholder=""></asp:TextBox>
                <label for="AdmBornTextBox">出生年月</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator8"
                    runat="server"
                    ErrorMessage="请输入出生年月"
                    Font-Strikeout="False"
                    ControlToValidate="AdmBornTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
        <td colspan="2">
            <!-- input for 性别 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmSexTextBox" placeholder=""></asp:TextBox>
                <label for="AdmSexTextBox">性别</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator9"
                    runat="server"
                    ErrorMessage="请输入性别"
                    Font-Strikeout="False"
                    ControlToValidate="AdmSexTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <!-- input for 职务 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmOrdTextBox" placeholder=""></asp:TextBox>
                <label for="AdmOrdTextBox">职务</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator10"
                    runat="server"
                    ErrorMessage="请输入职务"
                    Font-Strikeout="False"
                    ControlToValidate="AdmOrdTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
        <td colspan="2">
            <!-- input for 职称 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmOrdNameTextBox" placeholder=""></asp:TextBox>
                <label for="AdmOrdNameTextBox">职称</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator11"
                    runat="server"
                    ErrorMessage="请输入职称"
                    Font-Strikeout="False"
                    ControlToValidate="AdmOrdNameTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
        <td colspan="2">
            <!-- input for 专业 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmMarTextBox" placeholder=""></asp:TextBox>
                <label for="AdmMarTextBox">专业</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator12"
                    runat="server"
                    ErrorMessage="请输入专业"
                    Font-Strikeout="False"
                    ControlToValidate="AdmMarTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <!-- input for 研究专长 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmMajBestTextBox" placeholder=""></asp:TextBox>
                <label for="AdmMajBestTextBox">研究专长</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator13"
                    runat="server"
                    ErrorMessage="请输入研究专长"
                    Font-Strikeout="False"
                    ControlToValidate="AdmMajBestTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
        <td colspan="3">
            <!-- input for 现从事专业 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmNowDoTextBox" placeholder=""></asp:TextBox>
                <label for="AdmNowDoTextBox">现从事专业</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator14"
                    runat="server"
                    ErrorMessage="请输入现从事专业"
                    Font-Strikeout="False"
                    ControlToValidate="AdmNowDoTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 工作单位 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmJobWhereTextBox" placeholder=""></asp:TextBox>
                <label for="AdmJobWhereTextBox">工作单位</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator15"
                    runat="server"
                    ErrorMessage="请输入工作单位"
                    Font-Strikeout="False"
                    ControlToValidate="AdmJobWhereTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <!-- input for 通信地址 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmPhoneWhereTextBox" placeholder=""></asp:TextBox>
                <label for="AdmPhoneWhereTextBox">通信地址</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator16"
                    runat="server"
                    ErrorMessage="请输入通信地址"
                    Font-Strikeout="False"
                    ControlToValidate="AdmPhoneWhereTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
        <td colspan="3">
            <!-- input for 是否符合青年项目申报条件 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="IsYoungProjremTextBox" placeholder=""></asp:TextBox>
                <label for="IsYoungProjremTextBox">是否符合青年项目申报条件(填“是”或“否”)</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator17"
                    runat="server"
                    ErrorMessage="请输入是否符合青年项目申报条件"
                    Font-Strikeout="False"
                    ControlToValidate="IsYoungProjremTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <!-- input for 办公个电话 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmAdmPhoneTextBox" placeholder=""></asp:TextBox>
                <label for="AdmAdmPhoneTextBox">办公个电话</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator18"
                    runat="server"
                    ErrorMessage="请输入办公个电话"
                    Font-Strikeout="False"
                    ControlToValidate="AdmAdmPhoneTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
        <td colspan="3">
            <!-- input for 手机 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmPhoneTextBox" placeholder=""></asp:TextBox>
                <label for="AdmPhoneTextBox">手机</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator19"
                    runat="server"
                    ErrorMessage="请输入手机"
                    Font-Strikeout="False"
                    ControlToValidate="AdmPhoneTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 电子邮箱 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="AdmEmailTextBox" placeholder=""></asp:TextBox>
                <label for="AdmEmailTextBox">电子邮箱</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator20"
                    runat="server"
                    ErrorMessage="请输入电子邮箱"
                    Font-Strikeout="False"
                    ControlToValidate="AdmEmailTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <lable style="font-size: large; font-weight: bolder;">项目主要参加人</lable>
        </td>
    </tr>
    <ProgremInf:LineForProgremParter runat="server" id="LineForProgremParter"></ProgremInf:LineForProgremParter>
    <!-- 用于放置项目成员信息 -->
    <asp:PlaceHolder runat="server" ID="LineForProgremParterPut"></asp:PlaceHolder>
</table>
<h2>二、项目论证</h2>
<table class="dataTable">
    <tr>
        <td colspan="6">
            <!-- input for 本项目国内外研究现状述评、选题意义和价值。限 1200 字以内 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" TextMode="MultiLine"  ID="ProjectIntroduceTextBox" placeholder=""></asp:TextBox>
                <label for="ProjectIntroduceTextBox">本项目国内外研究现状述评、选题意义和价值。限 1200 字以内</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator21"
                    runat="server"
                    ErrorMessage="请输入本项目国内外研究现状述评、选题意义和价值。限 1200 字以内"
                    Font-Strikeout="False"
                    ControlToValidate="ProjectIntroduceTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="ProjectMainIdeaTextBox" TextMode="MultiLine" placeholder=""></asp:TextBox>
                <label for="ProjectMainIdeaTextBox">本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator22"
                    runat="server"
                    ErrorMessage="请输入本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内"
                    Font-Strikeout="False"
                    ControlToValidate="ProjectMainIdeaTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <!-- input for 项目负责人和主要成员前期研究成果及参考文献。限填20项 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="ProjectAheadTextBox" TextMode="MultiLine" placeholder=""></asp:TextBox>
                <label for="ProjectAheadTextBox">项目负责人和主要成员前期研究成果及参考文献。限填20项</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator23"
                    runat="server"
                    ErrorMessage="请输入项目负责人和主要成员前期研究成果及参考文献。限填20项"
                    Font-Strikeout="False"
                    ControlToValidate="ProjectAheadTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
            </div>
        </td>
    </tr>
</table>
<h2>三、评审意见</h2>
<table class="dataTable">
    <tr>
        <td>
            <!-- input for 项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章 -->
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="WhereThinkTextBox" TextMode="MultiLine" placeholder=""></asp:TextBox>
                <label for="WhereThinkTextBox">项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章)</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator24"
                    runat="server"
                    ErrorMessage="请输入项目负责人所在单位审核意见"
                    Font-Strikeout="False"
                    ControlToValidate="WhereThinkTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
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
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="MajorThinkTextBox" TextMode="MultiLine" placeholder=""></asp:TextBox>
                <label for="MajorThinkTextBox">专家组评审意见</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator25"
                    runat="server"
                    ErrorMessage="请输入专家组评审意见"
                    Font-Strikeout="False"
                    ControlToValidate="MajorThinkTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
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
            <div class="form-floating mb-3" style="margin: 5px auto;">
                <asp:TextBox runat="server" class="form-control" ID="EndThinkTextBox" TextMode="MultiLine" placeholder=""></asp:TextBox>
                <label for="EndThinkTextBox">审批意见</label>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator26"
                    runat="server"
                    ErrorMessage="请输入审批意见"
                    Font-Strikeout="False"
                    ControlToValidate="EndThinkTextBox"
                    CssClass="setCharRed setCharSizeSmall program-errorBox" Font-Size="10px">
                </asp:RequiredFieldValidator>
                <div class="time">
                    <!-- 时间 -->
                    <asp:Label ID="EndThinkTimeLable" runat="server" Text="年--月--日"></asp:Label>
                </div>
            </div>
        </td>
    </tr>
</table>

