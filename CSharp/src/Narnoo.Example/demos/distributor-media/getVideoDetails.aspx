<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getVideoDetails.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.getVideoDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get video details</h2>
    <p>
        Distributors use this Get Video Details function to retreive a single video's details</p>
    <pre class="code" lang="csharp">
try
{
    var item = this.NarnooRequest.GetVideoDetails(videoId);

    this.searchPanel.Visible = false;
    this.resultPanel.Visible = true;

    this.lblVideo_id.Text = item.video_id;
    this.lblEntry_date.Text = item.entry_date;
    this.lblVideo_caption.Text = item.video_caption;
    this.lblVideo_language.Text = item.video_language;
    this.lblVideo_pause_image_path.Text = item.video_pause_image_path;
    this.lblVideo_preview_path.Text = item.video_preview_path;
    this.lblVideo_webm_path.Text = item.video_webm_path;
    this.lblVideo_stream_path.Text = item.video_stream_path;
    this.lblVideo_hqstream_path.Text = item.video_hqstream_path;
    this.lblVideo_thumb_image_path.Text = item.video_thumb_image_path;
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <div id="searchPanel" runat="server">
            <label for="video_id">
                video id</label>
            <asp:TextBox ID="txtVideoId" runat="server" Text="160"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        </div>
        <div id="resultPanel" runat="server" visible="false">
        <ul>
            <li>video_id :
                <asp:Label ID="lblVideo_id" runat="server"></asp:Label></li>
            <li>entry_date :
                <asp:Label ID="lblEntry_date" runat="server"></asp:Label></li>
            <li>video_thumb_image_path :
                <asp:Label ID="lblVideo_thumb_image_path" runat="server"></asp:Label></li>
            <li>video_pause_image_path :
                <asp:Label ID="lblVideo_pause_image_path" runat="server"></asp:Label></li>
            <li>video_preview_path :
                <asp:Label ID="lblVideo_preview_path" runat="server"></asp:Label></li>
            <li>video_webm_path :
                <asp:Label ID="lblVideo_webm_path" runat="server"></asp:Label></li>
            <li>video_stream_path :
                <asp:Label ID="lblVideo_stream_path" runat="server"></asp:Label></li>
            <li>video_hqstream_path :
                <asp:Label ID="lblVideo_hqstream_path" runat="server"></asp:Label></li>
            <li>video_caption :
                <asp:Label ID="lblVideo_caption" runat="server"></asp:Label></li>
            <li>video_language :
                <asp:Label ID="lblVideo_language" runat="server"></asp:Label></li>
            </ul>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
