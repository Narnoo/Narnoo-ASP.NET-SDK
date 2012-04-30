<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getProductTextWords.aspx.cs" Inherits="Narnoo.Example.demos.distributor_operator_media.getProductTextWords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get product text words</h2>
    <p>
        Distributors use this function to retrieve Operator's product information text (50/100/150)</p>
    <pre class="code" lang="php">
	$request = new DistributorOperatorMediaNarnooRequest ();
	$request->setAuth ( app_key, secret_key );
	$message = $request->getProductTextWords ( $operator_id, $product_title );
    
	</pre>
    <div id="demo-frame">
        <label for="operator_id">
            Operator id</label>
        <asp:TextBox ID="txtOperator_id" runat="server" Text="39"></asp:TextBox>
        <label for="product_title">
            product_title</label>
        <asp:TextBox ID="txtProduct_title" runat="server" Text="Narnoo Platform"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <dl id="detail" runat="server" visible="false">
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
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
