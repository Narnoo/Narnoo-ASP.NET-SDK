<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getProductTextWords.aspx.cs" Inherits="Narnoo.Example.demos.Operator.getProductTextWords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Get Operator's Text - getProductTextWords</h2>
    <p>
        Operators' use the Get Product Text Words function to retrieve their own product
        descriptions.</p>
    <pre class="code" lang="csharp">
try
{
    var item = this.NarnooRequest.GetProductTextWords(product_title);

    this.resultPanel.Visible = true;
    this.lblProduct_title.Text = item.product_title;
    this.lblWord_50.Text = item.text.word_50;
    this.lblWord_100.Text = item.text.word_100;
    this.lblWord_150.Text = item.text.word_150;
}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <label for="product_title">
            product_title</label>
        <asp:TextBox ID="txtProduct_title" runat="server" Text="Narnoo Platform"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <dl id="resultPanel" runat="server" visible="false">
            <dt>product_title</dt><dd><asp:Literal ID="lblProduct_title" runat="server"></asp:Literal>
            </dd>
            <dt></dt>
            <dd>
                <ul>
                    <li>word_50:
                        <asp:Literal ID="lblWord_50" runat="server"></asp:Literal>
                    </li>
                    <li>word_100:
                        <asp:Literal ID="lblWord_100" runat="server"></asp:Literal></li>
                    <li>word_150:
                        <asp:Literal ID="lblWord_150" runat="server"></asp:Literal></li>
                </ul>
            </dd>
        </dl>
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
