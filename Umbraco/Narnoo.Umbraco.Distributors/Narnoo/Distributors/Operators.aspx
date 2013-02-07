<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="Operators.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.Operators" %>

<%@ Register TagPrefix="cc1" Namespace="umbraco.uicontrols" Assembly="controls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        table {
            table-layout: fixed;
            border-color: #DFDFDF;
            background-color: #F9F9F9;
            border-spacing: 0;
            width: 100%;
            clear: both;
            margin: 0;
            -webkit-border-radius: 3px;
            border-radius: 3px;
            border-width: 1px;
            border-style: solid;
        }

        .check-column {
            padding: 9px 0 22px;
            width: 2.2em;
            vertical-align: top;
        }

        .hide {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <cc1:UmbracoPanel ID="Panel2" runat="server" Height="224px" Width="412px" hasMenu="false" Text="Operators">
        <div id="pager" class="hide">
            <span data-bind="text:items().length+' items'"></span>
            <span class="pagination-links">
                <a href="#" data-page="1">«</a>
                <a href="#" data-bind="attr:{'data-page':current()-1}">‹</a>
                <span class="paging-input">
                    <input id="current" type="text" name="page_no" size="1" disabled="disabled" data-bind="value:current,attr:{size:current}">
                    of <span data-bind="text:total"></span></span>
                <a href="#" data-bind="attr:{'data-page':current()+1}">›</a>
                <a href="#" data-bind="attr:{'data-page':total}">»</a></span>
        </div>
        <div style="padding-top: 10px; padding-bottom: 10px;">
            <table id="grid" class="hide">
                <thead>
                    <tr>
                        <th class="check-column">
                            <input type="checkbox" />
                        </th>
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
                <tbody data-bind="foreach: items">

                    <tr>

                        <td class="check-column">
                            <input type="checkbox" /></td>
                        <td data-bind="text:operator_businessname "></td>
                        <td data-bind="text:operator_id"></td>
                        <td data-bind="text:category "></td>
                        <td data-bind="text:sub_category "></td>
                        <td data-bind="text:country_name "></td>
                        <td data-bind="text:state "></td>
                        <td data-bind="text:suburb "></td>
                        <td data-bind="text:latitude "></td>
                        <td data-bind="text:longitude "></td>
                        <td data-bind="text:postcode "></td>
                        <td data-bind="text:keywords "></td>
                    </tr>
                </tbody>
                <tfoot>
                </tfoot>
            </table>
        </div>
    </cc1:UmbracoPanel>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">

        $(function () {
            var viewModel = null;

            $('#pager a').click(function (e) {
                e.preventDefault();
                var index = parseInt($(this).data('page'));
                if (index > 0 && index <= $('#pager a:last').val() + 1) {
                    load(index);
                }
                return false;
            });

            function load(page_no) {
                $.getJSON('operators.ashx', { page_no: page_no }, function (data) {
                    $('#grid').removeClass('hide');
                    $('#pager').removeClass('hide');
                    viewModel = ko.mapping.fromJS(data);
                    ko.applyBindings(viewModel);
                    $('#grid tr:odd').addClass('odd');
                });
            }

            load(1);

        });


    </script>
</asp:Content>
