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
    public partial class Albums : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                this.BindAlbums();
            }
        }

        public TabPage dataTab;
               public ImageButton btnDownloadAlbums;
        protected override void OnInit(EventArgs e)
        {
            dataTab = this.TabViewDetails.NewTabPage("Albums");
            dataTab.Controls.Add(this.tabAlbums);
     
            //Create a save button from the current datatab.
            btnDownloadAlbums = dataTab.Menu.NewImageButton();
            btnDownloadAlbums.ID = "btnDownloadAlbumImage";
            btnDownloadAlbums.AlternateText = "Download";
            btnDownloadAlbums.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnDownloadAlbums.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownloadAlbums.ValidationGroup = "";

            this.ddlAlbumsPageIndex.SelectedIndexChanged += ddlAlbumsPageIndex_SelectedIndexChanged;
            this.btnChangeAlbums.Click += btnChangeAlbums_Click;
            this.pagerAlbumImages.PageIndexChanged += pagerAlbumImages_PageIndexChanged;
        }

        void btnChangeAlbums_Click(object sender, EventArgs e)
        {
            this.lblCurrentAlbumName.Text = this.ddlAlbums.SelectedValue;
            this.BindAlbumImages(1);
        }

        private void BindAlbums()
        {
            try
            {
                var albums = this.LoadAlbums();

                this.lblCurrentAlbumName.Text = albums.Select(i => i.album_name).FirstOrDefault();

                this.rptAlbumImages.Visible = false;
                this.BindAlbumImages(1);
                this.pagerAlbumImages.Visible = true;


            }
            catch (Exception ex)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                //this.ErrorMessages.AppendLine(ex.Message);
            }


        }

        private NarnooCollection<Album> LoadAlbums(int pageIndex = 1)
        {
            var albums = this.NarnooMediaRequest.GetAlbums();

            this.ddlAlbumsPageIndex.Items.Clear();
            for (var i = 0; i < albums.TotalPages; i++)
            {
                this.ddlAlbumsPageIndex.Items.Add(string.Format("Album page {0}", i + 1));
            }

            this.ddlAlbumsPageIndex.SelectedIndex = this.pagerAlbumImages.CurrentPageIndex;

            this.ddlAlbums.DataSource = albums;
            this.ddlAlbums.DataBind();
            return albums;
        }
        void ddlAlbumsPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadAlbums(this.ddlAlbumsPageIndex.SelectedIndex);
        }

        void pagerAlbumImages_PageIndexChanged(int newPageIndex)
        {
            this.BindAlbumImages(newPageIndex);
        }

        void BindAlbumImages(int page_no)
        {
            try
            {
                var data = this.NarnooMediaRequest.GetAlbumImages(this.lblCurrentAlbumName.Text, page_no);
                this.rptAlbumImages.Visible = true;
                this.rptAlbumImages.DataSource = data;
                this.rptAlbumImages.DataBind();

                this.pagerAlbumImages.DataBind(page_no, data.TotalPages, data.Count);
            }
            catch (Exception ex)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                this.rptAlbumImages.DataSource = Enumerable.Empty<AlbumImage>();
                this.rptAlbumImages.DataBind();
            }
        }
    }
}