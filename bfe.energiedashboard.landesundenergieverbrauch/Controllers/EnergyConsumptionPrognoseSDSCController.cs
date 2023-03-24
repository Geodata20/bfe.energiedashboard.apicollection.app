using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EnergyConsumptionPrognoseSDSCController : ControllerBase
    {
        private readonly ILogger<EnergyConsumptionPrognoseSDSCController> _logger;

        public EnergyConsumptionPrognoseSDSCController(ILogger<EnergyConsumptionPrognoseSDSCController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetStromverbrauchPrognoseSDSC")]
        public IEnumerable<StromverbrauchPrognoseSDSCModel> Get()
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd110_strom_verbrauch_prognose.csv";

            var csvLoader = new CsvDataAccessor();
            var result = csvLoader.GetCSVFromUrl<StromverbrauchPrognoseSDSCModel>(csvfileUrl);

            return result;
        }


        [HttpGet("{startDate}", Name = "GetStromverbrauchPrognoseSDSCByStartDate")]
        public IEnumerable<StromverbrauchPrognoseSDSCModel> Get(DateTime startDate)
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd110_strom_verbrauch_prognose.csv";

            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<StromverbrauchPrognoseSDSCModel>(csvfileUrl);

            result = result.Where(x => x.Datum >= startDate);

            return result;
        }
    }
}
