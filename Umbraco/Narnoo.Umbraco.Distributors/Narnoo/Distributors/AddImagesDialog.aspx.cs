using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class AddImagesDialog : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {

                this.rptItems.DataSource = this.SelectedIds;
                this.rptItems.DataBind();

                var albums = this.NarnooMediaRequest.GetAlbums();

                BindAlbums(albums);

            
                this.ddlAlbumsPager.Items.Clear();
                for (var i = 0; i < albums.TotalPages; i++)
                {
                    this.ddlAlbumsPager.Items.Add(string.Format("Album page {0}", i + 1));
                }
                this.ddlAlbumsPager.SelectedIndex = 0;

            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.ddlAlbumsPager.SelectedIndexChanged += ddlAlbumsPager_SelectedIndexChanged;
        }

        void ddlAlbumsPager_SelectedIndexChanged(object sender, EventArgs e)
        {
            var albums = this.NarnooMediaRequest.GetAlbums(this.ddlAlbumsPager.SelectedIndex + 1);
            this.BindAlbums(albums);
        }

        private void BindAlbums(NarnooCollection<Album> albums)
        {
            this.ddlAlbums.DataTextField = "album_name";
            this.ddlAlbums.DataValueField = "album_id";
            this.ddlAlbums.DataSource = albums;
            this.ddlAlbums.DataBind();
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