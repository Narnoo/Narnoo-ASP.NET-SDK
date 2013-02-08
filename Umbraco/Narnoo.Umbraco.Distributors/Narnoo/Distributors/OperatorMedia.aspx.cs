using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.uicontrols;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class OperatorMedia : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public TabPage dataTab;
        protected override void OnInit(EventArgs e)
        {
            dataTab = this.TabViewDetails.NewTabPage("Albums");
            dataTab.Controls.Add(this.tabAlbums);

            dataTab = this.TabViewDetails.NewTabPage("Images");
            dataTab.Controls.Add(this.tabImages);

            dataTab = this.TabViewDetails.NewTabPage("Brochures");
            dataTab.Controls.Add(this.tabBrochures);

            dataTab = this.TabViewDetails.NewTabPage("Videos");
            dataTab.Controls.Add(this.tabVideos);

            dataTab = this.TabViewDetails.NewTabPage("Text");
            dataTab.Controls.Add(this.tabText);
            
        }
    }
}