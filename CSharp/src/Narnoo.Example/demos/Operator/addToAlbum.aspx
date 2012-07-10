<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="addToAlbum.aspx.cs" Inherits="Narnoo.Example.demos.Operator.addToAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Add Operator's album image - addToAlbum</h2>
	<p>This function is used to create a new image album for an operator.</p>
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
        <asp:TextBox ID="txtimage_id" runat="server" Text="1258"></asp:TextBox>
          <label for="txtalbum_id">
            album_id</label>
        <asp:TextBox ID="txtalbum_id" runat="server" Text="49"></asp:TextBox>

        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
