<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoDialog.Master" AutoEventWireup="true" CodeBehind="AddToChannel.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.AddToChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h4>Confirm add to channel</h4>
    <p>
        Please select channel to add the following <%= this.SelectedIds.Length %> video(s) to:	
        <asp:DropDownList ID="ddlChannelPager" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="ddlChannels" runat="server"></asp:DropDownList>
        <asp:Repeater ID="rptItems" runat="server">
            <HeaderTemplate>
                <ol class="tasks">
            </HeaderTemplate>

            <ItemTemplate>
                <li data-itemid="<%# Container.DataItem  %>">
                    <img src="/umbraco/narnoo/distributors/icons/icons_process.gif" style="display: none;" />
                    <span>Video ID: <%# Container.DataItem %>...</span>
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
        </p>

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

        });


    </script>
</asp:Content>
