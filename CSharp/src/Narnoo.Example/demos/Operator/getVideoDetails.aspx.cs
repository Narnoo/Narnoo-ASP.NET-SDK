using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class getVideoDetails : OperatorNarnooRequestPage
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
          
            var video_id = this.txtVideo_id.Text;

            try
            {
                var request = new OperatorNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var list = request.GetVideoDetails( video_id);

                this.rptList.DataSource = list;
                this.rptList.DataBind();

            }
            catch (NarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.ShowMessage(ex.Message);
            }
        }
    }
}