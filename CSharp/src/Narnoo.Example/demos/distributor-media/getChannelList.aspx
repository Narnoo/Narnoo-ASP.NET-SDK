<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
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
        var request = new DistributorMediaNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        var list = request.GetChannelList();

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
