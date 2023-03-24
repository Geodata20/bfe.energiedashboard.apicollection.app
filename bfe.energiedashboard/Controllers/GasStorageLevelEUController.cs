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
        // load csv from url into model
        private readonly string _csvUrl;

        public GasStorageLevelEUController(ILogger<GasStorageLevelEUController> logger)
        {
            _logger = logger;
            _csvUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd102_fuellstand_gasspeicher.csv";
        }


        [HttpGet(Name = "GetGasStorageLevel")]
        public IEnumerable<GasStorageLevelEuModel> Get()
        {
            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<GasStorageLevelEuModel>(_csvUrl);

            return result;
        }
    }
}
