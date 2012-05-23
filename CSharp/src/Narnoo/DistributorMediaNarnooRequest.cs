using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorMediaNarnooRequest : NarnooRequest
    {

        public DownloadBrochure DownloadBrochure(string brochure_id)
        {

            var content = this.GetResponse(this.getDistXmlApi(), "downloadBrochure", new RequestParameter("brochure_id", brochure_id));


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


            var content = this.GetResponse(this.getDistXmlApi(), "downloadImage", new RequestParameter("media_id", image_id));


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
            var content = this.GetResponse(this.getDistXmlApi(), "downloadVideo", new RequestParameter("video_id", videoId));


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
            var content = this.GetResponse(this.getDistXmlApi(), "getAlbumImages", new RequestParameter("album_name", album_name));

            var list = this.Deserialize<DistributorAlbumImagesResponse>(content);


            if (list == null)
            {
                list = new DistributorAlbumImagesResponse();
            }


            foreach (var i in list.distributor_albums_images)
            {
                yield return i.album_image;
            }

        }

        public IEnumerable<Album> GetAlbums()
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getAlbums");

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

        public IEnumerable<Brochure> GetBrochures()
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getBrochures");

            var list = this.Deserialize<DistributorBrochuresResponse>(content);


            if (list == null)
            {
                list = new DistributorBrochuresResponse();
            }


            foreach (var i in list.distributor_brochures)
            {
                yield return i.brochure;
            }
        }

        public IEnumerable<Channel> GetChannelList()
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getChannelList");

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
            var content = this.GetResponse(this.getDistXmlApi(), "getChannelVideos", new RequestParameter("channel", channel));

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
            var content = this.GetResponse(this.getDistXmlApi(), "getImages");

            var list = this.Deserialize<DistributorImagesResponse>(content);


            if (list == null)
            {
                list = new DistributorImagesResponse();
            }


            foreach (var i in list.distributor_images)
            {
                yield return i.image;
            }
        }

        public SingleBrochure GetSingleBrochure(string brochure_id)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getSingleBrochure", new RequestParameter("brochure_id", brochure_id));

            var list = this.Deserialize<DistributorSingleBrochuresResponse>(content);


            if (list != null && list.distributor_brochure.Count > 0)
            {
                return list.distributor_brochure[0].brochure;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Video> GetVideoDetails(string videoId)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getVideoDetails", new RequestParameter("video_id", videoId));

            var list = this.Deserialize<DistributorVideoDetailsResponse>(content);


            if (list == null)
            {
                list = new DistributorVideoDetailsResponse();
            }


            foreach (var i in list.distributor_video_details)
            {
                yield return i.distributor_video;
            }
        }

        public IEnumerable<Video> GetVideos()
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getVideos");

            var list = this.Deserialize<DistributorVideosResponse>(content);


            if (list == null)
            {
                list = new DistributorVideosResponse();
            }


            foreach (var i in list.distributor_videos)
            {
                yield return i.distributor_video;
            }
        }

        public IEnumerable<SearchMedia> SearchMedia(string media_type, string media_id)
        {
            var content = this.GetResponse(this.getXmlApi(), "searchMedia",
                new RequestParameter("media_type", media_type),
                new RequestParameter("media_id", media_id));

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

        public IEnumerable<SearchMedia> SearchMedia(string media_type, string category, string subcategory, string suburb, string location, string latitude, string longitude, string keywords, int page_no)
        {

            var content = this.GetResponse(this.getXmlApi(), "searchMedia",
                new RequestParameter("media_type", media_type),
                new RequestParameter("category", category),
                new RequestParameter("subcategory", subcategory),
                new RequestParameter("suburb", suburb),
                new RequestParameter("location", location),
                new RequestParameter("latitude", latitude),
                new RequestParameter("longitude", longitude),
                new RequestParameter("keywords", keywords),
                //new RequestParameter("radius", radius),
                //new RequestParameter("privilege", privilege),
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



        public IEnumerable<SearchMedia> SearchMedia(string media_type, string category, string subcategory, string suburb, string location, string latitude, string longitude, string radius, string privilege, string keywords, int page_no)
        {

            var content = this.GetResponse(this.getXmlApi(), "searchMedia",
                new RequestParameter("media_type", media_type),
                new RequestParameter("category", category),
                new RequestParameter("subcategory", subcategory),
                new RequestParameter("suburb", suburb),
                new RequestParameter("location", location),
                new RequestParameter("latitude", latitude),
                new RequestParameter("longitude", longitude),
                new RequestParameter("keywords", keywords),
                new RequestParameter("radius", radius),
                new RequestParameter("privilege", privilege),
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



        public bool deleteImage(string image_id)
        {

            var content = this.GetResponse(this.getDistXmlApi(), "deleteImage", new RequestParameter("image_id", image_id));

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

        public bool deleteBrochure(string brochure_id)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "deleteBrochure", new RequestParameter("brochure_id", brochure_id));
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
            var content = this.GetResponse(this.getDistXmlApi(), "deleteVideo", new RequestParameter("video_id", video_id));
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
