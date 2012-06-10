using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor
{
    public partial class addOperator : DistributorNarnooRequestPage
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
            string operatorId = this.txtOperatorId.Text;

            try
            {
                this.NarnooRequest.AddOperator(operatorId);
                this.ShowMessage("done.");
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}