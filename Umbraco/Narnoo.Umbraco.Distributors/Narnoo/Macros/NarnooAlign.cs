using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using umbraco.interfaces;

namespace Narnoo.Umbraco.Distributors.Narnoo.Macros
{
    public class NarnooAlign : RadioButtonList, IMacroGuiRendering
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.Items.Count == 0)
            {
                this.Items.Add(new ListItem("none", "none"));
                this.Items.Add(new ListItem("left", "left"));
                this.Items.Add(new ListItem("center", "center"));
                this.Items.Add(new ListItem("right", "right"));
            }
        }

        #region IMacroGuiRendering Members

        public bool ShowCaption
        {
            get { return true; }
        }

        public string Value
        {
            get
            {
                return this.SelectedValue;
            }
            set
            {
                this.SelectedValue = value;
            }
        }

        #endregion
    }
}