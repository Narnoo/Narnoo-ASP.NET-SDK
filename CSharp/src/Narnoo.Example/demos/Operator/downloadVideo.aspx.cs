using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class downloadVideo : OperatorNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.resultPanel.Visible = false;
        
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
            string video_id = this.txtVideo_id.Text;

            try
            {
                var item = this.NarnooRequest.DownloadVideo(video_id);

                this.resultPanel.Visible = true;
                this.lblDownload_video_stream_path.Text = item.download_video_stream_path;
                this.lblOriginal_video_path.Text = item.original_video_path;
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}