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
    public partial class Channels : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack ==false)
            {
           

                var channels = this.NarnooMediaRequest.GetChannelList();

                BindChannels(channels);

                this.ddlChannelPager.SelectedIndexChanged += ddlChannelPager_SelectedIndexChanged;
                this.ddlChannelPager.Items.Clear();
                for (var i = 0; i < channels.TotalPages; i++)
                {
                    this.ddlChannelPager.Items.Add(string.Format("Channel page {0}", i + 1));
                }
           

                if (string.IsNullOrWhiteSpace(this.Request["channel_id"]))
                {
               
                    this.lblCurrentChannelName.Text = this.ddlChannels.SelectedItem.Text;
                    this.lblChannelId.Value = this.ddlChannels.SelectedItem.Value;
                    this.ddlChannelPager.SelectedIndex = 0;
                }
                else
                {
                    this.lblCurrentChannelName.Text = this.Request["channel_name"];
                    this.lblChannelId.Value = this.Request["channel_id"];
                    this.ddlChannels.Items.FindByValue(this.Request["channel_id"]).Selected = true;
                }

                this.BindVideos(1);
            }
        }


        

        void ddlChannelPager_SelectedIndexChanged(object sender, EventArgs e)
        {
            var channels = this.NarnooMediaRequest.GetChannelList(this.ddlChannelPager.SelectedIndex + 1);
            this.BindChannels(channels);
        }

        private void BindChannels(NarnooCollection<Channel> channels)
        {
            this.ddlChannels.DataTextField = "channel_name";
            this.ddlChannels.DataValueField = "channel_id";
            this.ddlChannels.DataSource = channels;
            this.ddlChannels.DataBind();
        }


        public TabPage dataTab;
        public ImageButton btnDownloadVideos;
        public ImageButton btnRemoveFromChannel;
        protected override void OnInit(EventArgs e)
        {
            dataTab = this.TabViewDetails.NewTabPage("Videos");
            dataTab.Controls.Add(this.tabVideos);

            btnDownloadVideos = dataTab.Menu.NewImageButton();
            btnDownloadVideos.ID = "btnDownloadVideos";
            btnDownloadVideos.AlternateText = "Download";
            btnDownloadVideos.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnDownloadVideos.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownloadVideos.ValidationGroup = "";

            btnRemoveFromChannel = dataTab.Menu.NewImageButton();
            btnRemoveFromChannel.ID = "btnRemoveFromChannel";
            btnRemoveFromChannel.AlternateText = "Remove from channel";
            btnRemoveFromChannel.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnRemoveFromChannel.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_remove_from_channel.png";
            btnRemoveFromChannel.ValidationGroup = "";


            this.pagerVideos.PageIndexChanged += pagerVideos_PageIndexChanged;


            this.btnChangeChannel.Click += btnChangeChannel_Click;
        }

        void btnChangeChannel_Click(object sender, EventArgs e)
        {
            this.lblChannelId.Value = this.ddlChannels.SelectedValue;
            this.lblCurrentChannelName.Text = this.ddlChannels.SelectedItem.Text;

            this.BindVideos(1);
        }

        private void BindVideos(int pageIndex)
        {

            try
            {
                var videos = this.NarnooMediaRequest.GetChannelVideos(this.lblCurrentChannelName.Text, pageIndex);

                this.rptVideos.Visible = true;
                this.rptVideos.DataSource = videos;
                this.rptVideos.DataBind();     
                this.pagerVideos.DataBind(pageIndex, videos.TotalPages, videos.Count);
            }
            catch (Exception ex)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                this.rptVideos.DataSource = Enumerable.Empty<ChannelVideo>();
                this.rptVideos.DataBind();
                this.pagerVideos.Visible = false;
            }


        }

        void pagerVideos_PageIndexChanged(int newPageIndex)
        {
            this.BindVideos(newPageIndex);
        }
    }
}