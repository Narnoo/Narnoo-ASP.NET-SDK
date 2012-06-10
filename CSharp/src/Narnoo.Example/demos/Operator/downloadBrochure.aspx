<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="downloadBrochure.aspx.cs" Inherits="Narnoo.Example.demos.Operator.downloadBrochure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Download Operator's Brochures - downloadBrochures</h2>
    <p>
        Operators' use the downloadBrochures function to download their high resolution
        brochure.</p>
    <pre class="code" lang="csharp">
try
{
    var item = this.NarnooRequest.DownloadBrochure(brochure_id);

    this.lblDownload_brochure_to_pdf_path.Visible = true;
    this.lblDownload_brochure_to_pdf_path.Text = item.download_brochure_to_pdf_path;
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <label for="brochure_id">
            brochure_id</label>
        <asp:TextBox ID="txtBrochure_id" runat="server" Text="310"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblDownload_brochure_to_pdf_path" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
</asp:Content>
