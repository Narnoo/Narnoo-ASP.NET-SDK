<%@ Page Title="" Language="C#" MasterPageFile="../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Narnoo.Umbraco.Narnoo.Settings" %>

<%@ Register TagPrefix="cc1" Namespace="umbraco.uicontrols" Assembly="controls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <cc1:umbracopanel id="Panel2" runat="server" height="224px" width="412px" hasmenu="false">
				<div style="padding: 2px 15px 0px 15px">
				<asp:PlaceHolder id="dashBoardContent" Runat="server"></asp:PlaceHolder>
				</div>
			</cc1:umbracopanel>
    <cc1:tabview id="dashboardTabs" width="400px" visible="false" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
