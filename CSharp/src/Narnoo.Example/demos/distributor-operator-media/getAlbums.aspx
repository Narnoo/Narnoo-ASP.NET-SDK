﻿<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="getAlbums.aspx.cs" Inherits="Narnoo.Example.demos.distributor_operator_media.getAlbums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's get album names</h2>
    <p>
        Distributors use this function to retrieve Operator's album names</p>
    <pre class="code" lang="csharp">
try
{
    var list = this.NarnooRequest.GetAlbums(operator_id);

    this.searchPanel.Visible = false;
    this.resultPanel.Visible = true;

    this.lblTotal.Text = list.TotalPages.ToString();
    this.rptList.DataSource = list;
    this.rptList.DataBind();

}
catch (NarnooRequestException ex)
{
    this.ShowMessage(ex.Message);
}
	</pre>
    <div id="demo-frame">
        <div id="searchPanel" runat="server">
            <label for="operator_id">
                Operator id</label>
            <asp:TextBox ID="txtOperator_id" runat="server" Text="39"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        </div>
        <div id="resultPanel" runat="server" visible="false">
            total pages:
            <asp:Label ID="lblTotal" runat="server"></asp:Label>
        </div>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>album_id:
                    <%# Eval("album_id")%>
                    album_name:
                    <%# Eval("album_name")%></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <br />
    <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </div>
</asp:Content>
