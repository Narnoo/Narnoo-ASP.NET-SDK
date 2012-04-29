using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor
{
    public partial class searchOperators : DistributorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var country = this.txtCountry.Text;
            var category = this.txtCategory.Text;
            var subcategory = this.txtSubCategory.Text;
            var state = this.txtState.Text;
            var suburb = this.txtSuburb.Text;
            var postal_code = this.txtPostal_code.Text;

            try
            {
                var request = new DistributorNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var list = request.SearchOperators(country, category, subcategory, state, suburb, postal_code);
                this.rptList.DataSource = list;
                this.rptList.DataBind();
            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
            }
        }
    }
}