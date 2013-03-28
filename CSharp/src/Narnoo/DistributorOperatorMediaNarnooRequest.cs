using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorOperatorMediaNarnooRequest : NarnooRequest
    {

        public DownloadBrochure DownloadBrochure(string operator_id, string brochure_id)
        {
            var content = this.GetResponse(this.getXmlApi(), "downloadBrochure",
                new RequestParameter("operator_id", operator_id),
                new RequestParameter("brochure_id", brochure_id));


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

        public DownloadImage DownloadImage(string operator_id, string image_id)
        {
            var content = this.GetResponse(this.getXmlApi(), "downloadImage", new RequestParameter("operator_id", operator_id), new RequestParameter("media_id", image_id));


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

        public DownloadVideo DownloadVideo(string operator_id, string vedio_id)
        {
            var content = this.GetResponse(this.getXmlApi(), "downloadVideo",
               new RequestParameter("operator_id", operator_id),
               new RequestParameter("video_id", vedio_id));


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

        public NarnooCollection<AlbumImage> GetAlbumImages(string operator_id, string album_name)
        {
            return this.GetAlbumImages(operator_id, album_name, 1);
        }
        public NarnooCollection<AlbumImage> GetAlbumImages(string operator_id, string album_name, int page_no)
        {
            var content = this.GetResponse(this.getXmlApi(), "getAlbumImages", new RequestParameter("operator_id", operator_id), new RequestParameter("album_name", album_name), new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<OperatorAlbumImagesResponse>(content);


            if (list == null)
            {
                list = new OperatorAlbumImagesResponse();
            }

            return new NarnooCollection<AlbumImage>(list.total_pages, list.operator_albums_images);
        }


        public NarnooCollection<Album> GetAlbums(string operator_id)
        {
            return this.GetAlbums(operator_id, 1);
        }

        public NarnooCollection<Album> GetAlbums(string operator_id, int page_no)
        {
            var content = this.GetResponse(this.getXmlApi(), "getAlbums", new RequestParameter("operator_id", operator_id), new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<OperatorAlbumsResponse>(content);


            if (list == null)
            {
                list = new OperatorAlbumsResponse();
            }

            return new NarnooCollection<Album>(list.total_pages, list.operator_albums);
        }
        public NarnooCollection<Brochure> GetBrochures(string operator_id)
        {
            return this.GetBrochures(operator_id, 1);
        }
        public NarnooCollection<Brochure> GetBrochures(string operator_id, int page_no)
        {
            var content = this.GetResponse(this.getXmlApi(), "getBrochures", new RequestParameter("operator_id", operator_id), new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<OperatorBrochuresResponse>(content);


            if (list == null)
            {
                list = new OperatorBrochuresResponse();
            }

            return new NarnooCollection<Brochure>(list.total_pages, list.operator_brochures);
        }
        public NarnooCollection<Image> GetImages(string operator_id)
        {
            return this.GetImages(operator_id, 1);
        }
        public NarnooCollection<Image> GetImages(string operator_id, int page_no)
        {
            var content = this.GetResponse(this.getXmlApi(), "getImages", new RequestParameter("operator_id", operator_id), new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<OperatorImagesResponse>(content);


            if (list == null)
            {
                list = new OperatorImagesResponse();
            }

            return new NarnooCollection<Image>(list.total_pages, list.operator_images);
        }
        public NarnooCollection<Product> GetProductText(string operator_id)
        {
            return this.GetProductText(operator_id, 1);
        }
        public NarnooCollection<Product> GetProductText(string operator_id, int page_no)
        {
            var content = this.GetResponse(this.getXmlApi(), "getProductText", new RequestParameter("operator_id", operator_id), new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<OperatorProductsResponse>(content);


            if (list == null)
            {
                list = new OperatorProductsResponse();
            }

            return new NarnooCollection<Product>(list.total_pages, list.operator_products);
        }

        public ProductTextWords GetProductTextWords(string operator_id, string product_title)
        {
            var content = this.GetResponse(this.getXmlApi(), "getProductTextWords", new RequestParameter("operator_id", operator_id), new RequestParameter("product_title", product_title));

            var item = this.Deserialize<ProductTextWords>(content);


            if (item == null)
            {
                throw new NarnooRequestException("ProductTextWords can NOT be found.");
            }
            else
            {
                return item;
            }

        }

        public SingleBrochure GetSingleBrochure(string operator_id, string brochure_id)
        {
            var content = this.GetResponse(this.getXmlApi(), "getSingleBrochure", new RequestParameter("operator_id", operator_id), new RequestParameter("brochure_id", brochure_id));

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

        public Video GetVideoDetails(string operator_id, string video_id)
        {
            var content = this.GetResponse(this.getXmlApi(), "getVideoDetails", new RequestParameter("operator_id", operator_id), new RequestParameter("video_id", video_id));

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

        public NarnooCollection<Video> GetVideos(string operator_id)
        {
            return this.GetVideos(operator_id, 1);
        }
        public NarnooCollection<Video> GetVideos(string operator_id, int page_no)
        {
            var content = this.GetResponse(this.getXmlApi(), "getVideos", new RequestParameter("operator_id", operator_id), new RequestParameter("page_no", page_no.ToString()));

            var list = this.Deserialize<OperatorVideosResponse>(content);


            if (list == null)
            {
                list = new OperatorVideosResponse();
            }


            return new NarnooCollection<Video>(list.total_pages, list.operator_videos);
        }

        
        public NarnooCollection<ISearchMedia> SearchMedia(string media_type,
            string business_name,
            string country,
            string state,
            string category,
            string subcategory,
            string suburb,
            string location,
            string postal_code,
            string latitude,
            string longitude,
            string keywords)
        {
            return this.SearchMedia(media_type, business_name, country, state, category, subcategory, suburb, location, postal_code, latitude, longitude, keywords, 1);
        }

        public NarnooCollection<ISearchMedia> SearchMedia(string media_type,
            string business_name,
            string country,
            string state,
            string category,
            string subcategory,
            string suburb,
            string location,
            string postal_code,
            string latitude,
            string longitude,
            string keywords, int page_no)
        {
            var content = this.GetResponse(this.getXmlApi(), "searchMedia",
                new RequestParameter("media_type", media_type),
                new RequestParameter("business_name", business_name),
                new RequestParameter("country", country),
                new RequestParameter("state", state),
                new RequestParameter("category", category),
                new RequestParameter("subcategory", subcategory),
                new RequestParameter("suburb", suburb),
                new RequestParameter("location", location),
                new RequestParameter("postal_code", postal_code),
                new RequestParameter("latitude", latitude),
                new RequestParameter("longitude", longitude),
                new RequestParameter("keywords", keywords),
                new RequestParameter("page_no", page_no.ToString()));

            return SearchMediaParser.Parse(media_type, content);

        }
    }
}
