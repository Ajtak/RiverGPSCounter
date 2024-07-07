using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RiverGPSCounter.DataClass
{
    public class ParsedRiver
    {
        public string? name { get; set; }

        public JArray? gpsPoints { get; set;}
    }
}
