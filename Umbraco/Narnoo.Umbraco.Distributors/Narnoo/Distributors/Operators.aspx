<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="Operators.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.Operators" %>

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
        <uc1:Pager ID="Pager1" runat="server" />
        <div style="padding-top: 10px; padding-bottom: 10px;">
            <table class="narnoo-table">
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
                                    <input type="checkbox" name="selected" value="<%# Eval("operator_id") %>" /></td>
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
                            <tr class="odd">
                                <td class="check-column">
                                    <input type="checkbox"  name="selected" value="<%# Eval("operator_id") %>" /></td>
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
        $(function () {
            $('.narnoo-table .check-column:first input').click(function () {
                if ($(this).is(':checked')) {
                    $('.narnoo-table tbody .check-column input').attr('checked', true);
                } else {
                    $('.narnoo-table tbody .check-column input').removeAttr('checked');
                }
            });

            function getSelected() {
                return $('.narnoo-table input[name="selected"]:checked');
            }

            $('#btnDelete').click(function (e) {
                var selected = getSelected();
                if (selected.size() == 0) {
                    e.preventDefault();
                    alert('please select some operators first!');
                    return false;
                }
            });

            $('#btnMedia').click(function (e) {
                e.preventDefault();
                var selected = getSelected();
                if (selected.size() != 1) {
                    alert('please select one operator!');
                } else {
                   // parent.openOperatorMedia(selected.val());
                  //  parent.jQuery('#JTree .clicked').removeClass('clicked');
                  //  parent.jQuery('#operatorMedia a').addClass('clicked');
                    parent.jQuery('#operatorMedia a').data('operatorid', selected.val()).trigger('click');
                }

                return false;
            });
        });

    </script>
</asp:Content>
