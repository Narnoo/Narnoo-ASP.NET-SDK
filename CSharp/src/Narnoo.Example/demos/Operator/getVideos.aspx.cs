using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class getVideos : OperatorNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var request = new OperatorNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var list = request.GetVideos();

                this.rptList.DataSource = list;
                this.rptList.DataBind();

            }
            catch (NarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.ShowMessage(ex.Message);
                    
            }
        }

        protected override Label MessageBox
        {
            get
            {
                return this.lblMessage;
            }
        }
    }
}