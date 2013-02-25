<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="OperatorMedia.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.OperatorMedia" %>

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
                <asp:DropDownList ID="ddlAlbums" runat="server" DataValueField="album_name" DataTextField="album_name" ClientIDMode="Static"></asp:DropDownList><asp:Button ID="btnChangeAlbums" runat="server" Text="Go" />
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
                    <td class="check-column">
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
                <tr class="odd">
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

    <asp:Panel ID="tabImages" runat="server">
        <uc1:Loading ID="loadingImages" runat="server" LoadingText="images"></uc1:Loading>
        <uc1:Pager ID="pagerImages" runat="server" />


        <asp:Repeater ID="rptImages" runat="server">
            <HeaderTemplate>
                <table class="narnoo-table">
                    <thead>
                        <tr>
                            <th class="check-column">
                                <input id="Checkbox1" type="checkbox"></th>
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

                <tr class="odd">
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

    <asp:Panel ID="tabBrochures" runat="server">
        <uc1:Loading ID="loadingBrochures" runat="server" LoadingText="brochures"></uc1:Loading>
        <uc1:Pager ID="pagerBrochures" runat="server" />

        <asp:Repeater ID="rptBrochures" runat="server">
            <HeaderTemplate>
                <table class="narnoo-table">
                    <thead>
                        <tr>
                            <th class="check-column">
                                <input id="Checkbox3" type="checkbox"></th>
                            <th>Thumbnail</th>
                            <th>Caption</th>
                            <th>Entry Date</th>
                            <th>Brochure ID</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <th class="check-column">
                        <input type="checkbox" name="selected_brochure" value="<%# Eval("brochure_id") %>"></th>
                    <td class="column-thumbnail_image">
                        <img src="<%# Eval("thumb_image_path") %>">
                    </td>
                    <td><%# Eval("brochure_caption") %></td>
                    <td><%# Eval("entry_date") %></td>
                    <td><%# Eval("brochure_id") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="odd">
                    <th class="check-column">
                        <input type="checkbox" name="selected_brochure" value="<%# Eval("brochure_id") %>"></th>
                    <td class="column-thumbnail_image">
                        <img src="<%# Eval("thumb_image_path") %>">
                    </td>
                    <td><%# Eval("brochure_caption") %></td>
                    <td><%# Eval("entry_date") %></td>
                    <td><%# Eval("brochure_id") %></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>
        </asp:Repeater>

    </asp:Panel>

    <asp:Panel ID="tabVideos" runat="server">
        <uc1:Loading ID="loadingVideos" runat="server" LoadingText="videos"></uc1:Loading>
        <uc1:Pager ID="pagerVideos" runat="server" />



        <asp:Repeater ID="rptVideos" runat="server">
            <HeaderTemplate>
                <table class="narnoo-table">
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
                <tr>
                    <th class="check-column">
                        <input type="checkbox" name="selected_brochure" value="<%# Eval("video_id") %>"></th>
                    <td class="column-thumbnail_image">
                        <img src="<%# Eval("video_thumb_image_path") %>">
                    </td>
                    <td><%# Eval("video_caption") %></td>
                    <td><%# Eval("entry_date") %></td>
                    <td><%# Eval("video_id") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="odd">
                    <th class="check-column">
                        <input type="checkbox" name="selected_brochure" value="<%# Eval("video_id") %>"></th>
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

    <asp:Panel ID="tabText" runat="server">
        <uc1:Loading ID="loadingText" runat="server" LoadingText="text"></uc1:Loading>
    </asp:Panel>

    <input type="hidden" id="status_body_TabViewDetails_tab01" value="0" runat="server" clientidmode="Static" />
    <input type="hidden" id="status_body_TabViewDetails_tab02" value="0" runat="server" clientidmode="Static" />
    <input type="hidden" id="status_body_TabViewDetails_tab03" value="0" runat="server" clientidmode="Static" />
    <input type="hidden" id="status_body_TabViewDetails_tab04" value="0" runat="server" clientidmode="Static" />
    <input type="hidden" id="status_body_TabViewDetails_tab05" value="0" runat="server" clientidmode="Static" />
    <asp:Button ID="btnReloadTabView" runat="server" Text="" ClientIDMode="Static" Style="display: none;" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">

    <script type="text/javascript">
        $(function () {
            $('.narnoo-table').each(function () {
                $(this).find('.check-column:first input').click(function () {
                    if ($(this).is(':checked')) {
                        $(this).parentsUntil('table').find('tbody .check-column input').attr('checked', true);
                    } else {
                        $(this).parentsUntil('table').find('tbody .check-column input').removeAttr('checked');
                    }
                });
            });

            $('#btnDownloadAlbumImage').click(function (e) {
                e.preventDefault();
                UmbClientMgr.openModalWindow('downloadfile.aspx', 'some title', true, 800, 600);
            });

            function getActiveTag() {
                return $('#body_TabViewDetails_activetab').val();
            }

            Umbraco.Controls.TabView.onActiveTabChange(function (activeTab, options) {
                //debugger;
                if ($('#status_' + options).val() == '0') {
                    $('#btnReloadTabView').trigger('click');
                }
            });
        });
    </script>
</asp:Content>
