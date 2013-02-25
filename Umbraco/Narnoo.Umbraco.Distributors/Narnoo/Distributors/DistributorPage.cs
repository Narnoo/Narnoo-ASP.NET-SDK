using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.BasePages;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public class DistributorPage : BasePage
    {
        public DistributorPage():base()
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
    }
}