using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DailyElectricityFlowInAndOutCHController : ControllerBase
    {
        private readonly ILogger<DailyElectricityFlowInAndOutCHController> _logger;
        // load csv from url into model
        private readonly string _csvUrl;

        private Dictionary<DateTime, IEnumerable<DailyElectricityFlowInAndOutOfCHModel>> _cache;


        public DailyElectricityFlowInAndOutCHController(ILogger<DailyElectricityFlowInAndOutCHController> logger)
        {
            _logger = logger;
            _csvUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd107_strom_import_export.csv";
            _cache = new Dictionary<DateTime, IEnumerable<DailyElectricityFlowInAndOutOfCHModel>>();

            // reload, if last import was yesterday
            if (_cache.Count > 0 && _cache.First().Key.Date < DateTime.Now.Date)
            {
                _cache.Remove(_cache.First().Key.Date);
            }

            if (_cache.Count == 0)
            {
                var csvAccess = new CsvDataAccessor();
                _cache.Add(DateTime.UtcNow, csvAccess.GetCSVFromUrl<DailyElectricityFlowInAndOutOfCHModel>(_csvUrl));
            }

        }


        [HttpGet(Name = "GetDailyElectricityFlowInAndOutCH")]
        public IEnumerable<DailyElectricityFlowInAndOutOfCHModel> Get()
        {
            return _cache.First().Value;
        }


        [HttpGet("{startDate}", Name = "GetDailyElectricityFlowInAndOutCHByStartDate")]
        public IEnumerable<DailyElectricityFlowInAndOutOfCHModel> Get(DateTime startDate)
        {
            var result = _cache.First().Value.Where(x => x.Datetime >= startDate);

            return result;
        }
    }
}
