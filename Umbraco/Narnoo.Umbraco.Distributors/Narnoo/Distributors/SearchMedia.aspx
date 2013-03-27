<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="SearchMedia.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.SearchMedia" %>

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
            <label for="search_media_id">media_id:</label>
            <asp:TextBox ID="search_media_id" runat="server"></asp:TextBox>
            <br>
            <label for="search_category">category:</label>
            <asp:TextBox ID="search_category" runat="server"></asp:TextBox><br>
            <label for="search_subcategory">subcategory:</label>
            <asp:TextBox ID="search_subcategory" runat="server"></asp:TextBox><br>
            <label for="search_suburb">suburb:</label>
            <asp:TextBox ID="search_suburb" runat="server"></asp:TextBox><br>
            <label for="search_location">location:</label>
            <asp:TextBox ID="search_location" runat="server"></asp:TextBox><br>
            <label for="search_latitude">latitude:</label>
            <asp:TextBox ID="search_latitude" runat="server"></asp:TextBox><br>
            <label for="search_longitude">longitude:</label>
            <asp:TextBox ID="search_longitude" runat="server"></asp:TextBox><br>
            <%--        <label for="search_radius">radius:</label>
         <asp:TextBox ID="search_radius" runat="server"></asp:TextBox><br>
            <label for="search_privilege">privilege:</label>
            <asp:RadioButtonList ID="search_privilege_public" runat="server" RepeatLayout="Flow" CssClass="radio-list" RepeatColumns="2">
                <asp:ListItem Value="public" Text="public"></asp:ListItem>
                <asp:ListItem Value="private" Text="private"></asp:ListItem>
            </asp:RadioButtonList>
            <br />--%>
            <label for="search_keywords">keywords:</label>
            <asp:TextBox ID="search_keywords" runat="server"></asp:TextBox>

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
                        <input type="checkbox" name="selected" value="<%# Eval("media_id") %>" />
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
                        <input type="checkbox" name="selected" value="<%# Eval("media_id") %>" />
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
                 $('input[name="selected"]:checked').each(function () {
                     ids.push($(this).val());
                 });
                 if (ids.length == 0) {
                     alert('please select some ' + $('#search_media_type').val() + ' first.');
                     return false;
                 }


                 UmbClientMgr.openModalWindow(downloadUrl + '&data=dist_' + $('#search_media_type').val() + '&title=' + $('#search_media_type').val() + (ids.length > 1 ? '(s)' : '') + '&ids=' + ids.join(','), 'Download images', true, 800, 600);
                 return false;
             });


         });


    </script>
</asp:Content>
