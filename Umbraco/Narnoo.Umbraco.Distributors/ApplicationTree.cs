﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.businesslogic;
using umbraco.cms.presentation.Trees;
using umbraco.interfaces;

namespace Narnoo.Umbraco.Distributors
{
    [Tree("narnoo", "narnoo.distributors", "Narnoo")]
    public class ApplicationTree : BaseTree
    {
        public ApplicationTree(string application)
            : base(application)
        {

        }


        protected override void CreateRootNode(ref XmlTreeNode rootNode)
        {
            rootNode.Icon = FolderIcon;//"narnoo.png"

            rootNode.OpenIcon = FolderIconOpen;

            rootNode.NodeType = TreeAlias;

            rootNode.NodeID = "init";

        }

        public override void Render(ref XmlTree tree)
        {
            var operators = XmlTreeNode.Create(this);
            operators.Text = "Operators";
            operators.Icon = "member.gif";
            operators.Action = "javascript:openOperators()";
            tree.Add(operators);


            var operatorMedia = XmlTreeNode.Create(this);
            operatorMedia.Text = "Operator Media";
            operatorMedia.Icon = "docPic.gif";
            operatorMedia.Action = "javascript:openOperatorMedia()";
            tree.Add(operatorMedia);

            var albums = XmlTreeNode.Create(this);
            albums.Text = "Albums";
            albums.Icon = "mediaPhoto.gif";
            albums.Action = "javascript:openAlbums()";
            tree.Add(albums);

            var images = XmlTreeNode.Create(this);
            images.Text = "Images";
            images.Icon = "mediaPhoto.gif";
            images.Action = "javascript:openImages()";
            tree.Add(images);

            var brochures = XmlTreeNode.Create(this);
            brochures.Text = "Brochures";
            brochures.Icon = "mediaPhoto.gif";
            brochures.Action = "javascript:openBrochures()";
            tree.Add(brochures);

            var channels = XmlTreeNode.Create(this);
            channels.Text = "Channels";
            channels.Icon = "mediaFile.gif";
            channels.Action = "javascript:openChannels()";
            tree.Add(channels);

            var videos = XmlTreeNode.Create(this);
            videos.Text = "Videos";
            videos.Icon = "mediaMovie.gif";
            videos.Action = "javascript:openVideos()";
            tree.Add(videos);

            var searchMedia = XmlTreeNode.Create(this);
            searchMedia.Text = "Search Media";
            searchMedia.Icon = "search.png";
            searchMedia.Action = "javascript:openSearchMedia()";
            tree.Add(searchMedia);

            var searchOperatorMedia = XmlTreeNode.Create(this);
            searchOperatorMedia.Text = "Search Operator Media";
            searchOperatorMedia.Icon = "search.png";
            searchOperatorMedia.Action = "javascript:openSearchOperatorMedia()";
            tree.Add(searchOperatorMedia);

            var settings = XmlTreeNode.Create(this);
            settings.Text = "Settings";
            settings.Icon = "settingDatatype.gif";
            settings.Action = "javascript:openSettings()";
            tree.Add(settings);
        }

        public override void RenderJS(ref StringBuilder Javascript)
        {
            Javascript.Append(@"
                            function openOperators() {
                                parent.right.document.location.href = 'narnoo/distributors/Operators.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openOperatorMedia() {
                                parent.right.document.location.href = 'narnoo/distributors/OperatorMedia.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openAlbums() {
                                parent.right.document.location.href = 'narnoo/distributors/Albums.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openImages() {
                                parent.right.document.location.href = 'narnoo/distributors/Images.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openBrochures() {
                                parent.right.document.location.href = 'narnoo/distributors/Brochures.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openChannels() {
                                parent.right.document.location.href = 'narnoo/distributors/Channels.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openVideos() {
                                parent.right.document.location.href = 'narnoo/distributors/Videos.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openSearchMedia() {
                                parent.right.document.location.href = 'narnoo/distributors/SearchMedia.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openSearchOperatorMedia() {
                                parent.right.document.location.href = 'narnoo/distributors/SearchOperatorMedia.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openSettings() {
                                parent.right.document.location.href = 'narnoo/Settings.aspx';
                            }
            			");
        }
    }
}
