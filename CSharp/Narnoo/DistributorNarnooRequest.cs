using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorNarnooRequest : NarnooRequest
    {

        private string interaction_url = "devapi.narnoo.com/xml.php";
        private string remote_url = "devapi.narnoo.com/dist_xml.php"; 
        public bool AddOperator(string operatorId)
        {
            var content = this.GetResponse(this.interaction_url, "addOperator", new RequestParameter("operator_id", operatorId));

            return content == "true";
        }

        public bool DeleteOperator(string operatorId)
        {
            var content = this.GetResponse(this.interaction_url, "deleteOperator", new RequestParameter("operator_id", operatorId));

            return content == "true";
        }

        public IEnumerable<Operator> ListOperators()
        {
            var content = this.GetResponse(this.interaction_url, "listOperators");

            content = content.Replace("{\"operator\":{\"", "{\"Operator\":{\"");

            var list = this.Deserialize<OperatorsResponse>(content);


            if (list == null)
            {
                list = new OperatorsResponse();
            }


            foreach (var i in list.operators)
            {
                yield return i.Operator;
            }

        }

        public IEnumerable<Operator> SearchOperators(string country, string category, string subcategory, string state, string suburb, string postal_code)
        {
            var content = this.GetResponse(this.interaction_url, "searchOperators",
                new RequestParameter("country",country),
                new RequestParameter("category",category),
                new RequestParameter("subcategory",subcategory),
                new RequestParameter("state",state),
                new RequestParameter("suburb",suburb),
                new RequestParameter("postal_code",postal_code)
                );

            content = content.Replace("{\"operator\":{\"", "{\"Operator\":{\"");

            var list = this.Deserialize<SearchOperatorsResponse>(content);


            if (list == null)
            {
                list = new SearchOperatorsResponse();
            }


            foreach (var i in list.search_operators)
            {
                yield return i.Operator;
            }
        }

        public Operator SingleOperatorDetail(string operatorId)
        {
             var content = this.GetResponse(this.interaction_url, "singleOperatorDetail",new RequestParameter("operator_id",operatorId));
             content = content.Replace("{\"operator\":{\"", "{\"Operator\":{\"");

             var list = this.Deserialize<OperatorDetailResponse>(content);

             if (list != null && list.operator_detail.Count > 0)
             {
                 return list.operator_detail[0].Operator;
             }
             else
             {
                 return null;
             }

        }

      
    }
}
