using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor
{
    public partial class singleOperatorDetail : DistributorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Visible = false;
            this.detailView.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string operatorId = this.txtOperatorId.Text;

            try
            {
                var request = new DistributorNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var item = request.SingleOperatorDetail(operatorId);

                if (item == null)
                {
                    this.lblMessage.Visible = true;
                    this.lblMessage.Text = "Operator cannot found";
                }
                else
                {
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
               
            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode + "</br> ErrorMessage:" + ex.Error.errorMessage;
            }
        }
    }
}