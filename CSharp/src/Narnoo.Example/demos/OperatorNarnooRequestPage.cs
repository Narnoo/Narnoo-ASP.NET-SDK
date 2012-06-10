using System;
using System.Collections.Generic;
using System.Web;

namespace Narnoo.Example.demos
{
    public abstract class OperatorNarnooRequestPage:OperatorPageBase
    {
        OperatorNarnooRequest _NarnooRequest;
        protected OperatorNarnooRequest NarnooRequest
        {
            get
            {
                if (this._NarnooRequest == null)
                {
                    this._NarnooRequest = new OperatorNarnooRequest();
                    this._NarnooRequest.SetAuth(this.appkey, this.secretkey);
                    this._NarnooRequest.Sandbox = this.Sandbox;
                }

                return this._NarnooRequest;

            }
        }
    }
}