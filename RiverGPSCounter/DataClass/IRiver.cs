using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace RiverGPSCounter.DataClass
{
    public interface IRiver : IRealmObject
    {
        public int relation { get; }

        public GPSCoords? coords { get; set; }

    }
}
