using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using RiverGPSCounter.DataClass;

namespace RiverGPSCounter.DataObjects
{
    public partial class Sazava : IRealmObject, IRiver
    {
        int IRiver.relation { get => 1772080; }

        public GPSCoords? coords { get; set; }

    }
}
