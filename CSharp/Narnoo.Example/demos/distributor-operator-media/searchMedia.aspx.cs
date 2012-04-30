using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_operator_media
{
    public partial class searchMedia : DistributorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var media_type = this.ddlMedia_Type.SelectedValue;
            var category = this.txtCategory.Text;
            var subcategory = this.txtSubcategory.Text;
            var suburb = this.txtsuburb.Text;
            var location = this.txtlocation.Text;
            var latitude = this.txtlatitude.Text;
            var longitude = this.txtlongitude.Text;
            var keywords = this.txtkeywords.Text;
            var page_no = 1;

            try
            {
                var request = new DistributorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var list = request.SearchMedia(media_type, 
                    category, 
                    subcategory, 
                    suburb, 
                    location, 
                    latitude, 
                    longitude, 
                    keywords, 
                    page_no);

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
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode 
                    + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
            }
        }
    }
}