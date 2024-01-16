<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PrintMassage.ascx.cs" Inherits="ASCX_PrintMassage" %>

<%@ Register Src="~/ASCX/Massage/popMassage.ascx" TagName="popMassage" TagPrefix="TpopMassage" %>

<%@ Import Namespace="System.Timers" %>
<style type="text/css">
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
        background: linear-gradient( blue,rgba(255, 255, 255, 0.001)); /* 溢出部分那显示渐变 */
        overflow: hidden;
        margin-right: 10px;
    }
</style>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<!-- Position it: -->
<!-- - `.toast-container` for spacing between toasts -->
<!-- - `top-0` & `end-0` to position the toasts in the upper right corner -->
<!-- - `.p-3` to prevent the toasts from sticking to the edge of the container  -->
<div id ="print" class="toast-container buttom-0 end-0 p-3 index_box">
    <asp:UpdatePanel ID="updateFlight" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="200" OnTick="Timer1_Tick">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="MassageP" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True" OnLoad="MassageP_Load">

    </asp:UpdatePanel>
</div>

