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

        // load csv from url into model
        private readonly string _csvUrl;

        public ElectricityConsumptionPrognoseSDSCController(ILogger<ElectricityConsumptionPrognoseSDSCController> logger)
        {
            _logger = logger;
            
            _csvUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd110_strom_verbrauch_prognose.csv";
        }


        [HttpGet(Name = "GetElectricityConsumptionPrognoseSDSC")]
        public IEnumerable<ElectricityConsumptionPrognoseSDSCModel> Get()
        {
            var csvLoader = new CsvDataAccessor();
            var result = csvLoader.GetCSVFromUrl<ElectricityConsumptionPrognoseSDSCModel>(_csvUrl);

            return result;
        }


        [HttpGet("{startDate}", Name = "GetElectricityConsumptionSDSCByStartDate")]
        public IEnumerable<ElectricityConsumptionPrognoseSDSCModel> Get(DateTime startDate)
        {
            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<ElectricityConsumptionPrognoseSDSCModel>(_csvUrl);

            result = result.Where(x => x.Datum >= startDate);

            return result;
        }
    }
}
