using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorOperatorMediaNarnooRequest : NarnooRequest
    {

        string remote_url = "devapi.narnoo.com/xml.php"; // Distributor -> Operator
        public DownloadBrochure DownloadBrochure(string operator_id,string brochure_id)
        {
            var content = this.GetResponse(this.remote_url, "downloadBrochure", 
                new RequestParameter("operator_id",operator_id),
                new RequestParameter("brochure__id", brochure_id));


            var list = this.Deserialize<DownloadBrochuresResponse>(content);

            if (list != null && list.download_brochure.Count > 0)
            {
                return list.download_brochure[0].download_brochure_details;
            }
            else
            {
                return null;
            }
        }
    }
}
