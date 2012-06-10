﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class getVideoDetails : DistributorPageBase
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
                var request = new DistributorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var list = request.GetVideoDetails(videoId);

                this.rptList.DataSource = list;
                this.rptList.DataBind();


            }
            catch (NarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = ex.Message;
            }
        }
    }
}