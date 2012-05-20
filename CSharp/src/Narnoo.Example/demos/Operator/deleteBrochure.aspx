﻿<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="deleteBrochure.aspx.cs" Inherits="Narnoo.Example.demos.Operator.deleteBrochure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Delete Operator's Brochures - deleteBrochures</h2>
    <p>
        This function used to delete brochure based on brochure id of the operator.</p>
    <pre class="code" lang="csharp">
try
{
    this.lblMessage.Visible = true;
    var request = new OperatorNarnooRequest();
    request.SetAuth(this.appkey, this.secretkey);
    this.lblMessage.Text = request.deleteBrochure(brochure_id);

}
catch (InvalidNarnooRequestException ex)
{
    this.lblMessage.Visible = true;
    this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode 
        + "</br> ErrorMessage:" + ex.Error.errorMessage;
}
	</pre>
    <div id="demo-frame">
        <label for="brochure_id">
            brochure_id</label>
        <asp:TextBox ID="txtBrochure_id" runat="server" Text="310"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
      
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
</asp:Content>
