<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoDialog.Master" AutoEventWireup="true" CodeBehind="CreateAlbumDialog.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.CreateAlbumDialog" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="narnoo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h3>Create album</h3>
    <table>
        <tbody>
            <tr>
                <th>Please key in a new album name:</th>
                <td>
                    <asp:TextBox ID="txtAlbumName" runat="server"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>

    <p class="submit">
        <asp:Button ID="btnSubmit" runat="server" Text="Create" />
        <input type="submit" id="btnCancel" class="button-secondary" value="Cancel">
    </p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        $('#btnCancel').click(function (e) {
            e.preventDefault();
            UmbClientMgr.closeModalWindow();
            return false;
        });
    </script>
</asp:Content>
