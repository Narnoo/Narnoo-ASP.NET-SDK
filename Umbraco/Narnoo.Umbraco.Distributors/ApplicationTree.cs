using Narnoo.Umbraco.Distributors.Narnoo.Distributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco;
using umbraco.businesslogic;
using umbraco.BusinessLogic.Actions;
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
            //this.
            //actions.Clear();
        }

        protected override void CreateRootNode(ref XmlTreeNode rootNode)
        {
            rootNode.NodeType = "init" + this.TreeAlias;
            rootNode.NodeID = "init";
            rootNode.Menu.Clear();
        }

        public override void Render(ref XmlTree tree)
        {
            tree.Clear();
            var operators = XmlTreeNode.Create(this);
            operators.NodeID = "operators";
            operators.Text = "Operators";
            operators.Icon = "member.gif";
            operators.Action = "javascript:openOperators()";
    
            operators.Menu.Clear();
            operators.Menu.Add(ActionAddOperator.Instance);
            tree.Add(operators);



            var operatorMedia = XmlTreeNode.Create(this);
            operatorMedia.NodeID = "operatorMedia";
            operatorMedia.Text = "Operator Media";
            operatorMedia.Icon = "node_icons_media.png";
            operatorMedia.Action = "javascript:openOperatorMedia()";
            operatorMedia.Menu.Clear();
            tree.Add(operatorMedia);

            var albums = XmlTreeNode.Create(this);
            albums.NodeID = "albums";
            albums.Text = "Albums";
            albums.Icon = "node_icons_album.png";
            albums.Action = "javascript:openAlbums()";
            albums.Menu.Clear();
            albums.Menu.Add(ActionAddAlbum.Instance);
            tree.Add(albums);

            var images = XmlTreeNode.Create(this);
            images.NodeID = "images";
            images.Text = "Images";
            images.Icon = "node_icons_images.png";
            images.Action = "javascript:openImages()";
            images.Menu.Clear();
            tree.Add(images);

            var brochures = XmlTreeNode.Create(this);
            brochures.NodeID = "brochures";
            brochures.Text = "Brochures";
            brochures.Icon = "node_icons_brochures.png";
            brochures.Action = "javascript:openBrochures()";
            brochures.Menu.Clear();
            tree.Add(brochures);

            var channels = XmlTreeNode.Create(this);
            channels.NodeID = "channels";
            channels.Text = "Channels";
            channels.Icon = "node_icons_channel.png";
            channels.Action = "javascript:openChannels()";
            channels.Menu.Clear();
            channels.Menu.Add(ActionAddChannel.Instance);
            tree.Add(channels);

            var videos = XmlTreeNode.Create(this);
            videos.NodeID = "videos";
            videos.Text = "Videos";
            videos.Icon = "mediaMovie.gif";
            videos.Action = "javascript:openVideos()";
            videos.Menu.Clear();
            tree.Add(videos);

            var searchMedia = XmlTreeNode.Create(this);
            searchMedia.NodeID = "searchMedia";
            searchMedia.Text = "Search Media";
            searchMedia.Icon = "search.png";
            searchMedia.Action = "javascript:openSearchMedia()";
            searchMedia.Menu.Clear();
            tree.Add(searchMedia);

            var searchOperatorMedia = XmlTreeNode.Create(this);
            searchOperatorMedia.NodeID = "searchOperatorMedia";
            searchOperatorMedia.Text = "Search Operator Media";
            searchOperatorMedia.Icon = "search.png";
            searchOperatorMedia.Action = "javascript:openSearchOperatorMedia()";
            searchOperatorMedia.Menu.Clear();
            tree.Add(searchOperatorMedia);

            var settings = XmlTreeNode.Create(this);
            settings.NodeID = "settings";
            settings.Text = "Settings";
            settings.Icon = "node_icons_settings.png";
            settings.Action = "javascript:openSettings()";
            settings.Menu.Clear();
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
                                id = $('#channels a').data('channel-id');
                                name = $('#channels a').data('channel-name');
                                var url = '/Umbraco/narnoo/distributors/Channels.aspx';
                                if(id){
                                    url = url +'?channel_id='+id+'&channel_name='+name ;
                                    $('#channels a').data('channel-id',null).data('channel-name',null);
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
