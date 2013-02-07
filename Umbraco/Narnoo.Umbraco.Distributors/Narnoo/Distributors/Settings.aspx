<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Narnoo.Umbraco.Narnoo.Distributors.Settings" %>

<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.uicontrols" Assembly="controls" %>
<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.controls" Assembly="umbraco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <style type="text/css">
        .textField {
            width: 300px;
        }

        .validationSummaryTop {
            margin-top: 10px;
            margin-bottom: 10px;
        }
    </style>

    <UmbracoControls:TabView ID="TabViewDetails" runat="server" Width="552px" Height="692px" />



    <asp:Panel ID="panelSettings" runat="server">

        <asp:ValidationSummary runat="server" DisplayMode="BulletList" ID="ValidationSummaryDetails" CssClass="error validationSummaryTop" ValidationGroup="" HeaderText="<h3>The data has not been saved because there are some errors you need to fix first:</h3>"></asp:ValidationSummary>

        <UmbracoControls:Pane ID="settingsConatiner" runat="server">
            <UmbracoControls:PropertyPanel ID="propAppkey" runat="server" Text="Appkey">
                <asp:TextBox ID="txtAppkey" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valAppkey" ControlToValidate="txtAppkey" ErrorMessage="Appkey is a mandatory field" runat="server" Display="None"></asp:RequiredFieldValidator>
            </UmbracoControls:PropertyPanel>
            <UmbracoControls:PropertyPanel ID="propSecretkey" runat="server" Text="Secretkey">
                <asp:TextBox ID="txtSecretkey" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valSecretkey" ControlToValidate="txtSecretkey" ErrorMessage="Secretkey is a mandatory field" runat="server" Display="None"></asp:RequiredFieldValidator>
            </UmbracoControls:PropertyPanel>
        </UmbracoControls:Pane>
    </asp:Panel>
    <asp:Panel ID="panelInfo" runat="server">

        <UmbracoControls:Pane ID="infoContainer" runat="server">
            <UmbracoControls:PropertyPanel ID="PropertyPanel1" runat="server" Text="Id">
                <asp:Literal ID="lblId" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel2" runat="server" Text="Email">
                <asp:Literal ID="lblEmail" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel3" runat="server" Text="Business Name">
                <asp:Literal ID="lblBusinessName" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel4" runat="server" Text="Contact Name">
                <asp:Literal ID="lblContactName" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel5" runat="server" Text="Country">
                <asp:Literal ID="lblCountry" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel6" runat="server" Text="Post Code">
                <asp:Literal ID="lblPostCode" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel7" runat="server" Text="Suburb">
                <asp:Literal ID="lblSuburb" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel8" runat="server" Text="State">
                <asp:Literal ID="lblState" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel9" runat="server" Text="Phone">
                <asp:Literal ID="lblPhone" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel10" runat="server" Text="URL">
                <asp:Literal ID="lblURL" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel11" runat="server" Text="Total Images">
                <asp:Literal ID="lblTotalImages" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel12" runat="server" Text="Total Brochures">
                <asp:Literal ID="lblTotalBrochures" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>

            <UmbracoControls:PropertyPanel ID="PropertyPanel13" runat="server" Text="Total Videos">
                <asp:Literal ID="lblTotalVideos" runat="server"></asp:Literal>
            </UmbracoControls:PropertyPanel>
        </UmbracoControls:Pane>

    </asp:Panel>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
