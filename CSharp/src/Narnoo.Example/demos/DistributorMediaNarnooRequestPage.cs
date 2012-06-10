using System;
using System.Collections.Generic;
using System.Web;

namespace Narnoo.Example.demos
{
    public abstract class DistributorMediaNarnooRequestPage:DistributorPageBase
    {
        DistributorMediaNarnooRequest _NarnooRequest;
        protected DistributorMediaNarnooRequest NarnooRequest
        {
            get
            {
                if (this._NarnooRequest == null)
                {
                    this._NarnooRequest = new DistributorMediaNarnooRequest();
                    this._NarnooRequest.SetAuth(this.appkey, this.secretkey);
                    this._NarnooRequest.Sandbox = this.Sandbox;
                }

                return this._NarnooRequest;

            }
        }
    }
}