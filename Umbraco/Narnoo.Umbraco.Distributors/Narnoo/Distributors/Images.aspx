<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="Images.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.Images" %>

<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.uicontrols" Assembly="controls" %>
<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.controls" Assembly="umbraco" %>

<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="Loading.ascx" TagName="Loading" TagPrefix="uc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="narnoo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <UmbracoControls:TabView ID="TabViewDetails" runat="server" Width="552px" Height="692px" />
    <asp:Panel ID="tabImages" runat="server">

        <uc1:Pager ID="pagerImages" runat="server" />


        <asp:Repeater ID="rptImages" runat="server">
            <HeaderTemplate>
                <table class="narnoo-table">
                    <thead>
                        <tr>
                            <th class="check-column">
                                <input type="checkbox"></th>
                            <th>Thumbnail</th>
                            <th>Caption</th>
                            <th>Entry Date</th>
                            <th>Image ID</th>
                        </tr>
                    </thead>

                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr data-itemid="<%# Eval("image_id") %>">
                    <th class="check-column">
                        <input type="checkbox" name="selected_image" value="<%# Eval("image_id") %>"></th>
                    <td class="column-thumbnail_image">
                        <img src="<%# Eval("thumb_image_path") %>">
                    </td>
                    <td><%# Eval("image_caption") %></td>
                    <td><%# Eval("entry_date") %></td>
                    <td><%# Eval("image_id") %></td>
                </tr>

            </ItemTemplate>
            <AlternatingItemTemplate>

                <tr class="odd" data-itemid="<%# Eval("image_id") %>">
                    <th class="check-column">
                        <input type="checkbox" name="selected_image" value="<%# Eval("image_id") %>"></th>
                    <td class="column-thumbnail_image">
                        <img src="<%# Eval("thumb_image_path") %>">
                    </td>

                    <td><%# Eval("image_caption") %></td>
                    <td><%# Eval("entry_date") %></td>
                    <td><%# Eval("image_id") %></td>
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


            $('#btnDownloadImage').click(function (e) {
                e.preventDefault();
                var ids = [];
                $('input[name="selected_image"]:checked').each(function () {
                    ids.push($(this).val());
                });
                if (ids.length == 0) {
                    alert('please select some images first.');
                    return false;
                }
                UmbClientMgr.openModalWindow(downloadUrl + '&data=dist_image&title=image' + (ids.length > 1 ? '(s)' : '') + '&ids=' + ids.join(','), 'Download images', true, 800, 600);
                return false;
            });

            var addImageDialogUrl = '/umbraco/narnoo/distributors/AddImagesDialog.aspx?';
            $('#btnAddToAlbum').click(function (e) {
                e.preventDefault();
                var ids = [];
                $('input[name="selected_image"]:checked').each(function () {
                    ids.push($(this).val());
                });
                if (ids.length == 0) {
                    alert('please select some images first.');
                    return false;
                }
       
                UmbClientMgr.openModalWindow(addImageDialogUrl + 'ids=' + ids.join(','), 'Add images', true, 800, 600);
                return false;
            });

            var deleteImagesDialogUrl = '/umbraco/narnoo/distributors/DeleteImagesDialog.aspx?';

            $('#btnDeleteImage').click(function (e) {
                e.preventDefault();
                var ids = [];
                $('input[name="selected_image"]:checked').each(function () {
                    ids.push($(this).val());
                });
                if (ids.length == 0) {
                    alert('please select some images first.');
                    return false;
                }

                UmbClientMgr.openModalWindow(deleteImagesDialogUrl + 'ids=' + ids.join(','), 'Delete images', true, 800, 600);
                return false;
            });
        });


    </script>
</asp:Content>
