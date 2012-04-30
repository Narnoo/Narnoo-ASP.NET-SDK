using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorNarnooRequest : NarnooRequest
    {
        string remote_url = "devapi.narnoo.com/op_xml.php"; // Operator's own account
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

        public IEnumerable<AlbumImage> GetAlbumImages(string album_name)
        {
            var content = this.GetResponse(this.remote_url, "getAlbumImages", new RequestParameter("album__name", album_name));

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

        public IEnumerable<Album> GetAlbums()
        {
            var content = this.GetResponse(this.remote_url, "getAlbums");

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

        public IEnumerable<Brochure> GetBrochures()
        {
            var content = this.GetResponse(this.remote_url, "getBrochures");

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

        public IEnumerable<Channel> GetChannelList()
        {
            var content = this.GetResponse(this.remote_url, "getChannelList");

            var list = this.Deserialize<DistributorChannelsResponse>(content);


            if (list == null)
            {
                list = new DistributorChannelsResponse();
            }


            foreach (var i in list.distributor_channel_list)
            {
                yield return i.channel;
            }
        }



        public IEnumerable<ChannelVideo> GetChannelVideos(string channel)
        {
            var content = this.GetResponse(this.remote_url, "getChannelVideos", new RequestParameter("channel", channel));

            var list = this.Deserialize<DistributorChannelVideosResponse>(content);


            if (list == null)
            {
                list = new DistributorChannelVideosResponse();
            }


            foreach (var i in list.distributor_channel_videos)
            {
                yield return i.channel_video_details;
            }
        }

        public IEnumerable<Image> GetImages()
        {
            var content = this.GetResponse(this.remote_url, "getImages");

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

        public SingleBrochure GetSingleBrochure(string brochure_id)
        {
            var content = this.GetResponse(this.remote_url, "getSingleBrochure", new RequestParameter("brochure__id", brochure_id));

            var list = this.Deserialize<OperatorSingleBrochuresResponse>(content);


            if (list != null && list.operator_brochures.Count > 0)
            {
                return list.operator_brochures[0].brochure;
            }
            else
            {
                return null;
            }


          
        }

        public IEnumerable<Video> GetVideoDetails(string videoId)
        {
            var content = this.GetResponse(this.remote_url, "getVideoDetails", new RequestParameter("video__id", videoId));

            var list = this.Deserialize<OperatorVideoDetailsResponse>(content);


            if (list == null)
            {
                list = new OperatorVideoDetailsResponse();
            }


            foreach (var i in list.operator_videos)
            {
                yield return i.operator_video;
            }
        }

        public IEnumerable<Video> GetVideos()
        {
            var content = this.GetResponse(this.remote_url, "getVideos");

            var list = this.Deserialize<OperatorVideosResponse>(content);


            if (list == null)
            {
                list = new OperatorVideosResponse();
            }


            foreach (var i in list.operator_videos)
            {
                yield return i.operator_video;
            }
        }

        public IEnumerable<SearchMedia> SearchMedia(string media_type, string category, string subcategory, string suburb, string location, string latitude, string longitude, string keywords, int page_no)
        {
            var content = this.GetResponse(this.remote_url, "searchMedia",
                new RequestParameter("media_type", media_type),
                new RequestParameter("category", category),
                new RequestParameter("subcategory", subcategory),
                new RequestParameter("suburb", suburb),
                new RequestParameter("location", location),
                new RequestParameter("latitude", latitude),
                new RequestParameter("longitude", longitude),
                new RequestParameter("keywords", keywords),
                new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<SearchMediaListResponse>(content);


            if (list == null)
            {
                list = new SearchMediaListResponse();
            }


            foreach (var i in list.search_media)
            {
                switch (media_type)
                {
                    case "image":
                        yield return i.search_media_image;
                        break;
                    case "brochure":
                        yield return i.search_media_brochure;
                        break;
                    case "video":
                        yield return i.search_media_video;
                        break;

                    default:
                        yield return null;
                        break;
                }
            }




        }


        public IEnumerable<Product> GetProductText()
        {
            var content = this.GetResponse(this.remote_url, "getProductText");

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

        public ProductTextWords GetProductTextWords(string product_title)
        {
            var content = this.GetResponse(this.remote_url, "getProductTextWords",  new RequestParameter("product_title", product_title));

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
