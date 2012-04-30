using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class ProductTextWords
    {
        public string product_title { get; set; }

        public ProductText text { get; set; }
    }

    public class ProductText
    {
        public string word_50 { get; set; }
        public string word_100 { get; set; }
        public string word_150 { get; set; }

    }
}
