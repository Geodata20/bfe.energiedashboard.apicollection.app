using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElectricityConsumptionController : ControllerBase
    {
        private readonly ILogger<ElectricityConsumptionController> _logger;

        public ElectricityConsumptionController(ILogger<ElectricityConsumptionController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetElectricityConsumption")]
        public IEnumerable<ElectricityConsumptionNationalAndEnduserModel> Get()
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd103_stromverbrauch_swissgrid_lv_und_endv.csv";

            var csvLoader = new CsvDataAccessor();

            return csvLoader.GetCSVFromUrl<ElectricityConsumptionNationalAndEnduserModel>(csvfileUrl);
        }


        [HttpGet("{startDate}", Name = "GetElectricityConsumptionNationalAndEnduserByStartDate")]
        public IEnumerable<ElectricityConsumptionNationalAndEnduserModel> Get(DateTime startDate)
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd103_stromverbrauch_swissgrid_lv_und_endv.csv";

            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<ElectricityConsumptionNationalAndEnduserModel>(csvfileUrl);

            result = result.Where(x => x.Datum.ToDateTime(TimeOnly.MinValue) >= startDate);

            return result;
        }

    }
}