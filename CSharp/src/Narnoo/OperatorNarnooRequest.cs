using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorNarnooRequest : NarnooRequest
    {

        public DownloadBrochure DownloadBrochure(string brochure_id)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "downloadBrochure", new RequestParameter("brochure_id", brochure_id));


            var item = this.Deserialize<DownloadBrochure>(content);

            if (item == null)
            {
                throw new NarnooRequestException("Brochure can NOT be found.");
            }
            else
            {
                return item;
            }

        }

        public DownloadImage DownloadImage(string image_id)
        {


            var content = this.GetResponse(this.getOpXmlApi(), "downloadImage", new RequestParameter("media_id", image_id));


            var item = this.Deserialize<DownloadImage>(content);

            if (item == null)
            {
                throw new NarnooRequestException("Image can NOT be found.");
            }
            else
            {
                return item;
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

        public NarnooCollection<AlbumImage> GetAlbumImages(string album_name)
        {
            return this.GetAlbumImages(album_name, 1);
        }

        public NarnooCollection<AlbumImage> GetAlbumImages(string album_name, int page_no)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getAlbumImages", new RequestParameter("album_name", album_name), new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<OperatorAlbumImagesResponse>(content);


            if (list == null)
            {
                list = new OperatorAlbumImagesResponse();
            }

            return new NarnooCollection<AlbumImage>(list.total_pages, list.operator_albums_images);

        }

        public NarnooCollection<Album> GetAlbums()
        {
            return this.GetAlbums(1);
        }

        public NarnooCollection<Album> GetAlbums(int page_no)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getAlbums", new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<OperatorAlbumsResponse>(content);


            if (list == null)
            {
                list = new OperatorAlbumsResponse();
            }


            return new NarnooCollection<Album>(list.total_pages, list.operator_albums);
        }

        public NarnooCollection<Brochure> GetBrochures()
        {
            return this.GetBrochures(1);
        }

        public NarnooCollection<Brochure> GetBrochures(int page_no)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getBrochures", new RequestParameter("page_no", page_no.ToString()));

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
        public NarnooCollection<Image> GetImages()
        {
            return this.GetImages(1);
        }
        public NarnooCollection<Image> GetImages(int page_no)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getImages", new RequestParameter("page_no", page_no.ToString()));

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

            var item = this.Deserialize<SingleBrochure>(content);

            if (item == null)
            {
                throw new NarnooRequestException("Brochure can NOT be found.");
            }
            else
            {
                return item;
            }


        }

        public Video GetVideoDetails(string videoId)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getVideoDetails", new RequestParameter("video_id", videoId));

            var item = this.Deserialize<Video>(content);

            if (item == null)
            {
                throw new NarnooRequestException("Brochure can NOT be found.");
            }
            else
            {
                return item;
            }
        }

        public NarnooCollection<Video> GetVideos()
        {
            return this.GetVideos(1);
        }
        public NarnooCollection<Video> GetVideos(int page_no)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getVideos", new RequestParameter("page_no", page_no.ToString()));

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

        public NarnooCollection<Product> GetProductText()
        {
            return this.GetProductText(1);
        }

        public NarnooCollection<Product> GetProductText(int page_no)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getProductText", new RequestParameter("page_no", page_no.ToString()));

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

            var item = this.Deserialize<ProductTextWords>(content);

            if (item == null)
            {
                throw new NarnooRequestException("Brochure can NOT be found.");
            }
            else
            {
                return item;
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


        #region getDistributors

        public NarnooCollection<Distributor> getDistributors()
        {
            return this.getDistributors(1);
        }

        public NarnooCollection<Distributor> getDistributors(int page_no)
        {
            var content = this.GetResponse(this.getOpXmlApi(), "getDistributors", new RequestParameter("page_no", page_no.ToString()));
            var list = this.Deserialize<DistributorCollectionRespone>(content);


            if (list == null)
            {
                list = new DistributorCollectionRespone();
            }

            return new NarnooCollection<Distributor>(list.total_pages, list.distributors);
        } 
        #endregion
    }
}
