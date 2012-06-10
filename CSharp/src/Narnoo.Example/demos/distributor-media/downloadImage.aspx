<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="downloadImage.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.downloadImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's Download Image</h2>
    <p>
        Distributors use this downloadImage function to download the highest resolution
        image file. *only available to approved Distributors</p>
    <pre class="code" lang="csharp">
try
{
    var item = this.NarnooRequest.DownloadImage(image_id);
    this.lblDownload_image_link.Text = item.download_image_link;
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <label for="image_id">
            image_id</label>
        <asp:TextBox ID="txtImage_id" runat="server" Text="212"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblDownload_image_link" runat="server"> </asp:Label>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
