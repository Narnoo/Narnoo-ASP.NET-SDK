using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class getChannelList : DistributorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Visible = false;

            try
            {
                var request = new DistributorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var list = request.GetChannelList();

                this.rptList.DataSource = list;
                this.rptList.DataBind();


            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
            }
        }
    }
}