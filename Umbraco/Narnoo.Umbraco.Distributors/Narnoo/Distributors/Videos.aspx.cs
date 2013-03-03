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
    public partial class Videos : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                this.BindVideos(1);
            }
        }

        public TabPage dataTab;
        public ImageButton btnDownloadVideos;
        public ImageButton btnAddToChannel;
        protected override void OnInit(EventArgs e)
        {
            dataTab = this.TabViewDetails.NewTabPage("Videos");
            dataTab.Controls.Add(this.tabVideos);

            btnDownloadVideos = dataTab.Menu.NewImageButton();
            btnDownloadVideos.ID = "btnDownloadVideos";
            btnDownloadVideos.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnDownloadVideos.AlternateText = "Download";
            btnDownloadVideos.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownloadVideos.ValidationGroup = "";

            btnAddToChannel = dataTab.Menu.NewImageButton();
            btnAddToChannel.ID = "btnAddToChannel";
            btnAddToChannel.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnAddToChannel.AlternateText = "AddToChannel";
            btnAddToChannel.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_add_to_channel.png";
            btnAddToChannel.ValidationGroup = "";

            this.pagerVideos.PageIndexChanged += pagerVideos_PageIndexChanged;
        }

        private void BindVideos(int pageIndex)
        {

            try
            {
                var videos = this.NarnooMediaRequest.GetVideos(pageIndex);

                this.rptVideos.Visible = true;
                this.rptVideos.DataSource = videos;
                this.rptVideos.DataBind();
                this.pagerVideos.DataBind(pageIndex, videos.TotalPages, videos.Count);
                this.pagerVideos.Visible = true;

            }
            catch (Exception ex)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                this.rptVideos.DataSource = Enumerable.Empty<Video>();
                this.rptVideos.DataBind();
            }

        }

        void pagerVideos_PageIndexChanged(int newPageIndex)
        {
            this.BindVideos(newPageIndex);
        }
    }
}