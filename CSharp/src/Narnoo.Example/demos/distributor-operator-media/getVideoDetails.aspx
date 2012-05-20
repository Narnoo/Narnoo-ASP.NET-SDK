<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getVideoDetails.aspx.cs" Inherits="Narnoo.Example.demos.distributor_operator_media.getVideoDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get an Opeartor's single video details</h2>
    <p>
        Distributors use this function to retrieve Operator's single video information</p>
    <pre class="code" lang="csharp">
try
{
    var request = new DistributorOperatorMediaNarnooRequest();
    request.SetAuth(this.appkey, this.secretkey);
    var list = request.GetVideoDetails(operator_id, video_id);

    this.rptList.DataSource = list;
    this.rptList.DataBind();

}
catch (InvalidNarnooRequestException ex)
{
    this.lblMessage.Visible = true;
    this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode
        + "</br> ErrorMessage:" + ex.Error.errorMessage;
}
	</pre>
    <div id="demo-frame">
        <label for="operator_id">
            Operator id</label>
        <asp:TextBox ID="txtOperator_id" runat="server" Text="39"></asp:TextBox>
        <label for="operator_id">
            video id</label>
        <asp:TextBox ID="txtVideo_id" runat="server" Text="413"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>video_id :
                    <%# Eval("video_id")%></li>
                <li>entry_date :
                    <%# Eval("entry_date")%></li>
                <li>video_thumb_image_path :
                    <%# Eval("video_thumb_image_path")%></li>
                <li>video_pause_image_path :
                    <%# Eval("video_pause_image_path")%></li>
                <li>video_preview_path :
                    <%# Eval("video_preview_path")%></li>
                <li>video_stream_path :
                    <%# Eval("video_stream_path")%></li>
                <li>video_caption :
                    <%# Eval("video_caption")%></li>
                <li>video_language :
                    <%# Eval("video_language")%></li>
                </ul></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
