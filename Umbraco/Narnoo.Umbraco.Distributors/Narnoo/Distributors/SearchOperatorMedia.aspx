<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="SearchOperatorMedia.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.SearchOperatorMedia" %>

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

    <asp:Panel ID="tabSearch" runat="server">

        <p class="narnoo-box">
            <span>Search for media using the form below:</span><br>
            <label for="search_media_type">media_type</label>
            <asp:DropDownList ID="search_media_type" runat="server" ClientIDMode="Static">
                <asp:ListItem Value="image" Selected="True" Text="image"></asp:ListItem>
                <asp:ListItem Value="brochure" Text="brochure"></asp:ListItem>
                <asp:ListItem Value="video" Text="video"></asp:ListItem>
            </asp:DropDownList>
            <br>
            <label for="search_business_name">business_name:</label>
            <input id="search_business_name" name="search_business_name" type="text" value="" runat="server"><br>
            <label for="search_country">country:</label>
            <input id="search_country" name="search_country" type="text" value="" runat="server"><br>
            <label for="search_state">state:</label>
            <input id="search_state" name="search_state" type="text" value="" runat="server"><br>
            <label for="search_category">category:</label>
            <input id="search_category" name="search_category" type="text" value="" runat="server" /><br>
            <label for="search_subcategory">subcategory:</label>
            <input id="search_subcategory" name="search_subcategory" type="text" value="" runat="server"><br>
            <label for="search_suburb">suburb:</label>
            <input id="search_suburb" name="search_suburb" type="text" value="" runat="server"><br>
            <label for="search_location">location:</label>
            <input id="search_location" name="search_location" type="text" value="" runat="server"><br>
            <label for="search_postal_code">postal_code:</label>
            <input id="search_postal_code" name="search_postal_code" type="text" value="" runat="server"><br>
            <label for="search_latitude">latitude:</label>
            <input id="search_latitude" name="search_latitude" type="text" value="" runat="server"><br>
            <label for="search_longitude">longitude:</label>
            <input id="search_longitude" name="search_longitude" type="text" value="" runat="server"><br>
            <label for="search_keywords">keywords:</label>
            <input id="search_keywords" name="search_keywords" type="text" value="" runat="server">

            <asp:Button ID="btnSearch" runat="server" Text="search" />
        </p>

        <uc1:Pager ID="Pager1" runat="server" />



        <asp:Repeater ID="rptMedia" runat="server">
            <HeaderTemplate>
                <table class="narnoo-table">
                    <thead>
                        <tr>
                            <th class="check-column" style="">
                                <input type="checkbox" /></th>
                            <th>Thumbnail</th>
                            <% if (this.IsImage)
                               { %>
                            <th>Owner</th>
                            <%} %>
                            <th>Caption</th>
                            <th>Entry Date</th>
                            <th>Media ID</th>
                            <th>Operator ID</th>
                        </tr>

                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="check-column">
                        <input type="checkbox" name="selected" data-operator-id="<%# Eval("operator_id") %>" value="<%# Eval("media_id") %>" />
                    </td>
                    <td>
                        <img src="<%# Eval("thumb_image_path") %>" />
                    </td>
                    <%# this.IsImage? "<td>"+Eval("media_owner_business_name")+"</td>":""  %>
                    <td><%# Eval("caption") %></td>
                    <td><%# Eval("entry_date") %></td>
                    <td><%# Eval("media_id") %></td>
                    <td><%# Eval("operator_id") %></td>
                </tr>

            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="odd">
                    <td class="check-column">
                        <input type="checkbox" name="selected" value="<%# Eval("media_id") %>" data-operator-id="<%# Eval("operator_id") %>" />
                    </td>
                    <td>
                        <img src="<%# Eval("thumb_image_path") %>" />
                    </td>
                    <%# this.IsImage? "<td>"+Eval("media_owner_business_name")+"</td>":""  %>
                    <td><%# Eval("caption") %></td>
                    <td><%# Eval("entry_date") %></td>
                    <td><%# Eval("media_id") %></td>
                    <td><%# Eval("operator_id") %></td>
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
            $('.narnoo-table').each(function () {
                $(this).find('.check-column:first input').click(function () {
                    if ($(this).is(':checked')) {
                        $(this).parentsUntil('table').parent().find('tbody .check-column input').attr('checked', true);
                    } else {
                        $(this).parentsUntil('table').parent().find('tbody .check-column input').removeAttr('checked');
                    }
                });
            });

            var downloadUrl = '/umbraco/narnoo/distributors/downloadfiles.aspx?operator_id=<%=this.Request["id"] %>';


            $('#btnDownload').click(function (e) {
                e.preventDefault();
                var ids = [];
                var operatorIds = [];
                $('input[name="selected"]:checked').each(function () {
                    ids.push($(this).val());
                    operatorIds.push($(this).data('operator-id'));
                });
                if (ids.length == 0) {
                    alert('please select some ' + $('#search_media_type').val() + ' first.');
                    return false;
                }


                UmbClientMgr.openModalWindow(downloadUrl + '&data=dist_operator_<%= this.search_media_type.SelectedValue %>&title=<%= this.search_media_type.SelectedValue %>' + (ids.length > 1 ? '(s)' : '') + '&ids=' + ids.join(',') + '&operatorIds=' + operatorIds.join(','), 'Download <%= this.search_media_type.SelectedValue %>(s)', true, 800, 600);
                return false;
            });


        });


    </script>
</asp:Content>
