using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class getChannelVideos : DistributorMediaNarnooRequestPage
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
            string channel = this.txtChannel.Text;


            try
            {
                var list = this.NarnooRequest.GetChannelVideos(channel);
                this.searchPanel.Visible = false;
                this.resultPanel.Visible = true;
                this.lblTotal.Text = list.TotalPages.ToString();
                this.rptList.DataSource = list;
                this.rptList.DataBind();
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}