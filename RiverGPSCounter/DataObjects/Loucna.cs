using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using RiverGPSCounter.DataClass;

namespace RiverGPSCounter.DataObjects
{
    public partial class Loucna : IRealmObject, IRiver
    {
        int IRiver.relation { get => 7032231; }

        public GPSCoords? coords { get; set; }

    }
}
