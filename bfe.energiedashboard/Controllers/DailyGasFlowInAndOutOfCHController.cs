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
        // load csv from url into model
        private readonly string _csvUrl;


        public DailyGasFlowInAndOutOfCHController(ILogger<DailyGasFlowInAndOutOfCHController> logger)
        {
            _logger = logger;
            _csvUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd101_gas_import_export.csv";
        }


        [HttpGet(Name = "GetDailyGasFlowInAndOutOfCH")]
        public IEnumerable<DailyGasFlowInAndOutOfCHModel> Get()
        {
            var csvLoader = new CsvDataAccessor();
            var result = csvLoader.GetCSVFromUrl<DailyGasFlowInAndOutOfCHModel>(_csvUrl);

            return result;
        }


        [HttpGet("{startDate}", Name = "GetDailyGasFlowInAndOutOfCHByStartDate")]
        public IEnumerable<DailyGasFlowInAndOutOfCHModel> Get(DateTime startDate)
        {
            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<DailyGasFlowInAndOutOfCHModel>(_csvUrl);

            result = result.Where(x => x.Datum >= startDate);

            return result;
        }
    }
}
