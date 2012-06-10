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

        public NarnooCollection<Operator> ListOperators()
        {
            var content = this.GetResponse(this.getXmlApi(), "listOperators");

            var list = this.Deserialize<OperatorsResponse>(content);


            if (list == null)
            {
                list = new OperatorsResponse();
            }

            return new NarnooCollection<Operator>(list.total_pages, list.operators);
        }

        public NarnooCollection<Operator> SearchOperators(string country, string category, string subcategory, string state, string suburb, string postal_code)
        {
            return this.SearchOperators(country, category, subcategory, state, suburb, postal_code, 1);
        }
        public NarnooCollection<Operator> SearchOperators(string country, string category, string subcategory, string state, string suburb, string postal_code,int page_no)
        {
            var content = this.GetResponse(this.getXmlApi(), "searchOperators",
                new RequestParameter("country", country),
                new RequestParameter("category", category),
                new RequestParameter("subcategory", subcategory),
                new RequestParameter("state", state),
                new RequestParameter("suburb", suburb),
                new RequestParameter("postal_code", postal_code),
                new RequestParameter("page_no",page_no.ToString())
                );

           
            var list = this.Deserialize<SearchOperatorsResponse>(content);


            if (list == null)
            {
                list = new SearchOperatorsResponse();
            }

            return new NarnooCollection<Operator>(list.total_pages, list.search_operators);
        }

        public Operator SingleOperatorDetail(string operatorId)
        {
            var content = this.GetResponse(this.getXmlApi(), "singleOperatorDetail", new RequestParameter("operator_id", operatorId));
          

            var item = this.Deserialize<Operator>(content);

            if (item == null)
            {
                throw new NarnooRequestException("Opertor can not be found.");
            }

            return item;

        }


    }
}
