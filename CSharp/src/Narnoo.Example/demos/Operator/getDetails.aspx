<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getDetails.aspx.cs" Inherits="Narnoo.Example.demos.Operator.getDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Get Operator's account information - getDetails</h2>
    <p>
        This function is used to retrieve Operator’s account info.</p>
    <pre class="code" lang="csharp">
try
{
    var item = this.NarnooRequest.getDetails();
    this.lbloperator_id.Text = item.operator_id;
    this.lbloperator_url.Text = item.operator_url;
    this.lbloperator_username.Text = item.operator_username;
    this.lbloperator_businessname.Text = item.operator_businessname;
    this.lbloperator_contactname.Text = item.operator_contactname;
    this.lblcountry_name.Text = item.country_name;
    this.lblstate.Text = item.state;
    this.lblsuburb.Text = item.suburb;
    this.lblphone.Text = item.phone;
    this.lblemail.Text = item.email;
    this.lblpostcode.Text = item.postcode;
    this.lbltotal_images.Text = item.total_images.ToString();
    this.lbltotal_brochures.Text = item.total_brochures.ToString();
    this.lbltotal_products.Text = item.total_products.ToString();
    this.lbltotal_videos.Text = item.total_videos.ToString();
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <dl>
            <dt>operator_id</dt>
            <dd>
                <asp:Label ID="lbloperator_id" runat="server"></asp:Label></dd>
            <dt>operator_url</dt>
            <dd>
                <asp:Label ID="lbloperator_url" runat="server"></asp:Label></dd>
            <dt>operator_username</dt>
            <dd>
                <asp:Label ID="lbloperator_username" runat="server"></asp:Label></dd>
            <dt>operator_businessname</dt>
            <dd>
                <asp:Label ID="lbloperator_businessname" runat="server"></asp:Label></dd>
            <dt>operator_contactname</dt>
            <dd>
                <asp:Label ID="lbloperator_contactname" runat="server"></asp:Label></dd>
            <dt>country_name</dt>
            <dd>
                <asp:Label ID="lblcountry_name" runat="server"></asp:Label></dd>
            <dt>state</dt>
            <dd>
                <asp:Label ID="lblstate" runat="server"></asp:Label></dd>
            <dt>suburb</dt>
            <dd>
                <asp:Label ID="lblsuburb" runat="server"></asp:Label></dd>
            <dt>phone</dt>
            <dd>
                <asp:Label ID="lblphone" runat="server"></asp:Label></dd>
            <dt>email</dt>
            <dd>
                <asp:Label ID="lblemail" runat="server"></asp:Label></dd>
            <dt>postcode</dt>
            <dd>
                <asp:Label ID="lblpostcode" runat="server"></asp:Label></dd>
            <dt>Total Images</dt>
            <dd>
                <asp:Label ID="lbltotal_images" runat="server"></asp:Label></dd>
            <dt>Total Brochures</dt>
            <dd>
                <asp:Label ID="lbltotal_brochures" runat="server"></asp:Label></dd>
            <dt>Total Videos</dt>
            <dd>
                <asp:Label ID="lbltotal_videos" runat="server"></asp:Label></dd>
            <dt>Total Products</dt>
            <dd>
                <asp:Label ID="lbltotal_products" runat="server"></asp:Label></dd>
        </dl>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
