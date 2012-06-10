<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="searchMedia.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.searchMedia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $('input[data-item=media_id]').blur(function () {
                var id = $.trim($(this).val());
                if (id == '') {
                    $('input[type=text]').not($(this)).removeAttr('disabled');
                    $('input[type=radio]').removeAttr('disabled');
                } else {
                    $('input[type=text]').not($(this)).attr('disabled', true).val('');
                    $('input[type=radio]').attr('disabled', true).removeAttr('checked');
                }
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's search their media</h2>
    <p>
        Distributors use this function to search their media. *min 1 criteria needed</p>
    <pre class="code" lang="csharp">
 try
{
    var request = new DistributorMediaNarnooRequest();
    request.SetAuth(this.appkey, this.secretkey);
    IEnumerable<SearchMedia> list = null;
    if (string.IsNullOrEmpty(media_id))
    {
        list = request.SearchMedia(media_type, category, subcategory, suburb, location, latitude, longitude, radius, privilege, keywords, page_no);
    }
    else
    {
        list = request.SearchMedia(media_type, media_id);
    }

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
catch (InvalidNarnooRequestException ex)
{
    this.lblMessage.Visible = true;
    this.ShowMessage(ex.Message); + 
    "</br> ErrorMessage:" + ex.Error.errorMessage;
}
    </pre>
    <div id="demo-frame">
        <label for="media_type">
            media_type</label>
        <asp:DropDownList ID="ddlMedia_Type" runat="server">
            <asp:ListItem Value="image" Text="image" Selected="True"></asp:ListItem>
            <asp:ListItem Value="brochure" Text="brochure"></asp:ListItem>
            <asp:ListItem Value="video" Text="video"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <label for="media_id">
            media_id</label>
        <asp:TextBox ID="txtMediaId" runat="server" ></asp:TextBox>
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
        <label for="radius">
            radius</label>
        <asp:TextBox ID="txtradius" runat="server"></asp:TextBox>
        <br />
        <label for="">
            <asp:RadioButtonList ID="rblprivilege" runat="server">
                <asp:ListItem Value="public">public</asp:ListItem>
                <asp:ListItem Value="private">private</asp:ListItem>
            </asp:RadioButtonList>
        </label>
        <label for="keywords">
            keywords</label>
        <asp:TextBox ID="txtkeywords" runat="server" Text="Narnoo"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
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
                        <dt>standard_pages</dt><dd><ul>
                            <li>page_0:
                                <%# Eval("standard_pages.page_0")%></li>
                            <li>page_1:
                                <%# Eval("standard_pages.page_1")%></li>
                            <li>page_2:
                                <%# Eval("standard_pages.page_2")%></li>
                            <li>page_3:
                                <%# Eval("standard_pages.page_3")%></li>
                            <li>page_4:
                                <%# Eval("standard_pages.page_4")%></li>
                            <li>page_5:
                                <%# Eval("standard_pages.page_5")%></li>
                            }
                        </ul>
                        </dd>
                        <dt>zoom_page </dt>
                        <dd>
                            <ul>
                                <li>page_order_xml_config:
                                    <%# Eval("zoom_page.page_order_xml_config")%></li>
                                <li>file_path_to_pdf:<%# Eval("zoom_page.file_path_to_pdf")%></li>
                                <li>validity_date:
                                    <%# Eval("zoom_page.validity_date")%></li>
                                <li>brochure_caption:
                                    <%# Eval("zoom_page.brochure_caption")%></li>
                                }
                            </ul>
                        </dd>
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
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
