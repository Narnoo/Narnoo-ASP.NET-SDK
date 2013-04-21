<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoDialog.Master" AutoEventWireup="true" CodeBehind="AddOperatorsDialog.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.AddOperatorsDialog" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="narnoo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <span id="lblTitle" runat="server"></span>

    <asp:Repeater ID="rptItems" runat="server">
        <HeaderTemplate>
            <ol class="tasks">
        </HeaderTemplate>

        <ItemTemplate>
            <li data-itemid="<%# Container.DataItem  %>">
                <img src="/umbraco/narnoo/distributors/icons/icons_process.gif" />
                <span>Item ID: <%# Container.DataItem %>...</span><span style="display: none;"><strong>Success!. </strong></span>
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
            var taskUrl = '/umbraco/narnoo/distributors/ProcessAddOperators.ashx?';

            $('.tasks li').each(function () {
                var task = function (item) {
                    return function () {
                        var id = item.data("itemid");
                        var url = taskUrl + 'id=' + id;
                        item.find('img').show();
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

    </script>
</asp:Content>
