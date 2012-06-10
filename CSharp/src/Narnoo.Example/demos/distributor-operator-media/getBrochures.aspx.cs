﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_operator_media
{
    public partial class getBrochures : DistributorPageBase
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
            var operator_id = this.txtOperator_id.Text;

            try
            {
                var request = new DistributorOperatorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var list = request.GetBrochures(operator_id);

                this.rptList.DataSource = list;
                this.rptList.DataBind();

            }
            catch (NarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = ex.Message;
                    
            }
        }
    }
}