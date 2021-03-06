﻿<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="downloadVideo.aspx.cs" Inherits="Narnoo.Example.demos.distributor_operator_media.downloadVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's download Operator's Video</h2>
    <p>
        Distributors use this function to download an Operator's HD video file</p>
    <pre class="code" lang="csharp">

try
{
    var item = this.NarnooRequest.DownloadVideo(operator_id, vedio_id);

    this.lblDownload_video_stream_path.Visible = true;
    this.lblOriginal_video_path.Visible = true;
    this.lblDownload_video_stream_path.Text = item.download_video_stream_path;
    this.lblOriginal_video_path.Text = item.original_video_path;
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <label for="operator_id">
            operator_id</label>
        <asp:TextBox ID="txtOperator_id" runat="server" Text="39"></asp:TextBox>
        <label for="video_id">
            video_id</label>
        <asp:TextBox ID="txtVideo_id" runat="server" Text="413"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblDownload_video_stream_path" runat="server">
    
    </asp:Label>
        <asp:Label ID="lblOriginal_video_path" runat="server"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
