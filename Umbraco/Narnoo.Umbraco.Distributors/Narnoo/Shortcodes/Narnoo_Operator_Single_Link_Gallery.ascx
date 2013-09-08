<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Narnoo_Operator_Single_Link_Gallery.ascx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Shortcodes.Narnoo_Operator_Single_Link_Gallery" %>

<link rel='stylesheet' href='/umbraco/narnoo/scripts/imagebox/imagebox.min.css' type='text/css' media='all' />
<link rel='stylesheet' href='/umbraco/narnoo/css/Single_Link_Gallery.css' type='text/css' media='all' />

<% if (this.IsDesignTime)
   { %>
<%= this.RenderDesignContent() %>
<%}
   else
   { %>
<%= this.RenderContent() %>
<%} %>