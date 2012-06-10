<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="downloadVideo.aspx.cs" Inherits="Narnoo.Example.demos.Operator.downloadVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Download Operator's Videos - downloadVideo</h2>
    <p>
        Operators' use the Download Videos function to download their highest resolution
        videos.</p>
    <pre class="code" lang="csharp">
try
{
    var request = new OperatorNarnooRequest();
    request.SetAuth(this.appkey, this.secretkey);
    var item = request.DownloadVideo(video_id);

    if (item == null)
    {
        this.lblMessage.Visible = true;
        this.lblMessage.Text = "Brochure cannot found";
    }
    else
    {

        this.detail.Visible = true;
        this.lblDownload_video_stream_path.Text 
                = item.download_video_stream_path;
        this.lblOriginal_video_path.Text 
                = item.original_video_path;

    }

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
        <asp:TextBox ID="txtVideo_id" runat="server" Text="413"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <ul id="detail" runat="server" visible="false">
            <li>download_video_stream_path :
                <asp:Label ID="lblDownload_video_stream_path" runat="server"></asp:Label></li>
            <li>original_video_path :
                <asp:Label ID="lblOriginal_video_path" runat="server"></asp:Label></li>
        </ul>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
