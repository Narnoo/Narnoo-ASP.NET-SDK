 using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorProductsResponse
    {
        public OperatorProductsResponse()
        {
            this.operator_products = new List<OperatorProudctResponse>();
        }

        public List<OperatorProudctResponse> operator_products
        {
            get;
            set;
        }
    }
}
