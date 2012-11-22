<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getChannelVideos.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.getChannelVideos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get channel videos</h2>
    <p>
        Distributors use this getChannelVideos function to retrieve their video channel
        detailed information.</p>
    <pre class="code" lang="csharp">
try
{
    var list = this.NarnooRequest.GetChannelVideos(channel);
    this.searchPanel.Visible = false;
    this.resultPanel.Visible = true;
    this.lblTotal.Text = list.TotalPages.ToString();
    this.rptList.DataSource = list;
    this.rptList.DataBind();
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <div id="searchPanel" runat="server">
            <label for="channel">
                channel</label>
            <asp:TextBox ID="txtChannel" runat="server" Text="disst_33_channel"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        </div>
        <div id="resultPanel" runat="server" visible="false">
            total pages:
            <asp:Label ID="lblTotal" runat="server"></asp:Label>
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>owner_id :
                        <%# Eval("owner_id")%></li>
                    <li>owner_business_name :<%# Eval("owner_business_name")%></li>
                    <li>video_id :
                        <%# Eval("video_id")%></li>
                    <li>entry_date :
                        <%# Eval("entry_date")%></li>
                    <li>video_thumb_image_path :
                        <%# Eval("video_thumb_image_path")%></li>
                    <li>video_pause_image_path :
                        <%# Eval("video_pause_image_path")%></li>
                    <li>video_preview_path :
                        <%# Eval("video_preview_path")%></li>
                    <li>video_webm_path :
                        <%# Eval("video_webm_path")%></li>
                    <li>video_stream_path :
                        <%# Eval("video_stream_path")%></li>
                    <li>video_hqstream_path :
                        <%# Eval("video_hqstream_path")%></li>
                    <li>video_caption :
                        <%# Eval("video_caption")%></li>
                    <li>video_language :
                        <%# Eval("video_language")%></li>
                    </ul></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul></FooterTemplate>
            </asp:Repeater>
        </div>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
