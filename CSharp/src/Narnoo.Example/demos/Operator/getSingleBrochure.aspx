<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getSingleBrochure.aspx.cs" Inherits="Narnoo.Example.demos.Operator.getSingleBrochure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Get Operator's Single Brochure - getSingleBrochure</h2>
    <p>
        Operators' use the getSingleBrochure function to retrieve their brochure details.</p>
    <pre class="code" lang="csharp">
try
{
    var item = this.NarnooRequest.GetSingleBrochure(brochure_id);

    this.resultPanel.Visible = true;
    this.txtBrochureId.Text = item.brochure_id;
    this.txtbrochure_caption.Text = item.brochure_caption;
    this.txtEntry_date.Text = item.entry_date;
    this.txtPage_order_xml_config.Text = item.page_order_xml_config;
    this.txtPreview_image_path.Text = item.preview_image_path;
    this.lblFormat.Text = item.format;
    this.txtThumb_image_path.Text = item.thumb_image_path;
    this.txtvalidity_date.Text = item.validity_date;

    if (item.pages.Count > 0)
    {
        this.rptStandardPages.DataSource = item.pages[0].standard_pages;
        this.rptStandardPages.DataBind();
        this.rptZoomPages.DataSource = item.pages[0].zoom_page;
        this.rptZoomPages.DataBind();
    }
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <label for="operator_id">
        </label>
        <label for="brochure_id">
            brochure id</label>
        <asp:TextBox ID="txtBrochure_id" runat="server" Text="310"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <ul id="resultPanel" runat="server" visible="false">
            <li>brochure_id :
                <asp:Label ID="txtBrochureId" runat="server"></asp:Label></li>
            <li>entry_date :<asp:Label ID="txtEntry_date" runat="server"></asp:Label></li>
            <li>thumb_image_path :
                <asp:Label ID="txtThumb_image_path" runat="server"></asp:Label></li>
            <li>preview_image_path :
                <asp:Label ID="txtPreview_image_path" runat="server"></asp:Label></li>
            <li>page_order_xml_config :
                <asp:Label ID="txtPage_order_xml_config" runat="server"></asp:Label></li>
            <li>file_path_to_pdf :
                <asp:Label ID="file_path_to_pdf" runat="server"></asp:Label></li>
            <li>validity_date :
                <asp:Label ID="txtvalidity_date" runat="server"></asp:Label></li>
            <li>brochure_caption :
                <asp:Label ID="txtbrochure_caption" runat="server"></asp:Label></li>
            <li>format :
                <asp:Label ID="lblFormat" runat="server"></asp:Label></li>
            <li>standard_pages :
                <ul>
                    <asp:Repeater ID="rptStandardPages" runat="server">
                        <ItemTemplate>
                            <li>
                                <%# Container.DataItem %></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </li>
            <li>zoom_page :
                <ul>
                    <asp:Repeater ID="rptZoomPages" runat="server">
                        <ItemTemplate>
                            <li>
                                <%# Container.DataItem %></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </li>
        </ul>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
    <br />
</asp:Content>
