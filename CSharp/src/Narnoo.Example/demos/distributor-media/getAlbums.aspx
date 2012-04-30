<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getAlbums.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.getAlbums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Get Distributor's album names - Get Albums</h2>
    <p>
        Distributors use the Get Albums function to retrieve their list of album names.</p>
    <pre class="code" lang="csharp">
    try
    {
        var request = new DistributorMediaNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        var list = request.GetAlbums();

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
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>album_id:
                    <%# Eval("album_id ")%>
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
