﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class getAlbumImages : OperatorNarnooRequestPage
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

            var album_name = this.txtAlbum_name.Text;
            try
            {
                var list = this.NarnooRequest.GetAlbumImages(album_name);

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