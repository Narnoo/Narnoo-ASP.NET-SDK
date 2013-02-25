<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoDialog.Master" AutoEventWireup="true" CodeBehind="DownloadFiles.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.DownloadFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
    <span id="lblTitle" runat="server"></span>

    <asp:Repeater ID="rptItems" runat="server">
        <HeaderTemplate>
            <ol class="tasks">
        </HeaderTemplate>

        <ItemTemplate>
            <li data-itemid="<%# Container.DataItem  %>">
                <img src="/umbraco/narnoo/distributors/icons/icons_process.gif" />
                <span>Item ID: <%# Container.DataItem %>...</span><span style="display: none;"><strong>Success!. <a href="#" target="_blank">Download</a></strong></span>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ol>

        </FooterTemplate>
    </asp:Repeater>

    <span id="lblSuccess"></span>

    <script type="text/javascript">
        $(function () {
            var linkBuilderUrl = '/umbraco/narnoo/distributors/linkbuilder.ashx?data=<%= this.Page.Request["data"] %>&operator_id=<%= this.Page.Request["operator_id"] %>';
            $('.tasks li').each(function () {

                var download = function (item) {
                    return function () {
                        var url = linkBuilderUrl + '&id=' + $(item).data('itemid');
                        $.ajax({
                            dataType: "json",
                            url: url,
                            success: function (link) {
                                $(item).find('img').attr('src', "/umbraco/narnoo/distributors/icons/icons_process_success.png").attr('data-status', 'success');
                                $(item).find('span:last').show().find('a').attr('href', link);
                            },
                            error: function () {
                                $(item).find('img').attr('src', "/umbraco/narnoo/distributors/icons/icons_process_failure.png");
                            }, complete: function () {
                                window.setTimeout(function () {
                                    var done = $('.tasks li img[data-status="success"]').size();
                                    var max = $('.tasks li').size();
                                    var messsage = done + ' of ' + max + ' item(s) successful.';

                                    if (done < max) {
                                        $('#lblSuccess').show().html('<strong>Processing... ' + messsage + '</strong>')
                                    } else {
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
