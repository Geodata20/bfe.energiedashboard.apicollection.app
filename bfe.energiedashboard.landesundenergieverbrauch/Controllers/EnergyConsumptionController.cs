using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnergyConsumptionController : ControllerBase
    {
        private readonly ILogger<EnergyConsumptionController> _logger;

        public EnergyConsumptionController(ILogger<EnergyConsumptionController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetEnergyConsumption")]
        public IEnumerable<EnergyConsuptionNationalAndEnduserModel> Get()
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd103_stromverbrauch_swissgrid_lv_und_endv.csv";

            var csvLoader = new CsvDataAccessor();

            return csvLoader.GetCSVFromUrl<EnergyConsuptionNationalAndEnduserModel>(csvfileUrl);
        }

      
    }
}