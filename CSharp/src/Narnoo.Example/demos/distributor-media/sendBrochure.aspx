<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="sendBrochure.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.sendBrochure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's send brochure</h2>
    <p>
        This function allows the distributor to create a download link for the high resolution
        version of a brochure.</p>
    <pre class="code" lang="csharp">
try
{
    var response =  this.NarnooRequest.sendBrochure(brochure_id);
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
            brochure_id</label>
        <asp:TextBox ID="txtBrochure_id" runat="server" Text="244"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <br />
        expiry_date:
        <asp:Label ID="lblExpiry_date" runat="server"></asp:Label><br />
        download_link:
        <asp:HyperLink ID="lnkDownload_link" runat="server"></asp:HyperLink><br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
