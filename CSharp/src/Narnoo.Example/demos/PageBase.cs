using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos
{
    public abstract class PageBase:Page
    {



        protected bool Sandbox
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["sandbox"] == "true";
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            this.MessageBox.Visible = false;
            base.OnLoad(e);
        }
        
        protected abstract Label MessageBox { get; }




        protected void ShowMessage(string message)
        {
            this.MessageBox.Visible = true;
            this.MessageBox.Text = message;
        }
    }
}