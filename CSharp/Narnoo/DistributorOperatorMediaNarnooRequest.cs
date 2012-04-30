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

        public IEnumerable<Album> GetAlbums(string operator_id)
        {
            var content = this.GetResponse(this.remote_url, "getAlbums",new RequestParameter("operator_id",operator_id));

            var list = this.Deserialize<OperatorAlbumsResponse>(content);


            if (list == null)
            {
                list = new OperatorAlbumsResponse();
            }


            foreach (var i in list.operator_albums)
            {
                yield return i.album;
            }
        }

        public IEnumerable<Brochure> GetBrochures(string operator_id)
        {
            var content = this.GetResponse(this.remote_url, "getBrochures", new RequestParameter("operator_id", operator_id));

            var list = this.Deserialize<OperatorBrochuresResponse>(content);


            if (list == null)
            {
                list = new OperatorBrochuresResponse();
            }


            foreach (var i in list.operator_brochures)
            {
                yield return i.brochure;
            }
        }

        public IEnumerable<Image> GetImages(string operator_id)
        {
            var content = this.GetResponse(this.remote_url, "getImages", new RequestParameter("operator_id", operator_id));

            var list = this.Deserialize<OperatorImagesResponse>(content);


            if (list == null)
            {
                list = new OperatorImagesResponse();
            }


            foreach (var i in list.operator_images)
            {
                yield return i.image;
            }
        }

        public IEnumerable<Product> GetProductText(string operator_id)
        {
            var content = this.GetResponse(this.remote_url, "getProductText", new RequestParameter("operator_id", operator_id));

            var list = this.Deserialize<OperatorProductsResponse>(content);


            if (list == null)
            {
                list = new OperatorProductsResponse();
            }


            foreach (var i in list.operator_products)
            {
                yield return i.operator_product;
            }
        }

        public ProductTextWords GetProductTextWords(string operator_id,string product_title)
        {
            var content = this.GetResponse(this.remote_url, "getProductTextWords", new RequestParameter("operator_id", operator_id),new RequestParameter("product_title",product_title));

            var list = this.Deserialize<OperatorProductTextWordsListResponse>(content);


            if (list != null && list.operator_products.Count > 0)
            {
                return list.operator_products[0].product_description;
            }
            else
            {
                return null;
            }

        }
    }
}
