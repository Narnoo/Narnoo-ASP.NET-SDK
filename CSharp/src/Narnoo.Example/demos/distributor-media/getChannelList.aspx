﻿<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getChannelList.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.getChannelList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get channel list</h2>
    <p>
        Distributors use this getChannelList function to retrieve their video channel names.</p>
    <pre class="code" lang="csharp">
try
{
    var list = this.NarnooRequest.GetChannelList();
    this.lblTotal.Text = list.TotalPages.ToString();
    this.rptList.DataSource = list;
    this.rptList.DataBind();
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
</pre>
    <div id="demo-frame">
        total pages:
        <asp:Label ID="lblTotal" runat="server"></asp:Label>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <ul>
                        <li>channel_id :
                            <%# Eval("channel_id")%></li>
                        <li>channel_name :<%# Eval("channel_name")%></li>
                        <li>location :
                            <%# Eval("location")%></li>
                        <li>latitude :
                            <%# Eval("latitude")%></li>
                        <li>longitude :
                            <%# Eval("longitude")%></li>
                    </ul>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
