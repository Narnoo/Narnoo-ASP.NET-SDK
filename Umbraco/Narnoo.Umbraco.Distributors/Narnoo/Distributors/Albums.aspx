<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.Albums" %>

<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.uicontrols" Assembly="controls" %>
<%@ Register TagPrefix="UmbracoControls" Namespace="umbraco.controls" Assembly="umbraco" %>

<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="Loading.ascx" TagName="Loading" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <link href="narnoo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <UmbracoControls:TabView ID="TabViewDetails" runat="server" Width="552px" Height="692px" />

    <asp:Panel ID="tabAlbums" runat="server">

        <div id="toobarAlbums" runat="server">
            <h4>Currently viewing album:<span>
                <asp:Literal ID="lblCurrentAlbumName" runat="server"></asp:Literal></span>
            </h4>
            <span>selected album:
                <asp:DropDownList ID="ddlAlbumsPageIndex" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="ddlAlbums" runat="server" DataValueField="album_id" DataTextField="album_name" ClientIDMode="Static"></asp:DropDownList><asp:Button ID="btnChangeAlbums" runat="server" Text="Go" />
            </span>
        </div>

        <uc1:Pager ID="pagerAlbumImages" runat="server" />


        <asp:Repeater ID="rptAlbumImages" runat="server">
            <HeaderTemplate>
                <table class="narnoo-table">
                    <thead>
                        <tr>
                            <th class="check-column">
                                <input name="selected" type="checkbox"></th>
                            <th>Thumbnail</th>
                            <th>Caption</th>
                            <th>Entry Date</th>
                            <th>Image ID</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="check-column" data-itemid="<%# Eval("image_id") %>">
                        <input type="checkbox" name="selected_album_image" value="<%# Eval("image_id") %>" /></td>
                    <td>
                        <img src="<%# Eval("thumb_image_path") %>">
                    </td>
                    <td><%# Eval("image_caption") %></td>
                    <td><%# Eval("entry_date") %></td>
                    <td><%# Eval("image_id") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="odd" data-itemid="<%# Eval("image_id") %>">
                    <td class="check-column">
                        <input type="checkbox" name="selected_album_image" value="<%# Eval("image_id") %>" /></td>
                    <td>
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

            var downloadUrl = '/umbraco/narnoo/distributors/downloadfiles.aspx?';

             $('#btnDownloadAlbumImage').click(function (e) {
                 e.preventDefault();
                 var ids = [];
                 $('input[name="selected_album_image"]:checked').each(function () {
                     ids.push($(this).val());
                 });
                 if (ids.length == 0) {
                     alert('please select some images first.');
                     return false;
                 }
                 UmbClientMgr.openModalWindow(downloadUrl + '&data=dist_image&title=image' + (ids.length > 1 ? '(s)' : '') + '&ids=' + ids.join(','), 'Download images from [' + encodeURI($.trim($('#body_toobarAlbums h4 span').text())) + ']', true, 800, 600);
                 return false;
             });

             var removeImageDialogUrl = '/umbraco/narnoo/distributors/RemoveImageDialog.aspx?';
             $('#btnRemoveFromAlbum').click(function (e) {
                 e.preventDefault();
                 var ids = [];
                 $('input[name="selected_album_image"]:checked').each(function () {
                     ids.push($(this).val());
                 });
                 if (ids.length == 0) {
                     alert('please select some images first.');
                     return false;
                 }
                 var album_name = encodeURI($.trim($('#body_toobarAlbums h4 span').text()));
                 var album_id = encodeURI($('#ddlAlbums').val());
                 UmbClientMgr.openModalWindow(removeImageDialogUrl + 'album_name=' + album_name + '&album_id=' + album_id + '&ids=' + ids.join(','), 'Remove images from [' + album_name + ']', true, 800, 600);
                 return false;
             });
         });
    </script>
</asp:Content>
