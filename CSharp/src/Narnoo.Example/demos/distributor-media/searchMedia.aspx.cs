using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class searchMedia : DistributorMediaNarnooRequestPage
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
            var media_type = this.ddlMedia_Type.SelectedValue;
            var media_id = this.txtMediaId.Text;
            var category = this.txtCategory.Text;
            var subcategory = this.txtSubcategory.Text;
            var suburb = this.txtsuburb.Text;
            var location = this.txtlocation.Text;
            var latitude = this.txtlatitude.Text;
            var longitude = this.txtlongitude.Text;
            var radius = this.txtradius.Text;
            var privilege = this.rblprivilege.SelectedValue;
            var keywords = this.txtkeywords.Text;

            try
            {
                NarnooCollection<ISearchMedia> list = null;

                if (string.IsNullOrEmpty(media_id))
                {
                    list = this.NarnooRequest.SearchMedia(media_type, category, subcategory, suburb, location, latitude, longitude, radius,privilege, keywords);
                }
                else
                {
                    list = this.NarnooRequest.SearchMedia(media_type, media_id);
                }

                this.searchPanel.Visible = false;
                this.resultPanel.Visible = true;

                this.lblTotal.Text = list.TotalPages.ToString();

                switch (media_type)
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