<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="deleteImage.aspx.cs" Inherits="Narnoo.Example.demos.Operator.deleteImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Delete Operators images - deleteImage</h2>
    <p>
        This function used to delete image based on image id of the operator.</p>
    <pre class="code" lang="csharp">
try
{
    this.lblMessage.Visible = true;
    var request = new OperatorNarnooRequest();
    request.SetAuth(this.appkey, this.secretkey);
    this.lblMessage.Text = request.DownloadImage(image_id);

}
catch (InvalidNarnooRequestException ex)
{
    this.lblMessage.Text = ex.Message;
    
}
	</pre>
    <div id="demo-frame">
        <label for="image_id">
            image_id</label>
        <asp:TextBox ID="txtImage_id" runat="server" Text="295"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
