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

        public object SearchOperators(string country, string category, string subcategory, string state, string suburb, string postal_code)
        {
            throw new NotImplementedException();
        }
    }
}
