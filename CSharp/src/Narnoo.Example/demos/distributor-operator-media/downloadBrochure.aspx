<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="downloadBrochure.aspx.cs" Inherits="Narnoo.Example.demos.distributor_operator_media.downloadBrochure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's download Operator's Brochure</h2>
    <p>
        Distributors use this function to download an Operator's PDF brochure</p>
    <pre class="code" lang="csharp">
try
{
    var item = this.NarnooRequest.DownloadBrochure(operator_id, brochure_id);
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
        <asp:TextBox ID="txtOperator_id" Text="39" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtBrochure_id" Text="310" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblDownload_brochure_to_pdf_path" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
