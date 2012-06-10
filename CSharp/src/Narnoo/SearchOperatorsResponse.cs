using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class SearchOperatorsResponse : NarnooCollectionResponse
    {
        public SearchOperatorsResponse()
        {
            this.search_operators = new List<Operator>();
        }

        public List<Operator> search_operators
        {
            get;
            set;
        }
    }
}
