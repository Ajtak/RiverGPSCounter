using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RiverGPSCounter.DataClass;

namespace RiverGPSCounter.Utils
{
    public class FileHelper
    {
        public ParsedRiver? ReadFile(string filePath)
        {
            string json = File.ReadAllText(filePath);

            RootObject? root = JsonConvert.DeserializeObject<RootObject>(json);

            if (root == null)
            {
                return null;
            }

            var coords = new List<Pair<double, double>>();
            string? riverName = null;

            JArray? points = null;
            foreach (var feature in root.Features)
            {
                // Dynamické zpracování coordinates
                var coordinates = feature.Geometry.Coordinates as JArray;

                JArray? longestPoints = null;
                if (feature.Geometry.Type == "MultiLineString")
                {
                    longestPoints = coordinates?.OfType<JArray>().OrderByDescending(arr => arr.Count).FirstOrDefault();
                }else if (feature.Geometry.Type == "LineString")
                {
                    longestPoints = coordinates;
                }



                if (coordinates != null && longestPoints != null)
                {
                    riverName = feature.Properties.NameCs ?? feature.Properties.Name;
                    points = longestPoints;

                }
            }

            return new ParsedRiver
            {
                name = riverName,
                gpsPoints = points
            };
        }
    }
}
