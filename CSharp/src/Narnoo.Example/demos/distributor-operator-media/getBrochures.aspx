<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getBrochures.aspx.cs" Inherits="Narnoo.Example.demos.distributor_operator_media.getBrochures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get brochures</h2>
    <p>
        Distributors use this function to retrieve Operator's brochure information</p>
    <pre class="code" lang="csharp">
try
{
    var request = new DistributorOperatorMediaNarnooRequest();
    request.SetAuth(this.appkey, this.secretkey);
    var list = request.GetBrochures(operator_id);

    this.rptList.DataSource = list;
    this.rptList.DataBind();

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
            Operator id</label>
        <asp:TextBox ID="txtOperator_id" runat="server" Text="39"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <ul>
                        <li>brochure_id :<%# Eval("brochure_id ")%>
                        </li>
                        <li>entry_date :<%# Eval("entry_date ")%> </li>
                        <li>thumb_image_path :<%# Eval("thumb_image_path ")%>
                        </li>
                        <li>preview_image_path :<%# Eval("preview_image_path ")%>
                        </li>
                        <li>page_order_xml_config :<%# Eval("page_order_xml_config ")%>
                        </li>
                        <li>validity_date :<%# Eval("validity_date ")%>
                        </li>
                        <li>brochure_caption :<%# Eval("brochure_caption ")%>
                        </li>
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
