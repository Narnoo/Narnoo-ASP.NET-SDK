<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getAlbums.aspx.cs" Inherits="Narnoo.Example.demos.Operator.getAlbums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Get Operator's Albums - getAlbums</h2>
    <p>
        Operators' use the Get Albums function to retrieve their own album names.</p>
    <pre class="code" lang="csharp">
try
{
    var list = this.NarnooRequest.GetAlbums();

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
                <li>album_id:
                    <%# Eval("album_id")%>
                    album_name:
                    <%# Eval("album_name")%></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
