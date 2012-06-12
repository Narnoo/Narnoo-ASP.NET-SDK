<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getSingleBrochure.aspx.cs" Inherits="Narnoo.Example.demos.distributor_operator_media.getSingleBrochure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get an Opeartor's single brochure details</h2>
    <p>
        Distributors use this function to retrieve Operator's single brochure information</p>
    <pre class="code" lang="csharp">
try
{
    var item = this.NarnooRequest.GetSingleBrochure(operator_id, brochure_id);

    this.searchPanel.Visible = false;
    this.resultPanel.Visible = true;

    this.txtBrochureId.Text = item.brochure_id;
    this.txtbrochure_caption.Text = item.brochure_caption;
    this.txtEntry_date.Text = item.entry_date;
    this.txtPage_order_xml_config.Text = item.page_order_xml_config;
    this.txtPreview_image_path.Text = Utilities.DecodeCData(item.preview_image_path);
    this.lblFormat.Text = item.format;

    this.txtThumb_image_path.Text = item.thumb_image_path;
    this.txtvalidity_date.Text = item.validity_date;

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
            <label for="operator_id">
                Operator id</label>
            <asp:TextBox ID="txtOperator_id" runat="server" Text="39"></asp:TextBox>
            <label for="brochure_id">
                brochure id</label>
            <asp:TextBox ID="txtBrochure_id" runat="server" Text="310"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        </div>
        <div id="resultPanel" runat="server" visible="false">
            <ul>
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
                                    <%# Container.DataItem %>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </li>
                <li>zoom_page :
                    <ul>
                        <asp:Repeater ID="rptZoomPages" runat="server">
                            <ItemTemplate>
                                <li>
                                    <%# Container.DataItem %>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </li>
            </ul>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
    <br />
</asp:Content>
