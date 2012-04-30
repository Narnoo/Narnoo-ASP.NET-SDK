<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="singleOperatorDetail.aspx.cs" Inherits="Narnoo.Example.demos.distributor.singleOperatorDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's can list Operator details</h2>
    <p>
        Distributors use this function to get a single Operators' details</p>
    <pre class="code" lang="csharp">
    string operatorId = this.txtOperatorId.Text;

    try
    {
        var request = new DistributorNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        var item = request.SingleOperatorDetail(operatorId);

        if (item == null)
        {
            this.lblMessage.Visible = true;
            this.lblMessage.Text = "Operator cannot found";
        }
        else
        {
            this.detailView.Visible = true;
            this.lblCategory.Text = item.category;
            this.lblCountryName.Text = item.country_name;
            this.lblKeywords.Text = item.keywords;
            this.lblLatitude.Text = item.latitude;
            this.lblLongitude.Text = item.longitude;
            this.lblOperatorBusinessname.Text = item.operator_businessname;
            this.lblOperatorId.Text = item.operator_id;
            this.lblPostcode.Text = item.postcode;
            this.lblState.Text = item.state;
            this.lblSubCategory.Text = item.sub_category;
            this.lblSuburb.Text = item.suburb;
                    
        }
               
    }
    catch (InvalidNarnooRequestException ex)
    {
        this.lblMessage.Visible = true;
        this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
    }
    
	</pre>
    <div id="demo-frame">
        <label for="operator">
            Operator id</label>
        <asp:TextBox ID="txtOperatorId" runat="server" Text="39"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <dl runat="server" id="detailView" visible="false">
            <dt>operator_id</dt>
            <dd>
                <asp:Literal ID="lblOperatorId" runat="server"></asp:Literal></dd>
            <dt>category</dt>
            <dd>
                <asp:Literal ID="lblCategory" runat="server"></asp:Literal></dd>
            <dt>sub_category</dt>
            <dd>
                <asp:Literal ID="lblSubCategory" runat="server"></asp:Literal></dd>
            <dt>operator_businessname</dt>
            <dd>
                <asp:Literal ID="lblOperatorBusinessname" runat="server"></asp:Literal></dd>
            <dt>country_name</dt>
            <dd>
                <asp:Literal ID="lblCountryName" runat="server"></asp:Literal></dd>
            <dt>state</dt>
            <dd>
                <asp:Literal ID="lblState" runat="server"></asp:Literal></dd>
            <dt>suburb</dt>
            <dd>
                <asp:Literal ID="lblSuburb" runat="server"></asp:Literal></dd>
            <dt>latitude</dt>
            <dd>
                <asp:Literal ID="lblLatitude" runat="server"></asp:Literal></dd>
            <dt>longitude</dt>
            <dd>
                <asp:Literal ID="lblLongitude" runat="server"></asp:Literal></dd>
            <dt>postcode</dt>
            <dd>
                <asp:Literal ID="lblPostcode" runat="server"></asp:Literal></dd>
            <dt>keywords</dt>
            <dd>
                <asp:Literal ID="lblKeywords" runat="server"></asp:Literal></dd>
        </dl>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
