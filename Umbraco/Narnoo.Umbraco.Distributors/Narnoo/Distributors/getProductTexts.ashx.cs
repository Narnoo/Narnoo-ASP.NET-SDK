
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for getProductTexts
    /// </summary>
    public class getProductTexts : DistributorHanlder
    {

        public override void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var product_title = request["product_title"];
            var operator_id = request["operator_id"];

            var texts = this.NarnooOperatorMediaRequest.GetProductTextWords(operator_id, product_title);

            context.Response.Write(JsonConvert.SerializeObject(texts.text));
            context.Response.Flush();
            context.Response.End();
        }


    }
}