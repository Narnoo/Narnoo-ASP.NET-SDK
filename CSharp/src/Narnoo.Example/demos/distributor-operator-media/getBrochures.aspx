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
    var list = this.NarnooRequest.GetBrochures(operator_id);

    this.searchPanel.Visible = false;
    this.resultPanel.Visible = true;

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
        <div id="searchPanel" runat="server">
            <label for="operator_id">
                Operator id</label>
            <asp:TextBox ID="txtOperator_id" runat="server" Text="39"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        </div>
        <div id="resultPanel" runat="server" visible="false">
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
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
