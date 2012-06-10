using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorAlbumsResponse:NarnooCollectionResponse
    {
        public OperatorAlbumsResponse()
        {
            this.operator_albums = new List<Album>();
        }

        public List<Album> operator_albums
        {
            get;
            set;
        }
    }
}
