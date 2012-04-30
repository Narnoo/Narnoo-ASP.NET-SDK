using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public  class OperatorProductTextWordsListResponse
    {
        public OperatorProductTextWordsListResponse()
        {
            this.operator_products = new List<OperatorProductTextWordsResponse>();
        }
        public List<OperatorProductTextWordsResponse> operator_products
        {
            get;set;
        }
    }
}
