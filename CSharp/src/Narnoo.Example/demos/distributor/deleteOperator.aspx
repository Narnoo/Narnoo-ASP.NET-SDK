<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="deleteOperator.aspx.cs" Inherits="Narnoo.Example.demos.distributor.deleteOperator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's can delete Opeartors</h2>
    <p>
        Distributors use this function to remove Operator's from their access list</p>
    <pre class="code" lang="csharp">
	string operatorId = this.txtOperatorId.Text;

    try
    {

        var request = new DistributorNarnooRequest();
        request.SetAuth(this.appkey, this.secretkey);
        var result = request.DeleteOperator(operatorId);
        if (result)
        {
            this.lblMessage.Text = "Success";
        }
        else
        {
            this.lblMessage.Text = "Failed";
        }
    }
    catch (InvalidNarnooRequestException ex)
    {
        this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode + "</br> ErrorMessage:" + ex.Error.errorMessage;
    }
	</pre>
    <div id="demo-frame">
       <div id="demoForm" runat="server">
            <label for="operator">
                Operator id</label>
            <asp:TextBox ID="txtOperatorId" runat="server"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        </div>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
