using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public class DistributorHanlder : IHttpHandler
    {
        public DistributorHanlder()
        {
            var settings = new ApiSettings();
            settings.Load();

            this.NarnooRequest = new DistributorNarnooRequest();
            this.NarnooRequest.SetAuth(settings.Appkey, settings.Secretkey);
            this.NarnooRequest.Sandbox = false;

            this.NarnooMediaRequest = new DistributorMediaNarnooRequest();
            this.NarnooMediaRequest.SetAuth(settings.Appkey, settings.Secretkey);
            this.NarnooMediaRequest.Sandbox = false;

            this.NarnooOperatorMediaRequest = new DistributorOperatorMediaNarnooRequest();
            this.NarnooOperatorMediaRequest.SetAuth(settings.Appkey, settings.Secretkey);
            this.NarnooOperatorMediaRequest.Sandbox = false;
        }

        #region NarnooRequest

        protected DistributorNarnooRequest NarnooRequest
        {
            get;
            set;
        }

        protected DistributorMediaNarnooRequest NarnooMediaRequest
        {
            get;
            set;
        }

        protected DistributorOperatorMediaNarnooRequest NarnooOperatorMediaRequest
        {
            get;
            set;
        } 
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        public virtual void ProcessRequest(HttpContext context)
        {
          
        }
    }
}