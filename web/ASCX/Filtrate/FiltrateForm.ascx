<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FiltrateForm.ascx.cs" Inherits="WebForm.ASCX.Filtrate.FiltrateForm" %>

<%@ Register Src="~/ASCX/Filtrate/FiltrateItemForm.ascx" TagName="FiltrateItemForm" TagPrefix="Filtrate" %>

<div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
    <div class="modal-content">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel"><strong>筛选</strong></h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>

        <div class="modal-body">
            <div class="accordion" id="accordionPanelsStayOpenExample">
                <asp:PlaceHolder ID="FiltrateItemHolder" runat="server">无筛选项
                </asp:PlaceHolder>
            </div>
        </div>

        <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">关闭</button>
            <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="确定" OnClick="Button1_Click" />
        </div>
    </div>
</div>
