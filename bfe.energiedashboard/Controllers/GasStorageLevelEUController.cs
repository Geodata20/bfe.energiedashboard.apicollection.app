using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GasStorageLevelEUController : ControllerBase
    {
        private readonly ILogger<GasStorageLevelEUController> _logger;

        public GasStorageLevelEUController(ILogger<GasStorageLevelEUController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetGasStorageLevel")]
        public IEnumerable<GasStorageLevelEuModel> Get()
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd102_fuellstand_gasspeicher.csv";

            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<GasStorageLevelEuModel>(csvfileUrl);

            return result;
        }
    }
}
