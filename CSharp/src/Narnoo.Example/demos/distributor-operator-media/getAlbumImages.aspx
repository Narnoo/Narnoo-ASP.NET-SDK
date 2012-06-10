<%@  Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getAlbumImages.aspx.cs" Inherits="Narnoo.Example.demos.distributor_operator_media.getAlbumImages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get Operator's album images</h2>
    <p>
        Distributors use this function to retrieve Operator's album images</p>
    <pre class="code" lang="csharp">
try
{
    var list = this.NarnooRequest.GetAlbumImages(operator_id, album_name);

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
            <label for="operator">
                Operator id</label>
            <asp:TextBox ID="txtOperator_id" runat="server" Text="39"></asp:TextBox>
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
                    </ul></FooterTemplate>
            </asp:Repeater>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
