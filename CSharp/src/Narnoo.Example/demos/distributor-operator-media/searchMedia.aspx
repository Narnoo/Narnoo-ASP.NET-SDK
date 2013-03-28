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
           <label for="search_media_type">media_type</label>
            <asp:DropDownList ID="search_media_type" runat="server" ClientIDMode="Static">
                <asp:ListItem Value="image" Selected="True" Text="image"></asp:ListItem>
                <asp:ListItem Value="brochure" Text="brochure"></asp:ListItem>
                <asp:ListItem Value="video" Text="video"></asp:ListItem>
            </asp:DropDownList>
            <br>
            <label for="search_business_name">business_name:</label>
            <input id="search_business_name" name="search_business_name" type="text" value="" runat="server"><br>
            <label for="search_country">country:</label>
            <input id="search_country" name="search_country" type="text" value="" runat="server"><br>
            <label for="search_state">state:</label>
            <input id="search_state" name="search_state" type="text" value="" runat="server"><br>
            <label for="search_category">category:</label>
            <input id="search_category" name="search_category" type="text" value="" runat="server" /><br>
            <label for="search_subcategory">subcategory:</label>
            <input id="search_subcategory" name="search_subcategory" type="text" value="" runat="server"><br>
            <label for="search_suburb">suburb:</label>
            <input id="search_suburb" name="search_suburb" type="text" value="" runat="server"><br>
            <label for="search_location">location:</label>
            <input id="search_location" name="search_location" type="text" value="" runat="server"><br>
            <label for="search_postal_code">postal_code:</label>
            <input id="search_postal_code" name="search_postal_code" type="text" value="" runat="server"><br>
            <label for="search_latitude">latitude:</label>
            <input id="search_latitude" name="search_latitude" type="text" value="" runat="server"><br>
            <label for="search_longitude">longitude:</label>
            <input id="search_longitude" name="search_longitude" type="text" value="" runat="server"><br>
            <label for="search_keywords">keywords:</label>
            <input id="search_keywords" name="search_keywords" type="text" value="" runat="server">
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
