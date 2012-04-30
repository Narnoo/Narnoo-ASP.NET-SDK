<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="downloadImage.aspx.cs" Inherits="Narnoo.Example.demos.distributor_operator_media.downloadImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's download Operator's Image</h2>
    <p>
        Distributors use this function to download an Operator's high resolution image</p>
    <pre class="code" lang="csharp">
    try
    {
        var request = new DistributorOperatorMediaNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        var item = request.DownloadImage(operator_id, image_id);

        if (item == null)
        {
            this.lblMessage.Visible = true;
            this.lblMessage.Text = "Image cannot found";
        }
        else
        {

            this.lblDownload_image_link.Text = item.download_image_link;

        }

    }
    catch (InvalidNarnooRequestException ex)
    {
        this.lblMessage.Visible = true;
        this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
            }
	</pre>
    <div id="demo-frame">
        <form method="post">
        <label for="operator_id">
            operator_id</label>
        <asp:TextBox ID="txtOperator_id" runat="server" Text="39"></asp:TextBox>
        <label for="image_id">
            image_id</label>
        <asp:TextBox ID="txtImage_id" runat="server" Text="295"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblDownload_image_link" runat="server"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
