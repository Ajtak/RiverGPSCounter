using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using RiverGPSCounter.DataClass;

namespace RiverGPSCounter.DataObjects
{
    public partial class Ostravice : IRealmObject, IRiver
    {
        int IRiver.relation { get => 6048107; }

        public GPSCoords? coords { get; set; }

    }
}
