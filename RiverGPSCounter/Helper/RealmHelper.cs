using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Realms;
using RiverGPSCounter.DataClass;
using RiverGPSCounter.DataObjects;
using RiverGPSCounter.Utils;

namespace RiverGPSCounter.Helper
{
    public class RealmHelper
    {
        private Realm realm;

        public RealmHelper()
        {
            realm = Realm.GetInstance(new FileInfo("database.realm").FullName);

        }

        public async Task<bool> ComputeDistances<T>()
    where T : IRealmObject
        {
            var distCords = realm.All<T>().ToList();
            for (var i = 0; i < distCords.Count(); i++)
            {
                var obe = distCords[i] as IRiver;
                var obn = i + 1 < distCords.Count ? distCords[i+1] as IRiver : null;
                if (obe == null || obn == null)
                {
                    return false;
                }

                var obj = obe.coords;
                var nextObj = obn.coords;

                if (obj != null && nextObj != null)
                {
                    var distanceKm = Harvesine.Compute(obj.Latitude, obj.Longitude, nextObj.Latitude, nextObj.Longitude);

                    await realm.WriteAsync(() =>
                    {
                        obj.SecondLat = nextObj.Latitude;
                        obj.SecondLong = nextObj.Longitude;
                        obj.Distance = distanceKm * 1000;
                    });
                }
            }
            Debug.WriteLine("DONE");
            return true;

        }

        public GPSCoords? GetCoords(int orderPerRiver, List<JToken> ppt)
        {
            if(ppt.Count != 2)
            {
                return null;
            }
            return new GPSCoords
            {
                OrderId = orderPerRiver,
                Latitude = (double)ppt[1],
                Longitude = (double)ppt[0]
            };
        }

        public async Task<bool> FillDatabase<T>(JArray points) where T : IRiver
        {

            int orderPerRiver = 0;

            foreach (var point in points)
            {
                var ppt = point.ToList();
                var cds = GetCoords(orderPerRiver++, ppt);
                if(cds == null)
                {
                    return false;
                }

                await realm.WriteAsync(() =>
                {

                   
                    if (typeof(T) == typeof(Becva))
                        realm.Add(new Becva { coords = cds });
                    else if (typeof(T) == typeof(Berounka))
                        realm.Add(new Berounka { coords = cds });
                    else if (typeof(T) == typeof(Dyje))
                        realm.Add(new Dyje { coords = cds });
                    else if (typeof(T) == typeof(Morava))
                        realm.Add(new Morava { coords = cds });
                    else if (typeof(T) == typeof(Ohre))
                        realm.Add(new Ohre { coords = cds });
                    else if (typeof(T) == typeof(Otava))
                        realm.Add(new Otava { coords = cds });
                    else if (typeof(T) == typeof(Sazava))
                        realm.Add(new Sazava { coords = cds });
                    else if (typeof(T) == typeof(Vltava))
                        realm.Add(new Vltava { coords = cds });
                    else if (typeof(T) == typeof(Bilina))
                        realm.Add(new Bilina { coords = cds });
                    else if (typeof(T) == typeof(DivokaOrlice))
                        realm.Add(new DivokaOrlice { coords = cds });
                    else if (typeof(T) == typeof(Chrudimka))
                        realm.Add(new Chrudimka { coords = cds });
                    else if (typeof(T) == typeof(Jihlava))
                        realm.Add(new Jihlava { coords = cds });
                    else if (typeof(T) == typeof(Jizera))
                        realm.Add(new Jizera { coords = cds });
                    else if (typeof(T) == typeof(Labe))
                        realm.Add(new Labe { coords = cds });
                    else if (typeof(T) == typeof(Loucna))
                        realm.Add(new Loucna { coords = cds });
                    else if (typeof(T) == typeof(Luznice))
                        realm.Add(new Luznice { coords = cds });
                    else if (typeof(T) == typeof(Metuje))
                        realm.Add(new Metuje { coords = cds });
                    else if (typeof(T) == typeof(Mostenka))
                        realm.Add(new Mostenka { coords = cds });
                    else if (typeof(T) == typeof(Mze))
                        realm.Add(new Mze { coords = cds });
                    else if (typeof(T) == typeof(Nezarka))
                        realm.Add(new Nezarka { coords = cds });
                    else if (typeof(T) == typeof(NovaReka))
                        realm.Add(new NovaReka { coords = cds });
                    else if (typeof(T) == typeof(Odra))
                        realm.Add(new Odra { coords = cds });
                    else if (typeof(T) == typeof(Opava))
                        realm.Add(new Opava { coords = cds });
                    else if (typeof(T) == typeof(Ostravice))
                        realm.Add(new Ostravice { coords = cds });
                    else if (typeof(T) == typeof(Orlice))
                        realm.Add(new Orlice { coords = cds });
                    else if (typeof(T) == typeof(Ploucnice))
                        realm.Add(new Ploucnice { coords = cds });
                    else if (typeof(T) == typeof(Radbuza))
                        realm.Add(new Radbuza { coords = cds });
                    else if (typeof(T) == typeof(Svratka))
                        realm.Add(new Svratka { coords = cds });
                    else if (typeof(T) == typeof(TichaOrlice))
                        realm.Add(new TichaOrlice { coords = cds });
                    else if (typeof(T) == typeof(Uhlava))
                        realm.Add(new Uhlava { coords = cds });
                    else if (typeof(T) == typeof(Upa))
                        realm.Add(new Upa { coords = cds });
                    else if (typeof(T) == typeof(Vltava))
                        realm.Add(new Vltava { coords = cds });
                });
            }
            return true;
        }

        public async Task<bool> ClearDatabase<T>() where T : IRiver
        {
            await realm.WriteAsync(() =>
            {
                var tDb = realm.All<T>();

                foreach (var t in tDb)
                {
                    var delCoords = t.coords;
                    if (delCoords != null)
                        realm.Remove(delCoords);
                }
                realm.RemoveRange(tDb);
            });

            return true;
        }
    }
}

