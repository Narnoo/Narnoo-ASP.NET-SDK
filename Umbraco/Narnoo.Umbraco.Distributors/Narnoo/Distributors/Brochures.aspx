<%@ Page Title="" Language="C#" MasterPageFile="../../Masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="Brochures.aspx.cs" Inherits="Narnoo.Umbraco.Distributors.Narnoo.Distributors.Brochures" %>

<%@ Register TagPrefix="cc1" Namespace="umbraco.uicontrols" Assembly="controls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocType" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .widefat, div.updated, div.error, .wrap .add-new-h2, textarea, input[type="text"], input[type="password"], input[type="file"], input[type="email"], input[type="number"], input[type="search"], input[type="tel"], input[type="url"], select, .tablenav .tablenav-pages a, .tablenav-pages span.current, #titlediv #title, .postbox, #postcustomstuff table, #postcustomstuff input, #postcustomstuff textarea, .imgedit-menu div, .plugin-update-tr .update-message, #poststuff .inside .the-tagcloud, .login form, #login_error, .login .message, #menu-management .menu-edit, .nav-menus-php .list-container, .menu-item-handle, .link-to-original, .nav-menus-php .major-publishing-actions .form-invalid, .press-this #message, #TB_window, .tbtitle, .highlight, .feature-filter, #widget-list .widget-top, .editwidget .widget-inside {
            -webkit-border-radius: 3px;
            border-radius: 3px;
            border-width: 1px;
            border-style: solid;
        }

        .widefat {
            border-spacing: 0;
            width: 100%;
            clear: both;
            margin: 0;
        }

            .widefat * {
                word-wrap: break-word;
            }

            .widefat a {
                text-decoration: none;
            }

            .widefat thead th:first-of-type {
                -webkit-border-top-left-radius: 3px;
                border-top-left-radius: 3px;
            }

            .widefat thead th:last-of-type {
                -webkit-border-top-right-radius: 3px;
                border-top-right-radius: 3px;
            }

            .widefat tfoot th:first-of-type {
                -webkit-border-bottom-left-radius: 3px;
                border-bottom-left-radius: 3px;
            }

            .widefat tfoot th:last-of-type {
                -webkit-border-bottom-right-radius: 3px;
                border-bottom-right-radius: 3px;
            }

            .widefat td, .widefat th {
                border-width: 1px 0;
                border-style: solid;
            }

            .widefat tfoot th {
                border-bottom: 0;
            }

            .widefat .no-items td {
                border-bottom-width: 0;
            }

            .widefat td {
                font-size: 12px;
                padding: 4px 7px 2px;
                vertical-align: top;
            }

                .widefat td p, .widefat td ol, .widefat td ul {
                    font-size: 12px;
                }

            .widefat th {
                padding: 7px 7px 8px;
                text-align: left;
                line-height: 1.3em;
                font-size: 14px;
            }

                .widefat th input {
                    margin: 0 0 0 8px;
                    padding: 0;
                    vertical-align: text-top;
                }

            .widefat .check-column {
                width: 2.2em;
                padding: 6px 0 25px;
                vertical-align: top;
            }

            .widefat tbody th.check-column {
                padding: 9px 0 22px;
            }

            .widefat.media .check-column {
                padding-top: 8px;
            }

            .widefat thead .check-column, .widefat tfoot .check-column {
                padding: 10px 0 0;
            }

        .no-js .widefat thead .check-column input, .no-js .widefat tfoot .check-column input {
            display: none;
        }

        .widefat .num, .column-comments, .column-links, .column-posts {
            text-align: center;
        }

        .widefat th#comments {
            vertical-align: middle;
        }


        .fixed .column-comments .sorting-indicator {
            margin-top: 3px;
        }

        .widefat th.sortable, .widefat th.sorted {
            padding: 0;
        }

        th.sortable a, th.sorted a {
            display: block;
            overflow: hidden;
            padding: 7px 7px 8px;
        }

        .fixed .column-comments.sortable a, .fixed .column-comments.sorted a {
            padding: 8px 0;
        }

        th.sortable a span, th.sorted a span {
            float: left;
            cursor: pointer;
        }

        th.sorted.asc .sorting-indicator, th.desc:hover span.sorting-indicator {
            display: block;
            background-position: 0 0;
        }

        th.sorted.desc .sorting-indicator, th.asc:hover span.sorting-indicator {
            display: block;
            background-position: -7px 0;
        }
    </style>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <cc1:UmbracoPanel ID="Panel2" runat="server" Height="224px" Width="412px" hasMenu="false">
        <div style="padding: 2px 15px 0px 15px">
            <asp:PlaceHolder ID="dashBoardContent" runat="server"></asp:PlaceHolder>

            <table class="wp-list-table widefat fixed" cellspacing="0">
                <thead>
                    <tr>
                        <th scope="col" id="cb" class="manage-column column-cb check-column" style="">
                            <label class="screen-reader-text" for="cb-select-all-1">Select All</label><input id="cb-select-all-1" type="checkbox"></th>
                        <th scope="col" id="operator_businessname" class="manage-column column-operator_businessname" style="">Business</th>
                        <th scope="col" id="operator_id" class="manage-column column-operator_id" style="">ID</th>
                        <th scope="col" id="category" class="manage-column column-category" style="">Category</th>
                        <th scope="col" id="sub_category" class="manage-column column-sub_category" style="">Subcategory</th>
                        <th scope="col" id="country_name" class="manage-column column-country_name" style="">Country</th>
                        <th scope="col" id="state" class="manage-column column-state" style="">State</th>
                        <th scope="col" id="suburb" class="manage-column column-suburb" style="">Suburb</th>
                        <th scope="col" id="latitude" class="manage-column column-latitude" style="">Latitude</th>
                        <th scope="col" id="longitude" class="manage-column column-longitude" style="">Longitude</th>
                        <th scope="col" id="postcode" class="manage-column column-postcode" style="">Postcode</th>
                        <th scope="col" id="keywords" class="manage-column column-keywords" style="">Keywords</th>
                    </tr>
                </thead>

                <tfoot>
                    <tr>
                        <th scope="col" class="manage-column column-cb check-column" style="">
                            <label class="screen-reader-text" for="cb-select-all-2">Select All</label><input id="cb-select-all-2" type="checkbox"></th>
                        <th scope="col" class="manage-column column-operator_businessname" style="">Business</th>
                        <th scope="col" class="manage-column column-operator_id" style="">ID</th>
                        <th scope="col" class="manage-column column-category" style="">Category</th>
                        <th scope="col" class="manage-column column-sub_category" style="">Subcategory</th>
                        <th scope="col" class="manage-column column-country_name" style="">Country</th>
                        <th scope="col" class="manage-column column-state" style="">State</th>
                        <th scope="col" class="manage-column column-suburb" style="">Suburb</th>
                        <th scope="col" class="manage-column column-latitude" style="">Latitude</th>
                        <th scope="col" class="manage-column column-longitude" style="">Longitude</th>
                        <th scope="col" class="manage-column column-postcode" style="">Postcode</th>
                        <th scope="col" class="manage-column column-keywords" style="">Keywords</th>
                    </tr>
                </tfoot>

                <tbody id="the-list">
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="39"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Narnoo Demo" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Narnoo Demo
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=39&amp;operator_name=Narnoo Demo">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=39&amp;operator_names[]=Narnoo Demo">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=39&amp;operator_names[]=Narnoo Demo">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">39</td>
                        <td class="category column-category">Service</td>
                        <td class="sub_category column-sub_category">Online Services</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.919514</td>
                        <td class="longitude column-longitude">145.778135</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Narnoo</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="74"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Kewarra Beach Resort &amp; Spa" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Kewarra Beach Resort &amp; Spa
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=74&amp;operator_name=Kewarra Beach Resort &amp; Spa">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=74&amp;operator_names[]=Kewarra Beach Resort &amp; Spa">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=74&amp;operator_names[]=Kewarra Beach Resort &amp; Spa">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">74</td>
                        <td class="category column-category">Accommodation</td>
                        <td class="sub_category column-sub_category">Resort</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">KEWARRA BEACH</td>
                        <td class="latitude column-latitude">-16.7778423666266</td>
                        <td class="longitude column-longitude">145.683158407687</td>
                        <td class="postcode column-postcode">4879</td>
                        <td class="keywords column-keywords">Kewarra Beach Cairns Resort</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="75"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Mamu Rainforest Canopy Walkway" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Mamu Rainforest Canopy Walkway
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=75&amp;operator_name=Mamu Rainforest Canopy Walkway">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=75&amp;operator_names[]=Mamu Rainforest Canopy Walkway">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=75&amp;operator_names[]=Mamu Rainforest Canopy Walkway">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">75</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Rainforest</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">EAST PALMERSTON</td>
                        <td class="latitude column-latitude">-17.6134494542795</td>
                        <td class="longitude column-longitude">145.799045399634</td>
                        <td class="postcode column-postcode">4860</td>
                        <td class="keywords column-keywords">Rainforest Walkway Mamu</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="73"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Passions Of Paradise" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Passions Of Paradise
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=73&amp;operator_name=Passions Of Paradise">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=73&amp;operator_names[]=Passions Of Paradise">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=73&amp;operator_names[]=Passions Of Paradise">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">73</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Reef</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9218184032553</td>
                        <td class="longitude column-longitude">145.780138097931</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Diving Great Barrier Reef Snorkelling</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="99"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Hot Air" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Hot Air
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=99&amp;operator_name=Hot Air">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=99&amp;operator_names[]=Hot Air">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=99&amp;operator_names[]=Hot Air">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">99</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Hot Air Ballooning</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9233991</td>
                        <td class="longitude column-longitude">145.773851</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Hot Air Ballooning Cairns Port Douglas</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="59"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Hartley's Crocodile Adventures" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Hartley's Crocodile Adventures
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=59&amp;operator_name=Hartley's Crocodile Adventures">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=59&amp;operator_names[]=Hartley's Crocodile Adventures">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=59&amp;operator_names[]=Hartley's Crocodile Adventures">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">59</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Wildlife</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">PORT DOUGLAS</td>
                        <td class="latitude column-latitude">-16.6600771</td>
                        <td class="longitude column-longitude">145.5664269</td>
                        <td class="postcode column-postcode">4877</td>
                        <td class="keywords column-keywords">Hartley's Crocodile Adventures Wildlife Cairn</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="60"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Sanctuary Palm Cove" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Sanctuary Palm Cove
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=60&amp;operator_name=Sanctuary Palm Cove">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=60&amp;operator_names[]=Sanctuary Palm Cove">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=60&amp;operator_names[]=Sanctuary Palm Cove">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">60</td>
                        <td class="category column-category">Accommodation</td>
                        <td class="sub_category column-sub_category">Apartments</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">PALM COVE</td>
                        <td class="latitude column-latitude">-16.7413894805902</td>
                        <td class="longitude column-longitude">145.670832953967</td>
                        <td class="postcode column-postcode">4879</td>
                        <td class="keywords column-keywords">Self Contained</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="72"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Cairns Beach Resort" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Cairns Beach Resort
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=72&amp;operator_name=Cairns Beach Resort">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=72&amp;operator_names[]=Cairns Beach Resort">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=72&amp;operator_names[]=Cairns Beach Resort">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">72</td>
                        <td class="category column-category">Accommodation</td>
                        <td class="sub_category column-sub_category"></td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">HOLLOWAYS BEACH</td>
                        <td class="latitude column-latitude">-16.8387094704217</td>
                        <td class="longitude column-longitude">145.739752585983</td>
                        <td class="postcode column-postcode">4878</td>
                        <td class="keywords column-keywords">Cairns Beach Resort</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="76"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Sunlover Reef Cruises" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Sunlover Reef Cruises
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=76&amp;operator_name=Sunlover Reef Cruises">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=76&amp;operator_names[]=Sunlover Reef Cruises">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=76&amp;operator_names[]=Sunlover Reef Cruises">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">76</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Reef</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9216336456269</td>
                        <td class="longitude column-longitude">145.780245386292</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Great Barrier Reef Diving Snorkeling</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="77"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Paronella Park" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Paronella Park
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=77&amp;operator_name=Paronella Park">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=77&amp;operator_names[]=Paronella Park">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=77&amp;operator_names[]=Paronella Park">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">77</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Botanical</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">MENA CREEK</td>
                        <td class="latitude column-latitude">-17.6523528155755</td>
                        <td class="longitude column-longitude">145.956301223279</td>
                        <td class="postcode column-postcode">4871</td>
                        <td class="keywords column-keywords">Paronella Park</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="78"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="The Reef Hotel Casino" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">The Reef Hotel Casino
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=78&amp;operator_name=The Reef Hotel Casino">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=78&amp;operator_names[]=The Reef Hotel Casino">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=78&amp;operator_names[]=The Reef Hotel Casino">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">78</td>
                        <td class="category column-category">Accommodation</td>
                        <td class="sub_category column-sub_category">Hotel</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9234606853189</td>
                        <td class="longitude column-longitude">145.779387079407</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Casino Reef Cairns</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="80"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Down Under Tours" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Down Under Tours
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=80&amp;operator_name=Down Under Tours">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=80&amp;operator_names[]=Down Under Tours">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=80&amp;operator_names[]=Down Under Tours">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">80</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Coach</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">BUNGALOW</td>
                        <td class="latitude column-latitude">-16.9461374818819</td>
                        <td class="longitude column-longitude">145.766337153534</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Coach Tours Day Trips Cairns</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="79"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Poseidon Outer Reef Cruises" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Poseidon Outer Reef Cruises
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=79&amp;operator_name=Poseidon Outer Reef Cruises">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=79&amp;operator_names[]=Poseidon Outer Reef Cruises">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=79&amp;operator_names[]=Poseidon Outer Reef Cruises">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">79</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Reef</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">PORT DOUGLAS</td>
                        <td class="latitude column-latitude">-16.4827489820745</td>
                        <td class="longitude column-longitude">145.464395337296</td>
                        <td class="postcode column-postcode">4877</td>
                        <td class="keywords column-keywords">Port Douglas Reef Snorkeling Diving</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="81"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Flames Of The Forest" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Flames Of The Forest
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=81&amp;operator_name=Flames Of The Forest">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=81&amp;operator_names[]=Flames Of The Forest">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=81&amp;operator_names[]=Flames Of The Forest">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">81</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Botanical</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">PORT DOUGLAS</td>
                        <td class="latitude column-latitude">-16.4607867</td>
                        <td class="longitude column-longitude">145.3734582</td>
                        <td class="postcode column-postcode">4877</td>
                        <td class="keywords column-keywords">Flames Forest Dinner Rainforest</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="82"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Raging Thunder" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Raging Thunder
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=82&amp;operator_name=Raging Thunder">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=82&amp;operator_names[]=Raging Thunder">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=82&amp;operator_names[]=Raging Thunder">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">82</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">White Water Rafting</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9206893260289</td>
                        <td class="longitude column-longitude">145.777134023834</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Rafting Tully Cairns Raging Thunder</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="84"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Tropical Horizons Tours" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Tropical Horizons Tours
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=84&amp;operator_name=Tropical Horizons Tours">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=84&amp;operator_names[]=Tropical Horizons Tours">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=84&amp;operator_names[]=Tropical Horizons Tours">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">84</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Day Tour</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">BUNGALOW</td>
                        <td class="latitude column-latitude">-16.938575011322</td>
                        <td class="longitude column-longitude">145.766847193423</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Rainforest Tropical Horizons Tours</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="83"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Cape Trib Connections" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Cape Trib Connections
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=83&amp;operator_name=Cape Trib Connections">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=83&amp;operator_names[]=Cape Trib Connections">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=83&amp;operator_names[]=Cape Trib Connections">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">83</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Day Tour</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9226549424711</td>
                        <td class="longitude column-longitude">145.772525988747</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Daintree Rainforest Cape Tribulation</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="86"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Foaming Fury" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Foaming Fury
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=86&amp;operator_name=Foaming Fury">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=86&amp;operator_names[]=Foaming Fury">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=86&amp;operator_names[]=Foaming Fury">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">86</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">White Water Rafting</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.8692578220929</td>
                        <td class="longitude column-longitude">145.673021398712</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Barron White Water Rafting Cairns</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="85"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Adventure North Australia" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Adventure North Australia
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=85&amp;operator_name=Adventure North Australia">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=85&amp;operator_names[]=Adventure North Australia">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=85&amp;operator_names[]=Adventure North Australia">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">85</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Day Tour</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9216336456269</td>
                        <td class="longitude column-longitude">145.772348962952</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Aboriginal Tours Cooktown Chilligo</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="87"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Tropics Explorer" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Tropics Explorer
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=87&amp;operator_name=Tropics Explorer">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=87&amp;operator_names[]=Tropics Explorer">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=87&amp;operator_names[]=Tropics Explorer">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">87</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Eco Tour</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">BUNGALOW</td>
                        <td class="latitude column-latitude">-16.9386314599801</td>
                        <td class="longitude column-longitude">145.752980172816</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Daintree Rainforest Cape Tribulation</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="88"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Big Cat Green Island" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Big Cat Green Island
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=88&amp;operator_name=Big Cat Green Island">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=88&amp;operator_names[]=Big Cat Green Island">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=88&amp;operator_names[]=Big Cat Green Island">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">88</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Reef</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9218389318695</td>
                        <td class="longitude column-longitude">145.780105911423</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Green Island Reef</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="89"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Reef Magic Cruises" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Reef Magic Cruises
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=89&amp;operator_name=Reef Magic Cruises">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=89&amp;operator_names[]=Reef Magic Cruises">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=89&amp;operator_names[]=Reef Magic Cruises">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">89</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Reef</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9218184032553</td>
                        <td class="longitude column-longitude">145.780138097931</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Reef Pontoon Cairns Magic</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="90"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Tusa Dive" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Tusa Dive
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=90&amp;operator_name=Tusa Dive">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=90&amp;operator_names[]=Tusa Dive">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=90&amp;operator_names[]=Tusa Dive">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">90</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Reef</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9208330271427</td>
                        <td class="longitude column-longitude">145.777777753998</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Tusa Great Barrier Reef</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="93"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Blazing Saddles Adventures" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Blazing Saddles Adventures
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=93&amp;operator_name=Blazing Saddles Adventures">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=93&amp;operator_names[]=Blazing Saddles Adventures">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=93&amp;operator_names[]=Blazing Saddles Adventures">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">93</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">ATV Quad Bike</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9492817091778</td>
                        <td class="longitude column-longitude">145.537796797559</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">ATV Horse Riding Cairns Kuranda</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="91"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Ocean Spirit Cruises" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Ocean Spirit Cruises
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=91&amp;operator_name=Ocean Spirit Cruises">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=91&amp;operator_names[]=Ocean Spirit Cruises">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=91&amp;operator_names[]=Ocean Spirit Cruises">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">91</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Reef</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9218184032553</td>
                        <td class="longitude column-longitude">145.780138097931</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Great Barrier Reef</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="92"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Billy Tea Safaris" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Billy Tea Safaris
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=92&amp;operator_name=Billy Tea Safaris">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=92&amp;operator_names[]=Billy Tea Safaris">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=92&amp;operator_names[]=Billy Tea Safaris">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">92</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Adventure</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.9233991</td>
                        <td class="longitude column-longitude">145.773851</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Chilligo Outback Cooktown Tours</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="94"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Amaroo At Trinity" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Amaroo At Trinity
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=94&amp;operator_name=Amaroo At Trinity">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=94&amp;operator_names[]=Amaroo At Trinity">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=94&amp;operator_names[]=Amaroo At Trinity">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">94</td>
                        <td class="category column-category">Accommodation</td>
                        <td class="sub_category column-sub_category">Apartments</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">TRINITY BEACH</td>
                        <td class="latitude column-latitude">-16.7833590603087</td>
                        <td class="longitude column-longitude">145.698046551898</td>
                        <td class="postcode column-postcode">4879</td>
                        <td class="keywords column-keywords">Trinity Beach Self Contained Units</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="98"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Jungle Surfing Canopy Tours" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Jungle Surfing Canopy Tours
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=98&amp;operator_name=Jungle Surfing Canopy Tours">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=98&amp;operator_names[]=Jungle Surfing Canopy Tours">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=98&amp;operator_names[]=Jungle Surfing Canopy Tours">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">98</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Rainforest</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">PORT DOUGLAS</td>
                        <td class="latitude column-latitude">-16.087247</td>
                        <td class="longitude column-longitude">145.4625598</td>
                        <td class="postcode column-postcode">4877</td>
                        <td class="keywords column-keywords">Daintree Canopy Surfing Cape Tribulation</td>
                    </tr>
                    <tr class="alternate">
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="95"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Deep Sea Divers Den" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Deep Sea Divers Den
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=95&amp;operator_name=Deep Sea Divers Den">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=95&amp;operator_names[]=Deep Sea Divers Den">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=95&amp;operator_names[]=Deep Sea Divers Den">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">95</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Reef</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">PARRAMATTA PARK</td>
                        <td class="latitude column-latitude">-16.9231117015788</td>
                        <td class="longitude column-longitude">145.765340350796</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Diving Liveaboard Training</td>
                    </tr>
                    <tr>
                        <th scope="row" class="check-column">
                            <input class="operator-id-cb" type="checkbox" name="operators[]" value="96"><input class="operator-name-cb" type="checkbox" name="operator_names[]" value="Cairns Dive Centre" style="display: none;"></th>
                        <td class="operator_businessname column-operator_businessname">Cairns Dive Centre
                            <br>
                            <div class="row-actions"><span class="media"><a href="?page=narnoo-distributor-operator-media&amp;action=media&amp;operator_id=96&amp;operator_name=Cairns Dive Centre">Media</a> | </span><span class="import"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=import&amp;operators[]=96&amp;operator_names[]=Cairns Dive Centre">Import</a> | </span><span class="delete"><a href="?page=narnoo-distributor-operators&amp;paged=1&amp;action=delete&amp;operators[]=96&amp;operator_names[]=Cairns Dive Centre">Delete</a></span></div>
                        </td>
                        <td class="operator_id column-operator_id">96</td>
                        <td class="category column-category">Attraction</td>
                        <td class="sub_category column-sub_category">Reef</td>
                        <td class="country_name column-country_name">Australia</td>
                        <td class="state column-state">QLD</td>
                        <td class="suburb column-suburb">CAIRNS</td>
                        <td class="latitude column-latitude">-16.921099900349</td>
                        <td class="longitude column-longitude">145.776377640892</td>
                        <td class="postcode column-postcode">4870</td>
                        <td class="keywords column-keywords">Diving Liveaboard Training Great Barrier Reef</td>
                    </tr>
                </tbody>
            </table>

        </div>
    </cc1:UmbracoPanel>
    <cc1:TabView ID="dashboardTabs" Width="400px" Visible="false" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
