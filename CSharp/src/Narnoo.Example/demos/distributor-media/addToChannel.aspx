<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="addToChannel.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.addToChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Add a video into a Distributor's channel - addToChannel</h2>
	<p>This function is used to add a video to an already created channel.
		Distributor's can add their operator's videos to this channel as
		well.. Operator has to be on the Distributors access list.</p>
	 <pre class="code" lang="csharp">
try
{
    this.NarnooRequest.addToChannel(video_id,channel_id);
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
