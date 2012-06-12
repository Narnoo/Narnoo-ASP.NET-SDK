﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class getSingleBrochure : DistributorMediaNarnooRequestPage
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
            string brochure_id = this.txtBrochure_id.Text;


            try
            {
                var item = this.NarnooRequest.GetSingleBrochure(brochure_id);

                this.searchPanel.Visible = false;
                this.resultPanel.Visible = true;

                this.brochure_id.Text = item.brochure_id;
                this.brochure_caption.Text = item.brochure_caption;
                this.entry_date.Text = item.entry_date;
                this.page_order_xml_config.Text = item.page_order_xml_config;
                this.preview_image_path.Text = item.preview_image_path;
                this.format.Text = item.format;
                this.thumb_image_pat.Text = item.thumb_image_path;
                this.validity_date.Text = item.validity_date;
                if (item.pages !=null )
                {
                    rptStandardPages.DataSource = item.pages.standard_pages;
                    rptStandardPages.DataBind();

                    rptZoomPages.DataSource = item.pages.zoom_page;
                    rptZoomPages.DataBind();
                }
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }


    }
}