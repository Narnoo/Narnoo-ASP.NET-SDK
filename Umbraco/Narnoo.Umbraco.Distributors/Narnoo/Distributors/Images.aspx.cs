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
    public partial class Images : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                this.BindImages(1);
            }
        }

        public TabPage dataTab;
        public ImageButton btnDownloadImage;

        protected override void OnInit(EventArgs e)
        {
            dataTab = this.TabViewDetails.NewTabPage("Images");
            dataTab.Controls.Add(this.tabImages);

            //Create a save button from the current datatab.
            btnDownloadImage = dataTab.Menu.NewImageButton();
            btnDownloadImage.ID = "btnDownloadImage";
            btnDownloadImage.AlternateText = "Download";
            btnDownloadImage.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnDownloadImage.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownloadImage.ValidationGroup = "";

            this.pagerImages.PageIndexChanged += pagerImages_PageIndexChanged;

        }

        private void BindImages(int pageIndex)
        {
            try
            {
                var images = this.NarnooMediaRequest.GetImages(pageIndex);
                this.rptImages.Visible = true;
                this.rptImages.DataSource = images;
                this.rptImages.DataBind();
                this.pagerImages.DataBind(pageIndex, images.TotalPages, images.Count);
                this.pagerImages.Visible = true;

            }
            catch (Exception ex)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                this.rptImages.DataSource = Enumerable.Empty<Image>();
                this.rptImages.DataBind();
            }

        }

        void pagerImages_PageIndexChanged(int newPageIndex)
        {
            this.BindImages(newPageIndex);
        }
    }
}