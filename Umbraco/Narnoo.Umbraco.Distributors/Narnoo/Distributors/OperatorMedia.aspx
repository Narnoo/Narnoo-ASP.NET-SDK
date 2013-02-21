<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="OperatorMedia.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.OperatorMedia" %>

<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.uicontrols" Assembly="controls" %>
<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.controls" Assembly="umbraco" %>

<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <UmbracoControls:TabView ID="TabViewDetails" runat="server" Width="552px" Height="692px" />

    <asp:Panel ID="tabAlbums" runat="server">
        <asp:Label ID="lblOperatorId" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="tabImages" runat="server">
    </asp:Panel>

    <asp:Panel ID="tabBrochures" runat="server">
    </asp:Panel>

    <asp:Panel ID="tabVideos" runat="server">
    </asp:Panel>

    <asp:Panel ID="tabText" runat="server">
    </asp:Panel>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        $(function () {
            //activeTab, [tabviewid, tabid, tabid]
            //setActiveTab('body_TabViewDetails', 'body_TabViewDetails_tab01', body_TabViewDetails_tabs)

            Umbraco.Controls.TabView.onActiveTabChange(function (activeTab, options) {
                console.log(activeTab);
                console.log(options);
            });
        });


    </script>
</asp:Content>
