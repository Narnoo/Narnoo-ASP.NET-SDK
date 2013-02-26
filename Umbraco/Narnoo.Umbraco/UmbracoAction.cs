using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.interfaces;

namespace Narnoo.Umbraco
{
    public class UmbracoAction:IAction
    {
        public string Alias
        {
            get;
            set;
        }

        public bool CanBePermissionAssigned
        {
            get;
            set;
        }

        public string Icon
        {
            get;
            set;
        }

        public string JsFunctionName
        {
            get;
            set;
        }

        public string JsSource
        {
            get;
            set;
        }

        public char Letter
        {
            get;
            set;
        }

        public bool ShowInNotifier
        {
            get;
            set;
        }
    }
}