<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getSingleBrochure.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.getSingleBrochure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get single brochure</h2>
    <p>
        Distributors use this getSingleBrochure function to retrieve a single brochure's
        detailed information.</p>
    <pre class="code" lang="csharp">
try
{
    var item = this.NarnooRequest.GetSingleBrochure(brochure_id);

    this.searchPanel.Visible = false;
    this.resultPanel.Visible = true;

    this.brochure_id.Text = item.brochure_id;
    this.brochure_caption.Text = item.brochure_caption;
    this.entry_date.Text = item.entry_date;
    this.page_order_xml_config.Text = item.page_order_xml_config;
    this.preview_image_path.Text = item.preview_image_path;
    this.format.Text = item.format;
    this.thumb_image_pat.Text = item.thumb_image_path;
    this.validity_date.Text = item.validity_date;
    if (item.pages != null)
    {
        rptStandardPages.DataSource = item.pages.standard_pages;
        rptStandardPages.DataBind();

        rptZoomPages.DataSource = item.pages.zoom_page;
        rptZoomPages.DataBind();
    }
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <div id="searchPanel" runat="server">
            <label for="brochure_id">
                brochure id</label>
            <asp:TextBox ID="txtBrochure_id" runat="server" Text="170"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        </div>
        <div id="resultPanel" runat="server" visible="false">
            <dl>
                <dt>brochure_id</dt><dd><asp:Label ID="brochure_id" runat="server"></asp:Label></dd>
                <dt>entry_date</dt><dd><asp:Label ID="entry_date" runat="server"></asp:Label></dd>
                <dt>thumb_image_path</dt><dd><asp:Label ID="thumb_image_pat" h runat="server"></asp:Label></dd>
                <dt>preview_image_path</dt><dd><asp:Label ID="preview_image_path" runat="server"></asp:Label></dd>
                <dt>page_order_xml_config</dt><dd><asp:Label ID="page_order_xml_config" runat="server"></asp:Label></dd>
                <dt>file_path_to_pdf</dt><dd>
                    <asp:Label ID="file_path_to_pdf" runat="server"></asp:Label></dd>
                <dt>validity_date</dt><dd><asp:Label ID="validity_date" runat="server"></asp:Label></dd>
                <dt>brochure_caption</dt><dd><asp:Label ID="brochure_caption" runat="server"></asp:Label></dd>
                <dt>format</dt><dd><asp:Label ID="format" runat="server"></asp:Label></dd>
                <dt>standard_pages</dt><dd>
                    <ul>
                        <asp:Repeater ID="rptStandardPages" runat="server">
                            <ItemTemplate>
                                <li>
                                    <%# Container.DataItem %>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </dd>
                <dt>zoom_page </dt>
                <dd>
                    <ul>
                        <asp:Repeater ID="rptZoomPages" runat="server">
                            <ItemTemplate>
                                <li>
                                    <%# Container.DataItem %>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </dd>
            </dl>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
    <br />
</asp:Content>
