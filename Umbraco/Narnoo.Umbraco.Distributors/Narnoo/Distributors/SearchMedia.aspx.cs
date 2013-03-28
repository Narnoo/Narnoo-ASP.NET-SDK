using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco;
using umbraco.uicontrols;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class SearchMedia : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                this.Pager1.Visible = false;
            }
        }

        TabPage dataTab;
        ImageButton btnDownload;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Pager1.PageIndexChanged += Pager1_PageIndexChanged;

            dataTab = TabViewDetails.NewTabPage("Narnoo Media - Search");
            dataTab.Controls.Add(this.tabSearch);

            btnDownload = dataTab.Menu.NewImageButton();
            btnDownload.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnDownload.ID = "btnDownload";
            //btnAdd.Click += new ImageClickEventHandler(btnAdd_Click);
            btnDownload.AlternateText = "Download";
            btnDownload.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownload.ValidationGroup = "";

            this.btnSearch.Click += btnSearch_Click;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindMedia();
        }

        private void Pager1_PageIndexChanged(int newPageIndex)
        {
            this.BindMedia(newPageIndex);
        }

        public bool IsImage
        {
            get
            {

                return this.search_media_type.SelectedValue == "image";
            }
        }

        void BindMedia(int pageIndex = 1)
        {
            try
            {
                NarnooCollection<ISearchMedia> items = null;
                if (string.IsNullOrWhiteSpace(search_media_id.Text))
                {
                    items = this.NarnooMediaRequest.SearchMedia(this.search_media_type.SelectedValue,
                       this.search_category.Text,
                       this.search_subcategory.Text,
                       this.search_suburb.Text,
                       this.search_location.Text,
                       this.search_latitude.Text,
                       this.search_longitude.Text,
                       this.search_radius.Text,
                       this.search_privilege_public.SelectedValue,
                       this.search_keywords.Text,
                       pageIndex);
                }
                else
                {
                    items = this.NarnooMediaRequest.SearchMedia(this.search_media_type.SelectedValue, this.search_media_id.Text, pageIndex);
                }

                this.rptMedia.Visible = true;
                this.rptMedia.DataSource = items;
                this.rptMedia.DataBind();
                this.Pager1.DataBind(pageIndex, items.TotalPages, items.Count);
            }
            catch (Exception ex)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                this.rptMedia.Visible = false;
                this.Pager1.Visible = false;
            }
        }
    }
}