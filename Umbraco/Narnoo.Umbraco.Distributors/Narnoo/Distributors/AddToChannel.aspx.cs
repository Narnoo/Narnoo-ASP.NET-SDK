using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class AddToChannel : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {

                this.rptItems.DataSource = this.SelectedIds;
                this.rptItems.DataBind();

                var channels = this.NarnooMediaRequest.GetChannelList();

                BindChannels(channels);

                this.ddlChannelPager.SelectedIndexChanged += ddlChannelPager_SelectedIndexChanged;
                this.ddlChannelPager.Items.Clear();
                for (var i = 0; i < channels.TotalPages; i++)
                {
                    this.ddlChannelPager.Items.Add(string.Format("Channel page {0}", i + 1));
                }
                this.ddlChannelPager.SelectedIndex = 0;

            }
        }

        void ddlChannelPager_SelectedIndexChanged(object sender, EventArgs e)
        {
            var channels = this.NarnooMediaRequest.GetChannelList(this.ddlChannelPager.SelectedIndex + 1);
            this.BindChannels(channels);
        }

        private void BindChannels(NarnooCollection<Channel> channels)
        {
            this.ddlChannels.DataTextField = "channel_name";
            this.ddlChannels.DataValueField = "channel_id";
            this.ddlChannels.DataSource = channels;
            this.ddlChannels.DataBind();
        }

        string[] _SelectedIds;
        public string[] SelectedIds
        {
            get
            {
                if (this._SelectedIds == null)
                {
                    var ids = this.Request["ids"];
                    this._SelectedIds = string.IsNullOrWhiteSpace(ids) ? new string[0] : ids.Split(',');
                }

                return this._SelectedIds;
            }
        }
    }
}