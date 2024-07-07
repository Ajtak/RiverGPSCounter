﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using RiverGPSCounter.DataClass;

namespace RiverGPSCounter.DataObjects
{
    public partial class Odra : IRealmObject, IRiver
    {
        int IRiver.relation { get => 387605; }

        public GPSCoords? coords { get; set; }

    }
}
