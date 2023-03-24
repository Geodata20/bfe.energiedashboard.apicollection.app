using bfe.energiedashboard.landesundenergieverbrauch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace bfe.energiedashboard.landesundenergieverbrauch.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GasNettoImportController : ControllerBase
    {
        private readonly ILogger<GasNettoImportController> _logger;
        // load csv from url into model
        private readonly string _csvUrl;

        public GasNettoImportController(ILogger<GasNettoImportController> logger)
        {
            _logger = logger;
            _csvUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd111_gas_nettoimport.csv";
        }


        [HttpGet(Name = "GetGasNettoImport")]
        public IEnumerable<GasNettoImportModel> Get()
        {
            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<GasNettoImportModel>(_csvUrl);

            return result;
        }


        [HttpGet("{startYear}/{endYear}",Name = "GetGasNettoImportByYearRange")]
        public IEnumerable<GasNettoImportModel> Get(int startYear, int endYear)
        {
            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<GasNettoImportModel>(_csvUrl);

            result = result.Where(x => x.Jahr >= startYear && x.Jahr <= endYear);

            return result;
        }
    }
}
