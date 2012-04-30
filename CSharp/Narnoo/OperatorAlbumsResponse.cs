using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorAlbumsResponse
    {
        public OperatorAlbumsResponse()
        {
            this.operator_albums = new List<AlbumResponse>();
        }

        public List<AlbumResponse> operator_albums
        {
            get;
            set;
        }
    }
}
