<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getDistributors.aspx.cs" Inherits="Narnoo.Example.demos.Operator.getDistributors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Get distributors - getDistributors</h2>
    <p>
        Operators' use the GetDistributors function to retrieve all reachable distributors.</p>
    <pre class="code" lang="csharp">
try
{
    var list = this.NarnooRequest.getDistributors();

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
                        <li>business_name :
                            <%# Eval("business_name")%></li>
                        <li>country :<%# Eval("country")%></li>
                        <li>state :
                            <%# Eval("state")%></li>
                        <li>suburb :
                            <%# Eval("suburb")%></li>
                        <li>postcode :
                            <%# Eval("postcode")%></li>
                        <li>url :
                            <%# Eval("url")%></li>
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
