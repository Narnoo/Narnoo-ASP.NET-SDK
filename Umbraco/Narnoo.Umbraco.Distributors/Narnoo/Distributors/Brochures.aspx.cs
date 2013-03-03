using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco;
using umbraco.uicontrols;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class Brochures : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                this.BindBrochures(1);
            }
        }

        public TabPage dataTab;
        public ImageButton btnDownloadBrochures;
        protected override void OnInit(EventArgs e)
        {
            dataTab = this.TabViewDetails.NewTabPage("Brochures");
            dataTab.Controls.Add(this.tabBrochures);

            //Create a save button from the current datatab.
            btnDownloadBrochures = dataTab.Menu.NewImageButton();
            btnDownloadBrochures.ID = "btnDownloadBrochures";
            btnDownloadBrochures.AlternateText = "Download";
            btnDownloadBrochures.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnDownloadBrochures.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownloadBrochures.ValidationGroup = "";


            this.pagerBrochures.PageIndexChanged += pagerBrochures_PageIndexChanged;
        }

        private void BindBrochures(int pageIndex)
        {
          
                try
                {
                    var brochures = this.NarnooMediaRequest.GetBrochures(pageIndex);
                    this.rptBrochures.Visible = true;

                    this.rptBrochures.DataSource = brochures;
                    this.rptBrochures.DataBind();
                    this.pagerBrochures.DataBind(pageIndex, brochures.TotalPages, brochures.Count);
           
                    this.pagerBrochures.Visible = true;

                }
                catch (Exception ex)
                {
                    this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                    this.rptBrochures.DataSource = Enumerable.Empty<Brochure>();
                    this.rptBrochures.DataBind();
                }
               
            
        }

        void pagerBrochures_PageIndexChanged(int newPageIndex)
        {
            this.BindBrochures(newPageIndex);
        }
    }
}