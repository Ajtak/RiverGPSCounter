using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MongoDB.Bson;
using Realms;

namespace RiverGPSCounter.DataClass
{
    public partial class GPSCoords : IRealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("order_id")]
        public int OrderId { get; set; }

        [MapTo("latitude")]
        public double Latitude { get; set; }
        
        [MapTo("longitude")]
        public double Longitude { get; set; }
        
        [MapTo("second_latitude")]
        public double? SecondLat { get; set; }

        [MapTo("second_longitude")]
        public double? SecondLong { get; set; }

        [MapTo("distance")]
        public double? Distance { get; set; }

    }
}
