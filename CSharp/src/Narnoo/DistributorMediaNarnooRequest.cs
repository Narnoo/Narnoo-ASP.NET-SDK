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


            var item = this.Deserialize<DownloadBrochure>(content);

            if (item == null)
            {
                throw new NarnooRequestException("Brochure can NOT be found.");
            }

            return item;

        }

        public DownloadImage DownloadImage(string image_id)
        {

            var content = this.GetResponse(this.getDistXmlApi(), "downloadImage", new RequestParameter("media_id", image_id));

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
            var content = this.GetResponse(this.getDistXmlApi(), "downloadVideo", new RequestParameter("video_id", videoId));

            var item = this.Deserialize<DownloadVideo>(content);

            if (item == null)
            {
                throw new NarnooRequestException("Video can NOT be found.");
            }
            else
            {
                return item;
            }
        }

        public NarnooCollection<AlbumImage> GetAlbumImages(string album_name)
        {
            return this.GetAlbumImages(album_name, 1);
        }

        public NarnooCollection<AlbumImage> GetAlbumImages(string album_name, int page_no)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getAlbumImages", new RequestParameter("album_name", album_name), new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<DistributorAlbumImagesResponse>(content);


            if (list == null)
            {
                list = new DistributorAlbumImagesResponse();
            }

            return new NarnooCollection<AlbumImage>(list.total_pages, list.distributor_albums_images);

        }

        public NarnooCollection<Album> GetAlbums()
        {
            return this.GetAlbums(1);
        }

        public NarnooCollection<Album> GetAlbums(int page_no)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getAlbums", new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<DistributorAlbumsResponse>(content);


            if (list == null)
            {
                list = new DistributorAlbumsResponse();
            }


            return new NarnooCollection<Album>(list.total_pages, list.distributor_albums);
        }

        public NarnooCollection<Brochure> GetBrochures()
        {
            return this.GetBrochures(1);
        }
        public NarnooCollection<Brochure> GetBrochures(int page_no)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getBrochures", new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<DistributorBrochuresResponse>(content);


            if (list == null)
            {
                list = new DistributorBrochuresResponse();
            }
            return new NarnooCollection<Brochure>(list.total_pages, list.distributor_brochures);
        }

        public NarnooCollection<Channel> GetChannelList()
        {
            return this.GetChannelList(1);
        }

        public NarnooCollection<Channel> GetChannelList(int page_no)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getChannelList", new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<DistributorChannelsResponse>(content);


            if (list == null)
            {
                list = new DistributorChannelsResponse();
            }

            return new NarnooCollection<Channel>(list.total_pages, list.distributor_channel_list);
        }


        public NarnooCollection<ChannelVideo> GetChannelVideos(string channel)
        {
            return this.GetChannelVideos(channel, 1);
        }
        public NarnooCollection<ChannelVideo> GetChannelVideos(string channel, int page_no)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getChannelVideos", new RequestParameter("channel", channel), new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<DistributorChannelVideosResponse>(content);


            if (list == null)
            {
                list = new DistributorChannelVideosResponse();
            }

            return new NarnooCollection<ChannelVideo>(list.total_pages, list.distributor_channel_videos);
        }
        public NarnooCollection<Image> GetImages()
        {
            return this.GetImages(1);
        }

        public NarnooCollection<Image> GetImages(int page_no)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getImages", new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<DistributorImagesResponse>(content);


            if (list == null)
            {
                list = new DistributorImagesResponse();
            }

            return new NarnooCollection<Image>(list.total_pages, list.distributor_images);
        }

        public SingleBrochure GetSingleBrochure(string brochure_id)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "getSingleBrochure", new RequestParameter("brochure_id", brochure_id));

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
            var content = this.GetResponse(this.getDistXmlApi(), "getVideoDetails", new RequestParameter("video_id", videoId));

            var item = this.Deserialize<Video>(content);


            if (item == null)
            {
                throw new NarnooRequestException("Video can NOT be found.");
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
            var content = this.GetResponse(this.getDistXmlApi(), "getVideos", new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<DistributorVideosResponse>(content);


            if (list == null)
            {
                list = new DistributorVideosResponse();
            }

            return new NarnooCollection<Video>(list.total_pages, list.distributor_videos);
        }

        public NarnooCollection<SearchMedia> SearchMedia(string media_type, string media_id)
        {
            return this.SearchMedia(media_type, media_id, 1);
        }

        public NarnooCollection<SearchMedia> SearchMedia(string media_type, string media_id, int page_no)
        {
            var content = this.GetResponse(this.getXmlApi(), "searchMedia",
                new RequestParameter("media_type", media_type),
                new RequestParameter("media_id", media_id),
                new RequestParameter("page_no", page_no.ToString()));

            return SearchMediaParser.Parse(media_type, content);

        }


        public NarnooCollection<SearchMedia> SearchMedia(string media_type, string category, string subcategory, string suburb, string location, string latitude, string longitude, string keywords)
        {
            return this.SearchMedia(media_type, category, subcategory, suburb, location, latitude, longitude, keywords, 1);
        }
        public NarnooCollection<SearchMedia> SearchMedia(string media_type, string category, string subcategory, string suburb, string location, string latitude, string longitude, string keywords, int page_no)
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

            return SearchMediaParser.Parse(media_type, content);

        }


        public NarnooCollection<SearchMedia> SearchMedia(string media_type, string category, string subcategory, string suburb, string location, string latitude, string longitude, string radius, string privilege, string keywords)
        {
            return this.SearchMedia(media_type, category, subcategory, suburb, location, latitude, longitude, radius,privilege, keywords, 1);
        }
        public NarnooCollection<SearchMedia> SearchMedia(string media_type, string category, string subcategory, string suburb, string location, string latitude, string longitude, string radius, string privilege, string keywords, int page_no)
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
            return SearchMediaParser.Parse(media_type, content);

        }

      



        public bool DeleteImage(string image_id)
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

        public bool DeleteBrochure(string brochure_id)
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

        public bool DeleteVideo(string video_id)
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

        #region createAlbum
        public bool createAlbum(string album_name)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "createAlbum", new RequestParameter("album_name", album_name));

            try
            {
                var success = this.Deserialize<NarnooSuccessResponse>(content);

                return success != null;

            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region addToAlbum
        public void addToAlbum(string image_id, string album_id)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "addToAlbum", new RequestParameter("media_id", image_id), new RequestParameter("album_id", album_id));

            try
            {
                var success = this.Deserialize<NarnooSuccessResponse>(content);
            }
            catch
            {
                throw new Exception(content);
            }
        }
        #endregion

        #region removeFromAlbum
        public void removeFromAlbum(string image_id, string album_id)
        {
            var content = this.GetResponse(this.getDistXmlApi(), "removeFromAlbum", new RequestParameter("media_id", image_id), new RequestParameter("album_id", album_id));

            try
            {
                var success = this.Deserialize<NarnooSuccessResponse>(content);
            }
            catch
            {
                throw new Exception(content);
            }
        }
        #endregion

    }
}
