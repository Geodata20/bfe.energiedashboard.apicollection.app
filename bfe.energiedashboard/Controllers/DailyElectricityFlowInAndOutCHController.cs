using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DailyElectricityFlowInAndOutCHController : ControllerBase
    {
        private readonly ILogger<DailyElectricityFlowInAndOutCHController> _logger;

        public DailyElectricityFlowInAndOutCHController(ILogger<DailyElectricityFlowInAndOutCHController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetDailyElectricityFlowInAndOutCH")]
        public IEnumerable<DailyElectricityFlowInAndOutOfCHModel> Get()
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd107_strom_import_export.csv";

            var csvLoader = new CsvDataAccessor();
            var result = csvLoader.GetCSVFromUrl<DailyElectricityFlowInAndOutOfCHModel>(csvfileUrl);

            return result;
        }


        [HttpGet("{startDate}", Name = "GetDailyElectricityFlowInAndOutCHByStartDate")]
        public IEnumerable<DailyElectricityFlowInAndOutOfCHModel> Get(DateTime startDate)
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd107_strom_import_export.csv";

            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<DailyElectricityFlowInAndOutOfCHModel>(csvfileUrl);

            result = result.Where(x => x.Datetime >= startDate);

            return result;
        }
    }
}
