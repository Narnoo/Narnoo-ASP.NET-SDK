<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="removeFromChannel.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.removeFromChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Remove a video from a Distributor's channel - removeFromChannel</h2>
	<p>This function is used to remove a video from an already created
		channel.</p>
    <pre class="code" lang="csharp">
try
{
    this.NarnooRequest.removeFromChannel(video_id,channel_id);
    this.ShowMessage("done.");
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <label for="txtVideoId">
            Video Id</label>
        <asp:TextBox ID="txtVideoId" runat="server" Text="176"></asp:TextBox>
        <label for="txtChannelId">
            Channel Id</label>
        <asp:TextBox ID="txtChannelId" runat="server" Text="12"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
