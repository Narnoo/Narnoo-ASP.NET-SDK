<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getVideos.aspx.cs" Inherits="Narnoo.Example.demos.Operator.getVideos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Get Operator's Videos - getVideos</h2>
    <p>
        Operators' use the Get Videos function to retrieve their own videos.</p>
    <pre class="code" lang="csharp">
try
{
    var list = this.NarnooRequest.GetVideos();

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
        total pages:
        <asp:Label ID="lblTotal" runat="server"></asp:Label>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <ul>
                        <li>video_id :
                            <%# Eval("video_id")%></li>
                        <li>entry_date :<%# Eval("entry_date")%></li>
                        <li>video_thumb_image_path :
                            <%# Eval("video_thumb_image_path")%></li>
                        <li>video_pause_image_path :
                            <%# Eval("video_pause_image_path")%></li>
                        <li>video_preview_path :
                            <%# Eval("video_preview_path")%></li>
                        <li>video_caption :
                            <%# Eval("video_caption")%></li>
                        <li>video_language :
                            <%# Eval("video_language")%></li>
                    </ul>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
