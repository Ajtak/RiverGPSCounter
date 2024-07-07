using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using OsmSharp.Complete;
using OsmSharp.Tags;
using OsmSharp;
using System;
using System.IO;
using System.Net.Http;
using System.Diagnostics;
using RiverGPSCounter.Utils;
using System.Reflection;
using System.Xml.Linq;
using RiverGPSCounter.DataClass;


namespace RiverGPSCounter
{
    public partial class DataDownloader : Form
    {
        string subPath = "GeoJsons";

        public DataDownloader()
        {
            InitializeComponent();


            string subPath = "GeoJsons"; // Your code goes here

            bool exists = Directory.Exists(subPath);
            if (!exists)
                Directory.CreateDirectory(subPath);

        }



        private async Task<bool> DownloadRiver(IRiver river)
        {
            var name = river.ObjectSchema!.Name;
            var relationId = river.relation;

            if (relationId == 0)
            {
                return false;
            }

            string overpassUrl = "http://overpass-api.de/api/interpreter";
            string overpassQuery = "[out:json][timeout:25];relation(" + relationId + ");out geom;";


            // Odeslání požadavku na Overpass API
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{overpassUrl}?data={Uri.EscapeDataString(overpassQuery)}");

            // Kontrola, zda byl požadavek úspěšný
            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                string tempOsmFile = Path.GetTempFileName();
                File.WriteAllText(tempOsmFile, jsonData);

                // Převod JSON dat na GeoJSON pomocí osmtogeojson command line tool
                string geoJson = await ConvertToGeoJsonAsync(tempOsmFile);
                File.WriteAllText(Path.Combine(subPath, string.Format("{0}-{1}.geojson", name, relationId)), geoJson);

                File.Delete(tempOsmFile);  


                return true;
            }
            return false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == "RiverGPSCounter.DataObjects" && t.IsVisible == true
                    select t;

            foreach (var clazz in q)
            {
                IRiver? clz = Activator.CreateInstance(clazz) as IRiver;
                await DownloadRiver(clz!);
            }
        }


        static async Task<string> ConvertToGeoJsonAsync(string osmFilePath)
        {
            using (var app = new Process())
            {
                app.StartInfo.FileName = "osmtogeojson.cmd";
                app.StartInfo.Arguments = osmFilePath;
                app.EnableRaisingEvents = true;
                app.StartInfo.RedirectStandardOutput = true;
                app.StartInfo.RedirectStandardError = true;
                // Must not set true to execute PowerShell command
                app.StartInfo.UseShellExecute = false;
                app.StartInfo.RedirectStandardOutput = true;
                app.StartInfo.StandardOutputEncoding = Encoding.UTF8; // Nastavte správné kódování
                app.Start();
                using (var o = app.StandardOutput)
                {
                    return await o.ReadToEndAsync();
                }
            }

        }

    }
}
