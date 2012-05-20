<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getAlbumImages.aspx.cs" Inherits="Narnoo.Example.demos.Operator.getAlbumImages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Get Operator's Album Images - getAlbumImages</h2>
    <p>
        Operators' use the Get Album Images function to retrieve their images within an
        album.</p>
    <pre class="code" lang="csharp">
try
{
    var request = new OperatorNarnooRequest();
    request.SetAuth(this.appkey, this.secretkey);
    var list = request.GetAlbumImages(album_name);

    this.rptList.DataSource = list;
    this.rptList.DataBind();

}
catch (InvalidNarnooRequestException ex)
{
    this.lblMessage.Visible = true;
    this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode
        + "</br> ErrorMessage:" + ex.Error.errorMessage;
}
	</pre>
    <div id="demo-frame">
        <label for="album_name">
            album name</label>
        <asp:TextBox ID="txtAlbum_name" runat="server" Text="test"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
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
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
