using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class NarnooCollection<T>:List<T>
    {
        

        public NarnooCollection(string totalPages, IEnumerable<T> collection)
        {
            this.ParseTotalPages(totalPages);
            this.AddRange(collection);
        }

        void ParseTotalPages(string totalPages)
        {
            int total = 1;
            if (int.TryParse(totalPages, out total))
            {
                this.TotalPages = total;
            }
            else
            {
                this.TotalPages = 1;
            }
        }

        public int TotalPages
        {
            get;
            set;
        }
    }
}
