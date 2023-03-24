using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElectricityConsumptionController : ControllerBase
    {
        private readonly ILogger<ElectricityConsumptionController> _logger;
        // load csv from url into model
        private readonly string _csvUrl;

        public ElectricityConsumptionController(ILogger<ElectricityConsumptionController> logger)
        {
            _logger = logger;
            _csvUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd103_stromverbrauch_swissgrid_lv_und_endv.csv";
        }


        [HttpGet(Name = "GetElectricityConsumption")]
        public IEnumerable<ElectricityConsumptionNationalAndEnduserModel> Get()
        {
            var csvLoader = new CsvDataAccessor();

            return csvLoader.GetCSVFromUrl<ElectricityConsumptionNationalAndEnduserModel>(_csvUrl);
        }


        [HttpGet("{startDate}", Name = "GetElectricityConsumptionNationalAndEnduserByStartDate")]
        public IEnumerable<ElectricityConsumptionNationalAndEnduserModel> Get(DateTime startDate)
        {
            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<ElectricityConsumptionNationalAndEnduserModel>(_csvUrl);

            result = result.Where(x => x.Datum.ToDateTime(TimeOnly.MinValue) >= startDate);

            return result;
        }

    }
}