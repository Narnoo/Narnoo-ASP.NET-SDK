<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getDetails.aspx.cs" Inherits="Narnoo.Example.demos.distributor.getDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Get Distributor's account information - getDetails</h2>
    <p>
        This function is used to retrieve Distributor's account info.</p>
    <pre class="code" lang="csharp">
try
{
    var item = this.NarnooRequest.getDetails();
    this.lbldistributor_id.Text = item.distributor_id;
    this.lbldistributor_businessname.Text = item.distributor_businessname;
    this.lbldistributor_contactname.Text = item.distributor_contactname;
    this.lblcountry_name.Text = item.country_name;
    this.lblstate.Text = item.state;
    this.lblsuburb.Text = item.suburb;
    this.lblphone.Text = item.phone;
    this.lblurl.Text = item.url;
    this.lblemail.Text = item.email;
    this.lblpostcode.Text = item.postcode;
    this.lblimage_limit.Text = item.image_limit;
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <dl>
            <dt>distributor_id</dt>
            <dd>
                <asp:Literal ID="lbldistributor_id" runat="server"></asp:Literal></dd>
            <dt>distributor_businessname</dt>
            <dd>
                <asp:Literal ID="lbldistributor_businessname" runat="server"></asp:Literal></dd>
            <dt>distributor_contactname</dt>
            <dd>
                <asp:Literal ID="lbldistributor_contactname" runat="server"></asp:Literal></dd>
            <dt>country_name</dt>
            <dd>
                <asp:Literal ID="lblcountry_name" runat="server"></asp:Literal></dd>
            <dt>state</dt>
            <dd>
                <asp:Literal ID="lblstate" runat="server"></asp:Literal></dd>
            <dt>suburb</dt>
            <dd>
                <asp:Literal ID="lblsuburb" runat="server"></asp:Literal></dd>
            <dt>phone</dt>
            <dd>
                <asp:Literal ID="lblphone" runat="server"></asp:Literal></dd>
            <dt>url</dt>
            <dd>
                <asp:Literal ID="lblurl" runat="server"></asp:Literal></dd>
            <dt>email</dt>
            <dd>
                <asp:Literal ID="lblemail" runat="server"></asp:Literal></dd>
            <dt>postcode</dt>
            <dd>
                <asp:Literal ID="lblpostcode" runat="server"></asp:Literal></dd>
            <dt>image_limit</dt>
            <dd>
                <asp:Literal ID="lblimage_limit" runat="server"></asp:Literal></dd>
        </dl>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
