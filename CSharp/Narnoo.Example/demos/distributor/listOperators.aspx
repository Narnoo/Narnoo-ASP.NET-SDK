<%@ Page Title="" Language="C#" MasterPageFile="~/demos/Demo.Master" AutoEventWireup="true"
    CodeBehind="listOperators.aspx.cs" Inherits="Narnoo.Example.demos.distributor.listOperators" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Distributor's can list Opeartors</h2>
    <p>
        Distributors use this function to list the details of Operator on their access list</p>
    <pre class="code" lang="php">	
	$request = new DistributorNarnooRequest ();
	$request->setAuth ( app_key, secret_key );
	$message = $request->listOperators();
    
	</pre>
    <div id="demo-frame">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <ul>
                        <li>operator_id :
                            <%# Eval("operator_id")%>
                        </li>
                        <li>category :
                            <%# Eval("category")%></li>
                        <li>sub_category :
                            <%# Eval("sub_category")%></li>
                        <li>operator_businessname :
                            <%# Eval("operator_businessname")%></li>
                        <li>country_name :
                            <%# Eval("country_name")%></li>
                        <li>state :
                            <%# Eval("state")%></li>
                        <li>suburb :
                            <%# Eval("suburb")%></li>
                        <li>latitude :
                            <%# Eval("latitude")%></li>
                        <li>longitude :
                            <%# Eval("longitude")%></li>
                        <li>postcode :
                            <%# Eval("postcode")%></li>
                        <li>keywords :
                            <%# Eval("keywords")%></li>
                    </ul>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
        <%--			foreach ( $message->operators as $item ) {
				$business = $item->operator;
				echo '<li><ul>';
				echo '<li>operator_id : ' . $business->operator_id . '</li>';
				echo '<li>category : ' . $business->category . '</li>';
				echo '<li>sub_category : ' . $business->sub_category . '</li>';
				echo '<li>operator_businessname : ' . $business->operator_businessname . '</li>';
				echo '<li>country_name : ' . $business->country_name . '</li>';
				echo '<li>state : ' . $business->state . '</li>';
				echo '<li>suburb : ' . $business->suburb . '</li>';
				echo '<li>latitude : ' . $business->latitude . '</li>';
				echo '<li>longitude : ' . $business->longitude . '</li>';
				echo '<li>postcode : ' . $business->postcode . '</li>';
				echo '<li>keywords : ' . $business->keywords . '</li>';
				echo '</ul></li>';
			}
			
--%>
    </div>
</asp:Content>
