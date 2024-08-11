<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PeopleAdd.ascx.cs" Inherits="WebForm.ASCX.PeopleInform.PeopleAdd" %>

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
        <div class="tab" data-tab="tab2">项目负责人信息补充</div>
    </div>
    <div class="tab-content active" id="tab1">
        <table class="dataTable">
            <tr>
                <td colspan="6">
                    <!-- input for 姓名 -->
                    <BaseForm:InputBoxForm runat="server" ID="PEB_Name" Note="姓名" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <!-- input for 性别 -->
                    <BaseForm:InputBoxForm runat="server" ID="PEB_Sex" Note="性别" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
                <td colspan="3">
                    <!-- input for 生日 -->
                    <BaseForm:InputBoxForm runat="server" ID="PEB_Birthday" Note="生日" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <!-- input for 职务 -->
                    <BaseForm:InputBoxForm ID="PEB_Job" runat="server" Note="职务" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
                <td colspan="3">
                    <!-- input for 职称 -->
                    <BaseForm:InputBoxForm runat="server" ID="PEB_Title" Note="职称" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
            <tr>
                <td colspan="6">
                    <!-- input for 工作单位 -->
                    <BaseForm:InputBoxForm runat="server" ID="PEB_Employer" Note="工作单位" TextBoxMode="SingleLine" CheckEmpty="true" />
                </td>
            </tr>
            </tr>
        </table>
    </div>
    <div class="tab-content" id="tab2">
        <table class="dataTable">
            <tr>
                <td colspan="2">
                    <!-- input for 专业 -->
                    <BaseForm:InputBoxForm runat="server" ID="PE_Major" Note="专业"  TextBoxMode="SingleLine"/>
                </td>
                <td colspan="2">
                    <!-- input for 研究专长 -->
                    <BaseForm:InputBoxForm runat="server" ID="PE_Speciality" Note="研究专长" TextBoxMode="SingleLine" />
                </td>
                <td colspan="2">
                    <!-- input for 现从事专业 -->
                    <BaseForm:InputBoxForm runat="server" ID="PE_Engage" Note="现从事专业" TextBoxMode="SingleLine" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <!-- input for 通信地址 -->
                    <BaseForm:InputBoxForm runat="server" ID="PE_Address" Note="通信地址" TextBoxMode="SingleLine" />
                </td>
                <td colspan="3">
                    <!-- input for 是否符合青年项目申报条件 -->
                    <BaseForm:InputBoxForm runat="server" ID="PE_IsYouth" Note="是否符合青年项目申报条件（填是或否）" TextBoxMode="SingleLine" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <!-- input for 办公电话 -->
                    <BaseForm:InputBoxForm runat="server" ID="PE_OfficePhone" Note="办公电话" TextBoxMode="SingleLine" />
                </td>
                <td colspan="2">
                    <!-- input for 手机 -->
                    <BaseForm:InputBoxForm runat="server" ID="PE_MobilePhone" Note="手机"  TextBoxMode="SingleLine"/>
                </td>
                <td colspan="2">
                    <!-- input for 邮箱 -->
                    <BaseForm:InputBoxForm runat="server" ID="PE_Email" Note="邮箱" TextBoxMode="SingleLine" />
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
