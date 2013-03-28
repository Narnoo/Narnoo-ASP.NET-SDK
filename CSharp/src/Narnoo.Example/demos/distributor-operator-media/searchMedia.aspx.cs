using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_operator_media
{
    public partial class searchMedia : DistributorOperatorMediaNarnooRequestPage
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
       

            try
            {
                var list = this.NarnooRequest.SearchMedia(this.search_media_type.SelectedValue,
                    this.search_business_name.Value,
                    this.search_country.Value,
                    this.search_state.Value,
                    this.search_category.Value,
                    this.search_subcategory.Value,
                    this.search_suburb.Value,
                    this.search_location.Value,
                    this.search_postal_code.Value,
                    this.search_latitude.Value,
                    this.search_longitude.Value,
                    this.search_keywords.Value);

                this.searchPanel.Visible = false;
                this.resultPanel.Visible = true;

                this.lblTotal.Text = list.TotalPages.ToString();
                switch (this.search_media_type.SelectedValue)
                {
                    case "image":
                        this.rptImages.DataSource = list;
                        this.rptImages.DataBind();
                        break;
                    case "brochure":
                        this.rptBrochures.DataSource = list;
                        this.rptBrochures.DataBind();
                        break;
                    case "video":
                        this.rptVideos.DataSource = list;
                        this.rptVideos.DataBind();
                        break;
                    default:
                        break;
                }
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}