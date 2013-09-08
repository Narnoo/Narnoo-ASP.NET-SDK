using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EBA.Helpers;

namespace Narnoo.Umbraco.Distributors.Narnoo.handlers
{
    /// <summary>
    /// Summary description for GalleryHandler
    /// </summary>
    public class GalleryHandler : HandlerBase
    {

        protected override void Process(HttpRequest request, HttpResponse response)
        {

            // handle AJAX request
            var narnoo_slg_shortcode_count = request.Form["narnoo_slg_shortcode_count"];
            var album_name = request.Form["album_name"];
            var width = request.Form["width"];
            var height = request.Form["height"];
            var operator_id = request.Form["operator_id"];


            NarnooCollection<AlbumImage> list;
            // request album images from API
            if (operator_id.HasValue())
            {
                try
                {
                    list = this.NarnooOperatorMediaRequest.GetAlbumImages(operator_id, album_name);
                }
                catch (Exception ex)
                {

                    response.Write(serializer.Serialize(new { response = ex.Message }));
                    return;
                }
            }
            else
            {
                try
                {
                    list = this.NarnooMediaRequest.GetAlbumImages(album_name);
                }
                catch (Exception ex)
                {

                    response.Write(serializer.Serialize(new { response = ex.Message }));
                    return;
                }
            }


            if (list.Count == 0)
            {
                response.Write(serializer.Serialize(new { response = "NO IMAGE" }));
                return;
            }

            var master_img_index = (new Random()).Next(0, list.Count);
            var master_img = list[master_img_index];

            var content = "<a href='javascript:imagebox.open(document.getElementById(\"narnoo_single_link_gallery" + narnoo_slg_shortcode_count + "\"));' class='narnoo_single_link_gallery_thumbnail'>";

     
            content += " <img src='" + master_img.preview_image_path + "' width='" + width + "' height='" + height + "' alt='' />";
            content += " <span class='narnoo_single_link_gallery_cover'></span></a>";

            foreach (var img in list)
            {
                content += "<a href='" + img.large_image_path + "' rel='imagebox[narnoo_slg" + narnoo_slg_shortcode_count + "]' id='narnoo_single_link_gallery" + narnoo_slg_shortcode_count + "' title='" + img.image_caption + "'></a>";
            }


            response.Write(serializer.Serialize(new { response = content }));
        }


    }
}