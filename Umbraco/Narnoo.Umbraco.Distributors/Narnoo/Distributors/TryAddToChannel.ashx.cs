using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for TryAddToChannel
    /// </summary>
    public class TryAddToChannel : DistributorPage
    {

        public override void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var channel_id = request["channel_id"];
            var video_id = request["video_id"];


            try
            {
                this.NarnooMediaRequest.addToChannel(video_id, channel_id);
                context.Response.Write("{}");
            }
            catch (Exception ex)
            {
                context.Response.Write(JsonSerializer.SerializeToString(new { error = ex.Message }));
            }

            context.Response.Flush();
            context.Response.End();

        }
    }
}