<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="SearchMedia.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.SearchMedia" %>

<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.uicontrols" Assembly="controls" %>
<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.controls" Assembly="umbraco" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
        <link href="narnoo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <UmbracoControls:UmbracoPanel ID="Panel2" runat="server" Height="224px" Width="412px" hasMenu="false">
        <div style="padding: 2px 15px 0px 15px">
            <asp:PlaceHolder ID="dashBoardContent" runat="server"></asp:PlaceHolder>
        </div>
    </UmbracoControls:UmbracoPanel>
    <UmbracoControls:TabView ID="dashboardTabs" Width="400px" Visible="false" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
