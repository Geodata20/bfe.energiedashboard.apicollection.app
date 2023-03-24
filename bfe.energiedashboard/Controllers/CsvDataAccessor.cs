using System;
using System.Globalization;
using System.Net;
using bfe.energiedashboard.landesundenergieverbrauch.Models;
using CsvHelper;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{
    public class CsvDataAccessor
    {

        public IEnumerable<T> GetCSVFromUrl<T>(string url)
        {
            var result = new List<ElectricityConsumptionNationalAndEnduserModel>();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (var reader = new StreamReader(resp.GetResponseStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return  csv.GetRecords<T>().ToList();
            }
        }
    }
}
