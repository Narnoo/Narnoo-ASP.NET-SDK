<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="searchOperators.aspx.cs" Inherits="Narnoo.Example.demos.distributor.searchOperators" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's can search Opeartors</h2>
    <p>
        Distributors use this function to search Operator's on Narnoo</p>
    <pre class="code" lang="csharp">	
    var country = this.txtCountry.Text;
    var category = this.txtCategory.Text;
    var subcategory = this.txtSubCategory.Text;
    var state = this.txtState.Text;
    var suburb = this.txtSuburb.Text;
    var postal_code = this.txtPostal_code.Text;

    try
    {
        var request = new DistributorNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        var list = request.SearchOperators(country, category, subcategory, state, suburb, postal_code);
        this.rptList.DataSource = list;
        this.rptList.DataBind();
    }
    catch (InvalidNarnooRequestException ex)
    {
        this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
    }
	</pre>
    <div id="demo-frame">
        <label for="country">
            country</label>
        <asp:TextBox ID="txtCountry" runat="server">
        </asp:TextBox>
        <br />
        <label for="category">
            category</label>
        <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
        <br />
        <label for="subcategory">
            subcategory</label>
        <asp:TextBox ID="txtSubCategory" runat="server"></asp:TextBox>
        <br />
        <label for="state">
            state</label>
        <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
        <br />
        <label for="suburb">
            suburb</label>
        <asp:TextBox ID="txtSuburb" runat="server"></asp:TextBox>
        <br />
        <label for="postal_code">
            postal_code</label>
        <asp:TextBox ID="txtPostal_code" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <ul>
                        <li>operator_id :
                            <%# Eval("operator_id")%>
                        </li>
                        <li>category :
                            <%# Eval("category")%></li>
                        <li>sub_category :
                            <%# Eval("sub_category")%></li>
                        <li>operator_businessname :
                            <%# Eval("operator_businessname")%></li>
                        <li>country_name :
                            <%# Eval("country_name")%></li>
                        <li>state :
                            <%# Eval("state")%></li>
                        <li>suburb :
                            <%# Eval("suburb")%></li>
                        <li>latitude :
                            <%# Eval("latitude")%></li>
                        <li>longitude :
                            <%# Eval("longitude")%></li>
                        <li>postcode :
                            <%# Eval("postcode")%></li>
                        <li>keywords :
                            <%# Eval("keywords")%></li>
                    </ul>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
