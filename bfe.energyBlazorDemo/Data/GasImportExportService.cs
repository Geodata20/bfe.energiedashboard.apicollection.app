using bfe.Energy.Api;

namespace bfe.energyBlazorDemo.Data
{
 
    public class GasImportExportService
    {

        public async Task<List<GasNettoImportModel>> GetGasImportAsync()
        {
            string baseUrl = "https://bfeprototype.sh1.hidora.com/";

            var apiClient = new BfeEnergyApi(baseUrl, new HttpClient());

            var result = await apiClient.GetGasNettoImportAsync();

            return result.ToList();

        }
    }
}
