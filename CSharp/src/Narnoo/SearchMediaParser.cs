using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Narnoo
{
    public static class SearchMediaParser
    {
       public static  NarnooCollection<ISearchMedia> Parse(string media_type, string content)
        {
            NarnooCollection<ISearchMedia> result = new NarnooCollection<ISearchMedia>("1", new List<ISearchMedia>());

            switch (media_type)
            {
                case "image":
                    var images = JsonConvert.DeserializeObject<SearchMediaImagesResponse>(content);

                    if (images != null)
                    {
                        var items = new List<ISearchMedia>();
                        foreach (var i in images.search_media)
                        {
                            items.Add((ISearchMedia)i);
                        }

                        result = new NarnooCollection<ISearchMedia>(images.total_pages, items);
                    }

                    break;
                case "brochure":
                    var brochures = JsonConvert.DeserializeObject<SearchMediaBrochuresResponse>(content);

                    if (brochures != null)
                    {
                        var items = new List<ISearchMedia>();
                        foreach (var i in brochures.search_media)
                        {
                            items.Add((ISearchMedia)i);
                        }

                        result = new NarnooCollection<ISearchMedia>(brochures.total_pages, items);
                    }
                    break;
                case "video":
                    var videos = JsonConvert.DeserializeObject<SearchMediaVideosResponse>(content);

                    if (videos != null)
                    {
                        var items = new List<ISearchMedia>();
                        foreach (var i in videos.search_media)
                        {
                            items.Add((ISearchMedia)i);
                        }

                        result = new NarnooCollection<ISearchMedia>(videos.total_pages, items);
                    }
                    break;

                default:

                    break;

            }

            return result;
        }
    }
}
