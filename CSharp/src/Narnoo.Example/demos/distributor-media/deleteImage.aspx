<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="deleteImage.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.deleteImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Distributor's Delete Image</h2>
<p>This function used to delete image of the distributor.</p>
    <pre class="code" lang="csharp">
try
{
    this.NarnooRequest.DeleteImage(image_id);
    this.ShowMessage("done.");
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
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
