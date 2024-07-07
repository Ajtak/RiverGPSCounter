using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiverGPSCounter
{
    public class Properties
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name:cs")]
        public string NameCs { get; set; }

        [JsonProperty("name:de")]
        public string NameDe { get; set; }

        [JsonProperty("name:nl")]
        public string NameNl { get; set; }

        [JsonProperty("ref:fgkz")]
        public string RefFgkz { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("waterway")]
        public string Waterway { get; set; }

        [JsonProperty("wikidata")]
        public string Wikidata { get; set; }

        [JsonProperty("wikipedia")]
        public string Wikipedia { get; set; }
    }

    public class Feature
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        // Obecná vlastnost pro různé formáty coordinates
        [JsonProperty("coordinates")]
        public object Coordinates { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("generator")]
        public string Generator { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }

}
