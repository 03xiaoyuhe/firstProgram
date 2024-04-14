<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MassageBox.ascx.cs" Inherits="WebForm.ASCX.MassageForm.MassageBox" %>

<div class="toast show" role="alert" aria-live="assertive" aria-atomic="true">
    <div class="toast-header">
        <strong class="me-auto">
            <asp:Label ID="Head" runat="server" Text="Label" ForeColor="Red">Bootstrap</asp:Label>
        </strong>
        <small class="text-muted">
            <asp:Label ID="second" runat="server" Text=""></asp:Label>
        </small>
        <!--  data-bs-dismiss="toast" aria-label="Close" -->
        <asp:Button ID="Button1" runat="server" class="btn-close"  OnClick="Quit_Click" />
    </div>
    <div class="toast-body">
        <asp:Label ID="MAssageLable" runat="server" Text="Label"></asp:Label>
    </div>
</div>