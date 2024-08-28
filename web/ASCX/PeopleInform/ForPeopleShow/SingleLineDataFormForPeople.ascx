<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SingleLineDataFormForPeople.ascx.cs" Inherits="WebForm.ASCX.PeopleInform.ForPeopleShow.SingleLineDataFormForPeople" %>

<%@ Register Src="~/ASCX/BaseForm/ShowBoxForm.ascx" TagName="ShowBoxForm" TagPrefix="BaseForm" %>

<style type="text/css">
    .alert {
        padding: 15px;
        border-radius: 5px;
        background-color: #f8f9fa;
        border: 1px solid #ced4da;
        margin: 10px 0;
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
    }

    .btn {
        padding: 10px 20px;
        font-size: 16px;
        color: #fff;
        background-color: #007bff;
        border: none;
        border-radius: 5px;
        cursor: pointer;
    }

        .btn:active {
            background-color: #0056b3;
        }

    .content {
        margin-top: 10px;
        display: none; /* 初始状态下隐藏内容 */
        text-align: center;
    }

    
    .dataTable {
        width: 100%;
    }
</style>

<div class="alert alert-secondary" role="alert" style="margin: 10px 0;width:100%;">
    <%if (PeopleData != null && !PeopleData.IsEmpty())
        { %>
    <table class="dataTable">
        <tr>
            <td colspan="1">
                <BaseForm:ShowBoxForm runat="server" ID="PEB_ID" DataHead="ID" />
            </td>
            <td colspan="3">
                <BaseForm:ShowBoxForm runat="server" ID="PEB_Name" DataHead="姓名" />
            </td>
            <td colspan="5">
                <BaseForm:ShowBoxForm runat="server" ID="PEB_Employer" DataHead="工作单位" />
            </td>
            <td colspan="5">
                <BaseForm:ShowBoxForm runat="server" ID="PEB_Job" DataHead="职务" />
            </td>
        </tr>
    </table>
    <%}
        else
        { %>
    无信息
<%--    <div id="buttonContainer">
        无信息<!-- Button trigger modal --><br/>
        <a class="btn" id="toggleButton">点击绑定</a>
    </div>

    <div class="content" id="newContent">
        这是新显示的内容。
        <a class="btn" id="cancelButton">取消</a>
    </div>

    <script type="text/javascript">
        document.getElementById('toggleButton').addEventListener('click', function () {
            var buttonContainer = document.getElementById('buttonContainer');
            var newContent = document.getElementById('newContent');
            buttonContainer.style.display = 'none'; // 隐藏按钮
            newContent.style.display = 'block';     // 显示新内容
        });

        document.getElementById('cancelButton').addEventListener('click', function () {
            var buttonContainer = document.getElementById('buttonContainer');
            var newContent = document.getElementById('newContent');
            newContent.style.display = 'none';      // 隐藏新内容
            buttonContainer.style.display = 'block'; // 显示原来的按钮
        });
    </script>--%>

    <%} %>
</div>

