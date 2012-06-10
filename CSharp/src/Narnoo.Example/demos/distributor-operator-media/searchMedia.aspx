<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="searchMedia.aspx.cs" Inherits="Narnoo.Example.demos.distributor_operator_media.searchMedia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's search their Operator's media</h2>
    <p>
        Distributors use this function to search their Operator's media. *min 1 criteria
        needed</p>
    <pre class="code" lang="csharp">
try
{
    var list = this.NarnooRequest.SearchMedia(media_type, category, subcategory, suburb, location, latitude, longitude, keywords);

    this.searchPanel.Visible = false;
    this.resultPanel.Visible = true;

    this.lblTotal.Text = list.TotalPages.ToString();
    switch (media_type)
    {
        case "image":
            this.rptImages.DataSource = list;
            this.rptImages.DataBind();
            break;
        case "brochure":
            this.rptBrochures.DataSource = list;
            this.rptBrochures.DataBind();
            break;
        case "video":
            this.rptVideos.DataSource = list;
            this.rptVideos.DataBind();
            break;
        default:
            break;
    }
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <div id="searchPanel" runat="server">
            <label for="media_type">
                media_type</label>
            <asp:DropDownList ID="ddlMedia_Type" runat="server">
                <asp:ListItem Value="image" Text="image" Selected="True"></asp:ListItem>
                <asp:ListItem Value="brochure" Text="brochure"></asp:ListItem>
                <asp:ListItem Value="video" Text="video"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <label for="category">
                category</label>
            <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
            <br />
            <label for="subcategory">
                subcategory</label>
            <asp:TextBox ID="txtSubcategory" runat="server"></asp:TextBox>
            <br />
            <label for="suburb">
                suburb</label>
            <asp:TextBox ID="txtsuburb" runat="server"></asp:TextBox>
            <br />
            <label for="location">
                location</label>
            <asp:TextBox ID="txtlocation" runat="server"></asp:TextBox>
            <br />
            <label for="latitude">
                latitude</label>
            <asp:TextBox ID="txtlatitude" runat="server"></asp:TextBox>
            <br />
            <label for="longitude">
                longitude</label>
            <asp:TextBox ID="txtlongitude" runat="server"></asp:TextBox>
            <br />
            <label for="keywords">
                keywords</label>
            <asp:TextBox ID="txtkeywords" runat="server" Text="Narnoo"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        </div>
        <div id="resultPanel" runat="server" visible="false">
            total pages:
            <asp:Label ID="lblTotal" runat="server"></asp:Label>
            <asp:Repeater ID="rptImages" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <dl>
                            <dt>entry_date</dt><dd><%# Eval("entry_date")%></dd>
                            <dt>thumb_media_path</dt><dd><%# Eval("thumb_media_path")%></dd>
                            <dt>preview_media_path</dt><dd><%# Eval("preview_media_path")%></dd>
                            <dt>large_media_path</dt><dd><%# Eval("large_media_path")%></dd>
                            <dt>media_owner_business_name</dt><dd><%# Eval("media_owner_business_name")%></dd>
                            <dt>media_caption</dt><dd><%# Eval("media_caption")%></dd>
                        </dl>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul></FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptBrochures" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <dl>
                            <dt>brochure_id</dt><dd><%# Eval("brochure_id")%></dd>
                            <dt>entry_date</dt><dd><%# Eval("entry_date")%></dd>
                            <dt>thumb_image_path</dt><dd><%# Eval("thumb_image_path")%></dd>
                            <dt>preview_image_path</dt><dd><%# Eval("preview_image_path")%></dd>
                        </dl>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul></FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptVideos" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <dl>
                            <dt>video_id</dt><dd><%# Eval("video_id")%></dd>
                            <dt>entry_date</dt><dd><%# Eval("entry_date")%></dd>
                            <dt>video_thumb_image_path</dt><dd><%# Eval("video_thumb_image_path")%></dd>
                            <dt>video_pause_image_path</dt><dd><%# Eval("video_pause_image_path")%></dd>
                            <dt>video_preview_path</dt><dd><%# Eval("video_preview_path")%></dd>
                            <dt>video_stream_path</dt><dd><%# Eval("video_stream_path")%></dd>
                            <dt>video_caption</dt><dd><%# Eval("video_caption")%></dd>
                            <dt>video_language</dt><dd><%# Eval("video_language")%></dd>
                        </dl>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul></FooterTemplate>
            </asp:Repeater>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label></div>
</asp:Content>
