using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor
{
    public partial class deleteOperator : DistributorPageBase
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
            this.lblMessage.Visible = true;

            string operatorId = this.txtOperatorId.Text;

            try
            {

                var request = new DistributorNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                request.Sandbox = this.Sandbox;
                request.DeleteOperator(operatorId);
                this.lblMessage.Text = "Success";

            }
            catch (NarnooRequestException ex)
            {
                this.lblMessage.Text = ex.Message;
            }
        }
    }
}