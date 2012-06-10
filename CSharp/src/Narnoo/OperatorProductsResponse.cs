 using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorProductsResponse:NarnooCollectionResponse
    {
        public OperatorProductsResponse()
        {
            this.operator_products = new List<Product>();
        }

        public List<Product> operator_products
        {
            get;
            set;
        }
    }
}
