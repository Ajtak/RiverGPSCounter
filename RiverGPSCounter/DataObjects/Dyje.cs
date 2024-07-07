using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using RiverGPSCounter.DataClass;

namespace RiverGPSCounter.DataObjects
{
    public partial class Dyje : IRealmObject, IRiver
    {
        int IRiver.relation { get => 966493; }
        public GPSCoords? coords { get; set; }

    }
}
