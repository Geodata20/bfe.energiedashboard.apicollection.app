using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ElectricityPriceController : ControllerBase
    {
        private readonly ILogger<ElectricityPriceController> _logger;

        public ElectricityPriceController(ILogger<ElectricityPriceController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetElectricityPriceEnduser")]
        public IEnumerable<ElectricityPriceEnduserModel> Get()
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd106_preise_strom_endverbrauch.csv";

            var csvLoader = new CsvDataAccessor();

            return csvLoader.GetCSVFromUrl<ElectricityPriceEnduserModel>(csvfileUrl);
        }


    }
}
