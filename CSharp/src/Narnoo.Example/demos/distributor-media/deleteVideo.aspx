<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="deleteVideo.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.deleteVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's Delete Video</h2>
    <p>
        This function used to delete Video of the distributor.</p>
    <pre class="code" lang="csharp">
try
{
    this.NarnooRequest.DeleteVideo(videoId);
    this.ShowMessage("done.");
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <label for="video_id">
            video_id</label>
        <asp:TextBox ID="txtVideoId" runat="server" Text="160"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
