<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoDialog.Master" AutoEventWireup="true" CodeBehind="ChangeOperatorDialog.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.ChangeOperatorDialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
   <link href="narnoo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h3>Currently viewing operator: <%= this.Request["id"] %>			 
    </h3>

    <p>
        Operator ID:
        <input type="text" id="operator_id" value="">
        <input type="button" id="btnChangeOperator"  value="change operator">
    </p>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#btnChangeOperator').click(function (e) {
                e.preventDefault();

                var operator = $.trim($('#operator_id').val());

                if (operator.length > 0) {
                    parent.right.document.location.href = '/Umbraco/narnoo/distributors/OperatorMedia.aspx?id=' + operator;
                    UmbClientMgr.closeModalWindow();
                } else {
                    alert('please enter an operator id first.');
                }
            });
        });

    </script>
</asp:Content>
