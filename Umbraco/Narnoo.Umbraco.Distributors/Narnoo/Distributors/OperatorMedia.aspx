<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="OperatorMedia.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.OperatorMedia" %>

<%@ Register TagPrefix="cc1" Namespace="umbraco.uicontrols" Assembly="controls" %><asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <cc1:UmbracoPanel id="Panel2" runat="server" Height="224px" Width="412px" hasMenu="false">
				<div style="padding: 2px 15px 0px 15px">
				<asp:PlaceHolder id="dashBoardContent" Runat="server"></asp:PlaceHolder>
				</div>
			</cc1:UmbracoPanel>
			<cc1:TabView id="dashboardTabs" Width="400px" Visible="false" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
