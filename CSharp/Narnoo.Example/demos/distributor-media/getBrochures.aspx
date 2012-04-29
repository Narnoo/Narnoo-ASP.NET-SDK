﻿<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getBrochures.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.getBrochures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get brochures</h2>
    <p>
        Distributors use this get brochures function to retrieve their brochure information.</p>
    <pre class="code" lang="php">
    try
    {
        var request = new DistributorMediaNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        var list = request.GetBrochures();

        this.rptList.DataSource = list;
        this.rptList.DataBind();


    }
    catch (InvalidNarnooRequestException ex)
    {
        this.lblMessage.Visible = true;
        this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
    }
	
    </pre>
    <div id="demo-frame">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <ul>
                        ';
                        <li>brochure_id :
                            <%# Eval("brochure_id")%></li>
                        <li>entry_date :<%# Eval("entry_date")%></li>
                        <li>thumb_image_path :
                            <%# Eval("thumb_image_path")%></li>
                        <li>preview_image_path :
                            <%# Eval("preview_image_path")%></li>
                        <li>page_order_xml_config :
                            <%# Eval("page_order_xml_config")%></li>
                        <li>validity_date :
                            <%# Eval("validity_date")%></li>
                        <li>brochure_caption :
                            <%# Eval("brochure_caption")%></li>
                    </ul>
                </li>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
