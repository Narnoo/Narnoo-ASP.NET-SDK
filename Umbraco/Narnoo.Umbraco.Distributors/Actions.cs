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
            this.JsFunctionName = "addOperator";
            this.JsSource = string.Empty;
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
}