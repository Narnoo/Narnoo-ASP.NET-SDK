<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getVideos.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.getVideos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get videos</h2>
    <p>
        Distributors use this Get Videos function to retreive their videos</p>
    <pre class="code" lang="csharp">
    try
    {
        var request = new DistributorMediaNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        var list = request.GetVideos();

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
                        <li>video_id :
                            <%# Eval("video_id")%></li>
                        <li>entry_date :
                            <%# Eval("entry_date")%></li>
                        <li>video_thumb_image_path :
                            <%# Eval("video_thumb_image_path")%></li>
                        <li>video_pause_image_path :
                            <%# Eval("video_pause_image_path")%></li>
                        <li>video_preview_path :
                            <%# Eval("video_preview_path")%></li>
                        <li>video_stream_path :
                            <%# Eval("video_stream_path")%></li>
                        <li>video_caption :
                            <%# Eval("video_caption")%></li>
                        <li>video_language :
                            <%# Eval("video_language")%></li>
                    </ul>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
