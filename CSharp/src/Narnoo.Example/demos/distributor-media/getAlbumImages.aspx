<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getAlbumImages.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.getAlbumImages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Get Distributor's album images - Get Albums Images</h2>
    <p>
        Distributors use the Get Album Images function to retrieve their list of images
        within an album.</p>
    <pre class="code" lang="csharp">
try
{
    var list = this.NarnooRequest.GetAlbumImages(album_name);
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
            <label for="album_name">
                album name</label>
            <asp:TextBox ID="txtAlbum_name" runat="server" Text="test"></asp:TextBox>
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
                    <li>
                        <ul>
                            <li>album_name:<%# Eval("album_name")%></li>
                            <li>image_id:<%# Eval("image_id")%></li>
                            <li>entry_date:<%# Eval("entry_date")%></li>
                            <li>thumb_image_path:<%# Eval("thumb_image_path")%></li>
                            <li>preview_image_path:<%# Eval("preview_image_path")%></li>
                            <li>large_image_path:<%# Eval("large_image_path")%></li>
                            <li>image_caption:<%# Eval("image_caption")%></li>
                        </ul>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
