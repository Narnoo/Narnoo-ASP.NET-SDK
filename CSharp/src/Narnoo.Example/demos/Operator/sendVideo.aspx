<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="sendVideo.aspx.cs" Inherits="Narnoo.Example.demos.Operator.sendVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Operator's send video</h2>
    <p>
        This function allows the operator to create a download link for the high resolution
        version of a video.</p>
    <pre class="code" lang="csharp">
try
{
    var response =  this.NarnooRequest.sendVideo(video_id);
    this.lblExpiry_date.Text = response.expiry_date;
    this.lnkDownload_link.NavigateUrl = response.download_link;
    this.lnkDownload_link.Text = response.download_link;
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <label for="input">
            video_id</label>
        <asp:TextBox ID="txtVideo_id" runat="server" Text="435"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <br />
        expiry_date:
        <asp:Label ID="lblExpiry_date" runat="server"></asp:Label><br />
        download_link:
        <asp:HyperLink ID="lnkDownload_link" runat="server"></asp:HyperLink><br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
