﻿<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="downloadBrochure.aspx.cs" Inherits="Narnoo.Example.demos.distributor_media.downloadBrochure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's Download Brochure</h2>
    <p>
        Distributors use this downloadBrochures function to download their PDF. *only available
        to approved Distributors</p>
    <pre class="code" lang="csharp">
    string brochure_id = this.txtBrochure_id.Text;

    try
    {
        var request = new DistributorNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        var item = request.DownloadBrochure(brochure_id);

        if (item == null)
        {
            this.lblMessage.Visible = true;
            this.lblMessage.Text = "Brochure cannot found";
        }
        else
        {
                    
            this.lblDownload_brochure_to_pdf_path.Text =  HttpUtility.HtmlDecode (item.download_brochure_to_pdf_path);

        }

    }
    catch (InvalidNarnooRequestException ex)
    {
        this.lblMessage.Visible = true;
        this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
    }

</pre>
    <div id="demo-frame">
        <label for="brochure_id">
            brochure_id</label>
        <asp:TextBox ID="txtBrochure_id" Text="170" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Label ID="lblDownload_brochure_to_pdf_path" runat="server"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
