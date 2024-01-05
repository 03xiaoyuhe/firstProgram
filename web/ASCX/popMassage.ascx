<%@ Control Language="C#" AutoEventWireup="true" CodeFile="popMassage.ascx.cs" Inherits="ASCX_popMassage" %>

<style type="text/css">
    .POP-head {
        color: red;
    }
</style>

<link href="../../bootstrap-5.3.0-alpha1-dist/css/bootstrap.min.css" rel="stylesheet" />
<script src="../../bootstrap-5.3.0-alpha1-dist/js/bootstrap.bundle.min.js"></script>

<div id="liveToast" class="z-3 toast show" role="alert" aria-live="assertive" aria-atomic="true" style="background-color: white; margin: 5px;">
    <div class="toast-header" style="background-color: white">
        <img src="" class="rounded me-2" alt="">
        <strong class="me-auto">
            <asp:Label ID="Head" runat="server" Text="Label" ForeColor="Red">Bootstrap</asp:Label>
        </strong>
        <small class="text-muted">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                    </asp:Timer>
                    <asp:Label ID="second" runat="server" Text=""></asp:Label>秒前
                </ContentTemplate>
            </asp:UpdatePanel>
        </small>
        <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
    </div>
    <div class="toast-body" style="background-color: white">
        <asp:Label ID="MAssage" runat="server" Text="Label">错误信息</asp:Label>
    </div>
</div>


