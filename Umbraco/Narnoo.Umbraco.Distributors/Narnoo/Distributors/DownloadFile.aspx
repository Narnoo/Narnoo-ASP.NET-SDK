<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/umbracoDialog.Master" AutoEventWireup="true" CodeBehind="DownloadFile.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.DownloadFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
    <span>Requesting download links for the following 2 image(s):</span>

    <asp:Repeater ID="rptItems" runat="server">
        <FooterTemplate>
            <ol>
        </FooterTemplate>
        <ItemTemplate>
            <li data-itemid="<%# Eval("id") %>">
                <span>Item ID: <%# Eval("id") %>...</span><span></span>
            </li>
            Item ID: 1984...

        </ItemTemplate>
        <FooterTemplate>
            </ol>

        </FooterTemplate>
    </asp:Repeater>

    <span id="lblSuccess">Processing completed. 2 of 2 item(s) successful.</span>

</asp:Content>
