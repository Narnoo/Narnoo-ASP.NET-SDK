using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.businesslogic;
using umbraco.cms.presentation.Trees;
using umbraco.interfaces;

namespace Narnoo.Umbraco
{
    [Tree("narnoo", "narnoodist", "Narnoo")]
    public class ApplicationTree : BaseTree
    {
        public ApplicationTree(string application)
            : base(application)
        {

        }


        protected override void CreateRootNode(ref XmlTreeNode rootNode)
        {
            rootNode.Icon = FolderIcon;

            rootNode.OpenIcon = FolderIconOpen;

            rootNode.NodeType = TreeAlias;

            rootNode.NodeID = "init";

        }

        public override void Render(ref XmlTree tree)
        {
            // Create tree node to allow sending a newsletter

            var sendNewsletter = XmlTreeNode.Create(this);

            sendNewsletter.Text = "Send Newsletter";

            sendNewsletter.Icon = "docPic.gif";

            sendNewsletter.Action = "javascript:openSendNewsletter()";

            // Add the node to the tree

            tree.Add(sendNewsletter);


            // Create tree node to allow viewing previously sent newsletters
            var previousNewsletters = XmlTreeNode.Create(this);

            previousNewsletters.Text = "Previous Newsletters";

            previousNewsletters.Icon = "docPic.gif";

            previousNewsletters.Action = "javascript:openPreviousNewsletters()";

            // Add the node to the tree
            tree.Add(previousNewsletters);

        }

        public override void RenderJS(ref StringBuilder Javascript)
        {
            Javascript.Append(@"
                            function openSendNewsletter() {
                                parent.right.document.location.href = 'newsletter/sendNewsletter.aspx';
                            }
            			");

            Javascript.Append(@"
                            function openPreviousNewsletters() {
                                parent.right.document.location.href = 'newsletter/previousNewsletters.aspx';
                            }
            			");
        }
    }
}
