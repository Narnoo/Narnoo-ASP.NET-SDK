using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor
{
    public partial class searchOperators : DistributorNarnooRequestPage
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
            var country = this.txtCountry.Text;
            var category = this.txtCategory.Text;
            var subcategory = this.txtSubCategory.Text;
            var state = this.txtState.Text;
            var suburb = this.txtSuburb.Text;
            var postal_code = this.txtPostal_code.Text;

            try
            {
                var list = this.NarnooRequest.SearchOperators(country, category, subcategory, state, suburb, postal_code);
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