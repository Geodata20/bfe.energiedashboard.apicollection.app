using System;
using System.Globalization;
using System.Net;
using bfe.energiedashboard.landesundenergieverbrauch.Models;
using CsvHelper;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{
    public class CsvDataAccessor
    {

        public string GetCSV(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }


        public IEnumerable<EnergyConsuptionNationalAndEnduserModel> GetCSVFromUrl(string url)
        {
            var result = new List<EnergyConsuptionNationalAndEnduserModel>();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (var reader = new StreamReader(resp.GetResponseStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return  csv.GetRecords<EnergyConsuptionNationalAndEnduserModel>().ToList();
            }
        }
    }
}
