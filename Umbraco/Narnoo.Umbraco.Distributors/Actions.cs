using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors
{
    public class ActionAddOperator:UmbracoAction
    {
        public ActionAddOperator()
        {
            this.Alias = "AddOperator";
            this.CanBePermissionAssigned = true;
            this.Icon = ".sprNew";
            this.JsFunctionName = "addOperators();";
            this.JsSource =@" function addOperators() {
                                parent.right.document.location.href = '/Umbraco/narnoo/distributors/AddOperators.aspx';
                            }";
            this.Letter = '1';
            this.ShowInNotifier = true;
        }

        private static readonly ActionAddOperator m_instance = new ActionAddOperator();
        public static ActionAddOperator Instance
        {
            get
            {
                return ActionAddOperator.m_instance;
            }
        }
    }


    public class ActionDeleteOperator : UmbracoAction
    {
        public ActionDeleteOperator()
        {
            this.Alias = "DeleteOperator";
            this.CanBePermissionAssigned = true;
            this.Icon = ".sprDelete";
            this.JsFunctionName = string.Empty;
            this.JsSource = string.Empty;
            this.Letter = '2';
            this.ShowInNotifier = true;
        }

        private static readonly ActionDeleteOperator m_instance = new ActionDeleteOperator();
        public static ActionDeleteOperator Instance
        {
            get
            {
                return ActionDeleteOperator.m_instance;
            }
        }
    }

    public class ActionAddAlbum : UmbracoAction
    {
        public ActionAddAlbum()
        {
            this.Alias = "CreateAlbum";
            this.CanBePermissionAssigned = true;
            this.Icon = ".sprNew";
            this.JsFunctionName = "createAlbum();";
            this.JsSource = @" function createAlbum() {
                                UmbClientMgr.openModalWindow('/Umbraco/narnoo/distributors/CreateAlbumDialog.aspx', 'Create album', true, 350, 200);
                            }";
            this.Letter = '3';
            this.ShowInNotifier = true;
        }

        private static readonly ActionAddAlbum m_instance = new ActionAddAlbum();
        public static ActionAddAlbum Instance
        {
            get
            {
                return ActionAddAlbum.m_instance;
            }
        }
    }


    public class ActionAddChannel : UmbracoAction
    {
        public ActionAddChannel()
        {
            this.Alias = "CreateChannel";
            this.CanBePermissionAssigned = true;
            this.Icon = ".sprNew";
            this.JsFunctionName = "createChannel();";
            this.JsSource = @" function createChannel() {
                                UmbClientMgr.openModalWindow('/Umbraco/narnoo/distributors/CreateChannelDialog.aspx', 'Create channel', true, 350, 200);
                            }";
            this.Letter = '4';
            this.ShowInNotifier = true;
        }

        private static readonly ActionAddChannel m_instance = new ActionAddChannel();
        public static ActionAddChannel Instance
        {
            get
            {
                return ActionAddChannel.m_instance;
            }
        }
    }

}