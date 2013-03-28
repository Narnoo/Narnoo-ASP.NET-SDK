<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoDialog.Master" AutoEventWireup="true" CodeBehind="DownloadFiles.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.DownloadFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <span id="lblTitle" runat="server"></span>

    <asp:Repeater ID="rptItems" runat="server">
        <HeaderTemplate>
            <ol class="tasks">
        </HeaderTemplate>

        <ItemTemplate>
            <li data-itemid="<%# Eval("ItemId")  %>" data-operator-id="<%# Eval("OperatorId") %>">
                <img src="/umbraco/narnoo/distributors/icons/icons_process.gif" />
                <span>Item ID: <%# Eval("ItemId")  %>...</span><span style="display: none;"><strong>Success!. <a href="#" target="_blank">Download</a></strong></span>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ol>

        </FooterTemplate>
    </asp:Repeater>

    <span id="lblSuccess"></span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">


    <script type="text/javascript">
        $(function () {
            var linkBuilderUrl = '/umbraco/narnoo/distributors/linkbuilder.ashx?data=<%= this.Page.Request["data"] %>';
            $('.tasks li').each(function () {

                var download = function (item) {
                    return function () {
                        var url = linkBuilderUrl + '&id=' + $(item).data('itemid') + '&operator_id=' + $(item).data('operator-id');
                        $.ajax({
                            dataType: "json",
                            url: url,
                            success: function (link) {
                                if (typeof (link.Error) == 'undefined') {
                                    $(item).find('img').attr('src', "/umbraco/narnoo/distributors/icons/icons_process_success.png").parent().attr('data-status', 'success');
                                    $(item).find('span:last').show().find('a').attr('href', link);
                                } else {
                                    $(item).find('img').attr('src', "/umbraco/narnoo/distributors/icons/icons_process_failure.png").parent().attr('data-status', 'failure');
                                    $(item).find('span:last').show().html('<strong>' + link.Error + '</strong>');
                                }
                            },
                            error: function (err) {
                                $(item).find('img').attr('src', "/umbraco/narnoo/distributors/icons/icons_process_failure.png").parent().attr('data-status', 'failure');
                                $(item).find('span:last').show().html('<strong>' + err.responseText + '</strong>');
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

                    }
                }($(this));

                download();
            });
        });

    </script>
</asp:Content>
