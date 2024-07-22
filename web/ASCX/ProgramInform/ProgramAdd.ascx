<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramAdd.ascx.cs" Inherits="WebForm.ASCX.ProgramInform.ProgramAdd" %>

<%@ Register Src="./ForProgramAdd/ALineDataForParters.ascx" TagName="LineForProgremParter" TagPrefix="ProgremInf" %>
<%@ Register Src="~/ASCX/BaseForm/InputBoxForm.ascx" TagName="InputBoxForm" TagPrefix="BaseForm" %>


<!-- D:\______myProgram\哲学与社会科学规划项目信息化管理平台\firstProgram\web\ASCX\BaseForm\InputBoxForm.ascx -->
<style type="text/css">
    .container {
            margin: 20px;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            background-color: #fff;
            position: relative;
        }
        .tabs {
            display: flex;
            cursor: pointer;
            padding-left: 10px;
            background-color: #f1f1f1;
            border-bottom: 1px solid #ddd;
            position: fixed;
            top: 0;
            width: 100%;
            z-index: 1000;
        }
        .tab {
            padding: 10px 20px;
            background-color: #ddd;
            border: 1px solid #ddd;
            border-bottom: none;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            margin-right: 2px;
            position: relative;
            top: 1px;
        }
        .tab.active {
            background-color: #fff;
            border-bottom: none;
            z-index: 2;
            top: 0;
        }
        .tab-content {
            display: none;
            padding: 20px;
            padding-top:40px;
            border: 1px solid #ddd;
            border-top-left-radius: 0;
            border-top-right-radius: 0;
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
            background-color: #fff;
            position: relative;
            z-index: 1;
            top: -5px;
        }
        .tab-content.active {
            display: block;
        }
        .tabs::after {
            content: '';
            display: block;
            width: 100%;
            height: 10px;
            background-color: #fff;
            position: absolute;
            bottom: -10px;
            left: 0;
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
            z-index: 1;
        }

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


    .dataTable {
        width: 100%;
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

<div class="container">
    <div class="tabs">
        <div class="tab active" data-tab="tab1">基本信息</div>
        <div class="tab" data-tab="tab2">项目论证</div>
        <div class="tab" data-tab="tab3">评审意见</div>
    </div>
    <div class="tab-content active" id="tab1">
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
                    <BaseForm:InputBoxForm runat="server" ID="InputForProjectName" Note="课题名称" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <!-- input for 项目类别 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForProjectCategory" Note="项目类别" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <!-- input for 项目状态 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForProjectState" Note="项目状态" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <!-- input for 负责人所在单位 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForDisciplineClassification" Note="学科分类" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
            </tr>

            <tr>
                <td colspan="3">
                    <!-- input for 项目完成时间 -->
                    <BaseForm:InputBoxForm ID="InputForEndingDate" runat="server" Note="项目完成时间" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
                <td colspan="3">
                    <!-- input for 最后成果形式 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForEnding" Note="最后成果形式" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
            </tr>
        </table>
    </div>
    <div class="tab-content" id="tab2">
        <table class="dataTable">
            <tr>
                <td colspan="6">
                    <!-- input for 本项目国内外研究现状述评、选题意义和价值。限 1200 字以内 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForProjectSignificance" Note="本项目国内外研究现状述评、选题意义和价值。限 1200 字以内" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <!-- input for 本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForProjectDocument" Note="本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <!-- input for 项目负责人和主要成员前期研究成果及参考文献。限填20项 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForProjectReferences" Note="项目负责人和主要成员前期研究成果及参考文献。限填20项" />
                </td>
            </tr>
        </table>
    </div>
    <div class="tab-content" id="tab3">
        <table class="dataTable">
            <tr>
                <td>
                    <!-- input for 项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForUnitJudge" Note="项目负责人所在单位审核意见" />
                </td>
            </tr>
            <tr>
                <td>
                    <!-- input for 所在单位评审意见时间 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForUnitJudgeDate" Note="所在单位评审意见时间" TextBoxMode="SingleLine" />
                </td>
            </tr>

            <tr>
                <td>
                    <!-- input for 专家组评审意见 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForExpertJudge" Note="专家组评审意见" />
                </td>
            </tr>
            <tr>
                <td>
                    <!-- input for 专家组评审意见时间 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForExpertJudgeDate" Note="专家组评审意见时间" TextBoxMode="SingleLine" />
                </td>
            </tr>

            <tr>
                <td>
                    <!-- input for 专家组评审意见 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForApprovalOpinion" Note="专家组评审意见" />
                </td>
            </tr>
            <tr>
                <td>
                    <!-- input for 专家组评审意见时间 -->
                    <BaseForm:InputBoxForm runat="server" ID="InputForApprovalOpinionDate" Note="专家组评审意见时间" TextBoxMode="SingleLine" />
                </td>
            </tr>

        </table>


    </div>
</div>
<script type="text/javascript">
    document.addEventListener('DOMContentLoaded', function () {
        const tabs = document.querySelectorAll('.tab');
        const tabContents = document.querySelectorAll('.tab-content');

        tabs.forEach(tab => {
            tab.addEventListener('click', function () {
                tabs.forEach(item => item.classList.remove('active'));
                tabContents.forEach(item => item.classList.remove('active'));

                this.classList.add('active');
                document.getElementById(this.dataset.tab).classList.add('active');
            });
        });
    });
    </script>
