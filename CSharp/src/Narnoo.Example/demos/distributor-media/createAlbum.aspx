<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="createAlbum.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.createAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create Distributor's Albums - createAlbum</h2>
    <p>
        This function is used to create a new image album for a distributor.
    </p>
    <pre class="code" lang="csharp">
try
{
    this.NarnooRequest.createAlbum(album_name);
    this.ShowMessage("done.");
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
</pre>
    <div id="demo-frame">
        <label for="txtAlbumName">
            Album Name</label>
        <asp:TextBox ID="txtAlbumName" runat="server" Text="test album"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
