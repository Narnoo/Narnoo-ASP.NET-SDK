<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="createChannel.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.createChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create Distributor's channel - createChannel</h2>
    <p>
        This function is used to create a new video channel for a distributor. 
    </p>
    <pre class="code" lang="csharp">
try
{
    this.NarnooRequest.createChannel(channel_name);
    this.ShowMessage("done.");
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
</pre>
    <div id="demo-frame">
        <label for="txtChannelName">
            Channel Name</label>
        <asp:TextBox ID="txtChannelName" runat="server" Text=".NET Channel"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
