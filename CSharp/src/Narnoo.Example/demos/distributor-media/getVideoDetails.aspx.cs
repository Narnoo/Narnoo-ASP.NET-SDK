using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class getVideoDetails : DistributorMediaNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override Label MessageBox
        {
            get
            {
                return this.lblMessage;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string videoId = this.txtVideoId.Text;


            try
            {
                var item = this.NarnooRequest.GetVideoDetails(videoId);
                
                this.searchPanel.Visible = false;
                this.resultPanel.Visible = true;

                this.lblVideo_id.Text = item.video_id;
                this.lblEntry_date.Text = item.entry_date;
                this.lblVideo_caption.Text = item.video_caption;
                this.lblVideo_language.Text = item.video_language;
                this.lblVideo_pause_image_path.Text = item.video_pause_image_path;
                this.lblVideo_preview_path.Text = item.video_preview_path;
                this.lblVideo_webm_path.Text = item.video_webm_path;
                this.lblVideo_stream_path.Text = item.video_stream_path;
                this.lblVideo_hqstream_path.Text = item.video_hqstream_path;
                this.lblVideo_thumb_image_path.Text = item.video_thumb_image_path;
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}