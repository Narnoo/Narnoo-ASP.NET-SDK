<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="deleteVideo.aspx.cs" Inherits="Narnoo.Example.demos.Operator.deleteVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Delete Operator's Videos - deleteVideo</h2>
<p>This function used to delete video based on video id of  the operator.</p>
    <pre class="code" lang="csharp">
try
{
    this.lblMessage.Visible = true;
    var request = new OperatorNarnooRequest();
    request.SetAuth(this.appkey, this.secretkey);
    this.lblMessage.Text = request.deleteVideo(video_id);
}
catch (InvalidNarnooRequestException ex)
{
    this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode 
    + "</br> ErrorMessage:" + ex.Error.errorMessage;
}
	</pre>
    <div id="demo-frame">
        <label for="video_id">
            video_id</label>
        <asp:TextBox ID="txtVideo_id" runat="server" Text="413"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />

        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
