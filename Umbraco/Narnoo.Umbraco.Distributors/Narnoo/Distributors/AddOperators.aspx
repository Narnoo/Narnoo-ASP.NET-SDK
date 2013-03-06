<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoDialog.Master" AutoEventWireup="true" CodeBehind="AddOperators.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.AddOperators" %>

<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.uicontrols" Assembly="controls" %>
<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.controls" Assembly="umbraco" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="narnoo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <UmbracoControls:TabView ID="TabViewDetails" runat="server" Width="552px" Height="692px" />

    <asp:Panel ID="tabOperators" runat="server">
        <p>
            <label for="add_operators_list">Enter IDs of operators to add (separate each ID by a comma e.g. <code>12, 13</code>):</label>
            <asp:TextBox ID="txtAddOperatorIds" ClientIDMode="Static" runat="server"></asp:TextBox>
        </p>
        <p class="narnoo-box">
            <span>Or search for operators using the form below:</span><br>
            <label for="search_country">country:</label>
            <asp:TextBox ID="search_country" runat="server"></asp:TextBox><br>
            <label for="search_category">category:</label>
            <asp:TextBox ID="search_category" runat="server"></asp:TextBox><br>
            <label for="search_subcategory">subcategory:</label>
            <asp:TextBox ID="search_subcategory" runat="server"></asp:TextBox><br>
            <label for="search_state">state:</label>
            <asp:TextBox ID="search_state" runat="server"></asp:TextBox><br>
            <label for="search_suburb">suburb:</label>
            <asp:TextBox ID="search_suburb" runat="server"></asp:TextBox><br>
            <label for="search_postal_code">postal_code:</label>
            <asp:TextBox ID="search_postal_code" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="search" />
        </p>
        <uc1:Pager ID="Pager1" runat="server" />
        <asp:Repeater ID="rptOperators" runat="server">
            <HeaderTemplate>
                <table class="narnoo-table">
                    <thead>
                        <tr>
                            <th class="check-column" style="">
                                <input type="checkbox" /></th>
                            <th>Business</th>
                            <th>ID</th>
                            <th>Category</th>
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
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="check-column">
                        <input type="checkbox" name="selected" value="<%# Eval("operator_id") %>" />
                    </td>
                    <td><%# Eval("operator_businessname") %>
                    </td>
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
                <tr class="odd">
                    <td class="check-column">
                        <input type="checkbox" name="selected" value="<%# Eval("operator_id") %>" />
                    </td>
                    <td><%# Eval("operator_businessname") %>
                    </td>
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

            <FooterTemplate>
                </tbody>
            </table>
            </FooterTemplate>

        </asp:Repeater>

    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        $(function () {

            var dialogUrl = '/umbraco/narnoo/distributors/AddOperatorsDialog.aspx?';

            $('#btnAdd').click(function (e) {
                var ids = [],i=0;
                e.preventDefault();
               
                $('input[name="selected"]:checked').each(function () {
                    ids.push($(this).val());
                });

                var items = $('#txtAddOperatorIds').val().split(',');
                for (i = 0; i < items.length; i++) {
                    var item = $.trim(items[i]);
                    if (item.length > 0) {
                        ids.push(items[i]);
                    }
                }

                if (ids.length == 0) {
                    alert('please select some operators first.');
                    return false;
                }

                UmbClientMgr.openModalWindow(dialogUrl + '&ids=' + ids.join(','), 'Add operators', true, 600, 400);
                return false;

            });
        });

    </script>
</asp:Content>
