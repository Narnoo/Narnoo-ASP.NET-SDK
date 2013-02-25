<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.Pager" %>
<div id="pager">
    <span id="totalRecords" runat="server" class="displaying-num"></span>
    <span class="pagination-links" id="links" runat="server">
        <asp:LinkButton ID="lnkFirst" runat="server" Text="«" OnCommand="lnkFirst_Command"></asp:LinkButton>
        <asp:LinkButton ID="lnkPrev" runat="server" Text="‹" OnCommand="lnkPrev_Command"></asp:LinkButton>
        <span class="paging-input">
            <asp:TextBox ID="txtCurrent" runat="server" ReadOnly="true" disabled="disabled"></asp:TextBox>
            of <span id="totalPages" runat="server"></span>

        </span>
        <asp:LinkButton ID="lnkNext" runat="server" Text="›" OnCommand="lnkNext_Command"></asp:LinkButton>
        <asp:LinkButton ID="lnkLast" runat="server" Text="»" OnCommand="lnkLast_Command"></asp:LinkButton>
    </span>
</div>
