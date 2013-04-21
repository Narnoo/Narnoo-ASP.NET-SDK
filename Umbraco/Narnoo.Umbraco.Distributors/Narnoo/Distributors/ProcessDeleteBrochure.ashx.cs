
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for ProcessDeleteBrochure
    /// </summary>
    public class ProcessDeleteBrochure : DistributorHanlder
    {
        public override void ProcessRequest(HttpContext context)
        {

            var brochure_id = context.Request["brochure_id"];

            try
            {
                this.NarnooMediaRequest.DeleteBrochure(brochure_id);
                context.Response.Write("{}");
            }
            catch (Exception ex)
            {
                context.Response.Write(JsonConvert.SerializeObject(new { error = ex.Message }));
            }

            context.Response.Flush();
            context.Response.End();
        }
    }
}