<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="Videos.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.Videos" %>

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

    <asp:Panel ID="tabVideos" runat="server">

        <uc1:Pager ID="pagerVideos" runat="server" />

        <asp:Repeater ID="rptVideos" runat="server">
            <HeaderTemplate>
                <table class="narnoo-table" id="tblVideos">
                    <thead>
                        <tr>
                            <th class="check-column">
                                <input id="Checkbox5" type="checkbox"></th>
                            <th>Thumbnail</th>
                            <th>Caption</th>
                            <th>Entry Date</th>
                            <th>Video ID</th>
                        </tr>
                    </thead>
                    <tbody id="Tbody3">
            </HeaderTemplate>
            <ItemTemplate>
                <tr data-itemid="<%# Eval("video_id") %>">
                    <th class="check-column">
                        <input type="checkbox" name="selected_video" value="<%# Eval("video_id") %>"></th>
                    <td class="column-thumbnail_image">
                        <img src="<%# Eval("video_thumb_image_path") %>">
                    </td>
                    <td><%# Eval("video_caption") %></td>
                    <td><%# Eval("entry_date") %></td>
                    <td><%# Eval("video_id") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="odd" data-itemid="<%# Eval("video_id") %>">
                    <th class="check-column">
                        <input type="checkbox" name="selected_video" value="<%# Eval("video_id") %>"></th>
                    <td class="column-thumbnail_image">
                        <img src="<%# Eval("video_thumb_image_path") %>">
                    </td>
                    <td><%# Eval("video_caption") %></td>
                    <td><%# Eval("entry_date") %></td>
                    <td><%# Eval("video_id") %></td>
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


            $('#btnDownloadVideos').click(function (e) {
                e.preventDefault();
                var ids = [];
                $('input[name="selected_video"]:checked').each(function () {
                    ids.push($(this).val());
                });
                if (ids.length == 0) {
                    alert('please select some videos first.');
                    return false;
                }

                UmbClientMgr.openModalWindow(downloadUrl + '&data=dist_video&title=video' + (ids.length > 1 ? '(s)' : '') + '&ids=' + ids.join(','), 'Download videos', true, 800, 600);
                return false;
            });

            var addToChannelUrl = '/umbraco/narnoo/distributors/addToChannel.aspx?';
            $('#btnAddToChannel').click(function (e) {
                e.preventDefault();
                var ids = [];
                $('input[name="selected_video"]:checked').each(function () {
                    ids.push($(this).val());
                });
                if (ids.length == 0) {
                    alert('please select some videos first.');
                    return false;
                }

                UmbClientMgr.openModalWindow(addToChannelUrl + '&ids=' + ids.join(','), 'Add videos to channel', true, 800, 600);
                return false;
            });


            var deleteVideosDialogUrl = '/umbraco/narnoo/distributors/DeleteVideosDialog.aspx?';

            $('#btnDeleteVideo').click(function (e) {
                e.preventDefault();
                var ids = [];
                $('input[name="selected_video"]:checked').each(function () {
                    ids.push($(this).val());
                });
                if (ids.length == 0) {
                    alert('please select some videos first.');
                    return false;
                }

                UmbClientMgr.openModalWindow(deleteVideosDialogUrl + 'ids=' + ids.join(','), 'Delete videos', true, 800, 600);
                return false;
            });

        });

    </script>
</asp:Content>
