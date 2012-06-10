<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="deleteBrochure.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.deleteBrochure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's delete Brochure</h2>
    <p>
        This function used to delete Brochure of the distributor.</p>
    <pre class="code" lang="csharp">
try
{
    this.NarnooRequest.DeleteBrochure(brochure_id);
    this.ShowMessage("done.");
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
</pre>
    <div id="demo-frame">
        <label for="brochure_id">
            brochure_id</label>
        <asp:TextBox ID="txtBrochure_id" Text="170" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
