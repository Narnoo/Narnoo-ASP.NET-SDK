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
        var request = new DistributorMediaNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        var list = request.GetSingleBrochure(brochure_id);

        this.rptList.DataSource = list;
        this.rptList.DataBind();


    }
    catch (InvalidNarnooRequestException ex)
    {
        this.lblMessage.Visible = true;
        this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
    }
    
	</pre>
    <div id="demo-frame">
        <label for="brochure_id">
            brochure id</label>
        <asp:TextBox ID="txtBrochure_id" runat="server" Text="170"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <dl>
            </HeaderTemplate>
            <ItemTemplate>
                <dt>brochure_id</dt><dd><%# Eval("brochure_id")%></dd>
                <dt>entry_date</dt><dd><%# Eval("entry_date")%></dd>
                <dt>thumb_image_path</dt><dd><%# Eval("thumb_image_path")%></dd>
                <dt>preview_image_path</dt><dd><%# Eval("preview_image_path")%></dd>
                <dt>page_order_xml_config</dt><dd><%# Eval("page_order_xml_config")%></dd>
                <dt>file_path_to_pdf</dt><dd>' . uncdata ( $brochure->file_path_to_pdf )")%></dd>
                <dt>validity_date</dt><dd><%# Eval("validity_date")%></dd>
                <dt>brochure_caption</dt><dd><%# Eval("brochure_caption")%></dd>
                <dt>standard_pages</dt><dd>
                    <ul>
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
                    </ul>
                </dd>
                <dt>zoom_page </dt>
                <dd>
                    <ul>
                        <li>zoom_0:
                            <%# Eval("zoom_page.zoom_0")%></li>
                        <li>zoom_1:
                            <%# Eval("zoom_page.zoom_1")%></li>
                        <li>zoom_2:
                            <%# Eval("zoom_page.zoom_2")%></li>
                        <li>zoom_3:
                            <%# Eval("zoom_page.zoom_3")%></li>
                        <li>zoom_4:
                            <%# Eval("zoom_page.zoom_4")%></li>
                        <li>zoom_5:
                            <%# Eval("zoom_page.zoom_5")%></li>
                    </ul>
                </dd>
            </ItemTemplate>
            <FooterTemplate>
                </dl>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
    <br />
</asp:Content>
