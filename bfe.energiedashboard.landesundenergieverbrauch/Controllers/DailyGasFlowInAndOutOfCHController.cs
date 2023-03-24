using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DailyGasFlowInAndOutOfCHController : ControllerBase
    {
        private readonly ILogger<DailyGasFlowInAndOutOfCHController> _logger;

        public DailyGasFlowInAndOutOfCHController(ILogger<DailyGasFlowInAndOutOfCHController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetDailyGasFlowInAndOutOfCH")]
        public IEnumerable<DailyGasFlowInAndOutOfCHModel> Get()
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd101_gas_import_export.csv";

            var csvLoader = new CsvDataAccessor();
            var result = csvLoader.GetCSVFromUrl<DailyGasFlowInAndOutOfCHModel>(csvfileUrl);

            return result;
        }


        [HttpGet("{startDate}", Name = "GetDailyGasFlowInAndOutOfCHByStartDate")]
        public IEnumerable<DailyGasFlowInAndOutOfCHModel> Get(DateTime startDate)
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd101_gas_import_export.csv";

            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<DailyGasFlowInAndOutOfCHModel>(csvfileUrl);

            result = result.Where(x => x.Datum >= startDate);

            return result;
        }
    }
}
