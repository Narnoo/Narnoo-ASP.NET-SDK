<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoDialog.Master" AutoEventWireup="true" CodeBehind="AddToChannel.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.AddToChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
       <link href="narnoo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h4>Confirm add to channel</h4>
    <p>
        Please select channel to add the following <%= this.SelectedIds.Length %> video(s) to:	
        <asp:DropDownList ID="ddlChannelPager" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="ddlChannels" runat="server" ClientIDMode="Static"></asp:DropDownList>
        <asp:Repeater ID="rptItems" runat="server">
            <HeaderTemplate>
                <ol class="tasks">
            </HeaderTemplate>

            <ItemTemplate>
                <li data-itemid="<%# Container.DataItem  %>">
                    <img src="/umbraco/narnoo/distributors/icons/icons_process.gif" style="display: none;" />
                    <span>Video ID: <%# Container.DataItem %></span>
                    <img src="/Umbraco/Images/throbber.gif" />
                    <span style="display: none;"><strong></strong></span>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ol>

            </FooterTemplate>
        </asp:Repeater>


        <p class="submit">
            <input type="button" id="btnConfirm" class="button-secondary" value="Confirm Add to Channel">
            <input type="button" id="btnCancel" class="button-secondary" value="Cancel">
            <input type="button" id="btnView" class="button-secondary" value="View channel" style="display: none;">
        </p>

        <span id="lblSuccess"></span>

    </p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.tasks li').each(function () {
                var loadImage = function (item) {
                    return function () {
                        var id = item.data("itemid");
                        var src = window.parent.right.jQuery('#tblVideos tr[data-itemid="' + id + '"] img').attr('src');
                        var image = new Image();
                        image.onload = function () {
                            item.find('img:last').attr('src', src);
                            loadImage = null;
                        }

                        image.onerror = function () {
                            item.find('img:last').hide();
                            loadImage = null;
                        }

                        image.src = src;
                    };
                }($(this));

                loadImage();
            });


            $('#btnCancel').click(function (e) {
                e.preventDefault();
                UmbClientMgr.closeModalWindow();
                return false;
            });

            var addTochannelUrl = '/umbraco/narnoo/distributors/TryAddToChannel.ashx';
            $('#btnConfirm').click(function (e) {
                e.preventDefault();
                $('#btnCancel').hide();
                $('#btnConfirm').hide();

                var channel_id = $('#ddlChannels').val();
                $('.tasks li').each(function () {
                    var task = function (item) {
                        return function () {
                            var video_id = item.data("itemid");
                            var url = addTochannelUrl + '?channel_id=' + channel_id + '&video_id=' + video_id;
                            item.find('img:first').show();
                            item.find('img:last').hide();
                            $.ajax({
                                url: url,
                                data: 'get',
                                dataType: 'json',
                                success: function (data) {
                                    if (data.error) {
                                        $(item).find('img:first').attr('src', "/umbraco/narnoo/distributors/icons/icons_process_failure.png").parent().attr('data-status', 'failure');
                                        $(item).find('span:last').show().find('strong').text(data.error);
                                    } else {
                                        $(item).find('img:first').attr('src', "/umbraco/narnoo/distributors/icons/icons_process_success.png").parent().attr('data-status', 'success');
                                        $(item).find('span:last').show().find('strong').text('Success!');
                                    }
                                }, complete: function () {
                                    window.setTimeout(function () {
                                        var done = $('.tasks li[data-status]').size();
                                        var success = $('.tasks li[data-status="success"]').size();
                                        var max = $('.tasks li').size();
                                        var messsage = success + ' of ' + max + ' item(s) successful.';

                                        if (done < max) {
                                            $('#lblSuccess').show().html('<strong>Processing... ' + messsage + '</strong>')
                                        } else {
                                            $('#btnView').show();
                                            $('#lblSuccess').show().html('<strong>Processing completed. ' + messsage + '</strong>')
                                        }
                                    }, 500);
                                }

                            });
                        };
                    }($(this));

                    task();
                });

            });

            $('#btnView').click(function (e) {
                e.preventDefault();
                parent.jQuery('#channels a').data('channelid', $('#ddlChannels').val()).trigger('click');
                UmbClientMgr.closeModalWindow();
                return false;
            });
        });


    </script>
</asp:Content>
