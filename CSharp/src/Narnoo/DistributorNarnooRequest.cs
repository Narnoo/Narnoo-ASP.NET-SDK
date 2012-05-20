using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorNarnooRequest : NarnooRequest
    {

        public bool AddOperator(string operatorId)
        {
            var content = this.GetResponse(this.getXmlApi(), "addOperator", new RequestParameter("operator_id", operatorId));

            return content.StartsWith("{\"operator_new\":");
            //try
            //{

            //    //{"operator_new":[{"operator":{"operator_id":"75","operator_businessname":"Mamu Rainforest Canopy Walkway","country_name":"Australia","state":"QLD","suburb":"EAST PALMERSTON","postcode":"4860","keywords":"Rainforest Walkway Mamu"}}]}
            //    var success = this.Deserialize<NarnooSuccessResponse>(content);

            //    return success != null;

            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }

        public bool DeleteOperator(string operatorId)
        {
            var content = this.GetResponse(this.getXmlApi(), "deleteOperator", new RequestParameter("operator_id", operatorId));

            try
            {
                var success = this.Deserialize<NarnooSuccessResponse>(content);

                return success != null;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Operator> ListOperators()
        {
            var content = this.GetResponse(this.getXmlApi(), "listOperators");

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
            var content = this.GetResponse(this.getXmlApi(), "searchOperators",
                new RequestParameter("country", country),
                new RequestParameter("category", category),
                new RequestParameter("subcategory", subcategory),
                new RequestParameter("state", state),
                new RequestParameter("suburb", suburb),
                new RequestParameter("postal_code", postal_code)
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
            var content = this.GetResponse(this.getXmlApi(), "singleOperatorDetail", new RequestParameter("operator_id", operatorId));
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
