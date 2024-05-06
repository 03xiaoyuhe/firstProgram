<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FiltrateItemForm.ascx.cs" Inherits="WebForm.ASCX.Filtrate.FiltrateItemForm" %>

<div class="accordion-item">
    <h2 class="accordion-header" id="<% =$"{this.ID}panelsStayOpen-headingOne" %>">
        <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="<% = $"#{this.ID}panelsStayOpen-collapseOne" %>" aria-expanded="true" aria-controls="<% = $"{this.ID}panelsStayOpen-collapseOne" %>">
            <asp:Label ID="TitleLable" runat="server" Text=" "></asp:Label>
        </button>
    </h2>
    <div id="<% = $"{this.ID}panelsStayOpen-collapseOne" %>" class="accordion-collapse collapse" aria-labelledby="<% =$"{this.ID}panelsStayOpen-headingOne" %>">
        <div class="accordion-body">
            <asp:PlaceHolder ID="CheckBoxHolder" runat="server">
                无筛选项
            </asp:PlaceHolder>
        </div>
    </div>
</div>
