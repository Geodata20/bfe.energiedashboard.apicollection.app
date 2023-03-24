using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EnergyPriceController : ControllerBase
    {
        private readonly ILogger<EnergyPriceController> _logger;

        public EnergyPriceController(ILogger<EnergyPriceController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetEnergyPriceEnduser")]
        public IEnumerable<EnergyPriceEnduserModel> Get()
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd106_preise_strom_endverbrauch.csv";

            var csvLoader = new CsvDataAccessor();

            return csvLoader.GetCSVFromUrl<EnergyPriceEnduserModel>(csvfileUrl);
        }


    }
}
