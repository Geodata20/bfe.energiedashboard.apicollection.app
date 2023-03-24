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
        // load csv from url into model
        private readonly string _csvUrl;

        public ElectricityPriceController(ILogger<ElectricityPriceController> logger)
        {
            _logger = logger;
            _csvUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd106_preise_strom_endverbrauch.csv";
        }


        [HttpGet(Name = "GetElectricityPriceEnduser")]
        public IEnumerable<ElectricityPriceEnduserModel> Get()
        {
            var csvLoader = new CsvDataAccessor();

            return csvLoader.GetCSVFromUrl<ElectricityPriceEnduserModel>(_csvUrl);
        }


    }
}
