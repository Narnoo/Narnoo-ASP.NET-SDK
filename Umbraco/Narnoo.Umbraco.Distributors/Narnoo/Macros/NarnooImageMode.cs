using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using umbraco.interfaces;

namespace Narnoo.Umbraco.Distributors.Narnoo.Macros
{
    public class NarnooImageMode : RadioButtonList, IMacroGuiRendering
       {
           protected override void OnLoad(EventArgs e)
           {
               base.OnLoad(e);
               if (this.Items.Count == 0)
               {
                   this.Items.Add(new ListItem("thumbnail", "thumbnail"));
                   this.Items.Add(new ListItem("preview", "preview"));
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