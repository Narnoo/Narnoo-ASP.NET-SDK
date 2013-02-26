﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco;
using umbraco.businesslogic;
using umbraco.cms.presentation.Trees;
using umbraco.interfaces;

namespace Narnoo.Umbraco.Distributors
{
    [Tree("narnoo", "narnoo.distributors", "Narnoo", ".sprTreeFolder", ".sprTreeFolder_o", "", false, true, 0)]
    public class ApplicationTree : BaseTree
    {
        public ApplicationTree(string application)
            : base(application)
        {

        }

        protected override void CreateAllowedActions(ref List<IAction> actions)
        {
            actions.Clear();
        }

        protected override void CreateRootNode(ref XmlTreeNode rootNode)
        {
            rootNode.NodeType = "init" + this.TreeAlias;
            rootNode.NodeID = "init";
        }

        public override void Render(ref XmlTree tree)
        {
            tree.Clear();
            var operators = XmlTreeNode.Create(this);
            operators.NodeID = "operators";
            operators.Text = "Operators";
            operators.Icon = "member.gif";
            operators.Action = "javascript:openOperators()";
            tree.Add(operators);


            //XmlTreeNode xmlTreeNode = XmlTreeNode.Create(this);
            //xmlTreeNode.Menu.Clear();
            //xmlTreeNode.NodeID = task.Id.ToString();
            //xmlTreeNode.Text = task.Node.Text;
            //xmlTreeNode.Action = "javascript:openTranslationTask(" + task.Id.ToString() + ")";
            //xmlTreeNode.Icon = ".sprTreeSettingLanguage";
            //xmlTreeNode.OpenIcon = ".sprTreeSettingLanguage";
            //this.OnBeforeNodeRender(ref tree, ref xmlTreeNode, System.EventArgs.Empty);
            //if (xmlTreeNode != null)
            //{
            //    tree.Add(xmlTreeNode);
            //    this.OnAfterNodeRender(ref tree, ref xmlTreeNode, System.EventArgs.Empty);
            //}

            var operatorMedia = XmlTreeNode.Create(this);
            operatorMedia.NodeID = "operatorMedia";
            operatorMedia.Text = "Operator Media";
            operatorMedia.Icon = "node_icons_media.png";
            operatorMedia.Action = "javascript:openOperatorMedia()";
            tree.Add(operatorMedia);

            var albums = XmlTreeNode.Create(this);
            albums.NodeID = "albums";
            albums.Text = "Albums";
            albums.Icon = "node_icons_album.png";
            albums.Action = "javascript:openAlbums()";
            tree.Add(albums);

            var images = XmlTreeNode.Create(this);
            images.NodeID = "images";
            images.Text = "Images";
            images.Icon = "node_icons_images.png";
            images.Action = "javascript:openImages()";
            tree.Add(images);

            var brochures = XmlTreeNode.Create(this);
            brochures.NodeID = "brochures";
            brochures.Text = "Brochures";
            brochures.Icon = "node_icons_brochures.png";
            brochures.Action = "javascript:openBrochures()";
            tree.Add(brochures);

            var channels = XmlTreeNode.Create(this);
            channels.NodeID = "channels";
            channels.Text = "Channels";
            channels.Icon = "node_icons_channel.png";
            channels.Action = "javascript:openChannels()";
            tree.Add(channels);

            var videos = XmlTreeNode.Create(this);
            videos.NodeID = "videos";
            videos.Text = "Videos";
            videos.Icon = "mediaMovie.gif";
            videos.Action = "javascript:openVideos()";
            tree.Add(videos);

            var searchMedia = XmlTreeNode.Create(this);
            searchMedia.NodeID = "searchMedia";
            searchMedia.Text = "Search Media";
            searchMedia.Icon = "search.png";
            searchMedia.Action = "javascript:openSearchMedia()";
            tree.Add(searchMedia);

            var searchOperatorMedia = XmlTreeNode.Create(this);
            searchOperatorMedia.NodeID = "searchOperatorMedia";
            searchOperatorMedia.Text = "Search Operator Media";
            searchOperatorMedia.Icon = "search.png";
            searchOperatorMedia.Action = "javascript:openSearchOperatorMedia()";
            tree.Add(searchOperatorMedia);

            var settings = XmlTreeNode.Create(this);
            settings.NodeID = "settings";
            settings.Text = "Settings";
            settings.Icon = "node_icons_settings.png";
            settings.Action = "javascript:openSettings()";
            tree.Add(settings);
        }

        public override void RenderJS(ref StringBuilder Javascript)
        {
            Javascript.Append(@"
                            function openOperators() {
                                parent.right.document.location.href = '/Umbraco/narnoo/distributors/Operators.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openOperatorMedia() {
                                id = $('#operatorMedia a').data('operatorid');
                                var url = '/Umbraco/narnoo/distributors/OperatorMedia.aspx';
                                if(id){
                                    url = url +'?id='+id;
                                    $('#operatorMedia a').data('operatorid',null);
                                }
                                parent.right.document.location.href = url;
                            }
            			");

            Javascript.Append(@"
                            function openAlbums() {
                                parent.right.document.location.href = '/Umbraco/narnoo/distributors/Albums.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openImages() {
                                parent.right.document.location.href = '/Umbraco/narnoo/distributors/Images.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openBrochures() {
                                parent.right.document.location.href = '/Umbraco/narnoo/distributors/Brochures.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openChannels() {
                                id = $('#channels a').data('channelid');
                                var url = '/Umbraco/narnoo/distributors/Channels.aspx';
                                if(id){
                                    url = url +'?id='+id;
                                    $('#operatorMedia a').data('channelid',null);
                                }
                                parent.right.document.location.href = url;
                            }
            			");

            Javascript.Append(@"
                            function openVideos() {
                                parent.right.document.location.href = '/Umbraco/narnoo/distributors/Videos.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openSearchMedia() {
                                parent.right.document.location.href = '/Umbraco/narnoo/distributors/SearchMedia.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openSearchOperatorMedia() {
                                parent.right.document.location.href = '/Umbraco/narnoo/distributors/SearchOperatorMedia.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openSettings() {
                                parent.right.document.location.href = '/Umbraco/narnoo/distributors/Settings.aspx';
                            }
            			");
        }
    }
}
