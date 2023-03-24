using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ElectricityConsumptionPrognoseSDSCController : ControllerBase
    {
        private readonly ILogger<ElectricityConsumptionPrognoseSDSCController> _logger;

        private string _csvUrl = "";

        public ElectricityConsumptionPrognoseSDSCController(ILogger<ElectricityConsumptionPrognoseSDSCController> logger)
        {
            _logger = logger;
            _csvUrl = "";
        }


        [HttpGet(Name = "GetElectricityConsumptionPrognoseSDSC")]
        public IEnumerable<ElectricityConsumptionPrognoseSDSCModel> Get()
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd110_strom_verbrauch_prognose.csv";

            var csvLoader = new CsvDataAccessor();
            var result = csvLoader.GetCSVFromUrl<ElectricityConsumptionPrognoseSDSCModel>(csvfileUrl);

            return result;
        }


        [HttpGet("{startDate}", Name = "GetElectricityConsumptionSDSCByStartDate")]
        public IEnumerable<ElectricityConsumptionPrognoseSDSCModel> Get(DateTime startDate)
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd110_strom_verbrauch_prognose.csv";

            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<ElectricityConsumptionPrognoseSDSCModel>(csvfileUrl);

            result = result.Where(x => x.Datum >= startDate);

            return result;
        }
    }
}
