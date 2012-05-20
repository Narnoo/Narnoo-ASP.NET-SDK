<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="downloadImage.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.downloadImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's Download Image</h2>
    <p>
        Distributors use this downloadImage function to download the highest resolution
        image file. *only available to approved Distributors</p>
    <pre class="code" lang="csharp">
    string image_id = this.txtImage_id.Text;

    try
    {
        var request = new DistributorMediaNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        var item = request.DownloadImage(image_id);

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
        this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode + "</br> ErrorMessage:" + ex.Error.errorMessage;
    }

    
	</pre>
    <div id="demo-frame">
        <label for="image_id">
            image_id</label>
        <asp:TextBox ID="txtImage_id" runat="server" Text="212"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblDownload_image_link" runat="server">
   
        </asp:Label>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
