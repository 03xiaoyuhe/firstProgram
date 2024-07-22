<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramShow.ascx.cs" Inherits="WebForm.ASCX.ProgramInform.ProgramShow" %>

<%@ Register Src="./ForProgramShow/DataFormForParters.ascx" TagName="LineForProgremParter" TagPrefix="ProgremInf" %>
<%@ Register Src="~/ASCX/BaseForm/ShowBoxForm.ascx" TagName="ShowBoxForm" TagPrefix="BaseForm" %>


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
        padding-top: 40px;
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
                    <BaseForm:ShowBoxForm runat="server" ID="PB_ID" DataHead="项目ID" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <!-- input for 课题名称 -->
                    <BaseForm:ShowBoxForm runat="server" ID="ProjectName" DataHead="课题名称" />
                </td>
            </tr>

            <tr>
                <td colspan="6">
                    <!-- input for 项目状态 -->
                    <BaseForm:ShowBoxForm runat="server" ID="ProjectState" DataHead="项目状态" />
                </td>
            </tr>

            <tr>
                <td colspan="6">
                    <!-- input for 项目类别 -->
                    <BaseForm:ShowBoxForm runat="server" ID="ProjectCategory" DataHead="项目类别" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <!-- input for 学科分类 -->
                    <BaseForm:ShowBoxForm runat="server" ID="DisciplineClassification" DataHead="学科分类" />
                </td>
            </tr>

            <tr>
                <td colspan="3">
                    <!-- input for 项目完成时间 -->
                    <BaseForm:ShowBoxForm runat="server" ID="EndingDate" DataHead="项目完成时间" />
                </td>
                <td colspan="3">
                    <!-- input for 最后成果形式 -->
                    <BaseForm:ShowBoxForm runat="server" ID="Ending" DataHead="最后成果形式" />
                </td>
            </tr>

        </table>
    </div>
    <div class="tab-content" id="tab2">

        <table class="dataTable">
            <tr>
                <td colspan="6">
                    <!-- input for 本项目国内外研究现状述评、选题意义和价值。限 1200 字以内 -->
                    <BaseForm:ShowBoxForm runat="server" ID="ProjectSignificance" DataHead="项目国内外研究现状述评，选题意义及价值" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <!-- input for 本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内 -->

                    <BaseForm:ShowBoxForm runat="server" ID="ProjectDocument" DataHead="项目研究的主要观点、基本思路和方法、重点难点及创新之处" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <!-- input for 项目负责人和主要成员前期研究成果及参考文献。限填20项 -->
                    <BaseForm:ShowBoxForm runat="server" ID="ProjectReferences" DataHead="项目负责人和主要成员前期研究成果及主要参考文献" />
                </td>
            </tr>
        </table>
    </div>
    <div class="tab-content" id="tab3">
        <table class="dataTable">
            <tr>
                <td>
                    <!-- input for 项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章 -->

                    <BaseForm:ShowBoxForm runat="server" ID="UnitJudge" DataHead="所在单位评审意见" />
                </td>
            </tr>
            <tr>
                <td>
                    <!-- input for 项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章 -->

                    <BaseForm:ShowBoxForm runat="server" ID="UnitJudgeDate" DataHead="所在单位评审意见时间" />
                </td>
            </tr>
            <tr>
                <td>
                    <!-- input for 专家组评审意见 -->
                    <BaseForm:ShowBoxForm runat="server" ID="ExpertJudge" DataHead="专家组评审意见" />
                </td>
            </tr>
            <tr>
                <td>
                    <!-- input for 专家组评审意见 -->
                    <BaseForm:ShowBoxForm runat="server" ID="ExpertJudgeDate" DataHead="专家组评审意见时间" />
                </td>
            </tr>
            <tr>
                <td>
                    <!-- input for 审批意见 -->
                    <BaseForm:ShowBoxForm runat="server" ID="ApprovalOpinion" DataHead="审批意见" />
                </td>
            </tr>
            <tr>
                <td>
                    <!-- input for 审批意见 -->
                    <BaseForm:ShowBoxForm runat="server" ID="ApprovalOpinionDate" DataHead="审批意见时间" />
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

