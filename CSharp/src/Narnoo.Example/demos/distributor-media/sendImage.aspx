<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="sendImage.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.sendImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's send Image</h2>
    <p>
        This function allows the distributor to create a download link for the high resolution
        version of an image.</p>
    <pre class="code" lang="csharp">
try
{
    var response =  this.NarnooRequest.sendImage(image_id);
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
        <label for="image_id">
            image_id</label>
        <asp:TextBox ID="txtImage_id" runat="server" Text="212"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <br />
       expiry_date: <asp:Label ID="lblExpiry_date" runat="server"></asp:Label><br />
       download_link: <asp:HyperLink ID="lnkDownload_link" runat="server"></asp:HyperLink><br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
