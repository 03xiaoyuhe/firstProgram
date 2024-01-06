<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Timer.ascx.cs" Inherits="ASCX_Timer" %>


<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
 
<div class="form-inline row">
    <asp:UpdatePanel ID="updateFlight" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">      
            </asp:Timer>
            <p style="margin-left:55px">日期：<span class="short-description">
                <asp:label ID="timeLock" runat="server"></asp:label>
            </p>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>

