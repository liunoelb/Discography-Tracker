using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum
{
    internal class Album
    {
        public string AlbumId { get; set; }
        public string AlbumArtist { get; set; }
        public string AlbumTitle { get; set; }
        public DateTime AlbumRelease { get; set; }
        public Album(string sor)
        {
            var d = sor.Split(';');
            AlbumId = d[0];
            AlbumArtist = d[1];
            AlbumTitle = d[2];
            AlbumRelease = DateTime.Parse(d[3]);
        }
    }
}
