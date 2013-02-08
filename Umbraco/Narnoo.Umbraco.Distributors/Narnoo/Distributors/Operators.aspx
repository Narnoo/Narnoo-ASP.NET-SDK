<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="Operators.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.Operators" %>

<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.uicontrols" Assembly="controls" %>
<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.controls" Assembly="umbraco" %>

<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .check-column {
            padding: 9px 0 22px;
            width: 2.2em;
            vertical-align: top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <UmbracoControls:TabView ID="TabViewDetails" runat="server" Width="552px" Height="692px" />

    <asp:Panel ID="tabOperators" runat="server">
        <uc1:Pager ID="Pager1" runat="server" />
        <div style="padding-top: 10px; padding-bottom: 10px;">
            <table id="grid">
                <thead>
                    <tr>
                        <th class="check-column">
                            <input type="checkbox" />
                        </th>
                        <th>Business</th>
                        <th>ID</th>
                        <th>Category
                        </th>
                        <th>Subcategory</th>
                        <th>Country</th>
                        <th>State</th>
                        <th>Suburb</th>
                        <th>Latitude</th>
                        <th>Longitude</th>
                        <th>Postcode</th>
                        <th>Keywords</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptItems" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="check-column">
                                    <input type="checkbox" /></td>
                                <td><%# Eval("operator_businessname") %></td>
                                <td><%# Eval("operator_id") %></td>
                                <td><%# Eval("category") %></td>
                                <td><%# Eval("sub_category") %></td>
                                <td><%# Eval("country_name") %></td>
                                <td><%# Eval("state") %></td>
                                <td><%# Eval("suburb") %></td>
                                <td><%# Eval("latitude") %></td>
                                <td><%# Eval("longitude") %></td>
                                <td><%# Eval("postcode") %></td>
                                <td><%# Eval("keywords") %></td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr>
                                <td class="check-column odd">
                                    <input type="checkbox" /></td>
                                <td><%# Eval("operator_businessname") %></td>
                                <td><%# Eval("operator_id") %></td>
                                <td><%# Eval("category") %></td>
                                <td><%# Eval("sub_category") %></td>
                                <td><%# Eval("country_name") %></td>
                                <td><%# Eval("state") %></td>
                                <td><%# Eval("suburb") %></td>
                                <td><%# Eval("latitude") %></td>
                                <td><%# Eval("longitude") %></td>
                                <td><%# Eval("postcode") %></td>
                                <td><%# Eval("keywords") %></td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>


                </tbody>
                <tfoot>
                </tfoot>
            </table>
        </div>
    </asp:Panel>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">

      


    </script>
</asp:Content>
