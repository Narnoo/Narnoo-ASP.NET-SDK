using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class RequestParameter
    {
        public RequestParameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

    }
}
