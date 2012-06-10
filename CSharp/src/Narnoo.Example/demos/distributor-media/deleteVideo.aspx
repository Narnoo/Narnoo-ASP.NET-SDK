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
    this.lblMessage.Visible = true;
    string videoId = this.txtVideoId.Text;

    try
    {
        var request = new DistributorMediaNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        this.lblMessage.Text = request.deleteVideo(videoId);

    }
    catch (InvalidNarnooRequestException ex)
    {
        this.lblMessage.Visible = true;
        this.ShowMessage(ex.Message);
    }
    
	</pre>
    <div id="demo-frame">
        <label for="video_id">
            video_id</label>
        <asp:TextBox ID="txtVideoId" runat="server" Text="160"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
     
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
