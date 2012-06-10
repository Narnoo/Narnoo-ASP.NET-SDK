using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor
{
    public partial class singleOperatorDetail : DistributorNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.detailView.Visible = false;
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
                var item = this.NarnooRequest.SingleOperatorDetail(operatorId);

                this.detailView.Visible = true;

                this.lblCategory.Text = item.category;
                this.lblCountryName.Text = item.country_name;
                this.lblKeywords.Text = item.keywords;
                this.lblLatitude.Text = item.latitude;
                this.lblLongitude.Text = item.longitude;
                this.lblOperatorBusinessname.Text = item.operator_businessname;
                this.lblOperatorId.Text = item.operator_id;
                this.lblPostcode.Text = item.postcode;
                this.lblState.Text = item.state;
                this.lblSubCategory.Text = item.sub_category;
                this.lblSuburb.Text = item.suburb;
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}