<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="addToAlbum.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.addToAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Add Distributor's album image - addToAlbum</h2>
	<p>This function is used to create a new image album for a distributor.</p>
	 <pre class="code" lang="csharp">
try
{
    this.NarnooRequest.addToAlbum(image_id,album_id);
    this.ShowMessage("done.");
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <label for="txtimage_id">
            image_id</label>
        <asp:TextBox ID="txtimage_id" runat="server" Text="186"></asp:TextBox>
          <label for="txtalbum_id">
            album_id</label>
        <asp:TextBox ID="txtalbum_id" runat="server" Text="26"></asp:TextBox>

        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
