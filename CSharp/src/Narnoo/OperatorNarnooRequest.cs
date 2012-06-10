﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorNarnooRequest : NarnooRequest
    {

        public DownloadBrochure DownloadBrochure(string brochure_id)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "downloadBrochure", new RequestParameter("brochure_id", brochure_id));


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


            var content = this.GetResponse(this.getOpXmlApi(), "downloadImage", new RequestParameter("media_id", image_id));


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
            var content = this.GetResponse(this.getOpXmlApi(), "downloadVideo", new RequestParameter("video_id", videoId));


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
            var content = this.GetResponse(this.getOpXmlApi(), "getAlbumImages", new RequestParameter("album_name", album_name));

            var list = this.Deserialize<OperatorAlbumImagesResponse>(content);


            if (list == null)
            {
                list = new OperatorAlbumImagesResponse();
            }

            return new NarnooCollection<AlbumImage>(list.total_pages, list.operator_albums_images);

        }

        public IEnumerable<Album> GetAlbums()
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getAlbums");

            var list = this.Deserialize<OperatorAlbumsResponse>(content);


            if (list == null)
            {
                list = new OperatorAlbumsResponse();
            }


            return new NarnooCollection<Album>(list.total_pages, list.operator_albums);
        }

        public IEnumerable<Brochure> GetBrochures()
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getBrochures");

            var list = this.Deserialize<OperatorBrochuresResponse>(content);


            if (list == null)
            {
                list = new OperatorBrochuresResponse();
            }


            return new NarnooCollection<Brochure>(list.total_pages, list.operator_brochures);
        }

        public IEnumerable<Channel> GetChannelList()
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getChannelList");

            var list = this.Deserialize<DistributorChannelsResponse>(content);


            if (list == null)
            {
                list = new DistributorChannelsResponse();
            }


            return null;
        }



        public IEnumerable<ChannelVideo> GetChannelVideos(string channel)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getChannelVideos", new RequestParameter("channel", channel));

            var list = this.Deserialize<DistributorChannelVideosResponse>(content);


            if (list == null)
            {
                list = new DistributorChannelVideosResponse();
            }


            return null;
        }

        public IEnumerable<Image> GetImages()
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getImages");

            var list = this.Deserialize<OperatorImagesResponse>(content);


            if (list == null)
            {
                list = new OperatorImagesResponse();
            }


            return new NarnooCollection<Image>(list.total_pages, list.operator_images);
        }

        public SingleBrochure GetSingleBrochure(string brochure_id)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getSingleBrochure", new RequestParameter("brochure_id", brochure_id));

            var list = this.Deserialize<List< OperatorSingleBrochuresResponse>>(content);


            if (list != null && list.Count > 0)
            {
                return list[0].operator_brochures[0].brochure;
            }
            else
            {
                return null;
            }



        }

        public IEnumerable<Video> GetVideoDetails(string videoId)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getVideoDetails", new RequestParameter("video_id", videoId));

            var list = this.Deserialize<OperatorVideoDetailsResponse>(content);


            if (list == null)
            {
                list = new OperatorVideoDetailsResponse();
            }

            return new NarnooCollection<Video>(list.total_pages, list.operator_videos);
        }

        public IEnumerable<Video> GetVideos()
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getVideos");

            var list = this.Deserialize<OperatorVideosResponse>(content);


            if (list == null)
            {
                list = new OperatorVideosResponse();
            }


            return new NarnooCollection<Video>(list.total_pages, list.operator_videos);
        }

        public NarnooCollection<SearchMedia> SearchMedia(string media_type, string category, string subcategory, string suburb, string location, string latitude, string longitude, string keywords, int page_no)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "searchMedia",
                new RequestParameter("media_type", media_type),
                new RequestParameter("category", category),
                new RequestParameter("subcategory", subcategory),
                new RequestParameter("suburb", suburb),
                new RequestParameter("location", location),
                new RequestParameter("latitude", latitude),
                new RequestParameter("longitude", longitude),
                new RequestParameter("keywords", keywords),
                new RequestParameter("page_no", page_no.ToString()));

            return SearchMediaParser.Parse(media_type, content);


        }


        public IEnumerable<Product> GetProductText()
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getProductText");

            var list = this.Deserialize<OperatorProductsResponse>(content);


            if (list == null)
            {
                list = new OperatorProductsResponse();
            }

            return new NarnooCollection<Product>(list.total_pages, list.operator_products);
        }

        public ProductTextWords GetProductTextWords(string product_title)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getProductTextWords", new RequestParameter("product_title", product_title));

            var list = this.Deserialize<OperatorProductTextWordsListResponse>(content);


            if (list != null && list.operator_products.Count > 0)
            {
                return list.operator_products[0];
            }
            else
            {
                return null;
            }

        }

        public bool deleteBrochure(string brochure_id)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "deleteBrochure", new RequestParameter("brochure_id", brochure_id));

            try
            {
                var success = this.Deserialize<NarnooSuccessResponse>(content);

                return success != null;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteImage(string image_id)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "deleteImage", new RequestParameter("image_id", image_id));
            try
            {
                var success = this.Deserialize<NarnooSuccessResponse>(content);

                return success != null;

            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool deleteVideo(string video_id)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "deleteVideo", new RequestParameter("video_id", video_id));

            try
            {
                var success = this.Deserialize<NarnooSuccessResponse>(content);

                return success != null;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
