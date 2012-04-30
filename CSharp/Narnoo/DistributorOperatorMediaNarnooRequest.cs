using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorOperatorMediaNarnooRequest : NarnooRequest
    {

        string remote_url = "devapi.narnoo.com/xml.php"; // Distributor -> Operator
        public DownloadBrochure DownloadBrochure(string operator_id, string brochure_id)
        {
            var content = this.GetResponse(this.remote_url, "downloadBrochure",
                new RequestParameter("operator_id", operator_id),
                new RequestParameter("brochure__id", brochure_id));


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

        public DownloadImage DownloadImage(string operator_id, string image_id)
        {
            var content = this.GetResponse(this.remote_url, "downloadImage", new RequestParameter("operator_id", operator_id), new RequestParameter("media_id", image_id));


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

        public DownloadVideo DownloadVideo(string operator_id, string vedio_id)
        {
            var content = this.GetResponse(this.remote_url, "downloadVideo",
               new RequestParameter("operator_id", operator_id),
               new RequestParameter("video__id", vedio_id));


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


        public IEnumerable<AlbumImage> GetAlbumImages(string operator_id, string album_name)
        {
            var content = this.GetResponse(this.remote_url, "getAlbumImages", new RequestParameter("operator_id",operator_id), new RequestParameter("album__name", album_name));

            var list = this.Deserialize<OperatorAlbumImagesResponse>(content);


            if (list == null)
            {
                list = new OperatorAlbumImagesResponse();
            }


            foreach (var i in list.operator_albums_images)
            {
                yield return i.album_image;
            }
        }
    }
}
