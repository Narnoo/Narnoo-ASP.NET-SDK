<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="addOperator.aspx.cs" Inherits="Narnoo.Example.demos.distributor.addOperator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's can add Opeartors</h2>
    <p>
        Distributors use this function to add Operator's to their access list</p>
    <pre class="code" lang="csharp">

try
{
    this.NarnooRequest.AddOperator(operatorId);
    this.lblMessage.Text = "Success";
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
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
