using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorNarnooRequest : NarnooRequest
    {

        private string interaction_url = "devapi.narnoo.com/xml.php";
        public bool AddOperator(string operatorId)
        {
            var content = this.GetResponse(this.interaction_url, "addOperator", new RequestParameter("operator_id", operatorId));

            return content == "true";
        }
    }
}
