using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using RiverGPSCounter.DataClass;

namespace RiverGPSCounter.DataObjects
{        
    public partial class Morava : IRealmObject, IRiver
    {
        int IRiver.relation { get => 1741294; }

        public GPSCoords? coords { get; set; }

    }
}
