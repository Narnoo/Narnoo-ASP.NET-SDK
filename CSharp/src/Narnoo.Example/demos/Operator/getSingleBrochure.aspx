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
    var request = new OperatorNarnooRequest();
    request.SetAuth(this.appkey, this.secretkey);
    var item = request.GetSingleBrochure(brochure_id);

    if (item == null)
    {
        this.lblMessage.Visible = true;
        this.lblMessage.Text = "Brochure cannot found";
    }
    else
    {
        this.detail.Visible = true;
        this.txtBrochureId.Text = item.brochure_id;
        this.txtbrochure_caption.Text = item.brochure_caption;
        this.txtEntry_date.Text = item.entry_date;
        this.txtPage_order_xml_config.Text = item.page_order_xml_config;
        this.txtPreview_image_path.Text = item.preview_image_path;
        this.txtStandard_pages_page_0.Text = item.standard_pages.page_0;
        this.txtStandard_pages_page_1.Text = item.standard_pages.page_1;
        this.txtStandard_pages_page_2.Text = item.standard_pages.page_2;
        this.txtStandard_pages_page_3.Text = item.standard_pages.page_3;
        this.txtStandard_pages_page_4.Text = item.standard_pages.page_4;
        this.txtStandard_pages_page_5.Text = item.standard_pages.page_5;

        this.txtThumb_image_path.Text = item.thumb_image_path;
        this.txtvalidity_date.Text = item.validity_date;
        this.txtZoom_pages_zoom_0.Text = item.zoom_page.zoom_0;
        this.txtZoom_pages_zoom_1.Text = item.zoom_page.zoom_1;
        this.txtZoom_pages_zoom_2.Text = item.zoom_page.zoom_2;
        this.txtZoom_pages_zoom_3.Text = item.zoom_page.zoom_3;
        this.txtZoom_pages_zoom_4.Text = item.zoom_page.zoom_4;
        this.txtZoom_pages_zoom_5.Text = item.zoom_page.zoom_5;


    }

}
catch (InvalidNarnooRequestException ex)
{
    this.lblMessage.Visible = true;
    this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode
        + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
}
	</pre>
    <div id="demo-frame">
        <label for="operator_id">
        </label>
        <label for="brochure_id">
            brochure id</label>
        <asp:TextBox ID="txtBrochure_id" runat="server" Text="310"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <ul id="detail" runat="server" visible="false">
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
            <li>standard_pages :
                <ul>
                    <li>page_0:
                        <asp:Label ID="txtStandard_pages_page_0" runat="server"></asp:Label></li>
                    <li>page_1:
                        <asp:Label ID="txtStandard_pages_page_1" runat="server"></asp:Label></li>
                    <li>page_2:
                        <asp:Label ID="txtStandard_pages_page_2" runat="server"></asp:Label></li>
                    <li>page_3:
                        <asp:Label ID="txtStandard_pages_page_3" runat="server"></asp:Label></li>
                    <li>page_4:
                        <asp:Label ID="txtStandard_pages_page_4" runat="server"></asp:Label></li>
                    <li>page_5:
                        <asp:Label ID="txtStandard_pages_page_5" runat="server"></asp:Label></li>
                </ul>
            </li>
            <li>zoom_page :
                <ul>
                    <li>zoom_0:
                        <asp:Label ID="txtZoom_pages_zoom_0" runat="server"></asp:Label></li>
                    <li>zoom_1:
                        <asp:Label ID="txtZoom_pages_zoom_1" runat="server"></asp:Label></li>
                    <li>zoom_2:
                        <asp:Label ID="txtZoom_pages_zoom_2" runat="server"></asp:Label></li>
                    <li>zoom_3:
                        <asp:Label ID="txtZoom_pages_zoom_3" runat="server"></asp:Label></li>
                    <li>zoom_4:
                        <asp:Label ID="txtZoom_pages_zoom_4" runat="server"></asp:Label></li>
                    <li>zoom_5:
                        <asp:Label ID="txtZoom_pages_zoom_5" runat="server"></asp:Label></li>
                </ul>
            </li>
        </ul>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
    <br />
</asp:Content>
