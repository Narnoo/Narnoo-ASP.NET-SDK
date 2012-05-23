using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_operator_media
{
    public partial class getSingleBrochure : DistributorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var operator_id = this.txtOperator_id.Text;
            string brochure_id = this.txtBrochure_id.Text;

            try
            {
                var request = new DistributorOperatorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);

                var item = request.GetSingleBrochure(operator_id, brochure_id);

                if (item == null)
                {
                    this.lblMessage.Visible = true;
                    this.lblMessage.Text = "Brochure cannot found";
                }
                else
                {
                    this.detail.Visible = true;
                    this.txtBrochureId.Text = item.brochure_id;
                    this.txtbrochure_caption.Text = item.brochure_caption;
                    this.txtEntry_date.Text = item.entry_date;
                    this.txtPage_order_xml_config.Text = item.page_order_xml_config;
                    this.txtPreview_image_path.Text = Utilities.DecodeCData(item.preview_image_path);
                    this.lblFormat.Text = item.format;
          

                    this.txtThumb_image_path.Text = item.thumb_image_path;
                    this.txtvalidity_date.Text = item.validity_date;

               
                    if (item.pages.Count > 0)
                    {
                        rptStandardPages.DataSource = item.pages[0].standard_pages;
                        rptStandardPages.DataBind();

                        rptZoomPages.DataSource = item.pages[0].zoom_page;
                        rptZoomPages.DataBind();
                    }
                }

            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode
                    + "</br> ErrorMessage:" + ex.Error.errorMessage;
            }
        }
    }
}