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

        public GasNettoImportController(ILogger<GasNettoImportController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetGasNettoImport")]
        public IEnumerable<GasNettoImportModel> Get()
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd111_gas_nettoimport.csv";

            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<GasNettoImportModel>(csvfileUrl);

            return result;
        }


        [HttpGet("{startYear}/{endYear}",Name = "GetGasNettoImportByYearRange")]
        public IEnumerable<GasNettoImportModel> Get(int startYear, int endYear)
        {
            // load csv from url into model
            string csvfileUrl = "https://bfe-energy-dashboard-ogd.s3.amazonaws.com/ogd111_gas_nettoimport.csv";

            var csvLoader = new CsvDataAccessor();

            var result = csvLoader.GetCSVFromUrl<GasNettoImportModel>(csvfileUrl);

            result = result.Where(x => x.Jahr >= startYear && x.Jahr <= endYear);

            return result;
        }
    }
}
