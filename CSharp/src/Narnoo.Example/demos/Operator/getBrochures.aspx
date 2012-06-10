<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getBrochures.aspx.cs" Inherits="Narnoo.Example.demos.Operator.getBrochures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Get Operator's Brochures - getBrochures</h2>
    <p>
        Operators' use the Get Brochure Details function to retrieve their brochure information.</p>
    <pre class="code" lang="csharp">
try
{
    var list = this.NarnooRequest.GetBrochures();

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
        total pages:
        <asp:Label ID="lblTotal" runat="server"></asp:Label>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <ul>
                        <li>brochure_id :<%# Eval("brochure_id ")%>
                        </li>
                        <li>entry_date :<%# Eval("entry_date ")%>
                        </li>
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
