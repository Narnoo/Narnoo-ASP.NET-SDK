using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Narnoo.Umbraco.Distributors.Narnoo.Shortcodes
{
    public abstract class ShortcodeBase : UserControl
    {

        public bool IsDesignTime
        {
            get
            {
                return umbraco.library.RequestServerVariables("HTTP_URL").Contains("macroResultWrapper");
            }
        }
        public abstract string RenderContent();

        public abstract string RenderDesignContent();

        protected override void OnPreRender(EventArgs e)
        {
            //if (this.IsDesignTime)
            //{
            //    this.Controls.Add(new LiteralControl() { Text = this.RenderDesignContent() });
            //}
            //else
            //{
            //    this.Controls.Add(new LiteralControl() { Text = this.RenderContent() });
            //}
            base.OnPreRender(e);

        }
    }
}