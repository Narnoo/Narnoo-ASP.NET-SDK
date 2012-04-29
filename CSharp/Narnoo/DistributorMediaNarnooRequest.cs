using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorMediaNarnooRequest : NarnooRequest
    {
        private string interaction_url = "devapi.narnoo.com/xml.php";
        private string remote_url = "devapi.narnoo.com/dist_xml.php";

        public DownloadBrochure DownloadBrochure(string brochure_id)
        {

            var content = this.GetResponse(this.remote_url, "downloadBrochure", new RequestParameter("brochure__id", brochure_id));


            var list = this.Deserialize<DownloadBrochuresResponse>(content);

            if (list != null && list.download_brochure.Count > 0)
            {
                return list.download_brochure[0].download_brochure_details;
            }
            else
            {
                return null;
            }

        }

        public DownloadImage DownloadImage(string image_id)
        {


            var content = this.GetResponse(this.remote_url, "downloadImage", new RequestParameter("media_id", image_id));


            var list = this.Deserialize<DownloadImagesResponse>(content);

            if (list != null && list.download_image.Count > 0)
            {
                return list.download_image[0].download_image_details;
            }
            else
            {
                return null;
            }
        }

        public DownloadVideo DownloadVideo(string videoId)
        {
            var content = this.GetResponse(this.remote_url, "downloadVideo", new RequestParameter("video__id", videoId));


            var list = this.Deserialize<DownloadVideosResponse>(content);

            if (list != null && list.download_video.Count > 0)
            {
                return list.download_video[0].download_video_details;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<AlbumImage>  GetAlbumImages(string album_name)
        {
            var content = this.GetResponse(this.remote_url, "getAlbumImages", new RequestParameter("album__name",album_name));

            var list = this.Deserialize<AlbumImagesResponse>(content);


            if (list == null)
            {
                list = new AlbumImagesResponse();
            }


            foreach (var i in list.distributor_albums_images)
            {
                yield return i.album_image;
            }

        }

        public IEnumerable<Album> GetAlbums()
        {
            var content = this.GetResponse(this.remote_url, "getAlbums");

            var list = this.Deserialize<DistributorAlbumsResponse>(content);


            if (list == null)
            {
                list = new DistributorAlbumsResponse();
            }


            foreach (var i in list.distributor_albums)
            {
                yield return i.album;
            }
        }
    }
}
