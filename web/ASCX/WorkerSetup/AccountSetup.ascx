<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccountSetup.ascx.cs" Inherits="ASCX_WorkerSetup_AccountSetup" %>

<style type="text/css">
    .form-div {
        overflow: auto;
        height: 600px;
    }

    .index-part {
        width: 100px;
    }
</style>


<div class="row form-div">
    <div class="col-2 ">
        <div id="list-example" class="list-group form-div">
            <a class="list-group-item list-group-item-action" href="#list-item-1">账户信息</a>
            <a class="list-group-item list-group-item-action" href="#list-item-2">Item 2</a>
            <a class="list-group-item list-group-item-action" href="#list-item-3">Item 3</a>
            <a class="list-group-item list-group-item-action" href="#list-item-4">Item 4</a>
        </div>
    </div>
    <div class="col-10">
    <h3>账户信息</h3>
        <div data-bs-spy="scroll" data-bs-target="#list-example" data-bs-smooth-scroll="true" class="scrollspy-example form-div" tabindex="0">
            <h4 id="list-item-1">账户信息</h4>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <h4 id="list-item-2">Item 2</h4>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <h4 id="list-item-3">Item 3</h4>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <h4 id="list-item-4">Item 4</h4>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
            <p>...</p>
        </div>
    </div>
</div>
