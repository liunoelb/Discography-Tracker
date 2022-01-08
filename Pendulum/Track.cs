using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum
{
    internal class Track
    {
        public string TrackTitle { get; set; }
        public TimeSpan TrackLength { get; set; }
        public string AlbumFk { get; set; }
        public string TrackUrl { get; set; }
        public Track(string sor)
        {
            var d = sor.Split(';');
            TrackTitle = d[0];
            var ts = d[1].Split(':');
            TrackLength = new TimeSpan(0, int.Parse(ts[0]), int.Parse(ts[1]));
            AlbumFk = d[2];
            TrackUrl = d[3];
        }
    }
}
